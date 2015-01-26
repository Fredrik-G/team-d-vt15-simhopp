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

    class ContestTest1
    {

        [Test]
        public void WorkingContestObject()
        {//Testar konstruktorn och att det skapas två olika objekt.
            Simhopp.Contest p1 = new Simhopp.Contest("Orebro", "Simhoppstavlingen", "050414");
            Simhopp.Contest p2 = new Simhopp.Contest("Hallsberg", "Tavling enofdoom", "050406");

            NUnit.Framework.Assert.AreEqual(p1.place, "Orebro");
            NUnit.Framework.Assert.AreNotEqual(p2.place, "Orebro");
            NUnit.Framework.Assert.AreNotEqual(p1, p2);

        }

        [Test]
        public void CorrectInputContestName() 
        {
            Simhopp.Contest p1 = new Simhopp.Contest("Orebro", "Simhoppstavlingen", "05/04/2015");
            Simhopp.Contest p2 = new Simhopp.Contest("Hallsberg", "Tavl in genofdo om", "1/02/2008");

            Simhopp.Contest n1 = new Simhopp.Contest("Ore,Bro", "Tävli ngen", "88-04-55");
            Simhopp.Contest n2 = new Simhopp.Contest("Örebro", "Tavl1ngen", "Jan 7 2014");

            //Positiv test
            NUnit.Framework.Assert.AreEqual(p1.CheckCorrectName(p1.Name), true);
            NUnit.Framework.Assert.AreEqual(p1.CheckCorrectPlace(p1.Place), true);
            NUnit.Framework.Assert.AreEqual(p1.CheckCorrectDate(p1.Date), true);

            NUnit.Framework.Assert.AreEqual(p2.CheckCorrectName(p2.Name), true);
            NUnit.Framework.Assert.AreEqual(p2.CheckCorrectPlace(p2.Place), true);
            NUnit.Framework.Assert.AreEqual(p2.CheckCorrectDate(p2.Date), true);

            //Negativa test
            NUnit.Framework.Assert.AreEqual(n1.CheckCorrectName(n1.Name), false);
            NUnit.Framework.Assert.AreEqual(n1.CheckCorrectPlace(n1.Place), false);
            NUnit.Framework.Assert.AreEqual(n1.CheckCorrectDate(n1.Date), false);

            NUnit.Framework.Assert.AreEqual(n2.CheckCorrectName(n2.Name), false);
            NUnit.Framework.Assert.AreEqual(n2.CheckCorrectPlace(n2.Place), false);
            NUnit.Framework.Assert.AreEqual(n2.CheckCorrectDate(n2.Date), false);
        }
        
    }
    
}
