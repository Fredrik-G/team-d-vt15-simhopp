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
        
        [Test]
        public void CreateObjectWithoutParameters()
        {
            TrickDictionary td = new TrickDictionary();
            Assert.AreEqual(true, td.isEmpty());
        }

    }
}
