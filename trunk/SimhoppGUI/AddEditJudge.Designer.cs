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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditJudge));
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
            this.AddJudgePasswordTb = new System.Windows.Forms.TextBox();
            this.AddJudgePasswordLabel = new System.Windows.Forms.Label();
            this.JudgesDataGridView = new System.Windows.Forms.DataGridView();
            this.NameErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.InputToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.NationalityErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.SSNErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.weirddatagridfix = new System.Windows.Forms.DataGridView();
            this.weirdfix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EditJudgeToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.AddJudgeToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.EditJudgeHiddenLabel = new System.Windows.Forms.Label();
            this.AddJudgeHiddenLabel = new System.Windows.Forms.Label();
            this.JudgesDataGridToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.JudgesDataGridHiddenLabel = new System.Windows.Forms.Label();
            this.tabControlAddEdit.SuspendLayout();
            this.tabPageEditJudge.SuspendLayout();
            this.tabPageAddJudge.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.JudgesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NationalityErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SSNErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weirddatagridfix)).BeginInit();
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
            this.AddJudgeSSNLabel.Location = new System.Drawing.Point(6, 62);
            this.AddJudgeSSNLabel.Name = "AddJudgeSSNLabel";
            this.AddJudgeSSNLabel.Size = new System.Drawing.Size(32, 13);
            this.AddJudgeSSNLabel.TabIndex = 3;
            this.AddJudgeSSNLabel.Text = "SSN";
            // 
            // AddJudgeNationalityLabel
            // 
            this.AddJudgeNationalityLabel.AutoSize = true;
            this.AddJudgeNationalityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddJudgeNationalityLabel.Location = new System.Drawing.Point(6, 36);
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
            // 
            // AddJudgeNationaltyTb
            // 
            this.AddJudgeNationaltyTb.Location = new System.Drawing.Point(98, 36);
            this.AddJudgeNationaltyTb.Name = "AddJudgeNationaltyTb";
            this.AddJudgeNationaltyTb.Size = new System.Drawing.Size(148, 20);
            this.AddJudgeNationaltyTb.TabIndex = 7;
            this.InputToolTip.SetToolTip(this.AddJudgeNationaltyTb, "Allowed characters: \"A-Z ,-\"");
            this.AddJudgeNationaltyTb.Click += new System.EventHandler(this.AddJudgeNationaltyTb_Click);
            // 
            // AddJudgeSSNTb
            // 
            this.AddJudgeSSNTb.Location = new System.Drawing.Point(98, 62);
            this.AddJudgeSSNTb.Name = "AddJudgeSSNTb";
            this.AddJudgeSSNTb.Size = new System.Drawing.Size(148, 20);
            this.AddJudgeSSNTb.TabIndex = 8;
            this.InputToolTip.SetToolTip(this.AddJudgeSSNTb, "Allowed characters: \"1-9 -\". Swedish: yyyymmdd-xxxx. Rest: xxx-yy-zzzz");
            this.AddJudgeSSNTb.Click += new System.EventHandler(this.AddJudgeSSNTb_Click);
            // 
            // AddJudgeButton
            // 
            this.AddJudgeButton.Location = new System.Drawing.Point(98, 127);
            this.AddJudgeButton.Name = "AddJudgeButton";
            this.AddJudgeButton.Size = new System.Drawing.Size(75, 23);
            this.AddJudgeButton.TabIndex = 10;
            this.AddJudgeButton.Text = "Add";
            this.AddJudgeButton.UseVisualStyleBackColor = true;
            this.AddJudgeButton.Click += new System.EventHandler(this.AddJudgeButton_Click);
            // 
            // UpdateJudgeSSNTb
            // 
            this.UpdateJudgeSSNTb.Location = new System.Drawing.Point(98, 62);
            this.UpdateJudgeSSNTb.Name = "UpdateJudgeSSNTb";
            this.UpdateJudgeSSNTb.Size = new System.Drawing.Size(148, 20);
            this.UpdateJudgeSSNTb.TabIndex = 17;
            this.InputToolTip.SetToolTip(this.UpdateJudgeSSNTb, "Allowed characters: \"1-9 -\". Swedish: yyyymmdd-xxxx. Rest: xxx-yy-zzzz");
            this.UpdateJudgeSSNTb.Click += new System.EventHandler(this.UpdateJudgeSSNTb_Click);
            // 
            // UpdateJudgeNationalityTb
            // 
            this.UpdateJudgeNationalityTb.Location = new System.Drawing.Point(98, 36);
            this.UpdateJudgeNationalityTb.Name = "UpdateJudgeNationalityTb";
            this.UpdateJudgeNationalityTb.Size = new System.Drawing.Size(148, 20);
            this.UpdateJudgeNationalityTb.TabIndex = 16;
            this.InputToolTip.SetToolTip(this.UpdateJudgeNationalityTb, "Allowed characters: \"A-Z ,-\"");
            this.UpdateJudgeNationalityTb.Click += new System.EventHandler(this.UpdateJudgeNationalityTb_Click);
            // 
            // UpdateJudgeNameTb
            // 
            this.UpdateJudgeNameTb.Location = new System.Drawing.Point(98, 10);
            this.UpdateJudgeNameTb.Name = "UpdateJudgeNameTb";
            this.UpdateJudgeNameTb.Size = new System.Drawing.Size(148, 20);
            this.UpdateJudgeNameTb.TabIndex = 15;
            this.InputToolTip.SetToolTip(this.UpdateJudgeNameTb, "Allowed characters: \"A-Z \',.-\"");
            this.UpdateJudgeNameTb.Click += new System.EventHandler(this.UpdateJudgeNameTb_Click);
            // 
            // EditJudgeNationalityLabel
            // 
            this.EditJudgeNationalityLabel.AutoSize = true;
            this.EditJudgeNationalityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditJudgeNationalityLabel.Location = new System.Drawing.Point(6, 36);
            this.EditJudgeNationalityLabel.Name = "EditJudgeNationalityLabel";
            this.EditJudgeNationalityLabel.Size = new System.Drawing.Size(67, 13);
            this.EditJudgeNationalityLabel.TabIndex = 14;
            this.EditJudgeNationalityLabel.Text = "Nationality";
            // 
            // EditJudgeSSNLabel
            // 
            this.EditJudgeSSNLabel.AutoSize = true;
            this.EditJudgeSSNLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditJudgeSSNLabel.Location = new System.Drawing.Point(6, 62);
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
            this.UpdateJudgeButton.Location = new System.Drawing.Point(17, 127);
            this.UpdateJudgeButton.Name = "UpdateJudgeButton";
            this.UpdateJudgeButton.Size = new System.Drawing.Size(75, 23);
            this.UpdateJudgeButton.TabIndex = 18;
            this.UpdateJudgeButton.Text = "Update";
            this.UpdateJudgeButton.UseVisualStyleBackColor = true;
            this.UpdateJudgeButton.Click += new System.EventHandler(this.UpdateJudgeButton_Click);
            // 
            // AddJudgeCloseBtn
            // 
            this.AddJudgeCloseBtn.Location = new System.Drawing.Point(271, 127);
            this.AddJudgeCloseBtn.Name = "AddJudgeCloseBtn";
            this.AddJudgeCloseBtn.Size = new System.Drawing.Size(75, 23);
            this.AddJudgeCloseBtn.TabIndex = 11;
            this.AddJudgeCloseBtn.Text = "Close";
            this.AddJudgeCloseBtn.UseVisualStyleBackColor = true;
            this.AddJudgeCloseBtn.Click += new System.EventHandler(this.AddJudgePreviousBtn_Click);
            // 
            // tabControlAddEdit
            // 
            this.tabControlAddEdit.Controls.Add(this.tabPageEditJudge);
            this.tabControlAddEdit.Controls.Add(this.tabPageAddJudge);
            this.tabControlAddEdit.Location = new System.Drawing.Point(6, 261);
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
            this.UpdateJudgeRemoveBtn.Location = new System.Drawing.Point(98, 127);
            this.UpdateJudgeRemoveBtn.Name = "UpdateJudgeRemoveBtn";
            this.UpdateJudgeRemoveBtn.Size = new System.Drawing.Size(75, 23);
            this.UpdateJudgeRemoveBtn.TabIndex = 19;
            this.UpdateJudgeRemoveBtn.Text = "Remove";
            this.UpdateJudgeRemoveBtn.UseVisualStyleBackColor = true;
            this.UpdateJudgeRemoveBtn.Click += new System.EventHandler(this.UpdateJudgeRemoveBtn_Click);
            // 
            // UpdateJudgeClosebtn
            // 
            this.UpdateJudgeClosebtn.Location = new System.Drawing.Point(271, 127);
            this.UpdateJudgeClosebtn.Name = "UpdateJudgeClosebtn";
            this.UpdateJudgeClosebtn.Size = new System.Drawing.Size(75, 23);
            this.UpdateJudgeClosebtn.TabIndex = 23;
            this.UpdateJudgeClosebtn.Text = "Close";
            this.UpdateJudgeClosebtn.UseVisualStyleBackColor = true;
            this.UpdateJudgeClosebtn.Click += new System.EventHandler(this.UpdateJudgePreviousBtn_Click);
            // 
            // tabPageAddJudge
            // 
            this.tabPageAddJudge.Controls.Add(this.AddJudgePasswordTb);
            this.tabPageAddJudge.Controls.Add(this.AddJudgePasswordLabel);
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
            // AddJudgePasswordTb
            // 
            this.AddJudgePasswordTb.Location = new System.Drawing.Point(98, 88);
            this.AddJudgePasswordTb.Name = "AddJudgePasswordTb";
            this.AddJudgePasswordTb.Size = new System.Drawing.Size(148, 20);
            this.AddJudgePasswordTb.TabIndex = 9;
            this.InputToolTip.SetToolTip(this.AddJudgePasswordTb, "Judge password.");
            this.AddJudgePasswordTb.UseSystemPasswordChar = true;
            // 
            // AddJudgePasswordLabel
            // 
            this.AddJudgePasswordLabel.AutoSize = true;
            this.AddJudgePasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddJudgePasswordLabel.Location = new System.Drawing.Point(6, 88);
            this.AddJudgePasswordLabel.Name = "AddJudgePasswordLabel";
            this.AddJudgePasswordLabel.Size = new System.Drawing.Size(61, 13);
            this.AddJudgePasswordLabel.TabIndex = 21;
            this.AddJudgePasswordLabel.Text = "Password";
            // 
            // JudgesDataGridView
            // 
            this.JudgesDataGridView.AllowUserToAddRows = false;
            this.JudgesDataGridView.AllowUserToDeleteRows = false;
            this.JudgesDataGridView.AllowUserToOrderColumns = true;
            this.JudgesDataGridView.AllowUserToResizeColumns = false;
            this.JudgesDataGridView.AllowUserToResizeRows = false;
            this.JudgesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.JudgesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.JudgesDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.JudgesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.JudgesDataGridView.Location = new System.Drawing.Point(6, 12);
            this.JudgesDataGridView.Name = "JudgesDataGridView";
            this.JudgesDataGridView.ReadOnly = true;
            this.JudgesDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.JudgesDataGridView.Size = new System.Drawing.Size(360, 245);
            this.JudgesDataGridView.TabIndex = 22;
            this.JudgesDataGridView.TabStop = false;
            this.JudgesDataGridView.SelectionChanged += new System.EventHandler(this.JudgesDataGridView_SelectionChanged);
            this.JudgesDataGridView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AddEditJudge_KeyUp);
            // 
            // NameErrorProvider
            // 
            this.NameErrorProvider.BlinkRate = 150;
            this.NameErrorProvider.ContainerControl = this;
            // 
            // NationalityErrorProvider
            // 
            this.NationalityErrorProvider.BlinkRate = 150;
            this.NationalityErrorProvider.ContainerControl = this;
            // 
            // SSNErrorProvider
            // 
            this.SSNErrorProvider.BlinkRate = 150;
            this.SSNErrorProvider.ContainerControl = this;
            // 
            // weirddatagridfix
            // 
            this.weirddatagridfix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.weirddatagridfix.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.weirdfix});
            this.weirddatagridfix.Location = new System.Drawing.Point(387, 263);
            this.weirddatagridfix.Name = "weirddatagridfix";
            this.weirddatagridfix.Size = new System.Drawing.Size(138, 52);
            this.weirddatagridfix.TabIndex = 23;
            this.weirddatagridfix.TabStop = false;
            // 
            // weirdfix
            // 
            this.weirdfix.HeaderText = "weirdfix";
            this.weirdfix.Name = "weirdfix";
            // 
            // EditJudgeHiddenLabel
            // 
            this.EditJudgeHiddenLabel.AutoSize = true;
            this.EditJudgeHiddenLabel.Enabled = false;
            this.EditJudgeHiddenLabel.Location = new System.Drawing.Point(17, 240);
            this.EditJudgeHiddenLabel.Name = "EditJudgeHiddenLabel";
            this.EditJudgeHiddenLabel.Size = new System.Drawing.Size(66, 13);
            this.EditJudgeHiddenLabel.TabIndex = 0;
            this.EditJudgeHiddenLabel.Text = "Hidden label";
            this.EditJudgeHiddenLabel.Visible = false;
            // 
            // AddJudgeHiddenLabel
            // 
            this.AddJudgeHiddenLabel.AutoSize = true;
            this.AddJudgeHiddenLabel.Enabled = false;
            this.AddJudgeHiddenLabel.Location = new System.Drawing.Point(87, 240);
            this.AddJudgeHiddenLabel.Name = "AddJudgeHiddenLabel";
            this.AddJudgeHiddenLabel.Size = new System.Drawing.Size(66, 13);
            this.AddJudgeHiddenLabel.TabIndex = 0;
            this.AddJudgeHiddenLabel.Text = "Hidden label";
            this.AddJudgeHiddenLabel.Visible = false;
            // 
            // JudgesDataGridHiddenLabel
            // 
            this.JudgesDataGridHiddenLabel.AutoSize = true;
            this.JudgesDataGridHiddenLabel.Enabled = false;
            this.JudgesDataGridHiddenLabel.Location = new System.Drawing.Point(3, 12);
            this.JudgesDataGridHiddenLabel.Name = "JudgesDataGridHiddenLabel";
            this.JudgesDataGridHiddenLabel.Size = new System.Drawing.Size(66, 13);
            this.JudgesDataGridHiddenLabel.TabIndex = 24;
            this.JudgesDataGridHiddenLabel.Text = "Hidden label";
            this.JudgesDataGridHiddenLabel.Visible = false;
            // 
            // AddEditJudge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 480);
            this.Controls.Add(this.JudgesDataGridHiddenLabel);
            this.Controls.Add(this.AddJudgeHiddenLabel);
            this.Controls.Add(this.EditJudgeHiddenLabel);
            this.Controls.Add(this.weirddatagridfix);
            this.Controls.Add(this.JudgesDataGridView);
            this.Controls.Add(this.tabControlAddEdit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditJudge";
            this.Text = "Add/Edit Judge";
            this.Load += new System.EventHandler(this.AddEditJudge_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddEditJudge_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AddEditJudge_KeyUp);
            this.tabControlAddEdit.ResumeLayout(false);
            this.tabPageEditJudge.ResumeLayout(false);
            this.tabPageEditJudge.PerformLayout();
            this.tabPageAddJudge.ResumeLayout(false);
            this.tabPageAddJudge.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.JudgesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NationalityErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SSNErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weirddatagridfix)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.ErrorProvider NameErrorProvider;
        private System.Windows.Forms.ToolTip InputToolTip;
        private System.Windows.Forms.ErrorProvider NationalityErrorProvider;
        private System.Windows.Forms.ErrorProvider SSNErrorProvider;
        private System.Windows.Forms.TextBox AddJudgePasswordTb;
        private System.Windows.Forms.Label AddJudgePasswordLabel;
        private System.Windows.Forms.DataGridView weirddatagridfix;
        private System.Windows.Forms.DataGridViewTextBoxColumn weirdfix;
        private System.Windows.Forms.ToolTip EditJudgeToolTip;
        private System.Windows.Forms.ToolTip AddJudgeToolTip;
        private System.Windows.Forms.Label AddJudgeHiddenLabel;
        private System.Windows.Forms.Label EditJudgeHiddenLabel;
        private System.Windows.Forms.ToolTip JudgesDataGridToolTip;
        private System.Windows.Forms.Label JudgesDataGridHiddenLabel;
    }
}