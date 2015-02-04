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

    class ContestTest1
    {
        /// <summary>
        /// Testing the constructor to see that two different objekts are created.
        /// </summary>
        [Test]
        public void WorkingContestObject()
        {
            Contest p1 = new Contest("Orebro", "Simhoppstavlingen", "050414");
            Contest p2 = new Contest("Hallsberg", "Tavling enofdoom", "050406");

            Assert.AreEqual(p1.Place, "Orebro");
            Assert.AreNotEqual(p2.Place, "Orebro");
            Assert.AreNotEqual(p1, p2);
        }

        /// <summary>
        /// Testing to see that the constructor sets the correct values when the objects is created. 
        /// </summary>
        [Test]
        public void CorrectInputContestName() 
        {
            Contest p1 = new Contest("Orebro", "Simhoppstavlingen", "05/04/2015");
            Contest p2 = new Contest("Hallsberg", "Tavl in genofdo om", "1/02/2008");

            Contest n1 = new Contest("Ore,Bro", "Tävli ngen", "88-04-55");
            Contest n2 = new Contest("Örebro", "Tavl1ngen", "Jan 7 2014");

            //Positiv test
            Assert.AreEqual(Contest.CheckCorrectName(p1.Name), true);
            Assert.AreEqual(Contest.CheckCorrectPlace(p1.Place), true);
            Assert.AreEqual(Contest.CheckCorrectDate(p1.Date), true);

            Assert.AreEqual(Contest.CheckCorrectName(p2.Name), true);
            Assert.AreEqual(Contest.CheckCorrectPlace(p2.Place), true);
            Assert.AreEqual(Contest.CheckCorrectDate(p2.Date), true);

            //Negativ test
            Assert.AreEqual(Contest.CheckCorrectName(n1.Name), false);
            Assert.AreEqual(Contest.CheckCorrectPlace(n1.Place), false);
            Assert.AreEqual(Contest.CheckCorrectDate(n1.Date), false);

            Assert.AreEqual(Contest.CheckCorrectName(n2.Name), false);
            Assert.AreEqual(Contest.CheckCorrectPlace(n2.Place), false);
            Assert.AreEqual(Contest.CheckCorrectDate(n2.Date), false);
        }   

        /// <summary>
        /// Tests the AddPrticipants- and the GetNumberOfParticipants-function
        /// </summary>
        [Test]
        public void AddParticipantsToList()
        {
            Contest c1 = new Contest("Jerusalem", "JVM", "29/02/2015");
            Diver d1 = new Diver("Sven", "Swe", "1111111");
            c1.AddParticipant(d1);
            Assert.AreEqual(1, c1.GetNumberOfParticipants());
            Diver d2 = new Diver("Svente", "Fin", "1131111");
            c1.AddParticipant(d2);
            Assert.AreEqual(2, c1.GetNumberOfParticipants());
            
            //Negative test
            Assert.AreNotEqual(3, c1.GetNumberOfParticipants());
        }

        /// <summary>
        /// Test for the AddJudgeToList method. 
        /// </summary>
        [Test]
        public void AddJudgeToList()
        {
            Contest c1 = new Contest("Jerusalem", "JVM", "29/02/2015");
            Judge j1 = new Judge("heppa", "Bor", "222921");
            Judge j2 = new Judge("heppa", "Bor", "222922");
            Judge j3 = new Judge("heppa", "Bor", "222923");
            Judge j4 = new Judge("heppa", "Bor", "222924");
            Judge j5 = new Judge("heppa", "Bor", "222925");
            Judge j6 = new Judge("heppa", "Bor", "222926");
            Judge j7 = new Judge("heppa", "Bor", "222927");
            Judge j8 = new Judge("heppa", "Bor", "222928");
            Judge j9 = new Judge("", "Bor", "222928");
            Judge j10 = new Judge("heppa", "", "222928");
            Judge j11 = new Judge("heppa", "Bor", "");
            var exeptionTest1 = Assert.Throws<Exception>(() => c1.AddJudge(j9));
            Assert.That(exeptionTest1.Message, Is.EqualTo("Judge name is not set."));
            exeptionTest1 = Assert.Throws<Exception>(() => c1.AddJudge(j10));
            Assert.That(exeptionTest1.Message, Is.EqualTo("Judge nationality is not set."));
            exeptionTest1 = Assert.Throws<Exception>(() => c1.AddJudge(j11));
            Assert.That(exeptionTest1.Message, Is.EqualTo("Judge social security number is not set."));
            c1.AddJudge(j1);
            Assert.AreEqual(1, c1.GetNumberOfJudges());
            //Testing what expression is returned when a judge who is already in the list is beeing added again.
            exeptionTest1 = Assert.Throws<Exception>(() => c1.AddJudge(j1));
            Assert.That(exeptionTest1.Message, Is.EqualTo("Judge is already in list."));
            c1.AddJudge(j2);
            c1.AddJudge(j3);
            c1.AddJudge(j4);
            c1.AddJudge(j5);
            c1.AddJudge(j6);
            c1.AddJudge(j7);
            Assert.AreEqual(7, c1.GetNumberOfJudges());
            //Negative test.
            Assert.AreNotEqual(10, c1.GetNumberOfJudges());
            //Test to see that the right expression is thrown when You try to add a judge and the judgeList is full.
            exeptionTest1 = Assert.Throws<Exception>(() => c1.AddJudge(j8));
            Assert.That(exeptionTest1.Message, Is.EqualTo("All 7 judges are already set in the list."));
        }
    }
}
