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
            this.GlobalJudgesDataGridView = new System.Windows.Forms.DataGridView();
            this.GlobalDiversDataGridView = new System.Windows.Forms.DataGridView();
            this.JudgesDiversTabControl = new System.Windows.Forms.TabControl();
            this.JudgeTabPage = new System.Windows.Forms.TabPage();
            this.DiverTabPage = new System.Windows.Forms.TabPage();
            this.JudgesTabControl = new System.Windows.Forms.TabControl();
            this.GlobalJudgesTabPage = new System.Windows.Forms.TabPage();
            this.CurrentJudgesTabPage = new System.Windows.Forms.TabPage();
            this.CurrentJudgesDataGridView = new System.Windows.Forms.DataGridView();
            this.DiversTabControl = new System.Windows.Forms.TabControl();
            this.GlobalDiversTabPage = new System.Windows.Forms.TabPage();
            this.CurrentDiversTabPage = new System.Windows.Forms.TabPage();
            this.CurrentDiversDataGridView = new System.Windows.Forms.DataGridView();
            this.ContestsDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.GlobalJudgesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GlobalDiversDataGridView)).BeginInit();
            this.JudgesDiversTabControl.SuspendLayout();
            this.JudgesTabControl.SuspendLayout();
            this.GlobalJudgesTabPage.SuspendLayout();
            this.CurrentJudgesTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentJudgesDataGridView)).BeginInit();
            this.DiversTabControl.SuspendLayout();
            this.GlobalDiversTabPage.SuspendLayout();
            this.CurrentDiversTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentDiversDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContestsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // GlobalJudgesDataGridView
            // 
            this.GlobalJudgesDataGridView.AllowUserToResizeColumns = false;
            this.GlobalJudgesDataGridView.AllowUserToResizeRows = false;
            this.GlobalJudgesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GlobalJudgesDataGridView.Location = new System.Drawing.Point(0, 0);
            this.GlobalJudgesDataGridView.Name = "GlobalJudgesDataGridView";
            this.GlobalJudgesDataGridView.ReadOnly = true;
            this.GlobalJudgesDataGridView.Size = new System.Drawing.Size(364, 217);
            this.GlobalJudgesDataGridView.TabIndex = 1;
            // 
            // GlobalDiversDataGridView
            // 
            this.GlobalDiversDataGridView.AllowUserToResizeColumns = false;
            this.GlobalDiversDataGridView.AllowUserToResizeRows = false;
            this.GlobalDiversDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GlobalDiversDataGridView.Location = new System.Drawing.Point(6, 6);
            this.GlobalDiversDataGridView.Name = "GlobalDiversDataGridView";
            this.GlobalDiversDataGridView.ReadOnly = true;
            this.GlobalDiversDataGridView.Size = new System.Drawing.Size(368, 206);
            this.GlobalDiversDataGridView.TabIndex = 2;
            // 
            // JudgesDiversTabControl
            // 
            this.JudgesDiversTabControl.Controls.Add(this.JudgeTabPage);
            this.JudgesDiversTabControl.Controls.Add(this.DiverTabPage);
            this.JudgesDiversTabControl.Location = new System.Drawing.Point(981, 295);
            this.JudgesDiversTabControl.Name = "JudgesDiversTabControl";
            this.JudgesDiversTabControl.SelectedIndex = 0;
            this.JudgesDiversTabControl.Size = new System.Drawing.Size(168, 94);
            this.JudgesDiversTabControl.TabIndex = 3;
            // 
            // JudgeTabPage
            // 
            this.JudgeTabPage.Location = new System.Drawing.Point(4, 22);
            this.JudgeTabPage.Name = "JudgeTabPage";
            this.JudgeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.JudgeTabPage.Size = new System.Drawing.Size(160, 68);
            this.JudgeTabPage.TabIndex = 0;
            this.JudgeTabPage.Text = "Judges";
            this.JudgeTabPage.UseVisualStyleBackColor = true;
            // 
            // DiverTabPage
            // 
            this.DiverTabPage.Location = new System.Drawing.Point(4, 22);
            this.DiverTabPage.Name = "DiverTabPage";
            this.DiverTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.DiverTabPage.Size = new System.Drawing.Size(160, 68);
            this.DiverTabPage.TabIndex = 1;
            this.DiverTabPage.Text = "Divers";
            this.DiverTabPage.UseVisualStyleBackColor = true;
            // 
            // JudgesTabControl
            // 
            this.JudgesTabControl.Controls.Add(this.GlobalJudgesTabPage);
            this.JudgesTabControl.Controls.Add(this.CurrentJudgesTabPage);
            this.JudgesTabControl.Location = new System.Drawing.Point(12, 214);
            this.JudgesTabControl.Name = "JudgesTabControl";
            this.JudgesTabControl.SelectedIndex = 0;
            this.JudgesTabControl.Size = new System.Drawing.Size(374, 241);
            this.JudgesTabControl.TabIndex = 0;
            this.JudgesTabControl.SelectedIndexChanged += new System.EventHandler(this.JudgesTabControl_SelectedIndexChanged);
            // 
            // GlobalJudgesTabPage
            // 
            this.GlobalJudgesTabPage.Controls.Add(this.GlobalJudgesDataGridView);
            this.GlobalJudgesTabPage.Location = new System.Drawing.Point(4, 22);
            this.GlobalJudgesTabPage.Name = "GlobalJudgesTabPage";
            this.GlobalJudgesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.GlobalJudgesTabPage.Size = new System.Drawing.Size(366, 215);
            this.GlobalJudgesTabPage.TabIndex = 0;
            this.GlobalJudgesTabPage.Text = "Global Judges";
            this.GlobalJudgesTabPage.UseVisualStyleBackColor = true;
            // 
            // CurrentJudgesTabPage
            // 
            this.CurrentJudgesTabPage.Controls.Add(this.CurrentJudgesDataGridView);
            this.CurrentJudgesTabPage.Location = new System.Drawing.Point(4, 22);
            this.CurrentJudgesTabPage.Name = "CurrentJudgesTabPage";
            this.CurrentJudgesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.CurrentJudgesTabPage.Size = new System.Drawing.Size(366, 215);
            this.CurrentJudgesTabPage.TabIndex = 1;
            this.CurrentJudgesTabPage.Text = "Curent Judges";
            this.CurrentJudgesTabPage.UseVisualStyleBackColor = true;
            // 
            // CurrentJudgesDataGridView
            // 
            this.CurrentJudgesDataGridView.AllowUserToResizeColumns = false;
            this.CurrentJudgesDataGridView.AllowUserToResizeRows = false;
            this.CurrentJudgesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CurrentJudgesDataGridView.Location = new System.Drawing.Point(-1, 0);
            this.CurrentJudgesDataGridView.Name = "CurrentJudgesDataGridView";
            this.CurrentJudgesDataGridView.ReadOnly = true;
            this.CurrentJudgesDataGridView.Size = new System.Drawing.Size(367, 215);
            this.CurrentJudgesDataGridView.TabIndex = 4;
            // 
            // DiversTabControl
            // 
            this.DiversTabControl.Controls.Add(this.GlobalDiversTabPage);
            this.DiversTabControl.Controls.Add(this.CurrentDiversTabPage);
            this.DiversTabControl.Location = new System.Drawing.Point(392, 214);
            this.DiversTabControl.Name = "DiversTabControl";
            this.DiversTabControl.SelectedIndex = 0;
            this.DiversTabControl.Size = new System.Drawing.Size(385, 241);
            this.DiversTabControl.TabIndex = 0;
            // 
            // GlobalDiversTabPage
            // 
            this.GlobalDiversTabPage.Controls.Add(this.GlobalDiversDataGridView);
            this.GlobalDiversTabPage.Location = new System.Drawing.Point(4, 22);
            this.GlobalDiversTabPage.Name = "GlobalDiversTabPage";
            this.GlobalDiversTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.GlobalDiversTabPage.Size = new System.Drawing.Size(377, 215);
            this.GlobalDiversTabPage.TabIndex = 0;
            this.GlobalDiversTabPage.Text = "Global Divers";
            this.GlobalDiversTabPage.UseVisualStyleBackColor = true;
            // 
            // CurrentDiversTabPage
            // 
            this.CurrentDiversTabPage.Controls.Add(this.CurrentDiversDataGridView);
            this.CurrentDiversTabPage.Location = new System.Drawing.Point(4, 22);
            this.CurrentDiversTabPage.Name = "CurrentDiversTabPage";
            this.CurrentDiversTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.CurrentDiversTabPage.Size = new System.Drawing.Size(377, 215);
            this.CurrentDiversTabPage.TabIndex = 1;
            this.CurrentDiversTabPage.Text = "Current Divers";
            this.CurrentDiversTabPage.UseVisualStyleBackColor = true;
            // 
            // CurrentDiversDataGridView
            // 
            this.CurrentDiversDataGridView.AllowUserToResizeColumns = false;
            this.CurrentDiversDataGridView.AllowUserToResizeRows = false;
            this.CurrentDiversDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CurrentDiversDataGridView.Location = new System.Drawing.Point(0, 3);
            this.CurrentDiversDataGridView.Name = "CurrentDiversDataGridView";
            this.CurrentDiversDataGridView.ReadOnly = true;
            this.CurrentDiversDataGridView.Size = new System.Drawing.Size(250, 122);
            this.CurrentDiversDataGridView.TabIndex = 4;
            // 
            // ContestsDataGridView
            // 
            this.ContestsDataGridView.AllowUserToAddRows = false;
            this.ContestsDataGridView.AllowUserToDeleteRows = false;
            this.ContestsDataGridView.AllowUserToOrderColumns = true;
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
            // StartContest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 593);
            this.Controls.Add(this.ContestsDataGridView);
            this.Controls.Add(this.JudgesTabControl);
            this.Controls.Add(this.DiversTabControl);
            this.Controls.Add(this.JudgesDiversTabControl);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartContest";
            this.Text = "StartContest";
            ((System.ComponentModel.ISupportInitialize)(this.GlobalJudgesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GlobalDiversDataGridView)).EndInit();
            this.JudgesDiversTabControl.ResumeLayout(false);
            this.JudgesTabControl.ResumeLayout(false);
            this.GlobalJudgesTabPage.ResumeLayout(false);
            this.CurrentJudgesTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CurrentJudgesDataGridView)).EndInit();
            this.DiversTabControl.ResumeLayout(false);
            this.GlobalDiversTabPage.ResumeLayout(false);
            this.CurrentDiversTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CurrentDiversDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContestsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView GlobalJudgesDataGridView;
        private System.Windows.Forms.DataGridView GlobalDiversDataGridView;
        private System.Windows.Forms.TabControl JudgesDiversTabControl;
        private System.Windows.Forms.TabPage JudgeTabPage;
        private System.Windows.Forms.TabPage DiverTabPage;
        private System.Windows.Forms.TabControl JudgesTabControl;
        private System.Windows.Forms.TabPage GlobalJudgesTabPage;
        private System.Windows.Forms.TabPage CurrentJudgesTabPage;
        private System.Windows.Forms.TabControl DiversTabControl;
        private System.Windows.Forms.TabPage GlobalDiversTabPage;
        private System.Windows.Forms.TabPage CurrentDiversTabPage;
        private System.Windows.Forms.DataGridView CurrentJudgesDataGridView;
        private System.Windows.Forms.DataGridView CurrentDiversDataGridView;
        private System.Windows.Forms.DataGridView ContestsDataGridView;
    }
}