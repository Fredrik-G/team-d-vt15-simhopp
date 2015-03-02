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
            this.StartScreenNewContesttBtn = new System.Windows.Forms.Button();
            this.StartScreenStartContestBtn = new System.Windows.Forms.Button();
            this.StartScreenAddDiverContestBtn = new System.Windows.Forms.Button();
            this.StartScreenAddJudgeBtn = new System.Windows.Forms.Button();
            this.StartScreenViewJudgeClient = new System.Windows.Forms.Button();
            this.LivefeedBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartScreenNewContesttBtn
            // 
            this.StartScreenNewContesttBtn.Location = new System.Drawing.Point(12, 84);
            this.StartScreenNewContesttBtn.Name = "StartScreenNewContesttBtn";
            this.StartScreenNewContesttBtn.Size = new System.Drawing.Size(72, 66);
            this.StartScreenNewContesttBtn.TabIndex = 0;
            this.StartScreenNewContesttBtn.Text = "New Contest";
            this.StartScreenNewContesttBtn.UseVisualStyleBackColor = true;
            this.StartScreenNewContesttBtn.Click += new System.EventHandler(this.StartScreenNewContesttBtn_Click);
            // 
            // StartScreenStartContestBtn
            // 
            this.StartScreenStartContestBtn.Location = new System.Drawing.Point(129, 84);
            this.StartScreenStartContestBtn.Name = "StartScreenStartContestBtn";
            this.StartScreenStartContestBtn.Size = new System.Drawing.Size(72, 66);
            this.StartScreenStartContestBtn.TabIndex = 1;
            this.StartScreenStartContestBtn.Text = "Start Contest";
            this.StartScreenStartContestBtn.UseVisualStyleBackColor = true;
            this.StartScreenStartContestBtn.Click += new System.EventHandler(this.StartScreenStartContestBtn_Click);
            // 
            // StartScreenAddDiverContestBtn
            // 
            this.StartScreenAddDiverContestBtn.Location = new System.Drawing.Point(363, 84);
            this.StartScreenAddDiverContestBtn.Name = "StartScreenAddDiverContestBtn";
            this.StartScreenAddDiverContestBtn.Size = new System.Drawing.Size(72, 66);
            this.StartScreenAddDiverContestBtn.TabIndex = 3;
            this.StartScreenAddDiverContestBtn.Text = "Add/Edit Diver";
            this.StartScreenAddDiverContestBtn.UseVisualStyleBackColor = true;
            this.StartScreenAddDiverContestBtn.Click += new System.EventHandler(this.StartScreenAddDiverContestBtn_Click);
            // 
            // StartScreenAddJudgeBtn
            // 
            this.StartScreenAddJudgeBtn.Location = new System.Drawing.Point(480, 84);
            this.StartScreenAddJudgeBtn.Name = "StartScreenAddJudgeBtn";
            this.StartScreenAddJudgeBtn.Size = new System.Drawing.Size(72, 66);
            this.StartScreenAddJudgeBtn.TabIndex = 4;
            this.StartScreenAddJudgeBtn.Text = "Add/View Judge";
            this.StartScreenAddJudgeBtn.UseVisualStyleBackColor = true;
            this.StartScreenAddJudgeBtn.Click += new System.EventHandler(this.StartScreenAddJudgeBtn_Click);
            // 
            // StartScreenViewJudgeClient
            // 
            this.StartScreenViewJudgeClient.Location = new System.Drawing.Point(257, 191);
            this.StartScreenViewJudgeClient.Name = "StartScreenViewJudgeClient";
            this.StartScreenViewJudgeClient.Size = new System.Drawing.Size(130, 23);
            this.StartScreenViewJudgeClient.TabIndex = 5;
            this.StartScreenViewJudgeClient.Text = "View Judge Client";
            this.StartScreenViewJudgeClient.UseVisualStyleBackColor = true;
            this.StartScreenViewJudgeClient.Click += new System.EventHandler(this.StartScreenViewJudgeClient_Click);
            // 
            // LivefeedBtn
            // 
            this.LivefeedBtn.Location = new System.Drawing.Point(230, 80);
            this.LivefeedBtn.Name = "LivefeedBtn";
            this.LivefeedBtn.Size = new System.Drawing.Size(117, 74);
            this.LivefeedBtn.TabIndex = 6;
            this.LivefeedBtn.Text = "Live Feed";
            this.LivefeedBtn.UseVisualStyleBackColor = true;
            this.LivefeedBtn.Click += new System.EventHandler(this.LivefeedBtn_Click);
            // 
            // StartScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 244);
            this.Controls.Add(this.LivefeedBtn);
            this.Controls.Add(this.StartScreenViewJudgeClient);
            this.Controls.Add(this.StartScreenAddJudgeBtn);
            this.Controls.Add(this.StartScreenAddDiverContestBtn);
            this.Controls.Add(this.StartScreenStartContestBtn);
            this.Controls.Add(this.StartScreenNewContesttBtn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartScreen";
            this.Text = "StartScreen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StartScreen_FormClosing);
            this.Load += new System.EventHandler(this.StartScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartScreenNewContesttBtn;
        private System.Windows.Forms.Button StartScreenStartContestBtn;
        private System.Windows.Forms.Button StartScreenAddDiverContestBtn;
        private System.Windows.Forms.Button StartScreenAddJudgeBtn;
        private System.Windows.Forms.Button StartScreenViewJudgeClient;
        private System.Windows.Forms.Button LivefeedBtn;
    }
}