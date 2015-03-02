using System;
using System.Reflection;
using System.Windows.Forms;
using log4net;
using Simhopp;
using Simhopp.View;

namespace SimhoppGUI
{
    public partial class EditContest : Form
    {
        #region Data

        private DelegateUpdateContest eventUpdateContest;
        private int contestId;

        private static readonly ILog log = LogManager.GetLogger
            (MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

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
        public EditContest(DataGridViewCell cell, DelegateUpdateContest eventUpdateContest)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();

            this.eventUpdateContest = eventUpdateContest;

            try
            {
                var contestRow = cell.OwningRow;

                contestId = Convert.ToInt16(contestRow.Cells["Id"].Value);
                ContestName = contestRow.Cells["Name"].Value.ToString();
                Place = contestRow.Cells["Place"].Value.ToString();
                StartDate = contestRow.Cells["StartDate"].Value.ToString();
                EndDate = contestRow.Cells["EndDate"].Value.ToString();
            }
            catch (ArgumentOutOfRangeException outOfRangeException)
            {
                MsgBox.CreateErrorBox(outOfRangeException.ToString(), MethodBase.GetCurrentMethod().Name);
                log.Warn("Argument out of range exception when attempting to edit a contest", outOfRangeException);
            }
            catch (InvalidOperationException invalidOperationException)
            {
                MsgBox.CreateErrorBox(invalidOperationException.ToString(), MethodBase.GetCurrentMethod().Name);
                log.Warn("Invalid operation exception when attempting to edit a contest", invalidOperationException);
            }
            catch (Exception exception)
            {
                MsgBox.CreateErrorBox(exception.ToString(), MethodBase.GetCurrentMethod().Name);
                log.Warn("Exception when attempting to edit a contest", exception);
            }
        }
        #endregion

        #region Events

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
                var correctStartDate = CheckInput.CheckCorrectDate(startDate);

                var endDate = StartScreen.CreateDateString(EditViewContestEditEndtDateTp);
                var correctEndDate = CheckInput.CheckCorrectDate(endDate);

                if (CheckInput.CheckCorrectContestInput(NameErrorProvider,
                    PlaceErrorProvider,
                    EditViewContestEditContestNameTb,
                    EditViewContestEditContestPlaceTb) && correctStartDate && correctEndDate)
                {
                    eventUpdateContest(contestId, EditViewContestEditContestNameTb.Text,
                         EditViewContestEditContestPlaceTb.Text, startDate, endDate);

                    log.Info("Updated contest with (id,name,place,startdate,enddate): " + contestId+EditViewContestEditContestNameTb.Text + 
                        EditViewContestEditContestPlaceTb.Text + startDate + endDate);

                    DialogResult = DialogResult.OK;
                }
            }

            catch (ArgumentNullException nullException)
            {
                MsgBox.CreateErrorBox(nullException.ToString(), MethodBase.GetCurrentMethod().Name);
                log.Warn("Argument null exception when attempting to update a contest", nullException);
            }
            catch (ArgumentOutOfRangeException outOfRangeException)
            {
                MsgBox.CreateErrorBox(outOfRangeException.ToString(), MethodBase.GetCurrentMethod().Name);
                log.Warn("Out of range exception when attempting to update a contest", outOfRangeException);
            }
            catch (Exception exception)
            {
                MsgBox.CreateErrorBox(exception.ToString(), MethodBase.GetCurrentMethod().Name);
                log.Warn("Exception when attempting to update a contest", exception);
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
            EditViewContestEditContestNameTb.SelectionStart = 0;
            EditViewContestEditContestNameTb.SelectionLength = EditViewContestEditContestNameTb.Text.Length;
        }

        private void EditViewContestEditContestPlaceTb_Click(object sender, EventArgs e)
        {
            EditViewContestEditContestPlaceTb.SelectionStart = 0;
            EditViewContestEditContestPlaceTb.SelectionLength = EditViewContestEditContestPlaceTb.Text.Length;
        }
        #endregion
    }
}
