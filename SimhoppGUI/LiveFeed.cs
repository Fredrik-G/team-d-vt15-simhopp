using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
        private readonly int contestId;
        private Contest contest;
        private Thread listenerThread;

        #endregion

        #region Constructor

        public LiveFeed(DelegateGetFirstClientObjectData eventGetFirstClientObjectData,
            DelegateHandleMessage eventHandleMessage,
            DelegateSendDataToClient eventSendDataToClient,
            DelegateGetContest eventGetContest, 
            int contestId,
            DelegateStartServer eventStartServer)
        {
            InitializeComponent();

            this.eventGetFirstClientObjectData = eventGetFirstClientObjectData;
            this.eventHandleMessage = eventHandleMessage;
            this.eventSendDataToClient = eventSendDataToClient;
            this.eventGetContest = eventGetContest;
            this.eventStartServer = eventStartServer;
            this.contestId = contestId;
            this.contest = eventGetContest(contestId);
            

        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
           // ResultDataGridView.DataSource = contest.GetDiversList();

            if (listenerThread != null)
            {
                return;
            }

            listenerThread = new Thread(ReadPointsFromJudges);
            listenerThread.Start();
            listenerThread.IsBackground = true;
        }

        private void LiveFeed_Load(object sender, EventArgs e)
        {
            eventStartServer();
            var judgesList = contest.GetJudgesList();
            foreach (var judge in judgesList)
            {
                var judgeIndex = judgesList.IndexOf(judge);
                ActivateJudgePointField((judgeIndex + 1), judge.Name);
            }            
        }

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
                    judge2Point.Enabled = false;
                    break;
                case 4:
                    Judge4Label.Text = shortName;
                  
                    Judge4Label.Visible = true;
                    judge4Point.Visible = true;
                    judge2Point.Enabled = false;
                    break;
                case 5:
                    Judge5Label.Text = shortName;
                 
                    Judge5Label.Visible = true;
                    judge5Point.Visible = true;
                    judge2Point.Enabled = false;
                    break;
                case 6:
                    Judge6Label.Text = shortName;
                
                    Judge6Label.Visible = true;
                    judge6Point.Visible = true;
                    judge2Point.Enabled = false;
                    break;
                case 7:
                    Judge7Label.Text = shortName;
                
                    Judge7Label.Visible = true;
                    judge7Point.Visible = true;
                    judge2Point.Enabled = false;
                    break;
            }
        }

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

                    //TODO: Simhopp.SetJudgePoint
                }

                Thread.Sleep(300);
            }
        }

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

        private void LiveFeed_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (listenerThread != null)
            {
                listenerThread.Abort();  
            }
        }
    }
}
