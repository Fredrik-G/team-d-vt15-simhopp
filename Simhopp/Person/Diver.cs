using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace Simhopp
{
    public class Diver : Person
    {
        public Diver(string name, string nationality, string ssn)
        {
            this.name = name;
            this.nationality = nationality;
            this.ssn = ssn;
        }
        public bool CheckCorrectName(string name)
        {
            Regex patternName = new Regex(@"^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*$");
            return patternName.IsMatch(name);
        }
        public bool CheckCorrectNationality(string nationality)
        {
            Regex patternNationality = new Regex(@"^[a-zA-Z]+(([\,\- ][a-zA-Z ])?)*$");
            return patternNationality.IsMatch(nationality);
        }
        public bool CheckCorrectSSN(string ssn)
        {
            if (this.nationality == "Sweden")
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
    }
}
