namespace Simhopp.Model
{
    /// <summary>
    /// Class that inherits from person class and holds information about a diver.
    /// </summary>
    public class Diver : Person
    {
        #region Constructors

        /// <summary>
        /// A default constructor without parameters
        /// </summary>
        public Diver()
        {
            this.id = -1;
            this.name = "";
            this.nationality = "";
            this.ssn = "";
        }

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="nationality"></param>
        /// <param name="ssn"></param>
        public Diver(string name, string nationality, string ssn)
        {
            this.id = -1;
            this.name = name;
            this.nationality = nationality;
            this.ssn = ssn;
        }

        /// <summary>
        /// Constructor with parameters.
        /// Should only be used by databascontroller.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="nationality"></param>
        /// <param name="ssn"></param>
        public Diver(int id, string name, string nationality, string ssn)
        {
            this.id = id;
            this.name = name;
            this.nationality = nationality;
            this.ssn = ssn;
        }

        #endregion
    }
}
