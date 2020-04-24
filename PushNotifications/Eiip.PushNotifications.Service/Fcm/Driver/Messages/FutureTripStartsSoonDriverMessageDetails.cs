using System.Collections.Generic;
using FirebaseAdmin.Messaging;

namespace Eiip.PushNotifications.Service.Fcm.Driver.Messages
{
    public class FutureTripStartsSoonDriverMessageDetails : NotificationDetails
    {
        public int OrderId { get; set; }

        public string ClientAddress { get; set; }

        public int MinToStart { get; set; }

        public override Dictionary<string, string> GetData()
        {
            return new Dictionary<string, string>()
            {
                {nameof(ClientAddress), ClientAddress},
                {nameof(MinToStart), MinToStart.ToString()},
                {nameof(OrderId), OrderId.ToString()}
            };
        }

        public override Notification GetNotification()
        {
            return new Notification()
            {
                Title = "Future ride will start soon",
                Body = $"Your ride to {ClientAddress} will start in {MinToStart} minutes. Get ready!"
            };
        }

        public override string NotificationType => "d_future_soon";
    }
}