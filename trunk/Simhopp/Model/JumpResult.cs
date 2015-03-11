using System.Linq;

namespace Simhopp.Model
{
    /// <summary>
    /// JumpResult class. Contains information about a specific jump in for a diver.
    /// Stores the trick name, the point the judges gave for the jump and the total points the jump genareted.
    /// </summary>
    public class JumpResult
    {
        #region Variables
        private string trickName;
        private double[] judgePoints;
        private double sumJudgePoints;
        #endregion

        #region Properties
        public string TrickName
        {
            get
            {
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
                return this.sumJudgePoints;
            } 
            set 
            {
                this.sumJudgePoints = value;
            }
        }

        #endregion
        
        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public JumpResult()
        {
            trickName = "";
            judgePoints = new double[7]; 
            for (var i = 0; i < judgePoints.Length; i++)
            {
                judgePoints[i] = -1;
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
            judgePoints = new[] { j0, j1, j2, j3, j4, j5, j6 }; 
            CalculateResult();
        }
        #endregion

        #region Methods
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
        /// Returns judgepoints.
        /// </summary>
        /// <returns></returns>
        public double[] GetJudgePointsArray()
        {
            return judgePoints;
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
            //this.sumJudgePoints = judgePoints.Sum() - judgePoints.Max() - judgePoints.Min();
            var sumPoints = 0.0;
            var min = 15.0;
            var max = 0.0;
            foreach (var point in judgePoints.Where(point => point >= -0.5))
            {
                if (point > max)
                {
                    max = point;
                }
                if (point < min)
                {
                    min = point;
                }

                sumPoints += point;
            }

            sumJudgePoints = sumPoints - max - min;
        }

        /// <summary>
        /// Checks if all judges are done.
        /// </summary>
        /// <param name="numberOfJudges"></param>
        /// <returns></returns>
        public bool IsAllJudgePointSet(int numberOfJudges)
        {
            for (var i = 0; i < numberOfJudges; i++)
            {
                if (judgePoints[i] < 0)
                {
                    return false;
                }
            }
            return true;
        }

        #endregion
    }
}
