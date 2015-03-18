using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Simhopp;
using Simhopp.Model;
using Simhopp.View;

namespace SimhoppGUI
{
    public partial class LiveFeed : Form
    {
        #region Data

        private DelegateGetFirstClientObjectData eventGetFirstClientObjectData;
        private DelegateHandleMessage eventHandleMessage;
        private DelegateSendDataToClient eventSendDataToClient;
        private DelegateGetContest eventGetContest;
        private DelegateStartServer eventStartServer;
        private DelegateSetJudgePoint eventSetJudgePoint;
        private DelegateSetDiverMessage eventSetDiverMessage;
        private DelegateGetIPForServer eventGetIPForServer;
        private DelegateGetTrickDifficultyFromTrickHashTable eventGetTrickDifficultyFromTrickHashTable;
        private DelegateSaveContestToDatabase eventSaveContestToDatabase;
        private DelegateGetContestFromDatabase eventGetContestFromDatabase;
        private DelegateGetTrickIdByName eventGetTrickIdByName;

        private readonly int contestId;
        private readonly Contest contest;
        private int jumpNo = 0;
        private int participantNo = 0;
        private BindingList<Participant> liveResultList = new BindingList<Participant>();

        private Thread listenerThread;

        #endregion

        #region Properties

        public string DiverName
        {
            get { return NameTextLabel.Text; }
            set { NameTextLabel.Text = value; }
        }
        public string DiverTrickName
        {
            get { return TrickNameLabel.Text; }
            set { TrickNameLabel.Text = value; }
        }
        public string DiverTrickDifficulty
        {
            get { return DifficultyValueLabel.Text; }
            set { DifficultyValueLabel.Text = value; }
        }
        public string DiverPoints
        {
            get { return PointsValueLabel.Text; }
            set { PointsValueLabel.Text = value; }
        }

        #endregion

        #region Constructor

        public LiveFeed(DelegateGetFirstClientObjectData eventGetFirstClientObjectData,
            DelegateHandleMessage eventHandleMessage,
            DelegateSendDataToClient eventSendDataToClient,
            DelegateGetContest eventGetContest,
            int contestId,
            DelegateStartServer eventStartServer,
            DelegateSetJudgePoint eventSetJudgePoint,
            DelegateSetDiverMessage eventSetDiverMessage,
            DelegateGetIPForServer eventGetIPForServer,
            DelegateGetTrickDifficultyFromTrickHashTable eventGetTrickDifficultyFromTrickHashTable,
            DelegateSaveContestToDatabase eventSaveContestToDatabase,
            DelegateGetContestFromDatabase eventGetContestFromDatabase,
            DelegateGetTrickIdByName eventGetTrickIdByName)
        {
            InitializeComponent();

            this.eventGetFirstClientObjectData = eventGetFirstClientObjectData;
            this.eventHandleMessage = eventHandleMessage;
            this.eventSendDataToClient = eventSendDataToClient;
            this.eventGetContest = eventGetContest;
            this.eventStartServer = eventStartServer;
            this.eventSetJudgePoint = eventSetJudgePoint;
            this.eventSetDiverMessage = eventSetDiverMessage;
            this.eventGetIPForServer = eventGetIPForServer;
            this.eventGetTrickDifficultyFromTrickHashTable = eventGetTrickDifficultyFromTrickHashTable;
            this.eventSaveContestToDatabase = eventSaveContestToDatabase;
            this.eventGetTrickIdByName = eventGetTrickIdByName;

            this.contestId = contestId;
            this.contest = eventGetContest(contestId);
        }

        #endregion

