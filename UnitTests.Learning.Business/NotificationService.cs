using System;

namespace UnitTests.Learning.Business
{
    public class NotificationService
    {
        private readonly DataProvider _dataProvider;
        private readonly NotificationSender _notificationSender;

        public NotificationService(DataProvider dataProvider, NotificationSender notificationSender)
        {
            _dataProvider = dataProvider;
            _notificationSender = notificationSender;
        }

        public void SendNotifications()
        {
            throw new NotImplementedException();
        }
    }
}