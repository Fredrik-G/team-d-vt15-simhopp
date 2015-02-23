﻿using System;
using System.Windows.Forms;
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
                GlobalJudgesDataGridView.DataSource = this.eventGetDiversList();
            }
        }
        #endregion

        private void JudgesDiversTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
