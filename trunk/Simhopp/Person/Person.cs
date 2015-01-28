using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Simhopp
{
    public abstract class Person
    {
        protected string name;
        protected string nationality;
        protected string ssn;

        protected Person() { }
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
        void CheckCorrectName(string name)
        {
            //Regex patternInteger = new Regex(@"^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*$");
        }
    }



}

