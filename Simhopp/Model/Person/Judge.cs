using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace Simhopp.Model
{
    public class Judge : Person
    {
        public Judge()
        {
            this.name = "";
            this.nationality = "";
            this.ssn = "";
        }

        public Judge(string name, string nationality, string ssn)
        {
            this.name = name;
            this.nationality = nationality;
            this.ssn = ssn;
        }
    }
}
