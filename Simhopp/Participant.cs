﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    /// <summary>
    /// Class the hold a diver object, three jumpResult objects and one result
    /// </summary> 
    public class Participant
    {
        #region Data
        /// <summary>
        /// Variable that hold data about total points achieved
        /// </summary> 
        private double totalPoints = 0.0;
        Diver diver = new Diver();
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

        #region Methods
        public void CalculatePoints()
        {
            foreach (var jumpResult in jumpResults)
            {
                jumpResult.CalculateResult();
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
        /// <summary>
        /// Help function for calculating the points for the jumpResult
        /// </summary>
        public void UpdatePoints()
        {
            foreach (var jumpResult in jumpResults)
            {
                jumpResult.CalculateResult();
            }
        }
        #endregion
    }
}
