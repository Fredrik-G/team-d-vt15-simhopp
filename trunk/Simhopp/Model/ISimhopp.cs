using System.ComponentModel;

namespace Simhopp.Model
{
    /// <summary>
    /// Interface-class for simhopp
    /// </summary>
    public interface ISimhopp
    {
        void CreateContest(string place, string name, string startDate, string endDate);
        void SetJudgePoint(int contestId, string judgeSsn, string diverSsn, double point, int jumpNo);

        #region Read methods

        void ReadFromFile(string fileName);
        void ReadJudgesFromDatabase();
        void ReadDiversFromDatabase();
        void ReadContestsFromDatabase();
        void ReadTricksFromDatabase();

        #endregion

        #region Getters

        BindingList<Contest> GetContestsList();
        Contest GetContest(int id);

        BindingList<Judge> GetJudgesList();
        BindingList<Diver> GetDiversList();

        BindingList<Judge> GetJudgesInContest(int id);
        BindingList<Diver> GetDiversInContest(int id);

        BindingList<Trick> GetTrickList();
        string GetTrickFromParticipant(int contestId, int trickNo, string ssn);

        string GetJudgeHash(string ssn);
        string GetJudgeSalt(string ssn);

        #endregion

        #region Add methods

        void AddJudgeToList(string name, string nationality, string ssn, string password = "password");
        void AddDiverToList(string name, string nationality, string ssn);
        void AddJudgeToContest(int contestId, string ssn);
        void AddDiverToContest(int contestId, string ssn);
        void AddTrickToParticipant(int contestId, int trickNo, string trickName, string ssn);

        #endregion

        #region Remove methods

        void RemoveJudgeFromList(string ssn);
        void RemoveDiverFromList(string ssn);

        void RemoveJudgeFromContest(int contestId, string ssn);
        void RemoveDiverFromContest(int contestId, string ssn);

        #endregion

        #region Update methods

        void UpdateContest(int id, string name, string place, string startDate, string endDate);
        void UpdateJudge(int id, string name, string nationality, string ssn);
        void UpdateDiver(int id, string name, string nationality, string ssn);

        #endregion

        #region Server methods

        void HandleMessage();
        void SetDiverMessage(string contestName, string diverName, string trickName, double trickDifficulty);
        void SendDataToClient();
        ClientObjectData GetFirstClientObjectData();
        string GetIPForServer();

        void StartServer();

        #endregion
    }
}
