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
        public Diver() { }

        public Diver(string name, string nationality, string ssn)
        {
            this.name = name;
            this.nationality = nationality;
            this.ssn = ssn;
        }
    }
}
