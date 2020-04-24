using FirebaseAdmin.Messaging;

namespace Eiip.PushNotifications.Service.Fcm
{
    public class MulticastMessageFactory
    {
        public MulticastMessage Build(string[] tokens, NotificationDetails message)
        {
            var data = message.GetData();
            data.Add("type", message.NotificationType);

            return new MulticastMessage()
            {
                Tokens = tokens,
                Data = data,
                Notification = message.GetNotification()
            };
        }
    }
}