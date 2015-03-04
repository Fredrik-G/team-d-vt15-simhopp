using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Simhopp;
using Simhopp.View;

namespace SimhoppGUI
{
    public partial class StartScreen : Form, IStartScreen
    {
        #region Data
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region Constructor

        public StartScreen()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();

            log.Info("New simhopp application started");
        }

        #endregion



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

        #region Events
        /// <summary>
        /// Occurs on form load.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartScreen_Load(object sender, EventArgs e)
        {
            EventReadJudgesFromDatabase();
            EventReadDiversFromDatabase();
            EventReadTricksFromDatabase();
            EventReadContestsFromDatabase();
        }

        /// <summary>
        /// Creates a NewContest-form and attemps to create a new contest with the input from NewContest.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartScreenNewContesttBtn_Click(object sender, EventArgs e)
        {
            try
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
                    //Creates a new contest with the input from newContest-form. 
                    if (newContest.DialogResult == DialogResult.OK)
                    {
                        var startDate = CreateDateString(newContest.NewContestStartDateDTP);
                        var endDate = CreateDateString(newContest.NewContestEndDateDTP);

                        EventCreateContest(newContest.City, newContest.ContestName, startDate, endDate);
                        log.Info("Created new contest(" + newContest.City +", " +
                            newContest.ContestName + ", " + startDate + ", " + endDate + ").");
                    }
                }
            }

            catch (ArgumentNullException nullException)
            {
                MsgBox.CreateErrorBox(nullException.ToString(), MethodBase.GetCurrentMethod().Name);
                log.Warn("Null exception when creating a new contest", nullException);
            }
            //Occurs if contest data is invalid.
            catch (InvalidOperationException invalidOperationException)
            {
                MsgBox.CreateErrorBox(invalidOperationException.ToString(), MethodBase.GetCurrentMethod().Name);
                log.Warn("Invalid operation when creating a new contest", invalidOperationException);
            }
            catch (Exception exception)
            {
                MsgBox.CreateErrorBox(exception.ToString(), MethodBase.GetCurrentMethod().Name);
                log.Warn("Exception when creating a new contest", exception);
            }
        }

        /// <summary>
        /// Creates a StartContest-form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartScreenStartContestBtn_Click(object sender, EventArgs e)
        {
            //Dims the background form and makes it non-interactive.
            using (new DimIt())
            using (var startContest = new StartContest(
                EventGetContestsList,
                EventGetJudgesList,
                EventGetDiversList,
                EventGetJudgesInContest,
                EventGetDiversInContest,
                EventAddJudgeToContest,
                EventAddDiverToContest,
                EventRemoveJudgeFromContest,
                EventRemoveDiverFromContest,
                EventUpdateContest,
                EventGetTrickList,
                EventGetFirstClientObjectData,
                EventHandleMessage,
                EventSendDataToClient
                ))
            {
                if (startContest.ShowDialog(this) == DialogResult.OK)
                {
                    startContest.Show();
                }
            }
        }

        private void StartScreenAddDiverContestBtn_Click(object sender, EventArgs e)
        {
            //Dims the background form and makes it non-interactive.
            using (new DimIt())
            using (var addDiver = new AddEditDiver(EventAddDiverToList, EventGetDiversList, EventReadFromFile))
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
            using (var addjudge = new AddEditJudge(EventAddJudgeToList,
                             EventRemoveJudgeFromList,
                             EventGetJudgesList,
                             EventUpdateJudge))
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
            using (var judgeClient = new JudgeClient(EventGetJudgeHash, EventGetJudgeSalt))
            {
                if (judgeClient.ShowDialog(this) == DialogResult.OK)
                {
                    judgeClient.Show();
                }
            }
        }

        private void LivefeedBtn_Click(object sender, EventArgs e)
        {
            //using (new DimIt())
            /*using (var liveFeed = new LiveFeed())
            {
                if (liveFeed.ShowDialog(this) == DialogResult.OK)
                {

                }
            }*/
        }

        /// <summary>
        /// Occurs when the form is closing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            log.Info("Simhopp application closing down");
        }

        #endregion

        #region ISimhopp Methods

        public event DelegateCreateContest EventCreateContest = null;

        public event DelegateReadFromFile EventReadFromFile = null;
        public event DelegateReadJudgesFromDatabase EventReadJudgesFromDatabase = null;
        public event DelegateReadDiversFromDatabase EventReadDiversFromDatabase = null;
        public event DelegateReadTricksFromDatabase EventReadTricksFromDatabase = null;
        public event DelegateReadContestsFromDatabase EventReadContestsFromDatabase = null;

        public event DelegateGetContestsList EventGetContestsList = null;
        public event DelegateGetJudgesList EventGetJudgesList = null;
        public event DelegateGetDiversList EventGetDiversList = null;
        public event DelegateGetJudgesInContest EventGetJudgesInContest = null;
        public event DelegateGetDiversInContest EventGetDiversInContest = null;
        public event DelegateGetTrickList EventGetTrickList = null;

        public event DelegateGetJudgeHash EventGetJudgeHash = null;
        public event DelegateGetJudgeSalt EventGetJudgeSalt = null;

        public event DelegateAddJudgeToList EventAddJudgeToList = null;
        public event DelegateAddDiverToList EventAddDiverToList = null;

        public event DelegateAddJudgeToContest EventAddJudgeToContest = null;
        public event DelegateAddDiverToContest EventAddDiverToContest = null;

        public event DelegateRemoveJudgeFromList EventRemoveJudgeFromList = null;
        public event DelegateRemoveDiverFromList EventRemoveDiverFromList = null;

        public event DelegateRemoveJudgeFromContest EventRemoveJudgeFromContest = null;
        public event DelegateRemoveDiverFromContest EventRemoveDiverFromContest = null;


        public event DelegateUpdateContest EventUpdateContest = null;
        public event DelegateUpdateJudge EventUpdateJudge = null;
        public event DelegateUpdateDiver EventUpdateDiver = null;

        public event DelegateGetFirstClientObjectData EventGetFirstClientObjectData = null;
        public event DelegateSendDataToClient EventSendDataToClient = null;
        public event DelegateHandleMessage EventHandleMessage = null;

        #endregion
    }
}
