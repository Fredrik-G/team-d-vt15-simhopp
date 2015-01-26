using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    public class Trick
    {
        private string name;
        private double difficulty;
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Trick() 
        {
            this.name = "";
            this.difficulty = 0.0;
        }
        /// <summary>
        /// Creating an object with varibles 'name' and 'difficulty'
        /// </summary>
        /// <param name="name"></param>
        /// <param name="difficulty"></param>
        public Trick(string name, double difficulty)
        {
            this.name = name;
            this.difficulty = difficulty;
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public double Difficulty
        {
            get { return this.difficulty; }
            set { this.difficulty = value; }
        }
    }
}
