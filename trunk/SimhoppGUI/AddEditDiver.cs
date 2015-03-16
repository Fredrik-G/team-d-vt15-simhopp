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
    public partial class AddEditDiver : Form
    {
        #region Data
        private DelegateAddDiverToList eventAddDiverToList;
        private DelegateRemoveDiverFromList eventRemoveDiverFromList;
        private DelegateGetDiversList eventGetDiversList;
        private DelegateUpdateDiver eventUpdateDiver;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region Properties
        public string AddName
        {
            get { return AddDiverNameTb.Text; }
            set { AddDiverNameTb.Text = value; }
        }
        public string UpdateName
        {
            get { return UpdateDiverNameTb.Text; }
            set { UpdateDiverNameTb.Text = value; }
        }
        public string AddNationality
        {
            get { return AddDiverNationaltyTb.Text; }
            set { AddDiverNationaltyTb.Text = value; }
        }
        public string UpdateNationality
        {
            get { return UpdateDiverNationalityTb.Text; }
            set { UpdateDiverNationalityTb.Text = value; }
        }
        public string AddSSN
        {
            get { return AddDiverSSNTb.Text; }
            set { AddDiverSSNTb.Text = value; }
        }
        public string UpdateSSN
        {
            get { return UpdateDiverSSNTb.Text; }
            set { UpdateDiverSSNTb.Text = value; }
        }

        #endregion

        #region Constructor
        public AddEditDiver(DelegateAddDiverToList eventAddDiverToList,
            DelegateRemoveDiverFromList eventRemoveDiverFromList,
            DelegateGetDiversList eventGetDiversList,
            DelegateUpdateDiver eventUpdateDiver)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();

            this.eventAddDiverToList = eventAddDiverToList;
            this.eventRemoveDiverFromList = eventRemoveDiverFromList;
            this.eventGetDiversList = eventGetDiversList;
            this.eventUpdateDiver = eventUpdateDiver;

            if (eventGetDiversList != null)
            {
                DiverDataGridView.DataSource = eventGetDiversList();
                DiverDataGridView.ReadOnly = true;
                DiverDataGridView.Columns["Id"].Visible = false;
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Shows the selected diver in the textboxes below.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DiversDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                var cell = DiverDataGridView.SelectedCells.Cast<DataGridViewCell>().FirstOrDefault();

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
        /// Attempts to add a diver to list.
        /// Also checks if the input is correct.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddDiverButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckInput.CheckCorrectPersonInput(NameErrorProvider, NationalityErrorProvider,
                    SSNErrorProvider, AddDiverNameTb, AddDiverNationaltyTb, AddDiverSSNTb))
                {
                    eventAddDiverToList(AddName, AddNationality, AddSSN);
                    NameErrorProvider.Clear();

                    log.Info("Added diver to list (" + AddName + ", " + AddNationality + ", " + AddSSN + ")");
                }
            }
            catch (DuplicateNameException)
            {//diver already exists            
                NameErrorProvider.SetError(AddDiverSSNTb, "Error: Diver already exists");
                log.Debug("Attempted to add a diver which was already in list.");
            }
            catch (Exception exception)
            {
                MsgBox.CreateErrorBox(exception.ToString(), MethodBase.GetCurrentMethod().Name);
                log.Warn("Exception when adding a new diver", exception);
            }
        }

        /// <summary>
        /// Updates the selected diver with the input from the textboxes. 
        /// Also checks if the input is correct.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateDiverButton_Click(object sender, EventArgs e)
        {
            try
            {
                var cell = DiverDataGridView.SelectedCells.Cast<DataGridViewCell>().FirstOrDefault();

                if (cell == null)
                {
                    return;
                }

                var row = cell.OwningRow;

                if (CheckInput.CheckCorrectPersonInput(NameErrorProvider, NationalityErrorProvider,
                     SSNErrorProvider, UpdateDiverNameTb, UpdateDiverNationalityTb, UpdateDiverSSNTb))
                {
                    eventUpdateDiver(Convert.ToInt16(row.Cells["Id"].Value), UpdateName, UpdateNationality, UpdateSSN);

                    //force refresh to show changes. 
                    DiverDataGridView.Refresh();

                    NameErrorProvider.Clear();

                    log.Info("Updated diver (" + UpdateName + ", " + UpdateNationality + ", " + UpdateSSN + ")");
                }
            }
            catch (DuplicateNameException)
            {//diver med det ssn finns redan
                NameErrorProvider.SetError(UpdateDiverSSNTb, "Error: Diver ssn already in use");
                log.Debug("Attempted to add a diver which was already in list.");
            }
            catch (ArgumentNullException nullException)
            {
                MsgBox.CreateErrorBox(nullException.ToString(), MethodBase.GetCurrentMethod().Name);
                log.Warn("Argument null exception when trying to select diver cells", nullException);
            }
            catch (ArgumentOutOfRangeException outOfRangeException)
            {
                MsgBox.CreateErrorBox(outOfRangeException.ToString(), MethodBase.GetCurrentMethod().Name);
                log.Warn("Argument out of range exception when updating a diver", outOfRangeException);
            }
            catch (Exception exception)
            {
                MsgBox.CreateErrorBox(exception.ToString(), MethodBase.GetCurrentMethod().Name);
                log.Warn("Exception when updating a diver", exception);
            }
        }

        /// <summary>
        /// Removes the selected diver from the divers list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateDiverRemoveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                eventRemoveDiverFromList(UpdateSSN);
                log.Info("Removed diver from list (" + UpdateName + ", " + UpdateNationality + ", " + UpdateSSN + ")");
            }

            //Occurs if there is no diver to remove.
            catch (NullReferenceException)
            {
                //do nothing? warn user?
                NameErrorProvider.SetError(UpdateDiverRemoveBtn, "Error: No Diver to remove.");
            }

            //Resets the textboxes if list is empty.
            if (DiverDataGridView.Rows.Count == 0)
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
            DiversDataGridView_SelectionChanged(null, null);
        }

        /// <summary>
        /// Checks if enter was pressed and call event to add diver.
        /// Also checks if escape was pressed and closes this form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddCheckEnterOrEscape(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                AddDiverButton_Click(null, null);
            }
            else if (e.KeyChar == (char)27)
            {
                Close();
            }
        }

        /// <summary>
        /// Checks if enter was pressed and call event to update diver.
        /// Also checks if escape was pressed and closes this form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateCheckEnterOrEscape(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                UpdateDiverButton_Click(null, null);
            }
            else if (e.KeyChar == (char)27)
            {
                Close();
            }
        }

        #endregion

        #region Click Textboxes

        private void UpdateDiverNameTb_Click(object sender, EventArgs e)
        {
            UpdateDiverNameTb.BackColor = SystemColors.Window;
            UpdateDiverNameTb.SelectionStart = 0;
            UpdateDiverNameTb.SelectionLength = UpdateDiverNameTb.Text.Length;
        }
        private void UpdateDiverNationalityTb_Click(object sender, EventArgs e)
        {
            UpdateDiverNationalityTb.BackColor = SystemColors.Window;
            UpdateDiverNationalityTb.SelectionStart = 0;
            UpdateDiverNationalityTb.SelectionLength = UpdateDiverNationalityTb.Text.Length;
        }

        private void UpdateDiverSSNTb_Click(object sender, EventArgs e)
        {
            UpdateDiverSSNTb.BackColor = SystemColors.Window;
            UpdateDiverSSNTb.SelectionStart = 0;
            UpdateDiverSSNTb.SelectionLength = UpdateDiverSSNTb.Text.Length;
        }

        private void AddDiverNameTb_Click(object sender, EventArgs e)
        {
            AddDiverNameTb.BackColor = SystemColors.Window;
            AddDiverNameTb.SelectionStart = 0;
            AddDiverNameTb.SelectionLength = AddDiverNameTb.Text.Length;
        }
        private void AddDiverNationaltyTb_Click(object sender, EventArgs e)
        {
            AddDiverNationaltyTb.BackColor = SystemColors.Window;
            AddDiverNationaltyTb.SelectionStart = 0;
            AddDiverNationaltyTb.SelectionLength = AddDiverNationaltyTb.Text.Length;
        }

        private void AddDiverSSNTb_Click(object sender, EventArgs e)
        {
            AddDiverSSNTb.BackColor = SystemColors.Window;
            AddDiverSSNTb.SelectionStart = 0;
            AddDiverSSNTb.SelectionLength = AddDiverSSNTb.Text.Length;
        }

        #endregion

        #region Close Buttons
        private void AddDiverPreviousBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void UpdateDiverPreviousBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

    }
}
