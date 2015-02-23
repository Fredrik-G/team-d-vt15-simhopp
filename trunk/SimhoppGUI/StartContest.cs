using System;
using System.Windows.Forms;
using Simhopp;
using Simhopp.View;

namespace SimhoppGUI
{
    public partial class StartContest : Form
    {
        #region Data

        private DelegateGetContestsList eventGetContestsList;
        private DelegateGetJudgesList eventGetJudgesList;
        private DelegateGetDiversList eventGetDiversList;
        #endregion

        #region Constructor
        public StartContest
            (
                DelegateGetContestsList eventGetContestsList,
                DelegateGetJudgesList eventGetJudgesList,
                DelegateGetDiversList eventGetDiversList
            )
        {          
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();

            this.eventGetContestsList = eventGetContestsList;
            this.eventGetJudgesList = eventGetJudgesList;
            this.eventGetDiversList = eventGetDiversList;

            if (eventGetContestsList != null)
            {
                ContestsDataGridView.DataSource = this.eventGetContestsList();
                ContestsDataGridView.ReadOnly = true;
            }
            if (eventGetJudgesList != null)
            {
                GlobalJudgesDataGridView.DataSource = this.eventGetJudgesList();
            }
            if (eventGetDiversList != null)
            {
                GlobalDiversDataGridView.DataSource = this.eventGetDiversList();
            }
        }
        #endregion

        private void ContestsDataGridView_SelectionChanged(object sender, EventArgs e)
        {

        }
        private void JudgesTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MsgBox.CreateErrorBox("a","b");
        }



    }
}
