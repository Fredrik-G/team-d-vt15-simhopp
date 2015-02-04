using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using System.Text.RegularExpressions;


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
            Simhopp.Diver p1 = new Simhopp.Diver("Jimmy Makkonen", "Sweden", "20050101-1337");
            Simhopp.Diver p2 = new Simhopp.Diver("Fredrik-Gummus", "USA", "123-20-5555");
            Simhopp.Judge p3 = new Simhopp.Judge("Judge Judy", "USA", "123-20-5555");

            NUnit.Framework.Assert.AreEqual(p1.Name, "Jimmy Makkonen");
            NUnit.Framework.Assert.AreNotEqual(p1.Name, "Fredrik-Gummus");
            NUnit.Framework.Assert.AreNotEqual(p1, p2);

            NUnit.Framework.Assert.That(p2.SSN, Is.EquivalentTo("123-20-5555"));
            NUnit.Framework.Assert.AreEqual(p3.Name, "Judge Judy");
        }
        /// <summary>
        /// Tests that two persons is added with the correct input data
        /// </summary>
        [Test]
        public void CorrectInputPerson()
        {
            Simhopp.Diver p1 = new Simhopp.Diver("Jimmy Makkonen", "Sweden", "20050101-1337");
            Simhopp.Diver p2 = new Simhopp.Diver("Fredrik-Gummus", "USA", "123-20-5555");
            Simhopp.Judge p3 = new Simhopp.Judge("Judge Judy", "USA", "123-20-5555");

            Simhopp.Diver n1 = new Simhopp.Diver("J..Makkonen", "Swe.den", "20050101-137");
            Simhopp.Diver n2 = new Simhopp.Diver("-Gummus", "US--A", "123205555");

            //Positiv test
            NUnit.Framework.Assert.AreEqual(Simhopp.Person.CheckCorrectName(p1.Name), true);
            NUnit.Framework.Assert.AreEqual(Simhopp.Person.CheckCorrectNationality(p1.Nationality), true);
            NUnit.Framework.Assert.AreEqual(Simhopp.Person.CheckCorrectSSN(p1.SSN, p1.Nationality), true);

            NUnit.Framework.Assert.AreEqual(Simhopp.Person.CheckCorrectName(p2.Name), true);
            NUnit.Framework.Assert.AreEqual(Simhopp.Person.CheckCorrectNationality(p2.Nationality), true);
            NUnit.Framework.Assert.AreEqual(Simhopp.Person.CheckCorrectSSN(p2.SSN, p2.Nationality), true);

            //Negativa test
            NUnit.Framework.Assert.AreEqual(Simhopp.Person.CheckCorrectName(n1.Name), false);
            NUnit.Framework.Assert.AreEqual(Simhopp.Person.CheckCorrectNationality(n1.Nationality), false);
            NUnit.Framework.Assert.AreEqual(Simhopp.Person.CheckCorrectSSN(n1.SSN, n1.Nationality), false);

            NUnit.Framework.Assert.AreEqual(Simhopp.Person.CheckCorrectName(n2.Name), false);
            NUnit.Framework.Assert.AreEqual(Simhopp.Person.CheckCorrectNationality(n2.Nationality), false);
            NUnit.Framework.Assert.AreEqual(Simhopp.Person.CheckCorrectSSN(n2.SSN, n2.Nationality), false);
        }
    }
}