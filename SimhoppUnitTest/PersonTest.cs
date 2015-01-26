using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using System.Text.RegularExpressions;


namespace SimhoppUnitTest
{
    [TestFixture]
    public class PersonTest
    {
        [Test]
        public void WorkingPersonObject()
        {
            Simhopp.Diver p1 = new Simhopp.Diver("Jimmy Makkonen", "Sweden", "20050101-1337");
            Simhopp.Diver p2 = new Simhopp.Diver("Fredrik-Gummus", "USA", "123-20-5555");

            NUnit.Framework.Assert.AreNotEqual(p1, p2);
        }
        [Test]
        public void CorrectInputPerson()
        {
            Simhopp.Diver p1 = new Simhopp.Diver("Jimmy Makkonen", "Sweden", "20050101-1337");
            Simhopp.Diver p2 = new Simhopp.Diver("Fredrik-Gummus", "USA", "123-20-5555");

            Simhopp.Diver n1 = new Simhopp.Diver("J..Makkonen", "Swe.den", "20050101-137");
            Simhopp.Diver n2 = new Simhopp.Diver("-Gummus", "US--A", "123205555");

            //Positiv test
            NUnit.Framework.Assert.AreEqual(p1.CheckCorrectName(p1.Name), true);
            NUnit.Framework.Assert.AreEqual(p1.CheckCorrectNationality(p1.Nationality), true);
            NUnit.Framework.Assert.AreEqual(p1.CheckCorrectSSN(p1.SSN), true);

            NUnit.Framework.Assert.AreEqual(p2.CheckCorrectName(p2.Name), true);
            NUnit.Framework.Assert.AreEqual(p2.CheckCorrectNationality(p2.Nationality), true);
            NUnit.Framework.Assert.AreEqual(p2.CheckCorrectSSN(p2.SSN), true);

            //Negativa test
            NUnit.Framework.Assert.AreEqual(n1.CheckCorrectName(n1.Name), false);
            NUnit.Framework.Assert.AreEqual(n1.CheckCorrectNationality(n1.Nationality), false);
            NUnit.Framework.Assert.AreEqual(n1.CheckCorrectSSN(n1.SSN), false);

            NUnit.Framework.Assert.AreEqual(n2.CheckCorrectName(n2.Name), false);
            NUnit.Framework.Assert.AreEqual(n2.CheckCorrectNationality(n2.Nationality), false);
            NUnit.Framework.Assert.AreEqual(n2.CheckCorrectSSN(n2.SSN), false);
        }
    }
}