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
        }

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="nationality"></param>
        /// <param name="ssn"></param>
        public Diver(string name, string nationality, string ssn) 
            : base(name, nationality, ssn)
        {
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
            : base(id, name, nationality, ssn)
        {
        }

        #endregion
    }
}
