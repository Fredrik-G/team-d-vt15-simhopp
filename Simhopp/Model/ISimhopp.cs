using System.ComponentModel;

namespace Simhopp.Model
{
    /// <summary>
    /// Interface-class for simhopp
    /// </summary>
    public interface ISimhopp
    {
        void CreateContest(string place, string name, string startDate, string endDate);
        void ReadFromFile(string fileName);
        void ReadJudgesFromDatabase();
        void ReadDiversFromDatabase();

        void ReadTricksFromDatabase();

        BindingList<Contest> GetContestsList();
        BindingList<Judge> GetJudgesList();
        BindingList<Diver> GetDiversList();

        BindingList<Judge> GetJudgesInContest(int id);
        BindingList<Diver> GetDiversInContest(int id);

        BindingList<Trick> GetTrickList();

        string GetJudgeHash(string ssn);
        string GetJudgeSalt(string ssn);

        void AddJudgeToList(string name, string nationality, string ssn);
        void AddDiverToList(string name, string nationality, string ssn);
        void AddJudgeToContest(int contestId, string ssn);
        void AddDiverToContest(int contestId, string ssn);

        void RemoveJudgeFromList(string ssn);
        void RemoveDiverFromList(string ssn);

        void RemoveJudgeFromContest(int contestId, string ssn);
        void RemoveDiverFromContest(int contestId, string ssn);

        void UpdateContest(int id, string name, string place, string startDate, string endDate);
        void UpdateJudge(int id, string name, string nationality, string ssn);
        void UpdateDiver(int id, string name, string nationality, string ssn);
    }
}
