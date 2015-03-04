using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    [Serializable]
    public class ServerObjectData
    {
        public string ContestName { get; set; }
        public string DiverName { get; set; }
        public string TrickName { get; set; }
        public double TrickDiff { get; set; }
        public ServerObjectData() { }
        public ServerObjectData(string cName, string dName, string tName, double tDiff)
        {
            this.ContestName = cName;
            this.DiverName = dName;
            this.TrickName = tName;
            this.TrickDiff = tDiff;
        }
    };
    [Serializable]
    public class ClientObjectData
    {
        public string Ssn { get; set; }
        public double Point { get; set; }

        public ClientObjectData() { }

        public ClientObjectData(string ssn, double point)
        {
            this.Ssn = ssn;
            this.Point = point;
        }

    };
}
