using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            //var tempList = contest.GetLiveResultList();
            //var resultList = new BindingList<Participant>();

            //foreach (var result in tempList)
            //{
            //    resultList.Add(result);
            //}

            //ResultDataGridView.DataSource = resultList;

            ResultDataGridView.DataSource = contest.GetDiversList();

            //eventHandleMessage();
            //eventSendDataToClient();          
            //var asd = eventGetFirstClientObjectData();
        }

        private void LiveFeed_Load(object sender, EventArgs e)
        {
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
                    break;
                case 2:
                    Judge2Label.Text = shortName;
                    Judge2Label.Visible = true;
                    judge2Point.Visible = true;
                    break;
                case 3:
                    Judge3Label.Text = shortName;
                    Judge3Label.Visible = true;
                    judge3Point.Visible = true;
                    break;
                case 4:
                    Judge4Label.Text = shortName;
                    Judge4Label.Visible = true;
                    judge4Point.Visible = true;
                    break;
                case 5:
                    Judge5Label.Text = shortName;
                    Judge5Label.Visible = true;
                    judge5Point.Visible = true;
                    break;
                case 6:
                    Judge6Label.Text = shortName;
                    Judge6Label.Visible = true;
                    judge6Point.Visible = true;
                    break;
                case 7:
                    Judge7Label.Text = shortName;
                    Judge7Label.Visible = true;
                    judge7Point.Visible = true;
                    break;
            }
        }

        private void ReadPointsFromJudges()
        {
            while (!contest.IsFinished)
            {
                var judgeMessage = eventGetFirstClientObjectData();

            }
        }
    }
}
