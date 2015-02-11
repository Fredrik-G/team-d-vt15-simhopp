namespace SimhoppGUI
{
    partial class Edit_viewContestcs
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
            this.Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Place = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NameContestLabel = new System.Windows.Forms.Label();
            this.PlaceContestLabel = new System.Windows.Forms.Label();
            this.EditViewContestStartDateLabel = new System.Windows.Forms.Label();
            this.EditViewContestContestNameTb = new System.Windows.Forms.TextBox();
            this.EditViewContestContestPlaceTb = new System.Windows.Forms.TextBox();
            this.EditViewContestEndDateLabel = new System.Windows.Forms.Label();
            this.EditViewContestStartDateTp = new System.Windows.Forms.DateTimePicker();
            this.EditViewContestEndDateTp = new System.Windows.Forms.DateTimePicker();
            this.EditViewContestEditChangesBtn = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.EditViewContestCloseBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewEditViewContest
            // 
            this.listViewEditViewContest.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Name,
            this.Place,
            this.Date});
            this.listViewEditViewContest.Location = new System.Drawing.Point(46, 35);
            this.listViewEditViewContest.Name = "listViewEditViewContest";
            this.listViewEditViewContest.Size = new System.Drawing.Size(703, 170);
            this.listViewEditViewContest.TabIndex = 0;
            this.listViewEditViewContest.UseCompatibleStateImageBehavior = false;
            this.listViewEditViewContest.View = System.Windows.Forms.View.Details;
            this.listViewEditViewContest.SelectedIndexChanged += new System.EventHandler(this.listViewEditViewContest_SelectedIndexChanged);
            // 
            // Name
            // 
            this.Name.Text = "Contest Name";
            this.Name.Width = 252;
            // 
            // Place
            // 
            this.Place.Text = "Place";
            this.Place.Width = 240;
            // 
            // Date
            // 
            this.Date.Text = "Date";
            this.Date.Width = 334;
            // 
            // NameContestLabel
            // 
            this.NameContestLabel.AutoSize = true;
            this.NameContestLabel.Location = new System.Drawing.Point(43, 268);
            this.NameContestLabel.Name = "NameContestLabel";
            this.NameContestLabel.Size = new System.Drawing.Size(74, 13);
            this.NameContestLabel.TabIndex = 1;
            this.NameContestLabel.Text = "Contest Name";
            this.NameContestLabel.Click += new System.EventHandler(this.NameContestLabel_Click);
            // 
            // PlaceContestLabel
            // 
            this.PlaceContestLabel.AutoSize = true;
            this.PlaceContestLabel.Location = new System.Drawing.Point(43, 326);
            this.PlaceContestLabel.Name = "PlaceContestLabel";
            this.PlaceContestLabel.Size = new System.Drawing.Size(34, 13);
            this.PlaceContestLabel.TabIndex = 2;
            this.PlaceContestLabel.Text = "Place";
            this.PlaceContestLabel.Click += new System.EventHandler(this.PlaceContestLabel_Click);
            // 
            // EditViewContestStartDateLabel
            // 
            this.EditViewContestStartDateLabel.AutoSize = true;
            this.EditViewContestStartDateLabel.Location = new System.Drawing.Point(43, 384);
            this.EditViewContestStartDateLabel.Name = "EditViewContestStartDateLabel";
            this.EditViewContestStartDateLabel.Size = new System.Drawing.Size(55, 13);
            this.EditViewContestStartDateLabel.TabIndex = 3;
            this.EditViewContestStartDateLabel.Text = "Start Date";
            this.EditViewContestStartDateLabel.Click += new System.EventHandler(this.EditViewContestStartDateLabel_Click);
            // 
            // EditViewContestContestNameTb
            // 
            this.EditViewContestContestNameTb.Location = new System.Drawing.Point(138, 268);
            this.EditViewContestContestNameTb.Name = "EditViewContestContestNameTb";
            this.EditViewContestContestNameTb.ReadOnly = true;
            this.EditViewContestContestNameTb.Size = new System.Drawing.Size(200, 20);
            this.EditViewContestContestNameTb.TabIndex = 4;
            this.EditViewContestContestNameTb.TextChanged += new System.EventHandler(this.EditViewContestContestNameTb_TextChanged);
            // 
            // EditViewContestContestPlaceTb
            // 
            this.EditViewContestContestPlaceTb.Location = new System.Drawing.Point(138, 326);
            this.EditViewContestContestPlaceTb.Name = "EditViewContestContestPlaceTb";
            this.EditViewContestContestPlaceTb.ReadOnly = true;
            this.EditViewContestContestPlaceTb.Size = new System.Drawing.Size(200, 20);
            this.EditViewContestContestPlaceTb.TabIndex = 5;
            this.EditViewContestContestPlaceTb.TextChanged += new System.EventHandler(this.EditViewContestContestPlaceTb_TextChanged);
            // 
            // EditViewContestEndDateLabel
            // 
            this.EditViewContestEndDateLabel.AutoSize = true;
            this.EditViewContestEndDateLabel.Location = new System.Drawing.Point(43, 442);
            this.EditViewContestEndDateLabel.Name = "EditViewContestEndDateLabel";
            this.EditViewContestEndDateLabel.Size = new System.Drawing.Size(52, 13);
            this.EditViewContestEndDateLabel.TabIndex = 6;
            this.EditViewContestEndDateLabel.Text = "End Date";
            this.EditViewContestEndDateLabel.Click += new System.EventHandler(this.EditViewContestEndDateLabel_Click);
            // 
            // EditViewContestStartDateTp
            // 
            this.EditViewContestStartDateTp.Location = new System.Drawing.Point(138, 384);
            this.EditViewContestStartDateTp.Name = "EditViewContestStartDateTp";
            this.EditViewContestStartDateTp.Size = new System.Drawing.Size(200, 20);
            this.EditViewContestStartDateTp.TabIndex = 7;
            this.EditViewContestStartDateTp.ValueChanged += new System.EventHandler(this.EditViewContestStartDateTp_ValueChanged);
            // 
            // EditViewContestEndDateTp
            // 
            this.EditViewContestEndDateTp.Location = new System.Drawing.Point(138, 442);
            this.EditViewContestEndDateTp.Name = "EditViewContestEndDateTp";
            this.EditViewContestEndDateTp.Size = new System.Drawing.Size(200, 20);
            this.EditViewContestEndDateTp.TabIndex = 8;
            this.EditViewContestEndDateTp.ValueChanged += new System.EventHandler(this.EditViewContestEndDateTp_ValueChanged);
            // 
            // EditViewContestEditChangesBtn
            // 
            this.EditViewContestEditChangesBtn.Location = new System.Drawing.Point(636, 510);
            this.EditViewContestEditChangesBtn.Name = "EditViewContestEditChangesBtn";
            this.EditViewContestEditChangesBtn.Size = new System.Drawing.Size(113, 27);
            this.EditViewContestEditChangesBtn.TabIndex = 9;
            this.EditViewContestEditChangesBtn.Text = "Update changes";
            this.EditViewContestEditChangesBtn.UseVisualStyleBackColor = true;
            this.EditViewContestEditChangesBtn.Click += new System.EventHandler(this.EditViewContestEditChangesBtn_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(549, 436);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 17;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(549, 378);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 16;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(427, 442);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Edi End Date";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(549, 323);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 20);
            this.textBox1.TabIndex = 14;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(549, 265);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(200, 20);
            this.textBox2.TabIndex = 13;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(427, 384);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Edit Start Date";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(427, 326);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Edit Place";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(427, 268);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Edit Contest Name";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // EditViewContestCloseBtn
            // 
            this.EditViewContestCloseBtn.Location = new System.Drawing.Point(225, 510);
            this.EditViewContestCloseBtn.Name = "EditViewContestCloseBtn";
            this.EditViewContestCloseBtn.Size = new System.Drawing.Size(113, 27);
            this.EditViewContestCloseBtn.TabIndex = 18;
            this.EditViewContestCloseBtn.Text = "Close";
            this.EditViewContestCloseBtn.UseVisualStyleBackColor = true;
            this.EditViewContestCloseBtn.Click += new System.EventHandler(this.EditViewContestCloseBtn_Click);
            // 
            // Edit_viewContestcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 589);
            this.Controls.Add(this.EditViewContestCloseBtn);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.EditViewContestEditChangesBtn);
            this.Controls.Add(this.EditViewContestEndDateTp);
            this.Controls.Add(this.EditViewContestStartDateTp);
            this.Controls.Add(this.EditViewContestEndDateLabel);
            this.Controls.Add(this.EditViewContestContestPlaceTb);
            this.Controls.Add(this.EditViewContestContestNameTb);
            this.Controls.Add(this.EditViewContestStartDateLabel);
            this.Controls.Add(this.PlaceContestLabel);
            this.Controls.Add(this.NameContestLabel);
            this.Controls.Add(this.listViewEditViewContest);
            //this.Name = "Edit_viewContestcs";
            this.Text = "Edit_viewContestcs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewEditViewContest;
        private System.Windows.Forms.ColumnHeader Name;
        private System.Windows.Forms.ColumnHeader Place;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.Label NameContestLabel;
        private System.Windows.Forms.Label PlaceContestLabel;
        private System.Windows.Forms.Label EditViewContestStartDateLabel;
        private System.Windows.Forms.TextBox EditViewContestContestNameTb;
        private System.Windows.Forms.TextBox EditViewContestContestPlaceTb;
        private System.Windows.Forms.Label EditViewContestEndDateLabel;
        private System.Windows.Forms.DateTimePicker EditViewContestStartDateTp;
        private System.Windows.Forms.DateTimePicker EditViewContestEndDateTp;
        private System.Windows.Forms.Button EditViewContestEditChangesBtn;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button EditViewContestCloseBtn;
    }
}