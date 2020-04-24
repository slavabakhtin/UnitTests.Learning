using System.Collections.Generic;
using FirebaseAdmin.Messaging;

namespace Eiip.PushNotifications.Service.Fcm.Passenger.Messages
{
    public class FreeWaitingFinishedMessageDetails : NotificationDetails
    {
        public int OrderId { get; set; }

        public override Dictionary<string, string> GetData()
        {
            return new Dictionary<string, string>()
            {
                {nameof(OrderId), OrderId.ToString()}
            };
        }

        public override Notification GetNotification()
        {
            return new Notification()
            {
                Title = "Free wait finished",
                Body = "Your free wait has ended. Please hurry!"
            };
        }

        public override string NotificationType => "p_wait_paid";
    }
}