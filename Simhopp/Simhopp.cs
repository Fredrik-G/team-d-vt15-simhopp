using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Simhopp.Model;

namespace Simhopp
{
    /// <summary>
    /// Class that creates and handles a contest-object
    /// </summary>
    public class Simhopp : ISimhopp, IDisposable
    {
        #region Data
        /// <summary>
        /// A list that holds every judge that is stored in the database
        /// </summary>
        private BindingList<Judge> judgeList = new BindingList<Judge>();
        /// <summary>
        /// A list that holds every Diver that is stored in the database
        /// </summary>
        private BindingList<Diver> diverList = new BindingList<Diver>();

        private BindingList<Contest> contestList = new BindingList<Contest>();

        private DatabaseController databaseController;

        private TrickList trickList = new TrickList();
        private Server server = new Server();
        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor. Creates a database connection. 
        /// </summary>
        public Simhopp()
        {
            databaseController = new DatabaseController(@"C:\temp\Simhopp\Simhopp\simhoppTestDB.db");
           // databaseController = new DatabaseController(@"m:\desktop\simhopptestdb.db");
            databaseController.ConnectToDatabase();
        }

        #endregion

        #region Getters
        /// <summary>
        /// Returns contests list.
        /// </summary>
        /// <returns></returns>
        public BindingList<Contest> GetContestsList()
        {
            return contestList;
        }

        /// <summary>
        /// Returns a contest based on id.
        /// </summary>
        /// <param name="id">Contest id</param>
        /// <returns>Contest object.</returns>
        public Contest GetContest(int id)
        {
            return contestList.SingleOrDefault(x => x.Id == id);
        }

        public Contest GetContestFromDatabase(Contest contest)
        {
            return databaseController.GetContest(contest);
        }

        /// <summary>
        /// Returns judges list.
        /// </summary>
        /// <returns></returns>
        public BindingList<Judge> GetJudgesList()
        {
            return judgeList;
        }
        /// <summary>
        /// Returns divers list.
        /// </summary>
        /// <returns></returns>
        public BindingList<Diver> GetDiversList()
        {
            return diverList;
        }
        /// <summary>
        /// Returns a list of judges in a given contest by contest id.
        /// </summary>
        /// <param name="id">Contest id</param>
        /// <returns></returns>
        public BindingList<Judge> GetJudgesInContest(int id)
        {
            try
            {
                var selectedContest = contestList.SingleOrDefault(x => x.Id == id);
                var judgesInContest = selectedContest.GetJudgesList();

                var judges = new BindingList<Judge>();

                foreach (var judge in judgesInContest)
                {
                    judges.Add(judge);
                }
                return judges;
            }
            catch (NullReferenceException)
            {
                return new BindingList<Judge>();
            }
            catch (ArgumentNullException nullException)
            {
                MsgBox.CreateErrorBox(nullException.ToString(), MethodBase.GetCurrentMethod().ToString());
            }
            catch (Exception exception)
            {
                MsgBox.CreateErrorBox(exception.ToString(), MethodBase.GetCurrentMethod().ToString());
            }

            return new BindingList<Judge>();
        }
        /// <summary>
        /// Returns list of divers in a given contest.
        /// </summary>
        /// <param name="id">Contest id</param>
        /// <returns></returns>
        public BindingList<Diver> GetDiversInContest(int id)
        {
            try
            {
                var selectedContest = contestList.SingleOrDefault(x => x.Id == id);

                var diversInContest = selectedContest.GetDiversList();

                var divers = new BindingList<Diver>();

                foreach (var diver in diversInContest)
                {
                    divers.Add(diver);
                }
                return divers;
            }
            catch (NullReferenceException)
            {
                return new BindingList<Diver>();
            }
            catch (ArgumentNullException nullException)
            {
                MsgBox.CreateErrorBox(nullException.ToString(), MethodBase.GetCurrentMethod().ToString());
            }
            catch (Exception exception)
            {
                MsgBox.CreateErrorBox(exception.ToString(), MethodBase.GetCurrentMethod().ToString());
            }

            return new BindingList<Diver>();
        }

