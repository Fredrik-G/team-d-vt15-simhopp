namespace SimhoppGUI
{
    partial class EditContest
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
            this.toolTipEditViewContest = new System.Windows.Forms.ToolTip(this.components);
            this.NameErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.PlaceErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.NameErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlaceErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // EditViewContestEditChangesBtn
            // 
            this.EditViewContestEditChangesBtn.Location = new System.Drawing.Point(86, 219);
            this.EditViewContestEditChangesBtn.Name = "EditViewContestEditChangesBtn";
            this.EditViewContestEditChangesBtn.Size = new System.Drawing.Size(113, 27);
            this.EditViewContestEditChangesBtn.TabIndex = 18;
            this.EditViewContestEditChangesBtn.Text = "Update changes";
            this.EditViewContestEditChangesBtn.UseVisualStyleBackColor = true;
            this.EditViewContestEditChangesBtn.Click += new System.EventHandler(this.EditViewContestEditChangesBtn_Click);
            // 
            // EditViewContestEditEndtDateTp
            // 
            this.EditViewContestEditEndtDateTp.Location = new System.Drawing.Point(128, 184);
            this.EditViewContestEditEndtDateTp.Name = "EditViewContestEditEndtDateTp";
            this.EditViewContestEditEndtDateTp.Size = new System.Drawing.Size(200, 20);
            this.EditViewContestEditEndtDateTp.TabIndex = 17;
            this.EditViewContestEditEndtDateTp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EditContest_KeyPress);
            // 
            // EditViewContestEditStartDateTp
            // 
            this.EditViewContestEditStartDateTp.Location = new System.Drawing.Point(128, 126);
            this.EditViewContestEditStartDateTp.Name = "EditViewContestEditStartDateTp";
            this.EditViewContestEditStartDateTp.Size = new System.Drawing.Size(200, 20);
            this.EditViewContestEditStartDateTp.TabIndex = 16;
            this.EditViewContestEditStartDateTp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EditContest_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Edit End Date";
            // 
            // EditViewContestEditContestPlaceTb
            // 
            this.EditViewContestEditContestPlaceTb.Location = new System.Drawing.Point(128, 71);
            this.EditViewContestEditContestPlaceTb.Name = "EditViewContestEditContestPlaceTb";
            this.EditViewContestEditContestPlaceTb.Size = new System.Drawing.Size(200, 20);
            this.EditViewContestEditContestPlaceTb.TabIndex = 14;
            this.toolTipEditViewContest.SetToolTip(this.EditViewContestEditContestPlaceTb, "\"Stockholm\", \"Boulogne-Billancourt\"");
            this.EditViewContestEditContestPlaceTb.Click += new System.EventHandler(this.EditViewContestEditContestPlaceTb_Click);
            this.EditViewContestEditContestPlaceTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EditContest_KeyPress);
            // 
            // EditViewContestEditContestNameTb
            // 
            this.EditViewContestEditContestNameTb.Location = new System.Drawing.Point(128, 13);
            this.EditViewContestEditContestNameTb.Name = "EditViewContestEditContestNameTb";
            this.EditViewContestEditContestNameTb.Size = new System.Drawing.Size(200, 20);
            this.EditViewContestEditContestNameTb.TabIndex = 13;
            this.toolTipEditViewContest.SetToolTip(this.EditViewContestEditContestNameTb, "\"Jerusalem-VM\", \"He\'Man\", \"Asp.Net\"");
            this.EditViewContestEditContestNameTb.Click += new System.EventHandler(this.EditViewContestEditContestNameTb_Click);
            this.EditViewContestEditContestNameTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EditContest_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Edit Start Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Edit Place";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Edit Contest Name";
            // 
            // EditViewContestCloseBtn
            // 
            this.EditViewContestCloseBtn.Location = new System.Drawing.Point(223, 219);
            this.EditViewContestCloseBtn.Name = "EditViewContestCloseBtn";
            this.EditViewContestCloseBtn.Size = new System.Drawing.Size(113, 27);
            this.EditViewContestCloseBtn.TabIndex = 20;
            this.EditViewContestCloseBtn.Text = "Close";
            this.EditViewContestCloseBtn.UseVisualStyleBackColor = true;
            this.EditViewContestCloseBtn.Click += new System.EventHandler(this.EditViewContestCloseBtn_Click);
            // 
            // NameErrorProvider
            // 
            this.NameErrorProvider.ContainerControl = this;
            // 
            // PlaceErrorProvider
            // 
            this.PlaceErrorProvider.ContainerControl = this;
            // 
            // EditContest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 255);
            this.Controls.Add(this.EditViewContestEditContestNameTb);
            this.Controls.Add(this.EditViewContestEditEndtDateTp);
            this.Controls.Add(this.EditViewContestEditChangesBtn);
            this.Controls.Add(this.EditViewContestEditStartDateTp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.EditViewContestCloseBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.EditViewContestEditContestPlaceTb);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditContest";
            this.Text = "Edit Contest";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EditContest_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.NameErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlaceErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.ToolTip toolTipEditViewContest;
        private System.Windows.Forms.ErrorProvider NameErrorProvider;
        private System.Windows.Forms.ErrorProvider PlaceErrorProvider;
    }
}