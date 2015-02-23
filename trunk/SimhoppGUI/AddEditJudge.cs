using System;
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
        public AddEditJudge
            (DelegateAddJudgeToList eventAddJudgeToList,
            DelegateRemoveJudgeFromList eventRemoveJudgeFromList,
            DelegateGetJudgesList eventGetJudgesList,
            DelegateReadFromFile eventReadFromFile
            )
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();

            this.eventAddJudgeToList = eventAddJudgeToList;
            this.eventRemoveJudgeFromList = eventRemoveJudgeFromList;

            if (eventGetJudgesList != null)
            {
                //OBS TA BORT READ FILE
                eventReadFromFile("judge.txt");
                //OBS TA BORT READ FILE
                JudgesDataGridView.DataSource = eventGetJudgesList();
                JudgesDataGridView.ReadOnly = true;
            }
        }
        #endregion

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
            UpdateName = row.Cells["Name"].Value.ToString();
            UpdateNationality = row.Cells["Nationality"].Value.ToString();
            UpdateSSN = row.Cells["SSN"].Value.ToString();
        }

        private void AddJudgeButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckInput.CheckCorrectPersonInput(AddJudgeNameTb, AddJudgeNationaltyTb, AddJudgeSSNTb))
                {
                    eventAddJudgeToList(AddName, AddNationality, AddSSN);
                }
            }
            catch (Exception exception)
            {
                MsgBox.CreateErrorBox(exception.ToString(), MethodBase.GetCurrentMethod().Name);
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

                if (CheckInput.CheckCorrectPersonInput(UpdateJudgeNameTb, UpdateJudgeNationalityTb, UpdateJudgeSSNTb))
                {
                    row.Cells["Name"].Value = UpdateName;
                    row.Cells["Nationality"].Value = UpdateNationality;
                    row.Cells["SSN"].Value = UpdateSSN;
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
        /// Removes the selected judge from the judge list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateJudgeRemoveBtn_Click(object sender, EventArgs e)
        {
            eventRemoveJudgeFromList(UpdateSSN);

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
            JudgesDataGridView_SelectionChanged(null, null);
        }

        #region Click Textboxes
        private void AddJudgeNameTb_Click(object sender, EventArgs e)
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
