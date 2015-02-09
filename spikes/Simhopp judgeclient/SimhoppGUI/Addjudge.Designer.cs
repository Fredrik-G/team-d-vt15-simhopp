namespace SimhoppGUI
{
    partial class Addjudge
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Center);
            this.AddJudgeLabel = new System.Windows.Forms.Label();
            this.AddJudgeNameLabel = new System.Windows.Forms.Label();
            this.AddJudgeSSNLabel = new System.Windows.Forms.Label();
            this.AddJudgeNationalityLabel = new System.Windows.Forms.Label();
            this.AddJudgeNameTb = new System.Windows.Forms.TextBox();
            this.AddJudgeNationaltyTb = new System.Windows.Forms.TextBox();
            this.AddJudgeSSNTb = new System.Windows.Forms.TextBox();
            this.AddJudgeButton = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SSN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NameJudge = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Nationality = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.UpdateJudgeSSNTb = new System.Windows.Forms.TextBox();
            this.UpdateJudgeNationalityTb = new System.Windows.Forms.TextBox();
            this.UpdateJudgeNameTb = new System.Windows.Forms.TextBox();
            this.EditJudgeNationalityLabel = new System.Windows.Forms.Label();
            this.EditJudgeSSNLabel = new System.Windows.Forms.Label();
            this.EditJudgeNameLabel = new System.Windows.Forms.Label();
            this.UpdateJudgeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddJudgeLabel
            // 
            this.AddJudgeLabel.AutoSize = true;
            this.AddJudgeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddJudgeLabel.Location = new System.Drawing.Point(117, 39);
            this.AddJudgeLabel.Name = "AddJudgeLabel";
            this.AddJudgeLabel.Size = new System.Drawing.Size(81, 20);
            this.AddJudgeLabel.TabIndex = 0;
            this.AddJudgeLabel.Text = "Add judge";
            // 
            // AddJudgeNameLabel
            // 
            this.AddJudgeNameLabel.AutoSize = true;
            this.AddJudgeNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddJudgeNameLabel.Location = new System.Drawing.Point(40, 99);
            this.AddJudgeNameLabel.Name = "AddJudgeNameLabel";
            this.AddJudgeNameLabel.Size = new System.Drawing.Size(39, 13);
            this.AddJudgeNameLabel.TabIndex = 2;
            this.AddJudgeNameLabel.Text = "Name";
            // 
            // AddJudgeSSNLabel
            // 
            this.AddJudgeSSNLabel.AutoSize = true;
            this.AddJudgeSSNLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddJudgeSSNLabel.Location = new System.Drawing.Point(40, 169);
            this.AddJudgeSSNLabel.Name = "AddJudgeSSNLabel";
            this.AddJudgeSSNLabel.Size = new System.Drawing.Size(32, 13);
            this.AddJudgeSSNLabel.TabIndex = 3;
            this.AddJudgeSSNLabel.Text = "SSN";
            // 
            // AddJudgeNationalityLabel
            // 
            this.AddJudgeNationalityLabel.AutoSize = true;
            this.AddJudgeNationalityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddJudgeNationalityLabel.Location = new System.Drawing.Point(40, 134);
            this.AddJudgeNationalityLabel.Name = "AddJudgeNationalityLabel";
            this.AddJudgeNationalityLabel.Size = new System.Drawing.Size(67, 13);
            this.AddJudgeNationalityLabel.TabIndex = 4;
            this.AddJudgeNationalityLabel.Text = "Nationality";
            // 
            // AddJudgeNameTb
            // 
            this.AddJudgeNameTb.Location = new System.Drawing.Point(121, 99);
            this.AddJudgeNameTb.Name = "AddJudgeNameTb";
            this.AddJudgeNameTb.Size = new System.Drawing.Size(148, 20);
            this.AddJudgeNameTb.TabIndex = 6;
            // 
            // AddJudgeNationaltyTb
            // 
            this.AddJudgeNationaltyTb.Location = new System.Drawing.Point(121, 134);
            this.AddJudgeNationaltyTb.Name = "AddJudgeNationaltyTb";
            this.AddJudgeNationaltyTb.Size = new System.Drawing.Size(148, 20);
            this.AddJudgeNationaltyTb.TabIndex = 7;
            // 
            // AddJudgeSSNTb
            // 
            this.AddJudgeSSNTb.Location = new System.Drawing.Point(121, 169);
            this.AddJudgeSSNTb.Name = "AddJudgeSSNTb";
            this.AddJudgeSSNTb.Size = new System.Drawing.Size(148, 20);
            this.AddJudgeSSNTb.TabIndex = 8;
            // 
            // AddJudgeButton
            // 
            this.AddJudgeButton.Location = new System.Drawing.Point(194, 222);
            this.AddJudgeButton.Name = "AddJudgeButton";
            this.AddJudgeButton.Size = new System.Drawing.Size(75, 23);
            this.AddJudgeButton.TabIndex = 9;
            this.AddJudgeButton.Text = "Add";
            this.AddJudgeButton.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SSN,
            this.NameJudge,
            this.Nationality});
            listViewGroup1.Header = "ListViewGroup";
            listViewGroup1.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            listViewGroup1.Name = "listViewGroup1";
            this.listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.listView1.Location = new System.Drawing.Point(86, 315);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(615, 241);
            this.listView1.TabIndex = 10;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // SSN
            // 
            this.SSN.Text = "SSN";
            this.SSN.Width = 180;
            // 
            // NameJudge
            // 
            this.NameJudge.Text = "Name";
            this.NameJudge.Width = 178;
            // 
            // Nationality
            // 
            this.Nationality.Text = "Nationality";
            this.Nationality.Width = 254;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(516, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Edit judge";
            // 
            // UpdateJudgeSSNTb
            // 
            this.UpdateJudgeSSNTb.Location = new System.Drawing.Point(520, 168);
            this.UpdateJudgeSSNTb.Name = "UpdateJudgeSSNTb";
            this.UpdateJudgeSSNTb.Size = new System.Drawing.Size(148, 20);
            this.UpdateJudgeSSNTb.TabIndex = 17;
            // 
            // UpdateJudgeNationalityTb
            // 
            this.UpdateJudgeNationalityTb.Location = new System.Drawing.Point(520, 130);
            this.UpdateJudgeNationalityTb.Name = "UpdateJudgeNationalityTb";
            this.UpdateJudgeNationalityTb.Size = new System.Drawing.Size(148, 20);
            this.UpdateJudgeNationalityTb.TabIndex = 16;
            // 
            // UpdateJudgeNameTb
            // 
            this.UpdateJudgeNameTb.Location = new System.Drawing.Point(520, 92);
            this.UpdateJudgeNameTb.Name = "UpdateJudgeNameTb";
            this.UpdateJudgeNameTb.Size = new System.Drawing.Size(148, 20);
            this.UpdateJudgeNameTb.TabIndex = 15;
            // 
            // EditJudgeNationalityLabel
            // 
            this.EditJudgeNationalityLabel.AutoSize = true;
            this.EditJudgeNationalityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditJudgeNationalityLabel.Location = new System.Drawing.Point(421, 130);
            this.EditJudgeNationalityLabel.Name = "EditJudgeNationalityLabel";
            this.EditJudgeNationalityLabel.Size = new System.Drawing.Size(67, 13);
            this.EditJudgeNationalityLabel.TabIndex = 14;
            this.EditJudgeNationalityLabel.Text = "Nationality";
            // 
            // EditJudgeSSNLabel
            // 
            this.EditJudgeSSNLabel.AutoSize = true;
            this.EditJudgeSSNLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditJudgeSSNLabel.Location = new System.Drawing.Point(421, 168);
            this.EditJudgeSSNLabel.Name = "EditJudgeSSNLabel";
            this.EditJudgeSSNLabel.Size = new System.Drawing.Size(32, 13);
            this.EditJudgeSSNLabel.TabIndex = 13;
            this.EditJudgeSSNLabel.Text = "SSN";
            // 
            // EditJudgeNameLabel
            // 
            this.EditJudgeNameLabel.AutoSize = true;
            this.EditJudgeNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditJudgeNameLabel.Location = new System.Drawing.Point(421, 92);
            this.EditJudgeNameLabel.Name = "EditJudgeNameLabel";
            this.EditJudgeNameLabel.Size = new System.Drawing.Size(39, 13);
            this.EditJudgeNameLabel.TabIndex = 12;
            this.EditJudgeNameLabel.Text = "Name";
            // 
            // UpdateJudgeButton
            // 
            this.UpdateJudgeButton.Location = new System.Drawing.Point(593, 222);
            this.UpdateJudgeButton.Name = "UpdateJudgeButton";
            this.UpdateJudgeButton.Size = new System.Drawing.Size(75, 23);
            this.UpdateJudgeButton.TabIndex = 18;
            this.UpdateJudgeButton.Text = "Update";
            this.UpdateJudgeButton.UseVisualStyleBackColor = true;
            // 
            // Addjudge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 609);
            this.Controls.Add(this.UpdateJudgeButton);
            this.Controls.Add(this.UpdateJudgeSSNTb);
            this.Controls.Add(this.UpdateJudgeNationalityTb);
            this.Controls.Add(this.UpdateJudgeNameTb);
            this.Controls.Add(this.EditJudgeNationalityLabel);
            this.Controls.Add(this.EditJudgeSSNLabel);
            this.Controls.Add(this.EditJudgeNameLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.AddJudgeButton);
            this.Controls.Add(this.AddJudgeSSNTb);
            this.Controls.Add(this.AddJudgeNationaltyTb);
            this.Controls.Add(this.AddJudgeNameTb);
            this.Controls.Add(this.AddJudgeNationalityLabel);
            this.Controls.Add(this.AddJudgeSSNLabel);
            this.Controls.Add(this.AddJudgeNameLabel);
            this.Controls.Add(this.AddJudgeLabel);
            this.Name = "Addjudge";
            this.Text = "Addjudge";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label AddJudgeLabel;
        private System.Windows.Forms.Label AddJudgeNameLabel;
        private System.Windows.Forms.Label AddJudgeSSNLabel;
        private System.Windows.Forms.Label AddJudgeNationalityLabel;
        private System.Windows.Forms.TextBox AddJudgeNameTb;
        private System.Windows.Forms.TextBox AddJudgeNationaltyTb;
        private System.Windows.Forms.TextBox AddJudgeSSNTb;
        private System.Windows.Forms.Button AddJudgeButton;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader SSN;
        private System.Windows.Forms.ColumnHeader NameJudge;
        private System.Windows.Forms.ColumnHeader Nationality;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UpdateJudgeSSNTb;
        private System.Windows.Forms.TextBox UpdateJudgeNationalityTb;
        private System.Windows.Forms.TextBox UpdateJudgeNameTb;
        private System.Windows.Forms.Label EditJudgeNationalityLabel;
        private System.Windows.Forms.Label EditJudgeSSNLabel;
        private System.Windows.Forms.Label EditJudgeNameLabel;
        private System.Windows.Forms.Button UpdateJudgeButton;
    }
}