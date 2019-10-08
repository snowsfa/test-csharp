using NUnit.Framework;
using System;
using TestCSharp.Question3;

namespace UnitTests
{
    class UnitTestsQuestion3
    {
        const string invalidNameExceptionMsg = "Invalid name.";
        const string invalidBirthDateExceptionMsg = "Invalid birth date.";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddPersonsAndDelete_Pass()
        {
            string name = "Kelly M. Braun";
            DateTime birthdate = new DateTime(1954, 2, 14);
            Person p = PersonManager.AddPerson(name, birthdate);
            Assert.AreEqual(1, p.Id);
            Assert.AreEqual(name, p.Name);
            Assert.AreEqual(birthdate, p.BirthDate);
            Assert.AreEqual(65, p.Age);
            Assert.AreEqual(1, PersonManager.GetPersonCount());

            name = "Alice N. Bush";
            birthdate = new DateTime(1955, 12, 31);
            p = PersonManager.AddPerson(name, birthdate);
            Assert.AreEqual(2, p.Id);
            Assert.AreEqual(name, p.Name);
            Assert.AreEqual(birthdate, p.BirthDate);
            Assert.AreEqual(63, p.Age);
            Assert.AreEqual(2, PersonManager.GetPersonCount());

            name = "Ronnie A. Danos";
            birthdate = new DateTime(1982, 1, 1);
            p = PersonManager.AddPerson(name, birthdate);
            Assert.AreEqual(3, p.Id);
            Assert.AreEqual(name, p.Name);
            Assert.AreEqual(birthdate, p.BirthDate);
            Assert.AreEqual(37, p.Age);
            Assert.AreEqual(3, PersonManager.GetPersonCount());

            var deleteResult = PersonManager.DeletePerson(1);
            Assert.AreEqual(true, deleteResult);
            Assert.AreEqual(2, PersonManager.GetPersonCount());

            deleteResult = PersonManager.DeletePerson(4);
            Assert.AreEqual(false, deleteResult);
            Assert.AreEqual(2, PersonManager.GetPersonCount());

            name = "Shannon K. Dyer";
            birthdate = new DateTime(1985, 2, 28);
            p = PersonManager.AddPerson(name, birthdate);
            Assert.AreEqual(4, p.Id);
            Assert.AreEqual(name, p.Name);
            Assert.AreEqual(birthdate, p.BirthDate);
            Assert.AreEqual(34, p.Age);
            Assert.AreEqual(3, PersonManager.GetPersonCount());

            deleteResult = PersonManager.DeletePerson(4);
            Assert.AreEqual(true, deleteResult);
            Assert.AreEqual(2, PersonManager.GetPersonCount());

            deleteResult = PersonManager.DeletePerson(3);
            Assert.AreEqual(true, deleteResult);
            Assert.AreEqual(1, PersonManager.GetPersonCount());

            deleteResult = PersonManager.DeletePerson(2);
            Assert.AreEqual(true, deleteResult);
            Assert.AreEqual(0, PersonManager.GetPersonCount());

            deleteResult = PersonManager.DeletePerson(2);
            Assert.AreEqual(false, deleteResult);
            Assert.AreEqual(0, PersonManager.GetPersonCount());

            Assert.Pass();
        }

        [Test]
        public void InvalidArgument_PersonNameNull_ThrowsException()
        {
            string name = null;
            DateTime birthdate = new DateTime(1996, 12, 28);
            var ex = Assert.Throws<ArgumentException>(() => PersonManager.AddPerson(name, birthdate));
            Assert.That(ex.Message == invalidNameExceptionMsg);
        }

        [Test]
        public void InvalidArgument_PersonNameEmpty_ThrowsException()
        {
            string name = "";
            DateTime birthdate = new DateTime(1996, 12, 28);
            var ex = Assert.Throws<ArgumentException>(() => PersonManager.AddPerson(name, birthdate));
            Assert.That(ex.Message == invalidNameExceptionMsg);
        }

        [Test]
        public void InvalidArgument_PersonNameBlank_ThrowsException()
        {
            string name = " ";
            DateTime birthdate = new DateTime(1996, 12, 28);
            var ex = Assert.Throws<ArgumentException>(() => PersonManager.AddPerson(name, birthdate));
            Assert.That(ex.Message == invalidNameExceptionMsg);
        }

        [Test]
        public void InvalidArgument_BirthDateAhead_ThrowsException()
        {
            string name = "Kelly M. Braun";
            DateTime birthdate = DateTime.Now.AddDays(1);
            var ex = Assert.Throws<ArgumentException>(() => PersonManager.AddPerson(name, birthdate));
            Assert.That(ex.Message == invalidBirthDateExceptionMsg);
        }

        [Test]
        public void AgeCalculation_BorderDates_Pass()
        {
            DateTime basisDate = new DateTime(1982, DateTime.Now.Month, DateTime.Now.Day);

            string name = "Jennifer R. Holcomb";
            Person p = PersonManager.AddPerson(name, basisDate.AddDays(-1));
            Assert.AreEqual(37, p.Age);

            p = PersonManager.AddPerson(name, basisDate);
            Assert.AreEqual(37, p.Age);

            p = PersonManager.AddPerson(name, basisDate.AddDays(1));
            Assert.AreEqual(36, p.Age);

            Assert.Pass();
        }

    }
}

