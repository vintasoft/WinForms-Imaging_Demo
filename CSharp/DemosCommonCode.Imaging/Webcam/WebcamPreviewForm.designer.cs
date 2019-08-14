namespace DemosCommonCode.Imaging
{
    partial class WebcamPreviewForm
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
            this.videoPreviewImageViewer = new Vintasoft.Imaging.UI.ImageViewer();
            this.formatsComboBox = new System.Windows.Forms.ComboBox();
            this.captureImageButton = new System.Windows.Forms.Button();
            this.frameDelayNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.propertiesDefaultUiButton = new System.Windows.Forms.Button();
            this.processingGroupBox = new System.Windows.Forms.GroupBox();
            this.invertComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grayscaleCheckBox = new System.Windows.Forms.CheckBox();
            this.rotateComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.propertiesCustomUiButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.frameDelayNumericUpDown)).BeginInit();
            this.processingGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // videoPreviewImageViewer
            // 
            this.videoPreviewImageViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.videoPreviewImageViewer.AutoScroll = true;
            this.videoPreviewImageViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.videoPreviewImageViewer.Location = new System.Drawing.Point(7, 3);
            this.videoPreviewImageViewer.Name = "videoPreviewImageViewer";
            this.videoPreviewImageViewer.Size = new System.Drawing.Size(414, 286);
            this.videoPreviewImageViewer.SizeMode = Vintasoft.Imaging.UI.ImageSizeMode.BestFit;
            this.videoPreviewImageViewer.TabIndex = 0;
            this.videoPreviewImageViewer.Text = "imageViewer1";
            // 
            // formatsComboBox
            // 
            this.formatsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formatsComboBox.FormattingEnabled = true;
            this.formatsComboBox.Location = new System.Drawing.Point(97, 19);
            this.formatsComboBox.Name = "formatsComboBox";
            this.formatsComboBox.Size = new System.Drawing.Size(120, 21);
            this.formatsComboBox.TabIndex = 2;
            this.formatsComboBox.SelectedIndexChanged += new System.EventHandler(this.formatsComboBox_SelectedIndexChanged);
            // 
            // captureImageButton
            // 
            this.captureImageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.captureImageButton.Location = new System.Drawing.Point(327, 377);
            this.captureImageButton.Name = "captureImageButton";
            this.captureImageButton.Size = new System.Drawing.Size(94, 61);
            this.captureImageButton.TabIndex = 3;
            this.captureImageButton.Text = "Capture Image";
            this.captureImageButton.UseVisualStyleBackColor = true;
            this.captureImageButton.Visible = false;
            this.captureImageButton.Click += new System.EventHandler(this.captureImageButton_Click);
            // 
            // frameDelayNumericUpDown
            // 
            this.frameDelayNumericUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.frameDelayNumericUpDown.Location = new System.Drawing.Point(97, 43);
            this.frameDelayNumericUpDown.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.frameDelayNumericUpDown.Name = "frameDelayNumericUpDown";
            this.frameDelayNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.frameDelayNumericUpDown.TabIndex = 4;
            this.frameDelayNumericUpDown.ValueChanged += new System.EventHandler(this.frameDelayNumericUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Video format";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Frame delay (ms)";
            // 
            // propertiesDefaultUiButton
            // 
            this.propertiesDefaultUiButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.propertiesDefaultUiButton.Location = new System.Drawing.Point(275, 17);
            this.propertiesDefaultUiButton.Name = "propertiesDefaultUiButton";
            this.propertiesDefaultUiButton.Size = new System.Drawing.Size(133, 23);
            this.propertiesDefaultUiButton.TabIndex = 7;
            this.propertiesDefaultUiButton.Text = "Properties (Default UI) ...";
            this.propertiesDefaultUiButton.UseVisualStyleBackColor = true;
            this.propertiesDefaultUiButton.Click += new System.EventHandler(this.propertiesDefaultUiButton_Click);
            // 
            // processingGroupBox
            // 
            this.processingGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.processingGroupBox.Controls.Add(this.invertComboBox);
            this.processingGroupBox.Controls.Add(this.label4);
            this.processingGroupBox.Controls.Add(this.grayscaleCheckBox);
            this.processingGroupBox.Controls.Add(this.rotateComboBox);
            this.processingGroupBox.Controls.Add(this.label3);
            this.processingGroupBox.Location = new System.Drawing.Point(7, 371);
            this.processingGroupBox.Name = "processingGroupBox";
            this.processingGroupBox.Size = new System.Drawing.Size(314, 67);
            this.processingGroupBox.TabIndex = 8;
            this.processingGroupBox.TabStop = false;
            this.processingGroupBox.Text = "Captured Image Processing";
            // 
            // invertComboBox
            // 
            this.invertComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.invertComboBox.FormattingEnabled = true;
            this.invertComboBox.Items.AddRange(new object[] {
            "(none)",
            "Invert",
            "Invert RED",
            "Invert GREEN",
            "Invert BLUE"});
            this.invertComboBox.Location = new System.Drawing.Point(86, 38);
            this.invertComboBox.Name = "invertComboBox";
            this.invertComboBox.Size = new System.Drawing.Size(120, 21);
            this.invertComboBox.TabIndex = 4;
            this.invertComboBox.SelectedIndexChanged += new System.EventHandler(this.ChangeProcessingCommandHandler);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Invert";
            // 
            // grayscaleCheckBox
            // 
            this.grayscaleCheckBox.AutoSize = true;
            this.grayscaleCheckBox.Location = new System.Drawing.Point(230, 40);
            this.grayscaleCheckBox.Name = "grayscaleCheckBox";
            this.grayscaleCheckBox.Size = new System.Drawing.Size(73, 17);
            this.grayscaleCheckBox.TabIndex = 2;
            this.grayscaleCheckBox.Text = "Grayscale";
            this.grayscaleCheckBox.UseVisualStyleBackColor = true;
            this.grayscaleCheckBox.CheckedChanged += new System.EventHandler(this.ChangeProcessingCommandHandler);
            // 
            // rotateComboBox
            // 
            this.rotateComboBox.FormattingEnabled = true;
            this.rotateComboBox.Items.AddRange(new object[] {
            "0",
            "90",
            "180",
            "270"});
            this.rotateComboBox.Location = new System.Drawing.Point(86, 15);
            this.rotateComboBox.Name = "rotateComboBox";
            this.rotateComboBox.Size = new System.Drawing.Size(120, 21);
            this.rotateComboBox.TabIndex = 1;
            this.rotateComboBox.Text = "0";
            this.rotateComboBox.SelectedIndexChanged += new System.EventHandler(this.ChangeProcessingCommandHandler);
            this.rotateComboBox.TextChanged += new System.EventHandler(this.ChangeProcessingCommandHandler);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Rotate";
            // 
            // propertiesCustomUiButton
            // 
            this.propertiesCustomUiButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.propertiesCustomUiButton.Location = new System.Drawing.Point(275, 43);
            this.propertiesCustomUiButton.Name = "propertiesCustomUiButton";
            this.propertiesCustomUiButton.Size = new System.Drawing.Size(133, 23);
            this.propertiesCustomUiButton.TabIndex = 9;
            this.propertiesCustomUiButton.Text = "Properties (Custom UI) ...";
            this.propertiesCustomUiButton.UseVisualStyleBackColor = true;
            this.propertiesCustomUiButton.Click += new System.EventHandler(this.propertiesCustomUiButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.formatsComboBox);
            this.groupBox1.Controls.Add(this.propertiesCustomUiButton);
            this.groupBox1.Controls.Add(this.frameDelayNumericUpDown);
            this.groupBox1.Controls.Add(this.propertiesDefaultUiButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(7, 292);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 74);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Captured Image Settings";
            // 
            // WebcamPreviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 447);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.processingGroupBox);
            this.Controls.Add(this.captureImageButton);
            this.Controls.Add(this.videoPreviewImageViewer);
            this.Name = "WebcamPreviewForm";
            this.Shown += new System.EventHandler(this.WebcamVideoForm_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WebcamVideoForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.frameDelayNumericUpDown)).EndInit();
            this.processingGroupBox.ResumeLayout(false);
            this.processingGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Vintasoft.Imaging.UI.ImageViewer videoPreviewImageViewer;
        private System.Windows.Forms.ComboBox formatsComboBox;
        private System.Windows.Forms.Button captureImageButton;
        private System.Windows.Forms.NumericUpDown frameDelayNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button propertiesDefaultUiButton;
        private System.Windows.Forms.GroupBox processingGroupBox;
        private System.Windows.Forms.CheckBox grayscaleCheckBox;
        private System.Windows.Forms.ComboBox rotateComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox invertComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button propertiesCustomUiButton;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}