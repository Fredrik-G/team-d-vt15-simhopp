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
    public partial class JudgeClient : Form
    {
        public JudgeClient()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void connectToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Login LoginScreen = new Login();
            LoginScreen.Show();
        }

    

        private void button2_Click_1(object sender, EventArgs e)
        {
            NewContest start = new NewContest();
            start.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Addjudge add = new Addjudge();
            add.Show();
        }

  
    }
}