        #region Load/close
        /// <summary>
        /// Occurs when the form is loaded. 
        /// Starts a TCP server.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LiveFeed_Load(object sender, EventArgs e)
        {
            UpdateDiverInformation();
            UpdateLiveResultList();
            ResultDataGridView.DefaultCellStyle.Format = "0.00##";
            ResultDataGridView.DataSource = liveResultList;

            eventStartServer();

            if (listenerThread != null)
            {
                return;
            }

            listenerThread = new Thread(ReadPointsFromJudges);
            listenerThread.Start();
            listenerThread.IsBackground = true;

            eventSetDiverMessage(contest.Name, contest.GetParticipant(participantNo).DiverName,
                TrickNameLabel.Text, Convert.ToDouble(DifficultyValueLabel.Text));

            IPValueLabel.Text = eventGetIPForServer();

            var judgesList = contest.GetJudgesList();
            foreach (var judge in judgesList)
            {
                var judgeIndex = judgesList.IndexOf(judge);
                ActivateJudgePointField((judgeIndex + 1), judge.Name);
            }
        }
        /// <summary>
        /// Activates judge point fields depending on the number of judges.
        /// </summary>
        /// <param name="judgeIndex"></param>
        /// <param name="name"></param>
        private void ActivateJudgePointField(int judgeIndex, string name)
        {
            var tempName = name.Split(' ');
            var shortName = tempName[0][0] + ". " + tempName[1];

            switch (judgeIndex)
            {
                case 1:
                    Judge1Label.Text = shortName;

                    Judge1Label.Visible = true;
                    judge1Point.Visible = true;
                    judge1Point.Enabled = false;
                    break;
                case 2:
                    Judge2Label.Text = shortName;

                    Judge2Label.Visible = true;
                    judge2Point.Visible = true;
                    judge2Point.Enabled = false;
                    break;
                case 3:
                    Judge3Label.Text = shortName;

                    Judge3Label.Visible = true;
                    judge3Point.Visible = true;
                    judge3Point.Enabled = false;
                    break;
                case 4:
                    Judge4Label.Text = shortName;

                    Judge4Label.Visible = true;
                    judge4Point.Visible = true;
                    judge4Point.Enabled = false;
                    break;
                case 5:
                    Judge5Label.Text = shortName;

                    Judge5Label.Visible = true;
                    judge5Point.Visible = true;
                    judge5Point.Enabled = false;
                    break;
                case 6:
                    Judge6Label.Text = shortName;

                    Judge6Label.Visible = true;
                    judge6Point.Visible = true;
                    judge6Point.Enabled = false;
                    break;
                case 7:
                    Judge7Label.Text = shortName;

                    Judge7Label.Visible = true;
                    judge7Point.Visible = true;
                    judge7Point.Enabled = false;
                    break;
            }
        }
        /// <summary>
        /// Occurs when the form is closing.
        /// Closes the background thread for listening.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LiveFeed_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (listenerThread != null)
            {
                listenerThread.Abort();
            }
        }

        #endregion

        /// <summary>
        /// Updates the diver information labels with the current diver.
        /// </summary>
        private void UpdateDiverInformation()
        {
            DiverName = contest.GetParticipant(participantNo).GetDiverName();
            DiverTrickName = contest.GetParticipant(participantNo).GetJumpResults()[jumpNo].TrickName;
            DiverTrickDifficulty = eventGetTrickDifficultyFromTrickHashTable(DiverTrickName).ToString();
        }

        #region Point methods

        /// <summary>
        /// Reads points from JudgeClient untill contest is finished.
        /// This method should always run in its own thread.
        /// </summary>
        private void ReadPointsFromJudges()
        {
            while (!contest.IsFinished)
            {
                var judgeMessage = eventGetFirstClientObjectData();
                if (judgeMessage != null)
                {
                    var judge = contest.GetJudgesList().SingleOrDefault(x => x.SSN == judgeMessage.Ssn);
                    var judgeIndex = contest.GetJudgesList().IndexOf(judge);

                    UpdateJudgePointField((judgeIndex + 1), judgeMessage.Point);

                    eventSetJudgePoint(contest.Id, judgeMessage.Ssn, contest.GetParticipant(participantNo).GetDiverSSN(), judgeMessage.Point, jumpNo);
                }

                Thread.Sleep(300);
            }
            eventSaveContestToDatabase(contest);
            MsgBox.CreateInfoBox("Contest is finished");
            //using (new DimIt())
            /*using (var contestResult = new ContestResult(eventGetContestFromDatabase, eventGetContest(contest.Id)))
            {
                if (contestResult.ShowDialog(this) == DialogResult.OK)
                {

                }
            }*/
        }

