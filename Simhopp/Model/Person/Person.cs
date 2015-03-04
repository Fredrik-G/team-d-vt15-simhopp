using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace Simhopp.Model
{
    /// <summary>
    /// Abstract class that is used for inherit properties from a person.
    /// </summary>
    public abstract class Person
    {
        #region Data
        protected int id;
        protected string name;
        protected string nationality;
        protected string ssn;
        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Person()
        {
            this.id = -1;
            this.name = "";
            this.nationality = "";
            this.ssn = "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="nationality"></param>
        /// <param name="ssn"></param>
        protected Person(string name, string nationality, string ssn)
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
        public Person(int id, string name, string nationality, string ssn)
        {
            this.id = id;
            this.name = name;
            this.nationality = nationality;
            this.ssn = ssn;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Property for person id.
        /// </summary>
        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        /// <summary>
        /// Property for person name.
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
        /// Property for person nationality.
        /// </summary>
        public string Nationality
        {
            get
            {
                return this.nationality;
            }
            set
            {
                this.nationality = value;
            }
        }
        /// <summary>
        /// Property for person social security number.
        /// </summary>
        public string SSN
        {
            get
            {
                return this.ssn;
            }
            set
            {
                this.ssn = value;
            }
        }
        #endregion
       
        #region Check correct input

        /// <summary>
        /// Allowed characters: "A-Z ',.-"
        /// "Jimmy Makkonen", "J. Makkonen"
        /// </summary>
        /// <param name="name"></param>
        /// <returns>returns true or false</returns>
        public static bool CheckCorrectName(string name)
        {
            var patternName = new Regex(@"^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*$");
            return patternName.IsMatch(name);
        }

        /// <summary>
        /// Allowed characters: "A-Z ,-"
        /// "Sweden", "USA"
        /// </summary>
        /// <param name="nationality"></param>
        /// <returns>returns true or false</returns>
        public static bool CheckCorrectNationality(string nationality)
        {
            var patternNationality = new Regex(@"^[a-zA-Z]+(([\,\- ][a-zA-Z ])?)*$");
            return patternNationality.IsMatch(nationality);
        }

        /// <summary>
        /// Allowed characters: "1-9 -"
        /// Swedish: yyyymmdd-xxxx
        /// Rest: xxx-yy-zzzz
        /// </summary>
        /// <param name="ssn"></param>
        /// <param name="nationality"></param>
        /// <returns>returns true or false</returns>
        public static bool CheckCorrectSSN(string ssn, string nationality)
        {
            if (nationality == "Sweden")
            {
                var patternSwedishSSN = new Regex(@"^\d{8}-\d{4}$");
                return patternSwedishSSN.IsMatch(ssn);
            }
            else
            {
                var patternSSN = new Regex(@"^\d{3}-\d{2}-\d{4}$");
                return patternSSN.IsMatch(ssn);
            }
        }
        #endregion
    }
}
