using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace SimhoppGUI
{
    public class Diver : Person
    {
        /// <summary>
        /// A default constructor without parameters
        /// </summary>
        public Diver() { }
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