        /// <summary>
        /// Updates the judge point fields with points from the listener thread.
        /// </summary>
        /// <param name="judgeIndex"></param>
        /// <param name="point"></param>
        private void UpdateJudgePointField(int judgeIndex, double point)
        {
            switch (judgeIndex)
            {
                case 1:
                    Invoke((MethodInvoker)delegate { judge1Point.Text = point.ToString(); });
                    break;
                case 2:
                    Invoke((MethodInvoker)delegate { judge2Point.Text = point.ToString(); });
                    break;
                case 3:
                    Invoke((MethodInvoker)delegate { judge3Point.Text = point.ToString(); });
                    break;
                case 4:
                    Invoke((MethodInvoker)delegate { judge4Point.Text = point.ToString(); });
                    break;
                case 5:
                    Invoke((MethodInvoker)delegate { judge5Point.Text = point.ToString(); });
                    break;
                case 6:
                    Invoke((MethodInvoker)delegate { judge6Point.Text = point.ToString(); });
                    break;
                case 7:
                    Invoke((MethodInvoker)delegate { judge7Point.Text = point.ToString(); });
                    break;
            }
        }

        /// <summary>
        /// Resets all judge point fields to zero.
        /// </summary>
        private void ResetJudgePointField()
        {
            foreach (var point in JudgePointsPanel.Controls.OfType<NumericUpDown>())
            {
                point.Text = "0,0";
            }
        }

        #endregion

        /// <summary>
        /// Checks if all judge points are set for a given jump. 
        /// If so, continue with the next participant.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommitBtn_Click(object sender, EventArgs e)
        {
            var numberOfParticipants = participantNo + 1;
            if (contest.IsAllJudgePointSet(contest.GetParticipant(participantNo).GetDiverSSN(), jumpNo))
            {

                //Checks if all participants are done for this jump set.
                if (contest.GetNumberOfParticipants() == (participantNo + 1))
                {
                    CalculateAndUpdatePoints();
                    jumpNo++;
                    participantNo = 0;
                }
                else
                {
                    CalculateAndUpdatePoints();
                    participantNo++;
                }

                //Checks if every participant is done and there's been three jump sets. 
                if ((jumpNo == 3) && (contest.GetNumberOfParticipants() == numberOfParticipants))
                {
                    contest.IsFinished = true;
                    return;
                }


                if (!contest.IsFinished)
                {
                    UpdateLiveResultList();
                    UpdateDiverInformation();
                }

                eventSetDiverMessage(contest.Name, contest.GetParticipant(participantNo).DiverName,
                    TrickNameLabel.Text, Convert.ToDouble(DifficultyValueLabel.Text));
                eventSendDataToClient();
                ResetJudgePointField();
            }
            else
            {
                MsgBox.CreateErrorBox("not set", "ajdå");
            }
        }

        private void UpdateLiveResultList()
        {
            liveResultList.Clear();
            var tempLiveResultList = contest.GetParticipants().ToList();
            contest.SortParticipants(ref tempLiveResultList, true);
            foreach (var participant in tempLiveResultList)
            {
                liveResultList.Add(participant);
            }
        }

        private void CalculateAndUpdatePoints()
        {
            contest.GetParticipant(participantNo).CalculatePoints();
            contest.GetParticipant(participantNo).UpdateTotalPoints(eventGetTrickDifficultyFromTrickHashTable(DiverTrickName));
            DiverPoints = contest.GetParticipant(participantNo).TotalPoints.ToString();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
