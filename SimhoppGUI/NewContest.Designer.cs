﻿namespace SimhoppGUI
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewContest));
            this.label1 = new System.Windows.Forms.Label();
            this.newContestNameTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.newContestCityTB = new System.Windows.Forms.TextBox();
            this.NewContestStartDateLabel = new System.Windows.Forms.Label();
            this.NewContestStartDateDTP = new System.Windows.Forms.DateTimePicker();
            this.newContestCreateBtn = new System.Windows.Forms.Button();
            this.NewContestCloseBtn = new System.Windows.Forms.Button();
            this.NewContestEndDateDTP = new System.Windows.Forms.DateTimePicker();
            this.NewContestEndDateLabel = new System.Windows.Forms.Label();
            this.toolTipNewContest = new System.Windows.Forms.ToolTip(this.components);
            this.NameErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.CityErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.DateErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.NameErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CityErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Contest name:";
            // 
            // newContestNameTB
            // 
            this.newContestNameTB.BackColor = System.Drawing.SystemColors.Window;
            this.newContestNameTB.Location = new System.Drawing.Point(102, 23);
            this.newContestNameTB.Name = "newContestNameTB";
            this.newContestNameTB.Size = new System.Drawing.Size(178, 20);
            this.newContestNameTB.TabIndex = 1;
            this.toolTipNewContest.SetToolTip(this.newContestNameTB, "\"Jerusalem-VM\", \"He\'Man\", \"Asp.Net\"");
            this.newContestNameTB.Click += new System.EventHandler(this.newContestNameTB_Click);
            this.newContestNameTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnterOrEscape);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "City:";
            // 
            // newContestCityTB
            // 
            this.newContestCityTB.Location = new System.Drawing.Point(102, 85);
            this.newContestCityTB.Name = "newContestCityTB";
            this.newContestCityTB.Size = new System.Drawing.Size(178, 20);
            this.newContestCityTB.TabIndex = 2;
            this.toolTipNewContest.SetToolTip(this.newContestCityTB, "\"Stockholm\", \"Boulogne-Billancourt\"");
            this.newContestCityTB.Click += new System.EventHandler(this.newContestCityTB_Click);
            this.newContestCityTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnterOrEscape);
            // 
            // NewContestStartDateLabel
            // 
            this.NewContestStartDateLabel.AutoSize = true;
            this.NewContestStartDateLabel.Location = new System.Drawing.Point(21, 151);
            this.NewContestStartDateLabel.Name = "NewContestStartDateLabel";
            this.NewContestStartDateLabel.Size = new System.Drawing.Size(58, 13);
            this.NewContestStartDateLabel.TabIndex = 0;
            this.NewContestStartDateLabel.Text = "Start Date:";
            // 
            // NewContestStartDateDTP
            // 
            this.NewContestStartDateDTP.CustomFormat = "";
            this.NewContestStartDateDTP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.NewContestStartDateDTP.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.NewContestStartDateDTP.Location = new System.Drawing.Point(102, 145);
            this.NewContestStartDateDTP.Name = "NewContestStartDateDTP";
            this.NewContestStartDateDTP.Size = new System.Drawing.Size(119, 20);
            this.NewContestStartDateDTP.TabIndex = 3;
            this.NewContestStartDateDTP.Value = new System.DateTime(2015, 2, 18, 0, 0, 0, 0);
            // 
            // newContestCreateBtn
            // 
            this.newContestCreateBtn.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.newContestCreateBtn.Location = new System.Drawing.Point(102, 240);
            this.newContestCreateBtn.Name = "newContestCreateBtn";
            this.newContestCreateBtn.Size = new System.Drawing.Size(74, 23);
            this.newContestCreateBtn.TabIndex = 5;
            this.newContestCreateBtn.Text = "Create";
            this.newContestCreateBtn.UseVisualStyleBackColor = true;
            this.newContestCreateBtn.Click += new System.EventHandler(this.newContestCreateBtn_Click);
            // 
            // NewContestCloseBtn
            // 
            this.NewContestCloseBtn.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.NewContestCloseBtn.Location = new System.Drawing.Point(205, 240);
            this.NewContestCloseBtn.Name = "NewContestCloseBtn";
            this.NewContestCloseBtn.Size = new System.Drawing.Size(75, 23);
            this.NewContestCloseBtn.TabIndex = 6;
            this.NewContestCloseBtn.Text = "Close";
            this.NewContestCloseBtn.UseVisualStyleBackColor = true;
            this.NewContestCloseBtn.Click += new System.EventHandler(this.NewContestCloseBtn_Click);
            // 
            // NewContestEndDateDTP
            // 
            this.NewContestEndDateDTP.CustomFormat = "";
            this.NewContestEndDateDTP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.NewContestEndDateDTP.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.NewContestEndDateDTP.Location = new System.Drawing.Point(102, 197);
            this.NewContestEndDateDTP.Name = "NewContestEndDateDTP";
            this.NewContestEndDateDTP.Size = new System.Drawing.Size(119, 20);
            this.NewContestEndDateDTP.TabIndex = 4;
            this.NewContestEndDateDTP.Value = new System.DateTime(2015, 2, 18, 0, 0, 0, 0);
            // 
            // NewContestEndDateLabel
            // 
            this.NewContestEndDateLabel.AutoSize = true;
            this.NewContestEndDateLabel.Location = new System.Drawing.Point(24, 203);
            this.NewContestEndDateLabel.Name = "NewContestEndDateLabel";
            this.NewContestEndDateLabel.Size = new System.Drawing.Size(55, 13);
            this.NewContestEndDateLabel.TabIndex = 0;
            this.NewContestEndDateLabel.Text = "End Date:";
            // 
            // NameErrorProvider
            // 
            this.NameErrorProvider.ContainerControl = this;
            // 
            // CityErrorProvider
            // 
            this.CityErrorProvider.ContainerControl = this;
            // 
            // DateErrorProvider
            // 
            this.DateErrorProvider.ContainerControl = this;
            // 
            // NewContest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 287);
            this.Controls.Add(this.NewContestEndDateDTP);
            this.Controls.Add(this.NewContestEndDateLabel);
            this.Controls.Add(this.NewContestCloseBtn);
            this.Controls.Add(this.newContestCreateBtn);
            this.Controls.Add(this.NewContestStartDateDTP);
            this.Controls.Add(this.NewContestStartDateLabel);
            this.Controls.Add(this.newContestCityTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.newContestNameTB);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewContest";
            this.Text = "New Contest";
            ((System.ComponentModel.ISupportInitialize)(this.NameErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CityErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label NewContestStartDateLabel;
        public System.Windows.Forms.DateTimePicker NewContestStartDateDTP;
        private System.Windows.Forms.Button NewContestCloseBtn;
        public System.Windows.Forms.DateTimePicker NewContestEndDateDTP;
        private System.Windows.Forms.Label NewContestEndDateLabel;
        public System.Windows.Forms.TextBox newContestNameTB;
        public System.Windows.Forms.TextBox newContestCityTB;
        public System.Windows.Forms.Button newContestCreateBtn;
        private System.Windows.Forms.ToolTip toolTipNewContest;
        private System.Windows.Forms.ErrorProvider NameErrorProvider;
        private System.Windows.Forms.ErrorProvider CityErrorProvider;
        private System.Windows.Forms.ErrorProvider DateErrorProvider;
    }
}