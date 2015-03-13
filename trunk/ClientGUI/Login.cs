using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using ClientGUI.View;

namespace ClientGUI
{
    /// <summary>
    /// Allows a judge to log in. Authentication uses SHA256-encryption.
    /// The program gets the judges password hash and his salt, 
    /// then calculates the SHA256-hash for the inputed password + his hash (from database).
    /// The judge is authenticated if correct hash = input hash.
    /// </summary>
    public partial class Login : Form
    {
        private DelegateConnectToServer eventConnectToServer;
        private DelegateSendDataToServer eventSendDataToServer;
        private DelegateDisconnect eventDisconnect;
        

        public Login()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.InitializeComponent();
        }

        public Login(DelegateConnectToServer eventConnectToServer,
            DelegateSendDataToServer eventSendDataToServer,
            DelegateDisconnect eventDisconnect)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
            this.eventConnectToServer = eventConnectToServer;
            this.eventSendDataToServer = eventSendDataToServer;
            this.eventDisconnect = eventDisconnect;
        }

        private void LoginScreenCancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            using (var login = new Login(eventConnectToServer, eventSendDataToServer, eventDisconnect))
            {
                try
                {
                    eventConnectToServer(IPConnectionTB.Text, UserSSNTB.Text, PasswordTB.Text);
                    
                    Close();
                }
                catch (Exception ex)
                {
                    
                }
            }
        }
        

        private bool Authenticate()
        {
            
            return false;
        }

        private string CalculateHash(string password)
        {
            var crypt = new SHA256Managed();
            var tempString = String.Empty;
            var crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(password), 0, Encoding.UTF8.GetByteCount(password));

            return crypto.Aggregate(tempString, (current, bit) => current + bit.ToString("x2"));
        }
    }
}
