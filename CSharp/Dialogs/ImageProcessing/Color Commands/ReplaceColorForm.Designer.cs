namespace ImagingDemo
{
    partial class ReplaceColorForm
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.colorSpaceComboBox = new System.Windows.Forms.ComboBox();
            this.colorToleranceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.colorSpaceLabel = new System.Windows.Forms.Label();
            this.colorToleranceLabel = new System.Windows.Forms.Label();
            this.newColorLabel = new System.Windows.Forms.Label();
            this.oldColorLabel = new System.Windows.Forms.Label();
            this.previewCheckBox = new System.Windows.Forms.CheckBox();
            this.oldColorPanelControl = new DemosCommonCode.CustomControls.ColorPanelControl();
            this.newColorPanelControl = new DemosCommonCode.CustomControls.ColorPanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.colorToleranceNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(145, 156);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(81, 23);
            this.buttonCancel.TabIndex = 55;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(46, 156);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(81, 23);
            this.buttonOk.TabIndex = 54;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // colorSpaceComboBox
            // 
            this.colorSpaceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorSpaceComboBox.FormattingEnabled = true;
            this.colorSpaceComboBox.Items.AddRange(new object[] {
            "RGB",
            "Lab"});
            this.colorSpaceComboBox.Location = new System.Drawing.Point(105, 91);
            this.colorSpaceComboBox.Name = "colorSpaceComboBox";
            this.colorSpaceComboBox.Size = new System.Drawing.Size(92, 21);
            this.colorSpaceComboBox.TabIndex = 53;
            this.colorSpaceComboBox.SelectedIndexChanged += new System.EventHandler(this.colorSpaceComboBox_SelectedIndexChanged);
            // 
            // colorToleranceNumericUpDown
            // 
            this.colorToleranceNumericUpDown.Location = new System.Drawing.Point(105, 64);
            this.colorToleranceNumericUpDown.Maximum = new decimal(new int[] {
            442,
            0,
            0,
            0});
            this.colorToleranceNumericUpDown.Name = "colorToleranceNumericUpDown";
            this.colorToleranceNumericUpDown.Size = new System.Drawing.Size(92, 20);
            this.colorToleranceNumericUpDown.TabIndex = 52;
            this.colorToleranceNumericUpDown.ValueChanged += new System.EventHandler(this.colorToleranceNumericUpDown_ValueChanged);
            // 
            // colorSpaceLabel
            // 
            this.colorSpaceLabel.AutoSize = true;
            this.colorSpaceLabel.Location = new System.Drawing.Point(12, 94);
            this.colorSpaceLabel.Name = "colorSpaceLabel";
            this.colorSpaceLabel.Size = new System.Drawing.Size(65, 13);
            this.colorSpaceLabel.TabIndex = 49;
            this.colorSpaceLabel.Text = "Color Space";
            // 
            // colorToleranceLabel
            // 
            this.colorToleranceLabel.AutoSize = true;
            this.colorToleranceLabel.Location = new System.Drawing.Point(11, 66);
            this.colorToleranceLabel.Name = "colorToleranceLabel";
            this.colorToleranceLabel.Size = new System.Drawing.Size(82, 13);
            this.colorToleranceLabel.TabIndex = 48;
            this.colorToleranceLabel.Text = "Color Tolerance";
            // 
            // newColorLabel
            // 
            this.newColorLabel.AutoSize = true;
            this.newColorLabel.Location = new System.Drawing.Point(12, 40);
            this.newColorLabel.Name = "newColorLabel";
            this.newColorLabel.Size = new System.Drawing.Size(56, 13);
            this.newColorLabel.TabIndex = 46;
            this.newColorLabel.Text = "New Color";
            // 
            // oldColorLabel
            // 
            this.oldColorLabel.AutoSize = true;
            this.oldColorLabel.Location = new System.Drawing.Point(12, 13);
            this.oldColorLabel.Name = "oldColorLabel";
            this.oldColorLabel.Size = new System.Drawing.Size(50, 13);
            this.oldColorLabel.TabIndex = 44;
            this.oldColorLabel.Text = "Old Color";
            // 
            // previewCheckBox
            // 
            this.previewCheckBox.AutoSize = true;
            this.previewCheckBox.Location = new System.Drawing.Point(15, 123);
            this.previewCheckBox.Name = "previewCheckBox";
            this.previewCheckBox.Size = new System.Drawing.Size(143, 17);
            this.previewCheckBox.TabIndex = 56;
            this.previewCheckBox.Text = "Preview on ImageViewer";
            this.previewCheckBox.UseVisualStyleBackColor = true;
            this.previewCheckBox.CheckedChanged += new System.EventHandler(this.previewCheckBox_CheckedChanged);
            // 
            // oldColorPanelControl
            // 
            this.oldColorPanelControl.Color = System.Drawing.SystemColors.Control;
            this.oldColorPanelControl.ColorButtonMargin = 8;
            this.oldColorPanelControl.ColorButtonWidth = 47;
            this.oldColorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.oldColorPanelControl.Location = new System.Drawing.Point(105, 8);
            this.oldColorPanelControl.Name = "oldColorPanelControl";
            this.oldColorPanelControl.Size = new System.Drawing.Size(147, 22);
            this.oldColorPanelControl.TabIndex = 57;
            this.oldColorPanelControl.ColorChanged += new System.EventHandler(this.ColorPanelControl_ColorChanged);
            // 
            // newColorPanelControl
            // 
            this.newColorPanelControl.Color = System.Drawing.SystemColors.Control;
            this.newColorPanelControl.ColorButtonMargin = 8;
            this.newColorPanelControl.ColorButtonWidth = 47;
            this.newColorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.newColorPanelControl.Location = new System.Drawing.Point(105, 35);
            this.newColorPanelControl.Name = "newColorPanelControl";
            this.newColorPanelControl.Size = new System.Drawing.Size(147, 22);
            this.newColorPanelControl.TabIndex = 58;
            this.newColorPanelControl.ColorChanged += new System.EventHandler(this.ColorPanelControl_ColorChanged);
            // 
            // ReplaceColorForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(269, 192);
            this.Controls.Add(this.newColorPanelControl);
            this.Controls.Add(this.oldColorPanelControl);
            this.Controls.Add(this.previewCheckBox);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.colorSpaceComboBox);
            this.Controls.Add(this.colorToleranceNumericUpDown);
            this.Controls.Add(this.colorSpaceLabel);
            this.Controls.Add(this.colorToleranceLabel);
            this.Controls.Add(this.newColorLabel);
            this.Controls.Add(this.oldColorLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(40, 110);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReplaceColorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Replace Color";
            ((System.ComponentModel.ISupportInitialize)(this.colorToleranceNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.ComboBox colorSpaceComboBox;
        private System.Windows.Forms.NumericUpDown colorToleranceNumericUpDown;
        private System.Windows.Forms.Label colorSpaceLabel;
        private System.Windows.Forms.Label colorToleranceLabel;
        private System.Windows.Forms.Label newColorLabel;
        private System.Windows.Forms.Label oldColorLabel;
        private System.Windows.Forms.CheckBox previewCheckBox;
        private DemosCommonCode.CustomControls.ColorPanelControl oldColorPanelControl;
        private DemosCommonCode.CustomControls.ColorPanelControl newColorPanelControl;
    }
}