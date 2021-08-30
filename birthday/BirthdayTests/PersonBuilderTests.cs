using Birthday;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BirthdayTests
{
    [TestClass]
    public class PersonBuilderTests
    {
        private PersonBuilder builder = new PersonBuilder();

        [TestMethod]
        public void TestNullInput()
        {
            this.builder.SetPersonInputs(null);
            Assert.IsFalse(this.builder.TryBuild(out Person outputtedPerson));
        }

        [TestMethod]
        public void TestEmptyInput()
        {
            this.builder.SetPersonInputs(new string[0]);
            Assert.IsFalse(this.builder.TryBuild(out Person outputtedPerson));
        }

        [TestMethod]
        public void TestNoNameInput()
        {
            this.builder.SetPersonInputs(new string[] { DateTime.Today.ToString() });
            Assert.IsFalse(this.builder.TryBuild(out Person outputtedPerson));
        }


        [TestMethod]
        public void TestNoDateInput()
        {
            this.builder.SetPersonInputs(new string[] { "john", "joe" });
            Assert.IsFalse(this.builder.TryBuild(out Person outputtedPerson));
        }

        [TestMethod]
        public void TestMultipleDatesInput()
        {
            this.builder.SetPersonInputs(new string[] { DateTime.Today.ToString(), DateTime.Today.ToString() });
            Assert.IsFalse(this.builder.TryBuild(out Person outputtedPerson));
        }

        [TestMethod]
        public void TestDateTimeOneInput()
        {
            this.builder.SetPersonInputs(new string[] { "name", "This", DateTime.Today.ToString("MM/dd/yyyy") });
            Assert.IsTrue(this.builder.TryBuild(out Person outputtedPerson));
            Assert.AreEqual(DateTime.Today.ToString("MM/dd/yyyy"), outputtedPerson.Birthday.ToString("MM/dd/yyyy"));
            CollectionAssert.AreEqual(new List<string> { "This", "name" }, outputtedPerson.Names);
        }

        [TestMethod]
        public void TestDateTimeTwoInput()
        {
            this.builder.SetPersonInputs(new string[] { "name", "This", DateTime.Today.Date.ToString() });
            Assert.IsTrue(this.builder.TryBuild(out Person outputtedPerson));
            Assert.AreEqual(DateTime.Today.ToString("dd/MM/yyyy"), outputtedPerson.Birthday.ToString("dd/MM/yyyy"));
            CollectionAssert.AreEqual(new List<string> { "This", "name" }, outputtedPerson.Names);
        }

        [TestMethod]
        public void TestLongNameInput()
        {
            this.builder.SetPersonInputs(new string[] { "long", "is", "name", "This", DateTime.Today.ToString() });
            Assert.IsTrue(this.builder.TryBuild(out Person outputtedPerson));
            Assert.AreEqual(DateTime.Today.Date.ToString("dd/MM/yyyy"), outputtedPerson.Birthday.ToString("dd/MM/yyyy"));
            CollectionAssert.AreEqual(new List<string> { "This", "name", "is", "long" }, outputtedPerson.Names);
        }
    }
}
