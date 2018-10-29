namespace ImagingDemo
{
	partial class GetHistogramForm
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
            this.histogramImagePictureBox = new System.Windows.Forms.PictureBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.levelLabel = new System.Windows.Forms.Label();
            this.countLabel = new System.Windows.Forms.Label();
            this.percentageLabel = new System.Windows.Forms.Label();
            this.pixelCountLabel = new System.Windows.Forms.Label();
            this.histogramTypeComboBox = new System.Windows.Forms.ComboBox();
            this.histogramTypeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.histogramImagePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // histogramImagePictureBox
            // 
            this.histogramImagePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.histogramImagePictureBox.Location = new System.Drawing.Point(12, 33);
            this.histogramImagePictureBox.Name = "histogramImagePictureBox";
            this.histogramImagePictureBox.Size = new System.Drawing.Size(602, 302);
            this.histogramImagePictureBox.TabIndex = 0;
            this.histogramImagePictureBox.TabStop = false;
            this.histogramImagePictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.histogramImage_MouseMove);
            // 
            // closeButton
            // 
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(483, 341);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(131, 45);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.bOk_Click);
            // 
            // levelLabel
            // 
            this.levelLabel.AutoSize = true;
            this.levelLabel.Location = new System.Drawing.Point(176, 341);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(36, 13);
            this.levelLabel.TabIndex = 2;
            this.levelLabel.Text = "Level:";
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.Location = new System.Drawing.Point(176, 357);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(38, 13);
            this.countLabel.TabIndex = 3;
            this.countLabel.Text = "Count:";
            // 
            // percentageLabel
            // 
            this.percentageLabel.AutoSize = true;
            this.percentageLabel.Location = new System.Drawing.Point(176, 373);
            this.percentageLabel.Name = "percentageLabel";
            this.percentageLabel.Size = new System.Drawing.Size(65, 13);
            this.percentageLabel.TabIndex = 4;
            this.percentageLabel.Text = "Percentage:";
            // 
            // pixelsLabel
            // 
            this.pixelCountLabel.AutoSize = true;
            this.pixelCountLabel.Location = new System.Drawing.Point(9, 341);
            this.pixelCountLabel.Name = "pixelsLabel";
            this.pixelCountLabel.Size = new System.Drawing.Size(37, 13);
            this.pixelCountLabel.TabIndex = 5;
            this.pixelCountLabel.Text = "Pixels:";
            // 
            // histogramTypeComboBox
            // 
            this.histogramTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.histogramTypeComboBox.FormattingEnabled = true;
            this.histogramTypeComboBox.Items.AddRange(new object[] {
            "Luminosity",
            "Red",
            "Green",
            "Blue"});
            this.histogramTypeComboBox.Location = new System.Drawing.Point(95, 5);
            this.histogramTypeComboBox.Name = "histogramTypeComboBox";
            this.histogramTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.histogramTypeComboBox.TabIndex = 6;
            this.histogramTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.cbHistogramType_SelectedIndexChanged);
            // 
            // histogramTypeLabel
            // 
            this.histogramTypeLabel.AutoSize = true;
            this.histogramTypeLabel.Location = new System.Drawing.Point(9, 8);
            this.histogramTypeLabel.Name = "histogramTypeLabel";
            this.histogramTypeLabel.Size = new System.Drawing.Size(80, 13);
            this.histogramTypeLabel.TabIndex = 7;
            this.histogramTypeLabel.Text = "Histogram type:";
            // 
            // HistogramForm
            // 
            this.AcceptButton = this.closeButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(627, 392);
            this.Controls.Add(this.histogramTypeLabel);
            this.Controls.Add(this.histogramTypeComboBox);
            this.Controls.Add(this.pixelCountLabel);
            this.Controls.Add(this.percentageLabel);
            this.Controls.Add(this.countLabel);
            this.Controls.Add(this.levelLabel);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.histogramImagePictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HistogramForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Histogram";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HistogramDialog_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.histogramImagePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox histogramImagePictureBox;
		private System.Windows.Forms.Button closeButton;
		private System.Windows.Forms.Label levelLabel;
		private System.Windows.Forms.Label countLabel;
		private System.Windows.Forms.Label percentageLabel;
		private System.Windows.Forms.Label pixelCountLabel;
		private System.Windows.Forms.ComboBox histogramTypeComboBox;
		private System.Windows.Forms.Label histogramTypeLabel;
	}
}