using System;
using System.Reflection;
using System.Windows.Forms;
using ClientGUI.Model;
using ClientGUI.View;
using System.Threading;
namespace ClientGUI
{
    public partial class JudgeClient : Form, IJudgeClient
    {
        #region Data

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private bool isConnected;
        #endregion

        #region Constructor

        public JudgeClient(DelegateConnectToServer eventConnectToServer,
            DelegateSendDataToServer eventSendDataToServer,
            DelegateDisconnect eventDisconnect,
            DelegateGetFirstServerObjectData eventGetFirstServerObjectData,
            DelegateGetSizeOfQueue eventGetSizeOfQueue)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();

            this.EventSendDataToServer = eventSendDataToServer;
            this.EventConnectToServer = eventConnectToServer;
            this.EventDisconnect = eventDisconnect;
            this.EventGetFirstServerObjectData = eventGetFirstServerObjectData;
            this.EventGetSizeOfQueue = eventGetSizeOfQueue;
        }

        /// <summary>
        /// Default constructor. Starts a new thread that listens for new messages.
        /// </summary>
        public JudgeClient()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();

            var messageListener = new Thread(ListenForNewMessage);
            messageListener.Start();
            messageListener.IsBackground = true;

            //enables keyboard usage.
            KeyPreview = true;
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when a key is pressed.
        /// Shows tooltip if controll is pressed.
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (ModifierKeys == Keys.Alt)
            {
                FileToolStripMenuItem.ShowDropDown();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


        /// <summary>
        /// Occurs when the Connect item is clicked.
        /// Opens a new Login form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void connectToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (new DimIt())
            using (var login = new Login(EventConnectToServer, EventSendDataToServer, EventDisconnect))
            {
                if (login.ShowDialog(this) == DialogResult.OK)
                {
                    JudgeSSNTB.Text = login.UserSSNTB.Text;
                    ConnectionStatusLabel.Text = "Connected";
                    isConnected = true;
                }
                else
                {
                    ConnectionStatusLabel.Text = "Disconnected";
                    isConnected = false;
                }
            }
        }

        /// <summary>
        /// Occurs when the Send button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sendPointButton_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                var point = Convert.ToDouble(numericUpDown1.Text);
                var ssn = JudgeSSNTB.Text;
                EventSendDataToServer(ssn, point);
                sendPointButton.Enabled = false;
            }
            else
            {
                MessageBox.Show("Not connected");
            }
        }

        /// <summary>
        /// Occurs when the disconnect item is clicked.
        /// Calls event to disconnect.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void disconnectToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EventDisconnect();
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Thread-method that is listening for new messages from the server.
        /// </summary>
        private void ListenForNewMessage()
        {
            while (true)
            {
                using (new JudgeClient(EventConnectToServer, EventSendDataToServer, EventDisconnect,
                        EventGetFirstServerObjectData, EventGetSizeOfQueue))
                {
                    var sizeOfQueue = EventGetSizeOfQueue();
                    if (sizeOfQueue > 0)
                    {
                        var serverObjectData = EventGetFirstServerObjectData();
                        if (!ReferenceEquals(null, serverObjectData))
                        {
                            UpdateTextBoxes(serverObjectData);
                            Invoke((MethodInvoker)delegate { sendPointButton.Enabled = true; });
                            // sendPointButton.Enabled = true;
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

        private void JudgeClient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                sendPointButton_Click(sender, e);
            }
        }
    }
}
