using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimhoppGUI
{
    /// <summary>
    /// JumpResult class. Contains information about a specific jump in for a diver.
    /// Stores the trick name, the point the judges gave for the jump and the total points the jump genareted.
    /// </summary>
    public class JumpResult
    {
        #region JumpResult Variables
        private string trickName;
        private double[] judgePoints;
        private double sumJudgePoints;
        #endregion

        #region JumpResult Properties
        public string TrickName
        {
            get
            {
                if (this.trickName == null)
                {
                    throw new Exception("trickName is null");
                }
                return trickName;
            }
            set
            {
                this.trickName = value;
            }
        }
        public double SumJudgePoints
        { 
            get 
            {
                if (Double.IsNaN(this.sumJudgePoints))
                {
                    throw new Exception("sumJudgePoints is NaN.");
                }
                return this.sumJudgePoints;
            } 
            set 
            {
                this.sumJudgePoints = value;
            }
        }

        #endregion
        
        #region JumpResult Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public JumpResult()
        {
            trickName = "";
            judgePoints = new double[7]; 
            for (int i = 0; i < judgePoints.Length; i++)
            {
                judgePoints[i] = 0;
            }
            CalculateResult();
        }

        /// <summary>
        /// Constructor who takes a trick name and 7 judge points and stores them in the judgePoints array.
        /// Calculates the result with the CalculateResult method.
        /// </summary>
        /// <param name="trickName"></param>
        /// <param name="j0"></param>
        /// <param name="j1"></param>
        /// <param name="j2"></param>
        /// <param name="j3"></param>
        /// <param name="j4"></param>
        /// <param name="j5"></param>
        /// <param name="j6"></param>
        public JumpResult(string trickName, double j0, double j1, double j2, double j3, double j4, double j5, double j6)
        {
            this.trickName = trickName;
            judgePoints = new double[7]; 
            judgePoints[0] = j0;
            judgePoints[1] = j1;
            judgePoints[2] = j2;
            judgePoints[3] = j3;
            judgePoints[4] = j4;
            judgePoints[5] = j5;
            judgePoints[6] = j6;
            CalculateResult();
        }
        #endregion

        #region JumpResult Methods
        /// <summary>
        /// Returns a specific judge result depending on the judgeNo number. 
        /// </summary>
        /// <param name="judgeNo"></param>
        /// <returns></returns>
        public double GetJudgePoint(int judgeNo)
        {
            return judgePoints[judgeNo];
        }

        /// <summary>
        /// Stores a specific judges point in the corresponding place in the JudgePoints array.
        /// </summary>
        /// <param name="judgeNo"></param>
        /// <param name="point"></param>
        public void SetJudgePoint(int judgeNo, double point)
        {
            judgePoints[judgeNo] = point;
        }

        /// <summary>
        /// Calculates the result by adding all the doubles in the judgePoints array exept for the min and max points. 
        /// </summary>
        public void CalculateResult()
        {
            this.sumJudgePoints = judgePoints.Sum() - judgePoints.Max() - judgePoints.Min();
        }
        #endregion
    }
}
