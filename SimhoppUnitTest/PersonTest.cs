using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using System.Text.RegularExpressions;

using Simhopp.Model;
namespace SimhoppUnitTest
{
    /// <summary>
    /// A class that validate tests for the class
    /// </summary>
    [TestFixture]
    public class PersonTest
    {
        /// <summary>
        /// Tests the constructor and that it does create two different objects
        /// </summary>
        [Test]
        public void WorkingPersonObject()
        {
            Diver p1 = new Diver("Jimmy Makkonen", "Sweden", "20050101-1337");
            Diver p2 = new Diver("Fredrik-Gummus", "USA", "123-20-5555");
            Judge p3 = new Judge("Judge Judy", "USA", "123-20-5555");

            Assert.AreEqual(p1.Name, "Jimmy Makkonen");
            Assert.AreNotEqual(p1.Name, "Fredrik-Gummus");
            Assert.AreNotEqual(p1, p2);

            Assert.That(p2.SSN, Is.EquivalentTo("123-20-5555"));
            Assert.AreEqual(p3.Name, "Judge Judy");
        }
        /// <summary>
        /// Tests that two persons is added with the correct input data
        /// </summary>
        [Test]
        public void CorrectInputPerson()
        {
            Diver p1 = new Diver("Jimmy Makkonen", "Sweden", "20050101-1337");
            Diver p2 = new Diver("Fredrik-Gummus", "USA", "123-20-5555");
            Judge p3 = new Judge("Judge Judy", "USA", "123-20-5555");

            Diver n1 = new Diver("J..Makkonen", "Swe.den", "20050101-137");
            Diver n2 = new Diver("-Gummus", "US--A", "123205555");

            //Positiv test
            Assert.AreEqual(Person.CheckCorrectName(p1.Name), true);
            Assert.AreEqual(Person.CheckCorrectNationality(p1.Nationality), true);
            Assert.AreEqual(Person.CheckCorrectSSN(p1.SSN, p1.Nationality), true);

            Assert.AreEqual(Person.CheckCorrectName(p2.Name), true);
            Assert.AreEqual(Person.CheckCorrectNationality(p2.Nationality), true);
            Assert.AreEqual(Person.CheckCorrectSSN(p2.SSN, p2.Nationality), true);

            //Negativa test
            Assert.AreEqual(Person.CheckCorrectName(n1.Name), false);       
            Assert.AreEqual(Person.CheckCorrectNationality(n1.Nationality), false);
            Assert.AreEqual(Person.CheckCorrectSSN(n1.SSN, n1.Nationality), false);

            Assert.AreEqual(Person.CheckCorrectName(n2.Name), false);
            Assert.AreEqual(Person.CheckCorrectNationality(n2.Nationality), false);
            Assert.AreEqual(Person.CheckCorrectSSN(n2.SSN, n2.Nationality), false);
        }
    }
}