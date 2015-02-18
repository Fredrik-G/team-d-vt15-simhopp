using System;
using System.Drawing;
using System.Windows.Forms;
using Simhopp.Model;
using Simhopp.View;
namespace SimhoppGUI
{
    public partial class EditViewContest : Form
    {
        public EditViewContest(DelegateGetContestsList eventGetContestsList)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();

            if (eventGetContestsList != null)
            {
                ContestsDataGridView.DataSource = eventGetContestsList();
            }
        }

        private void EditViewContestCloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ContestsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in ContestsDataGridView.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                EditViewContestEditContestNameTb.Text = row.Cells["Name"].Value.ToString();
                EditViewContestEditContestPlaceTb.Text = row.Cells["Place"].Value.ToString();

                var date = row.Cells["Date"].Value.ToString().Split('/');
                var temp = row.Cells["Date"].Value.ToString().Split('/');

                date[0] = temp[1];
                date[1] = temp[0];
                var s = date[0] + "/" + date[1] + "/" + date[2];
                EditViewContestEditStartDateTp.Text = s;
            }
        }

        private void EditViewContestEditChangesBtn_Click(object sender, EventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in ContestsDataGridView.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell == null)
            {
                return;
            }
            var row = cell.OwningRow;
               
            var startDate = EditViewContestEditStartDateTp.Value.Day.ToString() +
                            "/" + EditViewContestEditStartDateTp.Value.Month.ToString() +
                            "/" + EditViewContestEditStartDateTp.Value.Year.ToString();
            var correctStartDate = Contest.CheckCorrectDate(startDate);

            var endDate = EditViewContestEditStartDateTp.Value.Day.ToString() +
                          "/" + EditViewContestEditStartDateTp.Value.Month.ToString() +
                          "/" + EditViewContestEditStartDateTp.Value.Year.ToString();
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

            if (CheckInput.CheckCorrectInput(EditViewContestEditContestNameTb,
                EditViewContestEditContestPlaceTb) && correctStartDate && correctEndDate)
            {
                row.Cells["Name"].Value = EditViewContestEditContestNameTb.Text;
                row.Cells["Place"].Value = EditViewContestEditContestPlaceTb.Text;
                row.Cells["StartDate"].Value = startDate;
                row.Cells["EndDate"].Value = endDate;
            }
        }

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
    }
}
