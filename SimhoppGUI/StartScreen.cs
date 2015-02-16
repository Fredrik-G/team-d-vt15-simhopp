using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimhoppGUI.View
{
    public partial class StartScreen : Form, IStartScreen
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
                if (EventCreateContest != null)
                {
                    string date = newContest.NewContestStartDateDTP.Value.Day.ToString() +
                                  "/" + newContest.NewContestStartDateDTP.Value.Month.ToString() +
                                  "/" + newContest.NewContestStartDateDTP.Value.Year.ToString();
                    try
                    {
                        this.EventCreateContest(newContest.newContestCityTB.Text, newContest.newContestNameTB.Text, date);
                    }
                    catch (Exception exception)
                    {

                    }
                }
            }
        }
        private void StartScreenStartContestBtn_Click(object sender, EventArgs e)
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
            using (EditViewContest Edit_viewContest = new EditViewContest())
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

        public event DelegateCreateContest EventCreateContest = null;

        //public event DelegateAddParticipant EventAddParticipant = null;
        //public event DelegateAddJudge EventAddJudge = null;
        //public event DelegateGetTrickDifficultyFromTrickHashTable EventGetTrickDifficultyFromTrickHashTable = null;
        //public event DelegateGetResultFromParticipant EventGetResultFromParticipant = null;
    }
}
