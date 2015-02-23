using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using System.Text.RegularExpressions;

using Simhopp.Model;
namespace SimhoppUnitTest
{
    [TestFixture]
    public class DatabaseControllerTest
    {
        private SQLiteConnection dbConnectionTest;
        private DatabaseController dbc = new DatabaseController("simhoppTestDB.db");

        
        /// <summary>
        /// Testing the AddDiverToDatabase and ClearDatabase funktion.
        /// </summary>
        [Test]
        public void AddDiverToDiverTableTest()
        {
            Diver d = new Diver("Jimmy McNultey", "Finish", "111-22-3333");
            //DatabaseController dbc = new DatabaseController("simhoppTestDB.db");
            dbc.CloseConnectionToDatabase();
            dbc.ConnectToDatabase();
            dbc.ClearDatabase("Diver");
            bool emptyOrNot = dbc.TableIsEmpty("Diver");
            Assert.AreEqual(emptyOrNot, true);

            dbc.AddDiverToDatabase(d);
            emptyOrNot = dbc.TableIsEmpty("Diver");
            Assert.AreEqual(emptyOrNot, false);

            dbc.CloseConnectionToDatabase();
        }


        /// <summary>
        /// Testing the AddJudgeToDatabase and ClearDatabase funktion.
        /// </summary>
        [Test]
        public void AddJudgeToJudgeTableTest()
        {
            Judge j = new Judge("Gnurra G", "Swedish", "111111-1111");
            dbc.ConnectToDatabase();
            dbc.ClearDatabase("Judge");
            bool emptyOrNot = dbc.TableIsEmpty("Judge");
            Assert.AreEqual(emptyOrNot, true);

            dbc.AddJudgeToDatabase(j);
            emptyOrNot = dbc.TableIsEmpty("Judge");
            Assert.AreEqual(emptyOrNot, false);

            dbc.CloseConnectionToDatabase();
        }

        /// <summary>
        /// Testing the AddContestToDatabase and ClearDatabase funktion.
        /// </summary>
        [Test]

        public void AddContestToContestTableTest()
        {
            Contest c = new Contest("VM", "G-vik", "12/02/2015", "13/02/2015");
            dbc.ConnectToDatabase();
            dbc.ClearDatabase("Contest");
            bool emptyOrNot = dbc.TableIsEmpty("Contest");
            Assert.AreEqual(emptyOrNot, true);

            dbc.AddContestToDatabase(c);
            emptyOrNot = dbc.TableIsEmpty("Contest");
            Assert.AreEqual(emptyOrNot, false);

            dbc.CloseConnectionToDatabase();
        }

        /// <summary>
        /// Testing the RemoveDiverFromDatabase function. 
        /// </summary>
        [Test]
        public void RemoveDiverFromDiverTableTest()
        {
            Diver d = new Diver("Jimmy McNultey", "Finish", "111-22-3333");
            dbc.ConnectToDatabase();
            dbc.ClearDatabase("Diver");
            bool emptyOrNot = dbc.TableIsEmpty("Diver");
            Assert.AreEqual(emptyOrNot, true);

            dbc.AddDiverToDatabase(d);
            emptyOrNot = dbc.TableIsEmpty("Diver");
            Assert.AreEqual(emptyOrNot, false);

            dbc.RemoveDiverFromTable(d);
            emptyOrNot = dbc.TableIsEmpty("Diver");
            Assert.AreEqual(emptyOrNot, true);

            dbc.CloseConnectionToDatabase();
        }

        /// <summary>
        /// Testing the RemoveJudgeFromDatabase function. 
        /// </summary>
        [Test]
        public void RemoveJudgeFromJudgeTableTest()
        {
            Judge j = new Judge("Gnurra G", "Swedish", "111111-1111");
            dbc.ConnectToDatabase();
            dbc.ClearDatabase("Judge");
            bool emptyOrNot = dbc.TableIsEmpty("Judge");
            Assert.AreEqual(emptyOrNot, true);

            dbc.AddJudgeToDatabase(j);
            emptyOrNot = dbc.TableIsEmpty("Judge");
            Assert.AreEqual(emptyOrNot, false);

            dbc.RemoveJudgeFromTable(j);
            emptyOrNot = dbc.TableIsEmpty("Judge");
            Assert.AreEqual(emptyOrNot, true);

            dbc.CloseConnectionToDatabase();
        }

        /// <summary>
        /// Testing the RemoveContestFromDatabase function. 
        /// </summary>
        /*
        [Test]
        public void RemoveContestFromContestTableTest()
        {
            Contest c = new Contest("VM", "G-vik", "12/02/2015", "13/02/2015");
            dbc.ConnectToDatabase();
            dbc.ClearDatabase("Contest");
            bool emptyOrNot = dbc.TableIsEmpty("Contest");
            Assert.AreEqual(emptyOrNot, true);

            dbc.AddContestToDatabase(c);
            emptyOrNot = dbc.TableIsEmpty("Contest");
            Assert.AreEqual(emptyOrNot, false);

            dbc.RemoveContestFromTable(c);
            emptyOrNot = dbc.TableIsEmpty("Contest");
            Assert.AreEqual(emptyOrNot, true);

            dbc.CloseConnectionToDatabase();
        }
          */
    }
}
