namespace DemosCommonCode.Imaging
{
    partial class AddDicomDataElementForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupNumberNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.valueRepresentationComboBox = new System.Windows.Forms.ComboBox();
            this.valueLabel = new System.Windows.Forms.Label();
            this.valueTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.valueTimePicker = new System.Windows.Forms.DateTimePicker();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton1 = new System.Windows.Forms.Button();
            this.valueDatePicker = new System.Windows.Forms.DateTimePicker();
            this.elementNumberNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.valueAgeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.valueAgeComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.groupNumberNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elementNumberNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueAgeNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Group Number";
            // 
            // groupNumberNumericUpDown
            // 
            this.groupNumberNumericUpDown.Location = new System.Drawing.Point(94, 7);
            this.groupNumberNumericUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.groupNumberNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.groupNumberNumericUpDown.Name = "groupNumberNumericUpDown";
            this.groupNumberNumericUpDown.Size = new System.Drawing.Size(52, 20);
            this.groupNumberNumericUpDown.TabIndex = 1;
            this.groupNumberNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Element Number";
            // 
            // valueRepresentationComboBox
            // 
            this.valueRepresentationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.valueRepresentationComboBox.FormattingEnabled = true;
            this.valueRepresentationComboBox.Location = new System.Drawing.Point(248, 33);
            this.valueRepresentationComboBox.Name = "valueRepresentationComboBox";
            this.valueRepresentationComboBox.Size = new System.Drawing.Size(47, 21);
            this.valueRepresentationComboBox.Sorted = true;
            this.valueRepresentationComboBox.TabIndex = 4;
            this.valueRepresentationComboBox.SelectedIndexChanged += new System.EventHandler(this.valueRepresentationComboBox_SelectedIndexChanged);
            // 
            // valueLabel
            // 
            this.valueLabel.AutoSize = true;
            this.valueLabel.Location = new System.Drawing.Point(12, 63);
            this.valueLabel.Name = "valueLabel";
            this.valueLabel.Size = new System.Drawing.Size(34, 13);
            this.valueLabel.TabIndex = 5;
            this.valueLabel.Text = "Value";
            // 
            // valueTextBox
            // 
            this.valueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.valueTextBox.Location = new System.Drawing.Point(15, 87);
            this.valueTextBox.Multiline = true;
            this.valueTextBox.Name = "valueTextBox";
            this.valueTextBox.ShortcutsEnabled = false;
            this.valueTextBox.Size = new System.Drawing.Size(280, 94);
            this.valueTextBox.TabIndex = 6;
            this.valueTextBox.Visible = false;
            this.valueTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.valueTextBox_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(133, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Value Representation";
            // 
            // valueTimePicker
            // 
            this.valueTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.valueTimePicker.Location = new System.Drawing.Point(219, 61);
            this.valueTimePicker.Name = "valueTimePicker";
            this.valueTimePicker.ShowUpDown = true;
            this.valueTimePicker.Size = new System.Drawing.Size(76, 20);
            this.valueTimePicker.TabIndex = 9;
            this.valueTimePicker.Visible = false;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(74, 187);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 10;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton1
            // 
            this.cancelButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton1.Location = new System.Drawing.Point(155, 187);
            this.cancelButton1.Name = "cancelButton1";
            this.cancelButton1.Size = new System.Drawing.Size(75, 23);
            this.cancelButton1.TabIndex = 11;
            this.cancelButton1.Text = "Cancel";
            this.cancelButton1.UseVisualStyleBackColor = true;
            // 
            // valueDatePicker
            // 
            this.valueDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.valueDatePicker.Location = new System.Drawing.Point(52, 61);
            this.valueDatePicker.Name = "valueDatePicker";
            this.valueDatePicker.Size = new System.Drawing.Size(161, 20);
            this.valueDatePicker.TabIndex = 12;
            this.valueDatePicker.Visible = false;
            // 
            // elementNumberNumericUpDown
            // 
            this.elementNumberNumericUpDown.Location = new System.Drawing.Point(243, 7);
            this.elementNumberNumericUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.elementNumberNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.elementNumberNumericUpDown.Name = "elementNumberNumericUpDown";
            this.elementNumberNumericUpDown.Size = new System.Drawing.Size(52, 20);
            this.elementNumberNumericUpDown.TabIndex = 3;
            this.elementNumberNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // valueAgeNumericUpDown
            // 
            this.valueAgeNumericUpDown.Location = new System.Drawing.Point(52, 61);
            this.valueAgeNumericUpDown.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.valueAgeNumericUpDown.Name = "valueAgeNumericUpDown";
            this.valueAgeNumericUpDown.Size = new System.Drawing.Size(152, 20);
            this.valueAgeNumericUpDown.TabIndex = 13;
            this.valueAgeNumericUpDown.Visible = false;
            // 
            // valueAgeComboBox
            // 
            this.valueAgeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.valueAgeComboBox.FormattingEnabled = true;
            this.valueAgeComboBox.Items.AddRange(new object[] {
            "Day",
            "Week",
            "Month",
            "Year"});
            this.valueAgeComboBox.Location = new System.Drawing.Point(210, 61);
            this.valueAgeComboBox.Name = "valueAgeComboBox";
            this.valueAgeComboBox.Size = new System.Drawing.Size(85, 21);
            this.valueAgeComboBox.TabIndex = 14;
            // 
            // AddDicomDataElementForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.cancelButton1;
            this.ClientSize = new System.Drawing.Size(304, 221);
            this.Controls.Add(this.valueAgeComboBox);
            this.Controls.Add(this.valueAgeNumericUpDown);
            this.Controls.Add(this.valueDatePicker);
            this.Controls.Add(this.cancelButton1);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.valueTimePicker);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.valueTextBox);
            this.Controls.Add(this.valueLabel);
            this.Controls.Add(this.valueRepresentationComboBox);
            this.Controls.Add(this.elementNumberNumericUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupNumberNumericUpDown);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(320, 65535);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(320, 190);
            this.Name = "AddDicomDataElementForm";
            this.Text = "Add Dicom Data Element";
            ((System.ComponentModel.ISupportInitialize)(this.groupNumberNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elementNumberNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueAgeNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown groupNumberNumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox valueRepresentationComboBox;
        private System.Windows.Forms.Label valueLabel;
        private System.Windows.Forms.TextBox valueTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker valueTimePicker;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton1;
        private System.Windows.Forms.DateTimePicker valueDatePicker;
        private System.Windows.Forms.NumericUpDown elementNumberNumericUpDown;
        private System.Windows.Forms.NumericUpDown valueAgeNumericUpDown;
        private System.Windows.Forms.ComboBox valueAgeComboBox;
    }
}
