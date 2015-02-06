using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Simhopp;

namespace SimhoppUnitTest
{
    [TestFixture]
    class SimhoppConsoleTest
    {
        private SimhoppConsole simhopp;

        [SetUp]
        public void Initilize()
        {
            simhopp = new SimhoppConsole();
        }
        /// <summary>
        /// Test if Read a diver or a person from file works
        /// </summary>
        [Test]
        public void ReadFromFile()
        {
            //Positivt test
            simhopp.ReadFromFile("diver.txt");
            var diver = simhopp.GetDiverByName("Rogelio	Parks");
            
            Assert.IsNotNull(diver);
            Assert.AreEqual(diver.Name, "Rogelio	Parks");

            //Negativt test
            var judge = simhopp.GetJudgeByName("Rogelio	Parks");
            Assert.IsNull(judge);
        }
        /// <summary>
        /// Test if Get a person by name works
        ///  </summary>
        [Test]
        public void GetPerson()
        {
            Assert.IsNull(simhopp.GetDiverByName("Rogelio	Parks"));

            simhopp.ReadFromFile("diver.txt");

            Assert.IsNotNull(simhopp.GetDiverByName("Rogelio	Parks"));
        }
    }
}
