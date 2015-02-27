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
            this.View.EventUpdateJudge += UpdateJudge;
            this.View.EventGetJudgeHash += GetJudgeHash;
            this.View.EventGetJudgeSalt += GetJudgeSalt;
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
        #endregion

        #region Methods

        public void CreateContest(string place, string name, string startDate, string endDate)
        {
            this.Model.CreateContest(place, name, startDate, endDate);
        }

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
        public void AddJudgeToList(string name, string nationality, string ssn)
        {
            this.Model.AddJudgeToList(name, nationality, ssn);
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
        void RemoveJudgeFromList(string ssn)
        {
            this.Model.RemoveJudgeFromList(ssn);
        }
        void RemoveDiverFromList(string ssn)
        {
            this.Model.RemoveDiverFromList(ssn);
        }

        void RemoveJudgeFromContest(int contestId, string ssn)
        {
            this.Model.RemoveJudgeFromContest(contestId, ssn);
        }
        void RemoveDiverFromContest(int contestId, string ssn)
        {
            this.Model.RemoveDiverFromContest(contestId, ssn);
        }

        void UpdateJudge(int id, string name, string nationality, string ssn)
        {
            this.Model.UpdateJudge(id, name, nationality, ssn);
        }
        //public void AddParticipant(Diver diver)
        //{
        //    this.Model.AddParticipant(diver);
        //}

        //void AddJudge(Judge judge)
        //{
        //    this.Model.AddJudge(judge);
        //}

        //double GetTrickDifficultyFromTrickHashTable(string trickName)
        //{
        //    return this.Model.GetTrickDifficultyFromTrickHashTable(trickName);
        //}

        //double GetResultFromParticipant(string ssn)
        //{
        //    return this.Model.GetResultFromParticipant(ssn);
        //}

        //void CreateHtmlResultFile()
        //{
        //    this.Model.CreateHtmlResultFile();
        //}

        #endregion
    }
}
