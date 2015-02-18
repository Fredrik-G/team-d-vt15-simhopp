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
    [TestFixture]
    class TrickTest
    {
        /// <summary>
        /// Testing the default constructor.
        /// </summary>
        [Test]
        public void CreateObjectWithoutParameters()
        {
            Trick t1 = new Trick();
            string t1String = t1.Name;
            double t1Double = t1.Difficulty;
            Assert.That(t1String, Is.StringMatching(""));
            Assert.That(t1Double, Is.EqualTo(0).Within(.0005));
            Assert.That(t1String, Is.Not.StringMatching("flip"));
            Assert.That(t1Double, Is.Not.EqualTo(1.4));
        }
        /// <summary>
        /// Testing the constructors that takes two arguments (name and difficulty).
        /// </summary>
        [Test]
        public void CreateObjectWithParameters()
        {
            Trick t1 = new Trick("flip", 2.1);
            string t1String = t1.Name;
            double t1Double = t1.Difficulty;
            Assert.That(t1String, Is.StringMatching("flip"));
            Assert.That(t1Double, Is.EqualTo(2.1).Within(.0005));
            Assert.That(t1String, Is.Not.StringMatching("gnurra"));
            Assert.That(t1Double, Is.Not.EqualTo(1.4));
        }

        /// <summary>
        /// Testing the set property.
        /// </summary>
        [Test]
        public void SetTrickNameAndDifficulty()
        {
            Trick t1 = new Trick();
            string t1String = t1.Name;
            double t1Double = t1.Difficulty;
            Assert.That(t1String, Is.StringMatching(""));
            Assert.That(t1Double, Is.EqualTo(0).Within(.0005));
            t1.Name = "flip";
            t1.Difficulty = 2.1;
            t1String = t1.Name;
            t1Double = t1.Difficulty;
            Assert.That(t1String, Is.StringMatching("flip"));
            Assert.That(t1Double, Is.EqualTo(2.1).Within(.0005));
            Assert.That(t1String, Is.Not.StringMatching("gnurra"));
            Assert.That(t1Double, Is.Not.EqualTo(1.4));
        }
    }
}
