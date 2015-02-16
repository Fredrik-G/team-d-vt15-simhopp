using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimhoppGUI
{
    public partial class StartContest : Form
    {
       
        public StartContest()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle; 
            InitializeComponent();
        }

        private void StartContestCloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
