using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Simhopp;
using Simhopp.View;

namespace SimhoppGUI
{
    public partial class AddEditJudge : Form
    {
        #region Data
        private DelegateAddJudgeToList eventAddJudgeToList;
        private DelegateRemoveJudgeFromList eventRemoveJudgeFromList;
        private DelegateUpdateJudge eventUpdateJudge;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region Properties
        public string AddName
        {
            get { return AddJudgeNameTb.Text; }
            set { AddJudgeNameTb.Text = value; }
        }
        public string UpdateName
        {
            get { return UpdateJudgeNameTb.Text; }
            set { UpdateJudgeNameTb.Text = value; }
        }
        public string AddNationality
        {
            get { return AddJudgeNationaltyTb.Text; }
            set { AddJudgeNationaltyTb.Text = value; }
        }
        public string UpdateNationality
        {
            get { return UpdateJudgeNationalityTb.Text; }
            set { UpdateJudgeNationalityTb.Text = value; }
        }
        public string AddSSN
        {
            get { return AddJudgeSSNTb.Text; }
            set { AddJudgeSSNTb.Text = value; }
        }
        public string UpdateSSN
        {
            get { return UpdateJudgeSSNTb.Text; }
            set { UpdateJudgeSSNTb.Text = value; }
        } 
        #endregion

        #region Constructor
        public AddEditJudge( DelegateAddJudgeToList eventAddJudgeToList,
            DelegateRemoveJudgeFromList eventRemoveJudgeFromList,
            DelegateGetJudgesList eventGetJudgesList,
            DelegateUpdateJudge eventUpdateJudge)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();

            this.eventAddJudgeToList = eventAddJudgeToList;
            this.eventRemoveJudgeFromList = eventRemoveJudgeFromList;
            this.eventUpdateJudge = eventUpdateJudge;

            if (eventGetJudgesList != null)
            {
                JudgesDataGridView.DataSource = eventGetJudgesList();
                JudgesDataGridView.ReadOnly = true;
                JudgesDataGridView.Columns["Id"].Visible = false;
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Shows the selected judge in the textboxes below.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JudgesDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                var cell = JudgesDataGridView.SelectedCells.Cast<DataGridViewCell>().FirstOrDefault();

                if (cell == null)
                {
                    return;
                }
                var row = cell.OwningRow;

                UpdateName = row.Cells["Name"].Value.ToString();
                UpdateNationality = row.Cells["Nationality"].Value.ToString();
                UpdateSSN = row.Cells["SSN"].Value.ToString();

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
        /// Attempts to add a judge to list.
        /// Also checks if the input is correct.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddJudgeButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckInput.CheckCorrectPersonInput(InputErrorProvider, AddJudgeNameTb, AddJudgeNationaltyTb, AddJudgeSSNTb))
                {
                    eventAddJudgeToList(AddName, AddNationality, AddSSN);
                    InputErrorProvider.Clear();

                    log.Info("Added judge to list (" + AddName + ", " + AddNationality + ", " + AddSSN + ")");
                }
            }
            catch (DuplicateNameException)
            {//judge already exists
                InputErrorProvider.SetError(AddJudgeSSNTb, "Error: Judge already exists");
                log.Debug("Attempted to add a judge which was already in list.");
            }
            catch (Exception exception)
            {
                MsgBox.CreateErrorBox(exception.ToString(), MethodBase.GetCurrentMethod().Name);
                log.Warn("Exception when adding a new judge", exception);
            }
        }

