namespace ImagingDemo
{
    partial class ImageSharpeningForm
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
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.blendingModeComboBox = new System.Windows.Forms.ComboBox();
            this.blendingModeLabel = new System.Windows.Forms.Label();
            this.filterTypeComboBox = new System.Windows.Forms.ComboBox();
            this.filterTypeLabel = new System.Windows.Forms.Label();
            this.previewCheckBox = new System.Windows.Forms.CheckBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.grayscaleFiltrationCheckBox = new System.Windows.Forms.CheckBox();
            this.radiusEditorControl = new DemosCommonCode.CustomControls.ValueEditorControl();
            this.overlayAlphaEditorControl = new DemosCommonCode.CustomControls.ValueEditorControl();
            this.SuspendLayout();
            // 
            // blendingModeComboBox
            // 
            this.blendingModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.blendingModeComboBox.FormattingEnabled = true;
            this.blendingModeComboBox.Location = new System.Drawing.Point(109, 187);
            this.blendingModeComboBox.Name = "blendingModeComboBox";
            this.blendingModeComboBox.Size = new System.Drawing.Size(150, 21);
            this.blendingModeComboBox.TabIndex = 9;
            this.blendingModeComboBox.SelectedIndexChanged += new System.EventHandler(this.blendingModeComboBox_SelectedIndexChanged);
            // 
            // blendingModeLabel
            // 
            this.blendingModeLabel.AutoSize = true;
            this.blendingModeLabel.Location = new System.Drawing.Point(15, 190);
            this.blendingModeLabel.Name = "blendingModeLabel";
            this.blendingModeLabel.Size = new System.Drawing.Size(78, 13);
            this.blendingModeLabel.TabIndex = 8;
            this.blendingModeLabel.Text = "Blending Mode";
            // 
            // filterTypeComboBox
            // 
            this.filterTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterTypeComboBox.FormattingEnabled = true;
            this.filterTypeComboBox.Location = new System.Drawing.Point(109, 218);
            this.filterTypeComboBox.Name = "filterTypeComboBox";
            this.filterTypeComboBox.Size = new System.Drawing.Size(150, 21);
            this.filterTypeComboBox.TabIndex = 39;
            this.filterTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.filterTypeComboBox_SelectedIndexChanged);
            // 
            // filterTypeLabel
            // 
            this.filterTypeLabel.AutoSize = true;
            this.filterTypeLabel.Location = new System.Drawing.Point(15, 221);
            this.filterTypeLabel.Name = "filterTypeLabel";
            this.filterTypeLabel.Size = new System.Drawing.Size(56, 13);
            this.filterTypeLabel.TabIndex = 38;
            this.filterTypeLabel.Text = "Filter Type";
            // 
            // previewCheckBox
            // 
            this.previewCheckBox.AutoSize = true;
            this.previewCheckBox.ForeColor = System.Drawing.Color.Green;
            this.previewCheckBox.Location = new System.Drawing.Point(12, 291);
            this.previewCheckBox.Name = "previewCheckBox";
            this.previewCheckBox.Size = new System.Drawing.Size(143, 17);
            this.previewCheckBox.TabIndex = 42;
            this.previewCheckBox.Text = "Preview on ImageViewer";
            this.previewCheckBox.UseVisualStyleBackColor = true;
            this.previewCheckBox.CheckedChanged += new System.EventHandler(this.previewCheckBox_CheckedChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(268, 287);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 41;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(186, 287);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 40;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // grayscaleFiltrationCheckBox
            // 
            this.grayscaleFiltrationCheckBox.AutoSize = true;
            this.grayscaleFiltrationCheckBox.Checked = true;
            this.grayscaleFiltrationCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.grayscaleFiltrationCheckBox.Location = new System.Drawing.Point(12, 258);
            this.grayscaleFiltrationCheckBox.Name = "grayscaleFiltrationCheckBox";
            this.grayscaleFiltrationCheckBox.Size = new System.Drawing.Size(137, 17);
            this.grayscaleFiltrationCheckBox.TabIndex = 43;
            this.grayscaleFiltrationCheckBox.Text = "Use Grayscale Filtration";
            this.grayscaleFiltrationCheckBox.UseVisualStyleBackColor = true;
            this.grayscaleFiltrationCheckBox.CheckedChanged += new System.EventHandler(this.grayscaleFiltrationCheckBox_CheckedChanged);
            // 
            // radiusEditorControl
            // 
            this.radiusEditorControl.DecimalPlaces = 2;
            this.radiusEditorControl.DefaultValue = 12F;
            this.radiusEditorControl.Location = new System.Drawing.Point(12, 12);
            this.radiusEditorControl.MinValue = 1F;
            this.radiusEditorControl.Name = "radiusEditorControl";
            this.radiusEditorControl.Size = new System.Drawing.Size(335, 76);
            this.radiusEditorControl.Step = 2F;
            this.radiusEditorControl.TabIndex = 44;
            this.radiusEditorControl.Value = 12F;
            this.radiusEditorControl.ValueName = "Radius";
            this.radiusEditorControl.ValueUnitOfMeasure = "Pixels";
            this.radiusEditorControl.ValueChanged += new System.EventHandler(this.amountEditorControl_ValueChanged);
            // 
            // overlayAlphaEditorControl
            // 
            this.overlayAlphaEditorControl.DecimalPlaces = 2;
            this.overlayAlphaEditorControl.DefaultValue = 1F;
            this.overlayAlphaEditorControl.Location = new System.Drawing.Point(12, 94);
            this.overlayAlphaEditorControl.MaxValue = 1F;
            this.overlayAlphaEditorControl.Name = "overlayAlphaEditorControl";
            this.overlayAlphaEditorControl.Size = new System.Drawing.Size(335, 76);
            this.overlayAlphaEditorControl.Step = 0.01F;
            this.overlayAlphaEditorControl.TabIndex = 45;
            this.overlayAlphaEditorControl.Value = 1F;
            this.overlayAlphaEditorControl.ValueName = "Overlay Alpha";
            this.overlayAlphaEditorControl.ValueUnitOfMeasure = "";
            this.overlayAlphaEditorControl.ValueChanged += new System.EventHandler(this.amountEditorControl_ValueChanged);
            // 
            // ImageSharpeningForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 321);
            this.Controls.Add(this.overlayAlphaEditorControl);
            this.Controls.Add(this.radiusEditorControl);
            this.Controls.Add(this.grayscaleFiltrationCheckBox);
            this.Controls.Add(this.previewCheckBox);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.filterTypeComboBox);
            this.Controls.Add(this.filterTypeLabel);
            this.Controls.Add(this.blendingModeComboBox);
            this.Controls.Add(this.blendingModeLabel);
            this.Name = "ImageSharpeningForm";
            this.Text = "Image Sharpening";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox blendingModeComboBox;
        private System.Windows.Forms.Label blendingModeLabel;
        private System.Windows.Forms.ComboBox filterTypeComboBox;
        private System.Windows.Forms.Label filterTypeLabel;
        private System.Windows.Forms.CheckBox previewCheckBox;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.CheckBox grayscaleFiltrationCheckBox;
        private DemosCommonCode.CustomControls.ValueEditorControl radiusEditorControl;
        private DemosCommonCode.CustomControls.ValueEditorControl overlayAlphaEditorControl;
    }
}