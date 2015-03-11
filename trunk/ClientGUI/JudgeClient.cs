using System;
using System.Windows.Forms;
using ClientGUI.Model;
using ClientGUI.View;
using System.Threading;
namespace ClientGUI
{
    public partial class JudgeClient : Form, IJudgeClient
    {

        #region Constructor

        public JudgeClient(DelegateConnectToServer eventConnectToServer, DelegateSendDataToServer eventSendDataToServer, DelegateDisconnect eventDisconnect, DelegateGetFirstServerObjectData eventGetFirstServerObjectData, DelegateGetSizeOfQueue eventGetSizeOfQueue)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
            this.EventSendDataToServer = eventSendDataToServer;
            this.EventConnectToServer = eventConnectToServer;
            this.EventDisconnect = eventDisconnect;
            this.EventGetFirstServerObjectData = eventGetFirstServerObjectData;
            this.EventGetSizeOfQueue = eventGetSizeOfQueue;
        }

        public JudgeClient()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
            Thread messageListener = new Thread(ListenForNewMessage);
            messageListener.Start();
            messageListener.IsBackground = true;
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
            sendPointButton.Enabled = false;

        }

        private void disconnectToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EventDisconnect();
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Thread-method that is listening for new messages from the server
        /// </summary>
        private void ListenForNewMessage()
        {
            while (true)
            {
                using (new JudgeClient(EventConnectToServer, EventSendDataToServer, EventDisconnect,
                EventGetFirstServerObjectData, EventGetSizeOfQueue))
                {
                    int heh = EventGetSizeOfQueue();
                    if (heh > 0)
                    {
                        ServerObjectData oD = EventGetFirstServerObjectData();
                        if (!object.ReferenceEquals(null, oD))
                        {
                            UpdateTextBoxes(oD);
                            sendPointButton.Enabled = true;
                        }
                    }
                }
                Thread.Sleep(200);
            }
        }

        /// <summary>
        /// Invokes an update on the textBoxes with new data.
        /// </summary>
        /// <param name="oD"></param>
        private void UpdateTextBoxes(ServerObjectData oD)
        {
            Invoke((MethodInvoker)delegate { JudgeClientChosenContestTb.Text = oD.ContestName; });
            Invoke((MethodInvoker)delegate { DiverNameTB.Text = oD.DiverName; });
            Invoke((MethodInvoker)delegate { TrickNameTB.Text = oD.TrickName; });
            Invoke((MethodInvoker)delegate { TrickDiffTB.Text = oD.TrickDiff.ToString(); });
        }

        #endregion

        #region IJudgeClient methods
        public event DelegateConnectToServer EventConnectToServer = null;
        public event DelegateSendDataToServer EventSendDataToServer = null;
        public event DelegateDisconnect EventDisconnect = null;
        public event DelegateGetFirstServerObjectData EventGetFirstServerObjectData = null;
        public event DelegateGetSizeOfQueue EventGetSizeOfQueue = null;

        #endregion


    }
}
