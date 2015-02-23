﻿using System;
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
    public class Judge : Person
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Judge()
        {
            this.id = -1;
            this.name = "";
            this.nationality = "";
            this.ssn = "";
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="nationality"></param>
        /// <param name="ssn"></param>
        public Judge(string name, string nationality, string ssn)
        {
            this.id = -1;
            this.name = name;
            this.nationality = nationality;
            this.ssn = ssn;
        }

        public Judge(int id, string name, string nationality, string ssn)
        {
            this.id = id;
            this.name = name;
            this.nationality = nationality;
            this.ssn = ssn;
        }
    }
}
