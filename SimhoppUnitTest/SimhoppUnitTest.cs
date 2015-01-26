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
    public class SimhoppUnitTest
    {
        [Test]
        public void IsInteger()
        {
            Regex patternInteger = new Regex(@"^[-+]?[0-9]+$");

            string p1 = "123",
                   p2 = "+123",
                   p3 = "-123";
            string n1 = "12e",
                   n2 = "-a",
                   n3 = "+123a";

            //Positiv test
            NUnit.Framework.Assert.AreEqual(patternInteger.IsMatch(p1), true);
            NUnit.Framework.Assert.That(patternInteger.IsMatch(p2), Is.True);
            NUnit.Framework.Assert.IsTrue(patternInteger.IsMatch(p3));

            //Negativ test
            NUnit.Framework.Assert.AreEqual(patternInteger.IsMatch(n1), false);
            NUnit.Framework.Assert.That(patternInteger.IsMatch(n2), Is.False);
            NUnit.Framework.Assert.IsFalse(patternInteger.IsMatch(n3));
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
