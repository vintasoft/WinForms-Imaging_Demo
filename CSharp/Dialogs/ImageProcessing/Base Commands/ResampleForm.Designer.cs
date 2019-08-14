namespace ImagingDemo
{
	partial class ResampleForm
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
            this.labelText1 = new System.Windows.Forms.Label();
            this.labelText2 = new System.Windows.Forms.Label();
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.nHorizontalResolution = new System.Windows.Forms.NumericUpDown();
            this.nVerticalResolution = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.interpolationModeComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nHorizontalResolution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nVerticalResolution)).BeginInit();
            this.SuspendLayout();
            // 
            // labelText1
            // 
            this.labelText1.Location = new System.Drawing.Point(12, 20);
            this.labelText1.Name = "labelText1";
            this.labelText1.Size = new System.Drawing.Size(105, 23);
            this.labelText1.TabIndex = 0;
            this.labelText1.Text = "Horizontal resolution:";
            this.labelText1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelText2
            // 
            this.labelText2.Location = new System.Drawing.Point(12, 47);
            this.labelText2.Name = "labelText2";
            this.labelText2.Size = new System.Drawing.Size(93, 20);
            this.labelText2.TabIndex = 2;
            this.labelText2.Text = "Vertical resolution:";
            this.labelText2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btOk
            // 
            this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btOk.Location = new System.Drawing.Point(42, 105);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(75, 23);
            this.btOk.TabIndex = 4;
            this.btOk.Text = "OK";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(123, 105);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 5;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // nHorizontalResolution
            // 
            this.nHorizontalResolution.Location = new System.Drawing.Point(123, 22);
            this.nHorizontalResolution.Maximum = new decimal(new int[] {
            12800,
            0,
            0,
            0});
            this.nHorizontalResolution.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nHorizontalResolution.Name = "nHorizontalResolution";
            this.nHorizontalResolution.Size = new System.Drawing.Size(100, 20);
            this.nHorizontalResolution.TabIndex = 6;
            this.nHorizontalResolution.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nVerticalResolution
            // 
            this.nVerticalResolution.Location = new System.Drawing.Point(123, 49);
            this.nVerticalResolution.Maximum = new decimal(new int[] {
            12800,
            0,
            0,
            0});
            this.nVerticalResolution.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nVerticalResolution.Name = "nVerticalResolution";
            this.nVerticalResolution.Size = new System.Drawing.Size(100, 20);
            this.nVerticalResolution.TabIndex = 7;
            this.nVerticalResolution.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Interpolation";
            // 
            // interpolationModeComboBox
            // 
            this.interpolationModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.interpolationModeComboBox.FormattingEnabled = true;
            this.interpolationModeComboBox.Location = new System.Drawing.Point(76, 75);
            this.interpolationModeComboBox.Name = "interpolationModeComboBox";
            this.interpolationModeComboBox.Size = new System.Drawing.Size(155, 21);
            this.interpolationModeComboBox.TabIndex = 9;
            // 
            // ResampleForm
            // 
            this.AcceptButton = this.btOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(243, 141);
            this.Controls.Add(this.interpolationModeComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nVerticalResolution);
            this.Controls.Add(this.nHorizontalResolution);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.labelText2);
            this.Controls.Add(this.labelText1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResampleForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Resample";
            ((System.ComponentModel.ISupportInitialize)(this.nHorizontalResolution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nVerticalResolution)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelText1;
		private System.Windows.Forms.Label labelText2;
		private System.Windows.Forms.Button btOk;
		private System.Windows.Forms.Button btCancel;
		private System.Windows.Forms.NumericUpDown nHorizontalResolution;
		private System.Windows.Forms.NumericUpDown nVerticalResolution;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox interpolationModeComboBox;
	}
}