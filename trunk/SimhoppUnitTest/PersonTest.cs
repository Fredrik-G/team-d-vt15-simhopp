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
        public void CorrectName()
        {
            Simhopp.Diver p1 = new Simhopp.Diver("Jimmy Makkonen", "Sweden", "20050101-1337");
            Simhopp.Diver p2 = new Simhopp.Diver("Fredrik-Gummus", "USA", "123-20-5555");

            //Positiv test
            NUnit.Framework.Assert.AreEqual(p1.CheckCorrectName(p1.Name), true);
            NUnit.Framework.Assert.AreEqual(p1.CheckCorrectNationality(p1.Nationality), true);
            NUnit.Framework.Assert.AreEqual(p1.CheckCorrectSSN(p1.SSN), true);

            NUnit.Framework.Assert.AreEqual(p2.CheckCorrectName(p2.Name), true);
            NUnit.Framework.Assert.AreEqual(p2.CheckCorrectNationality(p2.Nationality), true);
            NUnit.Framework.Assert.AreEqual(p2.CheckCorrectSSN(p2.SSN), true);
        }
        [Test]
        public void IsUnsignedInteger()
        {//positiva tal
            Regex patternUnsignedInteger = new Regex(@"^[+]?[0-9]+$");

            string p1 = "123",
                   p2 = "+123";
            string n1 = "1a3",
                   n2 = "-e",
                   n3 = "-123";

            //Positiv test
            NUnit.Framework.Assert.AreEqual(patternUnsignedInteger.IsMatch(p1), true);
            NUnit.Framework.Assert.That(patternUnsignedInteger.IsMatch(p2), Is.True);

            //Negativ test
            NUnit.Framework.Assert.AreEqual(patternUnsignedInteger.IsMatch(n1), false);
            NUnit.Framework.Assert.That(patternUnsignedInteger.IsMatch(n2), Is.False);
            NUnit.Framework.Assert.IsFalse(patternUnsignedInteger.IsMatch(n3));
        }
        [Test]
        public void IsSignedInteger()
        {//negativa tal
            Regex patternSignedInteger = new Regex(@"^[+-]?[0-9]+$");

            string p1 = "123",
                   p2 = "+123",
                   p3 = "-123";
            string n1 = "1a3",
                   n2 = "-e",
                   n3 = "+123a";

            //Positiv test
            NUnit.Framework.Assert.AreEqual(patternSignedInteger.IsMatch(p1), true);
            NUnit.Framework.Assert.That(patternSignedInteger.IsMatch(p2), Is.True);
            NUnit.Framework.Assert.IsTrue(patternSignedInteger.IsMatch(p3));

            //Negativ test
            NUnit.Framework.Assert.AreEqual(patternSignedInteger.IsMatch(n1), false);
            NUnit.Framework.Assert.That(patternSignedInteger.IsMatch(n2), Is.False);
            NUnit.Framework.Assert.IsFalse(patternSignedInteger.IsMatch(n3));
        }
        [Test]
        public void IsFloat()
        {
            Regex patternFloat = new Regex(@"^[-+]?[0-9]+[.]?[0-9]*([eE][-+]?[0-9]+)?$");

            string p1 = "12.3",
                   p2 = "+12.e3",
                   p3 = "-12.999999";
            string n1 = "1.e",
                   n2 = "-0.1.2",
                   n3 = ".+123";

            //Positiv test
            NUnit.Framework.Assert.AreEqual(patternFloat.IsMatch(p1), true);
            NUnit.Framework.Assert.That(patternFloat.IsMatch(p2), Is.True);
            NUnit.Framework.Assert.IsTrue(patternFloat.IsMatch(p3));

            //Negativ test
            NUnit.Framework.Assert.AreEqual(patternFloat.IsMatch(n1), false);
            NUnit.Framework.Assert.That(patternFloat.IsMatch(n2), Is.False);
            NUnit.Framework.Assert.IsFalse(patternFloat.IsMatch(n3));
        }
        [Test]
        public void IsValidEmail()
        {
            Regex patternEmail = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-
]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");

            string p1 = "asmith@mactec.com",
                   p2 = "foo12@foo.edu",
                   p3 = "bob.smith@foo.tv";
            string n1 = "joe",
                   n2 = "@foo.com",
                   n3 = "a@a",
                   n4 = "",
                   n5 = " @asd.com";

            //Positiv test
            NUnit.Framework.Assert.AreEqual(patternEmail.IsMatch(p1), true);
            NUnit.Framework.Assert.That(patternEmail.IsMatch(p2), Is.True);
            NUnit.Framework.Assert.IsTrue(patternEmail.IsMatch(p3));

            //Negativ test
            NUnit.Framework.Assert.AreEqual(patternEmail.IsMatch(n1), false);
            NUnit.Framework.Assert.That(patternEmail.IsMatch(n2), Is.False);
            NUnit.Framework.Assert.IsFalse(patternEmail.IsMatch(n3));
            NUnit.Framework.Assert.IsFalse(patternEmail.IsMatch(n4));
            NUnit.Framework.Assert.IsFalse(patternEmail.IsMatch(n5));
        }
    }
}
