namespace DemosCommonCode.Imaging
{
	partial class AddTiffTagForm
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
            this.integerValueGroupBox = new System.Windows.Forms.GroupBox();
            this.integerValueNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.integerValueLabel = new System.Windows.Forms.Label();
            this.rationalValueDenominatorNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.okButton = new System.Windows.Forms.Button();
            this.rationalValueGroupBox = new System.Windows.Forms.GroupBox();
            this.rationalValueNumeratorNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.rationalValueDenominatorLabel = new System.Windows.Forms.Label();
            this.rationalValueNumeratorLabel = new System.Windows.Forms.Label();
            this.stringValueGroupBox = new System.Windows.Forms.GroupBox();
            this.stringValueTextBox = new System.Windows.Forms.TextBox();
            this.stringValueLabel = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tagDataTypeLabel = new System.Windows.Forms.Label();
            this.tagDataTypeComboBox = new System.Windows.Forms.ComboBox();
            this.tagIdLabel = new System.Windows.Forms.Label();
            this.tagIdNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.tagInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.doubleValueGroup = new System.Windows.Forms.GroupBox();
            this.doubleValueTextBox = new System.Windows.Forms.TextBox();
            this.doubleValueLabel = new System.Windows.Forms.Label();
            this.integerValueGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.integerValueNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rationalValueDenominatorNumericUpDown)).BeginInit();
            this.rationalValueGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rationalValueNumeratorNumericUpDown)).BeginInit();
            this.stringValueGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tagIdNumericUpDown)).BeginInit();
            this.tagInfoGroupBox.SuspendLayout();
            this.doubleValueGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // integerValueGroupBox
            // 
            this.integerValueGroupBox.Controls.Add(this.integerValueNumericUpDown);
            this.integerValueGroupBox.Controls.Add(this.integerValueLabel);
            this.integerValueGroupBox.Location = new System.Drawing.Point(9, 59);
            this.integerValueGroupBox.Name = "integerValueGroupBox";
            this.integerValueGroupBox.Size = new System.Drawing.Size(433, 55);
            this.integerValueGroupBox.TabIndex = 13;
            this.integerValueGroupBox.TabStop = false;
            this.integerValueGroupBox.Text = "New integer value";
            this.integerValueGroupBox.Visible = false;
            // 
            // integerValueNumericUpDown
            // 
            this.integerValueNumericUpDown.Location = new System.Drawing.Point(194, 23);
            this.integerValueNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.integerValueNumericUpDown.Name = "integerValueNumericUpDown";
            this.integerValueNumericUpDown.Size = new System.Drawing.Size(83, 20);
            this.integerValueNumericUpDown.TabIndex = 3;
            // 
            // integerValueLabel
            // 
            this.integerValueLabel.AutoSize = true;
            this.integerValueLabel.Location = new System.Drawing.Point(151, 25);
            this.integerValueLabel.Name = "integerValueLabel";
            this.integerValueLabel.Size = new System.Drawing.Size(37, 13);
            this.integerValueLabel.TabIndex = 2;
            this.integerValueLabel.Text = "Value:";
            // 
            // rationalValueDenominatorNumericUpDown
            // 
            this.rationalValueDenominatorNumericUpDown.Location = new System.Drawing.Point(297, 21);
            this.rationalValueDenominatorNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.rationalValueDenominatorNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.rationalValueDenominatorNumericUpDown.Name = "rationalValueDenominatorNumericUpDown";
            this.rationalValueDenominatorNumericUpDown.Size = new System.Drawing.Size(83, 20);
            this.rationalValueDenominatorNumericUpDown.TabIndex = 5;
            this.rationalValueDenominatorNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(145, 122);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 9;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // rationalValueGroupBox
            // 
            this.rationalValueGroupBox.Controls.Add(this.rationalValueDenominatorNumericUpDown);
            this.rationalValueGroupBox.Controls.Add(this.rationalValueNumeratorNumericUpDown);
            this.rationalValueGroupBox.Controls.Add(this.rationalValueDenominatorLabel);
            this.rationalValueGroupBox.Controls.Add(this.rationalValueNumeratorLabel);
            this.rationalValueGroupBox.Location = new System.Drawing.Point(9, 59);
            this.rationalValueGroupBox.Name = "rationalValueGroupBox";
            this.rationalValueGroupBox.Size = new System.Drawing.Size(433, 55);
            this.rationalValueGroupBox.TabIndex = 12;
            this.rationalValueGroupBox.TabStop = false;
            this.rationalValueGroupBox.Text = "New rational value";
            this.rationalValueGroupBox.Visible = false;
            // 
            // rationalValueNumeratorNumericUpDown
            // 
            this.rationalValueNumeratorNumericUpDown.Location = new System.Drawing.Point(113, 22);
            this.rationalValueNumeratorNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.rationalValueNumeratorNumericUpDown.Name = "rationalValueNumeratorNumericUpDown";
            this.rationalValueNumeratorNumericUpDown.Size = new System.Drawing.Size(83, 20);
            this.rationalValueNumeratorNumericUpDown.TabIndex = 3;
            this.rationalValueNumeratorNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rationalValueDenominatorLabel
            // 
            this.rationalValueDenominatorLabel.AutoSize = true;
            this.rationalValueDenominatorLabel.Location = new System.Drawing.Point(221, 24);
            this.rationalValueDenominatorLabel.Name = "rationalValueDenominatorLabel";
            this.rationalValueDenominatorLabel.Size = new System.Drawing.Size(70, 13);
            this.rationalValueDenominatorLabel.TabIndex = 4;
            this.rationalValueDenominatorLabel.Text = "Denominator:";
            // 
            // rationalValueNumeratorLabel
            // 
            this.rationalValueNumeratorLabel.AutoSize = true;
            this.rationalValueNumeratorLabel.Location = new System.Drawing.Point(48, 25);
            this.rationalValueNumeratorLabel.Name = "rationalValueNumeratorLabel";
            this.rationalValueNumeratorLabel.Size = new System.Drawing.Size(59, 13);
            this.rationalValueNumeratorLabel.TabIndex = 2;
            this.rationalValueNumeratorLabel.Text = "Numerator:";
            // 
            // stringValueGroupBox
            // 
            this.stringValueGroupBox.Controls.Add(this.stringValueTextBox);
            this.stringValueGroupBox.Controls.Add(this.stringValueLabel);
            this.stringValueGroupBox.Location = new System.Drawing.Point(9, 59);
            this.stringValueGroupBox.Name = "stringValueGroupBox";
            this.stringValueGroupBox.Size = new System.Drawing.Size(433, 55);
            this.stringValueGroupBox.TabIndex = 11;
            this.stringValueGroupBox.TabStop = false;
            this.stringValueGroupBox.Text = "New string value";
            // 
            // stringValueTextBox
            // 
            this.stringValueTextBox.Location = new System.Drawing.Point(65, 21);
            this.stringValueTextBox.Name = "stringValueTextBox";
            this.stringValueTextBox.Size = new System.Drawing.Size(344, 20);
            this.stringValueTextBox.TabIndex = 3;
            // 
            // stringValueLabel
            // 
            this.stringValueLabel.AutoSize = true;
            this.stringValueLabel.Location = new System.Drawing.Point(20, 24);
            this.stringValueLabel.Name = "stringValueLabel";
            this.stringValueLabel.Size = new System.Drawing.Size(37, 13);
            this.stringValueLabel.TabIndex = 2;
            this.stringValueLabel.Text = "Value:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(226, 122);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // tagDataTypeLabel
            // 
            this.tagDataTypeLabel.AutoSize = true;
            this.tagDataTypeLabel.Location = new System.Drawing.Point(204, 22);
            this.tagDataTypeLabel.Name = "tagDataTypeLabel";
            this.tagDataTypeLabel.Size = new System.Drawing.Size(56, 13);
            this.tagDataTypeLabel.TabIndex = 14;
            this.tagDataTypeLabel.Text = "Data type:";
            // 
            // tagDataTypeComboBox
            // 
            this.tagDataTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tagDataTypeComboBox.FormattingEnabled = true;
            this.tagDataTypeComboBox.Items.AddRange(new object[] {
            "String",
            "Int16",
            "UInt16",
            "Int32",
            "UInt32",
            "Float",
            "Double",
            "Rational",
            "SRational"});
            this.tagDataTypeComboBox.Location = new System.Drawing.Point(266, 19);
            this.tagDataTypeComboBox.Name = "tagDataTypeComboBox";
            this.tagDataTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.tagDataTypeComboBox.TabIndex = 15;
            this.tagDataTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.tagDataTypeComboBox_SelectedIndexChanged);
            // 
            // tagIdLabel
            // 
            this.tagIdLabel.AutoSize = true;
            this.tagIdLabel.Location = new System.Drawing.Point(46, 22);
            this.tagIdLabel.Name = "tagIdLabel";
            this.tagIdLabel.Size = new System.Drawing.Size(21, 13);
            this.tagIdLabel.TabIndex = 16;
            this.tagIdLabel.Text = "ID:";
            // 
            // tagIdNumericUpDown
            // 
            this.tagIdNumericUpDown.Location = new System.Drawing.Point(73, 19);
            this.tagIdNumericUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.tagIdNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tagIdNumericUpDown.Name = "tagIdNumericUpDown";
            this.tagIdNumericUpDown.Size = new System.Drawing.Size(79, 20);
            this.tagIdNumericUpDown.TabIndex = 17;
            this.tagIdNumericUpDown.Value = new decimal(new int[] {
            58000,
            0,
            0,
            0});
            this.tagIdNumericUpDown.ValueChanged += new System.EventHandler(this.tagIdNumericUpDown_ValueChanged);
            // 
            // tagInfoGroupBox
            // 
            this.tagInfoGroupBox.Controls.Add(this.tagDataTypeComboBox);
            this.tagInfoGroupBox.Controls.Add(this.tagIdNumericUpDown);
            this.tagInfoGroupBox.Controls.Add(this.tagDataTypeLabel);
            this.tagInfoGroupBox.Controls.Add(this.tagIdLabel);
            this.tagInfoGroupBox.Location = new System.Drawing.Point(8, 7);
            this.tagInfoGroupBox.Name = "tagInfoGroupBox";
            this.tagInfoGroupBox.Size = new System.Drawing.Size(433, 48);
            this.tagInfoGroupBox.TabIndex = 18;
            this.tagInfoGroupBox.TabStop = false;
            this.tagInfoGroupBox.Text = "Tag";
            // 
            // doubleValueGroup
            // 
            this.doubleValueGroup.Controls.Add(this.doubleValueTextBox);
            this.doubleValueGroup.Controls.Add(this.doubleValueLabel);
            this.doubleValueGroup.Location = new System.Drawing.Point(9, 59);
            this.doubleValueGroup.Name = "doubleValueGroup";
            this.doubleValueGroup.Size = new System.Drawing.Size(433, 55);
            this.doubleValueGroup.TabIndex = 19;
            this.doubleValueGroup.TabStop = false;
            this.doubleValueGroup.Text = "New double value";
            this.doubleValueGroup.Visible = false;
            // 
            // doubleValueTextBox
            // 
            this.doubleValueTextBox.Location = new System.Drawing.Point(163, 23);
            this.doubleValueTextBox.Name = "doubleValueTextBox";
            this.doubleValueTextBox.Size = new System.Drawing.Size(147, 20);
            this.doubleValueTextBox.TabIndex = 3;
            this.doubleValueTextBox.Text = "0,0";
            // 
            // doubleValueLabel
            // 
            this.doubleValueLabel.AutoSize = true;
            this.doubleValueLabel.Location = new System.Drawing.Point(123, 25);
            this.doubleValueLabel.Name = "doubleValueLabel";
            this.doubleValueLabel.Size = new System.Drawing.Size(37, 13);
            this.doubleValueLabel.TabIndex = 2;
            this.doubleValueLabel.Text = "Value:";
            // 
            // AddTiffTagForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 155);
            this.Controls.Add(this.tagInfoGroupBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.doubleValueGroup);
            this.Controls.Add(this.integerValueGroupBox);
            this.Controls.Add(this.rationalValueGroupBox);
            this.Controls.Add(this.stringValueGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddTiffTagForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Tag";
            this.integerValueGroupBox.ResumeLayout(false);
            this.integerValueGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.integerValueNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rationalValueDenominatorNumericUpDown)).EndInit();
            this.rationalValueGroupBox.ResumeLayout(false);
            this.rationalValueGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rationalValueNumeratorNumericUpDown)).EndInit();
            this.stringValueGroupBox.ResumeLayout(false);
            this.stringValueGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tagIdNumericUpDown)).EndInit();
            this.tagInfoGroupBox.ResumeLayout(false);
            this.tagInfoGroupBox.PerformLayout();
            this.doubleValueGroup.ResumeLayout(false);
            this.doubleValueGroup.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox integerValueGroupBox;
		private System.Windows.Forms.NumericUpDown integerValueNumericUpDown;
		private System.Windows.Forms.Label integerValueLabel;
		private System.Windows.Forms.NumericUpDown rationalValueDenominatorNumericUpDown;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.GroupBox rationalValueGroupBox;
		private System.Windows.Forms.NumericUpDown rationalValueNumeratorNumericUpDown;
		private System.Windows.Forms.Label rationalValueDenominatorLabel;
		private System.Windows.Forms.Label rationalValueNumeratorLabel;
		private System.Windows.Forms.GroupBox stringValueGroupBox;
		private System.Windows.Forms.TextBox stringValueTextBox;
		private System.Windows.Forms.Label stringValueLabel;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label tagDataTypeLabel;
		private System.Windows.Forms.ComboBox tagDataTypeComboBox;
		private System.Windows.Forms.Label tagIdLabel;
		private System.Windows.Forms.NumericUpDown tagIdNumericUpDown;
		private System.Windows.Forms.GroupBox tagInfoGroupBox;
		private System.Windows.Forms.GroupBox doubleValueGroup;
		private System.Windows.Forms.TextBox doubleValueTextBox;
		private System.Windows.Forms.Label doubleValueLabel;

	}
}