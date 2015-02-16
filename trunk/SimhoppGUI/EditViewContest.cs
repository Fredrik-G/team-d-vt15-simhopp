using System;
using System.Windows.Forms;

namespace SimhoppGUI
{
    public partial class EditViewContest : Form
    {
        public EditViewContest()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();

            Simhopp simhopp = new Simhopp();

            simhopp.CreateContest("Simhoppstavling", "One", "10/10/2010");
            simhopp.CreateContest("sfdsad", "Two", "12/10/2010");
            simhopp.CreateContest("dgfgfd", "Three", "8/10/2010");
            simhopp.CreateContest("asdasd", "Four", "9/10/2010");
            ContestsDataGridView.DataSource = simhopp.ContestList;
            ContestsDataGridView.ReadOnly = true;
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
                EditViewContestEditStartDateTp.Text = row.Cells["Date"].Value.ToString();
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
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                row.Cells["Name"].Value = EditViewContestEditContestNameTb.Text;
                row.Cells["Place"].Value = EditViewContestEditContestPlaceTb.Text;

                string date = EditViewContestEditStartDateTp.Value.Day.ToString() +
                "/" + EditViewContestEditStartDateTp.Value.Month.ToString() +
                "/" + EditViewContestEditStartDateTp.Value.Year.ToString();

                row.Cells["Date"].Value = date;
            }
        }
    }
}
