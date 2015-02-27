using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;



namespace WindowsApplication1
{
   [Serializable]
    public class someClass
    {
        public string Name { get;  set; }
        public string Jump { get;  set; }

        public int Point { get;  set; }

        public someClass() { }
       public someClass(string name, string jump, int point) 
        {
            this.Name = name;
            this.Jump = jump;
            this.Point = point;
        }

    }
}
