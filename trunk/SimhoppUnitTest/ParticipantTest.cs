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
    class ParticipantTest
    {
        [Test]
        public void ConstructorWithParameters()
        {
            Diver d = new Diver();
            Participant p = new Participant(d);
            double tPoint = p.TotalPoints;
            Assert.AreEqual(0.0, tPoint);
            Assert.AreNotEqual(0.1, tPoint);
        }
        [Test]
        public void TotalPointsGetSet()
        {
            Diver d = new Diver();
            Participant p = new Participant(d);
            p.TotalPoints = 5.5;
            double tPoint = p.TotalPoints;
            Assert.AreEqual(5.5, tPoint);
            Assert.AreNotEqual(5.6, tPoint);
        }
    }
}
