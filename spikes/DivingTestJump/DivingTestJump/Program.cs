using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivingTestJump
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hej");

            double difficulty = 2.5d;
            List<double> judgeScore = new List<double>();

            for (var i = 1; i < 8; i++)
            {
                judgeScore.Add(i);
            }

            judgeScore.Remove(judgeScore.Max());
            judgeScore.Remove(judgeScore.Min());

            double sum = 0.0d;
            for (var i = 0; i < 5; i++)
            {
                sum += judgeScore[i];
            }

            sum /= 5;
            //sum *= Trick.difficulty;
            sum *= difficulty;

            Console.WriteLine("kalle fick" + sum + " .");

            Console.Read();
        }
    }
}
