﻿using System;
using System.Linq;
using System.Reflection;
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
        private DelegateGetJudgesInContest eventGetJudgesInContest;
        private DelegateGetDiversInContest eventGetDiversInContest;
        private DelegateAddJudgeToContest eventAddJudgeToContest;
        private DelegateAddDiverToContest eventAddDiverToContest;
        private DelegateRemoveJudgeFromContest eventRemoveJudgeFromContest;
        private DelegateRemoveDiverFromContest eventRemoveDiverFromContest;
        #endregion

        #region Constructor
        public StartContest
            (
                DelegateGetContestsList eventGetContestsList,
                DelegateGetJudgesList eventGetJudgesList,
                DelegateGetDiversList eventGetDiversList,
                DelegateGetJudgesInContest eventGetJudgesInContest,
                DelegateGetDiversInContest eventGetDiversInContest,
                DelegateAddJudgeToContest eventAddJudgeToContest,
                DelegateAddDiverToContest eventAddDiverToContest,
                DelegateRemoveJudgeFromContest eventRemoveJudgeFromContest,
                DelegateRemoveDiverFromContest eventRemoveDiverFromContest
            )
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();

            this.eventGetContestsList = eventGetContestsList;
            this.eventGetJudgesList = eventGetJudgesList;
            this.eventGetDiversList = eventGetDiversList;
            this.eventGetJudgesInContest = eventGetJudgesInContest;
            this.eventGetDiversInContest = eventGetDiversInContest;
            this.eventAddJudgeToContest = eventAddJudgeToContest;
            this.eventAddDiverToContest = eventAddDiverToContest;
            this.eventRemoveJudgeFromContest = eventRemoveJudgeFromContest;
            this.eventRemoveDiverFromContest = eventRemoveDiverFromContest;

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
            try
            {
                ContestsDataGridView.Columns["Id"].Visible = false;
                GlobalJudgesDataGridView.Columns["Id"].Visible = false;
                GlobalDiversDataGridView.Columns["Id"].Visible = false;
            }
            catch (NullReferenceException)
            {
                //gör inget, kommer hit om "Id" inte finns.
            }
        }
        #endregion

        /// <summary>
        /// Occurs when a row is selected in Contest Grid.
        /// Shows the judges/divers that participate in the selected contest.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContestsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                var cell = ContestsDataGridView.SelectedCells.Cast<DataGridViewCell>().FirstOrDefault();

                if (cell == null)
                {
                    return;
                }
                var row = cell.OwningRow;

                if (JudgesDiversTabControl.SelectedTab == JudgeTabPage)
                {
                    CurrentJudgesDataGridView.DataSource = eventGetJudgesInContest(Convert.ToInt16(row.Cells["Id"].Value));
                    CurrentJudgesDataGridView.Columns["Id"].Visible = false;
                }
                else if (JudgesDiversTabControl.SelectedTab == DiverTabPage)
                {
                    CurrentDiversDataGridView.DataSource = eventGetDiversInContest(Convert.ToInt16(row.Cells["Id"].Value));
                    CurrentDiversDataGridView.Columns["Id"].Visible = false;
                }

            }

            catch (NullReferenceException)
            {
                //do nothing
            }

            catch (OverflowException overflowException)
            {
                MsgBox.CreateErrorBox(overflowException.ToString(), MethodBase.GetCurrentMethod().Name);
            }
            catch (InvalidCastException invalidCastException)
            {
                MsgBox.CreateErrorBox(invalidCastException.ToString(), MethodBase.GetCurrentMethod().Name);
            }
            catch (FormatException formatException)
            {
                MsgBox.CreateErrorBox(formatException.ToString(), MethodBase.GetCurrentMethod().Name);
            }

            catch (ArgumentNullException nullException)
            {
                MsgBox.CreateErrorBox(nullException.ToString(), MethodBase.GetCurrentMethod().Name);
            }
            catch (ArgumentOutOfRangeException outOfRangeException)
            {
                MsgBox.CreateErrorBox(outOfRangeException.ToString(), MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception exception)
            {
                MsgBox.CreateErrorBox(exception.ToString(), MethodBase.GetCurrentMethod().Name);
            }
        }
        /// <summary>
        /// Occurs when changing tabs. Used to update the current datagrid content immediately.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JudgesDiversTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ContestsDataGridView_SelectionChanged(null, null);
        }

        #region Click Buttons

        private void AddJudgeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                AddPersonToContest(true);
            }
            catch (NullReferenceException nullReferenceException)
            {
                MsgBox.CreateErrorBox(nullReferenceException.ToString(), MethodBase.GetCurrentMethod().Name);
            }
            catch (ArgumentNullException argumentNullException)
            {
                MsgBox.CreateErrorBox(argumentNullException.ToString(), MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception exception)
            {
                MsgBox.CreateErrorBox(exception.ToString(), MethodBase.GetCurrentMethod().Name);
            }
        }
        private void AddDiverBtn_Click(object sender, EventArgs e)
        {
            try
            {
                AddPersonToContest(false);
            }
            catch (NullReferenceException nullReferenceException)
            {
                MsgBox.CreateErrorBox(nullReferenceException.ToString(), MethodBase.GetCurrentMethod().Name);
            }
            catch (ArgumentNullException argumentNullException)
            {
                MsgBox.CreateErrorBox(argumentNullException.ToString(), MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception exception)
            {
                MsgBox.CreateErrorBox(exception.ToString(), MethodBase.GetCurrentMethod().Name);
            }
        }
        /// <summary>
        /// Attempts to add a person (judge/diver) to a contest.
        /// </summary>
        /// <param name="isJudge"></param>
        private void AddPersonToContest(bool isJudge)
        {
            var personCell = isJudge ? GlobalJudgesDataGridView.SelectedCells.Cast<DataGridViewCell>().FirstOrDefault() :
                GlobalDiversDataGridView.SelectedCells.Cast<DataGridViewCell>().FirstOrDefault();

            var contestCell = ContestsDataGridView.SelectedCells.Cast<DataGridViewCell>().FirstOrDefault();

            if (personCell == null || contestCell == null)
            {
               throw new NullReferenceException("cell is null");
            }

            var personRow = personCell.OwningRow;
            var contestRow = contestCell.OwningRow;

            if (isJudge)
            {
                eventAddJudgeToContest(Convert.ToInt16(contestRow.Cells["Id"].Value), personRow.Cells["ssn"].Value.ToString());
            }
            else
            {
                eventAddDiverToContest(Convert.ToInt16(contestRow.Cells["Id"].Value), personRow.Cells["ssn"].Value.ToString());
            }
            
            //force update 
            ContestsDataGridView_SelectionChanged(null, null);
        }
        private void RemoveJudgeBtn_Click(object sender, EventArgs e)
        {
            RemovePersonFromContest(true);
        }

        private void RemoveDiverBtn_Click(object sender, EventArgs e)
        {
            RemovePersonFromContest(false);
        }
        /// <summary>
        /// Attempts to remove a person (judge/diver) from a contest.
        /// </summary>
        /// <param name="isJudge"></param>
        private void RemovePersonFromContest(bool isJudge)
        {
            var personCell = isJudge ? GlobalJudgesDataGridView.SelectedCells.Cast<DataGridViewCell>().FirstOrDefault() :
                GlobalDiversDataGridView.SelectedCells.Cast<DataGridViewCell>().FirstOrDefault();

            var contestCell = ContestsDataGridView.SelectedCells.Cast<DataGridViewCell>().FirstOrDefault();

            if (personCell == null || contestCell == null)
            {
                throw new NullReferenceException("cell is null");
            }

            var personRow = personCell.OwningRow;
            var contestRow = contestCell.OwningRow;

            if (isJudge)
            {
                eventRemoveJudgeFromContest(Convert.ToInt16(contestRow.Cells["Id"].Value), personRow.Cells["ssn"].Value.ToString());
            }
            else
            {
                eventRemoveJudgeFromContest(Convert.ToInt16(contestRow.Cells["Id"].Value), personRow.Cells["ssn"].Value.ToString());
            }

            //force update 
            ContestsDataGridView_SelectionChanged(null, null);
        }
        #endregion

    }
}