        /// <summary>
        /// Gets a divers trick based on trick number and contest id.
        /// </summary>
        /// <param name="contestId"></param>
        /// <param name="trickNo"></param>
        /// <param name="ssn"></param>
        /// <returns></returns>
        public string GetDiversTrick(int contestId, int trickNo, string ssn)
        {
            try
            {
                var selectedContest = contestList.SingleOrDefault(x => x.Id == contestId);

                var selectedParticipant = selectedContest.GetParticipants().SingleOrDefault(x => x.GetDiverSSN() == ssn);

                return selectedParticipant.GetTrick(trickNo);
            }
            catch (NullReferenceException)
            {

            }
            catch (ArgumentNullException nullException)
            {
                MsgBox.CreateErrorBox(nullException.ToString(), MethodBase.GetCurrentMethod().ToString());
            }
            catch (Exception exception)
            {
                MsgBox.CreateErrorBox(exception.ToString(), MethodBase.GetCurrentMethod().ToString());
            }

            return "";
        }
        /// <summary>
        /// A function that gets a judge by its ssn.
        /// Throws NullReferenceException if judge is not found.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>returns a judge object</returns>
        public Judge GetJudgeBySSN(string ssn)
        {
            return judgeList.SingleOrDefault(x => x.SSN == ssn);
        }

        /// <summary>
        /// A function that get a diver by its ssn
        /// </summary>
        /// <param name="name"></param>
        /// <returns>returns a diver object</returns>
        public Diver GetDiverBySSN(string ssn)
        {
            return diverList.SingleOrDefault(x => x.SSN == ssn);
        }

        /// <summary>
        /// Gets the hashcode for a given judge.
        /// Throws ArgumentNullException if judge is not found.
        /// </summary>
        /// <param name="ssn"></param>
        /// <returns></returns>
        public string GetJudgeHash(string ssn)
        {
            return GetJudgeBySSN(ssn).Hash;
        }

        /// <summary>
        /// Gets the salt for a given judge.
        /// Throws ArgumentNullException if judge is not found.
        /// </summary>
        /// <param name="ssn"></param>
        /// <returns></returns>
        public string GetJudgeSalt(string ssn)
        {
            return GetJudgeBySSN(ssn).Salt;
        }

        /// <summary>
        /// Returns trick list.
        /// </summary>
        /// <returns></returns>
        public BindingList<Trick> GetTrickList()
        {
            return trickList.GetTrickList();
        }

        /// <summary>
        /// Returns a given trick to a given contest/participant.
        /// </summary>
        /// <param name="contestId"></param>
        /// <param name="trickNo"></param>
        /// <param name="ssn"></param>
        public string GetTrickFromParticipant(int contestId, int trickNo, string ssn)
        {
            try
            {
                var selectedContest = contestList.SingleOrDefault(x => x.Id == contestId);
                return selectedContest.GetNumberOfParticipants() > 0 ? selectedContest.GetTrick(trickNo, ssn) : "";
            }

            catch (NullReferenceException nullReferenceException)
            {
                MsgBox.CreateErrorBox(nullReferenceException.ToString(), MethodBase.GetCurrentMethod().Name);
            }
            return "";
        }

        /// <summary>
        /// Returns the difficulty of a given trick name.
        /// </summary>
        /// <param name="trickName"></param>
        /// <returns></returns>
        public double GetTrickDifficultyFromTrickHashTable(string trickName)
        {
            return trickList.GetDifficultyByName(trickName);
        }

        #endregion

        /// <summary>
        /// Creates a new contest
        /// </summary>
        public void CreateContest(string place, string name, string startDate, string endDate)
        {
            if (!Contest.CheckCorrectName(name))
            {
                throw new InvalidDataException("contest name is not set or invalid.");
            }
            else if (!Contest.CheckCorrectPlace(place))
            {
                throw new InvalidDataException("contest place is not set or invalid.");
            }
            else if (!Contest.CheckCorrectDate(startDate))
            {
                throw new InvalidDataException("contest date is not set or invalid.");
            }
            else if (!Contest.CheckCorrectDate(endDate))
            {
                throw new InvalidDataException("contest date is not set or invalid.");
            }
            else
            {
                var contest = new Contest(place, name, startDate, endDate);
                contestList.Add(contest);
                databaseController.AddContestToDatabase(contest);
            }
        }

