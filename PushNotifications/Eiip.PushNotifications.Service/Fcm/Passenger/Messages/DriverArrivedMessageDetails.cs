﻿using System.Collections.Generic;
using FirebaseAdmin.Messaging;

namespace Eiip.PushNotifications.Service.Fcm.Passenger.Messages
{
    public class DriverArrivedMessageDetails : NotificationDetails
    {
        public int OrderId { get; set; }

        public CarInfo CarInfo { get; set; }

        public int FreeWaitingMin { get; set; }

        public override Dictionary<string, string> GetData()
        {
            return new Dictionary<string, string>()
            {
                {nameof(OrderId), OrderId.ToString()},
                {nameof(CarInfo.Color), CarInfo.Color},
                {nameof(CarInfo.Brand), CarInfo.Brand},
                {nameof(CarInfo.Model), CarInfo.Model},
                {nameof(CarInfo.Number), CarInfo.Number},
                {nameof(FreeWaitingMin), FreeWaitingMin.ToString()}
            };
        }

        public override Notification GetNotification()
        {
            return new Notification()
            {
                Title = "Driver arrived",
                Body = $"{CarInfo.Color} {CarInfo.Brand} {CarInfo.Model} {CarInfo.Number} arrived. You have {FreeWaitingMin} minutes of free wait"
            };
        }

        public override string NotificationType => "p_wait_free";
    }
}