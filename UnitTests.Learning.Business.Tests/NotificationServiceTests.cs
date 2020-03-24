using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTests.Learning.Business.Tests
{
    [TestClass]
    public class NotificationServiceTests
    {
        [TestMethod]
        public void SendNotifications_CheckCallingDataProviderNotificationSenderMethods()
        {
            var mockRepository = new MockRepository(MockBehavior.Default);
            var dataProviderMock = mockRepository.Create<DataProvider>();
            dataProviderMock.Setup(x => x.GetPersons()).Returns(GetTestPersons());
            var persons = dataProviderMock.Object.GetPersons().ToList();
            var notificationSenderMock = mockRepository.Create<NotificationSender>();
            var service = new NotificationService(dataProviderMock.Object, notificationSenderMock.Object);

            service.SendNotifications();

            dataProviderMock.Verify(x => x.GetPersons());
            notificationSenderMock.Verify(x => persons.ForEach(x.SendToPerson), Times.Exactly(persons.Count));
        }

        [TestMethod]
        public void SendNotifications_PersonsConsistLess1Element_ReturnedApplicationException()
        {
            var mockRepository = new MockRepository(MockBehavior.Default);
            var dataProviderMock = mockRepository.Create<DataProvider>();
            dataProviderMock.Setup(x => x.GetPersons()).Returns(GetOneTestPerson());
            var notificationSenderMock = mockRepository.Create<NotificationSender>();
            var service = new NotificationService(dataProviderMock.Object, notificationSenderMock.Object);

            service.SendNotifications();

            Assert.IsInstanceOfType(service, typeof(ApplicationException));
        }

        private Person[] GetTestPersons()
        {
            return new[]
            {
                new Person { Name="Lena", Age=20},
                new Person { Name="Diana", Age=20},
                new Person { Name="Olya", Age=20},
                new Person { Name="Vika", Age=19}
            };
        }

        private Person[] GetOneTestPerson()
        {
            return new[]
            {
                new Person { Name="Lena", Age=20}
            };
        }
    }
}
