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

        /// <summary>
        /// Default constructor.
        /// </summary>
        protected Person()
        {
            this.id = -1;
        }

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
        }

        /// <summary>
        /// Property for person name.
        /// </summary>
        public string Name
        {
            get
            {
                if (this.name == null)
                {
                    throw new Exception("Name is null");
                }
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
                if (this.nationality == null)
                {
                    throw new Exception("Nationality is null");
                }
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
                if (this.ssn == null)
                {
                    throw new Exception("Social security number is null");
                }
                return this.ssn;
            }
            set
            {
                this.ssn = value;
            }
        }
        #endregion

        /// <summary>
        /// Regex patterns for testing input data.
        /// </summary>
        #region Check correct input
        
        /// <summary>
        /// Allowed characters: "A-Z ',.-"
        /// "Jimmy Makkonen", "J. Makkonen"
        /// </summary>
        /// <param name="name"></param>
        /// <returns>returns true or false</returns>
        public static bool CheckCorrectName(string name)
        {
            Regex patternName = new Regex(@"^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*$");
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
            Regex patternNationality = new Regex(@"^[a-zA-Z]+(([\,\- ][a-zA-Z ])?)*$");
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
                Regex patternSwedishSSN = new Regex(@"^\d{8}-\d{4}$");
                return patternSwedishSSN.IsMatch(ssn);
            }
            else
            {
                Regex patternSSN = new Regex(@"^\d{3}-\d{2}-\d{4}$");
                return patternSSN.IsMatch(ssn);
            }
        }
        #endregion
    }



}

