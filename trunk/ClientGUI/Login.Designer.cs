using System;
using ClientGUI;

namespace ClientGUI
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.UserSSNTB = new System.Windows.Forms.TextBox();
            this.PasswordTB = new System.Windows.Forms.TextBox();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.LoginScreenCancelBtn = new System.Windows.Forms.Button();
            this.InputErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.IPAddressLabel = new System.Windows.Forms.Label();
            this.IPConnectionTB = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.InputErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Location = new System.Drawing.Point(6, 13);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(29, 13);
            this.UserNameLabel.TabIndex = 0;
            this.UserNameLabel.Text = "SSN";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(151, 13);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(53, 13);
            this.PasswordLabel.TabIndex = 1;
            this.PasswordLabel.Text = "Password";
            // 
            // UserSSNTB
            // 
            this.UserSSNTB.Location = new System.Drawing.Point(9, 28);
            this.UserSSNTB.Name = "UserSSNTB";
            this.UserSSNTB.Size = new System.Drawing.Size(125, 20);
            this.UserSSNTB.TabIndex = 2;
            this.UserSSNTB.Click += new System.EventHandler(this.UserSSNTB_Click);
            this.UserSSNTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnterOrEscape);
            // 
            // PasswordTB
            // 
            this.PasswordTB.Location = new System.Drawing.Point(154, 28);
            this.PasswordTB.Name = "PasswordTB";
            this.PasswordTB.PasswordChar = '*';
            this.PasswordTB.Size = new System.Drawing.Size(119, 20);
            this.PasswordTB.TabIndex = 3;
            this.PasswordTB.UseSystemPasswordChar = true;
            this.PasswordTB.Click += new System.EventHandler(this.PasswordTB_Click);
            this.PasswordTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnterOrEscape);
            // 
            // LoginBtn
            // 
            this.LoginBtn.Location = new System.Drawing.Point(59, 113);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(75, 23);
            this.LoginBtn.TabIndex = 4;
            this.LoginBtn.Text = "Login";
            this.LoginBtn.UseVisualStyleBackColor = true;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // LoginScreenCancelBtn
            // 
            this.LoginScreenCancelBtn.Location = new System.Drawing.Point(154, 113);
            this.LoginScreenCancelBtn.Name = "LoginScreenCancelBtn";
            this.LoginScreenCancelBtn.Size = new System.Drawing.Size(75, 23);
            this.LoginScreenCancelBtn.TabIndex = 5;
            this.LoginScreenCancelBtn.Text = "Cancel";
            this.LoginScreenCancelBtn.UseVisualStyleBackColor = true;
            this.LoginScreenCancelBtn.Click += new System.EventHandler(this.LoginScreenCancelBtn_Click);
            // 
            // InputErrorProvider
            // 
            this.InputErrorProvider.ContainerControl = this;
            // 
            // IPAddressLabel
            // 
            this.IPAddressLabel.AutoSize = true;
            this.IPAddressLabel.Location = new System.Drawing.Point(9, 55);
            this.IPAddressLabel.Name = "IPAddressLabel";
            this.IPAddressLabel.Size = new System.Drawing.Size(58, 13);
            this.IPAddressLabel.TabIndex = 6;
            this.IPAddressLabel.Text = "IP-Address";
            // 
            // IPConnectionTB
            // 
            this.IPConnectionTB.Location = new System.Drawing.Point(9, 72);
            this.IPConnectionTB.Name = "IPConnectionTB";
            this.IPConnectionTB.Size = new System.Drawing.Size(125, 20);
            this.IPConnectionTB.TabIndex = 7;
            this.IPConnectionTB.Text = "127.0.0.1";
            this.IPConnectionTB.Click += new System.EventHandler(this.IPConnectionTB_Click);
            this.IPConnectionTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnterOrEscape);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 148);
            this.Controls.Add(this.IPConnectionTB);
            this.Controls.Add(this.IPAddressLabel);
            this.Controls.Add(this.LoginScreenCancelBtn);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.PasswordTB);
            this.Controls.Add(this.UserSSNTB);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UserNameLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.InputErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox PasswordTB;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.Button LoginScreenCancelBtn;
        private System.Windows.Forms.ErrorProvider InputErrorProvider;
        private System.Windows.Forms.TextBox IPConnectionTB;
        private System.Windows.Forms.Label IPAddressLabel;
        public System.Windows.Forms.TextBox UserSSNTB;
    }
}