        #region Add methods

        /// <summary>
        /// Adds judge to judge list by name.
        /// </summary>
        /// <param name="name">Judge name</param>
        /// <param name="nationality">Judge nationality</param>
        /// <param name="ssn">Judge ssn</param>
        /// <param name="password">Judge password. Default = "password".</param>
        public void AddJudgeToList(string name, string nationality, string ssn, string password = "password")
        {
            //kollar om judge redan finns i judgelist. 
            if (GetJudgeBySSN(ssn) != null)
            {
                throw new DuplicateNameException("Judge already exists in list");
            }
            try
            {
                judgeList.Add(new Judge(name, nationality, ssn, password));
            }
            catch (Exception)
            {
                //do something
            }
        }

        /// <summary>
        /// Adds a diver to diver list.
        /// </summary>
        /// <param name="name">Diver name</param>
        /// <param name="nationality">Diver nationality</param>
        /// <param name="ssn">Diver ssn</param>
        public void AddDiverToList(string name, string nationality, string ssn)
        {
            if (GetDiverBySSN(ssn) != null)
            {
                throw new DuplicateNameException("Diver already exists in list");
            }
            try
            {
                diverList.Add(new Diver(name, nationality, ssn));
            }
            catch (Exception)
            {
                //do something
            }
        }

