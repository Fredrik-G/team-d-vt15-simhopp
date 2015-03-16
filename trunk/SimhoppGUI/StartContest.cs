using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        private DelegateGetContest eventGetContest;
        private DelegateGetJudgesList eventGetJudgesList;
        private DelegateGetDiversList eventGetDiversList;
        private DelegateGetJudgesInContest eventGetJudgesInContest;
        private DelegateGetDiversInContest eventGetDiversInContest;
        private DelegateAddJudgeToContest eventAddJudgeToContest;
        private DelegateAddDiverToContest eventAddDiverToContest;
        private DelegateRemoveJudgeFromContest eventRemoveJudgeFromContest;
        private DelegateRemoveDiverFromContest eventRemoveDiverFromContest;
        private DelegateUpdateContest eventUpdateContest;
        private DelegateGetTrickList eventGetTrickList;
        private DelegateGetFirstClientObjectData eventGetFirstClientObjectData;
        private DelegateHandleMessage eventHandleMessage;
        private DelegateSendDataToClient eventSendDataToClient;
        private DelegateAddTrickToParticipant eventAddTrickToParticipant;
        private DelegateGetTrickFromParticipant eventGetTrickFromParticipant;
        private DelegateStartServer eventStartServer;
        private DelegateSetJudgePoint eventSetJudgePoint;
        private DelegateSetDiverMessage eventSetDiverMessage;
        private DelegateGetIPForServer eventGetIPForServer;
        private DelegateGetTrickDifficultyFromTrickHashTable eventGetTrickDifficultyFromTrickHashTable;
        private DelegateSaveContestToDatabase eventSaveContestToDatabase;

        DataGridViewComboBoxColumn trick1ComboBoxColumn = new DataGridViewComboBoxColumn();
        DataGridViewComboBoxColumn trick2ComboBoxColumn = new DataGridViewComboBoxColumn();
        DataGridViewComboBoxColumn trick3ComboBoxColumn = new DataGridViewComboBoxColumn();

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region Constructor
        public StartContest
            (
                DelegateGetContestsList eventGetContestsList,
                DelegateGetContest eventGetContest,
                DelegateGetJudgesList eventGetJudgesList,
                DelegateGetDiversList eventGetDiversList,
                DelegateGetJudgesInContest eventGetJudgesInContest,
                DelegateGetDiversInContest eventGetDiversInContest,
                DelegateAddJudgeToContest eventAddJudgeToContest,
                DelegateAddDiverToContest eventAddDiverToContest,
                DelegateRemoveJudgeFromContest eventRemoveJudgeFromContest,
                DelegateRemoveDiverFromContest eventRemoveDiverFromContest,
                DelegateUpdateContest eventUpdateContest,
                DelegateGetTrickList eventGetTrickList,
                DelegateGetFirstClientObjectData eventGetFirstClientObjectData,
                DelegateHandleMessage eventHandleMessage,
                DelegateSendDataToClient eventSendDataToClient,
                DelegateAddTrickToParticipant eventAddTrickToParticipant,
                DelegateGetTrickFromParticipant eventGetTrickFromParticipant,
                DelegateStartServer eventStartServer,
                DelegateSetJudgePoint eventSetJudgePoint,
                DelegateSetDiverMessage eventSetDiverMessage,
                DelegateGetIPForServer eventGetIPForServer,
                DelegateGetTrickDifficultyFromTrickHashTable eventGetTrickDifficultyFromTrickHashTable,
                DelegateSaveContestToDatabase eventSaveContestToDatabase
            )
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();

            this.eventGetContestsList = eventGetContestsList;
            this.eventGetContest = eventGetContest;
            this.eventGetJudgesList = eventGetJudgesList;
            this.eventGetDiversList = eventGetDiversList;
            this.eventGetJudgesInContest = eventGetJudgesInContest;
            this.eventGetDiversInContest = eventGetDiversInContest;
            this.eventAddJudgeToContest = eventAddJudgeToContest;
            this.eventAddDiverToContest = eventAddDiverToContest;
            this.eventRemoveJudgeFromContest = eventRemoveJudgeFromContest;
            this.eventRemoveDiverFromContest = eventRemoveDiverFromContest;
            this.eventUpdateContest = eventUpdateContest;
            this.eventGetTrickList = eventGetTrickList;
            this.eventGetFirstClientObjectData = eventGetFirstClientObjectData;
            this.eventHandleMessage = eventHandleMessage;
            this.eventSendDataToClient = eventSendDataToClient;
            this.eventAddTrickToParticipant = eventAddTrickToParticipant;
            this.eventGetTrickFromParticipant = eventGetTrickFromParticipant;
            this.eventStartServer = eventStartServer;
            this.eventSetJudgePoint = eventSetJudgePoint;
            this.eventSetDiverMessage = eventSetDiverMessage;
            this.eventGetIPForServer = eventGetIPForServer;
            this.eventGetTrickDifficultyFromTrickHashTable = eventGetTrickDifficultyFromTrickHashTable;
            this.eventSaveContestToDatabase = eventSaveContestToDatabase;
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
            //enables keyboard usage.
            KeyPreview = true;

            if (eventGetContestsList != null)
            {
                ContestsDataGridView.DataSource = eventGetContestsList();
                ShowFinishedContestState();
            }
            if (eventGetJudgesList != null)
            {
                GlobalJudgesDataGridView.DataSource = eventGetJudgesList();
            }
            if (eventGetDiversList != null)
            {
                GlobalDiversDataGridView.DataSource = eventGetDiversList();
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

            trick1ComboBoxColumn.DataSource = eventGetTrickList();
            trick1ComboBoxColumn.DisplayMember = "name";
            trick1ComboBoxColumn.ValueMember = "name";
            trick1ComboBoxColumn.Name = "Trick 1";


            trick2ComboBoxColumn.DataSource = eventGetTrickList();
            trick2ComboBoxColumn.DisplayMember = "name";
            trick2ComboBoxColumn.ValueMember = "name";
            trick2ComboBoxColumn.Name = "Trick 2";

            trick3ComboBoxColumn.DataSource = eventGetTrickList();
            trick3ComboBoxColumn.DisplayMember = "name";
            trick3ComboBoxColumn.ValueMember = "name";
            trick3ComboBoxColumn.Name = "Trick 3";

            CurrentDiversDataGridView.Columns.Add(trick1ComboBoxColumn);
            CurrentDiversDataGridView.Columns.Add(trick2ComboBoxColumn);
            CurrentDiversDataGridView.Columns.Add(trick3ComboBoxColumn);

            CurrentDiversDataGridView.CellValueChanged += CurrentDiversDataGridView_CellValueChanged;
            CurrentDiversDataGridView.CurrentCellDirtyStateChanged += CurrentDiversDataGridView_CurrentCellDirtyStateChanged;


            GlobalJudgesDataGridView.Select();
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
                var contestCell = ContestsDataGridView.SelectedCells.Cast<DataGridViewCell>().FirstOrDefault();

                if (contestCell == null)
                {
                    return;
                }
                var contestRow = contestCell.OwningRow;

                if (JudgesDiversTabControl.SelectedTab == JudgeTabPage)
                {
                    CurrentJudgesDataGridView.DataSource =
                        eventGetJudgesInContest(Convert.ToInt16(contestRow.Cells["Id"].Value));

                    CurrentJudgesDataGridView.Columns["Id"].Visible = false;
                    CurrentJudgesDataGridView.Columns["Salt"].Visible = false;
                    CurrentJudgesDataGridView.Columns["Hash"].Visible = false;
                    CurrentJudgesDataGridView.Columns["SSN"].Visible = false;

                    CurrentJudgesDataGridView.Columns["Nationality"].Visible = false;
                }
                else if (JudgesDiversTabControl.SelectedTab == DiverTabPage)
                {
                    CurrentDiversDataGridView.DataSource = eventGetDiversInContest(Convert.ToInt16(contestRow.Cells["Id"].Value));

                    CurrentDiversDataGridView.Columns["Id"].Visible = false;
                    CurrentJudgesDataGridView.Columns["Salt"].Visible = false;
                    CurrentJudgesDataGridView.Columns["Hash"].Visible = false;
                    CurrentDiversDataGridView.Columns["SSN"].Visible = false;
                    CurrentDiversDataGridView.Columns["Nationality"].Visible = false;

                    CurrentDiversDataGridView.Columns["Trick 1"].DisplayIndex = 4;
                    CurrentDiversDataGridView.Columns["Trick 2"].DisplayIndex = 5;
                    CurrentDiversDataGridView.Columns["Trick 3"].DisplayIndex = 6;

                    //Check if there's any current divers.
                    if (CurrentDiversDataGridView.Rows.Count == 0)
                    {
                        return;
                    }

                    foreach (DataGridViewRow row in CurrentDiversDataGridView.Rows)
                    {
                        row.Cells["Trick 1"].Value = eventGetTrickFromParticipant(Convert.ToInt16(contestRow.Cells["Id"].Value), 0, row.Cells["SSN"].Value.ToString());
                        row.Cells["Trick 2"].Value = eventGetTrickFromParticipant(Convert.ToInt16(contestRow.Cells["Id"].Value), 1, row.Cells["SSN"].Value.ToString());
                        row.Cells["Trick 3"].Value = eventGetTrickFromParticipant(Convert.ToInt16(contestRow.Cells["Id"].Value), 2, row.Cells["SSN"].Value.ToString());
                    }
                }
            }

            #region Exceptions

            catch (NullReferenceException nullReferenceException)
            {
                log.Warn("Null reference exception when trying to show judges/divers in a contest",
                    nullReferenceException);
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

            #endregion

        }

        /// <summary>
        /// Occurs when changing tabs. Used to update the current datagrid content immediately.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JudgesDiversTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ContestsDataGridView_SelectionChanged(sender, e);

            if (JudgesDiversTabControl.SelectedTab == JudgeTabPage)
            {
                GlobalJudgesLabel.Visible = true;
                CurrentJudgesLabel.Visible = true;
                GlobalDiversLabel.Visible = false;
                CurrentlDiversLabel.Visible = false;

                GlobalJudgesDataGridView.Focus();
            }
            else if (JudgesDiversTabControl.SelectedTab == DiverTabPage)
            {
                GlobalDiversLabel.Visible = true;
                CurrentlDiversLabel.Visible = true;
                GlobalJudgesLabel.Visible = false;
                CurrentJudgesLabel.Visible = false;

                GlobalDiversDataGridView.Focus();
            }
        }

        #endregion

        #region Click Buttons

        /// <summary>
        /// Occurs when Add judge button is clicked. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Occurs when Add Diver button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddDiverBtn_Click(object sender, EventArgs e)
        {
            CurrentDiversDataGridView.CellValueChanged -= CurrentDiversDataGridView_CellValueChanged;

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

            finally
            {
                CurrentDiversDataGridView.CellValueChanged += CurrentDiversDataGridView_CellValueChanged;
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

            try
            {
                if (isJudge)
                {
                    eventAddJudgeToContest(Convert.ToInt16(contestRow.Cells["Id"].Value),
                        personRow.Cells["ssn"].Value.ToString());
                    log.Debug("Added judge with ssn: " + personRow.Cells["ssn"].Value + "to contest id " +
                              Convert.ToInt16(contestRow.Cells["Id"].Value));
                }
                else
                {
                    eventAddDiverToContest(Convert.ToInt16(contestRow.Cells["Id"].Value),
                        personRow.Cells["ssn"].Value.ToString());
                    log.Debug("Added diver with ssn: " + personRow.Cells["ssn"].Value + "to contest id " +
                              Convert.ToInt16(contestRow.Cells["Id"].Value));
                }
                ErrorProvider.Clear();
            }

            catch (DuplicateNameException duplicateNameException)
            {
                ErrorProvider.SetError(isJudge ? AddJudgeBtn : AddDiverBtn, duplicateNameException.Message);
            }
            catch (IndexOutOfRangeException indexOutOfRangeException)
            {
                ErrorProvider.SetError(isJudge ? AddJudgeBtn : AddDiverBtn, indexOutOfRangeException.Message);
            }

            //force update 
            ContestsDataGridView_SelectionChanged(null, null);
        }

        /// <summary>
        /// Occurs when remove judge button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Occurs when removed diver button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                log.Debug("Removed judge with ssn: " + personRow.Cells["ssn"].Value + "from contest id " + Convert.ToInt16(contestRow.Cells["Id"].Value));
            }
            else
            {
                eventRemoveDiverFromContest(Convert.ToInt16(contestRow.Cells["Id"].Value), personRow.Cells["ssn"].Value.ToString());
                log.Debug("Removed diver with ssn: " + personRow.Cells["ssn"].Value + "from contest id " + Convert.ToInt16(contestRow.Cells["Id"].Value));
            }

            //force update 
            ContestsDataGridView_SelectionChanged(null, null);
        }

        /// <summary>
        /// Creates a new EditContest-form and sends the selected contest. 
        /// Updates the content in Contests data grid after editing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Creates a new LiveFeed-form and shows it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartContestBtn_Click(object sender, EventArgs e)
        {
            if (!IsAllTricksSet())
            {
                MsgBox.CreateInfoBox("All tricks have to be set for all participants.");
                return;
            }

            var selectedContest = ContestsDataGridView.SelectedCells.Cast<DataGridViewCell>().FirstOrDefault();
            var contestRow = selectedContest.OwningRow;

            using (new DimIt())
            using (var liveFeed = new LiveFeed(eventGetFirstClientObjectData,
                                                eventHandleMessage,
                                                eventSendDataToClient,
                                                eventGetContest,
                                                Convert.ToInt16(contestRow.Cells["Id"].Value),
                                                eventStartServer,
                                                eventSetJudgePoint,
                                                eventSetDiverMessage,
                                                eventGetIPForServer,
                                                eventGetTrickDifficultyFromTrickHashTable,
                                                eventSaveContestToDatabase))
            {
                if (liveFeed.ShowDialog(this) == DialogResult.OK)
                {

                }
            }
        }

        /// <summary>
        /// Opens a new Contest Result form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewResultButton_Click(object sender, EventArgs e)
        {
            //using(DimIt d = new DimIt())
            //using (var contestResult = new ContestResult())
            //{
            //    if (contestResult.ShowDialog(this) == DialogResult.OK)
            //    {

            //    }
            //}
        }

        #endregion

        #region Keyboard events

        /// <summary>
        /// Occurs when a key is pressed.
        /// Shows tooltip if controll is pressed.
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (ModifierKeys != Keys.Control)
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }

            ContestsDataGridToolTip.Show("Ctrl+1", ContestsDataGridHiddenLabel);
            JudgesToolTip.Show("Ctrl+2", JudgesHiddenLabel);
            DiversToolTip.Show("Ctrl+3", DiversHiddenLabel);

            StartContestToolTip.Show("Ctrl+S", StartContestBtn);
            EditContestToolTip.Show("Ctrl+E", EditContestBtn);
            ViewResultToolTip.Show("Ctrl+R", viewResultButton);
            //Man ska bara behöva en tooltip, men jag fick inte det att fungera..

            PerformClick(keyData);

            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Performs a click on corresponding button based on keyboard shortkeys.
        /// </summary>
        /// <param name="keyData"></param>
        private void PerformClick(Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Control | Keys.S):
                    StartContestBtn.PerformClick();
                    break;
                case (Keys.Control | Keys.E):
                    EditContestBtn.PerformClick();
                    break;
                case (Keys.Control | Keys.R):
                    viewResultButton.PerformClick();
                    break;
                case (Keys.Control | Keys.D1):
                    ContestsDataGridView.Focus();
                    break;
                case (Keys.Control | Keys.D2):
                    JudgesDiversTabControl.SelectTab(JudgeTabPage);
                    GlobalJudgesDataGridView.Focus();
                    break;
                case (Keys.Control | Keys.D3):
                    JudgesDiversTabControl.SelectTab(DiverTabPage);
                    GlobalDiversDataGridView.Focus();
                    break;
            }
        }

        /// <summary>
        /// Occurs when a button is released.
        /// Hides shortcut tooltips.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartContest_KeyUp(object sender, KeyEventArgs e)
        {
            ContestsDataGridToolTip.RemoveAll();
            JudgesToolTip.RemoveAll();
            DiversToolTip.RemoveAll();
            StartContestToolTip.RemoveAll();
            EditContestToolTip.RemoveAll();
            ViewResultToolTip.RemoveAll();
        }

        /// <summary>
        /// Checks if enter or backspace was pressed.
        /// </summary>
        /// <param name="key"></param>
        private void CheckEnterAndBackspace(Keys key)
        {
            switch (key)
            {
                case Keys.Enter:
                    if (JudgesDiversTabControl.SelectedTab == JudgeTabPage)
                    {
                        AddJudgeBtn_Click(null, null);
                    }
                    else if (JudgesDiversTabControl.SelectedTab == DiverTabPage)
                    {
                        AddPersonToContest(false);
                    }
                    break;
                case Keys.Back:
                    if (JudgesDiversTabControl.SelectedTab == JudgeTabPage)
                    {
                        RemovePersonFromContest(true);
                    }
                    else if (JudgesDiversTabControl.SelectedTab == DiverTabPage)
                    {
                        RemovePersonFromContest(false);
                    }
                    break;

                case (Keys.Right):
                    if (JudgesDiversTabControl.SelectedTab == JudgeTabPage)
                    {
                        GlobalJudgesDataGridView.ClearSelection();
                        CurrentJudgesDataGridView.Select();
                    }
                    else if (JudgesDiversTabControl.SelectedTab == DiverTabPage)
                    {
                        GlobalDiversDataGridView.ClearSelection();
                        CurrentDiversDataGridView.Select();
                    }
                    break;

                case (Keys.Left):
                    if (JudgesDiversTabControl.SelectedTab == JudgeTabPage)
                    {
                        CurrentJudgesDataGridView.ClearSelection();
                        GlobalJudgesDataGridView.Select();
                    }
                    else if (JudgesDiversTabControl.SelectedTab == DiverTabPage)
                    {
                        CurrentDiversDataGridView.ClearSelection();
                        GlobalDiversDataGridView.Select();
                    }

                    break;
            }
        }
        /// <summary>
        /// Occurs when a key is pressed inside GlobalDiversDataGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GlobalDiversDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            CheckEnterAndBackspace(e.KeyCode);
        }

        /// <summary>
        /// Occurs when a key is pressed inside GlobalJudgesDataGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GlobalJudgesDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            CheckEnterAndBackspace(e.KeyCode);
        }

        /// <summary>
        /// Occurs when a key is pressed inside CurrentJudgesDataGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentJudgesDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            CheckEnterAndBackspace(e.KeyCode);
        }

        /// <summary>
        /// Occurs when a key is pressed inside CurrentDiversDataGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentDiversDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            CheckEnterAndBackspace(e.KeyCode);
        }
        #endregion

        /// <summary>
        /// Checks if all tricks are set for every participant in the selected contest.
        /// </summary>
        /// <returns>Returns true if all tricks are set.</returns>
        private bool IsAllTricksSet()
        {
            var contestCell = ContestsDataGridView.SelectedCells.Cast<DataGridViewCell>().FirstOrDefault();

            if (contestCell == null)
            {
                throw new NullReferenceException("cell is null");
            }

            foreach (DataGridViewRow row in CurrentDiversDataGridView.Rows)
            {
                var contestRow = contestCell.OwningRow;

                for (var trickNo = 0; trickNo < 3; trickNo++)
                {
                    var trick = eventGetTrickFromParticipant(Convert.ToInt16(contestRow.Cells["Id"].Value), trickNo,
                        row.Cells["ssn"].Value.ToString());
                    if (trick.Equals(""))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void ShowFinishedContestState()
        {
            // foreach (DataGridViewRow row in ContestsDataGridView.Rows.Cast<DataGridViewRow>().Where(row => row.Cells["isFinished"].Value.Equals("true")))
            foreach (DataGridViewRow row in ContestsDataGridView.Rows)
            {
                if (row.Cells["IsFinished"].Value.Equals(true))
                {
                    row.DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                }
            }
        }

        #region Trick selection
        /// <summary>
        /// Adds a trick for a given participant in the selected contest.
        /// </summary>
        /// <param name="trickName"></param>
        /// <param name="trickNo"></param>
        private void AddTrick(string trickName, int trickNo)
        {
            var personCell = CurrentDiversDataGridView.SelectedCells.Cast<DataGridViewCell>().FirstOrDefault();
            var contestCell = ContestsDataGridView.SelectedCells.Cast<DataGridViewCell>().FirstOrDefault();

            if (personCell == null || contestCell == null)
            {
                throw new NullReferenceException("cell is null");
            }

            var personRow = personCell.OwningRow;
            var contestRow = contestCell.OwningRow;

            eventAddTrickToParticipant(Convert.ToInt16(contestRow.Cells["Id"].Value), trickNo, trickName, personRow.Cells["ssn"].Value.ToString());

            log.Debug("Added trick " + trickName + "to contest id " + Convert.ToInt16(contestRow.Cells["Id"].Value) +
                " for person ssn " + personRow.Cells["ssn"].Value);
        }

        /// <summary>
        /// It's dirty.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentDiversDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (CurrentDiversDataGridView.IsCurrentCellDirty)
            {
                CurrentDiversDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        /// <summary>
        /// Occurs when a value in trick combobox is changed.
        /// Adds the selected trick to the participant.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentDiversDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var comboBox = (DataGridViewComboBoxCell)CurrentDiversDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (comboBox.Value != null)
            {
                AddTrick(comboBox.Value.ToString(), e.ColumnIndex);
            }
        }

        #endregion

    }
}
