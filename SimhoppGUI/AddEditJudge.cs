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
        public AddEditJudge(DelegateAddJudgeToList eventAddJudgeToList,
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
                JudgesDataGridView.Columns["Salt"].Visible = false;
                JudgesDataGridView.Columns["Hash"].Visible = false;
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
                if (CheckInput.CheckCorrectPersonInput(NameErrorProvider, NationalityErrorProvider,
                    SSNErrorProvider, AddJudgeNameTb, AddJudgeNationaltyTb, AddJudgeSSNTb))
                {
                    eventAddJudgeToList(AddName, AddNationality, AddSSN);
                    NameErrorProvider.Clear();

                    log.Info("Added judge to list (" + AddName + ", " + AddNationality + ", " + AddSSN + ")");
                }
            }
            catch (DuplicateNameException)
            {//judge already exists            
                NameErrorProvider.SetError(AddJudgeSSNTb, "Error: Judge already exists");
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

                if (CheckInput.CheckCorrectPersonInput(NameErrorProvider, NationalityErrorProvider,
                     SSNErrorProvider, UpdateJudgeNameTb, UpdateJudgeNationalityTb, UpdateJudgeSSNTb))
                {
                    eventUpdateJudge(Convert.ToInt16(row.Cells["Id"].Value), UpdateName, UpdateNationality, UpdateSSN);

                    //force refresh to show changes. 
                    JudgesDataGridView.Refresh();

                    NameErrorProvider.Clear();

                    log.Info("Updated judge (" + UpdateName + ", " + UpdateNationality + ", " + UpdateSSN + ")");
                }
            }
            catch (DuplicateNameException)
            {//judge med det ssn finns redan
                NameErrorProvider.SetError(UpdateJudgeSSNTb, "Error: Judge ssn already in use");
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
                NameErrorProvider.SetError(UpdateJudgeRemoveBtn, "Error: No judge to remove.");
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
            NameErrorProvider.Clear();
            JudgesDataGridView_SelectionChanged(null, null);
        }

        /// <summary>
        /// Checks if enter was pressed. 
        /// If so, call event to add judge.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckEnterAdd(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                AddJudgeButton_Click(null, null);
            }
        }

        /// <summary>
        /// Checks if enter was pressed. 
        /// If so, call event to update judge.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckEnterUpdate(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                UpdateJudgeButton_Click(null, null);
            }
        }

        #endregion

        #region Click Textboxes

        private void UpdateJudgeNameTb_Click(object sender, EventArgs e)
        {
            UpdateJudgeNameTb.BackColor = SystemColors.Window;
            UpdateJudgeNameTb.SelectionStart = 0;
            UpdateJudgeNameTb.SelectionLength = UpdateJudgeNameTb.Text.Length;
        }
        private void UpdateJudgeNationalityTb_Click(object sender, EventArgs e)
        {
            UpdateJudgeNationalityTb.BackColor = SystemColors.Window;
            UpdateJudgeNationalityTb.SelectionStart = 0;
            UpdateJudgeNationalityTb.SelectionLength = UpdateJudgeNationalityTb.Text.Length;
        }

        private void UpdateJudgeSSNTb_Click(object sender, EventArgs e)
        {
            UpdateJudgeSSNTb.BackColor = SystemColors.Window;
            UpdateJudgeSSNTb.SelectionStart = 0;
            UpdateJudgeSSNTb.SelectionLength = UpdateJudgeSSNTb.Text.Length;
        }

        private void AddJudgeNameTb_Click(object sender, EventArgs e)
        {
            AddJudgeNameTb.BackColor = SystemColors.Window;
            AddJudgeNameTb.SelectionStart = 0;
            AddJudgeNameTb.SelectionLength = AddJudgeNameTb.Text.Length;
        }
        private void AddJudgeNationaltyTb_Click(object sender, EventArgs e)
        {
            AddJudgeNationaltyTb.BackColor = SystemColors.Window;
            AddJudgeNationaltyTb.SelectionStart = 0;
            AddJudgeNationaltyTb.SelectionLength = AddJudgeNationaltyTb.Text.Length;
        }

        private void AddJudgeSSNTb_Click(object sender, EventArgs e)
        {
            AddJudgeSSNTb.BackColor = SystemColors.Window;
            AddJudgeSSNTb.SelectionStart = 0;
            AddJudgeSSNTb.SelectionLength = AddJudgeSSNTb.Text.Length;
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
