using System.Collections.Generic;
using FirebaseAdmin.Messaging;

namespace Eiip.PushNotifications.Service.Fcm.Passenger.Messages
{
    public class RepeatSearchMessageDetails : NotificationDetails
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
                Title = "Looking for a new taxi",
                Body = "Looks like that driver has canceled the ride. Don’t worry, we are already searching a new one"
            };
        }

        public override string NotificationType => "p_repeat_search";
    }
}