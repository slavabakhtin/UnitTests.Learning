using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Moq;

namespace UnitTests.Learning.Business.Tests
{
    [TestClass]
    public class DataProviderTests
    {
        [TestMethod]
        public void GetPersons_ShouldReturnPersonsOnlyFrom18To25Years()
        {
            //Arrange
            var dataProvider = new DataProvider();
            
            //Act
            var persons = dataProvider.GetPersons();

            //Assert
            Assert.IsTrue(persons.All(x => x.Age >= 18 && x.Age <= 25));
        }

        [TestMethod]
        public void GetPersons_ReturnedNotNullList()
        {
            //Arrange
            var dataProvider = new DataProvider();

            //Act
            var persons = dataProvider.GetPersons();

            //Assert
            Assert.IsNotNull(persons);
        }

        [TestMethod]
        public void GetPersons_ReturnedMoreThan1Element()
        {
            //Arrange
            var dataProvider = new DataProvider();
            
            //Act
            var persons = dataProvider.GetPersons();

            //Assert
            Assert.IsTrue(persons.Length >= 1);
        }
    }
}
