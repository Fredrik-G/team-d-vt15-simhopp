using System;
using System.Windows.Forms;
using ClientGUI.View;

namespace ClientGUI
{
    public partial class JudgeClient : Form, IJudgeClient
    {

        #region Constructor

     
        public JudgeClient(DelegateConnectToServer eventConnectToServer, DelegateSendDataToServer eventSendDataToServer, DelegateDisconnect eventDisconnect)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
            this.EventSendDataToServer = eventSendDataToServer;
            this.EventConnectToServer = eventConnectToServer;
            this.EventDisconnect = eventDisconnect;
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

        #endregion

        #region Member methods


        #endregion

        #region IJudgeClient methods
        public event DelegateConnectToServer EventConnectToServer = null;
        public event DelegateSendDataToServer EventSendDataToServer = null;
        public event DelegateDisconnect EventDisconnect = null;
        #endregion

        private void sendPointButton_Click(object sender, EventArgs e)
        {
            var point = Convert.ToDouble(numericUpDown1.Text);
            var ssn = JudgeSSNTB.Text;
            EventSendDataToServer(ssn, point);
           
        }

        private void SendMessageToGUI(ServerObjectData message);




    }
}
