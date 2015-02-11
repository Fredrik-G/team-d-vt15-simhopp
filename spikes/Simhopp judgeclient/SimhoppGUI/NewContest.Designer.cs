namespace SimhoppGUI
{
    partial class NewContest
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.NewContestStartDateLabel = new System.Windows.Forms.Label();
            this.NewContestStartDateDTP = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.NewContestCloseBtn = new System.Windows.Forms.Button();
            this.NewContestEndDateDTP = new System.Windows.Forms.DateTimePicker();
            this.NewContestEndDateLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Contest name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(112, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "City";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(112, 93);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 3;
            // 
            // NewContestStartDateLabel
            // 
            this.NewContestStartDateLabel.AutoSize = true;
            this.NewContestStartDateLabel.Location = new System.Drawing.Point(31, 159);
            this.NewContestStartDateLabel.Name = "NewContestStartDateLabel";
            this.NewContestStartDateLabel.Size = new System.Drawing.Size(53, 13);
            this.NewContestStartDateLabel.TabIndex = 4;
            this.NewContestStartDateLabel.Text = "Start date";
            // 
            // NewContestStartDateDTP
            // 
            this.NewContestStartDateDTP.CustomFormat = "";
            this.NewContestStartDateDTP.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.NewContestStartDateDTP.Location = new System.Drawing.Point(112, 153);
            this.NewContestStartDateDTP.Name = "NewContestStartDateDTP";
            this.NewContestStartDateDTP.Size = new System.Drawing.Size(151, 20);
            this.NewContestStartDateDTP.TabIndex = 5;
            this.NewContestStartDateDTP.Value = new System.DateTime(2015, 2, 6, 0, 0, 0, 0);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(91, 276);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Create";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // NewContestCloseBtn
            // 
            this.NewContestCloseBtn.Location = new System.Drawing.Point(188, 276);
            this.NewContestCloseBtn.Name = "NewContestCloseBtn";
            this.NewContestCloseBtn.Size = new System.Drawing.Size(75, 23);
            this.NewContestCloseBtn.TabIndex = 7;
            this.NewContestCloseBtn.Text = "Close";
            this.NewContestCloseBtn.UseVisualStyleBackColor = true;
            this.NewContestCloseBtn.Click += new System.EventHandler(this.NewContestPreviousBtn_Click);
            // 
            // NewContestEndDateDTP
            // 
            this.NewContestEndDateDTP.CustomFormat = "";
            this.NewContestEndDateDTP.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.NewContestEndDateDTP.Location = new System.Drawing.Point(112, 205);
            this.NewContestEndDateDTP.Name = "NewContestEndDateDTP";
            this.NewContestEndDateDTP.Size = new System.Drawing.Size(151, 20);
            this.NewContestEndDateDTP.TabIndex = 9;
            this.NewContestEndDateDTP.Value = new System.DateTime(2015, 2, 6, 0, 0, 0, 0);
            // 
            // NewContestEndDateLabel
            // 
            this.NewContestEndDateLabel.AutoSize = true;
            this.NewContestEndDateLabel.Location = new System.Drawing.Point(31, 211);
            this.NewContestEndDateLabel.Name = "NewContestEndDateLabel";
            this.NewContestEndDateLabel.Size = new System.Drawing.Size(50, 13);
            this.NewContestEndDateLabel.TabIndex = 8;
            this.NewContestEndDateLabel.Text = "End date";
            // 
            // NewContest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 397);
            this.Controls.Add(this.NewContestEndDateDTP);
            this.Controls.Add(this.NewContestEndDateLabel);
            this.Controls.Add(this.NewContestCloseBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.NewContestStartDateDTP);
            this.Controls.Add(this.NewContestStartDateLabel);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "NewContest";
            this.Text = "NewContest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label NewContestStartDateLabel;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.DateTimePicker NewContestStartDateDTP;
        private System.Windows.Forms.Button NewContestCloseBtn;
        public System.Windows.Forms.DateTimePicker NewContestEndDateDTP;
        private System.Windows.Forms.Label NewContestEndDateLabel;
    }
}