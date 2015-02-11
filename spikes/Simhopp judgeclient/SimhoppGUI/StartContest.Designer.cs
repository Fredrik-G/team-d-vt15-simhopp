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
            this.StartContestStartBtn = new System.Windows.Forms.Button();
            this.EditViewContestEndDateTp = new System.Windows.Forms.DateTimePicker();
            this.EditViewContestStartDateTp = new System.Windows.Forms.DateTimePicker();
            this.EditViewContestEndDateLabel = new System.Windows.Forms.Label();
            this.EditViewContestContestPlaceTb = new System.Windows.Forms.TextBox();
            this.EditViewContestContestNameTb = new System.Windows.Forms.TextBox();
            this.EditViewContestStartDateLabel = new System.Windows.Forms.Label();
            this.PlaceContestLabel = new System.Windows.Forms.Label();
            this.NameContestLabel = new System.Windows.Forms.Label();
            this.listViewEditViewContest = new System.Windows.Forms.ListView();
            this.Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Place = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StartContestCloseBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartContestStartBtn
            // 
            this.StartContestStartBtn.Location = new System.Drawing.Point(468, 446);
            this.StartContestStartBtn.Name = "StartContestStartBtn";
            this.StartContestStartBtn.Size = new System.Drawing.Size(93, 27);
            this.StartContestStartBtn.TabIndex = 37;
            this.StartContestStartBtn.Text = "Start contest";
            this.StartContestStartBtn.UseVisualStyleBackColor = true;
            // 
            // EditViewContestEndDateTp
            // 
            this.EditViewContestEndDateTp.Location = new System.Drawing.Point(129, 446);
            this.EditViewContestEndDateTp.Name = "EditViewContestEndDateTp";
            this.EditViewContestEndDateTp.Size = new System.Drawing.Size(200, 20);
            this.EditViewContestEndDateTp.TabIndex = 27;
            // 
            // EditViewContestStartDateTp
            // 
            this.EditViewContestStartDateTp.Location = new System.Drawing.Point(129, 388);
            this.EditViewContestStartDateTp.Name = "EditViewContestStartDateTp";
            this.EditViewContestStartDateTp.Size = new System.Drawing.Size(200, 20);
            this.EditViewContestStartDateTp.TabIndex = 26;
            // 
            // EditViewContestEndDateLabel
            // 
            this.EditViewContestEndDateLabel.AutoSize = true;
            this.EditViewContestEndDateLabel.Location = new System.Drawing.Point(34, 446);
            this.EditViewContestEndDateLabel.Name = "EditViewContestEndDateLabel";
            this.EditViewContestEndDateLabel.Size = new System.Drawing.Size(52, 13);
            this.EditViewContestEndDateLabel.TabIndex = 25;
            this.EditViewContestEndDateLabel.Text = "End Date";
            // 
            // EditViewContestContestPlaceTb
            // 
            this.EditViewContestContestPlaceTb.Location = new System.Drawing.Point(129, 330);
            this.EditViewContestContestPlaceTb.Name = "EditViewContestContestPlaceTb";
            this.EditViewContestContestPlaceTb.ReadOnly = true;
            this.EditViewContestContestPlaceTb.Size = new System.Drawing.Size(200, 20);
            this.EditViewContestContestPlaceTb.TabIndex = 24;
            // 
            // EditViewContestContestNameTb
            // 
            this.EditViewContestContestNameTb.Location = new System.Drawing.Point(129, 272);
            this.EditViewContestContestNameTb.Name = "EditViewContestContestNameTb";
            this.EditViewContestContestNameTb.ReadOnly = true;
            this.EditViewContestContestNameTb.Size = new System.Drawing.Size(200, 20);
            this.EditViewContestContestNameTb.TabIndex = 23;
            // 
            // EditViewContestStartDateLabel
            // 
            this.EditViewContestStartDateLabel.AutoSize = true;
            this.EditViewContestStartDateLabel.Location = new System.Drawing.Point(34, 388);
            this.EditViewContestStartDateLabel.Name = "EditViewContestStartDateLabel";
            this.EditViewContestStartDateLabel.Size = new System.Drawing.Size(55, 13);
            this.EditViewContestStartDateLabel.TabIndex = 22;
            this.EditViewContestStartDateLabel.Text = "Start Date";
            // 
            // PlaceContestLabel
            // 
            this.PlaceContestLabel.AutoSize = true;
            this.PlaceContestLabel.Location = new System.Drawing.Point(34, 330);
            this.PlaceContestLabel.Name = "PlaceContestLabel";
            this.PlaceContestLabel.Size = new System.Drawing.Size(34, 13);
            this.PlaceContestLabel.TabIndex = 21;
            this.PlaceContestLabel.Text = "Place";
            // 
            // NameContestLabel
            // 
            this.NameContestLabel.AutoSize = true;
            this.NameContestLabel.Location = new System.Drawing.Point(34, 272);
            this.NameContestLabel.Name = "NameContestLabel";
            this.NameContestLabel.Size = new System.Drawing.Size(74, 13);
            this.NameContestLabel.TabIndex = 20;
            this.NameContestLabel.Text = "Contest Name";
            // 
            // listViewEditViewContest
            // 
            this.listViewEditViewContest.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Name,
            this.Place,
            this.Date});
            this.listViewEditViewContest.Location = new System.Drawing.Point(37, 39);
            this.listViewEditViewContest.Name = "listViewEditViewContest";
            this.listViewEditViewContest.Size = new System.Drawing.Size(490, 170);
            this.listViewEditViewContest.TabIndex = 19;
            this.listViewEditViewContest.UseCompatibleStateImageBehavior = false;
            this.listViewEditViewContest.View = System.Windows.Forms.View.Details;
            // 
            // Name
            // 
            this.Name.Text = "Contest Name";
            this.Name.Width = 176;
            // 
            // Place
            // 
            this.Place.Text = "Place";
            this.Place.Width = 199;
            // 
            // Date
            // 
            this.Date.Text = "Date";
            this.Date.Width = 334;
            // 
            // StartContestCloseBtn
            // 
            this.StartContestCloseBtn.Location = new System.Drawing.Point(369, 446);
            this.StartContestCloseBtn.Name = "StartContestCloseBtn";
            this.StartContestCloseBtn.Size = new System.Drawing.Size(93, 27);
            this.StartContestCloseBtn.TabIndex = 38;
            this.StartContestCloseBtn.Text = "Close";
            this.StartContestCloseBtn.UseVisualStyleBackColor = true;
            this.StartContestCloseBtn.Click += new System.EventHandler(this.StartContestCloseBtn_Click);
            // 
            // StartContest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 517);
            this.Controls.Add(this.StartContestCloseBtn);
            this.Controls.Add(this.StartContestStartBtn);
            this.Controls.Add(this.EditViewContestEndDateTp);
            this.Controls.Add(this.EditViewContestStartDateTp);
            this.Controls.Add(this.EditViewContestEndDateLabel);
            this.Controls.Add(this.EditViewContestContestPlaceTb);
            this.Controls.Add(this.EditViewContestContestNameTb);
            this.Controls.Add(this.EditViewContestStartDateLabel);
            this.Controls.Add(this.PlaceContestLabel);
            this.Controls.Add(this.NameContestLabel);
            this.Controls.Add(this.listViewEditViewContest);
           // this.Name = "StartContest";
            this.Text = "StartContest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartContestStartBtn;
        private System.Windows.Forms.DateTimePicker EditViewContestEndDateTp;
        private System.Windows.Forms.DateTimePicker EditViewContestStartDateTp;
        private System.Windows.Forms.Label EditViewContestEndDateLabel;
        private System.Windows.Forms.TextBox EditViewContestContestPlaceTb;
        private System.Windows.Forms.TextBox EditViewContestContestNameTb;
        private System.Windows.Forms.Label EditViewContestStartDateLabel;
        private System.Windows.Forms.Label PlaceContestLabel;
        private System.Windows.Forms.Label NameContestLabel;
        private System.Windows.Forms.ListView listViewEditViewContest;
        private System.Windows.Forms.ColumnHeader Name;
        private System.Windows.Forms.ColumnHeader Place;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.Button StartContestCloseBtn;
    }
}