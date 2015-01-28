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
        /// A dictionary that contains an id and a Trick object.
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
        public void ReadFromFile(string filename)
        {
            try
            {
                string[] allTricks = System.IO.File.ReadAllLines(filename);
                foreach (string line in allTricks)
                {
                    string[] trick = line.Split(';');
                    foreach(string value in trick)
                    {
                        Trick t = new Trick(value[1].ToString(), Convert.ToDouble(value[2]));
                        AddTrick(t);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Error: File could not be opened.");
            }
        }

        //TODO:
        /* print funtion
         * read from file.
         * get object by id
         * get object by name
         * 
         */
    }
}