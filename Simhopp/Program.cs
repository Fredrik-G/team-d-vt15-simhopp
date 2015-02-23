using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simhopp.Model;

namespace Simhopp
{
    class Program
    {
        static void Main(string[] args)
        {
            Simhopp asd = new Simhopp();
            asd.CreateContest("contestA", "asd", "11/11/2011", "11/11/2011");
            asd.CreateContest("contestB", "asd", "11/11/2011", "11/11/2011");
            asd.CreateContest("contestB", "asd", "11/11/2011", "11/11/2011");

            var a = asd.GetJudgesInContest("contestB");

            SimhoppConsole simhopp = new SimhoppConsole();
            simhopp.Meny();
            
        }
    }
}