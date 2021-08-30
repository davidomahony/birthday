using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Birthday
{
    [TestClass]
    public class ValidateBirthdayService
    {
        private BirthdayService service = new BirthdayService();

        [TestMethod]
        public void TestNullInput()
        {
            var results = this.service.IdentifySameBirthdays(null);
            Assert.IsNotNull(results);
            Assert.IsFalse(results.Any());
        }

        [TestMethod]
        public void TestEmptyInput()
        {
            var results = this.service.IdentifySameBirthdays(string.Empty);
            Assert.IsNotNull(results);
            Assert.IsFalse(results.Any());
        }

        [TestMethod]
        public void TestGivenInput()
        {
            var results = this.service.IdentifySameBirthdays(TestInputs.ProvidedInput);
            Assert.IsNotNull(results);
            Assert.IsFalse(results.Any());
        }

        [TestMethod]
        public void TestCaseWithBirthdayToday()
        {
            var results = this.service.IdentifySameBirthdays(TestInputs.ProvidedInputWithBirthdayToday);
            Assert.IsNotNull(results);
            Assert.AreEqual("John Doe", results.First());
        }

        [TestMethod]
        public void TestMultipleNamesForPerson()
        {
            var results = this.service.IdentifySameBirthdays(TestInputs.ProvidedInputWithPersonWithThreeNames);
            Assert.IsNotNull(results);
            Assert.AreEqual("John Joe Doe", results.First());
        }

        [TestMethod]
        public void TestDifferentDateFormats()
        {
            var results = this.service.IdentifySameBirthdays(TestInputs.ProvidedInputWithOneDateInDifferentFormat);
            Assert.IsNotNull(results);
            Assert.AreEqual("John Joe Doe", results.First());
        }
    }
}
