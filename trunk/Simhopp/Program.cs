using Simhopp.Model;

namespace Simhopp
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseController database = new DatabaseController(@"M:/Desktop/simhoppTestDB.db");
            database.ConnectToDatabase();
            database.ClearDatabase("Judge");

            for (var i = 0; i < 10; i++)
            {
                database.AddJudgeToDatabase(new Judge("kalle", "USA", "123-22-666" + i));   
            }
            

            SimhoppConsole simhopp = new SimhoppConsole();
            simhopp.Meny();
            
        }
    }
}