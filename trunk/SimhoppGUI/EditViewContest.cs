﻿using System;
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

        #region Methods

        /// <summary>
        /// Creates a date string used by DateTimePicker.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="cellName"></param>
        /// <returns></returns>
        private string CreateDateTimePicker(DataGridViewRow row, string cellName)
        {
            var date = row.Cells[cellName].Value.ToString().Split('/');
            var temp = row.Cells[cellName].Value.ToString().Split('/');

            date[0] = temp[1];
            date[1] = temp[0];
            return date[0] + "/" + date[1] + "/" + date[2];
        }

        #endregion

        #region Events

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

                ContestName = row.Cells["Name"].Value.ToString();
                Place = row.Cells["Place"].Value.ToString();
                StartDate = CreateDateTimePicker(row, "StartDate");
                EndDate = CreateDateTimePicker(row, "EndDate");
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
                var correctStartDate = CheckInput.CheckCorrectDate(startDate);

                var endDate = StartScreen.CreateDateString(EditViewContestEditEndtDateTp);
                var correctEndDate = CheckInput.CheckCorrectDate(endDate);

                //Kan datum ens bli fel med DateTimePicker?
                if (!correctStartDate)
                {
                    EditViewContestEditStartDateTp.BackColor = Color.Red;
                }
                if (!correctEndDate)
                {
                    EditViewContestEditEndtDateTp.BackColor = Color.Red;
                }

                //if (CheckInput.CheckCorrectContestInput(EditViewContestEditContestNameTb,
                //    EditViewContestEditContestPlaceTb) && correctStartDate && correctEndDate)
                //{
                //    row.Cells["Name"].Value = Name;
                //    row.Cells["Place"].Value = Place;
                //    row.Cells["StartDate"].Value = startDate;
                //    row.Cells["EndDate"].Value = endDate;
                //}
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
            EditViewContestEditContestNameTb.BackColor = SystemColors.Window;
            Name = "";
        }

        private void EditViewContestEditContestPlaceTb_Click(object sender, EventArgs e)
        {
            EditViewContestEditContestPlaceTb.BackColor = SystemColors.Window;
            Place = "";
        }
        #endregion
    }
}
