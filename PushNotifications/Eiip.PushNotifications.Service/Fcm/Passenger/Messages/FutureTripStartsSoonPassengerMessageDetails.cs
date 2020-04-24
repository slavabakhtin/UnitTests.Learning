using System.Collections.Generic;
using FirebaseAdmin.Messaging;

namespace Eiip.PushNotifications.Service.Fcm.Passenger.Messages
{
    public class FutureTripStartsSoonPassengerMessageDetails : NotificationDetails
    {
        public int OrderId { get; set; }

        public int MinToStart { get; set; }

        public override Dictionary<string, string> GetData()
        {
            return new Dictionary<string, string>()
            {
                {nameof(MinToStart), MinToStart.ToString()},
                {nameof(OrderId), OrderId.ToString()}
            };
        }

        public override Notification GetNotification()
        {
            return new Notification()
            {
                Title = "Future ride will start soon",
                Body = $"Your ride will start in {MinToStart} minutes"
            };
        }

        public override string NotificationType => "p_future_soon";
    }
}