using System.Linq;

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

        #region Properties

        /// <summary>
        /// Property for TotalPoints
        /// </summary>
        public double TotalPoints
        {
            get { return this.totalPoints; }
            set { this.totalPoints = value; }
        }

        public string DiverName
        {
            get { return this.diver.Name; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor that takes a diver object as argument.
        /// </summary>
        /// <param name="diver"></param>
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

        /// <summary>
        /// Sets the current divers id.
        /// </summary>
        /// <param name="id"></param>
        public void SetDiverId(int id)
        {
            diver.Id = id;
        }
        #endregion

        #region Getters

        /// <summary>
        /// Returns the current diver.
        /// </summary>
        /// <returns></returns>
        public Diver GetDiver()
        {
            return diver;
        }

        /// <summary>
        /// Gets divers information.
        /// </summary>
        /// <returns>Returns diver name, nationality and totalpoints as string.</returns>
        public string GetDiverInfo()
        {
            return diver.Name + "\t" + diver.Nationality + "\t" + TotalPoints;
        }

        /// <summary>
        /// Returns the current divers id.
        /// </summary>
        /// <returns></returns>
        public int GetDiverId()
        {
            return diver.Id;
        }

        /// <summary>
        /// Gets the current divers SSN.
        /// </summary>
        /// <returns></returns>
        public string GetDiverSSN()
        {
            return diver.SSN;
        }

        /// <summary>
        /// Gets the current divers name.
        /// </summary>
        /// <returns></returns>
        public string GetDiverName()
        {
            return diver.Name;
        }

        /// <summary>
        /// Gets the current divers nationality.
        /// </summary>
        /// <returns></returns>
        public string GetDiverNationality()
        {
            return diver.Nationality;
        }

        /// <summary>
        /// Returns jump results.
        /// </summary>
        /// <returns></returns>
        public JumpResult[] GetJumpResults()
        {
            return jumpResults;
        }

        /// <summary>
        /// A function that returns a trick for a certain jump.
        /// </summary>
        /// <param name="jumpNo"></param>
        /// <param name="name"></param>
        public string GetTrick(int jumpNo)
        {
            return jumpResults[jumpNo].TrickName;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Calculates points for every jump result.
        /// </summary>
        public void CalculatePoints()
        {
            foreach (var jumpResult in jumpResults)
            {
                jumpResult.CalculateResult();
            }
        }

        /// <summary>
        /// Updates the total point for every jump result.
        /// TODO: nu får ju alla jump samma difficulity, borde man inte kunna ha olika?
        /// </summary>
        /// <param name="jumpDifficulty"></param>
        public void UpdateTotalPoints(double jumpDifficulty)
        {
            foreach (var jumpResult in jumpResults.Where(x => x.SumJudgePoints >= 0.0))
            {
                totalPoints += jumpResult.SumJudgePoints * jumpDifficulty;
            }
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

