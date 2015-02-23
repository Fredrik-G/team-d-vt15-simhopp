namespace SimhoppGUI
{
    partial class StartContest
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
            this.JudgesDiversTabControl = new System.Windows.Forms.TabControl();
            this.JudgeTabPage = new System.Windows.Forms.TabPage();
            this.RemoveJudgeBtn = new System.Windows.Forms.Button();
            this.AddJudgeBtn = new System.Windows.Forms.Button();
            this.GlobalJudgesDataGridView = new System.Windows.Forms.DataGridView();
            this.CurrentJudgesDataGridView = new System.Windows.Forms.DataGridView();
            this.DiverTabPage = new System.Windows.Forms.TabPage();
            this.AddDiverBtn = new System.Windows.Forms.Button();
            this.RemoveDiverBtn = new System.Windows.Forms.Button();
            this.CurrentDiversDataGridView = new System.Windows.Forms.DataGridView();
            this.GlobalDiversDataGridView = new System.Windows.Forms.DataGridView();
            this.ContestsDataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.JudgesDiversTabControl.SuspendLayout();
            this.JudgeTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GlobalJudgesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentJudgesDataGridView)).BeginInit();
            this.DiverTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentDiversDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GlobalDiversDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContestsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // JudgesDiversTabControl
            // 
            this.JudgesDiversTabControl.Controls.Add(this.JudgeTabPage);
            this.JudgesDiversTabControl.Controls.Add(this.DiverTabPage);
            this.JudgesDiversTabControl.Location = new System.Drawing.Point(12, 203);
            this.JudgesDiversTabControl.Name = "JudgesDiversTabControl";
            this.JudgesDiversTabControl.SelectedIndex = 0;
            this.JudgesDiversTabControl.Size = new System.Drawing.Size(739, 253);
            this.JudgesDiversTabControl.TabIndex = 3;
            this.JudgesDiversTabControl.SelectedIndexChanged += new System.EventHandler(this.JudgesDiversTabControl_SelectedIndexChanged);
            // 
            // JudgeTabPage
            // 
            this.JudgeTabPage.Controls.Add(this.RemoveJudgeBtn);
            this.JudgeTabPage.Controls.Add(this.AddJudgeBtn);
            this.JudgeTabPage.Controls.Add(this.GlobalJudgesDataGridView);
            this.JudgeTabPage.Controls.Add(this.CurrentJudgesDataGridView);
            this.JudgeTabPage.Location = new System.Drawing.Point(4, 22);
            this.JudgeTabPage.Name = "JudgeTabPage";
            this.JudgeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.JudgeTabPage.Size = new System.Drawing.Size(731, 227);
            this.JudgeTabPage.TabIndex = 0;
            this.JudgeTabPage.Text = "Judges";
            this.JudgeTabPage.UseVisualStyleBackColor = true;
            // 
            // RemoveJudgeBtn
            // 
            this.RemoveJudgeBtn.Location = new System.Drawing.Point(346, 100);
            this.RemoveJudgeBtn.Name = "RemoveJudgeBtn";
            this.RemoveJudgeBtn.Size = new System.Drawing.Size(37, 23);
            this.RemoveJudgeBtn.TabIndex = 8;
            this.RemoveJudgeBtn.Text = "←";
            this.RemoveJudgeBtn.UseVisualStyleBackColor = true;
            this.RemoveJudgeBtn.Click += new System.EventHandler(this.RemoveJudgeBtn_Click);
            // 
            // AddJudgeBtn
            // 
            this.AddJudgeBtn.Location = new System.Drawing.Point(346, 71);
            this.AddJudgeBtn.Name = "AddJudgeBtn";
            this.AddJudgeBtn.Size = new System.Drawing.Size(37, 23);
            this.AddJudgeBtn.TabIndex = 7;
            this.AddJudgeBtn.Text = "→";
            this.AddJudgeBtn.UseVisualStyleBackColor = true;
            this.AddJudgeBtn.Click += new System.EventHandler(this.AddJudgeBtn_Click);
            // 
            // GlobalJudgesDataGridView
            // 
            this.GlobalJudgesDataGridView.AllowUserToAddRows = false;
            this.GlobalJudgesDataGridView.AllowUserToDeleteRows = false;
            this.GlobalJudgesDataGridView.AllowUserToResizeColumns = false;
            this.GlobalJudgesDataGridView.AllowUserToResizeRows = false;
            this.GlobalJudgesDataGridView.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.GlobalJudgesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GlobalJudgesDataGridView.Location = new System.Drawing.Point(-1, 0);
            this.GlobalJudgesDataGridView.Name = "GlobalJudgesDataGridView";
            this.GlobalJudgesDataGridView.RowHeadersWidth = 20;
            this.GlobalJudgesDataGridView.Size = new System.Drawing.Size(340, 227);
            this.GlobalJudgesDataGridView.TabIndex = 5;
            this.GlobalJudgesDataGridView.TabStop = false;
            // 
            // CurrentJudgesDataGridView
            // 
            this.CurrentJudgesDataGridView.AllowUserToAddRows = false;
            this.CurrentJudgesDataGridView.AllowUserToDeleteRows = false;
            this.CurrentJudgesDataGridView.AllowUserToOrderColumns = true;
            this.CurrentJudgesDataGridView.AllowUserToResizeColumns = false;
            this.CurrentJudgesDataGridView.AllowUserToResizeRows = false;
            this.CurrentJudgesDataGridView.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.CurrentJudgesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CurrentJudgesDataGridView.Location = new System.Drawing.Point(389, 0);
            this.CurrentJudgesDataGridView.Name = "CurrentJudgesDataGridView";
            this.CurrentJudgesDataGridView.RowHeadersWidth = 20;
            this.CurrentJudgesDataGridView.Size = new System.Drawing.Size(340, 227);
            this.CurrentJudgesDataGridView.TabIndex = 6;
            this.CurrentJudgesDataGridView.TabStop = false;
            // 
            // DiverTabPage
            // 
            this.DiverTabPage.Controls.Add(this.AddDiverBtn);
            this.DiverTabPage.Controls.Add(this.RemoveDiverBtn);
            this.DiverTabPage.Controls.Add(this.CurrentDiversDataGridView);
            this.DiverTabPage.Controls.Add(this.GlobalDiversDataGridView);
            this.DiverTabPage.Location = new System.Drawing.Point(4, 22);
            this.DiverTabPage.Name = "DiverTabPage";
            this.DiverTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.DiverTabPage.Size = new System.Drawing.Size(731, 227);
            this.DiverTabPage.TabIndex = 1;
            this.DiverTabPage.Text = "Divers";
            this.DiverTabPage.UseVisualStyleBackColor = true;
            // 
            // AddDiverBtn
            // 
            this.AddDiverBtn.Location = new System.Drawing.Point(346, 71);
            this.AddDiverBtn.Name = "AddDiverBtn";
            this.AddDiverBtn.Size = new System.Drawing.Size(37, 23);
            this.AddDiverBtn.TabIndex = 10;
            this.AddDiverBtn.Text = "→";
            this.AddDiverBtn.UseVisualStyleBackColor = true;
            this.AddDiverBtn.Click += new System.EventHandler(this.AddDiverBtn_Click);
            // 
            // RemoveDiverBtn
            // 
            this.RemoveDiverBtn.Location = new System.Drawing.Point(346, 100);
            this.RemoveDiverBtn.Name = "RemoveDiverBtn";
            this.RemoveDiverBtn.Size = new System.Drawing.Size(37, 23);
            this.RemoveDiverBtn.TabIndex = 9;
            this.RemoveDiverBtn.Text = "←";
            this.RemoveDiverBtn.UseVisualStyleBackColor = true;
            this.RemoveDiverBtn.Click += new System.EventHandler(this.RemoveDiverBtn_Click);
            // 
            // CurrentDiversDataGridView
            // 
            this.CurrentDiversDataGridView.AllowUserToAddRows = false;
            this.CurrentDiversDataGridView.AllowUserToDeleteRows = false;
            this.CurrentDiversDataGridView.AllowUserToOrderColumns = true;
            this.CurrentDiversDataGridView.AllowUserToResizeColumns = false;
            this.CurrentDiversDataGridView.AllowUserToResizeRows = false;
            this.CurrentDiversDataGridView.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.CurrentDiversDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CurrentDiversDataGridView.Location = new System.Drawing.Point(389, 0);
            this.CurrentDiversDataGridView.Name = "CurrentDiversDataGridView";
            this.CurrentDiversDataGridView.RowHeadersWidth = 20;
            this.CurrentDiversDataGridView.Size = new System.Drawing.Size(340, 227);
            this.CurrentDiversDataGridView.TabIndex = 7;
            this.CurrentDiversDataGridView.TabStop = false;
            // 
            // GlobalDiversDataGridView
            // 
            this.GlobalDiversDataGridView.AllowUserToAddRows = false;
            this.GlobalDiversDataGridView.AllowUserToDeleteRows = false;
            this.GlobalDiversDataGridView.AllowUserToOrderColumns = true;
            this.GlobalDiversDataGridView.AllowUserToResizeColumns = false;
            this.GlobalDiversDataGridView.AllowUserToResizeRows = false;
            this.GlobalDiversDataGridView.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.GlobalDiversDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GlobalDiversDataGridView.Location = new System.Drawing.Point(-1, 0);
            this.GlobalDiversDataGridView.Name = "GlobalDiversDataGridView";
            this.GlobalDiversDataGridView.RowHeadersWidth = 20;
            this.GlobalDiversDataGridView.Size = new System.Drawing.Size(340, 227);
            this.GlobalDiversDataGridView.TabIndex = 6;
            this.GlobalDiversDataGridView.TabStop = false;
            // 
            // ContestsDataGridView
            // 
            this.ContestsDataGridView.AllowUserToAddRows = false;
            this.ContestsDataGridView.AllowUserToDeleteRows = false;
            this.ContestsDataGridView.AllowUserToResizeColumns = false;
            this.ContestsDataGridView.AllowUserToResizeRows = false;
            this.ContestsDataGridView.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.ContestsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ContestsDataGridView.Location = new System.Drawing.Point(12, 12);
            this.ContestsDataGridView.Name = "ContestsDataGridView";
            this.ContestsDataGridView.Size = new System.Drawing.Size(490, 185);
            this.ContestsDataGridView.TabIndex = 4;
            this.ContestsDataGridView.TabStop = false;
            this.ContestsDataGridView.SelectionChanged += new System.EventHandler(this.ContestsDataGridView_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(496, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Current Judges";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "All Judges";
            // 
            // StartContest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 466);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ContestsDataGridView);
            this.Controls.Add(this.JudgesDiversTabControl);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartContest";
            this.Text = "StartContest";
            this.JudgesDiversTabControl.ResumeLayout(false);
            this.JudgeTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GlobalJudgesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentJudgesDataGridView)).EndInit();
            this.DiverTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CurrentDiversDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GlobalDiversDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContestsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl JudgesDiversTabControl;
        private System.Windows.Forms.TabPage JudgeTabPage;
        private System.Windows.Forms.TabPage DiverTabPage;
        private System.Windows.Forms.DataGridView ContestsDataGridView;
        private System.Windows.Forms.DataGridView GlobalJudgesDataGridView;
        private System.Windows.Forms.DataGridView CurrentJudgesDataGridView;
        private System.Windows.Forms.DataGridView CurrentDiversDataGridView;
        private System.Windows.Forms.DataGridView GlobalDiversDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button RemoveJudgeBtn;
        private System.Windows.Forms.Button AddJudgeBtn;
        private System.Windows.Forms.Button AddDiverBtn;
        private System.Windows.Forms.Button RemoveDiverBtn;
    }
}