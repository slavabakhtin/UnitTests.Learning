﻿using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            //Arrange
            var mockRepository = new MockRepository(MockBehavior.Default);
            var dataProviderMock = mockRepository.Create<DataProvider>();
            var persons = GetTestPersons();
            dataProviderMock.Setup(x => x.GetPersons()).Returns(persons);
            var notificationSenderMock = mockRepository.Create<NotificationSender>();
            var service = new NotificationService(dataProviderMock.Object, notificationSenderMock.Object);

            //Act
            service.SendNotifications();

            //Assert
            dataProviderMock.Verify(x => x.GetPersons());
            notificationSenderMock.Verify(x => persons.ToList().ForEach(x.SendToPerson), Times.Exactly(persons.Length));
        }

        [TestMethod]
        public void SendNotifications_PersonsConsistsOfLessThan1Element_ReturnedApplicationException()
        {
            //Arrange
            var mockRepository = new MockRepository(MockBehavior.Default);
            var dataProviderMock = mockRepository.Create<DataProvider>();
            dataProviderMock.Setup(x => x.GetPersons()).Returns(GetOneTestPerson());
            var notificationSenderMock = mockRepository.Create<NotificationSender>();
            var service = new NotificationService(dataProviderMock.Object, notificationSenderMock.Object);

            //Assert
            Assert.ThrowsException<ApplicationException>(() => service.SendNotifications());
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
