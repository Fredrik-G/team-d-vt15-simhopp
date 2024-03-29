﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simhopp.Model;

namespace Simhopp.View
{
    public delegate void DelegateCreateContest(string place, string name, string startDate, string endDate);
    public delegate void DelegateSetJudgePoint(int contestId, string judgeSsn, string diverSsn, double point, int jumpNo);
    public delegate void DelegateSaveContestToDatabase(Contest contest);

    #region Read methods

    public delegate void DelegateReadFromFile(string fileName);

    public delegate void DelegateReadJudgesFromDatabase();

    public delegate void DelegateReadDiversFromDatabase();

    public delegate void DelegateReadTricksFromDatabase();

    public delegate void DelegateReadContestsFromDatabase();

    #endregion

    #region Getters

    public delegate BindingList<Contest> DelegateGetContestsList();
    public delegate Contest DelegateGetContest(int id);
    public delegate Contest DelegateGetContestFromDatabase(Contest contest);
    public delegate BindingList<Judge> DelegateGetJudgesList();
    public delegate BindingList<Diver> DelegateGetDiversList();
    public delegate BindingList<Judge> DelegateGetJudgesInContest(int id);
    public delegate BindingList<Diver> DelegateGetDiversInContest(int id);
    public delegate BindingList<Trick> DelegateGetTrickList();
    public delegate string DelegateGetJudgeHash(string ssn);
    public delegate string DelegateGetJudgeSalt(string ssn);
    public delegate void DelegateConnectToServer(string ip);
    public delegate string DelegateGetTrickFromParticipant(int contestId, int trickNo, string ssn);
    public delegate double DelegateGetTrickDifficultyFromTrickHashTable(string trickName);
    public delegate int DelegateGetTrickIdByName(string trickName);

    #endregion

    #region Adders

    public delegate void DelegateAddJudgeToList(
        string name, string nationality, string ssn, string password = "password");
    public delegate void DelegateAddDiverToList(string name, string nationality, string ssn);
    public delegate void DelegateAddJudgeToContest(int contestId, string ssn);
    public delegate void DelegateAddDiverToContest(int contestId, string ssn);
    public delegate void DelegateAddTrickToParticipant(int contestId, int trickNo, string trickName, string ssn);

    #endregion

    #region Remove methods

    public delegate void DelegateRemoveJudgeFromList(string ssn);
    public delegate void DelegateRemoveDiverFromList(string ssn);
    public delegate void DelegateRemoveJudgeFromContest(int contestId, string ssn);
    public delegate void DelegateRemoveDiverFromContest(int contestId, string ssn);

    #endregion

    #region Update methods

    public delegate void DelegateUpdateContest(int id, string name, string place, string startDate, string endDate);
    public delegate void DelegateUpdateJudge(int id, string name, string nationality, string ssn);
    public delegate void DelegateUpdateDiver(int id, string name, string nationality, string ssn);

    #endregion

    #region Server methods
    public delegate void DelegateHandleMessage();
    public delegate void DelegateSetDiverMessage(string contestName, string diverName, string trickName, double trickDifficulty);
    public delegate void DelegateSendDataToClient();
    public delegate ClientObjectData DelegateGetFirstClientObjectData();
    public delegate void DelegateStartServer();
    public delegate string DelegateGetIPForServer();


    //public delegate void DelegateAddParticipant(Diver diver);
    //public delegate void DelegateAddJudge(Judge judge);
    //public delegate double DelegateGetTrickDifficultyFromTrickHashTable(string trickName);
    //public delegate double DelegateGetResultFromParticipant(string ssn);

    #endregion

    public interface IStartScreen
    {
        event DelegateCreateContest EventCreateContest;
        event DelegateSetJudgePoint EventSetJudgePoint;
        event DelegateSaveContestToDatabase EventSaveContestToDatabase;
        

        #region Read methods

        event DelegateReadFromFile EventReadFromFile;
        event DelegateReadJudgesFromDatabase EventReadJudgesFromDatabase;
        event DelegateReadDiversFromDatabase EventReadDiversFromDatabase;
        event DelegateReadTricksFromDatabase EventReadTricksFromDatabase;
        event DelegateReadContestsFromDatabase EventReadContestsFromDatabase;

        #endregion

        #region Getters

        event DelegateGetContestsList EventGetContestsList;
        event DelegateGetContest EventGetContest;
        event DelegateGetJudgesList EventGetJudgesList;
        event DelegateGetDiversList EventGetDiversList;

        event DelegateGetJudgesInContest EventGetJudgesInContest;
        event DelegateGetDiversInContest EventGetDiversInContest;

        event DelegateGetJudgeHash EventGetJudgeHash;
        event DelegateGetJudgeSalt EventGetJudgeSalt;
        event DelegateConnectToServer EventConnectToServer;

        event DelegateGetTrickList EventGetTrickList;
        event DelegateGetTrickFromParticipant EventGetTrickFromParticipant;
        event DelegateGetTrickDifficultyFromTrickHashTable EventGetTrickDifficultyFromTrickHashTable;
        event DelegateGetTrickIdByName EventGetTrickIdByName;
        #endregion

        #region Add methods

        event DelegateAddJudgeToList EventAddJudgeToList;
        event DelegateAddDiverToList EventAddDiverToList;
        event DelegateGetContestFromDatabase EventGetContestFromDatabase;
        event DelegateAddJudgeToContest EventAddJudgeToContest;
        event DelegateAddDiverToContest EventAddDiverToContest;
        event DelegateAddTrickToParticipant EventAddTrickToParticipant;

        #endregion

        #region Remove methods

        event DelegateRemoveJudgeFromList EventRemoveJudgeFromList;
        event DelegateRemoveDiverFromList EventRemoveDiverFromList;

        event DelegateRemoveJudgeFromContest EventRemoveJudgeFromContest;
        event DelegateRemoveDiverFromContest EventRemoveDiverFromContest;

        #endregion

        #region Update methods

        event DelegateUpdateContest EventUpdateContest;
        event DelegateUpdateJudge EventUpdateJudge;
        event DelegateUpdateDiver EventUpdateDiver;


        

        #endregion

        #region Server methods


        event DelegateHandleMessage EventHandleMessage;
        event DelegateSetDiverMessage EventSetDiverMessage;
        event DelegateSendDataToClient EventSendDataToClient;
        event DelegateGetFirstClientObjectData EventGetFirstClientObjectData;
        event DelegateStartServer EventStartServer;
        event DelegateGetIPForServer EventGetIPForServer;

        #endregion

    }
}
