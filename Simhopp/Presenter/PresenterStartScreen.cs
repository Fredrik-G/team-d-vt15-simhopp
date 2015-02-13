using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimhoppGUI.Model;
using SimhoppGUI.View;

namespace SimhoppGUI.Presenter
{
    /// <summary>
    /// Denna lösning blir en form av både MVC/MVP.
    /// </summary>
    public class PresenterStartScreen
    {
        #region Properties
        public IStartScreen View{ get; set; }
        public ISimhopp Model { get; set; }

        #endregion

        public PresenterStartScreen(IStartScreen view, Simhopp simhopp)
        {
            this.Model = simhopp;
            this.View = view;
            this.View.EventCreateContest += CreateContest;

            //this.View.EventAddParticipant += AddParticipant;
            //this.View.EventAddJudge += AddJudge;
            //this.View.EventGetTrickDifficultyFromTrickHashTable += GetTrickDifficultyFromTrickHashTable;
            //this.View.EventGetResultFromParticipant += GetResultFromParticipant;
        }

        #region Methods

        public void CreateContest(string place, string name, string startDate)
        {
            this.Model.CreateContest(place, name, startDate);
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
