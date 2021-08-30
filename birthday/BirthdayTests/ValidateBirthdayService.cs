using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Birthday
{
    [TestClass]
    public class ValidateBirthdayService
    {
        private BirthdayService service = new BirthdayService();

        [TestMethod]
        public void DemoTest()
        {
            // This is just for demoing or running the function not actually testing anything
            var results = this.service.IdentifyBirthdaysToday("Put the exaple text in here");
            Assert.IsNotNull(results);
            // what is the expected result
        }

        [TestMethod]
        public void TestNullInput()
        {
            var results = this.service.IdentifyBirthdaysToday(null);
            Assert.IsNotNull(results);
            Assert.IsFalse(results.Any());
        }

        [TestMethod]
        public void TestEmptyInput()
        {
            var results = this.service.IdentifyBirthdaysToday(string.Empty);
            Assert.IsNotNull(results);
            Assert.IsFalse(results.Any());
        }

        [TestMethod]
        public void TestGivenInput()
        {
            var results = this.service.IdentifyBirthdaysToday(TestInputs.ProvidedInput);
            Assert.IsNotNull(results);
            Assert.IsFalse(results.Any());
        }

        [TestMethod]
        public void TestCaseWithBirthdayToday()
        {
            var results = this.service.IdentifyBirthdaysToday(TestInputs.ProvidedInputWithBirthdayToday);
            Assert.IsNotNull(results);
            Assert.AreEqual("John Doe", results.First());
        }

        [TestMethod]
        public void TestMultipleNamesForPerson()
        {
            var results = this.service.IdentifyBirthdaysToday(TestInputs.ProvidedInputWithPersonWithThreeNames);
            Assert.IsNotNull(results);
            Assert.AreEqual("John Joe Doe", results.First());
        }

        [TestMethod]
        public void TestDifferentDateFormats()
        {
            var results = this.service.IdentifyBirthdaysToday(TestInputs.ProvidedInputWithOneDateInDifferentFormat);
            Assert.IsNotNull(results);
            Assert.AreEqual("John Joe Doe", results.First());
        }
    }
}
