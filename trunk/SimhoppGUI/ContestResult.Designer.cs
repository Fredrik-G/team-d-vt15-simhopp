namespace SimhoppGUI
{
    partial class ContestResult
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
            this.resultDataGridView = new System.Windows.Forms.DataGridView();
            this.resultLabel = new System.Windows.Forms.Label();
            this.judgesDataGridView = new System.Windows.Forms.DataGridView();
            this.judgesLabel = new System.Windows.Forms.Label();
            this.contestLabel = new System.Windows.Forms.Label();
            this.contestNameLabel = new System.Windows.Forms.Label();
            this.startDateLabel = new System.Windows.Forms.Label();
            this.betweenDateLabel = new System.Windows.Forms.Label();
            this.endDateLabel = new System.Windows.Forms.Label();
            this.placeLabel = new System.Windows.Forms.Label();
            this.placeNameLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.judgesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // resultDataGridView
            // 
            this.resultDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.resultDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultDataGridView.Location = new System.Drawing.Point(223, 109);
            this.resultDataGridView.Name = "resultDataGridView";
            this.resultDataGridView.Size = new System.Drawing.Size(278, 258);
            this.resultDataGridView.TabIndex = 0;
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(220, 93);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(42, 13);
            this.resultLabel.TabIndex = 1;
            this.resultLabel.Text = "Results";
            // 
            // judgesDataGridView
            // 
            this.judgesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.judgesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.judgesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.judgesDataGridView.Location = new System.Drawing.Point(17, 109);
            this.judgesDataGridView.Name = "judgesDataGridView";
            this.judgesDataGridView.Size = new System.Drawing.Size(178, 258);
            this.judgesDataGridView.TabIndex = 2;
            // 
            // judgesLabel
            // 
            this.judgesLabel.AutoSize = true;
            this.judgesLabel.Location = new System.Drawing.Point(15, 93);
            this.judgesLabel.Name = "judgesLabel";
            this.judgesLabel.Size = new System.Drawing.Size(41, 13);
            this.judgesLabel.TabIndex = 3;
            this.judgesLabel.Text = "Judges";
            // 
            // contestLabel
            // 
            this.contestLabel.AutoSize = true;
            this.contestLabel.Location = new System.Drawing.Point(15, 13);
            this.contestLabel.Name = "contestLabel";
            this.contestLabel.Size = new System.Drawing.Size(49, 13);
            this.contestLabel.TabIndex = 4;
            this.contestLabel.Text = "Contest: ";
            // 
            // contestNameLabel
            // 
            this.contestNameLabel.AutoSize = true;
            this.contestNameLabel.Location = new System.Drawing.Point(70, 13);
            this.contestNameLabel.Name = "contestNameLabel";
            this.contestNameLabel.Size = new System.Drawing.Size(70, 13);
            this.contestNameLabel.TabIndex = 5;
            this.contestNameLabel.Text = "contestName";
            // 
            // startDateLabel
            // 
            this.startDateLabel.AutoSize = true;
            this.startDateLabel.Location = new System.Drawing.Point(14, 67);
            this.startDateLabel.Name = "startDateLabel";
            this.startDateLabel.Size = new System.Drawing.Size(65, 13);
            this.startDateLabel.TabIndex = 6;
            this.startDateLabel.Text = "01/01/1111";
            // 
            // betweenDateLabel
            // 
            this.betweenDateLabel.AutoSize = true;
            this.betweenDateLabel.Location = new System.Drawing.Point(85, 67);
            this.betweenDateLabel.Name = "betweenDateLabel";
            this.betweenDateLabel.Size = new System.Drawing.Size(16, 13);
            this.betweenDateLabel.TabIndex = 7;
            this.betweenDateLabel.Text = " - ";
            // 
            // endDateLabel
            // 
            this.endDateLabel.AutoSize = true;
            this.endDateLabel.Location = new System.Drawing.Point(107, 67);
            this.endDateLabel.Name = "endDateLabel";
            this.endDateLabel.Size = new System.Drawing.Size(65, 13);
            this.endDateLabel.TabIndex = 8;
            this.endDateLabel.Text = "01/01/1111";
            // 
            // placeLabel
            // 
            this.placeLabel.AutoSize = true;
            this.placeLabel.Location = new System.Drawing.Point(15, 37);
            this.placeLabel.Name = "placeLabel";
            this.placeLabel.Size = new System.Drawing.Size(40, 13);
            this.placeLabel.TabIndex = 9;
            this.placeLabel.Text = "Place: ";
            // 
            // placeNameLabel
            // 
            this.placeNameLabel.AutoSize = true;
            this.placeNameLabel.Location = new System.Drawing.Point(73, 36);
            this.placeNameLabel.Name = "placeNameLabel";
            this.placeNameLabel.Size = new System.Drawing.Size(61, 13);
            this.placeNameLabel.TabIndex = 10;
            this.placeNameLabel.Text = "placeName";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(430, 373);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 11;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // ContestResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 403);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.placeNameLabel);
            this.Controls.Add(this.placeLabel);
            this.Controls.Add(this.endDateLabel);
            this.Controls.Add(this.betweenDateLabel);
            this.Controls.Add(this.startDateLabel);
            this.Controls.Add(this.contestNameLabel);
            this.Controls.Add(this.contestLabel);
            this.Controls.Add(this.judgesLabel);
            this.Controls.Add(this.judgesDataGridView);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.resultDataGridView);
            this.Name = "ContestResult";
            this.Text = "ContestResult";
            this.Load += new System.EventHandler(this.ContestResult_Load);
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.judgesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView resultDataGridView;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.DataGridView judgesDataGridView;
        private System.Windows.Forms.Label judgesLabel;
        private System.Windows.Forms.Label contestLabel;
        private System.Windows.Forms.Label contestNameLabel;
        private System.Windows.Forms.Label startDateLabel;
        private System.Windows.Forms.Label betweenDateLabel;
        private System.Windows.Forms.Label endDateLabel;
        private System.Windows.Forms.Label placeLabel;
        private System.Windows.Forms.Label placeNameLabel;
        private System.Windows.Forms.Button closeButton;
    }
}