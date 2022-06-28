namespace ImagingDemo
{
    partial class ReplaceColorGradientForm
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
            this.gradientRadiusNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.gradientRadiusLabel = new System.Windows.Forms.Label();
            this.stopColorLabel = new System.Windows.Forms.Label();
            this.startColorLabel = new System.Windows.Forms.Label();
            this.previewCheckBox = new System.Windows.Forms.CheckBox();
            this.startColorPanelControl = new DemosCommonCode.CustomControls.ColorPanelControl();
            this.stopColorPanelControl = new DemosCommonCode.CustomControls.ColorPanelControl();
            this.replaceColorPanelControl = new DemosCommonCode.CustomControls.ColorPanelControl();
            this.replaceColorLabel = new System.Windows.Forms.Label();
            this.interpolationRadiusNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gradientRadiusNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.interpolationRadiusNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(158, 185);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(81, 23);
            this.buttonCancel.TabIndex = 55;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(59, 185);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(81, 23);
            this.buttonOk.TabIndex = 54;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // gradientRadiusNumericUpDown
            // 
            this.gradientRadiusNumericUpDown.Location = new System.Drawing.Point(147, 64);
            this.gradientRadiusNumericUpDown.Maximum = new decimal(new int[] {
            442,
            0,
            0,
            0});
            this.gradientRadiusNumericUpDown.Name = "gradientRadiusNumericUpDown";
            this.gradientRadiusNumericUpDown.Size = new System.Drawing.Size(92, 20);
            this.gradientRadiusNumericUpDown.TabIndex = 52;
            this.gradientRadiusNumericUpDown.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.gradientRadiusNumericUpDown.ValueChanged += new System.EventHandler(this.processingProperty_ValueChanged);
            // 
            // gradientRadiusLabel
            // 
            this.gradientRadiusLabel.AutoSize = true;
            this.gradientRadiusLabel.Location = new System.Drawing.Point(12, 66);
            this.gradientRadiusLabel.Name = "gradientRadiusLabel";
            this.gradientRadiusLabel.Size = new System.Drawing.Size(83, 13);
            this.gradientRadiusLabel.TabIndex = 48;
            this.gradientRadiusLabel.Text = "Gradient Radius";
            // 
            // stopColorLabel
            // 
            this.stopColorLabel.AutoSize = true;
            this.stopColorLabel.Location = new System.Drawing.Point(12, 40);
            this.stopColorLabel.Name = "stopColorLabel";
            this.stopColorLabel.Size = new System.Drawing.Size(56, 13);
            this.stopColorLabel.TabIndex = 46;
            this.stopColorLabel.Text = "Stop Color";
            // 
            // startColorLabel
            // 
            this.startColorLabel.AutoSize = true;
            this.startColorLabel.Location = new System.Drawing.Point(12, 13);
            this.startColorLabel.Name = "startColorLabel";
            this.startColorLabel.Size = new System.Drawing.Size(56, 13);
            this.startColorLabel.TabIndex = 44;
            this.startColorLabel.Text = "Start Color";
            // 
            // previewCheckBox
            // 
            this.previewCheckBox.AutoSize = true;
            this.previewCheckBox.Location = new System.Drawing.Point(11, 152);
            this.previewCheckBox.Name = "previewCheckBox";
            this.previewCheckBox.Size = new System.Drawing.Size(143, 17);
            this.previewCheckBox.TabIndex = 56;
            this.previewCheckBox.Text = "Preview on ImageViewer";
            this.previewCheckBox.UseVisualStyleBackColor = true;
            this.previewCheckBox.CheckedChanged += new System.EventHandler(this.previewCheckBox_CheckedChanged);
            // 
            // startColorPanelControl
            // 
            this.startColorPanelControl.CanEditAlphaChannel = false;
            this.startColorPanelControl.Color = System.Drawing.SystemColors.Control;
            this.startColorPanelControl.ColorButtonMargin = 8;
            this.startColorPanelControl.ColorButtonWidth = 47;
            this.startColorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.startColorPanelControl.Location = new System.Drawing.Point(147, 8);
            this.startColorPanelControl.Name = "startColorPanelControl";
            this.startColorPanelControl.Size = new System.Drawing.Size(147, 22);
            this.startColorPanelControl.TabIndex = 57;
            this.startColorPanelControl.ColorChanged += new System.EventHandler(this.processingProperty_ValueChanged);
            // 
            // stopColorPanelControl
            // 
            this.stopColorPanelControl.CanEditAlphaChannel = false;
            this.stopColorPanelControl.Color = System.Drawing.SystemColors.Control;
            this.stopColorPanelControl.ColorButtonMargin = 8;
            this.stopColorPanelControl.ColorButtonWidth = 47;
            this.stopColorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.stopColorPanelControl.Location = new System.Drawing.Point(147, 35);
            this.stopColorPanelControl.Name = "stopColorPanelControl";
            this.stopColorPanelControl.Size = new System.Drawing.Size(147, 22);
            this.stopColorPanelControl.TabIndex = 58;
            this.stopColorPanelControl.ColorChanged += new System.EventHandler(this.processingProperty_ValueChanged);
            // 
            // replaceColorPanelControl
            // 
            this.replaceColorPanelControl.CanEditAlphaChannel = false;
            this.replaceColorPanelControl.Color = System.Drawing.SystemColors.Control;
            this.replaceColorPanelControl.ColorButtonMargin = 8;
            this.replaceColorPanelControl.ColorButtonWidth = 47;
            this.replaceColorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.replaceColorPanelControl.Location = new System.Drawing.Point(147, 90);
            this.replaceColorPanelControl.Name = "replaceColorPanelControl";
            this.replaceColorPanelControl.Size = new System.Drawing.Size(147, 22);
            this.replaceColorPanelControl.TabIndex = 60;
            this.replaceColorPanelControl.ColorChanged += new System.EventHandler(this.processingProperty_ValueChanged);
            // 
            // replaceColorLabel
            // 
            this.replaceColorLabel.AutoSize = true;
            this.replaceColorLabel.Location = new System.Drawing.Point(12, 95);
            this.replaceColorLabel.Name = "replaceColorLabel";
            this.replaceColorLabel.Size = new System.Drawing.Size(74, 13);
            this.replaceColorLabel.TabIndex = 59;
            this.replaceColorLabel.Text = "Replace Color";
            // 
            // interpolationRadiusNumericUpDown
            // 
            this.interpolationRadiusNumericUpDown.Location = new System.Drawing.Point(147, 118);
            this.interpolationRadiusNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.interpolationRadiusNumericUpDown.Name = "interpolationRadiusNumericUpDown";
            this.interpolationRadiusNumericUpDown.Size = new System.Drawing.Size(92, 20);
            this.interpolationRadiusNumericUpDown.TabIndex = 62;
            this.interpolationRadiusNumericUpDown.ValueChanged += new System.EventHandler(this.processingProperty_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 61;
            this.label1.Text = "Interpolation Radius (x10)";
            // 
            // ReplaceColorGradientForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(303, 220);
            this.Controls.Add(this.interpolationRadiusNumericUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.replaceColorPanelControl);
            this.Controls.Add(this.replaceColorLabel);
            this.Controls.Add(this.stopColorPanelControl);
            this.Controls.Add(this.startColorPanelControl);
            this.Controls.Add(this.previewCheckBox);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.gradientRadiusNumericUpDown);
            this.Controls.Add(this.gradientRadiusLabel);
            this.Controls.Add(this.stopColorLabel);
            this.Controls.Add(this.startColorLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(40, 110);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReplaceColorGradientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Color Gradient Replace";
            ((System.ComponentModel.ISupportInitialize)(this.gradientRadiusNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.interpolationRadiusNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.NumericUpDown gradientRadiusNumericUpDown;
        private System.Windows.Forms.Label gradientRadiusLabel;
        private System.Windows.Forms.Label stopColorLabel;
        private System.Windows.Forms.Label startColorLabel;
        private System.Windows.Forms.CheckBox previewCheckBox;
        private DemosCommonCode.CustomControls.ColorPanelControl startColorPanelControl;
        private DemosCommonCode.CustomControls.ColorPanelControl stopColorPanelControl;
        private DemosCommonCode.CustomControls.ColorPanelControl replaceColorPanelControl;
        private System.Windows.Forms.Label replaceColorLabel;
        private System.Windows.Forms.NumericUpDown interpolationRadiusNumericUpDown;
        private System.Windows.Forms.Label label1;
    }
}