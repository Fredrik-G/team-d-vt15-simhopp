using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    public class TrickList
    {
        /// <summary>
        /// A Hashtable that contains an trickname as key and its difficulty as the value.
        /// </summary>
        private Hashtable trickList = new Hashtable();

        /// <summary>
        /// Default constructor. Size 127 cause of the number of tricks is 58. 58x2=116 --> closest upward prime 127. 
        /// </summary>
        public TrickList() 
        {
            
        }

        /// <summary>
        /// Checks if the trickDictionary is empty and returns a boolean value.
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return (trickList.Count == 0);
        }

        /// <summary>
        /// Adds a trick with an id to the trickDictionary.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="t"></param>
        public void AddTrick(Trick t)
        {
            try
            {
                trickList.Add(t.Name, t.Difficulty);
            }
            catch
            {
                Console.WriteLine("Error: Trick already in hashtable tricksList.");
            }
        }

        /// <summary>
        /// Reads trick information from a file (filename).
        /// For each trick in the file it creates a trick object and stores it in the trickList.
        /// </summary>
        /// <param name="filename"></param>
        public void ReadFromFile(string filename)
        {
            try
            {
                trickList.Clear();
                string[] allTricks = System.IO.File.ReadAllLines(filename);
                foreach (string line in allTricks)
                {
                    string[] trick = line.Split(';');
                    Trick t = new Trick(trick[1], double.Parse(trick[2]));
                    AddTrick(t);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: File could not be opened.");
            }
        }
        /// <summary>
        /// Searches the trickList for a specific trick and then returns the tricks difficulty
        /// </summary>
        /// <param name="trickName"></param>
        /// <returns></returns>
        public double GetDifficultyByName(string trickName)
        {
            try
            {
                return (double)trickList[trickName];
            }
            catch(Exception e)
            {
                Console.WriteLine("Not found"); 
                return 0.0;
            }
           
        }
        /// <summary>
        /// Prints the entire hashtable in the Console window
        /// </summary>
        public void PrintHashTable()
        {
            foreach(DictionaryEntry de in trickList)
            {
                Console.WriteLine(de.Key + "\t" + de.Value);
            }
        }

        //TODO:
        /* print funtion
         */
    }
}