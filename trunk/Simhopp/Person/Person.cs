using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace Simhopp
{
    public abstract class Person
    {
        #region Data
        protected string name;
        protected string nationality;
        protected string ssn;
        #endregion

        protected Person() { }

        #region Properties
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

        #region Methods
        public static bool CheckCorrectName(string name)
        {
            Regex patternName = new Regex(@"^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*$");
            return patternName.IsMatch(name);
        }
        public static bool CheckCorrectNationality(string nationality)
        {
            Regex patternNationality = new Regex(@"^[a-zA-Z]+(([\,\- ][a-zA-Z ])?)*$");
            return patternNationality.IsMatch(nationality);
        }
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

