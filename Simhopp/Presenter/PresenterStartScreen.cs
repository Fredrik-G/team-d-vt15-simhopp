using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Simhopp.Model;
using Simhopp;
using Simhopp.View;

namespace Simhopp.Presenter
{
    public class PresenterStartScreen
    {
        #region Properties
        public IStartScreen View { get; set; }
        public ISimhopp Model { get; set; }

        #endregion

        public PresenterStartScreen(IStartScreen view, Simhopp simhopp)
        {
            this.Model = simhopp;
            this.View = view;
            this.View.EventCreateContest += CreateContest;
            this.View.EventGetContestsList += GetContestsList;
            this.View.EventGetContest += GetContest;
            this.View.EventGetJudgesList += GetJudgesList;
            this.View.EventGetDiversList += GetDiversList;
            this.View.EventReadFromFile += ReadFromFile;
            this.View.EventAddJudgeToList += AddJudgeToList;
            this.View.EventAddDiverToList += AddDiverToList;
            this.View.EventRemoveJudgeFromList += RemoveJudgeFromList;
            this.View.EventRemoveDiverFromList += RemoveDiverFromList;
            this.View.EventGetJudgesInContest += GetJudgesInContest;
            this.View.EventGetDiversInContest += GetDiversInContest;
            this.View.EventAddJudgeToContest += AddJudgeToContest;
            this.View.EventAddDiverToContest += AddDiverToContest;
            this.View.EventRemoveJudgeFromContest += RemoveJudgeFromContest;
            this.View.EventRemoveDiverFromContest += RemoveDiverFromContest;
            this.View.EventReadJudgesFromDatabase += ReadJudgesFromDatabase;
            this.View.EventReadDiversFromDatabase += ReadDiversFromDatabase;
            this.View.EventUpdateJudge += UpdateJudge;
            this.View.EventGetJudgeHash += GetJudgeHash;
            this.View.EventGetJudgeSalt += GetJudgeSalt;
            this.View.EventUpdateContest += UpdateContest;
            this.View.EventReadTricksFromDatabase += ReadTricksFromDatabase;
            this.View.EventGetTrickList += GetTrickList;
            this.View.EventUpdateDiver += UpdateDiver;

            this.View.EventHandleMessage += HandleMessage;
            this.View.EventGetFirstClientObjectData += GetFirstClientObjectData;
            this.View.EventStartServer += StartServer;
            this.View.EventSendDataToClient += SendDataToClient;
            this.View.EventSetDiverMessage += SetDiverMessage;
            this.View.EventGetIPForServer += GetIPForServer;

            this.View.EventReadContestsFromDatabase += ReadContestsFromDatabase;
            this.View.EventAddTrickToParticipant += AddTrickToParticipant;
            this.View.EventGetTrickFromParticipant += GetTrickFromParticipant;
            this.View.EventSetJudgePoint += SetJudgePoint;


            //this.View.EventAddParticipant += AddParticipant;
            //this.View.EventAddJudge += AddJudge;
            //this.View.EventGetTrickDifficultyFromTrickHashTable += GetTrickDifficultyFromTrickHashTable;
            //this.View.EventGetResultFromParticipant += GetResultFromParticipant;
        }

        #region Getters
        public BindingList<Contest> GetContestsList()
        {
            return this.Model.GetContestsList();
        }

        public Contest GetContest(int id)
        {
            return this.Model.GetContest(id);
        }

        public BindingList<Judge> GetJudgesList()
        {

            return this.Model.GetJudgesList();
        }

        public BindingList<Diver> GetDiversList()
        {
            return this.Model.GetDiversList();
        }

        public BindingList<Judge> GetJudgesInContest(int id)
        {
            return this.Model.GetJudgesInContest(id);
        }
        public BindingList<Diver> GetDiversInContest(int id)
        {
            return this.Model.GetDiversInContest(id);
        }

        public string GetJudgeHash(string ssn)
        {
            return this.Model.GetJudgeHash(ssn);
        }

