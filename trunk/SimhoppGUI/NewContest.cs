using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using log4net;

namespace SimhoppGUI
{
    public partial class NewContest : Form
    {
        #region Data
        private static readonly ILog log = LogManager.GetLogger
            (MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Properties

        public string ContestName
        {
            get { return newContestNameTB.Text; }
            set { newContestNameTB.Text = value; }
        }

        public string City
        {
            get { return newContestCityTB.Text; }
            set { newContestCityTB.Text = value; }
        }

        #endregion

        #region Constructor

        public NewContest()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
        }

        #endregion

        #region Events

        /// <summary>
        /// Closes this form if the input is correct. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newContestCreateBtn_Click(object sender, EventArgs e)
        {
            //Måste anropa checkinput här utanför if för att båda check-anropen ska göras. (eller?)
            var correctDate = CheckInput.CheckCorrectStartDate(DateErrorProvider, NewContestStartDateDTP, NewContestEndDateDTP);
            var correctInput = CheckInput.CheckCorrectContestInput(NameErrorProvider, CityErrorProvider, newContestNameTB, newContestCityTB);

            if (correctDate && correctInput)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void CheckEnterOrEscape(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                newContestCreateBtn_Click(null, null);
            }
            else if (e.KeyChar == (char)27)
            {
                Close();
            }
        }

        #endregion

        #region Click Textboxes
        private void newContestNameTB_Click(object sender, EventArgs e)
        {
            newContestNameTB.BackColor = SystemColors.Window;
            newContestNameTB.SelectionStart = 0;
            newContestNameTB.SelectionLength= newContestNameTB.Text.Length;
        }

        private void newContestCityTB_Click(object sender, EventArgs e)
        {
            newContestCityTB.BackColor = SystemColors.Window;
            newContestCityTB.SelectionStart = 0;
            newContestCityTB.SelectionLength = newContestCityTB.Text.Length;
        }

        #endregion

        #region Close button

        private void NewContestCloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}
