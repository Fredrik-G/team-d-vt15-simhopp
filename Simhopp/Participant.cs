using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    public class Participant
    {
        private double totalPoints = 0.0;
        Diver diver = new Diver();
        private JumpResult[] jumpResults = new JumpResult[3];

        public Participant(Diver diver)
        {
            for (var i = 0; i < 3; i++)
            {
                jumpResults[i] = new JumpResult();
            }
            
            this.diver = diver;
        }

        public void SetJudgePoint(int jumpNo, int judgeNo, double point)
        {
            jumpResults[jumpNo].SetJudgePoint(judgeNo, point);
        }

        public void SetTrick(int jumpNo, string name)
        {
            jumpResults[jumpNo].TrickName = name;
        }

        public void CalculatePoints()
        {
            foreach (var jumpResult in jumpResults)
            {
                jumpResult.CalculateResult();
            }
        }
        public double TotalPoints
        {
            get
            {
                if (Double.IsNaN(this.totalPoints))
                {
                    throw new Exception("totalPoints is NaN");
                }
                return this.totalPoints;
            }
            set
            {
                this.totalPoints = value;
            }      
        }

        public void AddDiver(Diver diver)
        {
            this.diver = diver;
        }

        public void UpdatePoints()
        {
            foreach (var jumpResult in jumpResults)
            {
                jumpResult.CalculateResult();
            }        
        }

    }
}
