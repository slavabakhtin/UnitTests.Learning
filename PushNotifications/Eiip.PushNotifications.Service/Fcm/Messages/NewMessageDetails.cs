using FirebaseAdmin.Messaging;

namespace Eiip.PushNotifications.Service.Fcm.Messages
{
    public class NewMessageDetails : NotificationDetails
    {
        public override Notification GetNotification()
        {
            return new Notification()
            {
                Title = "Title",
                Body = "Body"
            };
        }

        public override string NotificationType => "new_message";
    }
}