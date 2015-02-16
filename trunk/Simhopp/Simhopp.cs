using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using Simhopp.Model;

namespace Simhopp
{
    /// <summary>
    /// Class that creates and handles a contest-object
    /// </summary>
    public class Simhopp : ISimhopp
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

        BindingList<Contest> contestList = new BindingList<Contest>();

        #endregion
     
        #region Methods
        /// <summary>
        /// Returns contests list.
        /// </summary>
        /// <returns></returns>
        public BindingList<Contest> GetContestsList()
        {
            return contestList;
        }
        /// <summary>
        /// 
        /// </summary>
        public void CreateContest(string place, string name, string startDate, string endDate)//, string endDate)
        {
            if (!Contest.CheckCorrectName(name))
            {
                throw new InvalidDataException("contest name is not set or invalid.");
            }
            else if (!Contest.CheckCorrectPlace(place))
            {
                throw new InvalidDataException("contest place is not set or invalid.");
            }
            else if (!Contest.CheckCorrectDate(startDate))
            {
                throw new InvalidDataException("contest date is not set or invalid.");
            }
            else if (!Contest.CheckCorrectDate(endDate))
            {
                throw new InvalidDataException("contest date is not set or invalid.");
            }
            else
            {
                contestList.Add(new Contest(place, name, startDate, endDate));
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
            //var judge = GetJudgeByName(name);
            //if (judge == null)
            //{
            //    Console.WriteLine(name + " was not found");
            //    return;
            //}
            //try
            //{
            //    contest.AddJudge(judge);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //    Console.ReadKey();
            //}
        }
        /// <summary>
        /// A function that adds a diver to a contest-object
        /// </summary>
        /// <param name="name"></param>
        public void AddDiverByName(string name)
        {
            //var diver = GetDiverByName(name);
            //if (diver == null)
            //{
            //    Console.WriteLine(name + " was not found");
            //    return;
            //}
            //try
            //{
            //    contest.AddParticipant(diver);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //    Console.ReadKey();
            //}
        }
        /// <summary>
        /// A function that reads judges and divers from text files
        /// </summary>
        /// <param name="fileName"></param>
        public void ReadFromFile(string fileName)
        {
            try
            {
                using (StreamReader reader = new StreamReader(@"Model\Files\" + fileName))
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
