using System.Collections.Generic;
using FirebaseAdmin.Messaging;

namespace Eiip.PushNotifications.Service.Fcm.Passenger.Messages
{
    public class TripPausedMessageDetails : NotificationDetails
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
                Title = "Ride paused",
                Body = "Your ride paused. Keep in mind that waiting can be charged"
            };
        }

        public override string NotificationType => "p_ride_wait";
    }
}
