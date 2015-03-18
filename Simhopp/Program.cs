using System.Net.Sockets;
using log4net.Config;
using Simhopp.Model;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;
[assembly: XmlConfigurator(Watch = true)]

namespace Simhopp
{
    class Program
    {
        private static void FillDatabase()
        {
            var database = new DatabaseController(@"C:/temp/Simhopp/Simhopp/simhoppTestDB.db");
            database.ConnectToDatabase();

            database.ClearDatabase("Judge");

            //for (var i = 0; i < 10; i++)
            //{
            //    database.AddContestToDatabase(new Contest("Stockholm", "Simhopp", i + "-10-2010", "11-11-2011") {IsFinished = true});
            //}

            for (var i = 0; i < 10; i++)
            {
                var judge = new Judge("kalle", "USA", "555-55-000" + i, "password" + i);

                database.AddJudgeToDatabase(judge);
                database.UpdateJudgeWithHash(judge);

                database.AddDiverToDatabase(new Diver("kalle", "finland", "123-22-123" + i));
            }
        }
        static void Main(string[] args)
        {
            //FillDatabase();

           // var simhopp = new Simhopp();
           // simhopp.ReadTricksFroMDatabase();
            
          //  var asd = new TcpClient();

            //var asd = new Client();
            TcpClient tcpclnt = new TcpClient();
            var console = new SimhoppConsole();
            console.Meny();
        }
    }
}