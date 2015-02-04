using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace Simhopp
{
    /// <summary>
    /// Class that creates and handles a contest-object
    /// </summary>
    public class SimhoppConsole
    {
        #region Data
        /// <summary>
        /// A list that holds every judge that is stored in the database
        /// </summary>
        List<Judge> judgeList = new List<Judge>();
        /// <summary>
        /// A list that holds every Diver that is stored in the database
        /// </summary>
        List<Diver> diverList = new List<Diver>();

        private Contest contest = new Contest();

        private string input;
        #endregion

        #region Methods
        /// <summary>
        /// A menu that shows a list of choices that a user may choose from
        /// </summary>
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
        /// <summary>
        /// A function that print all judges in the judgelist on the screen
        /// </summary>
        public void PrintJudges()
        {
            foreach (var judge in judgeList)
            {
                Console.WriteLine(judge.Name + " " + judge.Nationality);
            }
        }
        /// <summary>
        /// A function that prints divers in the diverlist on the screen
        /// </summary>
        public void PrintDivers()
        {
            foreach (var diver in diverList)
            {
                Console.WriteLine(diver.Name + " " + diver.Nationality);
            }
        }
        /// <summary>
        /// A function that get a judge by its name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>returns a judge object</returns>
        public Judge GetJudgeByName(string name)
        {
            return judgeList.Find(x => x.Name == name);
        }
        /// <summary>
        /// A function that get a diver by its name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>returns a diver object</returns>
        public Diver GetDiverByName(string name)
        {
            return diverList.Find(x => x.Name == name);
        }
        /// <summary>
        /// A function that adds a judge to a contest-object
        /// </summary>
        /// <param name="name"></param>
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
        /// <summary>
        /// A function that adds a diver to a contest-object
        /// </summary>
        /// <param name="name"></param>
        public void AddDiverByName(string name)
        {
            var diver = GetJudgeByName(name);
            if (diver != null)
            {
                //if(name not found in contest)

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
        /// <summary>
        /// A function that reads judges and divers from text files
        /// </summary>
        /// <param name="fileName"></param>
        public void ReadFromFile(string fileName)
        {
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
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
