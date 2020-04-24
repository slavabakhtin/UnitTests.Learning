using System.Collections.Generic;
using FirebaseAdmin.Messaging;

namespace Eiip.PushNotifications.Service.Fcm.Driver.Messages
{
    public class CarAssignedMessageDetails : NotificationDetails
    {
        public string CarColor { get; set; }

        public string CarBrand { get; set; }

        public string CarModel { get; set; }

        public string CarNumber { get; set; }

        public override Dictionary<string, string> GetData()
        {
            return new Dictionary<string, string>()
            {
                {nameof(CarColor), CarColor},
                {nameof(CarBrand), CarBrand},
                {nameof(CarModel), CarModel},
                {nameof(CarNumber), CarNumber}
            };
        }

        public override Notification GetNotification()
        {
            return new Notification()
            {
                Title = "Car assigned",
                Body = $"Taxi park assigned {CarColor} {CarBrand} {CarModel} {CarNumber} to you. Enjoy your rides!"
            };
        }

        public override string NotificationType => "d_car_added";
    }
}