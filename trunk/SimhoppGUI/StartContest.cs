using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Simhopp;
using Simhopp.Model;
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
        private DelegateUpdateContest eventUpdateContest;
        private DelegateReadTricksFromDatabase eventReadTricksFromDatabase;

        DataGridViewComboBoxColumn trick1ComboBoxColumn = new DataGridViewComboBoxColumn();
        DataGridViewComboBoxColumn trick2ComboBoxColumn = new DataGridViewComboBoxColumn();
        DataGridViewComboBoxColumn trick3ComboBoxColumn = new DataGridViewComboBoxColumn();

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
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
                DelegateRemoveDiverFromContest eventRemoveDiverFromContest,
                DelegateUpdateContest eventUpdateContest,
                DelegateReadTricksFromDatabase eventReadTricksFromDatabase
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
            this.eventUpdateContest = eventUpdateContest;
            this.eventReadTricksFromDatabase = eventReadTricksFromDatabase;      
        }
        #endregion

        #region Events

        /// <summary>
        /// Occurs when the form is loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartContest_Load(object sender, EventArgs e)
        {
            if (eventGetContestsList != null)
            {
                ContestsDataGridView.DataSource = this.eventGetContestsList();
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

                ContestsDataGridView.Columns["IsFinished"].Visible = false;

                GlobalJudgesDataGridView.Columns["Salt"].Visible = false;
                GlobalJudgesDataGridView.Columns["Hash"].Visible = false;

                GlobalDiversDataGridView.Columns["SSN"].Visible = false;
                GlobalJudgesDataGridView.Columns["SSN"].Visible = false;

            }
            catch (NullReferenceException nullReferenceException)
            {
                //gör inget, kommer hit om "Id" inte finns.
                log.Warn("Null reference exception when trying to start a contest", nullReferenceException);
            }
           
            var simhopp = new Simhopp.Simhopp();
            simhopp.ReadTricksFromDatabase();
            
            trick1ComboBoxColumn.DataSource = simhopp.GetTrickList();
            trick1ComboBoxColumn.DisplayMember = "name";
            trick1ComboBoxColumn.ValueMember = "name";
            trick1ComboBoxColumn.Name = "Trick 1";

            trick2ComboBoxColumn.DataSource = simhopp.GetTrickList();
            trick2ComboBoxColumn.DisplayMember = "name";
            trick2ComboBoxColumn.ValueMember = "name";
            trick2ComboBoxColumn.Name = "Trick 2";

            trick3ComboBoxColumn.DataSource = simhopp.GetTrickList();
            trick3ComboBoxColumn.DisplayMember = "name";
            trick3ComboBoxColumn.ValueMember = "name";
            trick3ComboBoxColumn.Name = "Trick 3";

            CurrentDiversDataGridView.Columns.Add(trick1ComboBoxColumn);
            CurrentDiversDataGridView.Columns.Add(trick2ComboBoxColumn);
            CurrentDiversDataGridView.Columns.Add(trick3ComboBoxColumn);

            ContestsDataGridView.Select();
        }

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
                  //  GlobalJudgesDataGridView.Select();

                    CurrentJudgesDataGridView.DataSource =
                        eventGetJudgesInContest(Convert.ToInt16(row.Cells["Id"].Value));

                    CurrentJudgesDataGridView.Columns["Id"].Visible = false;
                    CurrentJudgesDataGridView.Columns["Salt"].Visible = false;
                    CurrentJudgesDataGridView.Columns["Hash"].Visible = false;
                    CurrentJudgesDataGridView.Columns["SSN"].Visible = false;
                }
                else if (JudgesDiversTabControl.SelectedTab == DiverTabPage)
                {
                    CurrentDiversDataGridView.DataSource =
                        eventGetDiversInContest(Convert.ToInt16(row.Cells["Id"].Value));

                    CurrentDiversDataGridView.Columns["Id"].Visible = false;
                    CurrentJudgesDataGridView.Columns["Salt"].Visible = false;
                    CurrentJudgesDataGridView.Columns["Hash"].Visible = false;
                    CurrentDiversDataGridView.Columns["SSN"].Visible = false;

                    CurrentDiversDataGridView.Columns["Trick 1"].DisplayIndex = 4;
                    CurrentDiversDataGridView.Columns["Trick 2"].DisplayIndex = 5;
                    CurrentDiversDataGridView.Columns["Trick 3"].DisplayIndex = 6;

                    CurrentDiversDataGridView.Columns["Name"].Width = 100;
                    CurrentDiversDataGridView.Columns["Nationality"].Width = 70;
                    CurrentDiversDataGridView.Columns["Trick 1"].Width = 150;
                    CurrentDiversDataGridView.Columns["Trick 2"].Width = 150;
                    CurrentDiversDataGridView.Columns["Trick 3"].Width = 150;

                }
            }

            catch (NullReferenceException nullReferenceException)
            {
                //do nothing
                log.Warn("Null reference exception when trying to show judges/divers in a contest", nullReferenceException);
            }

            catch (OverflowException overflowException)
            {
                MsgBox.CreateErrorBox(overflowException.ToString(), MethodBase.GetCurrentMethod().Name);
                log.Error("Overflow exception when trying to show judges/divers in a contest", overflowException);
            }
            catch (InvalidCastException invalidCastException)
            {
                MsgBox.CreateErrorBox(invalidCastException.ToString(), MethodBase.GetCurrentMethod().Name);
                log.Warn("Invalid cast exception when trying to show judges/divers in a contest", invalidCastException);
            }
            catch (FormatException formatException)
            {
                MsgBox.CreateErrorBox(formatException.ToString(), MethodBase.GetCurrentMethod().Name);
                log.Warn("Format exception when trying to show judges/divers in a contest", formatException);
            }

            catch (ArgumentNullException nullException)
            {
                MsgBox.CreateErrorBox(nullException.ToString(), MethodBase.GetCurrentMethod().Name);
                log.Warn("Null argument exception when trying to show judges/divers in a contest", nullException);
            }
            catch (ArgumentOutOfRangeException outOfRangeException)
            {
                MsgBox.CreateErrorBox(outOfRangeException.ToString(), MethodBase.GetCurrentMethod().Name);
                log.Warn("Out of range exception when trying to show judges/divers in a contest", outOfRangeException);
            }
            catch (Exception exception)
            {
                MsgBox.CreateErrorBox(exception.ToString(), MethodBase.GetCurrentMethod().Name);
                log.Error("Overflow exception when trying to show judges/divers in a contest", exception);
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
            if (JudgesDiversTabControl.SelectedTab == JudgeTabPage)
            {
                GlobalJudgesLabel.Visible = true;
                CurrentJudgesLabel.Visible = true;
                GlobalDiversLabel.Visible = false;
                CurrentlDiversLabel.Visible = false;
            }
            else if (JudgesDiversTabControl.SelectedTab == DiverTabPage)
            {
                GlobalDiversLabel.Visible = true;
                CurrentlDiversLabel.Visible = true;
                GlobalJudgesLabel.Visible = false;
                CurrentJudgesLabel.Visible = false;
            }
        }

        #endregion

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
            try
            {
                RemovePersonFromContest(true);
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

        private void RemoveDiverBtn_Click(object sender, EventArgs e)
        {
            try
            {
                RemovePersonFromContest(false);
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
        /// Attempts to remove a person (judge/diver) from a contest.
        /// </summary>
        /// <param name="isJudge"></param>
        private void RemovePersonFromContest(bool isJudge)
        {
            var personCell = isJudge ? CurrentJudgesDataGridView.SelectedCells.Cast<DataGridViewCell>().FirstOrDefault() :
                CurrentDiversDataGridView.SelectedCells.Cast<DataGridViewCell>().FirstOrDefault();

            var contestCell = ContestsDataGridView.SelectedCells.Cast<DataGridViewCell>().FirstOrDefault();

            if (personCell == null || contestCell == null)
            {//Händer om man klickar remove när det inte finns några current judges/divers. Ska man visa error eller bara ignorera det?
                // throw new NullReferenceException("cell is null");
                return;
            }

            var personRow = personCell.OwningRow;
            var contestRow = contestCell.OwningRow;

            if (isJudge)
            {
                eventRemoveJudgeFromContest(Convert.ToInt16(contestRow.Cells["Id"].Value), personRow.Cells["ssn"].Value.ToString());
            }
            else
            {
                eventRemoveDiverFromContest(Convert.ToInt16(contestRow.Cells["Id"].Value), personRow.Cells["ssn"].Value.ToString());
            }

            //force update 
            ContestsDataGridView_SelectionChanged(null, null);
        }

        private void EditContestBtn_Click(object sender, EventArgs e)
        {
            var selectedContest = ContestsDataGridView.SelectedCells.Cast<DataGridViewCell>().FirstOrDefault();
            using (new DimIt())
            using (var editContest = new EditContest(selectedContest, eventUpdateContest))
            {
                if (editContest.ShowDialog(this) == DialogResult.OK)
                {
                    ContestsDataGridView.Refresh();
                }
            }
        }

        #endregion

        private void StartContestBtn_Click(object sender, EventArgs e)
        {
            using (new DimIt())
            using (var liveFeed = new LiveFeed())
            {
                if (liveFeed.ShowDialog(this) == DialogResult.OK)
                {

                }
            }
        }

     
    }
}
