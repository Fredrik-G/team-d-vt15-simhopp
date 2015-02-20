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
        public NewContest()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
        }

        private void NewContestCloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Closes this form if the input is correct. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newContestCreateBtn_Click(object sender, EventArgs e)
        {
            //var correctDate = CheckInput.CheckCorrectDate(NewContestStartDateDTP, NewContestEndDateDTP);
            if(CheckInput.CheckCorrectContestInput(newContestNameTB, newContestCityTB))
            {
               DialogResult = DialogResult.OK; 
            }          
        }

        private void newContestNameTB_Click(object sender, EventArgs e)
        {
            newContestNameTB.BackColor = SystemColors.Window;
            newContestNameTB.Text = "";
        }

        private void newContestCityTB_Click(object sender, EventArgs e)
        {
            newContestCityTB.BackColor = SystemColors.Window;
            newContestCityTB.Text = "";
        }

    }
}
