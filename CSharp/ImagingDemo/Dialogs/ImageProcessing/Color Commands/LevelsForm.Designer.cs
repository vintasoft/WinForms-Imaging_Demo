namespace ImagingDemo
{
    partial class LevelsForm
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
            this.sourceMinValueEditorControl = new DemosCommonCode.CustomControls.ValueEditorControl();
            this.sourceMaxValueEditorControl = new DemosCommonCode.CustomControls.ValueEditorControl();
            this.destinationMinValueEditorControl = new DemosCommonCode.CustomControls.ValueEditorControl();
            this.destinationMaxValueEditorControl = new DemosCommonCode.CustomControls.ValueEditorControl();
            this.gammaValueEditorControl = new DemosCommonCode.CustomControls.ValueEditorControl();
            this.redCheckBox = new System.Windows.Forms.CheckBox();
            this.greenCheckBox = new System.Windows.Forms.CheckBox();
            this.blueCheckBox = new System.Windows.Forms.CheckBox();
            this.previewCheckBox = new System.Windows.Forms.CheckBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sourceMinValueEditorControl
            // 
            this.sourceMinValueEditorControl.Location = new System.Drawing.Point(12, 12);
            this.sourceMinValueEditorControl.MaxValue = 255F;
            this.sourceMinValueEditorControl.Name = "sourceMinValueEditorControl";
            this.sourceMinValueEditorControl.Size = new System.Drawing.Size(267, 71);
            this.sourceMinValueEditorControl.TabIndex = 0;
            this.sourceMinValueEditorControl.ValueName = "Source Min";
            this.sourceMinValueEditorControl.ValueUnitOfMeasure = "";
            this.sourceMinValueEditorControl.ValueChanged += new System.EventHandler(this.amountEditorControl_ValueChanged);
            // 
            // sourceMaxValueEditorControl
            // 
            this.sourceMaxValueEditorControl.Location = new System.Drawing.Point(285, 12);
            this.sourceMaxValueEditorControl.MaxValue = 255F;
            this.sourceMaxValueEditorControl.Name = "sourceMaxValueEditorControl";
            this.sourceMaxValueEditorControl.Size = new System.Drawing.Size(267, 71);
            this.sourceMaxValueEditorControl.TabIndex = 1;
            this.sourceMaxValueEditorControl.ValueName = "Source Max";
            this.sourceMaxValueEditorControl.ValueUnitOfMeasure = "";
            this.sourceMaxValueEditorControl.ValueChanged += new System.EventHandler(this.amountEditorControl_ValueChanged);
            // 
            // destinationMinValueEditorControl
            // 
            this.destinationMinValueEditorControl.Location = new System.Drawing.Point(12, 89);
            this.destinationMinValueEditorControl.MaxValue = 255F;
            this.destinationMinValueEditorControl.Name = "destinationMinValueEditorControl";
            this.destinationMinValueEditorControl.Size = new System.Drawing.Size(267, 71);
            this.destinationMinValueEditorControl.TabIndex = 2;
            this.destinationMinValueEditorControl.ValueName = "Destination Min";
            this.destinationMinValueEditorControl.ValueUnitOfMeasure = "";
            this.destinationMinValueEditorControl.ValueChanged += new System.EventHandler(this.amountEditorControl_ValueChanged);
            // 
            // destinationMaxValueEditorControl
            // 
            this.destinationMaxValueEditorControl.Location = new System.Drawing.Point(285, 89);
            this.destinationMaxValueEditorControl.MaxValue = 255F;
            this.destinationMaxValueEditorControl.Name = "destinationMaxValueEditorControl";
            this.destinationMaxValueEditorControl.Size = new System.Drawing.Size(267, 71);
            this.destinationMaxValueEditorControl.TabIndex = 3;
            this.destinationMaxValueEditorControl.ValueName = "Destination Max";
            this.destinationMaxValueEditorControl.ValueUnitOfMeasure = "";
            this.destinationMaxValueEditorControl.ValueChanged += new System.EventHandler(this.amountEditorControl_ValueChanged);
            // 
            // gammaValueEditorControl
            // 
            this.gammaValueEditorControl.DecimalPlaces = 4;
            this.gammaValueEditorControl.Location = new System.Drawing.Point(12, 166);
            this.gammaValueEditorControl.MaxValue = 8F;
            this.gammaValueEditorControl.Name = "gammaValueEditorControl";
            this.gammaValueEditorControl.Size = new System.Drawing.Size(267, 71);
            this.gammaValueEditorControl.Step = 0.01F;
            this.gammaValueEditorControl.TabIndex = 4;
            this.gammaValueEditorControl.ValueName = "Gamma";
            this.gammaValueEditorControl.ValueUnitOfMeasure = "";
            this.gammaValueEditorControl.ValueChanged += new System.EventHandler(this.amountEditorControl_ValueChanged);
            // 
            // redCheckBox
            // 
            this.redCheckBox.AutoSize = true;
            this.redCheckBox.Checked = true;
            this.redCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.redCheckBox.Location = new System.Drawing.Point(16, 28);
            this.redCheckBox.Name = "redCheckBox";
            this.redCheckBox.Size = new System.Drawing.Size(46, 17);
            this.redCheckBox.TabIndex = 5;
            this.redCheckBox.Text = "Red";
            this.redCheckBox.UseVisualStyleBackColor = true;
            this.redCheckBox.CheckedChanged += new System.EventHandler(this.amountEditorControl_ValueChanged);
            // 
            // greenCheckBox
            // 
            this.greenCheckBox.AutoSize = true;
            this.greenCheckBox.Checked = true;
            this.greenCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.greenCheckBox.Location = new System.Drawing.Point(97, 28);
            this.greenCheckBox.Name = "greenCheckBox";
            this.greenCheckBox.Size = new System.Drawing.Size(55, 17);
            this.greenCheckBox.TabIndex = 6;
            this.greenCheckBox.Text = "Green";
            this.greenCheckBox.UseVisualStyleBackColor = true;
            this.greenCheckBox.CheckedChanged += new System.EventHandler(this.amountEditorControl_ValueChanged);
            // 
            // blueCheckBox
            // 
            this.blueCheckBox.AutoSize = true;
            this.blueCheckBox.Checked = true;
            this.blueCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.blueCheckBox.Location = new System.Drawing.Point(190, 28);
            this.blueCheckBox.Name = "blueCheckBox";
            this.blueCheckBox.Size = new System.Drawing.Size(47, 17);
            this.blueCheckBox.TabIndex = 7;
            this.blueCheckBox.Text = "Blue";
            this.blueCheckBox.UseVisualStyleBackColor = true;
            this.blueCheckBox.CheckedChanged += new System.EventHandler(this.amountEditorControl_ValueChanged);
            // 
            // previewCheckBox
            // 
            this.previewCheckBox.AutoSize = true;
            this.previewCheckBox.Checked = true;
            this.previewCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.previewCheckBox.ForeColor = System.Drawing.Color.Black;
            this.previewCheckBox.Location = new System.Drawing.Point(12, 254);
            this.previewCheckBox.Name = "previewCheckBox";
            this.previewCheckBox.Size = new System.Drawing.Size(143, 17);
            this.previewCheckBox.TabIndex = 58;
            this.previewCheckBox.Text = "Preview on ImageViewer";
            this.previewCheckBox.UseVisualStyleBackColor = true;
            this.previewCheckBox.CheckedChanged += new System.EventHandler(this.previewCheckBox_CheckedChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(473, 254);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 57;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(391, 254);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 56;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.redCheckBox);
            this.groupBox1.Controls.Add(this.greenCheckBox);
            this.groupBox1.Controls.Add(this.blueCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(285, 166);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 71);
            this.groupBox1.TabIndex = 59;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Channels:";
            // 
            // LevelsForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(560, 291);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.previewCheckBox);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.gammaValueEditorControl);
            this.Controls.Add(this.destinationMaxValueEditorControl);
            this.Controls.Add(this.destinationMinValueEditorControl);
            this.Controls.Add(this.sourceMaxValueEditorControl);
            this.Controls.Add(this.sourceMinValueEditorControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LevelsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Levels";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DemosCommonCode.CustomControls.ValueEditorControl sourceMinValueEditorControl;
        private DemosCommonCode.CustomControls.ValueEditorControl sourceMaxValueEditorControl;
        private DemosCommonCode.CustomControls.ValueEditorControl destinationMinValueEditorControl;
        private DemosCommonCode.CustomControls.ValueEditorControl destinationMaxValueEditorControl;
        private DemosCommonCode.CustomControls.ValueEditorControl gammaValueEditorControl;
        private System.Windows.Forms.CheckBox redCheckBox;
        private System.Windows.Forms.CheckBox greenCheckBox;
        private System.Windows.Forms.CheckBox blueCheckBox;
        private System.Windows.Forms.CheckBox previewCheckBox;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}