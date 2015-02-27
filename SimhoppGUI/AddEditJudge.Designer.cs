namespace SimhoppGUI
{
    partial class AddEditJudge
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
            this.AddJudgeNameLabel = new System.Windows.Forms.Label();
            this.AddJudgeSSNLabel = new System.Windows.Forms.Label();
            this.AddJudgeNationalityLabel = new System.Windows.Forms.Label();
            this.AddJudgeNameTb = new System.Windows.Forms.TextBox();
            this.AddJudgeNationaltyTb = new System.Windows.Forms.TextBox();
            this.AddJudgeSSNTb = new System.Windows.Forms.TextBox();
            this.AddJudgeButton = new System.Windows.Forms.Button();
            this.UpdateJudgeSSNTb = new System.Windows.Forms.TextBox();
            this.UpdateJudgeNationalityTb = new System.Windows.Forms.TextBox();
            this.UpdateJudgeNameTb = new System.Windows.Forms.TextBox();
            this.EditJudgeNationalityLabel = new System.Windows.Forms.Label();
            this.EditJudgeSSNLabel = new System.Windows.Forms.Label();
            this.EditJudgeNameLabel = new System.Windows.Forms.Label();
            this.UpdateJudgeButton = new System.Windows.Forms.Button();
            this.AddJudgeCloseBtn = new System.Windows.Forms.Button();
            this.tabControlAddEdit = new System.Windows.Forms.TabControl();
            this.tabPageEditJudge = new System.Windows.Forms.TabPage();
            this.UpdateJudgeRemoveBtn = new System.Windows.Forms.Button();
            this.UpdateJudgeClosebtn = new System.Windows.Forms.Button();
            this.tabPageAddJudge = new System.Windows.Forms.TabPage();
            this.JudgesDataGridView = new System.Windows.Forms.DataGridView();
            this.InputErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.InputToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tabControlAddEdit.SuspendLayout();
            this.tabPageEditJudge.SuspendLayout();
            this.tabPageAddJudge.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.JudgesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // AddJudgeNameLabel
            // 
            this.AddJudgeNameLabel.AutoSize = true;
            this.AddJudgeNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddJudgeNameLabel.Location = new System.Drawing.Point(6, 10);
            this.AddJudgeNameLabel.Name = "AddJudgeNameLabel";
            this.AddJudgeNameLabel.Size = new System.Drawing.Size(39, 13);
            this.AddJudgeNameLabel.TabIndex = 2;
            this.AddJudgeNameLabel.Text = "Name";
            // 
            // AddJudgeSSNLabel
            // 
            this.AddJudgeSSNLabel.AutoSize = true;
            this.AddJudgeSSNLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddJudgeSSNLabel.Location = new System.Drawing.Point(6, 96);
            this.AddJudgeSSNLabel.Name = "AddJudgeSSNLabel";
            this.AddJudgeSSNLabel.Size = new System.Drawing.Size(32, 13);
            this.AddJudgeSSNLabel.TabIndex = 3;
            this.AddJudgeSSNLabel.Text = "SSN";
            // 
            // AddJudgeNationalityLabel
            // 
            this.AddJudgeNationalityLabel.AutoSize = true;
            this.AddJudgeNationalityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddJudgeNationalityLabel.Location = new System.Drawing.Point(6, 53);
            this.AddJudgeNationalityLabel.Name = "AddJudgeNationalityLabel";
            this.AddJudgeNationalityLabel.Size = new System.Drawing.Size(67, 13);
            this.AddJudgeNationalityLabel.TabIndex = 4;
            this.AddJudgeNationalityLabel.Text = "Nationality";
            // 
            // AddJudgeNameTb
            // 
            this.AddJudgeNameTb.Location = new System.Drawing.Point(98, 10);
            this.AddJudgeNameTb.Name = "AddJudgeNameTb";
            this.AddJudgeNameTb.Size = new System.Drawing.Size(148, 20);
            this.AddJudgeNameTb.TabIndex = 6;
            this.InputToolTip.SetToolTip(this.AddJudgeNameTb, "Allowed characters: \"A-Z \',.-\"");
            this.AddJudgeNameTb.Click += new System.EventHandler(this.AddJudgeNameTb_Click);
            this.AddJudgeNameTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnterAdd);
            // 
            // AddJudgeNationaltyTb
            // 
            this.AddJudgeNationaltyTb.Location = new System.Drawing.Point(98, 53);
            this.AddJudgeNationaltyTb.Name = "AddJudgeNationaltyTb";
            this.AddJudgeNationaltyTb.Size = new System.Drawing.Size(148, 20);
            this.AddJudgeNationaltyTb.TabIndex = 7;
            this.InputToolTip.SetToolTip(this.AddJudgeNationaltyTb, "Allowed characters: \"A-Z ,-\"");
            this.AddJudgeNationaltyTb.Click += new System.EventHandler(this.AddJudgeNationaltyTb_Click);
            this.AddJudgeNationaltyTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnterAdd);
            // 
            // AddJudgeSSNTb
            // 
            this.AddJudgeSSNTb.Location = new System.Drawing.Point(98, 96);
            this.AddJudgeSSNTb.Name = "AddJudgeSSNTb";
            this.AddJudgeSSNTb.Size = new System.Drawing.Size(148, 20);
            this.AddJudgeSSNTb.TabIndex = 8;
            this.InputToolTip.SetToolTip(this.AddJudgeSSNTb, "Allowed characters: \"1-9 -\". Swedish: yyyymmdd-xxxx. Rest: xxx-yy-zzzz");
            this.AddJudgeSSNTb.Click += new System.EventHandler(this.AddJudgeSSNTb_Click);
            this.AddJudgeSSNTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnterAdd);
            // 
            // AddJudgeButton
            // 
            this.AddJudgeButton.Location = new System.Drawing.Point(98, 150);
            this.AddJudgeButton.Name = "AddJudgeButton";
            this.AddJudgeButton.Size = new System.Drawing.Size(75, 23);
            this.AddJudgeButton.TabIndex = 9;
            this.AddJudgeButton.Text = "Add";
            this.AddJudgeButton.UseVisualStyleBackColor = true;
            this.AddJudgeButton.Click += new System.EventHandler(this.AddJudgeButton_Click);
            // 
            // UpdateJudgeSSNTb
            // 
            this.UpdateJudgeSSNTb.Location = new System.Drawing.Point(98, 96);
            this.UpdateJudgeSSNTb.Name = "UpdateJudgeSSNTb";
            this.UpdateJudgeSSNTb.Size = new System.Drawing.Size(148, 20);
            this.UpdateJudgeSSNTb.TabIndex = 17;
            this.InputToolTip.SetToolTip(this.UpdateJudgeSSNTb, "Allowed characters: \"1-9 -\". Swedish: yyyymmdd-xxxx. Rest: xxx-yy-zzzz");
            this.UpdateJudgeSSNTb.Click += new System.EventHandler(this.UpdateJudgeSSNTb_Click);
            this.UpdateJudgeSSNTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnterUpdate);
            // 
            // UpdateJudgeNationalityTb
            // 
            this.UpdateJudgeNationalityTb.Location = new System.Drawing.Point(98, 53);
            this.UpdateJudgeNationalityTb.Name = "UpdateJudgeNationalityTb";
            this.UpdateJudgeNationalityTb.Size = new System.Drawing.Size(148, 20);
            this.UpdateJudgeNationalityTb.TabIndex = 16;
            this.InputToolTip.SetToolTip(this.UpdateJudgeNationalityTb, "Allowed characters: \"A-Z ,-\"");
            this.UpdateJudgeNationalityTb.Click += new System.EventHandler(this.UpdateJudgeNationalityTb_Click);
            this.UpdateJudgeNationalityTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnterUpdate);
            // 
            // UpdateJudgeNameTb
            // 
            this.UpdateJudgeNameTb.Location = new System.Drawing.Point(98, 10);
            this.UpdateJudgeNameTb.Name = "UpdateJudgeNameTb";
            this.UpdateJudgeNameTb.Size = new System.Drawing.Size(148, 20);
            this.UpdateJudgeNameTb.TabIndex = 15;
            this.InputToolTip.SetToolTip(this.UpdateJudgeNameTb, "Allowed characters: \"A-Z \',.-\"");
            this.UpdateJudgeNameTb.Click += new System.EventHandler(this.UpdateJudgeNameTb_Click);
            this.UpdateJudgeNameTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnterUpdate);
            // 
            // EditJudgeNationalityLabel
            // 
            this.EditJudgeNationalityLabel.AutoSize = true;
            this.EditJudgeNationalityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditJudgeNationalityLabel.Location = new System.Drawing.Point(6, 53);
            this.EditJudgeNationalityLabel.Name = "EditJudgeNationalityLabel";
            this.EditJudgeNationalityLabel.Size = new System.Drawing.Size(67, 13);
            this.EditJudgeNationalityLabel.TabIndex = 14;
            this.EditJudgeNationalityLabel.Text = "Nationality";
            // 
            // EditJudgeSSNLabel
            // 
            this.EditJudgeSSNLabel.AutoSize = true;
            this.EditJudgeSSNLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditJudgeSSNLabel.Location = new System.Drawing.Point(6, 96);
            this.EditJudgeSSNLabel.Name = "EditJudgeSSNLabel";
            this.EditJudgeSSNLabel.Size = new System.Drawing.Size(32, 13);
            this.EditJudgeSSNLabel.TabIndex = 13;
            this.EditJudgeSSNLabel.Text = "SSN";
            // 
            // EditJudgeNameLabel
            // 
            this.EditJudgeNameLabel.AutoSize = true;
            this.EditJudgeNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditJudgeNameLabel.Location = new System.Drawing.Point(6, 10);
            this.EditJudgeNameLabel.Name = "EditJudgeNameLabel";
            this.EditJudgeNameLabel.Size = new System.Drawing.Size(39, 13);
            this.EditJudgeNameLabel.TabIndex = 12;
            this.EditJudgeNameLabel.Text = "Name";
            // 
            // UpdateJudgeButton
            // 
            this.UpdateJudgeButton.Location = new System.Drawing.Point(17, 150);
            this.UpdateJudgeButton.Name = "UpdateJudgeButton";
            this.UpdateJudgeButton.Size = new System.Drawing.Size(75, 23);
            this.UpdateJudgeButton.TabIndex = 18;
            this.UpdateJudgeButton.Text = "Update";
            this.UpdateJudgeButton.UseVisualStyleBackColor = true;
            this.UpdateJudgeButton.Click += new System.EventHandler(this.UpdateJudgeButton_Click);
            // 
            // AddJudgeCloseBtn
            // 
            this.AddJudgeCloseBtn.Location = new System.Drawing.Point(271, 150);
            this.AddJudgeCloseBtn.Name = "AddJudgeCloseBtn";
            this.AddJudgeCloseBtn.Size = new System.Drawing.Size(75, 23);
            this.AddJudgeCloseBtn.TabIndex = 20;
            this.AddJudgeCloseBtn.Text = "Close";
            this.AddJudgeCloseBtn.UseVisualStyleBackColor = true;
            this.AddJudgeCloseBtn.Click += new System.EventHandler(this.AddJudgePreviousBtn_Click);
            // 
            // tabControlAddEdit
            // 
            this.tabControlAddEdit.Controls.Add(this.tabPageEditJudge);
            this.tabControlAddEdit.Controls.Add(this.tabPageAddJudge);
            this.tabControlAddEdit.Location = new System.Drawing.Point(12, 243);
            this.tabControlAddEdit.Name = "tabControlAddEdit";
            this.tabControlAddEdit.SelectedIndex = 0;
            this.tabControlAddEdit.Size = new System.Drawing.Size(360, 217);
            this.tabControlAddEdit.TabIndex = 21;
            this.tabControlAddEdit.SelectedIndexChanged += new System.EventHandler(this.tabControlAddEdit_SelectedIndexChanged);
            // 
            // tabPageEditJudge
            // 
            this.tabPageEditJudge.Controls.Add(this.UpdateJudgeRemoveBtn);
            this.tabPageEditJudge.Controls.Add(this.UpdateJudgeClosebtn);
            this.tabPageEditJudge.Controls.Add(this.UpdateJudgeButton);
            this.tabPageEditJudge.Controls.Add(this.EditJudgeNameLabel);
            this.tabPageEditJudge.Controls.Add(this.EditJudgeSSNLabel);
            this.tabPageEditJudge.Controls.Add(this.EditJudgeNationalityLabel);
            this.tabPageEditJudge.Controls.Add(this.UpdateJudgeSSNTb);
            this.tabPageEditJudge.Controls.Add(this.UpdateJudgeNameTb);
            this.tabPageEditJudge.Controls.Add(this.UpdateJudgeNationalityTb);
            this.tabPageEditJudge.Location = new System.Drawing.Point(4, 22);
            this.tabPageEditJudge.Name = "tabPageEditJudge";
            this.tabPageEditJudge.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEditJudge.Size = new System.Drawing.Size(352, 191);
            this.tabPageEditJudge.TabIndex = 1;
            this.tabPageEditJudge.Text = "Edit Judge";
            this.tabPageEditJudge.UseVisualStyleBackColor = true;
            // 
            // UpdateJudgeRemoveBtn
            // 
            this.UpdateJudgeRemoveBtn.Location = new System.Drawing.Point(98, 150);
            this.UpdateJudgeRemoveBtn.Name = "UpdateJudgeRemoveBtn";
            this.UpdateJudgeRemoveBtn.Size = new System.Drawing.Size(75, 23);
            this.UpdateJudgeRemoveBtn.TabIndex = 19;
            this.UpdateJudgeRemoveBtn.Text = "Remove";
            this.UpdateJudgeRemoveBtn.UseVisualStyleBackColor = true;
            this.UpdateJudgeRemoveBtn.Click += new System.EventHandler(this.UpdateJudgeRemoveBtn_Click);
            // 
            // UpdateJudgeClosebtn
            // 
            this.UpdateJudgeClosebtn.Location = new System.Drawing.Point(271, 150);
            this.UpdateJudgeClosebtn.Name = "UpdateJudgeClosebtn";
            this.UpdateJudgeClosebtn.Size = new System.Drawing.Size(75, 23);
            this.UpdateJudgeClosebtn.TabIndex = 23;
            this.UpdateJudgeClosebtn.Text = "Close";
            this.UpdateJudgeClosebtn.UseVisualStyleBackColor = true;
            this.UpdateJudgeClosebtn.Click += new System.EventHandler(this.UpdateJudgePreviousBtn_Click);
            // 
            // tabPageAddJudge
            // 
            this.tabPageAddJudge.Controls.Add(this.AddJudgeNameLabel);
            this.tabPageAddJudge.Controls.Add(this.AddJudgeButton);
            this.tabPageAddJudge.Controls.Add(this.AddJudgeCloseBtn);
            this.tabPageAddJudge.Controls.Add(this.AddJudgeSSNTb);
            this.tabPageAddJudge.Controls.Add(this.AddJudgeSSNLabel);
            this.tabPageAddJudge.Controls.Add(this.AddJudgeNationaltyTb);
            this.tabPageAddJudge.Controls.Add(this.AddJudgeNameTb);
            this.tabPageAddJudge.Controls.Add(this.AddJudgeNationalityLabel);
            this.tabPageAddJudge.Location = new System.Drawing.Point(4, 22);
            this.tabPageAddJudge.Name = "tabPageAddJudge";
            this.tabPageAddJudge.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAddJudge.Size = new System.Drawing.Size(352, 191);
            this.tabPageAddJudge.TabIndex = 0;
            this.tabPageAddJudge.Text = "Add Judge";
            this.tabPageAddJudge.UseVisualStyleBackColor = true;
            // 
            // JudgesDataGridView
            // 
            this.JudgesDataGridView.AllowUserToAddRows = false;
            this.JudgesDataGridView.AllowUserToDeleteRows = false;
            this.JudgesDataGridView.AllowUserToOrderColumns = true;
            this.JudgesDataGridView.AllowUserToResizeColumns = false;
            this.JudgesDataGridView.AllowUserToResizeRows = false;
            this.JudgesDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.JudgesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.JudgesDataGridView.Location = new System.Drawing.Point(12, 12);
            this.JudgesDataGridView.Name = "JudgesDataGridView";
            this.JudgesDataGridView.ReadOnly = true;
            this.JudgesDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.JudgesDataGridView.Size = new System.Drawing.Size(360, 225);
            this.JudgesDataGridView.TabIndex = 22;
            this.JudgesDataGridView.TabStop = false;
            this.JudgesDataGridView.SelectionChanged += new System.EventHandler(this.JudgesDataGridView_SelectionChanged);
            // 
            // InputErrorProvider
            // 
            this.InputErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.InputErrorProvider.ContainerControl = this;
            // 
            // AddEditJudge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 468);
            this.Controls.Add(this.JudgesDataGridView);
            this.Controls.Add(this.tabControlAddEdit);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditJudge";
            this.Text = "Add/Edit Judge";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnterAdd);
            this.tabControlAddEdit.ResumeLayout(false);
            this.tabPageEditJudge.ResumeLayout(false);
            this.tabPageEditJudge.PerformLayout();
            this.tabPageAddJudge.ResumeLayout(false);
            this.tabPageAddJudge.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.JudgesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label AddJudgeNameLabel;
        private System.Windows.Forms.Label AddJudgeSSNLabel;
        private System.Windows.Forms.Label AddJudgeNationalityLabel;
        private System.Windows.Forms.TextBox AddJudgeNameTb;
        private System.Windows.Forms.TextBox AddJudgeNationaltyTb;
        private System.Windows.Forms.TextBox AddJudgeSSNTb;
        private System.Windows.Forms.Button AddJudgeButton;
        private System.Windows.Forms.TextBox UpdateJudgeSSNTb;
        private System.Windows.Forms.TextBox UpdateJudgeNationalityTb;
        private System.Windows.Forms.TextBox UpdateJudgeNameTb;
        private System.Windows.Forms.Label EditJudgeNationalityLabel;
        private System.Windows.Forms.Label EditJudgeSSNLabel;
        private System.Windows.Forms.Label EditJudgeNameLabel;
        private System.Windows.Forms.Button UpdateJudgeButton;
        private System.Windows.Forms.Button AddJudgeCloseBtn;
        private System.Windows.Forms.TabControl tabControlAddEdit;
        private System.Windows.Forms.TabPage tabPageAddJudge;
        private System.Windows.Forms.TabPage tabPageEditJudge;
        private System.Windows.Forms.DataGridView JudgesDataGridView;
        private System.Windows.Forms.Button UpdateJudgeClosebtn;
        private System.Windows.Forms.Button UpdateJudgeRemoveBtn;
        private System.Windows.Forms.ErrorProvider InputErrorProvider;
        private System.Windows.Forms.ToolTip InputToolTip;
    }
}