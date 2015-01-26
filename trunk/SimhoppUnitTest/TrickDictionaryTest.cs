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
    class TrickDictionaryTest
    {
        /// <summary>
        /// Test the TrickDictionarys IsEmpty function.
        /// </summary>
        [Test]
        public void DictionaryIsEmpty()
        {
            TrickDictionary td = new TrickDictionary();
            bool tdBool = td.IsEmpty();
            Assert.AreEqual(true, tdBool);
            Assert.AreNotEqual(false, tdBool);
            Trick t = new Trick("flip", 2.1);
            td.AddTrick(20, t);
            tdBool = td.IsEmpty();
            Assert.AreEqual(false, tdBool);
            Assert.AreNotEqual(true, tdBool);
        }
    }
}
