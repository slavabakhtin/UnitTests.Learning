using Eiip.Common.Enums;
using System;

namespace Eiip.PushNotifications.Database.Models
{
    public class FcmToken : IFcmToken
    {
        public string Uid { get; set; }

        public DateTime Timestamp { get; set; }

        public string Token { get; set; }

        public MobilePlatform Platform { get; set; }
    }
}