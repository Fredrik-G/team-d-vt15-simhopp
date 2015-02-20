using System.ComponentModel;

namespace Simhopp.Model
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
        void CreateContest(string place, string name, string startDate, string endDate);
        void ReadFromFile(string fileName);
        BindingList<Contest> GetContestsList();
        BindingList<Judge> GetJudgesList();
        BindingList<Diver> GetDiversList();

        void AddJudgeToList(string name, string nationality, string ssn);
        void AddDiverToList(string name, string nationality, string ssn);
        void RemoveJudgeFromList(string ssn);
        void RemoveDiverFromList(string ssn);
    }
}
