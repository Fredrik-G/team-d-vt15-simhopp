using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    public class TrickDictionary
    {
        private Dictionary<int, Trick> trickDictionary;
        public bool isEmpty()
        {
            return (trickDictionary.Count() == 0);
        }
    }
}
