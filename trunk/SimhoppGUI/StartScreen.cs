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
            this.FormBorderStyle = FormBorderStyle.FixedSingle; 
            InitializeComponent();
        }
        private void StartScreenNewContesttBtn_Click(object sender, EventArgs e)
        {
            using (new DialogOverlay())
            using (NewContest newContest = new NewContest())
            {
                if (newContest.ShowDialog(this) == DialogResult.OK)
                {

                    newContest.Show();
                }
            } 
        }
        private void button2StartScreenStartContestBtn_Click(object sender, EventArgs e)
        {
            using (new DialogOverlay())
            using (StartContest StartContest = new StartContest())
            {
                if (StartContest.ShowDialog(this) == DialogResult.OK)
                {
                    StartContest.Show();
                }
            }
        }
        private void StartScreenEditViewContestBtn_Click(object sender, EventArgs e)
        {
            using (new DialogOverlay())
            using (Edit_viewContestcs Edit_viewContest = new Edit_viewContestcs())
            {
                if (Edit_viewContest.ShowDialog(this) == DialogResult.OK)
                {
                    Edit_viewContest.Show();
                }
            }      
        }
        private void StartScreenAddDiverContestBtn_Click(object sender, EventArgs e)
        {
            using (new DialogOverlay())
            using (AddDiver AddDiver = new AddDiver())
            {
                if (AddDiver.ShowDialog(this) == DialogResult.OK)
                {
                    AddDiver.Show();
                }
            }
        }
        private void StartScreenAddJudgeBtn_Click(object sender, EventArgs e)
        {
            using (new DialogOverlay())
            using (Addjudge Addjudge = new Addjudge())
            {
                if (Addjudge.ShowDialog(this) == DialogResult.OK)
                {
                    Addjudge.Show();
                }
            }
        }
        private void StartScreenViewJudgeClient_Click(object sender, EventArgs e)
        {
            using (new DialogOverlay())
            using (JudgeClient JudgeClient = new JudgeClient())
            {
                if (JudgeClient.ShowDialog(this) == DialogResult.OK)
                {
                    JudgeClient.Show();
                }
            }
        }

    }
}
