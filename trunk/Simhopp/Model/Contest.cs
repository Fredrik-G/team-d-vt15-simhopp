using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Text.RegularExpressions;

namespace Simhopp.Model
{
    /// <summary>
    /// Contains information about a contest and controlls it.
    /// </summary>
    public class Contest
    {
        #region Data

        private int id;
        private bool isFinished = false;
        private string place;
        private string name;
        private string startDate;
        private string endDate;
        private TrickList trickList = new TrickList();
        private List<Judge> judgeList = new List<Judge>();
        private List<Participant> participantsList = new List<Participant>();
        private List<Participant> liveResultList = new List<Participant>();

        #endregion

        #region Constructor
        public Contest()
        {
            this.id = -1;
            this.place = "";
            this.name = "";
            this.startDate = "";
            this.EndDate = "";
        }

        public Contest(string place, string name, string startDate, string endDate)
        {
            this.id = -1;
            this.place = place;
            this.name = name;
            this.startDate = startDate;
            this.endDate = endDate;
        }

        public Contest(int id, string place, string name, string startDate, string endDate)
        {
            this.id = id;
            this.place = place;
            this.name = name;
            this.startDate = startDate;
            this.endDate = endDate;
        }
        #endregion

        #region Properties

        public bool IsFinished
        {
            get
            {
                return isFinished;
            }
            set
            {
                this.isFinished = value;
            }
        }

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public string Place
        {
            get
            {
                return this.place;
            }
            set
            {
                this.place = value;
            }
        }
        public string StartDate
        {
            get
            {
                return this.startDate;
            }
            set
            {
                this.startDate = value;
            }
        }

        public string EndDate
        {
            get
            {
                return this.endDate;
            }
            set
            {
                this.endDate = value;
            }
        }
        #endregion

        #region Getters

        public List<Participant> GetParticipants()
        {
            return participantsList;
        }

        public List<Judge> GetJudgesList()
        {
            return judgeList;
        }

        public List<Diver> GetDiversList()
        {
            return participantsList.Select(participant => participant.GetDiver()).ToList();
        }

