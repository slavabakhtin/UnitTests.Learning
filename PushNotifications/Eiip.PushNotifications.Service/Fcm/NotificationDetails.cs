﻿using System.Collections.Generic;
using System.Text.Json.Serialization;
using FirebaseAdmin.Messaging;
using TopCase.OlivaTaxi.Common.Extensions;

namespace Eiip.PushNotifications.Service.Fcm
{
    public abstract class NotificationDetails
    {
        public virtual Dictionary<string, string> GetData()
        {
            return new Dictionary<string, string>();
        }

        public abstract Notification GetNotification();

        [JsonIgnore]
        public abstract string NotificationType { get; }

        public override string ToString()
        {
            return this.ToJson();
        }
    }
}