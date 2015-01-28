using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    public class Jump
    {
        List<Judge> judgeList = new List<Judge>();
        List<Diver> diverList = new List<Diver>();

        public Jump() { }

        public void Initilize()
        {
            ReadFromFile("judge.txt");
            ReadFromFile("diver.txt");
        }

        public void ReadFromFile(string fileName)
        {
            judgeList.Clear();
            diverList.Clear();
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
                            Simhopp.Judge judge = new Simhopp.Judge(temp[0], temp[1], temp[2]);
                            judgeList.Add(judge);
                        }
                        else if (fileName == "diver.txt")
                        {
                            Simhopp.Diver diver = new Simhopp.Diver(temp[0], temp[1], temp[2]);
                            diverList.Add(diver);
                        }
                    }
                }
            }
            catch (IOException e)
            {
                throw new Exception("Error when reading file");
            }
        }

        }

    }
