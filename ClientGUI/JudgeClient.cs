using System;
using System.Windows.Forms;
using ClientGUI.Model;
using ClientGUI.View;

namespace ClientGUI
{
    public partial class JudgeClient : Form, IJudgeClient
    {

        #region Constructor


        public JudgeClient(DelegateConnectToServer eventConnectToServer, DelegateSendDataToServer eventSendDataToServer, DelegateDisconnect eventDisconnect, DelegateGetFirstServerObjectData eventGetFirstServerObjectData)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
            this.EventSendDataToServer = eventSendDataToServer;
            this.EventConnectToServer = eventConnectToServer;
            this.EventDisconnect = eventDisconnect;
            this.EventGetFirstServerObjectData = eventGetFirstServerObjectData;

        }

        public JudgeClient()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
        }

        #endregion

        #region Events

        private void connectToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            using(new DimIt())
            using (var login = new Login(EventConnectToServer, EventSendDataToServer, EventDisconnect))
            {
                if (login.ShowDialog(this) == DialogResult.OK)
                {
                    login.Show();
                }
                JudgeSSNTB.Text = login.UserSSNTB.Text;
            }
        }
        private void sendPointButton_Click(object sender, EventArgs e)
        {
            var point = Convert.ToDouble(numericUpDown1.Text);
            var ssn = JudgeSSNTB.Text;
            EventSendDataToServer(ssn, point);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServerObjectData heh = EventGetFirstServerObjectData();
            JudgeClientChosenContestTb.Text = heh.ContestName;
            DiverNameTB.Text = heh.DiverName;
            TrickNameTB.Text = heh.TrickName;
            TrickDiffTB.Text = heh.TrickDiff.ToString();
        }

        private void disconnectToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EventDisconnect();
        }


        #endregion

        #region Member methods


        #endregion

        #region IJudgeClient methods
        public event DelegateConnectToServer EventConnectToServer = null;
        public event DelegateSendDataToServer EventSendDataToServer = null;
        public event DelegateDisconnect EventDisconnect = null;
        public event DelegateGetFirstServerObjectData EventGetFirstServerObjectData = null;

        #endregion

        
    }
}
