using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using System.Text.RegularExpressions;

using Simhopp;
namespace SimhoppUnitTest
{
    [TestFixture]
    class TrickListTest
    {
        /// <summary>
        /// Test the TrickDictionarys IsEmpty function.
        /// </summary>
        [Test]
        public void ListIsEmpty()
        {
            TrickList tl = new TrickList();
            bool tlBool = tl.IsEmpty();
            Assert.AreEqual(true, tlBool);
            Assert.AreNotEqual(false, tlBool);
            Trick t = new Trick("flip", 2.1);
            tl.AddTrick(t);
            tlBool = tl.IsEmpty();
            Assert.AreEqual(false, tlBool);
            Assert.AreNotEqual(true, tlBool);
        }
        /// <summary>
        /// Test if the AddTrick method works.
        /// </summary>
        [Test]
        public void AddToList()
        {
            TrickList tl = new TrickList();
            Trick t1 = new Trick("flip", 2.1);
            tl.AddTrick(t1);
            tl.AddTrick(t1);
            bool tlBool = tl.IsEmpty();
            tlBool = tl.IsEmpty();
            Assert.AreEqual(false, tlBool);
        }

        /// <summary>
        /// Test if the ReadFromFile method saves the file data to the hashtable.
        /// </summary>
        [Test]
        public void ReadFromFile()
        {
            TrickList tl = new TrickList();
            bool tlBool = tl.IsEmpty();
            tlBool = tl.IsEmpty();
            Assert.AreEqual(true, tlBool);
            tl.ReadFromFile("TrickList.txt");
            tlBool = tl.IsEmpty();
            Assert.AreEqual(false, tlBool);
        }

        [Test]
        public void GetDifficultyByName()
        {
            TrickList tl = new TrickList();
            tl.ReadFromFile("TrickList.txt");
            double tlDifficulty = tl.GetDifficultyByName("Forward 2.5 Somersault");
            Assert.That(tlDifficulty, Is.EqualTo(2.2).Within(.0005));
            Assert.That(tlDifficulty, Is.Not.EqualTo(2.5).Within(.0005));
        }
    }
}
