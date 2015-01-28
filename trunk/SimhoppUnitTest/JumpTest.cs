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
    public class JumpTest
    {
        [Test]
        public void CorrectFileReading()
        {
            Simhopp.Jump p1 = new Jump();

            NUnit.Framework.Assert.DoesNotThrow(() => p1.Initilize());
        }
    }
}