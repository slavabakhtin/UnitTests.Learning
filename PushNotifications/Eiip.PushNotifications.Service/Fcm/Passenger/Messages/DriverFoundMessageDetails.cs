using System.Collections.Generic;
using FirebaseAdmin.Messaging;

namespace Eiip.PushNotifications.Service.Fcm.Passenger.Messages
{
    public class DriverFoundMessageDetails : NotificationDetails
    {
        public int OrderId { get; set; }

        public CarInfo CarInfo { get; set; }

        public int WaitingMin { get; set; }

        public override Dictionary<string, string> GetData()
        {
            return new Dictionary<string, string>()
            {
                {nameof(OrderId), OrderId.ToString()},
                {nameof(CarInfo.Color), CarInfo.Color},
                {nameof(CarInfo.Brand), CarInfo.Brand},
                {nameof(CarInfo.Model), CarInfo.Model},
                {nameof(CarInfo.Number), CarInfo.Number},
                {nameof(WaitingMin), WaitingMin.ToString()}
            };
        }

        public override Notification GetNotification()
        {
            return new Notification()
            {
                Title = "Driver found",
                Body = $"{CarInfo.Color} {CarInfo.Brand} {CarInfo.Model} {CarInfo.Number} will arrive in {WaitingMin} minutes"
            };
        }

        public override string NotificationType => "p_taxi_found";
    }
}