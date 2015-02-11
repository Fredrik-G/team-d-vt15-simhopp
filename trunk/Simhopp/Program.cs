using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    class Program
    {
        static void Main(string[] args)
        {
            //TrickList tl = new TrickList();
            //tl.ReadFromFile("TrickList.txt");
            //tl.PrintHashTable();

            SimhoppConsole simhopp = new SimhoppConsole();
            simhopp.Meny();

            Console.ReadKey();
        }
    }
}