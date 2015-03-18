using System;
using System.Linq;
using System.Reflection;
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
        #region Data

        private DelegateConnectToServer eventConnectToServer;
        private DelegateSendDataToServer eventSendDataToServer;
        private DelegateDisconnect eventDisconnect;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Constructors

        public Login()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.InitializeComponent();
            log.Debug("New login window open.");
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

        #endregion

        #region Events

        private void LoginScreenCancelBtn_Click(object sender, EventArgs e)
        {
            log.Debug("Login window closed.");
            DialogResult = DialogResult.Cancel;
            Close();            
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (eventConnectToServer(IPConnectionTB.Text, UserSSNTB.Text, PasswordTB.Text))
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                InputErrorProvider.SetError(PasswordTB, "Username or password is incorrect.");
            }
            catch (Exception ex)
            {
                InputErrorProvider.SetError(IPConnectionTB, ex.Message);
            }
        }

        #endregion

        /// <summary>
        /// Checks if enter was pressed and call event to login.
        /// Also checks if escape was pressed and closes this form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckEnterOrEscape(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                LoginBtn_Click(sender, e);
            }
            else if (e.KeyChar == (char)27)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        #region Hash

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

        #endregion

        #region Click textboxes

        private void UserSSNTB_Click(object sender, EventArgs e)
        {
            UserSSNTB.SelectionStart = 0;
            UserSSNTB.SelectionLength = UserSSNTB.Text.Length;
        }

        private void PasswordTB_Click(object sender, EventArgs e)
        {
            PasswordTB.SelectionStart = 0;
            PasswordTB.SelectionLength = PasswordTB.Text.Length;
        }

        private void IPConnectionTB_Click(object sender, EventArgs e)
        {
            IPConnectionTB.SelectionStart = 0;
            IPConnectionTB.SelectionLength = IPConnectionTB.Text.Length;
        }

        #endregion

    }
}