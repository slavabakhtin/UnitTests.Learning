using FirebaseAdmin.Messaging;

namespace Eiip.PushNotifications.Service.Fcm.Passenger.Messages
{
    public class TermsOfServiceChangedPassengerMessageDetails : NotificationDetails
    {
        public override Notification GetNotification()
        {
            return new Notification()
            {
                Title = "Terms of service have changed",
                Body = "Terms of service have changed. Please take a look"
            };
        }

        public override string NotificationType => "p_terms_of_service";
    }
}
