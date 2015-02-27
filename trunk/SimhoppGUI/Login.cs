using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Simhopp;
using Simhopp.View;

namespace SimhoppGUI
{
    /// <summary>
    /// Allows a judge to log in. Authentication uses SHA256-encryption.
    /// The program gets the judges password hash and his salt, 
    /// then calculates the SHA256-hash for the inputed password + his hash (from database).
    /// The judge is authenticated if correct hash = input hash.
    /// </summary>
    public partial class Login : Form
    {
        private DelegateGetJudgeHash eventGetJudgeHash;
        private DelegateGetJudgeSalt eventGetJudgeSalt;

        public Login(DelegateGetJudgeHash eventGetJudgeHash, DelegateGetJudgeSalt eventGetJudgeSalt)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle; 
            InitializeComponent();

            this.eventGetJudgeHash = eventGetJudgeHash;
            this.eventGetJudgeSalt = eventGetJudgeSalt;
        }

        private void LoginScreenCancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (Authenticate())
            {
                MsgBox.CreateErrorBox("asd", "qsagfd");
            }
            else
            {
                MsgBox.CreateErrorBox("123132", "253123");
            }
        }

        private bool Authenticate()
        {
            var correctHash = eventGetJudgeHash(UserNameTB.Text);
            var salt = eventGetJudgeSalt(UserNameTB.Text);

            var inputHash = CalculateHash(PasswordTB.Text + salt);

            return correctHash == inputHash;
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
