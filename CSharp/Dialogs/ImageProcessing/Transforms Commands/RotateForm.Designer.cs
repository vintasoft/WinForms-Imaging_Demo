namespace ImagingDemo
{
	partial class RotateForm
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
            this.okButton = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.angleNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.blackRadioButton = new System.Windows.Forms.RadioButton();
            this.whiteRadioButton = new System.Windows.Forms.RadioButton();
            this.autoDetectRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.transparentRadioButton = new System.Windows.Forms.RadioButton();
            this.isAntialiasingEnabledCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.angleNumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(35, 146);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(116, 146);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // angleNumericUpDown
            // 
            this.angleNumericUpDown.Location = new System.Drawing.Point(87, 12);
            this.angleNumericUpDown.Maximum = new decimal(new int[] {
            359,
            0,
            0,
            0});
            this.angleNumericUpDown.Minimum = new decimal(new int[] {
            359,
            0,
            0,
            -2147483648});
            this.angleNumericUpDown.Name = "angleNumericUpDown";
            this.angleNumericUpDown.Size = new System.Drawing.Size(84, 20);
            this.angleNumericUpDown.TabIndex = 0;
            this.angleNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Angle:";
            // 
            // blackRadioButton
            // 
            this.blackRadioButton.AutoSize = true;
            this.blackRadioButton.Location = new System.Drawing.Point(17, 19);
            this.blackRadioButton.Name = "blackRadioButton";
            this.blackRadioButton.Size = new System.Drawing.Size(52, 17);
            this.blackRadioButton.TabIndex = 4;
            this.blackRadioButton.Text = "Black";
            this.blackRadioButton.UseVisualStyleBackColor = true;
            // 
            // whiteRadioButton
            // 
            this.whiteRadioButton.AutoSize = true;
            this.whiteRadioButton.Checked = true;
            this.whiteRadioButton.Location = new System.Drawing.Point(110, 19);
            this.whiteRadioButton.Name = "whiteRadioButton";
            this.whiteRadioButton.Size = new System.Drawing.Size(53, 17);
            this.whiteRadioButton.TabIndex = 5;
            this.whiteRadioButton.TabStop = true;
            this.whiteRadioButton.Text = "White";
            this.whiteRadioButton.UseVisualStyleBackColor = true;
            // 
            // autoDetectRadioButton
            // 
            this.autoDetectRadioButton.AutoSize = true;
            this.autoDetectRadioButton.Location = new System.Drawing.Point(110, 42);
            this.autoDetectRadioButton.Name = "autoDetectRadioButton";
            this.autoDetectRadioButton.Size = new System.Drawing.Size(80, 17);
            this.autoDetectRadioButton.TabIndex = 6;
            this.autoDetectRadioButton.Text = "Auto detect";
            this.autoDetectRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.transparentRadioButton);
            this.groupBox1.Controls.Add(this.blackRadioButton);
            this.groupBox1.Controls.Add(this.autoDetectRadioButton);
            this.groupBox1.Controls.Add(this.whiteRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(198, 69);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Background color";
            // 
            // transparentRadioButton
            // 
            this.transparentRadioButton.AutoSize = true;
            this.transparentRadioButton.Location = new System.Drawing.Point(16, 42);
            this.transparentRadioButton.Name = "transparentRadioButton";
            this.transparentRadioButton.Size = new System.Drawing.Size(82, 17);
            this.transparentRadioButton.TabIndex = 7;
            this.transparentRadioButton.Text = "Transparent";
            this.transparentRadioButton.UseVisualStyleBackColor = true;
            // 
            // isAntialiasingEnabledCheckBox
            // 
            this.isAntialiasingEnabledCheckBox.AutoSize = true;
            this.isAntialiasingEnabledCheckBox.Checked = true;
            this.isAntialiasingEnabledCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isAntialiasingEnabledCheckBox.Location = new System.Drawing.Point(65, 113);
            this.isAntialiasingEnabledCheckBox.Name = "isAntialiasingEnabledCheckBox";
            this.isAntialiasingEnabledCheckBox.Size = new System.Drawing.Size(101, 17);
            this.isAntialiasingEnabledCheckBox.TabIndex = 8;
            this.isAntialiasingEnabledCheckBox.Text = "Use Antialiasing";
            this.isAntialiasingEnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // RotateForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(220, 181);
            this.Controls.Add(this.isAntialiasingEnabledCheckBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.angleNumericUpDown);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "RotateForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rotation";
            ((System.ComponentModel.ISupportInitialize)(this.angleNumericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown angleNumericUpDown;
		private System.Windows.Forms.RadioButton blackRadioButton;
		private System.Windows.Forms.RadioButton whiteRadioButton;
		private System.Windows.Forms.RadioButton autoDetectRadioButton;
		private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton transparentRadioButton;
        private System.Windows.Forms.CheckBox isAntialiasingEnabledCheckBox;
	}
}
