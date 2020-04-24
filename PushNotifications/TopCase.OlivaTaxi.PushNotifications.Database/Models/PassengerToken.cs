using System;
using TopCase.OlivaTaxi.Common.Enums;

namespace TopCase.OlivaTaxi.PushNotifications.Database.Models
{
    public class PassengerToken : IFcmToken
    {
        public string Uid { get; set; }

        public DateTime Timestamp { get; set; }

        public string Token { get; set; }

        public MobilePlatform Platform { get; set; }
    }
}