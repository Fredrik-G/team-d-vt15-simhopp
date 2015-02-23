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
    public partial class EditViewContest : Form
    {
        #region Constructor
        public EditViewContest(DelegateGetContestsList eventGetContestsList)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();

            if (eventGetContestsList != null)
            {
                ContestsDataGridView.DataSource = eventGetContestsList();
                ContestsDataGridView.ReadOnly = true;
            }
        }
        #endregion

        /// <summary>
        /// Shows the selected contest in the textboxes below.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContestsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            var cell = ContestsDataGridView.SelectedCells.Cast<DataGridViewCell>().FirstOrDefault();

            if (cell == null)
            {
                return;
            }
            try
            {
                var row = cell.OwningRow;
                EditViewContestEditContestNameTb.Text = row.Cells["Name"].Value.ToString();
                EditViewContestEditContestPlaceTb.Text = row.Cells["Place"].Value.ToString();

                var date = row.Cells["StartDate"].Value.ToString().Split('/');
                var temp = row.Cells["EndDate"].Value.ToString().Split('/');

                date[0] = temp[1];
                date[1] = temp[0];
                var s = date[0] + "/" + date[1] + "/" + date[2];
                EditViewContestEditStartDateTp.Text = s;
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
        /// Updates the selected contest with the input from the textboxes. 
        /// Also checks if the input is correct.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditViewContestEditChangesBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var cell = ContestsDataGridView.SelectedCells.Cast<DataGridViewCell>().FirstOrDefault();

                if (cell == null)
                {
                    return;
                }

                var row = cell.OwningRow;

                var startDate = StartScreen.CreateDateString(EditViewContestEditStartDateTp);
                var correctStartDate = Contest.CheckCorrectDate(startDate);

                var endDate = StartScreen.CreateDateString(EditViewContestEditEndtDateTp);
                var correctEndDate = Contest.CheckCorrectDate(endDate);

                //Kan datum ens bli fel med DateTimePicker?
                if (!correctStartDate)
                {
                    EditViewContestEditStartDateTp.BackColor = Color.Red;
                }
                if (!correctEndDate)
                {
                    EditViewContestEditEndtDateTp.BackColor = Color.Red;
                }

                if (CheckInput.CheckCorrectContestInput(EditViewContestEditContestNameTb,
                    EditViewContestEditContestPlaceTb) && correctStartDate && correctEndDate)
                {
                    row.Cells["Name"].Value = EditViewContestEditContestNameTb.Text;
                    row.Cells["Place"].Value = EditViewContestEditContestPlaceTb.Text;
                    row.Cells["StartDate"].Value = startDate;
                    row.Cells["EndDate"].Value = endDate;
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
        #region Close Button
        private void EditViewContestCloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
        #region Click Textboxes
        private void EditViewContestEditContestNameTb_Click(object sender, EventArgs e)
        {
            EditViewContestEditContestNameTb.BackColor = SystemColors.Window;
            EditViewContestEditContestNameTb.Text = "";
        }

        private void EditViewContestEditContestPlaceTb_Click(object sender, EventArgs e)
        {
            EditViewContestEditContestPlaceTb.BackColor = SystemColors.Window;
            EditViewContestEditContestPlaceTb.Text = "";
        }
        #endregion
    }
}
