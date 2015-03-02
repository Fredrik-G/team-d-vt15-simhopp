using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace Simhopp.Model
{
    /// <summary>
    /// Contains a tricklist (hashtable).
    /// </summary>
    public class TrickList
    {
        #region Data

        /// <summary>
        /// A Hashtable that contains an trickname as key and its difficulty as the value.
        /// </summary>
        private Hashtable trickList = new Hashtable();
        private BindingList<Trick> trickList2 = new BindingList<Trick>();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor. Size 127 cause of the number of tricks is 58. 58x2=116 --> closest upward prime 127. 
        /// </summary>
        public TrickList()
        {

        }

        #endregion

        #region Methods
        /// <summary>
        /// Checks if the trickDictionary is empty and returns a boolean value.
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            //return (trickList.Count == 0);
            return (trickList2.Count == 0);
        }

        public BindingList<Trick> GetTrickList()
        {
            return trickList2;          
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
                // trickList.Add(t.Name, t.Difficulty);
                trickList2.Add(t);
            }
            catch
            {
                Console.WriteLine("Error: Trick " + t.Name + " already in hashtable tricksList.");
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
                string[] allTricks = File.ReadAllLines(@"Model\Files\" + filename);
                foreach (string line in allTricks)
                {
                    string[] trick = line.Split(';');
                    Trick t = new Trick(trick[1], double.Parse(trick[2]));
                    AddTrick(t);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: File " + filename + " could not be opened.\n" + e.Message);
            }
        }

        /// <summary>
        /// Reads tricks from database and adds them to the tricklist.
        /// </summary>
        /// <param name="database"></param>
        public void ReadFromDatabase(DatabaseController database)
        {
            trickList2.Clear();
            trickList2 = database.GetTrickListFromDatabase();
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
                //return (double)trickList[trickName];
                return trickList2.SingleOrDefault(x => x.Name == trickName).Difficulty;
            }
            catch (Exception e)
            {
                Console.WriteLine("Trick " + trickName + " not found\n" + e.Message);
                return 0.0;
            }

        }

        /// <summary>
        /// Prints the entire hashtable in the Console window
        /// </summary>
        public void PrintHashTable()
        {
            foreach (DictionaryEntry de in trickList)
            {
                Console.WriteLine(de.Key + "\t" + de.Value);
            }
        }
        #endregion

        //TODO:
        /* print funtion
         */
    }
}