using System.Collections.Generic;
using FirebaseAdmin.Messaging;

namespace Eiip.PushNotifications.Service.Fcm.Driver.Messages
{
    public class CarRemovedMessageDetails : NotificationDetails
    {
        public string TaxiParkContacts { get; set; }

        public override Dictionary<string, string> GetData()
        {
            return new Dictionary<string, string>()
            {
                {nameof(TaxiParkContacts), TaxiParkContacts}
            };
        }

        public override Notification GetNotification()
        {
            return new Notification()
            {
                Title = "Car unassigned",
                Body = $"Taxi park unassigned your car. Please contact {TaxiParkContacts}"
            };
        }

        public override string NotificationType => "d_car_removed";
    }
}