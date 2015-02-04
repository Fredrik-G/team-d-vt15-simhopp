using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace Simhopp
{
    class SimhoppConsole
    {
        #region Data
        List<Judge> judgeList = new List<Judge>();
        List<Diver> diverList = new List<Diver>();

        private Contest contest = new Contest();

        private string input;
        #endregion

        #region Methods
        public void Meny()
        {
            Console.Title = "Simhopp";
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("#########################################");
                Console.WriteLine("#\tMake your choice\t\t#");
                Console.WriteLine("#\t1: Read divers from textfile\t#");
                Console.WriteLine("#\t2: Read judges from textfile\t#");
                Console.WriteLine("#\t3: Add judge to contest\t\t#");
                Console.WriteLine("#\t4: Add diver to contest\t\t#");
                Console.WriteLine("#\t5: Make jump in contest\t\t#");
                Console.WriteLine("#\t6: Print all judges\t\t#");
                Console.WriteLine("#\t7: Print all divers\t\t#");
                Console.WriteLine("#\t99: Exit the program\t\t#");
                Console.WriteLine("#########################################");
                Console.Write(":");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        diverList.Clear();
                        ReadFromFile("diver.txt");
                        Console.WriteLine("Added " + diverList.Count + " divers to list.");
                        Console.ReadKey();
                        break;
                    case "2":
                        judgeList.Clear();
                        ReadFromFile("judge.txt");
                        Console.WriteLine("Added " + judgeList.Count + " judges to list.");
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Write("Name of judge: ");
                        AddJudgeByName(Console.ReadLine());
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.Write("Name of diver: ");
                        AddDiverByName(Console.ReadLine());
                        Console.ReadKey();
                        break;
                    case "5":
                        MakeJump();
                        break;
                    case "6":
                        PrintJudges();
                        Console.ReadKey();
                        break;
                    case "7":
                        PrintDivers();
                        Console.ReadKey();
                        break;

                    case "99":
                        return;

                    default:
                        break;
                }
            }
        }

        public void PrintJudges()
        {
            foreach (var judge in judgeList)
            {
                Console.WriteLine(judge.Name + " " + judge.Nationality);
            }
        }
        public void PrintDivers()
        {
            foreach (var diver in diverList)
            {
                Console.WriteLine(diver.Name + " " + diver.Nationality);
            }
        }
        public Judge GetJudgeByName(string name)
        {
            return judgeList.Find(x => x.Name == name);
        }
        public Diver GetDiverByName(string name)
        {
            return diverList.Find(x => x.Name == name);
        }
        public void AddJudgeByName(string name)
        {
            var judge = GetJudgeByName(name);
            if (judge != null)
            {
                //if(name not found in contest)
                    contest.AddJudge(judge);
                    Console.WriteLine("Successfully added " + name);
                //else lägg inte till
            }
            else
            {
                Console.WriteLine(name + " was not found");
            }
        }
        public void AddDiverByName(string name)
        {
            var diver = GetJudgeByName(name);
            if (diver != null)
            {
                //if(name not found in contest)
                    contest.AddJudge(diver);
                    Console.WriteLine("Successfully added " + name);
                //else lägg inte till
            }
            else
            {
                Console.WriteLine(name + " was not found");
            }
        }
        public void AddJudge()
        {
            Random random = new Random();
            for (var i = 0; i < 7; i++)
            {
                int randomNumber = random.Next(0, judgeList.Count);
                contest.AddJudge(judgeList[randomNumber]);
                judgeList.Remove(judgeList[randomNumber]);
            }
        }
        public void AddDiver()
        {
            Random random = new Random();
            for (var i = 0; i < 3; i++)
            {
                int randomNumber = random.Next(0, diverList.Count);
                contest.AddParticipant(diverList[randomNumber]);
                diverList.Remove(diverList[randomNumber]);
            }
        }

        public void MakeJump()
        {
            contest.MakeJump();
        }
        public void ReadFromFile(string fileName)
        {
            try
            {
                using (StreamReader reader = new StreamReader(@"M:\Desktop\år2\SystemProgramvaruutveckling\Simhopp\Simhopp\" + fileName))
                {
                    List<string> text = new List<string>();
                    while (!reader.EndOfStream)
                    {
                        text.Add(reader.ReadLine());
                    }
                    foreach (var line in text)
                    {
                        string[] temp = line.Split(';');

                        if (fileName == "judge.txt")
                        {
                            Judge judge = new Judge(temp[0], temp[1], temp[2]);
                            judgeList.Add(judge);
                        }
                        else if (fileName == "diver.txt")
                        {
                            Diver diver = new Diver(temp[0], temp[1], temp[2]);
                            diverList.Add(diver);
                        }
                        else
                        {
                            throw new IOException("File not found");
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Error when reading file " + fileName + "\n" + e.Message);
            }
        }
        #endregion
    }
}
