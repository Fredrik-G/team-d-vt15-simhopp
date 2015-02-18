using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace Simhopp.Model
{
    /// <summary>
    /// Class that inherits from person class and holds information about a diver.
    /// </summary>
    public class Diver : Person
    {
        /// <summary>
        /// A default constructor without parameters
        /// </summary>
        public Diver()
        {
            this.name = "";
            this.nationality = "";
            this.ssn = "";
        }
        /// <summary>
        /// A constructor that do take paramteters
        /// </summary>
        /// <param name="name"></param>
        /// <param name="nationality"></param>
        /// <param name="ssn"></param>
        public Diver(string name, string nationality, string ssn)
        {
            this.name = name;
            this.nationality = nationality;
            this.ssn = ssn;
        }
    }
}
