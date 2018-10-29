namespace ImagingDemo
{
	partial class ResizeForm
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
            this.okButton = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.widthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.heightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.constrainProportionsCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.interpolationModeComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.widthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // labelText1
            // 
            this.labelText1.Location = new System.Drawing.Point(34, 20);
            this.labelText1.Name = "labelText1";
            this.labelText1.Size = new System.Drawing.Size(57, 23);
            this.labelText1.TabIndex = 0;
            this.labelText1.Text = "Width:";
            this.labelText1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelText2
            // 
            this.labelText2.Location = new System.Drawing.Point(37, 47);
            this.labelText2.Name = "labelText2";
            this.labelText2.Size = new System.Drawing.Size(51, 20);
            this.labelText2.TabIndex = 2;
            this.labelText2.Text = "Height:";
            this.labelText2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.okButton.Location = new System.Drawing.Point(43, 128);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.btOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(124, 128);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // widthNumericUpDown
            // 
            this.widthNumericUpDown.Location = new System.Drawing.Point(106, 22);
            this.widthNumericUpDown.Maximum = new decimal(new int[] {
            128000,
            0,
            0,
            0});
            this.widthNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.widthNumericUpDown.Name = "widthNumericUpDown";
            this.widthNumericUpDown.Size = new System.Drawing.Size(103, 20);
            this.widthNumericUpDown.TabIndex = 6;
            this.widthNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.widthNumericUpDown.ValueChanged += new System.EventHandler(this.nWidth_ValueChanged);
            this.widthNumericUpDown.Leave += new System.EventHandler(this.nWidth_ValueChanged);
            // 
            // heightNumericUpDown
            // 
            this.heightNumericUpDown.Location = new System.Drawing.Point(106, 49);
            this.heightNumericUpDown.Maximum = new decimal(new int[] {
            128000,
            0,
            0,
            0});
            this.heightNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.heightNumericUpDown.Name = "heightNumericUpDown";
            this.heightNumericUpDown.Size = new System.Drawing.Size(103, 20);
            this.heightNumericUpDown.TabIndex = 7;
            this.heightNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.heightNumericUpDown.ValueChanged += new System.EventHandler(this.nHeight_ValueChanged);
            this.heightNumericUpDown.Leave += new System.EventHandler(this.nHeight_ValueChanged);
            // 
            // constrainProportionsCheckBox
            // 
            this.constrainProportionsCheckBox.AutoSize = true;
            this.constrainProportionsCheckBox.Checked = true;
            this.constrainProportionsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.constrainProportionsCheckBox.Location = new System.Drawing.Point(59, 79);
            this.constrainProportionsCheckBox.Name = "constrainProportionsCheckBox";
            this.constrainProportionsCheckBox.Size = new System.Drawing.Size(125, 17);
            this.constrainProportionsCheckBox.TabIndex = 8;
            this.constrainProportionsCheckBox.Text = "Constrain proportions";
            this.constrainProportionsCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Interpolation";
            // 
            // interpolationModeComboBox
            // 
            this.interpolationModeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.interpolationModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.interpolationModeComboBox.FormattingEnabled = true;
            this.interpolationModeComboBox.Location = new System.Drawing.Point(79, 101);
            this.interpolationModeComboBox.Name = "interpolationModeComboBox";
            this.interpolationModeComboBox.Size = new System.Drawing.Size(155, 21);
            this.interpolationModeComboBox.TabIndex = 10;
            // 
            // ResizeForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(243, 158);
            this.Controls.Add(this.interpolationModeComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.constrainProportionsCheckBox);
            this.Controls.Add(this.heightNumericUpDown);
            this.Controls.Add(this.widthNumericUpDown);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.labelText2);
            this.Controls.Add(this.labelText1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResizeForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Resize";
            ((System.ComponentModel.ISupportInitialize)(this.widthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelText1;
		private System.Windows.Forms.Label labelText2;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.NumericUpDown widthNumericUpDown;
		private System.Windows.Forms.NumericUpDown heightNumericUpDown;
		private System.Windows.Forms.CheckBox constrainProportionsCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox interpolationModeComboBox;
	}
}