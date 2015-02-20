using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simhopp.Model;

namespace Simhopp.View
{
    public delegate void DelegateCreateContest(string place, string name, string startDate, string endDate);

    public delegate void DelegateReadFromFile(string fileName);

    public delegate BindingList<Contest> DelegateGetContestsList();

    public delegate BindingList<Judge> DelegateGetJudgesList();
    public delegate BindingList<Diver> DelegateGetDiversList();

    public delegate void DelegateAddJudgeToList(string name, string nationality, string ssn);
    public delegate void DelegateAddDiverToList(string name, string nationality, string ssn);

    public delegate void DelegateRemoveJudgeFromList(string ssn);
    public delegate void DelegateRemoveDiverFromList(string ssn);

    //public delegate void DelegateAddParticipant(Diver diver);
    //public delegate void DelegateAddJudge(Judge judge);
    //public delegate double DelegateGetTrickDifficultyFromTrickHashTable(string trickName);
    //public delegate double DelegateGetResultFromParticipant(string ssn);
    public interface IStartScreen
    {
        event DelegateCreateContest EventCreateContest;
        event DelegateReadFromFile EventReadFromFile;
        event DelegateGetContestsList EventGetContestsList;
        event DelegateGetJudgesList EventGetJudgesList;
        event DelegateGetDiversList EventGetDiversList;

        event DelegateAddJudgeToList EventAddJudgeToList;
        event DelegateAddDiverToList EventAddDiverToList;

        event DelegateRemoveJudgeFromList EventRemoveJudgeFromList;
        event DelegateRemoveDiverFromList EventRemoveDiverFromList;


        //event DelegateAddParticipant EventAddParticipant;
        //event DelegateAddJudge EventAddJudge;
        //event DelegateGetTrickDifficultyFromTrickHashTable EventGetTrickDifficultyFromTrickHashTable;
        //event DelegateGetResultFromParticipant EventGetResultFromParticipant;
    }
}
