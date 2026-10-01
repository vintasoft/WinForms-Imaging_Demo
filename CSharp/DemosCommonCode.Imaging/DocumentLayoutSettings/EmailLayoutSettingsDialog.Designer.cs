namespace CommonCode.Imaging
{
    partial class EmailLayoutSettingsDialog
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
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.settingsGroupBox = new System.Windows.Forms.GroupBox();
            this.createUnknownHeadersCheckBox = new System.Windows.Forms.CheckBox();
            this.createAttachmentsCheckBox = new System.Windows.Forms.CheckBox();
            this.xLabel = new System.Windows.Forms.Label();
            this.createHeaderCheckBox = new System.Windows.Forms.CheckBox();
            this.mmLabel = new System.Windows.Forms.Label();
            this.pageWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.pageHeightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.pageSizeComboBox = new System.Windows.Forms.ComboBox();
            this.pageSizeLabel = new System.Windows.Forms.Label();
            this.defaultSettingsCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.settingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pageWidthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageHeightNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(233, 177);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 6;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(152, 177);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // settingsGroupBox
            // 
            this.settingsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsGroupBox.Controls.Add(this.label1);
            this.settingsGroupBox.Controls.Add(this.createUnknownHeadersCheckBox);
            this.settingsGroupBox.Controls.Add(this.createAttachmentsCheckBox);
            this.settingsGroupBox.Controls.Add(this.xLabel);
            this.settingsGroupBox.Controls.Add(this.createHeaderCheckBox);
            this.settingsGroupBox.Controls.Add(this.mmLabel);
            this.settingsGroupBox.Controls.Add(this.pageWidthNumericUpDown);
            this.settingsGroupBox.Controls.Add(this.pageHeightNumericUpDown);
            this.settingsGroupBox.Controls.Add(this.pageSizeComboBox);
            this.settingsGroupBox.Controls.Add(this.pageSizeLabel);
            this.settingsGroupBox.Enabled = false;
            this.settingsGroupBox.Location = new System.Drawing.Point(12, 12);
            this.settingsGroupBox.Name = "settingsGroupBox";
            this.settingsGroupBox.Size = new System.Drawing.Size(296, 159);
            this.settingsGroupBox.TabIndex = 7;
            this.settingsGroupBox.TabStop = false;
            // 
            // createUnknownHeadersCheckBox
            // 
            this.createUnknownHeadersCheckBox.AutoSize = true;
            this.createUnknownHeadersCheckBox.Checked = true;
            this.createUnknownHeadersCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.createUnknownHeadersCheckBox.Location = new System.Drawing.Point(27, 128);
            this.createUnknownHeadersCheckBox.Name = "createUnknownHeadersCheckBox";
            this.createUnknownHeadersCheckBox.Size = new System.Drawing.Size(145, 17);
            this.createUnknownHeadersCheckBox.TabIndex = 9;
            this.createUnknownHeadersCheckBox.Text = "Create unknown headers";
            this.createUnknownHeadersCheckBox.UseVisualStyleBackColor = true;
            // 
            // createAttachmentsCheckBox
            // 
            this.createAttachmentsCheckBox.AutoSize = true;
            this.createAttachmentsCheckBox.Checked = true;
            this.createAttachmentsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.createAttachmentsCheckBox.Location = new System.Drawing.Point(27, 105);
            this.createAttachmentsCheckBox.Name = "createAttachmentsCheckBox";
            this.createAttachmentsCheckBox.Size = new System.Drawing.Size(118, 17);
            this.createAttachmentsCheckBox.TabIndex = 11;
            this.createAttachmentsCheckBox.Text = "Create attachments";
            this.createAttachmentsCheckBox.UseVisualStyleBackColor = true;
            // 
            // xLabel
            // 
            this.xLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(174, 54);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(12, 13);
            this.xLabel.TabIndex = 15;
            this.xLabel.Text = "x";
            // 
            // createHeaderCheckBox
            // 
            this.createHeaderCheckBox.AutoSize = true;
            this.createHeaderCheckBox.Checked = true;
            this.createHeaderCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.createHeaderCheckBox.Location = new System.Drawing.Point(10, 82);
            this.createHeaderCheckBox.Name = "createHeaderCheckBox";
            this.createHeaderCheckBox.Size = new System.Drawing.Size(93, 17);
            this.createHeaderCheckBox.TabIndex = 10;
            this.createHeaderCheckBox.Text = "Create header";
            this.createHeaderCheckBox.UseVisualStyleBackColor = true;
            // 
            // mmLabel
            // 
            this.mmLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mmLabel.AutoSize = true;
            this.mmLabel.Location = new System.Drawing.Point(264, 56);
            this.mmLabel.Name = "mmLabel";
            this.mmLabel.Size = new System.Drawing.Size(29, 13);
            this.mmLabel.TabIndex = 14;
            this.mmLabel.Text = "(mm)";
            // 
            // pageWidthNumericUpDown
            // 
            this.pageWidthNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pageWidthNumericUpDown.Enabled = false;
            this.pageWidthNumericUpDown.Location = new System.Drawing.Point(101, 49);
            this.pageWidthNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.pageWidthNumericUpDown.Name = "pageWidthNumericUpDown";
            this.pageWidthNumericUpDown.Size = new System.Drawing.Size(66, 20);
            this.pageWidthNumericUpDown.TabIndex = 12;
            this.pageWidthNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.pageWidthNumericUpDown.ValueChanged += new System.EventHandler(this.pageSizeNumericUpDown_ValueChanged);
            // 
            // pageHeightNumericUpDown
            // 
            this.pageHeightNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pageHeightNumericUpDown.Enabled = false;
            this.pageHeightNumericUpDown.Location = new System.Drawing.Point(189, 49);
            this.pageHeightNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.pageHeightNumericUpDown.Name = "pageHeightNumericUpDown";
            this.pageHeightNumericUpDown.Size = new System.Drawing.Size(66, 20);
            this.pageHeightNumericUpDown.TabIndex = 13;
            this.pageHeightNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.pageHeightNumericUpDown.ValueChanged += new System.EventHandler(this.pageSizeNumericUpDown_ValueChanged);
            // 
            // pageSizeComboBox
            // 
            this.pageSizeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pageSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pageSizeComboBox.FormattingEnabled = true;
            this.pageSizeComboBox.Location = new System.Drawing.Point(101, 22);
            this.pageSizeComboBox.Name = "pageSizeComboBox";
            this.pageSizeComboBox.Size = new System.Drawing.Size(189, 21);
            this.pageSizeComboBox.TabIndex = 11;
            this.pageSizeComboBox.SelectedIndexChanged += new System.EventHandler(this.pageSizeComboBox_SelectedIndexChanged);
            // 
            // pageSizeLabel
            // 
            this.pageSizeLabel.AutoSize = true;
            this.pageSizeLabel.Location = new System.Drawing.Point(7, 23);
            this.pageSizeLabel.Name = "pageSizeLabel";
            this.pageSizeLabel.Size = new System.Drawing.Size(55, 13);
            this.pageSizeLabel.TabIndex = 10;
            this.pageSizeLabel.Text = "Page Size";
            // 
            // defaultSettingsCheckBox
            // 
            this.defaultSettingsCheckBox.AutoSize = true;
            this.defaultSettingsCheckBox.Checked = true;
            this.defaultSettingsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.defaultSettingsCheckBox.Location = new System.Drawing.Point(20, 11);
            this.defaultSettingsCheckBox.Name = "defaultSettingsCheckBox";
            this.defaultSettingsCheckBox.Size = new System.Drawing.Size(150, 17);
            this.defaultSettingsCheckBox.TabIndex = 8;
            this.defaultSettingsCheckBox.Text = "Use default layout settings";
            this.defaultSettingsCheckBox.UseVisualStyleBackColor = true;
            this.defaultSettingsCheckBox.CheckedChanged += new System.EventHandler(this.defaultSettingsCheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "0-Auto";
            // 
            // EmailLayoutSettingsDialog
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(320, 212);
            this.Controls.Add(this.defaultSettingsCheckBox);
            this.Controls.Add(this.settingsGroupBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EmailLayoutSettingsDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Email Layout Settings";
            this.settingsGroupBox.ResumeLayout(false);
            this.settingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pageWidthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageHeightNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.GroupBox settingsGroupBox;
        private System.Windows.Forms.CheckBox defaultSettingsCheckBox;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.Label mmLabel;
        private System.Windows.Forms.NumericUpDown pageWidthNumericUpDown;
        private System.Windows.Forms.NumericUpDown pageHeightNumericUpDown;
        private System.Windows.Forms.ComboBox pageSizeComboBox;
        private System.Windows.Forms.Label pageSizeLabel;
        private System.Windows.Forms.CheckBox createUnknownHeadersCheckBox;
        private System.Windows.Forms.CheckBox createAttachmentsCheckBox;
        private System.Windows.Forms.CheckBox createHeaderCheckBox;
        private System.Windows.Forms.Label label1;
    }
}