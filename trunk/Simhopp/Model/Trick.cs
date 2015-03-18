namespace Simhopp.Model
{
    /// <summary>
    /// Class that holds information about a trick (name and difficulty).
    /// </summary>
    public class Trick
    {
        #region Data

        private int id;
        private string name;
        private double difficulty;
        #endregion

        #region Constructors
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Trick()
        {
            this.id = -1;
            this.name = "";
            this.difficulty = 0.0;
        }
        /// <summary>
        /// Creating an object with varibles 'name' and 'difficulty'
        /// </summary>
        /// <param name="name"></param>
        /// <param name="difficulty"></param>
        public Trick(string name, double difficulty)
        {
            this.name = name;
            this.difficulty = difficulty;
        }

        /// <summary>
        /// Creating an object with varibles 'id', 'name' and 'difficulty'
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="difficulty"></param>
        public Trick(int id, string name, double difficulty)
        {
            this.id = id;
            this.name = name;
            this.difficulty = difficulty;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Getter/Setter for id value.
        /// </summary>
        public int Id
        {
            get { return id; }
            set { this.id = value; }
        }

        /// <summary>
        /// Getter/Setter for name value.
        /// </summary>
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
        /// <summary>
        /// Getter/Setter for difficulty value.
        /// </summary>
        public double Difficulty
        {
            get 
            {
                return this.difficulty; 
            }
            set
            {
                this.difficulty = value;
            }
        }


        #endregion
    }
}
