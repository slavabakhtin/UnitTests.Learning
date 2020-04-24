using System.Collections.Generic;
using FirebaseAdmin.Messaging;

namespace Eiip.PushNotifications.Service.Fcm.Driver.Messages
{
    public class FutureTripReminderMessageDetails : NotificationDetails
    {
        public string ClientAddress { get; set; }

        public override Dictionary<string, string> GetData()
        {
            return new Dictionary<string, string>()
            {
                {nameof(ClientAddress), ClientAddress}
            };
        }

        public override Notification GetNotification()
        {
            return new Notification()
            {
                Title = "Time to ride",
                Body = $"It’s time to ride to the client at {ClientAddress}"
            };
        }

        public override string NotificationType => "d_future_reminder";
    }
}