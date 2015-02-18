using System;
using System.Windows.Forms;
using Simhopp.View;

namespace SimhoppGUI
{
    public partial class StartScreen : Form, IStartScreen
    {
        public StartScreen()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
        }
        /// <summary>
        /// Creates a correct date string from DateTimePicker.
        /// dd/mm/yyyy
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string CreateDateString(DateTimePicker date)
        {
            return date.Value.Day.ToString() +
                           "/" + date.Value.Month.ToString() +
                           "/" + date.Value.Year.ToString();
        }
        /// <summary>
        /// Creates a NewContest-form and attemps to create a new contest with the input from NewContest.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartScreenNewContesttBtn_Click(object sender, EventArgs e)
        {
            //Dims the background form and makes it non-interactive.
            using (new DimIt())
            using (var newContest = new NewContest())
            {
                if (newContest.ShowDialog(this) == DialogResult.OK)
                {
                    newContest.Show();
                }
                if (EventCreateContest == null)
                {
                    return;
                }
                var startDate = CreateDateString(newContest.NewContestStartDateDTP);
                var endDate = CreateDateString(newContest.NewContestEndDateDTP);
                try
                {
                    EventCreateContest(newContest.newContestCityTB.Text, newContest.newContestNameTB.Text, startDate, endDate);
                }
                catch (Exception exception)
                {
                    // do something
                }
            }
        }
        private void StartScreenStartContestBtn_Click(object sender, EventArgs e)
        {
            //Dims the background form and makes it non-interactive.
            using (new DimIt())
            using (var startContest = new StartContest())
            {
                if (startContest.ShowDialog(this) == DialogResult.OK)
                {
                    startContest.Show();
                }
            }
        }
        private void StartScreenEditViewContestBtn_Click(object sender, EventArgs e)
        {
            //Dims the background form and makes it non-interactive.
            using (new DimIt())
            using (var editViewContest = new EditViewContest(EventGetContestsList))
            {
                if (editViewContest.ShowDialog(this) == DialogResult.OK)
                {
                    editViewContest.Show();
                }
            }
        }
        private void StartScreenAddDiverContestBtn_Click(object sender, EventArgs e)
        {
            //Dims the background form and makes it non-interactive.
            using (new DimIt())
            using (var addDiver = new AddDiver())
            {
                if (addDiver.ShowDialog(this) == DialogResult.OK)
                {
                    addDiver.Show();
                }
            }
        }
        private void StartScreenAddJudgeBtn_Click(object sender, EventArgs e)
        {
            //Dims the background form and makes it non-interactive.
            using (new DimIt())
            using (var addjudge = new Addjudge())
            {
                if (addjudge.ShowDialog(this) == DialogResult.OK)
                {
                    addjudge.Show();
                }
            }
        }
        private void StartScreenViewJudgeClient_Click(object sender, EventArgs e)
        {
            //Dims the background form and makes it non-interactive.
            using (new DimIt())
            using (var judgeClient = new JudgeClient())
            {
                if (judgeClient.ShowDialog(this) == DialogResult.OK)
                {
                    judgeClient.Show();
                }
            }
        }

        public event DelegateCreateContest EventCreateContest = null;
        public event DelegateGetContestsList EventGetContestsList = null;
        //public event DelegateAddParticipant EventAddParticipant = null;
        //public event DelegateAddJudge EventAddJudge = null;
        //public event DelegateGetTrickDifficultyFromTrickHashTable EventGetTrickDifficultyFromTrickHashTable = null;
        //public event DelegateGetResultFromParticipant EventGetResultFromParticipant = null;
    }
}
