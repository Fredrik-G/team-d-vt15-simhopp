using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimhoppGUI.Model
{
    /// <summary>
    /// Interface-class for simhopp
    /// </summary>
    public interface ISimhopp
    {
        //void AddParticipant(Diver diver);
        //void AddJudge(Judge judge);
        //double GetTrickDifficultyFromTrickHashTable(string trickName);
        //double GetResultFromParticipant(string ssn);
        //void CreateHtmlResultFile();
        void CreateContest(string place, string name, string startDate);
        BindingList<Contest> GetContestsList();
    }
}
