﻿namespace SimhoppGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartContest));
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
            this.GlobalJudgesLabel = new System.Windows.Forms.Label();
            this.GlobalDiversLabel = new System.Windows.Forms.Label();
            this.CurrentlDiversLabel = new System.Windows.Forms.Label();
            this.EditContestBtn = new System.Windows.Forms.Button();
            this.StartContestBtn = new System.Windows.Forms.Button();
            this.EditContestToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.CloseBtn = new System.Windows.Forms.Button();
            this.StartContestToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.viewResultButton = new System.Windows.Forms.Button();
            this.ContestsDataGridHiddenLabel = new System.Windows.Forms.Label();
            this.DiversHiddenLabel = new System.Windows.Forms.Label();
            this.JudgesHiddenLabel = new System.Windows.Forms.Label();
            this.ContestsDataGridToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.JudgesToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.DiversToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ViewResultToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CurrentJudgesLabel = new System.Windows.Forms.Label();
            this.CloseToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.AddEditJudgeBtn = new System.Windows.Forms.Button();
            this.AddEditDiverBtn = new System.Windows.Forms.Button();
            this.NewContesttBtn = new System.Windows.Forms.Button();
            this.NewContestToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.AddEditDiverToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.AddEditJudgeToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.JudgesDiversTabControl.SuspendLayout();
            this.JudgeTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GlobalJudgesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentJudgesDataGridView)).BeginInit();
            this.DiverTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentDiversDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GlobalDiversDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContestsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // JudgesDiversTabControl
            // 
            this.JudgesDiversTabControl.Controls.Add(this.JudgeTabPage);
            this.JudgesDiversTabControl.Controls.Add(this.DiverTabPage);
            this.JudgesDiversTabControl.Location = new System.Drawing.Point(12, 203);
            this.JudgesDiversTabControl.Name = "JudgesDiversTabControl";
            this.JudgesDiversTabControl.SelectedIndex = 0;
            this.JudgesDiversTabControl.Size = new System.Drawing.Size(957, 253);
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
            this.JudgeTabPage.Size = new System.Drawing.Size(949, 227);
            this.JudgeTabPage.TabIndex = 0;
            this.JudgeTabPage.Text = "Judges";
            this.JudgeTabPage.UseVisualStyleBackColor = true;
            // 
            // RemoveJudgeBtn
            // 
            this.RemoveJudgeBtn.Location = new System.Drawing.Point(299, 100);
            this.RemoveJudgeBtn.Name = "RemoveJudgeBtn";
            this.RemoveJudgeBtn.Size = new System.Drawing.Size(37, 23);
            this.RemoveJudgeBtn.TabIndex = 5;
            this.RemoveJudgeBtn.Text = "←";
            this.RemoveJudgeBtn.UseVisualStyleBackColor = true;
            this.RemoveJudgeBtn.Click += new System.EventHandler(this.RemoveJudgeBtn_Click);
            // 
            // AddJudgeBtn
            // 
            this.AddJudgeBtn.Location = new System.Drawing.Point(299, 71);
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
            this.GlobalJudgesDataGridView.Size = new System.Drawing.Size(294, 227);
            this.GlobalJudgesDataGridView.TabIndex = 4;
            this.GlobalJudgesDataGridView.TabStop = false;
            this.GlobalJudgesDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GlobalJudgesDataGridView_KeyDown);
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
            this.CurrentJudgesDataGridView.Location = new System.Drawing.Point(342, 0);
            this.CurrentJudgesDataGridView.Name = "CurrentJudgesDataGridView";
            this.CurrentJudgesDataGridView.ReadOnly = true;
            this.CurrentJudgesDataGridView.RowHeadersWidth = 30;
            this.CurrentJudgesDataGridView.Size = new System.Drawing.Size(607, 227);
            this.CurrentJudgesDataGridView.TabIndex = 6;
            this.CurrentJudgesDataGridView.TabStop = false;
            this.CurrentJudgesDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CurrentJudgesDataGridView_KeyDown);
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
            this.DiverTabPage.Size = new System.Drawing.Size(949, 227);
            this.DiverTabPage.TabIndex = 1;
            this.DiverTabPage.Text = "Divers";
            this.DiverTabPage.UseVisualStyleBackColor = true;
            // 
            // AddDiverBtn
            // 
            this.AddDiverBtn.Location = new System.Drawing.Point(299, 71);
            this.AddDiverBtn.Name = "AddDiverBtn";
            this.AddDiverBtn.Size = new System.Drawing.Size(37, 23);
            this.AddDiverBtn.TabIndex = 5;
            this.AddDiverBtn.Text = "→";
            this.AddDiverBtn.UseVisualStyleBackColor = true;
            this.AddDiverBtn.Click += new System.EventHandler(this.AddDiverBtn_Click);
            // 
            // RemoveDiverBtn
            // 
            this.RemoveDiverBtn.Location = new System.Drawing.Point(299, 100);
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
            this.CurrentDiversDataGridView.Location = new System.Drawing.Point(342, 0);
            this.CurrentDiversDataGridView.Name = "CurrentDiversDataGridView";
            this.CurrentDiversDataGridView.RowHeadersWidth = 30;
            this.CurrentDiversDataGridView.Size = new System.Drawing.Size(607, 227);
            this.CurrentDiversDataGridView.TabIndex = 7;
            this.CurrentDiversDataGridView.TabStop = false;
            this.CurrentDiversDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CurrentDiversDataGridView_KeyDown);
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
            this.GlobalDiversDataGridView.Size = new System.Drawing.Size(294, 227);
            this.GlobalDiversDataGridView.TabIndex = 6;
            this.GlobalDiversDataGridView.TabStop = false;
            this.GlobalDiversDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GlobalDiversDataGridView_KeyDown);
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
            this.ContestsDataGridView.Size = new System.Drawing.Size(611, 179);
            this.ContestsDataGridView.TabIndex = 40;
            this.ContestsDataGridView.TabStop = false;
            this.ContestsDataGridView.SelectionChanged += new System.EventHandler(this.ContestsDataGridView_SelectionChanged);
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
            this.CurrentlDiversLabel.Location = new System.Drawing.Point(360, 209);
            this.CurrentlDiversLabel.Name = "CurrentlDiversLabel";
            this.CurrentlDiversLabel.Size = new System.Drawing.Size(74, 13);
            this.CurrentlDiversLabel.TabIndex = 8;
            this.CurrentlDiversLabel.Text = "Current Divers";
            this.CurrentlDiversLabel.Visible = false;
            // 
            // EditContestBtn
            // 
            this.EditContestBtn.Location = new System.Drawing.Point(806, 168);
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
            this.StartContestBtn.Location = new System.Drawing.Point(630, 168);
            this.StartContestBtn.Name = "StartContestBtn";
            this.StartContestBtn.Size = new System.Drawing.Size(75, 23);
            this.StartContestBtn.TabIndex = 5;
            this.StartContestBtn.Text = "Start Contest";
            this.StartContestToolTip.SetToolTip(this.StartContestBtn, "Ctrl+S");
            this.StartContestBtn.UseVisualStyleBackColor = true;
            this.StartContestBtn.Click += new System.EventHandler(this.StartContestBtn_Click);
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(894, 168);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(75, 23);
            this.CloseBtn.TabIndex = 44;
            this.CloseBtn.Text = "Close";
            this.CloseToolTip.SetToolTip(this.CloseBtn, "Escape");
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // viewResultButton
            // 
            this.viewResultButton.Location = new System.Drawing.Point(718, 168);
            this.viewResultButton.Name = "viewResultButton";
            this.viewResultButton.Size = new System.Drawing.Size(75, 23);
            this.viewResultButton.TabIndex = 6;
            this.viewResultButton.Text = "View Result";
            this.ViewResultToolTip.SetToolTip(this.viewResultButton, "Ctrl+R");
            this.viewResultButton.UseVisualStyleBackColor = true;
            this.viewResultButton.Click += new System.EventHandler(this.viewResultButton_Click);
            // 
            // ContestsDataGridHiddenLabel
            // 
            this.ContestsDataGridHiddenLabel.AutoSize = true;
            this.ContestsDataGridHiddenLabel.Enabled = false;
            this.ContestsDataGridHiddenLabel.Location = new System.Drawing.Point(13, 12);
            this.ContestsDataGridHiddenLabel.Name = "ContestsDataGridHiddenLabel";
            this.ContestsDataGridHiddenLabel.Size = new System.Drawing.Size(66, 13);
            this.ContestsDataGridHiddenLabel.TabIndex = 43;
            this.ContestsDataGridHiddenLabel.Text = "Hidden label";
            this.ContestsDataGridHiddenLabel.Visible = false;
            // 
            // DiversHiddenLabel
            // 
            this.DiversHiddenLabel.AutoSize = true;
            this.DiversHiddenLabel.Enabled = false;
            this.DiversHiddenLabel.Location = new System.Drawing.Point(83, 187);
            this.DiversHiddenLabel.Name = "DiversHiddenLabel";
            this.DiversHiddenLabel.Size = new System.Drawing.Size(66, 13);
            this.DiversHiddenLabel.TabIndex = 41;
            this.DiversHiddenLabel.Text = "Hidden label";
            this.DiversHiddenLabel.Visible = false;
            // 
            // JudgesHiddenLabel
            // 
            this.JudgesHiddenLabel.AutoSize = true;
            this.JudgesHiddenLabel.Enabled = false;
            this.JudgesHiddenLabel.Location = new System.Drawing.Point(13, 187);
            this.JudgesHiddenLabel.Name = "JudgesHiddenLabel";
            this.JudgesHiddenLabel.Size = new System.Drawing.Size(66, 13);
            this.JudgesHiddenLabel.TabIndex = 42;
            this.JudgesHiddenLabel.Text = "Hidden label";
            this.JudgesHiddenLabel.Visible = false;
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.ContainerControl = this;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1096, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 30;
            this.dataGridView1.Size = new System.Drawing.Size(0, 81);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.TabStop = false;
            // 
            // CurrentJudgesLabel
            // 
            this.CurrentJudgesLabel.AutoSize = true;
            this.CurrentJudgesLabel.Location = new System.Drawing.Point(360, 209);
            this.CurrentJudgesLabel.Name = "CurrentJudgesLabel";
            this.CurrentJudgesLabel.Size = new System.Drawing.Size(78, 13);
            this.CurrentJudgesLabel.TabIndex = 6;
            this.CurrentJudgesLabel.Text = "Current Judges";
            // 
            // AddEditJudgeBtn
            // 
            this.AddEditJudgeBtn.Location = new System.Drawing.Point(849, 64);
            this.AddEditJudgeBtn.Name = "AddEditJudgeBtn";
            this.AddEditJudgeBtn.Size = new System.Drawing.Size(72, 66);
            this.AddEditJudgeBtn.TabIndex = 47;
            this.AddEditJudgeBtn.Text = "Add/Edit Judge";
            this.AddEditDiverToolTip.SetToolTip(this.AddEditJudgeBtn, "Shift+3");
            this.AddEditJudgeBtn.UseVisualStyleBackColor = true;
            this.AddEditJudgeBtn.Click += new System.EventHandler(this.StartScreenAddJudgeBtn_Click);
            // 
            // AddEditDiverBtn
            // 
            this.AddEditDiverBtn.Location = new System.Drawing.Point(761, 64);
            this.AddEditDiverBtn.Name = "AddEditDiverBtn";
            this.AddEditDiverBtn.Size = new System.Drawing.Size(72, 66);
            this.AddEditDiverBtn.TabIndex = 46;
            this.AddEditDiverBtn.Text = "Add/Edit Diver";
            this.NewContestToolTip.SetToolTip(this.AddEditDiverBtn, " ");
            this.AddEditDiverToolTip.SetToolTip(this.AddEditDiverBtn, "Shift+2");
            this.AddEditDiverBtn.UseVisualStyleBackColor = true;
            this.AddEditDiverBtn.Click += new System.EventHandler(this.StartScreenAddDiverContestBtn_Click);
            // 
            // NewContesttBtn
            // 
            this.NewContesttBtn.Location = new System.Drawing.Point(673, 64);
            this.NewContesttBtn.Name = "NewContesttBtn";
            this.NewContesttBtn.Size = new System.Drawing.Size(72, 66);
            this.NewContesttBtn.TabIndex = 45;
            this.NewContesttBtn.Text = "New Contest";
            this.NewContestToolTip.SetToolTip(this.NewContesttBtn, "Shift+1");
            this.NewContesttBtn.UseVisualStyleBackColor = true;
            this.NewContesttBtn.Click += new System.EventHandler(this.StartScreenNewContesttBtn_Click);
            // 
            // StartContest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 463);
            this.Controls.Add(this.AddEditJudgeBtn);
            this.Controls.Add(this.AddEditDiverBtn);
            this.Controls.Add(this.NewContesttBtn);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ContestsDataGridHiddenLabel);
            this.Controls.Add(this.DiversHiddenLabel);
            this.Controls.Add(this.JudgesHiddenLabel);
            this.Controls.Add(this.viewResultButton);
            this.Controls.Add(this.StartContestBtn);
            this.Controls.Add(this.EditContestBtn);
            this.Controls.Add(this.GlobalDiversLabel);
            this.Controls.Add(this.CurrentlDiversLabel);
            this.Controls.Add(this.GlobalJudgesLabel);
            this.Controls.Add(this.CurrentJudgesLabel);
            this.Controls.Add(this.ContestsDataGridView);
            this.Controls.Add(this.JudgesDiversTabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartContest";
            this.Text = "Simhopp";
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
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.Label ContestsDataGridHiddenLabel;
        private System.Windows.Forms.Label DiversHiddenLabel;
        private System.Windows.Forms.Label JudgesHiddenLabel;
        private System.Windows.Forms.ToolTip ContestsDataGridToolTip;
        private System.Windows.Forms.ToolTip JudgesToolTip;
        private System.Windows.Forms.ToolTip DiversToolTip;
        private System.Windows.Forms.ToolTip ViewResultToolTip;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Label CurrentJudgesLabel;
        private System.Windows.Forms.ToolTip CloseToolTip;
        private System.Windows.Forms.Button AddEditJudgeBtn;
        private System.Windows.Forms.Button AddEditDiverBtn;
        private System.Windows.Forms.Button NewContesttBtn;
        private System.Windows.Forms.ToolTip NewContestToolTip;
        private System.Windows.Forms.ToolTip AddEditDiverToolTip;
        private System.Windows.Forms.ToolTip AddEditJudgeToolTip;
    }
}