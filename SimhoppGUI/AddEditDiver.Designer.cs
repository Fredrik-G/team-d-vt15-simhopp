namespace SimhoppGUI
{
    partial class AddEditDiver
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
            this.AddDiverNameLabel = new System.Windows.Forms.Label();
            this.AddDiverSSNLabel = new System.Windows.Forms.Label();
            this.AddDiverNationalityLabel = new System.Windows.Forms.Label();
            this.AddDiverNameTb = new System.Windows.Forms.TextBox();
            this.AddDiverNationaltyTb = new System.Windows.Forms.TextBox();
            this.AddDiverSSNTb = new System.Windows.Forms.TextBox();
            this.AddDiverButton = new System.Windows.Forms.Button();
            this.UpdateDiverSSNTb = new System.Windows.Forms.TextBox();
            this.UpdateDiverNationalityTb = new System.Windows.Forms.TextBox();
            this.UpdateDiverNameTb = new System.Windows.Forms.TextBox();
            this.EditDiverNationalityLabel = new System.Windows.Forms.Label();
            this.EditDiverSSNLabel = new System.Windows.Forms.Label();
            this.EditDiverNameLabel = new System.Windows.Forms.Label();
            this.UpdateDiverButton = new System.Windows.Forms.Button();
            this.AddDiverCloseBtn = new System.Windows.Forms.Button();
            this.tabControlAddEdit = new System.Windows.Forms.TabControl();
            this.tabPageEditDiver = new System.Windows.Forms.TabPage();
            this.UpdateDiverRemoveBtn = new System.Windows.Forms.Button();
            this.UpdateDiverClosebtn = new System.Windows.Forms.Button();
            this.tabPageAddDiver = new System.Windows.Forms.TabPage();
            this.DiverDataGridView = new System.Windows.Forms.DataGridView();
            this.NameErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.InputToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.NationalityErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.SSNErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.weirddatagridfix = new System.Windows.Forms.DataGridView();
            this.weirdfix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiverDataGridHiddenLabel = new System.Windows.Forms.Label();
            this.AddDiverHiddenLabel = new System.Windows.Forms.Label();
            this.EditDiverHiddenLabel = new System.Windows.Forms.Label();
            this.AddDiverToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.DiversDataGridToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.EditDiverToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tabControlAddEdit.SuspendLayout();
            this.tabPageEditDiver.SuspendLayout();
            this.tabPageAddDiver.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DiverDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NationalityErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SSNErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weirddatagridfix)).BeginInit();
            this.SuspendLayout();
            // 
            // AddDiverNameLabel
            // 
            this.AddDiverNameLabel.AutoSize = true;
            this.AddDiverNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddDiverNameLabel.Location = new System.Drawing.Point(6, 10);
            this.AddDiverNameLabel.Name = "AddDiverNameLabel";
            this.AddDiverNameLabel.Size = new System.Drawing.Size(39, 13);
            this.AddDiverNameLabel.TabIndex = 2;
            this.AddDiverNameLabel.Text = "Name";
            // 
            // AddDiverSSNLabel
            // 
            this.AddDiverSSNLabel.AutoSize = true;
            this.AddDiverSSNLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddDiverSSNLabel.Location = new System.Drawing.Point(6, 62);
            this.AddDiverSSNLabel.Name = "AddDiverSSNLabel";
            this.AddDiverSSNLabel.Size = new System.Drawing.Size(32, 13);
            this.AddDiverSSNLabel.TabIndex = 3;
            this.AddDiverSSNLabel.Text = "SSN";
            // 
            // AddDiverNationalityLabel
            // 
            this.AddDiverNationalityLabel.AutoSize = true;
            this.AddDiverNationalityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddDiverNationalityLabel.Location = new System.Drawing.Point(6, 36);
            this.AddDiverNationalityLabel.Name = "AddDiverNationalityLabel";
            this.AddDiverNationalityLabel.Size = new System.Drawing.Size(67, 13);
            this.AddDiverNationalityLabel.TabIndex = 4;
            this.AddDiverNationalityLabel.Text = "Nationality";
            // 
            // AddDiverNameTb
            // 
            this.AddDiverNameTb.Location = new System.Drawing.Point(98, 10);
            this.AddDiverNameTb.Name = "AddDiverNameTb";
            this.AddDiverNameTb.Size = new System.Drawing.Size(157, 20);
            this.AddDiverNameTb.TabIndex = 6;
            this.InputToolTip.SetToolTip(this.AddDiverNameTb, "Allowed characters: \"A-Z \',.-\"");
            this.AddDiverNameTb.Click += new System.EventHandler(this.AddDiverNameTb_Click);
            this.AddDiverNameTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AddCheckEnterOrEscape);
            // 
            // AddDiverNationaltyTb
            // 
            this.AddDiverNationaltyTb.Location = new System.Drawing.Point(98, 36);
            this.AddDiverNationaltyTb.Name = "AddDiverNationaltyTb";
            this.AddDiverNationaltyTb.Size = new System.Drawing.Size(157, 20);
            this.AddDiverNationaltyTb.TabIndex = 7;
            this.InputToolTip.SetToolTip(this.AddDiverNationaltyTb, "Allowed characters: \"A-Z ,-\"");
            this.AddDiverNationaltyTb.Click += new System.EventHandler(this.AddDiverNationaltyTb_Click);
            this.AddDiverNationaltyTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AddCheckEnterOrEscape);
            // 
            // AddDiverSSNTb
            // 
            this.AddDiverSSNTb.Location = new System.Drawing.Point(98, 62);
            this.AddDiverSSNTb.Name = "AddDiverSSNTb";
            this.AddDiverSSNTb.Size = new System.Drawing.Size(157, 20);
            this.AddDiverSSNTb.TabIndex = 8;
            this.InputToolTip.SetToolTip(this.AddDiverSSNTb, "Allowed characters: \"1-9 -\". Swedish: yyyymmdd-xxxx. Rest: xxx-yy-zzzz");
            this.AddDiverSSNTb.Click += new System.EventHandler(this.AddDiverSSNTb_Click);
            this.AddDiverSSNTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AddCheckEnterOrEscape);
            // 
            // AddDiverButton
            // 
            this.AddDiverButton.Location = new System.Drawing.Point(180, 101);
            this.AddDiverButton.Name = "AddDiverButton";
            this.AddDiverButton.Size = new System.Drawing.Size(75, 23);
            this.AddDiverButton.TabIndex = 10;
            this.AddDiverButton.Text = "Add";
            this.AddDiverButton.UseVisualStyleBackColor = true;
            this.AddDiverButton.Click += new System.EventHandler(this.AddDiverButton_Click);
            // 
            // UpdateDiverSSNTb
            // 
            this.UpdateDiverSSNTb.Location = new System.Drawing.Point(98, 62);
            this.UpdateDiverSSNTb.Name = "UpdateDiverSSNTb";
            this.UpdateDiverSSNTb.Size = new System.Drawing.Size(157, 20);
            this.UpdateDiverSSNTb.TabIndex = 17;
            this.InputToolTip.SetToolTip(this.UpdateDiverSSNTb, "Allowed characters: \"1-9 -\". Swedish: yyyymmdd-xxxx. Rest: xxx-yy-zzzz");
            this.UpdateDiverSSNTb.Click += new System.EventHandler(this.UpdateDiverSSNTb_Click);
            this.UpdateDiverSSNTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UpdateCheckEnterOrEscape);
            // 
            // UpdateDiverNationalityTb
            // 
            this.UpdateDiverNationalityTb.Location = new System.Drawing.Point(98, 36);
            this.UpdateDiverNationalityTb.Name = "UpdateDiverNationalityTb";
            this.UpdateDiverNationalityTb.Size = new System.Drawing.Size(157, 20);
            this.UpdateDiverNationalityTb.TabIndex = 16;
            this.InputToolTip.SetToolTip(this.UpdateDiverNationalityTb, "Allowed characters: \"A-Z ,-\"");
            this.UpdateDiverNationalityTb.Click += new System.EventHandler(this.UpdateDiverNationalityTb_Click);
            this.UpdateDiverNationalityTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UpdateCheckEnterOrEscape);
            // 
            // UpdateDiverNameTb
            // 
            this.UpdateDiverNameTb.Location = new System.Drawing.Point(98, 10);
            this.UpdateDiverNameTb.Name = "UpdateDiverNameTb";
            this.UpdateDiverNameTb.Size = new System.Drawing.Size(157, 20);
            this.UpdateDiverNameTb.TabIndex = 15;
            this.InputToolTip.SetToolTip(this.UpdateDiverNameTb, "Allowed characters: \"A-Z \',.-\"");
            this.UpdateDiverNameTb.Click += new System.EventHandler(this.UpdateDiverNameTb_Click);
            this.UpdateDiverNameTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UpdateCheckEnterOrEscape);
            // 
            // EditDiverNationalityLabel
            // 
            this.EditDiverNationalityLabel.AutoSize = true;
            this.EditDiverNationalityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditDiverNationalityLabel.Location = new System.Drawing.Point(6, 36);
            this.EditDiverNationalityLabel.Name = "EditDiverNationalityLabel";
            this.EditDiverNationalityLabel.Size = new System.Drawing.Size(67, 13);
            this.EditDiverNationalityLabel.TabIndex = 14;
            this.EditDiverNationalityLabel.Text = "Nationality";
            // 
            // EditDiverSSNLabel
            // 
            this.EditDiverSSNLabel.AutoSize = true;
            this.EditDiverSSNLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditDiverSSNLabel.Location = new System.Drawing.Point(6, 62);
            this.EditDiverSSNLabel.Name = "EditDiverSSNLabel";
            this.EditDiverSSNLabel.Size = new System.Drawing.Size(32, 13);
            this.EditDiverSSNLabel.TabIndex = 13;
            this.EditDiverSSNLabel.Text = "SSN";
            // 
            // EditDiverNameLabel
            // 
            this.EditDiverNameLabel.AutoSize = true;
            this.EditDiverNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditDiverNameLabel.Location = new System.Drawing.Point(6, 10);
            this.EditDiverNameLabel.Name = "EditDiverNameLabel";
            this.EditDiverNameLabel.Size = new System.Drawing.Size(39, 13);
            this.EditDiverNameLabel.TabIndex = 12;
            this.EditDiverNameLabel.Text = "Name";
            // 
            // UpdateDiverButton
            // 
            this.UpdateDiverButton.Location = new System.Drawing.Point(98, 101);
            this.UpdateDiverButton.Name = "UpdateDiverButton";
            this.UpdateDiverButton.Size = new System.Drawing.Size(75, 23);
            this.UpdateDiverButton.TabIndex = 18;
            this.UpdateDiverButton.Text = "Update";
            this.UpdateDiverButton.UseVisualStyleBackColor = true;
            this.UpdateDiverButton.Click += new System.EventHandler(this.UpdateDiverButton_Click);
            // 
            // AddDiverCloseBtn
            // 
            this.AddDiverCloseBtn.Location = new System.Drawing.Point(268, 101);
            this.AddDiverCloseBtn.Name = "AddDiverCloseBtn";
            this.AddDiverCloseBtn.Size = new System.Drawing.Size(75, 23);
            this.AddDiverCloseBtn.TabIndex = 11;
            this.AddDiverCloseBtn.Text = "Close";
            this.AddDiverCloseBtn.UseVisualStyleBackColor = true;
            this.AddDiverCloseBtn.Click += new System.EventHandler(this.AddDiverPreviousBtn_Click);
            // 
            // tabControlAddEdit
            // 
            this.tabControlAddEdit.Controls.Add(this.tabPageEditDiver);
            this.tabControlAddEdit.Controls.Add(this.tabPageAddDiver);
            this.tabControlAddEdit.Location = new System.Drawing.Point(6, 261);
            this.tabControlAddEdit.Name = "tabControlAddEdit";
            this.tabControlAddEdit.SelectedIndex = 0;
            this.tabControlAddEdit.Size = new System.Drawing.Size(360, 168);
            this.tabControlAddEdit.TabIndex = 21;
            this.tabControlAddEdit.SelectedIndexChanged += new System.EventHandler(this.tabControlAddEdit_SelectedIndexChanged);
            // 
            // tabPageEditDiver
            // 
            this.tabPageEditDiver.Controls.Add(this.UpdateDiverRemoveBtn);
            this.tabPageEditDiver.Controls.Add(this.UpdateDiverClosebtn);
            this.tabPageEditDiver.Controls.Add(this.UpdateDiverButton);
            this.tabPageEditDiver.Controls.Add(this.EditDiverNameLabel);
            this.tabPageEditDiver.Controls.Add(this.EditDiverSSNLabel);
            this.tabPageEditDiver.Controls.Add(this.EditDiverNationalityLabel);
            this.tabPageEditDiver.Controls.Add(this.UpdateDiverSSNTb);
            this.tabPageEditDiver.Controls.Add(this.UpdateDiverNameTb);
            this.tabPageEditDiver.Controls.Add(this.UpdateDiverNationalityTb);
            this.tabPageEditDiver.Location = new System.Drawing.Point(4, 22);
            this.tabPageEditDiver.Name = "tabPageEditDiver";
            this.tabPageEditDiver.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEditDiver.Size = new System.Drawing.Size(352, 142);
            this.tabPageEditDiver.TabIndex = 1;
            this.tabPageEditDiver.Text = "Edit Diver";
            this.tabPageEditDiver.UseVisualStyleBackColor = true;
            // 
            // UpdateDiverRemoveBtn
            // 
            this.UpdateDiverRemoveBtn.Location = new System.Drawing.Point(180, 101);
            this.UpdateDiverRemoveBtn.Name = "UpdateDiverRemoveBtn";
            this.UpdateDiverRemoveBtn.Size = new System.Drawing.Size(75, 23);
            this.UpdateDiverRemoveBtn.TabIndex = 19;
            this.UpdateDiverRemoveBtn.Text = "Remove";
            this.UpdateDiverRemoveBtn.UseVisualStyleBackColor = true;
            this.UpdateDiverRemoveBtn.Click += new System.EventHandler(this.UpdateDiverRemoveBtn_Click);
            // 
            // UpdateDiverClosebtn
            // 
            this.UpdateDiverClosebtn.Location = new System.Drawing.Point(268, 101);
            this.UpdateDiverClosebtn.Name = "UpdateDiverClosebtn";
            this.UpdateDiverClosebtn.Size = new System.Drawing.Size(75, 23);
            this.UpdateDiverClosebtn.TabIndex = 23;
            this.UpdateDiverClosebtn.Text = "Close";
            this.UpdateDiverClosebtn.UseVisualStyleBackColor = true;
            this.UpdateDiverClosebtn.Click += new System.EventHandler(this.UpdateDiverPreviousBtn_Click);
            // 
            // tabPageAddDiver
            // 
            this.tabPageAddDiver.Controls.Add(this.AddDiverNameLabel);
            this.tabPageAddDiver.Controls.Add(this.AddDiverButton);
            this.tabPageAddDiver.Controls.Add(this.AddDiverCloseBtn);
            this.tabPageAddDiver.Controls.Add(this.AddDiverSSNTb);
            this.tabPageAddDiver.Controls.Add(this.AddDiverSSNLabel);
            this.tabPageAddDiver.Controls.Add(this.AddDiverNationaltyTb);
            this.tabPageAddDiver.Controls.Add(this.AddDiverNameTb);
            this.tabPageAddDiver.Controls.Add(this.AddDiverNationalityLabel);
            this.tabPageAddDiver.Location = new System.Drawing.Point(4, 22);
            this.tabPageAddDiver.Name = "tabPageAddDiver";
            this.tabPageAddDiver.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAddDiver.Size = new System.Drawing.Size(352, 142);
            this.tabPageAddDiver.TabIndex = 0;
            this.tabPageAddDiver.Text = "Add Diver";
            this.tabPageAddDiver.UseVisualStyleBackColor = true;
            // 
            // DiverDataGridView
            // 
            this.DiverDataGridView.AllowUserToAddRows = false;
            this.DiverDataGridView.AllowUserToDeleteRows = false;
            this.DiverDataGridView.AllowUserToOrderColumns = true;
            this.DiverDataGridView.AllowUserToResizeColumns = false;
            this.DiverDataGridView.AllowUserToResizeRows = false;
            this.DiverDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DiverDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DiverDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DiverDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DiverDataGridView.Location = new System.Drawing.Point(6, 12);
            this.DiverDataGridView.Name = "DiverDataGridView";
            this.DiverDataGridView.ReadOnly = true;
            this.DiverDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DiverDataGridView.Size = new System.Drawing.Size(362, 241);
            this.DiverDataGridView.TabIndex = 22;
            this.DiverDataGridView.TabStop = false;
            this.DiverDataGridView.SelectionChanged += new System.EventHandler(this.DiversDataGridView_SelectionChanged);
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
            // DiverDataGridHiddenLabel
            // 
            this.DiverDataGridHiddenLabel.AutoSize = true;
            this.DiverDataGridHiddenLabel.Enabled = false;
            this.DiverDataGridHiddenLabel.Location = new System.Drawing.Point(3, 12);
            this.DiverDataGridHiddenLabel.Name = "DiverDataGridHiddenLabel";
            this.DiverDataGridHiddenLabel.Size = new System.Drawing.Size(66, 13);
            this.DiverDataGridHiddenLabel.TabIndex = 27;
            this.DiverDataGridHiddenLabel.Text = "Hidden label";
            this.DiverDataGridHiddenLabel.Visible = false;
            // 
            // AddDiverHiddenLabel
            // 
            this.AddDiverHiddenLabel.AutoSize = true;
            this.AddDiverHiddenLabel.Enabled = false;
            this.AddDiverHiddenLabel.Location = new System.Drawing.Point(87, 240);
            this.AddDiverHiddenLabel.Name = "AddDiverHiddenLabel";
            this.AddDiverHiddenLabel.Size = new System.Drawing.Size(66, 13);
            this.AddDiverHiddenLabel.TabIndex = 25;
            this.AddDiverHiddenLabel.Text = "Hidden label";
            this.AddDiverHiddenLabel.Visible = false;
            // 
            // EditDiverHiddenLabel
            // 
            this.EditDiverHiddenLabel.AutoSize = true;
            this.EditDiverHiddenLabel.Enabled = false;
            this.EditDiverHiddenLabel.Location = new System.Drawing.Point(17, 240);
            this.EditDiverHiddenLabel.Name = "EditDiverHiddenLabel";
            this.EditDiverHiddenLabel.Size = new System.Drawing.Size(66, 13);
            this.EditDiverHiddenLabel.TabIndex = 26;
            this.EditDiverHiddenLabel.Text = "Hidden label";
            this.EditDiverHiddenLabel.Visible = false;
            // 
            // AddEditDiver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 432);
            this.Controls.Add(this.DiverDataGridHiddenLabel);
            this.Controls.Add(this.AddDiverHiddenLabel);
            this.Controls.Add(this.EditDiverHiddenLabel);
            this.Controls.Add(this.weirddatagridfix);
            this.Controls.Add(this.DiverDataGridView);
            this.Controls.Add(this.tabControlAddEdit);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditDiver";
            this.Text = "Add/Edit Diver";
            this.Load += new System.EventHandler(this.AddEditDiver_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddEditDiver_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AddEditDiver_KeyUp);
            this.tabControlAddEdit.ResumeLayout(false);
            this.tabPageEditDiver.ResumeLayout(false);
            this.tabPageEditDiver.PerformLayout();
            this.tabPageAddDiver.ResumeLayout(false);
            this.tabPageAddDiver.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DiverDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NationalityErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SSNErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weirddatagridfix)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label AddDiverNameLabel;
        private System.Windows.Forms.Label AddDiverSSNLabel;
        private System.Windows.Forms.Label AddDiverNationalityLabel;
        private System.Windows.Forms.TextBox AddDiverNameTb;
        private System.Windows.Forms.TextBox AddDiverNationaltyTb;
        private System.Windows.Forms.TextBox AddDiverSSNTb;
        private System.Windows.Forms.Button AddDiverButton;
        private System.Windows.Forms.TextBox UpdateDiverSSNTb;
        private System.Windows.Forms.TextBox UpdateDiverNationalityTb;
        private System.Windows.Forms.TextBox UpdateDiverNameTb;
        private System.Windows.Forms.Label EditDiverNationalityLabel;
        private System.Windows.Forms.Label EditDiverSSNLabel;
        private System.Windows.Forms.Label EditDiverNameLabel;
        private System.Windows.Forms.Button UpdateDiverButton;
        private System.Windows.Forms.Button AddDiverCloseBtn;
        private System.Windows.Forms.TabControl tabControlAddEdit;
        private System.Windows.Forms.TabPage tabPageAddDiver;
        private System.Windows.Forms.TabPage tabPageEditDiver;
        private System.Windows.Forms.DataGridView DiverDataGridView;
        private System.Windows.Forms.Button UpdateDiverClosebtn;
        private System.Windows.Forms.Button UpdateDiverRemoveBtn;
        private System.Windows.Forms.ErrorProvider NameErrorProvider;
        private System.Windows.Forms.ToolTip InputToolTip;
        private System.Windows.Forms.ErrorProvider NationalityErrorProvider;
        private System.Windows.Forms.ErrorProvider SSNErrorProvider;
        private System.Windows.Forms.DataGridView weirddatagridfix;
        private System.Windows.Forms.DataGridViewTextBoxColumn weirdfix;
        private System.Windows.Forms.Label DiverDataGridHiddenLabel;
        private System.Windows.Forms.Label AddDiverHiddenLabel;
        private System.Windows.Forms.Label EditDiverHiddenLabel;
        private System.Windows.Forms.ToolTip AddDiverToolTip;
        private System.Windows.Forms.ToolTip DiversDataGridToolTip;
        private System.Windows.Forms.ToolTip EditDiverToolTip;
    }
}