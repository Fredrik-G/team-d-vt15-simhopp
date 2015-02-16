using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimhoppGUI
{
    public partial class AddDiver : Form
    {
        public AddDiver()

        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle; 
            InitializeComponent();
        }

        private void AddDiverCloseBtn_Click(object sender, EventArgs e)
        {           
            Close();
        }
    }
}
