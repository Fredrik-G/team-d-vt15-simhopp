using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Simhopp.Model;
using Simhopp.View;

namespace SimhoppGUI
{
    public partial class ContestResult : Form
    {
        private Contest contest;
        private readonly int contestId;
        private BindingList<Participant> liveResultList = new BindingList<Participant>();
        private BindingList<Judge> judgeBindingList = new BindingList<Judge>(); 
        public ContestResult(DelegateGetContestFromDatabase eventGetContestFromDatabase, Contest contest)
        {
            InitializeComponent();
            this.contest = contest;
            this.contest = eventGetContestFromDatabase(contest);
        }

        private void ContestResult_Load(object sender, EventArgs e)
        {
            //resultsDataGridView.DataSource = //BindingList 
            UpdateResultList();
            convertJudgeList();
            resultDataGridView.DefaultCellStyle.Format = "0.00##";
            
            resultDataGridView.DataSource = liveResultList;
            judgesDataGridView.DataSource = judgeBindingList;
            judgesDataGridView.Columns["Hash"].Visible = false;
            judgesDataGridView.Columns["Salt"].Visible = false;
            judgesDataGridView.Columns["Id"].Visible = false;
            judgesDataGridView.Columns["Ssn"].Visible = false;
            
            contestNameLabel.Text = contest.Name;
            placeNameLabel.Text = contest.Place;
            startDateLabel.Text = contest.StartDate;
            endDateLabel.Text = contest.EndDate;

            
        }

        private void UpdateResultList()
        {
            liveResultList.Clear();
            var tempLiveResultList = contest.GetParticipants().ToList();
            contest.SortParticipants(ref tempLiveResultList, true);
            foreach (var participant in tempLiveResultList)
            {
                liveResultList.Add(participant);
            }
        }

        private void convertJudgeList()
        {
            foreach (var judge in contest.GetJudgesList())
            {
                judgeBindingList.Add(judge);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
