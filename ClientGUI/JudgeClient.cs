using System;
using System.Windows.Forms;

namespace ClientGUI
{
    public partial class JudgeClient : Form
    {

        #region Data

        //private DelegateGetJudgeHash eventGetJudgeHash;
        //private DelegateGetJudgeSalt eventGetJudgeSalt;
        //private DelegateConnectToServer eventConnectToServer;

        #endregion

        #region Constructor

        /*public JudgeClient(DelegateGetJudgeHash eventGetJudgeHash, DelegateGetJudgeSalt eventGetJudgeSalt, 
            DelegateConnectToServer eventConnectToServer)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();

            this.eventGetJudgeHash= eventGetJudgeHash;
            this.eventGetJudgeSalt = eventGetJudgeSalt;
            this.eventConnectToServer = eventConnectToServer;
        }*/

        #endregion

        #region Events

        private void connectToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            /*using (new DimIt())
            using (var loginScreen = new Login(eventGetJudgeHash, eventGetJudgeSalt))
            {
                if (loginScreen.ShowDialog(this) == DialogResult.OK)
                {
                    loginScreen.Show();
                }
            }*/
        }

        #endregion

        private void connectToServerButton_Click(object sender, EventArgs e)
        {
            //TODO checks for correct IP-input
            var ip = connectToServerButton.Text;
            //eventConnectToServer(ip);
        }


    }
}
