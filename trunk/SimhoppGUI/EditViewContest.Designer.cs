namespace SimhoppGUI
{
    partial class EditViewContest
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
            this.listViewEditViewContest = new System.Windows.Forms.ListView();
            this.ContestName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ContestPlace = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ContestDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EditViewContestEditChangesBtn = new System.Windows.Forms.Button();
            this.EditViewContestEditEndtDateTp = new System.Windows.Forms.DateTimePicker();
            this.EditViewContestEditStartDateTp = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.EditViewContestEditContestPlaceTb = new System.Windows.Forms.TextBox();
            this.EditViewContestEditContestNameTb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.EditViewContestCloseBtn = new System.Windows.Forms.Button();
            this.ContestsDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ContestsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // listViewEditViewContest
            // 
            this.listViewEditViewContest.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ContestName,
            this.ContestPlace,
            this.ContestDate});
            this.listViewEditViewContest.Location = new System.Drawing.Point(472, 322);
            this.listViewEditViewContest.Name = "listViewEditViewContest";
            this.listViewEditViewContest.Size = new System.Drawing.Size(343, 100);
            this.listViewEditViewContest.TabIndex = 0;
            this.listViewEditViewContest.UseCompatibleStateImageBehavior = false;
            this.listViewEditViewContest.View = System.Windows.Forms.View.Details;
            // 
            // ContestName
            // 
            this.ContestName.Text = "Contest Name";
            this.ContestName.Width = 178;
            // 
            // ContestPlace
            // 
            this.ContestPlace.Text = "Place";
            this.ContestPlace.Width = 201;
            // 
            // ContestDate
            // 
            this.ContestDate.Text = "Date";
            this.ContestDate.Width = 75;
            // 
            // EditViewContestEditChangesBtn
            // 
            this.EditViewContestEditChangesBtn.Location = new System.Drawing.Point(68, 415);
            this.EditViewContestEditChangesBtn.Name = "EditViewContestEditChangesBtn";
            this.EditViewContestEditChangesBtn.Size = new System.Drawing.Size(113, 27);
            this.EditViewContestEditChangesBtn.TabIndex = 18;
            this.EditViewContestEditChangesBtn.Text = "Update changes";
            this.EditViewContestEditChangesBtn.UseVisualStyleBackColor = true;
            this.EditViewContestEditChangesBtn.Click += new System.EventHandler(this.EditViewContestEditChangesBtn_Click);
            // 
            // EditViewContestEditEndtDateTp
            // 
            this.EditViewContestEditEndtDateTp.Location = new System.Drawing.Point(155, 374);
            this.EditViewContestEditEndtDateTp.Name = "EditViewContestEditEndtDateTp";
            this.EditViewContestEditEndtDateTp.Size = new System.Drawing.Size(200, 20);
            this.EditViewContestEditEndtDateTp.TabIndex = 17;
            // 
            // EditViewContestEditStartDateTp
            // 
            this.EditViewContestEditStartDateTp.Location = new System.Drawing.Point(155, 316);
            this.EditViewContestEditStartDateTp.Name = "EditViewContestEditStartDateTp";
            this.EditViewContestEditStartDateTp.Size = new System.Drawing.Size(200, 20);
            this.EditViewContestEditStartDateTp.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 380);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Edit End Date";
            // 
            // EditViewContestEditContestPlaceTb
            // 
            this.EditViewContestEditContestPlaceTb.Location = new System.Drawing.Point(155, 261);
            this.EditViewContestEditContestPlaceTb.Name = "EditViewContestEditContestPlaceTb";
            this.EditViewContestEditContestPlaceTb.Size = new System.Drawing.Size(200, 20);
            this.EditViewContestEditContestPlaceTb.TabIndex = 14;
            // 
            // EditViewContestEditContestNameTb
            // 
            this.EditViewContestEditContestNameTb.Location = new System.Drawing.Point(155, 203);
            this.EditViewContestEditContestNameTb.Name = "EditViewContestEditContestNameTb";
            this.EditViewContestEditContestNameTb.Size = new System.Drawing.Size(200, 20);
            this.EditViewContestEditContestNameTb.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 322);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Edit Start Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 264);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Edit Place";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Edit Contest Name";
            // 
            // EditViewContestCloseBtn
            // 
            this.EditViewContestCloseBtn.Location = new System.Drawing.Point(205, 415);
            this.EditViewContestCloseBtn.Name = "EditViewContestCloseBtn";
            this.EditViewContestCloseBtn.Size = new System.Drawing.Size(113, 27);
            this.EditViewContestCloseBtn.TabIndex = 20;
            this.EditViewContestCloseBtn.Text = "Close";
            this.EditViewContestCloseBtn.UseVisualStyleBackColor = true;
            this.EditViewContestCloseBtn.Click += new System.EventHandler(this.EditViewContestCloseBtn_Click);
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
            this.ContestsDataGridView.Size = new System.Drawing.Size(343, 185);
            this.ContestsDataGridView.TabIndex = 0;
            this.ContestsDataGridView.TabStop = false;
            this.ContestsDataGridView.SelectionChanged += new System.EventHandler(this.ContestsDataGridView_SelectionChanged);
            // 
            // EditViewContest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 466);
            this.Controls.Add(this.EditViewContestEditContestNameTb);
            this.Controls.Add(this.EditViewContestEditEndtDateTp);
            this.Controls.Add(this.ContestsDataGridView);
            this.Controls.Add(this.EditViewContestEditChangesBtn);
            this.Controls.Add(this.EditViewContestEditStartDateTp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.EditViewContestCloseBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewEditViewContest);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.EditViewContestEditContestPlaceTb);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditViewContest";
            this.Text = "Edit/View Contest";
            ((System.ComponentModel.ISupportInitialize)(this.ContestsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewEditViewContest;
        private System.Windows.Forms.ColumnHeader ContestName;
        private System.Windows.Forms.ColumnHeader ContestPlace;
        private System.Windows.Forms.ColumnHeader ContestDate;
        private System.Windows.Forms.Button EditViewContestEditChangesBtn;
        private System.Windows.Forms.DateTimePicker EditViewContestEditEndtDateTp;
        private System.Windows.Forms.DateTimePicker EditViewContestEditStartDateTp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox EditViewContestEditContestPlaceTb;
        private System.Windows.Forms.TextBox EditViewContestEditContestNameTb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button EditViewContestCloseBtn;
        private System.Windows.Forms.DataGridView ContestsDataGridView;
    }
}