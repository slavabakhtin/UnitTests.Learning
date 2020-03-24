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
            var dataProvider = new DataProvider();
            var persons = dataProvider.GetPersons();
            Assert.AreEqual(true, persons.All(x => x.Age >= 18 && x.Age <= 25));
        }

        [TestMethod]
        public void GetPersons_ExistsPersonNotFrom18To25Years_ReturnedFalse()
        {
            var dataProvider = new DataProvider();
            var persons = dataProvider.GetPersons();
            Assert.AreEqual(false, persons.Any(x => x.Age < 18 || x.Age > 25));
        }

        [TestMethod]
        public void GetPersons_ReturnedNotNullList()
        {
            var dataProvider = new DataProvider();
            var persons = dataProvider.GetPersons();
            Assert.IsNotNull(persons);
        }

        [TestMethod]
        public void GetPersons_ReturnedMore1Element()
        {
            var dataProvider = new DataProvider();
            var persons = dataProvider.GetPersons();
            Assert.IsTrue(persons.Length >= 1);
        }

        [TestMethod]
        public void GetPersons_ReturnedNotEmptyList()
        {
            var dataProvider = new DataProvider();
            var persons = dataProvider.GetPersons();
            Assert.IsTrue(persons.Length > 0);
        }
    }
}
