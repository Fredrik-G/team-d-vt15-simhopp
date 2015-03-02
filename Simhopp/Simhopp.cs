using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
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
        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor. Creates a database connection. 
        /// </summary>
        public Simhopp()
        {
            databaseController = new DatabaseController(@"M:/Desktop/simhoppTestDB.db");
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
            //DEBUG
            contestList.Add(new Contest(1, "asd", "a", "11/11/2011", "11/11/2011"));
            contestList.Add(new Contest(2, "asd", "b", "11/11/2011", "11/11/2011"));
            contestList.Add(new Contest(3, "asd", "c", "11/11/2011", "11/11/2011"));
            contestList.Add(new Contest(4, "asd", "d", "11/11/2011", "11/11/2011"));
            contestList.Add(new Contest(5, "asd", "e", "11/11/2011", "11/11/2011"));
            //-DEBUG
            //TODO: remove ^
            return contestList;
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
        /// <param name="contestName"></param>
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
        /// A function that gets a judge by its ssn.
        /// Throws ArgumentNullException if judge is not found.
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
            return databaseController.GetJudgeHash(GetJudgeBySSN(ssn));
        }

        /// <summary>
        /// Gets the salt for a given judge.
        /// Throws ArgumentNullException if judge is not found.
        /// </summary>
        /// <param name="ssn"></param>
        /// <returns></returns>
        public string GetJudgeSalt(string ssn)
        {
            return databaseController.GetJudgeSalt(GetJudgeBySSN(ssn));
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
                contestList.Add(new Contest(place, name, startDate, endDate));
            }
        }

        #region Add methods

        /// <summary>
        /// Adds judge to judge list by name.
        /// </summary>
        /// <param name="name">Judge name</param>
        /// <param name="nationality">Judge nationality</param>
        /// <param name="ssn">Judge ssn</param>
        public void AddJudgeToList(string name, string nationality, string ssn)
        {
            //kollar om judge redan finns i judgelist. 
            if (GetJudgeBySSN(ssn) != null)
            {
                throw new DuplicateNameException("Judge already exists in list");
            }

            try
            {
                judgeList.Add(new Judge(name, nationality, ssn));
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
            catch (Exception exception)
            {
                MsgBox.CreateErrorBox(exception.ToString(), MethodBase.GetCurrentMethod().ToString());
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
            catch (Exception exception)
            {
                MsgBox.CreateErrorBox(exception.ToString(), MethodBase.GetCurrentMethod().ToString());
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
            if (judge != null)
            {
                judge.Name = name;
                judge.Nationality = nationality;
                judge.SSN = ssn;
                databaseController.UpdateJudge(judge);
            }
        }

        #endregion

        #region Read from database
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
        /// Reads contests from database and adds them to contestlist.
        /// </summary>
        public void ReadContestsFromDatabase()
        {
            //get contest ej implementerad i databascontroller.
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
                            var judge = new Judge(temp[0], temp[1], temp[2]);
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
