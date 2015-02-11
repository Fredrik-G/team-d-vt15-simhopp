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
    public partial class StartScreen : Form
    {
        public StartScreen()
        {
            InitializeComponent();
        }

        private void StartScreenNewContesttBtn_Click(object sender, EventArgs e)
        {
            NewContest newContest = new NewContest();
            newContest.Show();
        }

        private void button2StartScreenStartContestBtn_Click(object sender, EventArgs e)
        {
            StartContest start = new StartContest();
            start.Show();
        }

        private void StartScreenEditViewContestBtn_Click(object sender, EventArgs e)
        {
            Edit_viewContestcs editviewcontest = new Edit_viewContestcs();
            editviewcontest.Show();
        }

        private void StartScreenAddDiverContestBtn_Click(object sender, EventArgs e)
        {
            AddDiver addDiver = new AddDiver();
            addDiver.Show();
        }

        private void StartScreenAddJudgeBtn_Click(object sender, EventArgs e)
        {
            Addjudge addJudge = new Addjudge();
            addJudge.Show();
        }

   


    }
}
