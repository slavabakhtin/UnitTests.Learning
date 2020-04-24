using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eiip.Common.Extensions;
using Eiip.PushNotifications.Database.Models;
using FirebaseAdmin.Messaging;
using Microsoft.Extensions.Logging;

namespace Eiip.PushNotifications.Service.Fcm
{
    public class PushNotificationSender
    {
        private readonly ILogger _logger;
        private readonly FirebaseMessaging _firebaseMessaging;
        private readonly MulticastMessageFactory _messageFactory;
        private FcmTokenProvider _fcmTokenProvider;

        // Currently this is the only way we can handle invalid token error. Check FirebaseAdmin library updates for better solution
        private const string InvalidTokenMessage = "The registration token is not a valid FCM registration token";

        public PushNotificationSender(ILogger<PushNotificationSender> logger,
            FirebaseMessaging firebaseMessaging,
            MulticastMessageFactory messageFactory)
        {
            _logger = logger;
            _firebaseMessaging = firebaseMessaging;
            _messageFactory = messageFactory;
        }

        public void WithTokenProvider(FcmTokenProvider tokenProvider)
        {
            _fcmTokenProvider = tokenProvider;
        }

        public async Task Send<T>(T messageDetails, string uid) where T : NotificationDetails
        {
            if (_fcmTokenProvider == null)
            {
                throw new ApplicationException($"{nameof(_fcmTokenProvider)} is null, please call {nameof(WithTokenProvider)} first.");
            }

            var tokens = await _fcmTokenProvider.GetRegistrationTokens(uid);
            if (!tokens.Any())
            {
                _logger.LogInformation($"{messageDetails.GetType().Name} ({messageDetails.ToJson()}) message is failed. Tokens for {uid} not found");
                return;
            }
            var registrationTokens = tokens.Select(x => x.Token).ToArray();
            var message = _messageFactory.Build(registrationTokens, messageDetails);

            _logger.LogInformation($"Sending {messageDetails.GetType().Name} ({messageDetails.ToJson()}) message to UID={uid}");
            var response = await _firebaseMessaging.SendMulticastAsync(message);
            
            await ProcessFailedTokensIfAny<T>(_fcmTokenProvider, response, tokens);
        }

        private async Task ProcessFailedTokensIfAny<T>(FcmTokenProvider fcmTokenProvider, BatchResponse response,
            IReadOnlyList<IFcmToken> tokens)
        {
            var failedTokens = tokens
                .Where((tokenRecord, i) => DeliveryFailedBecauseTokenIsInvalid<T>(tokenRecord, i, response.Responses))
                .ToList();
            if (failedTokens.Any())
            {
                await fcmTokenProvider.ProcessFailedTokens(failedTokens);
            }
        }

        private bool DeliveryFailedBecauseTokenIsInvalid<T>(IFcmToken fcmToken, int index, IReadOnlyList<SendResponse> deliveryResponses)
        {
            if (deliveryResponses[index].IsSuccess)
            {
                return false;
            }

            if (deliveryResponses[index].Exception.Message == InvalidTokenMessage)
            {
                return true;
            }

            _logger.LogWarning($"Push notification delivery of type {typeof(T).Name} for UID=[{fcmToken.Uid}] failed, but token is valid. " +
                               $"FCM message: {deliveryResponses[index].Exception.Message}");
            return false;
        }
    }
}