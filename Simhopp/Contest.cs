using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;


namespace Simhopp
{
    public class Contest
    {
        private string place;
        private string name;
        private string date;

        Contest() { }

        public Contest(string place, string name, string date)
        {
            this.place = place;
            this.name = name;
            this.date = date;
        }

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
        public string Place
        {
            get
            {
                if (this.place == null)
                {
                    throw new Exception("Place is null");
                }
                return this.place;
            }
            set
            {
                this.place = value;
            }
        }
        public string Date
        {
            get
            {
                if (this.date == null)
                {
                    throw new Exception("Date is null");
                }
                return this.date;
            }
            set
            {
                this.date = value;
            }
        }

        public bool CheckCorrectName(string name)
        {
            Regex patternName = new Regex(@"^[a-zA-Z]+(([\'\.\- ][a-zA-Z ])?[a-zA-Z]*)*$");
            return patternName.IsMatch(name);
        }

        public bool CheckCorrectPlace(string place)
        {
            Regex patternName = new Regex(@"^[a-zA-Z]+(([\'\.\- ][a-zA-Z ])?[a-zA-Z]*)*$");
            return patternName.IsMatch(place);
        }

        public bool CheckCorrectDate(string date)
        {
            Regex patternName = new Regex(@"^((((0[13578])|([13578])|(1[02]))[\/](([1-9])|([0-2][0-9])|(3[01])))|(((0[469])|([469])|(11))[\/](([1-9])|([0-2][0-9])|(30)))|((2|02)[\/](([1-9])|([0-2][0-9]))))[\/]\d{4}$|^\d{4}$");
            return patternName.IsMatch(date);
        }



    }
}
