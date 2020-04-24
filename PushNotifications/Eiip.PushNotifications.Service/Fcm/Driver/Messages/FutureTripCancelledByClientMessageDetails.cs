using System.Collections.Generic;
using FirebaseAdmin.Messaging;

namespace Eiip.PushNotifications.Service.Fcm.Driver.Messages
{
    public class FutureTripCancelledByClientMessageDetails : NotificationDetails
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
                Title = "Future ride canceled",
                Body = "Looks like client canceled the order. We are sorry"
            };
        }

        public override string NotificationType => "d_future_cancelbyclient";
    }
}