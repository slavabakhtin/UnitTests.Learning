using System;
using System.Linq;
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
        [ExpectedException(typeof(ApplicationException),"Persons consists less than 1 element")]
        public void SendNotifications_PersonsConsistsLessThan1Element_ReturnedApplicationException()
        {
            //Arrange
            var mockRepository = new MockRepository(MockBehavior.Default);
            var dataProviderMock = mockRepository.Create<DataProvider>();
            dataProviderMock.Setup(x => x.GetPersons()).Returns(GetOneTestPerson());
            var notificationSenderMock = mockRepository.Create<NotificationSender>();
            var service = new NotificationService(dataProviderMock.Object, notificationSenderMock.Object);

            //Act
            service.SendNotifications();
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
