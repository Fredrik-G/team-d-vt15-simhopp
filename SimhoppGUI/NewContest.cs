using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Simhopp.Model;
namespace SimhoppGUI
{
    public partial class NewContest : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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

        public NewContest()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
        }

        #region Events

        /// <summary>
        /// Closes this form if the input is correct. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newContestCreateBtn_Click(object sender, EventArgs e)
        {
            if (CheckInput.CheckCorrectContestInput(InputErrorProvider, newContestNameTB, newContestCityTB))
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void newContestNameTB_Click(object sender, EventArgs e)
        {
            newContestNameTB.BackColor = SystemColors.Window;
            ContestName = "";
        }

        private void newContestCityTB_Click(object sender, EventArgs e)
        {
            newContestCityTB.BackColor = SystemColors.Window;
            City = "";
        }

        #endregion
        private void NewContestCloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
