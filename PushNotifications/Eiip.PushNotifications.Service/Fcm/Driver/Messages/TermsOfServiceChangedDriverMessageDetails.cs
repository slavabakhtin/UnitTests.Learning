using FirebaseAdmin.Messaging;

namespace Eiip.PushNotifications.Service.Fcm.Driver.Messages
{
    public class TermsOfServiceChangedDriverMessageDetails : NotificationDetails
    {
        public override Notification GetNotification()
        {
            return new Notification()
            {
                Title = "Terms of service have changed",
                Body = "Terms of service have changed. Please take a look"
            };
        }

        public override string NotificationType => "d_terms_of_service_upd";
    }
}