        public List<Participant> GetLiveResultList()
        {
            return liveResultList;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Checks if given judge is in judge list.
        /// </summary>
        /// <param name="judge"></param>
        /// <returns></returns>
        public bool IsJudgeInContest(Judge judge)
        {
            return judgeList.Find(x => x.SSN == judge.SSN) != null;
        }

        /// <summary>
        /// Checks if given diver is in participants list.
        /// </summary>
        /// <param name="diver"></param>
        /// <returns></returns>
        public bool IsDiverInContest(Diver diver)
        {
            return participantsList.Find(x => x.GetDiverSSN() == diver.SSN) != null;
        }

        /// <summary>
        /// Adds a participant to the participantsList. Catches exeptions if there should be something wrong with the participant that should be added. 
        /// </summary>
        /// <param name="diver"></param>
        public void AddParticipant(Diver diver)
        {
            try
            {
                if (diver == null)
                {
                    throw new NullReferenceException("diver is null");
                }
                else if (!Person.CheckCorrectName(diver.Name))
                {
                    throw new InvalidDataException("diver name is not set or invalid.");
                }
                else if (!Person.CheckCorrectNationality(diver.Nationality))
                {
                    throw new InvalidDataException("diver nationality is not set or invalid.");
                }
                else if (!Person.CheckCorrectSSN(diver.SSN, diver.Nationality))
                {
                    throw new InvalidDataException("diver social security number is not set or invalid.");
                }
                else if (IsDiverInContest(diver))
                {
                    throw new DuplicateNameException("Diver is already in list.");
                }
                else
                {
                    participantsList.Add(new Participant(diver));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void AddParticipant(Participant participant)
        {
            try
            {
                if (participant == null)
                {
                    throw new NullReferenceException("participant is null");
                }
                /*else if (!Person.CheckCorrectName(diver.Name))
                {
                    throw new InvalidDataException("diver name is not set or invalid.");
                }
                else if (!Person.CheckCorrectNationality(diver.Nationality))
                {
                    throw new InvalidDataException("diver nationality is not set or invalid.");
                }
                else if (!Person.CheckCorrectSSN(diver.SSN, diver.Nationality))
                {
                    throw new InvalidDataException("diver social security number is not set or invalid.");
                }*/

                else
                {
                    participantsList.Add(participant);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Adds a judge to the judgelist. Catches exeptions if there should be something wrong with the judge that should be added. 
        /// </summary>
        /// <param name="judge"></param>
        public void AddJudge(Judge judge)
        {
            try
            {
                if (judge == null)
                {
                    throw new NullReferenceException("Judge is null");
                }
                else if (!Person.CheckCorrectName(judge.Name))
                {
                    throw new InvalidDataException("Judge name is not set or invalid.");
                }
                else if (!Person.CheckCorrectNationality(judge.Nationality))
                {
                    throw new InvalidDataException("Judge nationality is not set or invalid.");
                }
                else if (!Person.CheckCorrectSSN(judge.SSN, judge.Nationality))
                {
                    throw new InvalidDataException("Judge social security number is not set or invalid.");
                }
                else if (IsJudgeInContest(judge))
                {
                    throw new DuplicateNameException("Judge is already in list.");
                }
                else if (judgeList.Count >= 7)
                {
                    throw new IndexOutOfRangeException("All 7 judges are already set in the list.");
                }
                else
                {
                    judgeList.Add(judge);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Sets a given trick for a given participant
        /// </summary>
        /// <param name="trickNo"></param>
        /// <param name="trickName"></param>
        /// <param name="ssn"></param>
        public void SetTrick(int trickNo, string trickName, string ssn)
        {
            var participant = participantsList.SingleOrDefault(x => x.GetDiverSSN() == ssn);
            participant.SetTrick(trickNo, trickName);
        }

        /// <summary>
        /// Sets trick result for given participant.
        /// </summary>
        /// <param name="judgeSsn"></param>
        /// <param name="diverSsn"></param>
        /// <param name="point"></param>
        /// <param name="jumpNo"></param>
        public void SetJudgePoint(string judgeSsn, string diverSsn, double point, int jumpNo)
        {
            var participant = participantsList.SingleOrDefault(x => x.GetDiverSSN() == diverSsn);
            var judge = judgeList.SingleOrDefault(x => x.SSN == judgeSsn);

            participant.SetJudgePoint(jumpNo, judgeList.IndexOf(judge), point);
        }

        /// <summary>
        /// Removes a given judge from judge list.
        /// </summary>
        /// <param name="ssn"></param>
        public void RemoveJudgeFromList(string ssn)
        {
            var judge = judgeList.SingleOrDefault(x => x.SSN == ssn);
            judgeList.Remove(judge);
        }

        /// <summary>
        /// Removes a given diver from participants list.
        /// </summary>
        /// <param name="ssn"></param>
        public void RemoveDiverFromList(string ssn)
        {
            foreach (var participant in participantsList.Where(participant => participant.GetDiverSSN() == ssn))
            {
                participantsList.Remove(participant);
                return;
            }
        }

        /// <summary>
        /// Gets the number of participants in participants list.
        /// </summary>
        /// <returns></returns>
        public int GetNumberOfParticipants()
        {
            return participantsList.Count;
        }
        /// <summary>
        /// Gets the number of participants in participants list.
        /// </summary>
        /// <returns></returns>
        public int GetNumberOfJudges()
        {
            return judgeList.Count;
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

        /// <summary>
        /// Gets the result for a given participant.
        /// </summary>
        /// <param name="ssn">ssn for the participant.</param>
        /// <returns></returns>
        public double GetResultFromParticipant(string ssn)
        {
            foreach (var participant in participantsList)
            {
                if (participant.GetDiverSSN().Equals(ssn))
                {
                    return participant.TotalPoints;
                }
            }
            throw new InstanceNotFoundException("Person with " + ssn + " not found.");
        }

        public string GetTrick(int trickNo, string ssn)
        {
            var participant = participantsList.SingleOrDefault(x => x.GetDiverSSN() == ssn);
            return participant.GetTrick(trickNo);
        }

        /// <summary>
        /// Simulates a contest with three jump sets.
        /// </summary>
        public void SimulateContest()
        {
            if (isFinished)
            {
                Console.WriteLine("Contest is already finished.");
                return;
            }
            {
                liveResultList.Clear();
                foreach (var participant in participantsList)
                {
                    liveResultList.Add(participant);
                }
                for (int jumpNo = 0; jumpNo < 3; jumpNo++)
                {
                    MakeJump(jumpNo);
                    SortParticipants(ref participantsList, false);
                }
                isFinished = true;
            }
        }

        /// <summary>
        /// Simulates all the jumps of a competition. Sets a specific jump for all divers and randomizes all judges scores
        /// ans sets them. Calls for the live result list to be printed. 
        /// </summary>
        /// <param name="jumpNo"></param>
        public void MakeJump(int jumpNo)
        {
            Random random = new Random();

            foreach (var participant in participantsList)
            {
                participant.SetTrick(jumpNo, "Forward Double Somersault");
                for (var i = 0; i < judgeList.Count; i++)
                {
                    participant.SetJudgePoint(jumpNo, i, random.Next(0, 11));
                    participant.CalculatePoints();
                }
                participant.UpdateTotalPoints(trickList.GetDifficultyByName("Forward Double Somersault"));
                PrintLiveResults(jumpNo);
            }
        }

        /// <summary>
        /// Prints the results list.
        /// </summary>
        public void PrintResult()
        {
            foreach (var participant in liveResultList)
            {
                Console.WriteLine(participant.GetDiverInfo());
            }
        }

        /// <summary>
        /// Creates a list with the current result (including name,nationality and points).
        /// </summary>
        /// <returns>Returns list of current result</returns>
        private List<string> CreateResultList()
        {
            var resultList = new List<string>();
            for (var i = participantsList.Count - 1; i >= 0; i--)
            {
                resultList.Add(participantsList[i].GetDiverInfo());
            }
            return resultList;
        }

        /// <summary>
        /// Creates a HTML file with the contests result.
        /// </summary>
        public void CreateHtmlResultFile()
        {
            FileStream fileStream = null;
            try
            {
                fileStream = new FileStream("result.htm", FileMode.Create);

                using (var writer = new StreamWriter(fileStream, Encoding.UTF8))
                {
                    fileStream = null;

                    writer.WriteLine("<H2>" + this.Name + "\t" + this.Place + "</H2>");
                    writer.WriteLine("<ol>");
                    var resultList = CreateResultList();
                    foreach (var line in resultList)
                    {
                        writer.WriteLine("<li>" + line + "</li>");
                    }
                    writer.WriteLine("</ol>");
                }
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Sort participantslist by totalpoints in ascending/descending order.
        /// <param name="list">List to sort</param>
        /// <param name="highestToLowest">Sort totalpoints highest to lowest</param>
        /// </summary>
        public void SortParticipants(ref List<Participant> list, bool highestToLowest)
        {
            if (!highestToLowest)
            {
                list.Sort((x, y) => x.TotalPoints.CompareTo(y.TotalPoints));
            }
            else
            {
                list.Sort((x, y) => y.TotalPoints.CompareTo(x.TotalPoints));
            }
        }

        /// <summary>
        /// Creates a copy of the participantsList and sorts it and prints it between every single jump.
        /// </summary>
        /// <param name="jumpNo"></param>
        public void PrintLiveResults(int jumpNo)
        {
            Console.Clear();
            Console.WriteLine("Round: " + (jumpNo + 1));
            int i = 1;

            SortParticipants(ref liveResultList, true);
            foreach (var participant in liveResultList)
            {
                Console.WriteLine("{0,-3}{1,-15}{2,-10}", (i++ + "."), participant.GetDiverName(), participant.TotalPoints);
            }
            Console.ReadKey();
        }
        #endregion

        public bool IsAllJudgePointSet(string diverSsn, int jumpNo)
        {
            var selectedParticipant = participantsList.SingleOrDefault(x => x.GetDiverSSN() == diverSsn);
            var judgePoints = selectedParticipant.GetJumpResults();

            return judgePoints[jumpNo].IsAllJudgePointSet(judgeList.Count);
        }

        public Participant GetParticipant(int participantNo)
        {
            return participantsList[participantNo];
        }

        #region Check correct input
        /// <summary>
        /// Allowed characters: "a-Z '.- "
        /// "Jerusalem-VM, He'Man, Asp.Net"
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool CheckCorrectName(string name)
        {
            Regex patternName = new Regex(@"^[a-zA-Z]+(([\'\.\- ][a-zA-Z ])?[a-zA-Z]*)*$");
            return patternName.IsMatch(name);
        }
        /// <summary>
        /// Allowed characters: "a-Z '.- "
        /// "Jerusalem-VM, He'Man, Asp.Net"
        /// </summary>
        /// <param name="place"></param>
        /// <returns></returns>
        public static bool CheckCorrectPlace(string place)
        {
            Regex patternName = new Regex(@"^[a-zA-Z]+(([\'\.\- ][a-zA-Z ])?[a-zA-Z]*)*$");
            return patternName.IsMatch(place);
        }
        /// <summary>
        /// "dd/mm/yyyy", "dd.mm.yyyy", "dd-mm-yyyy"
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool CheckCorrectDate(string date)
        {
            Regex patternName = new Regex(@"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$");
            return patternName.IsMatch(date);
        }
        #endregion
    }
}

