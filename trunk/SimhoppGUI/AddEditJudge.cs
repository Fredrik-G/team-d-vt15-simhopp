using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Simhopp.View;

namespace SimhoppGUI
{
    public partial class AddEditJudge : Form
    {
        private DelegateAddJudgeToList eventAddJudgeToList;
        private DelegateRemoveJudgeFromList eventRemoveJudgeFromList;

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
            UpdateJudgeNameTb.Text = row.Cells["Name"].Value.ToString();
            UpdateJudgeNationalityTb.Text = row.Cells["Nationality"].Value.ToString();
            UpdateJudgeSSNTb.Text = row.Cells["SSN"].Value.ToString();
        }

        private void AddJudgeButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckInput.CheckCorrectPersonInput(AddJudgeNameTb, AddJudgeNationaltyTb, AddJudgeSSNTb))
                {
                    eventAddJudgeToList(AddJudgeNameTb.Text, AddJudgeNationaltyTb.Text, AddJudgeSSNTb.Text);
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
                    row.Cells["Name"].Value = UpdateJudgeNameTb.Text;
                    row.Cells["Nationality"].Value = UpdateJudgeNationalityTb.Text;
                    row.Cells["SSN"].Value = UpdateJudgeSSNTb.Text;
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
            eventRemoveJudgeFromList(UpdateJudgeSSNTb.Text);

            //Resets the textboxes if list is empty.
            if (JudgesDataGridView.Rows.Count == 0)
            {
                UpdateJudgeNameTb.Text = "";
                UpdateJudgeNationalityTb.Text = "";
                UpdateJudgeSSNTb.Text = "";
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
            UpdateJudgeNameTb.Text = "";
        }
        private void UpdateJudgeNationalityTb_Click(object sender, EventArgs e)
        {
            UpdateJudgeNationalityTb.BackColor = SystemColors.Window;
            UpdateJudgeNationalityTb.Text = "";
        }

        private void UpdateJudgeSSNTb_Click(object sender, EventArgs e)
        {
            UpdateJudgeSSNTb.BackColor = SystemColors.Window;
            UpdateJudgeSSNTb.Text = "";
        }
        #endregion
        #region Close Button
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
