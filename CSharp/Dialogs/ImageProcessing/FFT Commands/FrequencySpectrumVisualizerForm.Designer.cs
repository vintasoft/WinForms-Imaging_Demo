namespace ImagingDemo
{
    partial class FrequencySpectrumVisualizerForm
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
            this.visualizationTypeComboBox = new System.Windows.Forms.ComboBox();
            this.grayscaleVisualizationCheckBox = new System.Windows.Forms.CheckBox();
            this.normalizationCheckBox = new System.Windows.Forms.CheckBox();
            this.absoluteValuesCheckBox = new System.Windows.Forms.CheckBox();
            this.fixedSpectrumSizeCheckBox = new System.Windows.Forms.CheckBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.previewCheckBox = new System.Windows.Forms.CheckBox();
            this.spectrumSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.spectrumSizeNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Visualization type";
            // 
            // visualizationTypeComboBox
            // 
            this.visualizationTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.visualizationTypeComboBox.FormattingEnabled = true;
            this.visualizationTypeComboBox.Location = new System.Drawing.Point(111, 10);
            this.visualizationTypeComboBox.Name = "visualizationTypeComboBox";
            this.visualizationTypeComboBox.Size = new System.Drawing.Size(149, 21);
            this.visualizationTypeComboBox.TabIndex = 1;
            this.visualizationTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.visualizationTypeComboBox_SelectedIndexChanged);
            // 
            // grayscaleVisualizationCheckBox
            // 
            this.grayscaleVisualizationCheckBox.AutoSize = true;
            this.grayscaleVisualizationCheckBox.Location = new System.Drawing.Point(16, 45);
            this.grayscaleVisualizationCheckBox.Name = "grayscaleVisualizationCheckBox";
            this.grayscaleVisualizationCheckBox.Size = new System.Drawing.Size(142, 17);
            this.grayscaleVisualizationCheckBox.TabIndex = 2;
            this.grayscaleVisualizationCheckBox.Text = "Analyse grayscale image";
            this.grayscaleVisualizationCheckBox.UseVisualStyleBackColor = true;
            this.grayscaleVisualizationCheckBox.CheckedChanged += new System.EventHandler(this.grayscaleVisualizationCheckBox_CheckedChanged);
            // 
            // normalizationCheckBox
            // 
            this.normalizationCheckBox.AutoSize = true;
            this.normalizationCheckBox.Location = new System.Drawing.Point(16, 69);
            this.normalizationCheckBox.Name = "normalizationCheckBox";
            this.normalizationCheckBox.Size = new System.Drawing.Size(109, 17);
            this.normalizationCheckBox.TabIndex = 3;
            this.normalizationCheckBox.Text = "Use normalization";
            this.normalizationCheckBox.UseVisualStyleBackColor = true;
            this.normalizationCheckBox.CheckedChanged += new System.EventHandler(this.normalizationCheckBox_CheckedChanged);
            // 
            // absoluteValuesCheckBox
            // 
            this.absoluteValuesCheckBox.AutoSize = true;
            this.absoluteValuesCheckBox.Location = new System.Drawing.Point(16, 93);
            this.absoluteValuesCheckBox.Name = "absoluteValuesCheckBox";
            this.absoluteValuesCheckBox.Size = new System.Drawing.Size(122, 17);
            this.absoluteValuesCheckBox.TabIndex = 4;
            this.absoluteValuesCheckBox.Text = "Use absolute values";
            this.absoluteValuesCheckBox.UseVisualStyleBackColor = true;
            this.absoluteValuesCheckBox.CheckedChanged += new System.EventHandler(this.absoluteValuesCheckBox_CheckedChanged);
            // 
            // fixedSpectrumSizeCheckBox
            // 
            this.fixedSpectrumSizeCheckBox.AutoSize = true;
            this.fixedSpectrumSizeCheckBox.Location = new System.Drawing.Point(16, 116);
            this.fixedSpectrumSizeCheckBox.Name = "fixedSpectrumSizeCheckBox";
            this.fixedSpectrumSizeCheckBox.Size = new System.Drawing.Size(118, 17);
            this.fixedSpectrumSizeCheckBox.TabIndex = 5;
            this.fixedSpectrumSizeCheckBox.Text = "Fixed spectrum size";
            this.fixedSpectrumSizeCheckBox.UseVisualStyleBackColor = true;
            this.fixedSpectrumSizeCheckBox.CheckedChanged += new System.EventHandler(this.fixedSpectrumSizeCheckBox_CheckedChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(249, 147);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 54;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(167, 147);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 53;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // previewCheckBox
            // 
            this.previewCheckBox.AutoSize = true;
            this.previewCheckBox.ForeColor = System.Drawing.Color.Green;
            this.previewCheckBox.Location = new System.Drawing.Point(16, 151);
            this.previewCheckBox.Name = "previewCheckBox";
            this.previewCheckBox.Size = new System.Drawing.Size(143, 17);
            this.previewCheckBox.TabIndex = 55;
            this.previewCheckBox.Text = "Preview on ImageViewer";
            this.previewCheckBox.UseVisualStyleBackColor = true;
            this.previewCheckBox.CheckedChanged += new System.EventHandler(this.previewCheckBox_CheckedChanged);
            // 
            // spectrumSizeNumericUpDown
            // 
            this.spectrumSizeNumericUpDown.Location = new System.Drawing.Point(140, 113);
            this.spectrumSizeNumericUpDown.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.spectrumSizeNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spectrumSizeNumericUpDown.Name = "spectrumSizeNumericUpDown";
            this.spectrumSizeNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.spectrumSizeNumericUpDown.TabIndex = 56;
            this.spectrumSizeNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spectrumSizeNumericUpDown.ValueChanged += new System.EventHandler(this.spectrumSizeNumericUpDown_ValueChanged);
            // 
            // FrequencySpectrumVisualizerForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(336, 179);
            this.Controls.Add(this.spectrumSizeNumericUpDown);
            this.Controls.Add(this.previewCheckBox);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.fixedSpectrumSizeCheckBox);
            this.Controls.Add(this.absoluteValuesCheckBox);
            this.Controls.Add(this.normalizationCheckBox);
            this.Controls.Add(this.grayscaleVisualizationCheckBox);
            this.Controls.Add(this.visualizationTypeComboBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "FrequencySpectrumVisualizerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Frequency Spectrum Visualizer";
            ((System.ComponentModel.ISupportInitialize)(this.spectrumSizeNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox visualizationTypeComboBox;
        private System.Windows.Forms.CheckBox grayscaleVisualizationCheckBox;
        private System.Windows.Forms.CheckBox normalizationCheckBox;
        private System.Windows.Forms.CheckBox absoluteValuesCheckBox;
        private System.Windows.Forms.CheckBox fixedSpectrumSizeCheckBox;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.CheckBox previewCheckBox;
        private System.Windows.Forms.NumericUpDown spectrumSizeNumericUpDown;
    }
}
