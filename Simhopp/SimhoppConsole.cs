using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Simhopp
{
    class SimhoppConsole
    {
        List<Judge> judgeList = new List<Judge>();
        List<Diver> diverList = new List<Diver>();
        private Contest c = new Contest();

        private string input;

        public void Meny()
        {
            while (true)
            {
                Console.WriteLine("Make your choice");
                Console.WriteLine("1: Read divers from textfile");
                Console.WriteLine("2: Read judges from textfile");
                Console.WriteLine("99: Exit the program");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        diverList.Clear();
                        ReadFromFile("diver.txt");

                        break;
                    case "2":
                        judgeList.Clear();
                        ReadFromFile("judge.txt");

                        break;
                    case "99":
                        return;

                    default:
                        break;
                }
            }
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
                    }
                }
            }
            catch (IOException e)
            {
                throw new Exception("Error when reading file" + fileName);
            }
        }

    }


}