        /// <summary>
        /// Adds judge to a given contest.
        /// </summary>
        /// <param name="contestId"></param>
        /// <param name="ssn"></param>
        public void AddJudgeToContest(int contestId, string ssn)
        {
            try
            {
                var judge = GetJudgeBySSN(ssn);
                var selectedContest = contestList.SingleOrDefault(x => x.Id == contestId);
                selectedContest.AddJudge(judge);
            }
            catch (NullReferenceException nullReferenceException)
            {
                MsgBox.CreateErrorBox(nullReferenceException.ToString(), MethodBase.GetCurrentMethod().ToString());
            }
            catch (ArgumentNullException argumentNullException)
            {
                MsgBox.CreateErrorBox(argumentNullException.ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }

        /// <summary>
        /// Adds diver to a given contest.
        /// </summary>
        /// <param name="contestId"></param>
        /// <param name="ssn"></param>
        public void AddDiverToContest(int contestId, string ssn)
        {
            try
            {
                var diver = GetDiverBySSN(ssn);
                var selectedContest = contestList.SingleOrDefault(x => x.Id == contestId);
                selectedContest.AddParticipant(diver);
            }
            catch (NullReferenceException nullReferenceException)
            {
                MsgBox.CreateErrorBox(nullReferenceException.ToString(), MethodBase.GetCurrentMethod().ToString());
            }
            catch (ArgumentNullException argumentNullException)
            {
                MsgBox.CreateErrorBox(argumentNullException.ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }

        /// <summary>
        /// Adds a given trick to a given contest/participant.
        /// </summary>
        /// <param name="contestId"></param>
        /// <param name="trickNo"></param>
        /// <param name="trickName"></param>
        /// <param name="ssn"></param>
        public void AddTrickToParticipant(int contestId, int trickNo, string trickName, string ssn)
        {
            try
            {
                var selectedContest = contestList.SingleOrDefault(x => x.Id == contestId);
                selectedContest.SetTrick(trickNo, trickName, ssn);
            }

            catch (NullReferenceException nullReferenceException)
            {
                MsgBox.CreateErrorBox(nullReferenceException.ToString(), MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion

        #region Remove methods

        /// <summary>
        /// Removes a judge from list and database.
        /// </summary>
        /// <param name="ssn"></param>
        public void RemoveJudgeFromList(string ssn)
        {
            var judge = GetJudgeBySSN(ssn);
            if (judge == null)
            {
                throw new NullReferenceException("Judge ssn " + ssn + " was not found.");
            }

            judgeList.Remove(judge);
            databaseController.RemoveJudgeFromTable(judge);
        }

        /// <summary>
        /// Removes a diver from list and database.
        /// </summary>
        /// <param name="ssn"></param>
        public void RemoveDiverFromList(string ssn)
        {
            var diver = GetDiverBySSN(ssn);
            diverList.Remove(diver);
            databaseController.RemoveDiverFromTable(diver);
        }

        /// <summary>
        /// Removes a judge from a given contest.
        /// </summary>
        /// <param name="contestId"></param>
        /// <param name="ssn"></param>
        public void RemoveJudgeFromContest(int contestId, string ssn)
        {
            try
            {
                var selectedContest = contestList.SingleOrDefault(x => x.Id == contestId);
                selectedContest.RemoveJudgeFromList(ssn);
            }

            catch (NullReferenceException nullReferenceException)
            {
                MsgBox.CreateErrorBox(nullReferenceException.ToString(), MethodBase.GetCurrentMethod().ToString());
            }
            catch (ArgumentNullException argumentNullException)
            {
                MsgBox.CreateErrorBox(argumentNullException.ToString(), MethodBase.GetCurrentMethod().ToString());
            }
            catch (Exception exception)
            {
                MsgBox.CreateErrorBox(exception.ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }

        /// <summary>
        /// Removes a diver from a given contest.
        /// </summary>
        /// <param name="contestId"></param>
        /// <param name="ssn"></param>
        public void RemoveDiverFromContest(int contestId, string ssn)
        {
            try
            {
                var selectedContest = contestList.SingleOrDefault(x => x.Id == contestId);
                selectedContest.RemoveDiverFromList(ssn);
            }
            catch (NullReferenceException nullReferenceException)
            {
                MsgBox.CreateErrorBox(nullReferenceException.ToString(), MethodBase.GetCurrentMethod().ToString());
            }
            catch (ArgumentNullException argumentNullException)
            {
                MsgBox.CreateErrorBox(argumentNullException.ToString(), MethodBase.GetCurrentMethod().ToString());
            }
            catch (Exception exception)
            {
                MsgBox.CreateErrorBox(exception.ToString(), MethodBase.GetCurrentMethod().ToString());
            }

        }

        #endregion

        #region Update methods

        /// <summary>
        /// Updates a contest with given data.
        /// Throws NullReferenceException if contest is not found.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="place"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public void UpdateContest(int id, string name, string place, string startDate, string endDate)
        {
            var contest = contestList.SingleOrDefault(x => x.Id == id);

            if (contest == null)
            {
                throw new NullReferenceException("Contest with id " + id + "not found.");
            }

            contest.Name = name;
            contest.Place = place;
            contest.StartDate = startDate;
            contest.EndDate = endDate;

            databaseController.UpdateContest(contest);
        }
        /// <summary>
        /// Updates a judge object in judgelist and in database.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="nationality"></param>
        /// <param name="ssn"></param>
        public void UpdateJudge(int id, string name, string nationality, string ssn)
        {
            var tempJudge = GetJudgeBySSN(ssn);
            if (tempJudge != null && tempJudge.Id != id)
            {//judge med det ssn finns redan
                throw new DuplicateNameException("Judge already exists");
            }

            var judge = judgeList.SingleOrDefault(x => x.Id == id);
            if (judge == null)
            {
                throw new NullReferenceException("Judge with id " + id + " not found");
            }

            judge.Name = name;
            judge.Nationality = nationality;
            judge.SSN = ssn;
            databaseController.UpdateJudge(judge);
        }
        /// <summary>
        /// Updates a diver object in judgelist and in database.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="nationality"></param>
        /// <param name="ssn"></param>
        public void UpdateDiver(int id, string name, string nationality, string ssn)
        {
            var tempdiver = GetDiverBySSN(ssn);
            if (tempdiver != null && tempdiver.Id != id)
            {//diver med det ssn finns redan
                throw new DuplicateNameException("diver already exists");
            }

            var diver = diverList.SingleOrDefault(x => x.Id == id);
            if (diver == null)
            {
                throw new NullReferenceException("diver with id " + id + " not found");
            }

            diver.Name = name;
            diver.Nationality = nationality;
            diver.SSN = ssn;
            databaseController.UpdateDiver(diver);
        }

        #endregion

        #region Read/Write from/to database

        /// <summary>
        /// Reads judges from database and adds them to judgelist.
        /// </summary>
        public void ReadJudgesFromDatabase()
        {
            judgeList = databaseController.GetJudgeList();
        }
        /// <summary>
        /// Reads divers from database and adds them to diverlist.
        /// </summary>
        public void ReadDiversFromDatabase()
        {
            diverList = databaseController.GetDiverList();
        }
        /// <summary>
        /// Reads all contests from database and adds them to contestList.
        /// </summary>
        public void ReadContestsFromDatabase()
        {
            contestList = databaseController.GetContestList();
        }

        /// <summary>
        /// Reads tricks from database and adds them to the tricklist.
        /// </summary>
        public void ReadTricksFromDatabase()
        {
            trickList.ReadFromDatabase(databaseController);
        }

        public void SaveContestToDatabase(Contest contest)
        {
            databaseController.UpdateContest(contest);
        }

        #endregion

        #region Read from file

        /// <summary>
        /// Reads judges and divers from text files.
        /// </summary>
        /// <param name="fileName"></param>
        public void ReadFromFile(string fileName)
        {
            try
            {
                using (var reader = new StreamReader(@"Model\Files\" + fileName))
                {
                    var text = new List<string>();
                    while (!reader.EndOfStream)
                    {
                        text.Add(reader.ReadLine());
                    }
                    foreach (var line in text)
                    {
                        var temp = line.Split(';');

                        if (fileName == "judge.txt")
                        {
                            var judge = new Judge(temp[0], temp[1], temp[2], "password");
                            judgeList.Add(judge);
                        }
                        else if (fileName == "diver.txt")
                        {
                            var diver = new Diver(temp[0], temp[1], temp[2]);
                            diverList.Add(diver);
                        }
                        else
                        {
                            throw new IOException("File not found");
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Error when reading file " + fileName + "\n" + e.Message);
            }
        }

        #endregion

        #region Server methods

        public void StartServer()
        {
            server.StartServer();
            server.SetJudges(ref judgeList);
        }

        public void HandleMessage()
        {

        }

        public void SetDiverMessage(string contestName, string diverName, string trickName, double trickDifficulty)
        {
            server.SetDiverMessage(contestName, diverName, trickName, trickDifficulty);
        }

        public void SendDataToClient()
        {
            server.SendDataToClient();
        }

        public ClientObjectData GetFirstClientObjectData()
        {
            return server.GetFirstClientObjectData();
        }

        public string GetIPForServer()
        {
            return server.GetIPForServer();
        }
        #endregion

        /// <summary>
        /// Sets a judge point for a given diver in a given contest.
        /// </summary>
        /// <param name="contestId"></param>
        /// <param name="judgeSsn"></param>
        /// <param name="diverSsn"></param>
        /// <param name="point"></param>
        /// <param name="jumpNo"></param>
        public void SetJudgePoint(int contestId, string judgeSsn, string diverSsn, double point, int jumpNo)
        {
            var selectedContest = contestList.FirstOrDefault(x => x.Id == contestId);
            selectedContest.SetJudgePoint(judgeSsn, diverSsn, point, jumpNo);
        }

        /// <summary>
        /// Checks if all judges are done for a given participant in a given contest.
        /// </summary>
        /// <param name="contestId"></param>
        /// <param name="diverSsn"></param>
        /// <param name="jumpNo"></param>
        /// <returns></returns>
        public bool IsAllJudgePointSet(int contestId, string diverSsn, int jumpNo)
        {
            var selectedContest = contestList.SingleOrDefault(x => x.Id == contestId);
            return selectedContest.IsAllJudgePointSet(diverSsn, jumpNo);
        }



        #region IDisposable methods

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                databaseController.Dispose();
            }
        }

        #endregion

    }
}
