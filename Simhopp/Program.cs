using log4net.Config;
using Simhopp.Model;

[assembly: XmlConfigurator(Watch = true)]

namespace Simhopp
{
    class Program
    {
        static void Main(string[] args)
        {          
            var database = new DatabaseController(@"M:/Desktop/simhoppTestDB.db");
            //database.ConnectToDatabase();
           
            //database.ClearDatabase("Judge");

            //for (var i = 0; i < 10; i++)
            //{
            //    var judge = new Judge("kalle", "USA", "123-22-666" + i);

            //    judge.CalculateSalt();
            //    judge.CalculateHash("password" + i);                

            //    database.AddJudgeToDatabase(judge);
            //    database.UpdateJudgeWithHash(judge);
            //}

            var simhopp = new SimhoppConsole();
            simhopp.Meny();
            
        }
    }
}