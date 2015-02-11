using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Management.Instrumentation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace Simhopp
{
    public class Contest
    {
        #region Data
        private string place;
        private string name;
        private string date;
        private TrickList trickList = new TrickList();
        private List<Judge> judgeList = new List<Judge>();
        public List<Participant> participantsList = new List<Participant>();
        //!!!!!!!!!
        private List<Participant> liveResultList;

        #endregion

        #region Constructor
        public Contest()
        {
            this.place = "";
            this.name = "";
            this.date = "";
            trickList.ReadFromFile("tricklist.txt");
        }

        public Contest(string place, string name, string date)
        {
            this.place = place;
            this.name = name;
            this.date = date;
            trickList.ReadFromFile("tricklist.txt");
        }
        #endregion

        #region Properties
        public string Name
        {
            get
            {
                if (this.name == null)
                {
                    throw new Exception("Name is null");
                }
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
                if (this.place == null)
                {
                    throw new Exception("Place is null");
                }
                return this.place;
            }
            set
            {
                this.place = value;
            }
        }
        public string Date
        {
            get
            {
                if (this.date == null)
                {
                    throw new Exception("Date is null");
                }
                return this.date;
            }
            set
            {
                this.date = value;
            }
        }
        #endregion

        #region Methods

        public bool IsJudgeInContest(Judge judge)
        {
            return judgeList.Find(x => x.SSN == judge.SSN) != null;
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

        public int GetNumberOfParticipants()
        {
            return participantsList.Count;
        }
        public int GetNumberOfJudges()
        {
            return judgeList.Count;
        }

        public double GetTrickDifficultyFromTrickHashTable(string trickName)
        {
            return trickList.GetDifficultyByName(trickName);
        }

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


        public void SimulateContest()
        {
            for (int jumpNo = 0; jumpNo < 3; jumpNo++)
            {
                MakeJump(jumpNo);
                SortParticipants(ref participantsList, true);
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
            foreach (var participant in participantsList)
            {
                Console.WriteLine(participant.GetDiverInfo());
            }
        }

        /// <summary>
        /// Creates a list with the current result (including name,nationality and points).
        /// </summary>
        /// <returns>Returns list of current result</returns>
        public List<string> CreateResultList()
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
            using (var fs = new FileStream("result.htm", FileMode.Create))
            {
                using (var writer = new StreamWriter(fs, Encoding.UTF8))
                {
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
        }
        /// <summary>
        /// Sort participantslist by totalpoints in ascending/descending order.
        /// <param name="list">List to sort</param>
        /// <param name="highestToLowest">Sort totalpoints highest to lowest</param>
        /// </summary>
        public void SortParticipants(ref List<Participant> list, bool highestToLowest)
        {                           //referens?
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
            liveResultList = new List<Participant>(participantsList);
            SortParticipants(ref liveResultList, true);
            foreach (var participant in liveResultList)
            {
                Console.WriteLine("{0,-3}{1,-15}{2,-10}", (i++ + "."), participant.GetDiverName(), participant.TotalPoints);
            }
            Console.ReadKey();
        }
        #endregion

        #region Check correct input
        public static bool CheckCorrectName(string name)
        {
            Regex patternName = new Regex(@"^[a-zA-Z]+(([\'\.\- ][a-zA-Z ])?[a-zA-Z]*)*$");
            return patternName.IsMatch(name);
        }

        public static bool CheckCorrectPlace(string place)
        {
            Regex patternName = new Regex(@"^[a-zA-Z]+(([\'\.\- ][a-zA-Z ])?[a-zA-Z]*)*$");
            return patternName.IsMatch(place);
        }

        public static bool CheckCorrectDate(string date)
        {
            Regex patternName = new Regex(@"^((((0[13578])|([13578])|(1[02]))[\/](([1-9])|([0-2][0-9])|(3[01])))|(((0[469])|([469])|(11))[\/](([1-9])|([0-2][0-9])|(30)))|((2|02)[\/](([1-9])|([0-2][0-9]))))[\/]\d{4}$|^\d{4}$");
            return patternName.IsMatch(date);
        }
        #endregion     
    }
}

