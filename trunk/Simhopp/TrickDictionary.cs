using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    public class TrickDictionary
    {
        /// <summary>
        /// A dictionary that contains an id and a Trick object.
        /// </summary>
        private Dictionary<int, Trick> trickDictionary = new Dictionary<int,Trick>();

        /// <summary>
        /// Default constructor.
        /// </summary>
        public TrickDictionary() {}

        /// <summary>
        /// Checks if the trickDictionary is empty and returns a boolean value.
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return (trickDictionary.Count == 0);
        }

        /// <summary>
        /// Adds a trick with an id to the trickDictionary.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="t"></param>
        public void AddTrick(int id, Trick t)
        {
            trickDictionary.Add(id, t);
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