using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using Simhopp.Model;

namespace Simhopp
{
    /// <summary>
    /// Class that creates and handles a contest-object
    /// </summary>
    public class Simhopp : ISimhopp
    {
        #region Data
        /// <summary>
        /// A list that holds every judge that is stored in the database
        /// </summary>
        BindingList<Judge> judgeList = new BindingList<Judge>();
        /// <summary>
        /// A list that holds every Diver that is stored in the database
        /// </summary>
        BindingList<Diver> diverList = new BindingList<Diver>();

        BindingList<Contest> contestList = new BindingList<Contest>();

        DatabaseController databaseController = new DatabaseController();
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

        public List<Judge> GetJudgesInContest(string contestName)
        {
            try
            {
                var selectedContest = contestList.SingleOrDefault(x => x.Name == contestName);
                return selectedContest.GetJudgesList();            
            }
            catch (NullReferenceException)
            {
                return new List<Judge>();
            }
            catch (ArgumentNullException nullException)
            {
                MsgBox.CreateErrorBox(" " + nullException, MethodBase.GetCurrentMethod().ToString());
            }               
            catch (Exception exception)
            {
                MsgBox.CreateErrorBox(" " + exception, MethodBase.GetCurrentMethod().ToString());
            }

            return new List<Judge>(); 
        }

        /// <summary>
        /// Returns list of divers in a given contest.
        /// </summary>
        /// <param name="contestName"></param>
        /// <returns></returns>
        public List<Diver> GetDiversInContest(string contestName)
        {                   //OBS SÖK EJ PÅ CONTEST NAME
            try
            {
                var selectedContest = contestList.SingleOrDefault(x => x.Name == contestName);
                return selectedContest.GetDiversList();
            }
            catch (NullReferenceException)
            {
                return new List<Diver>();
            }
            catch (ArgumentNullException nullException)
            {
                MsgBox.CreateErrorBox(" " + nullException, MethodBase.GetCurrentMethod().ToString());
            }
            catch (Exception exception)
            {
                MsgBox.CreateErrorBox(" " + exception, MethodBase.GetCurrentMethod().ToString());
            }

            return new List<Diver>();
        }
        /// <summary>
        /// A function that get a judge by its ssn
        /// </summary>
        /// <param name="name"></param>
        /// <returns>returns a judge object</returns>
        public Judge GetJudgeBySSN(string ssn)
        {
            try
            {
                return judgeList.SingleOrDefault(x => x.SSN == ssn);
            }
            catch (ArgumentNullException exception)
            {
                return null;
                //do something
            }
        }
        /// <summary>
        /// A function that get a diver by its ssn
        /// </summary>
        /// <param name="name"></param>
        /// <returns>returns a diver object</returns>
        public Diver GetDiverBySSN(string ssn)
        {
            try
            {
                return diverList.SingleOrDefault(x => x.SSN == ssn);
            }
            catch (ArgumentNullException exception)
            {
                return null;
                //do something
            }
        }
        #endregion

        #region Methods
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

        /// <summary>
        /// Adds judge to judge list by name.
        /// </summary>
        /// <param name="name">Judge name</param>
        public void AddJudgeToList(string name, string nationality, string ssn)
        {
            var judge = new Judge(name, nationality, ssn);

            try
            {
                judgeList.Add(judge);
            }
            catch (Exception exception)
            {
                //do something
            }
        }
        /// <summary>
        /// Adds diver to diver list by name.
        /// </summary>
        /// <param name="name">Judge name</param>
        public void AddDiverToList(string name, string nationality, string ssn)
        {
            var diver = new Diver(name, nationality, ssn);

            try
            {
                diverList.Add(diver);
            }
            catch (Exception exception)
            {
                //do something
            }
        }
        /// <summary>
        /// Removes a judge from list by ssn.
        /// </summary>
        /// <param name="ssn"></param>
        public void RemoveJudgeFromList(string ssn)
        {
            var judge = GetJudgeBySSN(ssn);
            judgeList.Remove(judge);
        }
        /// <summary>
        /// Removes a diver from list by ssn.
        /// </summary>
        /// <param name="ssn"></param>
        public void RemoveDiverFromList(string ssn)
        {
            var diver = GetDiverBySSN(ssn);
            diverList.Remove(diver);
        }

        /// <summary>
        /// Adds judge to judge list by name.
        /// </summary>
        /// <param name="name">Judge name</param>
        public void AddJudgeToContest(string contestName, string ssn)
        {                   //SÖK EJ PÅ CONTEST NAME
            try
            {
                var judge = GetJudgeBySSN(ssn);
                var selectedContest = contestList.SingleOrDefault(x => x.Name == contestName);
                selectedContest.AddJudge(judge);
            }
            catch (NullReferenceException nullReferenceException)
            {
                MsgBox.CreateErrorBox("" + nullReferenceException, MethodBase.GetCurrentMethod().ToString());
            }
            catch (ArgumentNullException argumentNullException)
            {
                MsgBox.CreateErrorBox("" + argumentNullException, MethodBase.GetCurrentMethod().ToString());
            }
            catch (Exception exception)
            {
                MsgBox.CreateErrorBox("" + exception, MethodBase.GetCurrentMethod().ToString());
            }
        }

        public void ReadJudgesFromDatabase()
        {
            databaseController.ConnectToDatabase();
            var judges = databaseController.GetJudges();
            foreach (var judge in judges)
            {
                judgeList.Add(judge);
            }
        }
        /// <summary>
        /// A function that reads judges and divers from text files
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
    }
}
