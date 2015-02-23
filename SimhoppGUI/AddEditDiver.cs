using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Simhopp;
using Simhopp.Model;
using Simhopp.View;

namespace SimhoppGUI
{
    public partial class AddEditDiver : Form
    {
        private DelegateAddDiverToList eventAddDiverToList;
        #region Constructor
        public AddEditDiver(DelegateAddDiverToList eventAddDiverToList, DelegateGetDiversList eventGetDiversList, DelegateReadFromFile eventReadFromFile)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();

            this.eventAddDiverToList = eventAddDiverToList;

            if (eventGetDiversList != null)
            {
                //OBS TA BORT READ FILE
                eventReadFromFile("diver.txt");
                //OBS TA BORT READ FILE
                DiversDiverDataGridView.DataSource = eventGetDiversList();
                DiversDiverDataGridView.ReadOnly = true;
            }
        }
        #endregion

        /// <summary>
        /// Shows the selected judge in the textboxes below.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DiversDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                var cell = DiversDiverDataGridView.SelectedCells.Cast<DataGridViewCell>().FirstOrDefault();

                if (cell == null)
                {
                    return;
                }
                var row = cell.OwningRow;

                UpdateTextBoxes(row);

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

        private void UpdateTextBoxes(DataGridViewRow row)
        {
            if (tabControlAddEdit.SelectedTab == tabPageAddDiver)
            {
                AddDiverNameTb.Text = row.Cells["Name"].Value.ToString();
                AddDiverNationaltyTb.Text = row.Cells["Nationality"].Value.ToString();
                AddDiverSSNTb.Text = row.Cells["SSN"].Value.ToString();
            }
            else
            {
                UpdateDiverNameTb.Text = row.Cells["Name"].Value.ToString();
                UpdateDiverNationalityTb.Text = row.Cells["Nationality"].Value.ToString();
                UpdateDiverSSNTb.Text = row.Cells["SSN"].Value.ToString();
            }
        }
        /// <summary>
        /// Updates the selected judge with the input from the textboxes. 
        /// Also checks if the input is correct.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateDiverButton_Click(object sender, EventArgs e)
        {
            try
            {
                var cell = DiversDiverDataGridView.SelectedCells.Cast<DataGridViewCell>().FirstOrDefault();

                if (cell == null)
                {
                    return;
                }

                var row = cell.OwningRow;

                if (CheckInput.CheckCorrectPersonInput(UpdateDiverNameTb, UpdateDiverNationalityTb, UpdateDiverSSNTb))
                {
                    row.Cells["Name"].Value = UpdateDiverNameTb.Text;
                    row.Cells["Nationality"].Value = UpdateDiverNationalityTb.Text;
                    row.Cells["SSN"].Value = UpdateDiverSSNTb.Text;
                }
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
        /// Event that occurs when active tab is changed.
        /// Used to instantly update the contents of the textboxes when changing tabs.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControlAddEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            DiversDataGridView_SelectionChanged(null, null);
        }

        #region Click Textboxes
        private void AddDiverNameTb_Click(object sender, EventArgs e)
        {
            UpdateDiverNameTb.BackColor = SystemColors.Window;
            UpdateDiverNameTb.Text = "";
        }
        private void UpdateDiverNationalityTb_Click(object sender, EventArgs e)
        {
            UpdateDiverNationalityTb.BackColor = SystemColors.Window;
            UpdateDiverNationalityTb.Text = "";
        }

        private void UpdateDiverSSNTb_Click(object sender, EventArgs e)
        {
            UpdateDiverSSNTb.BackColor = SystemColors.Window;
            UpdateDiverSSNTb.Text = "";
        }
        #endregion
        #region Close Button
        private void AddDiverPreviousBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void UpdateDiverPreviousBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        private void AddDiverButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckInput.CheckCorrectPersonInput(AddDiverNameTb, AddDiverNationaltyTb, AddDiverSSNTb))
                {
                    eventAddDiverToList(AddDiverNameTb.Text, AddDiverNationaltyTb.Text, AddDiverSSNTb.Text);
                }
            }
            catch (Exception exception)
            {
                MsgBox.CreateErrorBox(exception.ToString(), MethodBase.GetCurrentMethod().Name);
            }

        }
    }
}
