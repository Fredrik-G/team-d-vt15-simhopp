namespace SimhoppGUI
{
    partial class StartScreen
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
            this.StartScreenNewContesttBtn = new System.Windows.Forms.Button();
            this.StartScreenStartContestBtn = new System.Windows.Forms.Button();
            this.StartScreenAddDiverContestBtn = new System.Windows.Forms.Button();
            this.StartScreenAddJudgeBtn = new System.Windows.Forms.Button();
            this.NewContestToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.StartContestToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.AddDiverToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.AddJudgeToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // StartScreenNewContesttBtn
            // 
            this.StartScreenNewContesttBtn.Location = new System.Drawing.Point(30, 52);
            this.StartScreenNewContesttBtn.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.StartScreenNewContesttBtn.Name = "StartScreenNewContesttBtn";
            this.StartScreenNewContesttBtn.Size = new System.Drawing.Size(144, 127);
            this.StartScreenNewContesttBtn.TabIndex = 0;
            this.StartScreenNewContesttBtn.Text = "New Contest";
            this.NewContestToolTip.SetToolTip(this.StartScreenNewContesttBtn, "Ctrl+N");
            this.StartScreenNewContesttBtn.UseVisualStyleBackColor = true;
            this.StartScreenNewContesttBtn.Click += new System.EventHandler(this.StartScreenNewContesttBtn_Click);
            // 
            // StartScreenStartContestBtn
            // 
            this.StartScreenStartContestBtn.Location = new System.Drawing.Point(264, 52);
            this.StartScreenStartContestBtn.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.StartScreenStartContestBtn.Name = "StartScreenStartContestBtn";
            this.StartScreenStartContestBtn.Size = new System.Drawing.Size(144, 127);
            this.StartScreenStartContestBtn.TabIndex = 1;
            this.StartScreenStartContestBtn.Text = "Start Contest";
            this.StartContestToolTip.SetToolTip(this.StartScreenStartContestBtn, "Ctrl+S");
            this.StartScreenStartContestBtn.UseVisualStyleBackColor = true;
            this.StartScreenStartContestBtn.Click += new System.EventHandler(this.StartScreenStartContestBtn_Click);
            // 
            // StartScreenAddDiverContestBtn
            // 
            this.StartScreenAddDiverContestBtn.Location = new System.Drawing.Point(496, 52);
            this.StartScreenAddDiverContestBtn.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.StartScreenAddDiverContestBtn.Name = "StartScreenAddDiverContestBtn";
            this.StartScreenAddDiverContestBtn.Size = new System.Drawing.Size(144, 127);
            this.StartScreenAddDiverContestBtn.TabIndex = 3;
            this.StartScreenAddDiverContestBtn.Text = "Add/Edit Diver";
            this.AddDiverToolTip.SetToolTip(this.StartScreenAddDiverContestBtn, "Ctrl+D");
            this.StartScreenAddDiverContestBtn.UseVisualStyleBackColor = true;
            this.StartScreenAddDiverContestBtn.Click += new System.EventHandler(this.StartScreenAddDiverContestBtn_Click);
            // 
            // StartScreenAddJudgeBtn
            // 
            this.StartScreenAddJudgeBtn.Location = new System.Drawing.Point(730, 52);
            this.StartScreenAddJudgeBtn.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.StartScreenAddJudgeBtn.Name = "StartScreenAddJudgeBtn";
            this.StartScreenAddJudgeBtn.Size = new System.Drawing.Size(144, 127);
            this.StartScreenAddJudgeBtn.TabIndex = 4;
            this.StartScreenAddJudgeBtn.Text = "Add/View Judge";
            this.AddDiverToolTip.SetToolTip(this.StartScreenAddJudgeBtn, "Ctrl+J");
            this.StartScreenAddJudgeBtn.UseVisualStyleBackColor = true;
            this.StartScreenAddJudgeBtn.Click += new System.EventHandler(this.StartScreenAddJudgeBtn_Click);
            // 
            // StartScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 298);
            this.Controls.Add(this.StartScreenAddJudgeBtn);
            this.Controls.Add(this.StartScreenAddDiverContestBtn);
            this.Controls.Add(this.StartScreenStartContestBtn);
            this.Controls.Add(this.StartScreenNewContesttBtn);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartScreen";
            this.Text = "StartScreen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StartScreen_FormClosing);
            this.Load += new System.EventHandler(this.StartScreen_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StartScreen_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartScreenNewContesttBtn;
        private System.Windows.Forms.Button StartScreenStartContestBtn;
        private System.Windows.Forms.Button StartScreenAddDiverContestBtn;
        private System.Windows.Forms.Button StartScreenAddJudgeBtn;
        private System.Windows.Forms.ToolTip NewContestToolTip;
        private System.Windows.Forms.ToolTip StartContestToolTip;
        private System.Windows.Forms.ToolTip AddDiverToolTip;
        private System.Windows.Forms.ToolTip AddJudgeToolTip;
    }
}