using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimhoppGUI.View
{
    public delegate void DelegateCreateContest(string place, string name, string startDate);
    //public delegate void DelegateAddParticipant(Diver diver);
    //public delegate void DelegateAddJudge(Judge judge);
    //public delegate double DelegateGetTrickDifficultyFromTrickHashTable(string trickName);
    //public delegate double DelegateGetResultFromParticipant(string ssn);
    public interface IStartScreen
    {
        event DelegateCreateContest EventCreateContest;
        //event DelegateAddParticipant EventAddParticipant;
        //event DelegateAddJudge EventAddJudge;
        //event DelegateGetTrickDifficultyFromTrickHashTable EventGetTrickDifficultyFromTrickHashTable;
        //event DelegateGetResultFromParticipant EventGetResultFromParticipant;
    }
}
