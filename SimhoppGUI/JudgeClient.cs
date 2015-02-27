using System;
using System.Windows.Forms;
using Simhopp.View;

namespace SimhoppGUI
{
    public partial class JudgeClient : Form
    {

        #region Data

        private DelegateGetJudgeHash eventGetJudgeHash;
        private DelegateGetJudgeSalt eventGetJudgeSalt;

        #endregion

        #region Constructor

        public JudgeClient(DelegateGetJudgeHash eventGetJudgeHash, DelegateGetJudgeSalt eventGetJudgeSalt)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();

            this.eventGetJudgeHash= eventGetJudgeHash;
            this.eventGetJudgeSalt = eventGetJudgeSalt;
        }

        #endregion

        #region Events

        private void connectToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (new DimIt())
            using (var loginScreen = new Login(eventGetJudgeHash, eventGetJudgeSalt))
            {
                if (loginScreen.ShowDialog(this) == DialogResult.OK)
                {
                    loginScreen.Show();
                }
            }
        }

        #endregion

    }
}
