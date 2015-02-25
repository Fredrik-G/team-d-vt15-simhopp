using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Simhopp;
using Simhopp.Model;

namespace SimhoppGUI
{
    public partial class EditContest : Form
    {
        #region Properties
        public string ContestName
        {
            get { return EditViewContestEditContestNameTb.Text; }
            set { EditViewContestEditContestNameTb.Text = value; }
        }

        public string Place
        {
            get { return EditViewContestEditContestPlaceTb.Text; }
            set { EditViewContestEditContestPlaceTb.Text = value; }
        }

        public string StartDate
        {
            get { return EditViewContestEditStartDateTp.Text; }
            set { EditViewContestEditStartDateTp.Text = value; }
        }

        public string EndDate
        {
            get { return EditViewContestEditEndtDateTp.Text; }
            set { EditViewContestEditEndtDateTp.Text = value; }
        }

        #endregion

        #region Constructor
        public EditContest(DataGridViewCell cell)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();

            try
            {
                var contestRow = cell.OwningRow;
                ContestName = contestRow.Cells["Name"].Value.ToString();
                Place = contestRow.Cells["Place"].Value.ToString();
                StartDate = contestRow.Cells["StartDate"].Value.ToString();
                EndDate = contestRow.Cells["EndDate"].Value.ToString();
            }
            catch (ArgumentOutOfRangeException outOfRangeException)
            {
                MsgBox.CreateErrorBox(outOfRangeException.ToString(), MethodBase.GetCurrentMethod().Name);
            }
            catch (InvalidOperationException invalidOperationException)
            {
                MsgBox.CreateErrorBox(invalidOperationException.ToString(), MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception exception)
            {
                MsgBox.CreateErrorBox(exception.ToString(), MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        #region Events

        private void EditContest_Load(object sender, EventArgs e)
        {
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

                if (CheckInput.CheckCorrectContestInput(InputErrorProvider,
                    EditViewContestEditContestNameTb,
                    EditViewContestEditContestPlaceTb) && correctStartDate && correctEndDate)
                {
                    //event update 

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

        #endregion

        #region Close Button
        private void EditViewContestCloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Click Textboxes
        private void EditViewContestEditContestNameTb_Click(object sender, EventArgs e)
        {
            ContestName = "";
        }

        private void EditViewContestEditContestPlaceTb_Click(object sender, EventArgs e)
        {
            Place = "";
        }
        #endregion
    }
}
