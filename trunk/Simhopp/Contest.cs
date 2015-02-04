﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        private TrickList trickList;
        private List<Judge> judgeList = new List<Judge>();
        private List<Participant> participantsList = new List<Participant>();

        #endregion

        #region Constructor
        public Contest() 
        {
            this.place = "";
            this.name = "";
            this.date = "";
        }

        public Contest(string place, string name, string date)
        {
            this.place = place;
            this.name = name;
            this.date = date;
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
        public void AddParticipant(Diver diver)
        {
            participantsList.Add(new Participant(diver));
        }


        public void AddJudge(Judge judge)
        {
            if (judge.Name.Equals(""))
                throw new Exception("Judge name is not set.");
            else if (judge.Nationality.Equals(""))
                throw new Exception("Judge nationality is not set.");
            else if (judge.SSN.Equals(""))
                throw new Exception("Judge social security number is not set.");
            else if (judgeList.Find(x => x.SSN == judge.SSN) != null)
                throw new Exception("Judge is already in list.");
            else if (judgeList.Count >= 7)
                throw new Exception("All 7 judges are already set in the list.");
            else
            {
                judgeList.Add(judge);
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

        public void MakeJump()
        {
            SortParticipants();
            Random random = new Random();

            double result;
            for (var i = 0; i < 7; i++)
            {
                result = 0;
                result = random.Next(0, 11);
              //  result += random.NextDouble();

                for (var j = 0; j < 3; j++)
                {
                    participantsList[0].SetJudgePoint(j, i, result);
                    participantsList[0].SetTrick(j, "Forward Double Somersault");

                    participantsList[0].CalculatePoints();
                }
            }  
        //lägg till uträkning av poäng   

        }

        public void PrintResult()
        {
            
        }

        public void SortParticipants()
        {
            IComparer<Participant> comparer = new OrderingClass();
            participantsList.Sort(comparer);
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

        #region Ordering Class
        /// <summary>
        /// Compare class to be able to sort the participantsList.
        /// </summary>
        public class OrderingClass : IComparer<Participant>
        {
            public int Compare(Participant x, Participant y)
            {
                return x.TotalPoints > y.TotalPoints ? 1 : 0;
            }
        }
        #endregion
    }
}

