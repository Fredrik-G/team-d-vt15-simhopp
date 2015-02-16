using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimhoppGUI.Model;

namespace SimhoppGUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Contest.CheckCorrectDate("01/01/2010"));
            Console.WriteLine(Contest.CheckCorrectDate("40/01/2010"));
            Console.WriteLine(Contest.CheckCorrectDate("01/15/2010"));
            Console.WriteLine(Contest.CheckCorrectDate("01/01/201"));
            Console.WriteLine(Contest.CheckCorrectName("Jerusalem-VM"));
            Console.WriteLine(Contest.CheckCorrectPlace("Jerusalem-VM"));
            Console.Read();
            SimhoppConsole simhopp = new SimhoppConsole();
            simhopp.Meny();
            
        }
    }
}