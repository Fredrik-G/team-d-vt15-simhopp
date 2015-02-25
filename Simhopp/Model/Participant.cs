using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp.Model
{
    /// <summary>
    /// Class the hold a diver object, three jumpResult objects and one result.
    /// </summary>
    public class Participant
    {
        #region Data
        /// <summary>
        /// Variable that hold data about total points achieved
        /// </summary>
        private double totalPoints = 0.0;
        private Diver diver = new Diver();
        /// <summary>
        /// Array of jumpResults that hold three jumpResult objects 
        /// </summary>
        private JumpResult[] jumpResults = new JumpResult[3];
        #endregion

        #region Constructor
        public Participant(Diver diver)
        {
            for (var i = 0; i < 3; i++)
            {
                jumpResults[i] = new JumpResult();
            }
            this.diver = diver;
        }

        #endregion

        #region Setters

        /// <summary>
        /// A function that sets judge points with respect to jump number and judge number 
        /// </summary>
        /// <param name="jumpNo"></param>
        /// <param name="judgeNo"></param>
        /// <param name="point"></param>
        public void SetJudgePoint(int jumpNo, int judgeNo, double point)
        {
            jumpResults[jumpNo].SetJudgePoint(judgeNo, point);
        }
        /// <summary>
        /// A function that sets a trick for a certain jump
        /// </summary>
        /// <param name="jumpNo"></param>
        /// <param name="name"></param>
        public void SetTrick(int jumpNo, string name)
        {
            jumpResults[jumpNo].TrickName = name;
        }
        #endregion

        #region Getters

        public Diver GetDiver()
        {
            return diver;
        }

        public JumpResult[] GetJumpResults()
        {
            return jumpResults;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets divers information.
        /// </summary>
        /// <returns>Returns diver name, nationality and totalpoints as string.</returns>
        public string GetDiverInfo()
        {
            return diver.Name + "\t" + diver.Nationality +  "\t" + TotalPoints;
        }
        public void CalculatePoints()
        {
            foreach (var jumpResult in jumpResults)
            {
                jumpResult.CalculateResult();
            }
        }
        public void UpdateTotalPoints(double jumpDifficulty)
        {
            foreach (var jumpResult in jumpResults)
            {
                totalPoints += jumpResult.SumJudgePoints * jumpDifficulty;
            }
        }



        /// <summary>
        /// Property for TotalPoints
        /// </summary>
        public double TotalPoints
        {
            get
            {
                if (Double.IsNaN(this.totalPoints))
                {
                    throw new Exception("totalPoints is NaN");
                }
                return this.totalPoints;
            }
            set
            {
                this.totalPoints = value;
            }
        }
        public string GetDiverSSN()
        {
            return diver.SSN;
        }

        public string GetDiverName()
        {
            return diver.Name;
        }

        public string GetDiverNationality()
        {
            return diver.Nationality;
        }

        /// <summary>
        /// Function that adds a diver object
        /// </summary>
        /// <param name="diver"></param>
        public void AddDiver(Diver diver)
        {
            this.diver = diver;
        }
        #endregion
    }
}

