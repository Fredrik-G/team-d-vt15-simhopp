﻿using System;
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
    public partial class Login : Form
    {
        public Login()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle; 
            InitializeComponent();
        }

        private void LoginScreenCancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}