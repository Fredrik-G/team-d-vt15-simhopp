using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    class Participant
    {
        private double totalPoints = 0.0;
        Diver diver = new Diver();
        //private JumpResultat[] jumpResultats = new JumpResultat[3];

        public double TotalPoints
        {
            get
            {
                if (this.totalPoints == null)
                {
                    throw new Exception("totalPoints is null");
                }
                return this.totalPoints;
            }
            set
            {
                this.totalPoints = value;
            }      
        }


        private void AddDiver(Diver diver)
        {
            this.diver = diver;
        }

        private void UpdatePoints()
        {
            //jumpResultats.CalculateResult();
        }

    }
}
