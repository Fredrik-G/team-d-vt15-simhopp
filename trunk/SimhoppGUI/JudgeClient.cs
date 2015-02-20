using System;
using System.Windows.Forms;

namespace SimhoppGUI
{
    public partial class JudgeClient : Form
    {
        public JudgeClient()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
        }

        private void connectToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (new DimIt())
            using (Login LoginScreen  = new Login())
            {
                if (LoginScreen.ShowDialog(this) == DialogResult.OK)
                {

                    LoginScreen.Show();
                }
            }       
        } 
    }
}
