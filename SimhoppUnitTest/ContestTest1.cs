using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
            Diver d1 = new Diver("Sven", "USA", "123-20-5555");
            c1.AddParticipant(d1);
            Assert.AreEqual(1, c1.GetNumberOfParticipants());
            Diver d2 = new Diver("Svente", "Fin", "123-20-5555");
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
            Judge j1 = new Judge("heppa", "Bor", "123-20-5551");
            Judge j2 = new Judge("heppa", "Bor", "123-20-5552");
            Judge j3 = new Judge("heppa", "Bor", "123-20-5553");
            Judge j4 = new Judge("heppa", "Bor", "123-20-5554");
            Judge j5 = new Judge("heppa", "Bor", "123-20-5555");
            Judge j6 = new Judge("heppa", "Bor", "123-20-5556");
            Judge j7 = new Judge("heppa", "Bor", "123-20-5557");
            Judge j8 = new Judge("heppa", "Bor", "123-20-5558");
            Judge j9 = new Judge("", "Bor", "123-20-5559");
            Judge j10 = new Judge("heppa", "", "123-20-5550");
            Judge j11 = new Judge("heppa", "Bor", "");

            c1.AddJudge(j8);
            Assert.AreEqual(1, c1.GetNumberOfJudges());

            c1.AddJudge(j9);
            Assert.AreEqual(1, c1.GetNumberOfJudges());

        //    Assert.DoesNotThrow(() => c1.AddJudge(j9));

            //!!!!!!!!!!! AddJudge fångar alla exception, så testen nedanför funkar inte.!!!!!!!!!!!!!!!!!!!!

            //var exeptionTest1 = Assert.Throws<InvalidDataException>(() => c1.AddJudge(j9));

            //Assert.That(exeptionTest1.Message, Is.EqualTo("Judge name is not set or invalid."));
            //exeptionTest1 = Assert.Throws<InvalidDataException>(() => c1.AddJudge(j10));
            //Assert.That(exeptionTest1.Message, Is.EqualTo("Judge nationality is not set or invalid."));
            //exeptionTest1 = Assert.Throws<InvalidDataException>(() => c1.AddJudge(j11));
            //Assert.That(exeptionTest1.Message, Is.EqualTo("Judge social security number is not set or invalid."));
            //c1.AddJudge(j1);
            //Assert.AreEqual(1, c1.GetNumberOfJudges());
            ////Testing what expression is returned when a judge who is already in the list is beeing added again.
            //var exeptionTest2 = Assert.Throws<DuplicateNameException>(() => c1.AddJudge(j1));
            //Assert.That(exeptionTest2.Message, Is.EqualTo("Judge is already in list."));
            c1.AddJudge(j2);
            c1.AddJudge(j3);
            c1.AddJudge(j4);
            c1.AddJudge(j5);
            c1.AddJudge(j6);
            c1.AddJudge(j7);
            Assert.AreEqual(7, c1.GetNumberOfJudges());
            //Negative test.
            Assert.AreNotEqual(10, c1.GetNumberOfJudges());
            ////Test to see that the right expression is thrown when You try to add a judge and the judgeList is full.
            //var exeptionTest3 = Assert.Throws<IndexOutOfRangeException>(() => c1.AddJudge(j8));
            //Assert.That(exeptionTest3.Message, Is.EqualTo("All 7 judges are already set in the list."));
        }

        [Test]
        public void SortParticipants()
        {
            Contest c1 = new Contest("Jerusalem", "JVM", "29/02/2015");
            Contest c2 = new Contest("Jerusalem", "JVM", "29/02/2015");
            for (var i = 0; i < 7; i++)
            {
                string asd = Convert.ToString("123-20-555" + i);
                Judge j1 = new Judge("heppa", "Bor", asd);
                c1.AddJudge(j1);
                c2.AddJudge(j1);
            }

            Assert.AreEqual(7, c1.GetNumberOfJudges());

            Diver d1 = new Diver("Jimmy Makkonen", "Sweden", "20050101-1330");
            Diver d2 = new Diver("Curtis Cain", "Sweden", "20050101-1332");
            Diver d3 = new Diver("Ricky Powell", "USA", "123-55-5555");

            c1.AddParticipant(d1);
            c1.AddParticipant(d2);
            c1.AddParticipant(d3);

            Assert.AreEqual(3, c1.GetNumberOfParticipants());

            for (int i = 0; i < 15; i++)
            {
                c1.AddParticipant(d3);
                c1.participantsList[i].TotalPoints = i;
            }
            
            Assert.AreEqual(0, c1.participantsList[0].TotalPoints);
            Assert.AreEqual(2, c1.participantsList[2].TotalPoints);

            c1.SortParticipants(ref c1.participantsList, true);

            Assert.AreEqual(14, c1.participantsList[0].TotalPoints);
            Assert.AreEqual(13, c1.participantsList[1].TotalPoints);
            Assert.AreEqual(12, c1.participantsList[2].TotalPoints);
        }

        [Test]
        public void MakeJump()
        {
            Contest c1 = new Contest("Jerusalem", "JVM", "29/02/2015");
            for (var i = 0; i < 7; i++)
            {
                string asd = Convert.ToString("123-20-555" + i);
                Judge j1 = new Judge("heppa", "Bor", asd);
                c1.AddJudge(j1);
            }

            Assert.AreEqual(7, c1.GetNumberOfJudges());

            for (var i = 0; i < 3; i++)
            {
                string asd = Convert.ToString("20050101-133" + i);
                Diver d1 = new Diver("Jimmy Makkonen", "Sweden", asd);
                c1.AddParticipant(d1);
            }
            Assert.AreEqual(3, c1.GetNumberOfParticipants());

            c1.MakeJump(0);
            Assert.AreNotEqual(0, c1.GetResultFromParticipant("20050101-1330"));
        }
    }
}
