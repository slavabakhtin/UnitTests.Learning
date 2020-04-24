using System.Collections.Generic;
using FirebaseAdmin.Messaging;

namespace Eiip.PushNotifications.Service.Fcm.Driver.Messages
{
    public class NewHotOrderMessageDetails : NotificationDetails
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
                Title = "HOT order!!!",
                Body = "HOT!!! don’t miss this order"
            };
        }

        public override string NotificationType => "d_order_hot";
    }
}