        /// <summary>
        /// Updates the selected judge with the input from the textboxes. 
        /// Also checks if the input is correct.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateJudgeButton_Click(object sender, EventArgs e)
        {
            try
            {
                var cell = JudgesDataGridView.SelectedCells.Cast<DataGridViewCell>().FirstOrDefault();

                if (cell == null)
                {
                    return;
                }

                var row = cell.OwningRow;

                if (CheckInput.CheckCorrectPersonInput(InputErrorProvider,
                    UpdateJudgeNameTb,
                    UpdateJudgeNationalityTb,
                    UpdateJudgeSSNTb))
                {
                    eventUpdateJudge(Convert.ToInt16(row.Cells["Id"].Value), UpdateName, UpdateNationality, UpdateSSN);

                    //force refresh to show changes. 
                    JudgesDataGridView.Refresh();

                    InputErrorProvider.Clear();

                    log.Info("Updated judge (" + UpdateName + ", " + UpdateNationality + ", " + UpdateSSN + ")");
                }
            }
            catch (DuplicateNameException)
            {//judge med det ssn finns redan
                InputErrorProvider.SetError(UpdateJudgeSSNTb, "Error: Judge ssn already in use");
                log.Debug("Attempted to add a judge which was already in list.");
            }
            catch (ArgumentNullException nullException)
            {
                MsgBox.CreateErrorBox(nullException.ToString(), MethodBase.GetCurrentMethod().Name);
                log.Warn("Argument null exception when trying to select judge cells", nullException);
            }
            catch (ArgumentOutOfRangeException outOfRangeException)
            {
                MsgBox.CreateErrorBox(outOfRangeException.ToString(), MethodBase.GetCurrentMethod().Name);
                log.Warn("Argument out of range exception when updating a judge", outOfRangeException);
            }
            catch (Exception exception)
            {
                MsgBox.CreateErrorBox(exception.ToString(), MethodBase.GetCurrentMethod().Name);
                log.Warn("Exception when updating a judge", exception);
            }
        }

        /// <summary>
        /// Removes the selected judge from the judge list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateJudgeRemoveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                eventRemoveJudgeFromList(UpdateSSN);
                log.Info("Removed judge from list (" + UpdateName + ", " + UpdateNationality + ", " + UpdateSSN + ")");
            }

            //Occurs if there is no judges to remove.
            catch (NullReferenceException)
            {
                //do nothing? warn user?
                InputErrorProvider.SetError(UpdateJudgeRemoveBtn, "Error: No judge to remove.");
            }
                      
            //Resets the textboxes if list is empty.
            if (JudgesDataGridView.Rows.Count == 0)
            {
                UpdateName = "";
                UpdateNationality = "";
                UpdateSSN = "";
            }         
        }

        /// <summary>
        /// Event that occurs when active tab is changed.
        /// Used to instantly update the contents of the textboxes when changing tabs.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControlAddEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            InputErrorProvider.Clear();
            JudgesDataGridView_SelectionChanged(null, null);
        }

        #endregion

        #region Click Textboxes

        private void UpdateJudgeNameTb_Click(object sender, EventArgs e)
        {
            UpdateJudgeNameTb.BackColor = SystemColors.Window;
            UpdateName = "";
        }
        private void UpdateJudgeNationalityTb_Click(object sender, EventArgs e)
        {
            UpdateJudgeNationalityTb.BackColor = SystemColors.Window;
            UpdateNationality = "";
        }

        private void UpdateJudgeSSNTb_Click(object sender, EventArgs e)
        {
            UpdateJudgeSSNTb.BackColor = SystemColors.Window;
            UpdateSSN = "";
        }

        private void AddJudgeNameTb_Click(object sender, EventArgs e)
        {
            AddJudgeNameTb.BackColor = SystemColors.Window;
            AddName = "";
        }
        private void AddJudgeNationaltyTb_Click(object sender, EventArgs e)
        {
            AddJudgeNationaltyTb.BackColor = SystemColors.Window;
            AddNationality = "";
        }

        private void AddJudgeSSNTb_Click(object sender, EventArgs e)
        {
            AddJudgeSSNTb.BackColor = SystemColors.Window;
            AddSSN = "";
        }
        #endregion

        #region Close Buttons
        private void AddJudgePreviousBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void UpdateJudgePreviousBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
