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
            this.components = new System.ComponentModel.Container();
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
            this.CurrentJudgesLabel = new System.Windows.Forms.Label();
            this.GlobalJudgesLabel = new System.Windows.Forms.Label();
            this.GlobalDiversLabel = new System.Windows.Forms.Label();
            this.CurrentlDiversLabel = new System.Windows.Forms.Label();
            this.EditContestBtn = new System.Windows.Forms.Button();
            this.StartContestBtn = new System.Windows.Forms.Button();
            this.EditContestToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.StartContestToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.viewResultButton = new System.Windows.Forms.Button();
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
            this.JudgesDiversTabControl.Size = new System.Drawing.Size(1040, 253);
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
            this.JudgeTabPage.Size = new System.Drawing.Size(1032, 227);
            this.JudgeTabPage.TabIndex = 0;
            this.JudgeTabPage.Text = "Judges";
            this.JudgeTabPage.UseVisualStyleBackColor = true;
            // 
            // RemoveJudgeBtn
            // 
            this.RemoveJudgeBtn.Location = new System.Drawing.Point(346, 100);
            this.RemoveJudgeBtn.Name = "RemoveJudgeBtn";
            this.RemoveJudgeBtn.Size = new System.Drawing.Size(37, 23);
            this.RemoveJudgeBtn.TabIndex = 5;
            this.RemoveJudgeBtn.Text = "←";
            this.RemoveJudgeBtn.UseVisualStyleBackColor = true;
            this.RemoveJudgeBtn.Click += new System.EventHandler(this.RemoveJudgeBtn_Click);
            // 
            // AddJudgeBtn
            // 
            this.AddJudgeBtn.Location = new System.Drawing.Point(346, 71);
            this.AddJudgeBtn.Name = "AddJudgeBtn";
            this.AddJudgeBtn.Size = new System.Drawing.Size(37, 23);
            this.AddJudgeBtn.TabIndex = 4;
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
            this.GlobalJudgesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GlobalJudgesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GlobalJudgesDataGridView.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.GlobalJudgesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GlobalJudgesDataGridView.Location = new System.Drawing.Point(-1, 0);
            this.GlobalJudgesDataGridView.Name = "GlobalJudgesDataGridView";
            this.GlobalJudgesDataGridView.ReadOnly = true;
            this.GlobalJudgesDataGridView.RowHeadersWidth = 30;
            this.GlobalJudgesDataGridView.Size = new System.Drawing.Size(340, 227);
            this.GlobalJudgesDataGridView.TabIndex = 4;
            this.GlobalJudgesDataGridView.TabStop = false;
            // 
            // CurrentJudgesDataGridView
            // 
            this.CurrentJudgesDataGridView.AllowUserToAddRows = false;
            this.CurrentJudgesDataGridView.AllowUserToDeleteRows = false;
            this.CurrentJudgesDataGridView.AllowUserToOrderColumns = true;
            this.CurrentJudgesDataGridView.AllowUserToResizeColumns = false;
            this.CurrentJudgesDataGridView.AllowUserToResizeRows = false;
            this.CurrentJudgesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentJudgesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CurrentJudgesDataGridView.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.CurrentJudgesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CurrentJudgesDataGridView.Location = new System.Drawing.Point(389, 0);
            this.CurrentJudgesDataGridView.Name = "CurrentJudgesDataGridView";
            this.CurrentJudgesDataGridView.ReadOnly = true;
            this.CurrentJudgesDataGridView.RowHeadersWidth = 30;
            this.CurrentJudgesDataGridView.Size = new System.Drawing.Size(643, 227);
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
            this.DiverTabPage.Size = new System.Drawing.Size(1032, 227);
            this.DiverTabPage.TabIndex = 1;
            this.DiverTabPage.Text = "Divers";
            this.DiverTabPage.UseVisualStyleBackColor = true;
            // 
            // AddDiverBtn
            // 
            this.AddDiverBtn.Location = new System.Drawing.Point(346, 71);
            this.AddDiverBtn.Name = "AddDiverBtn";
            this.AddDiverBtn.Size = new System.Drawing.Size(37, 23);
            this.AddDiverBtn.TabIndex = 5;
            this.AddDiverBtn.Text = "→";
            this.AddDiverBtn.UseVisualStyleBackColor = true;
            this.AddDiverBtn.Click += new System.EventHandler(this.AddDiverBtn_Click);
            // 
            // RemoveDiverBtn
            // 
            this.RemoveDiverBtn.Location = new System.Drawing.Point(346, 100);
            this.RemoveDiverBtn.Name = "RemoveDiverBtn";
            this.RemoveDiverBtn.Size = new System.Drawing.Size(37, 23);
            this.RemoveDiverBtn.TabIndex = 5;
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
            this.CurrentDiversDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentDiversDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CurrentDiversDataGridView.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.CurrentDiversDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CurrentDiversDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.CurrentDiversDataGridView.Location = new System.Drawing.Point(389, 0);
            this.CurrentDiversDataGridView.Name = "CurrentDiversDataGridView";
            this.CurrentDiversDataGridView.RowHeadersWidth = 30;
            this.CurrentDiversDataGridView.Size = new System.Drawing.Size(643, 227);
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
            this.GlobalDiversDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GlobalDiversDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GlobalDiversDataGridView.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.GlobalDiversDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GlobalDiversDataGridView.Location = new System.Drawing.Point(-1, 0);
            this.GlobalDiversDataGridView.Name = "GlobalDiversDataGridView";
            this.GlobalDiversDataGridView.ReadOnly = true;
            this.GlobalDiversDataGridView.RowHeadersWidth = 30;
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
            this.ContestsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ContestsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ContestsDataGridView.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.ContestsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ContestsDataGridView.Location = new System.Drawing.Point(12, 12);
            this.ContestsDataGridView.Name = "ContestsDataGridView";
            this.ContestsDataGridView.ReadOnly = true;
            this.ContestsDataGridView.Size = new System.Drawing.Size(563, 179);
            this.ContestsDataGridView.TabIndex = 40;
            this.ContestsDataGridView.TabStop = false;
            this.ContestsDataGridView.SelectionChanged += new System.EventHandler(this.ContestsDataGridView_SelectionChanged);
            // 
            // CurrentJudgesLabel
            // 
            this.CurrentJudgesLabel.AutoSize = true;
            this.CurrentJudgesLabel.Location = new System.Drawing.Point(496, 209);
            this.CurrentJudgesLabel.Name = "CurrentJudgesLabel";
            this.CurrentJudgesLabel.Size = new System.Drawing.Size(78, 13);
            this.CurrentJudgesLabel.TabIndex = 6;
            this.CurrentJudgesLabel.Text = "Current Judges";
            // 
            // GlobalJudgesLabel
            // 
            this.GlobalJudgesLabel.AutoSize = true;
            this.GlobalJudgesLabel.Location = new System.Drawing.Point(149, 208);
            this.GlobalJudgesLabel.Name = "GlobalJudgesLabel";
            this.GlobalJudgesLabel.Size = new System.Drawing.Size(55, 13);
            this.GlobalJudgesLabel.TabIndex = 7;
            this.GlobalJudgesLabel.Text = "All Judges";
            // 
            // GlobalDiversLabel
            // 
            this.GlobalDiversLabel.AutoSize = true;
            this.GlobalDiversLabel.Location = new System.Drawing.Point(152, 208);
            this.GlobalDiversLabel.Name = "GlobalDiversLabel";
            this.GlobalDiversLabel.Size = new System.Drawing.Size(51, 13);
            this.GlobalDiversLabel.TabIndex = 9;
            this.GlobalDiversLabel.Text = "All Divers";
            this.GlobalDiversLabel.Visible = false;
            // 
            // CurrentlDiversLabel
            // 
            this.CurrentlDiversLabel.AutoSize = true;
            this.CurrentlDiversLabel.Location = new System.Drawing.Point(499, 209);
            this.CurrentlDiversLabel.Name = "CurrentlDiversLabel";
            this.CurrentlDiversLabel.Size = new System.Drawing.Size(74, 13);
            this.CurrentlDiversLabel.TabIndex = 8;
            this.CurrentlDiversLabel.Text = "Current Divers";
            this.CurrentlDiversLabel.Visible = false;
            // 
            // EditContestBtn
            // 
            this.EditContestBtn.Location = new System.Drawing.Point(588, 166);
            this.EditContestBtn.Name = "EditContestBtn";
            this.EditContestBtn.Size = new System.Drawing.Size(75, 23);
            this.EditContestBtn.TabIndex = 7;
            this.EditContestBtn.Text = "Edit Contest";
            this.EditContestToolTip.SetToolTip(this.EditContestBtn, "Ctrl+E");
            this.EditContestBtn.UseVisualStyleBackColor = true;
            this.EditContestBtn.Click += new System.EventHandler(this.EditContestBtn_Click);
            // 
            // StartContestBtn
            // 
            this.StartContestBtn.Location = new System.Drawing.Point(588, 108);
            this.StartContestBtn.Name = "StartContestBtn";
            this.StartContestBtn.Size = new System.Drawing.Size(75, 23);
            this.StartContestBtn.TabIndex = 5;
            this.StartContestBtn.Text = "Start Contest";
            this.StartContestToolTip.SetToolTip(this.StartContestBtn, "Ctrl+S");
            this.StartContestBtn.UseVisualStyleBackColor = true;
            this.StartContestBtn.Click += new System.EventHandler(this.StartContestBtn_Click);
            // 
            // viewResultButton
            // 
            this.viewResultButton.Location = new System.Drawing.Point(588, 137);
            this.viewResultButton.Name = "viewResultButton";
            this.viewResultButton.Size = new System.Drawing.Size(75, 23);
            this.viewResultButton.TabIndex = 6;
            this.viewResultButton.Text = "View Result";
            this.viewResultButton.UseVisualStyleBackColor = true;
            this.viewResultButton.Click += new System.EventHandler(this.viewResultButton_Click);
            // 
            // StartContest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 463);
            this.Controls.Add(this.viewResultButton);
            this.Controls.Add(this.StartContestBtn);
            this.Controls.Add(this.EditContestBtn);
            this.Controls.Add(this.GlobalDiversLabel);
            this.Controls.Add(this.CurrentlDiversLabel);
            this.Controls.Add(this.GlobalJudgesLabel);
            this.Controls.Add(this.CurrentJudgesLabel);
            this.Controls.Add(this.ContestsDataGridView);
            this.Controls.Add(this.JudgesDiversTabControl);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartContest";
            this.Text = "StartContest";
            this.Load += new System.EventHandler(this.StartContest_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StartContest_KeyUp);
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
        private System.Windows.Forms.Label CurrentJudgesLabel;
        private System.Windows.Forms.Label GlobalJudgesLabel;
        private System.Windows.Forms.Button RemoveJudgeBtn;
        private System.Windows.Forms.Button AddJudgeBtn;
        private System.Windows.Forms.Button AddDiverBtn;
        private System.Windows.Forms.Button RemoveDiverBtn;
        private System.Windows.Forms.Label GlobalDiversLabel;
        private System.Windows.Forms.Label CurrentlDiversLabel;
        private System.Windows.Forms.Button EditContestBtn;
        private System.Windows.Forms.Button StartContestBtn;
        private System.Windows.Forms.ToolTip EditContestToolTip;
        private System.Windows.Forms.ToolTip StartContestToolTip;
        private System.Windows.Forms.Button viewResultButton;
    }
}