using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SimhoppGUI.Model;
namespace SimhoppGUI.View
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

        private void newContestCreateBtn_Click(object sender, EventArgs e)
        {
            if (!Contest.CheckCorrectName(newContestNameTB.Text))
            {
                newContestNameTB.BackColor = Color.Red;
            }
            if (!Contest.CheckCorrectPlace(newContestCityTB.Text))
            {
                newContestCityTB.BackColor = Color.Red;
            }

            if (Contest.CheckCorrectName(newContestNameTB.Text) &&
                Contest.CheckCorrectPlace(newContestCityTB.Text))
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void newContestNameTB_Click(object sender, EventArgs e)
        {
            newContestNameTB.BackColor = System.Drawing.SystemColors.Window;
            newContestNameTB.Text = "";
        }

        private void newContestCityTB_Click(object sender, EventArgs e)
        {
            newContestCityTB.BackColor = System.Drawing.SystemColors.Window;
            newContestCityTB.Text = "";
        }

    }
}