        public string GetJudgeSalt(string ssn)
        {
            return this.Model.GetJudgeSalt(ssn);
        }

        public string GetTrickFromParticipant(int contestId, int trickNo, string ssn)
        {
            return this.Model.GetTrickFromParticipant(contestId, trickNo, ssn);
        }
        #endregion

        public void CreateContest(string place, string name, string startDate, string endDate)
        {
            this.Model.CreateContest(place, name, startDate, endDate);
        }

        public void SetJudgePoint(int contestId, string judgeSsn, string diverSsn, double point, int jumpNo)
        {
            this.Model.SetJudgePoint(contestId, judgeSsn, diverSsn, point, jumpNo);
        }

        #region Read methods

        public void ReadFromFile(string fileName)
        {
            this.Model.ReadFromFile(fileName);
        }

        public void ReadJudgesFromDatabase()
        {
            this.Model.ReadJudgesFromDatabase();
        }

        public void ReadDiversFromDatabase()
        {
            this.Model.ReadDiversFromDatabase();
        }

        public void ReadTricksFromDatabase()
        {
            this.Model.ReadTricksFromDatabase();
        }

        public void ReadContestsFromDatabase()
        {
            this.Model.ReadContestsFromDatabase();
        }

        public BindingList<Trick> GetTrickList()
        {
            return this.Model.GetTrickList();
        }

        #endregion

        #region Add methods

        public void AddJudgeToList(string name, string nationality, string ssn, string password = "password")
        {
            this.Model.AddJudgeToList(name, nationality, ssn, password);
        }

        public void AddDiverToList(string name, string nationality, string ssn)
        {
            this.Model.AddDiverToList(name, nationality, ssn);
        }

        public void AddJudgeToContest(int contestId, string ssn)
        {
            this.Model.AddJudgeToContest(contestId, ssn);
        }

        public void AddDiverToContest(int contestId, string ssn)
        {
            this.Model.AddDiverToContest(contestId, ssn);
        }

        public void AddTrickToParticipant(int contestId, int trickNo, string trickName, string ssn)
        {
            this.Model.AddTrickToParticipant(contestId, trickNo, trickName, ssn);
        }

        #endregion

        #region Remove methods

        private void RemoveJudgeFromList(string ssn)
        {
            this.Model.RemoveJudgeFromList(ssn);
        }

        private void RemoveDiverFromList(string ssn)
        {
            this.Model.RemoveDiverFromList(ssn);
        }

        private void RemoveJudgeFromContest(int contestId, string ssn)
        {
            this.Model.RemoveJudgeFromContest(contestId, ssn);
        }

        private void RemoveDiverFromContest(int contestId, string ssn)
        {
            this.Model.RemoveDiverFromContest(contestId, ssn);
        }

        #endregion

        #region Update methods

        public void UpdateContest(int id, string name, string place, string startDate, string endDate)
        {
            this.Model.UpdateContest(id, name, place, startDate, endDate);
        }

        private void UpdateJudge(int id, string name, string nationality, string ssn)
        {
            this.Model.UpdateJudge(id, name, nationality, ssn);
        }

        private void UpdateDiver(int id, string name, string nationality, string ssn)
        {
            this.Model.UpdateDiver(id, name, nationality, ssn);
        }
        #endregion

        #region Server methods

        public void HandleMessage()
        {
            this.Model.HandleMessage();
        }

        public ClientObjectData GetFirstClientObjectData()
        {
            return this.Model.GetFirstClientObjectData();
        }

        public void StartServer()
        {
            this.Model.StartServer();
        }

        public void SetDiverMessage(string contestName, string diverName, string trickName, double trickDifficulty)
        {
            this.Model.SetDiverMessage(contestName, diverName, trickName, trickDifficulty);
        }

        public void SendDataToClient()
        {
            this.Model.SendDataToClient();
        }

        public string GetIPForServer()
        {
            return this.Model.GetIPForServer();
        }

        #endregion

    }
}
