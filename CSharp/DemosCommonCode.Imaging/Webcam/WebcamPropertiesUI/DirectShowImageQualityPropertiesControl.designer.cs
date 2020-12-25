namespace DemosCommonCode.Imaging
{
    partial class DirectShowImageQualityPropertiesControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.imageQualityPropertiesGroupBox = new System.Windows.Forms.GroupBox();
            this.whiteBalanceDirectShowPropertyControl = new DemosCommonCode.Imaging.DirectShowPropertyControl();
            this.sharpnessDirectShowPropertyControl = new DemosCommonCode.Imaging.DirectShowPropertyControl();
            this.saturationDirectShowPropertyControl = new DemosCommonCode.Imaging.DirectShowPropertyControl();
            this.hueDirectShowPropertyControl = new DemosCommonCode.Imaging.DirectShowPropertyControl();
            this.gammaDirectShowPropertyControl = new DemosCommonCode.Imaging.DirectShowPropertyControl();
            this.gainDirectShowPropertyControl = new DemosCommonCode.Imaging.DirectShowPropertyControl();
            this.contrastDirectShowPropertyControl = new DemosCommonCode.Imaging.DirectShowPropertyControl();
            this.colorEnableDirectShowPropertyControl = new DemosCommonCode.Imaging.DirectShowPropertyControl();
            this.brightnessDirectShowPropertyControl = new DemosCommonCode.Imaging.DirectShowPropertyControl();
            this.backlightCompensationDirectShowPropertyControl = new DemosCommonCode.Imaging.DirectShowPropertyControl();
            this.restoreButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.imageQualityPropertiesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageQualityPropertiesGroupBox
            // 
            this.imageQualityPropertiesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageQualityPropertiesGroupBox.Controls.Add(this.whiteBalanceDirectShowPropertyControl);
            this.imageQualityPropertiesGroupBox.Controls.Add(this.sharpnessDirectShowPropertyControl);
            this.imageQualityPropertiesGroupBox.Controls.Add(this.saturationDirectShowPropertyControl);
            this.imageQualityPropertiesGroupBox.Controls.Add(this.hueDirectShowPropertyControl);
            this.imageQualityPropertiesGroupBox.Controls.Add(this.gammaDirectShowPropertyControl);
            this.imageQualityPropertiesGroupBox.Controls.Add(this.gainDirectShowPropertyControl);
            this.imageQualityPropertiesGroupBox.Controls.Add(this.contrastDirectShowPropertyControl);
            this.imageQualityPropertiesGroupBox.Controls.Add(this.colorEnableDirectShowPropertyControl);
            this.imageQualityPropertiesGroupBox.Controls.Add(this.brightnessDirectShowPropertyControl);
            this.imageQualityPropertiesGroupBox.Controls.Add(this.backlightCompensationDirectShowPropertyControl);
            this.imageQualityPropertiesGroupBox.Controls.Add(this.restoreButton);
            this.imageQualityPropertiesGroupBox.Controls.Add(this.resetButton);
            this.imageQualityPropertiesGroupBox.Location = new System.Drawing.Point(3, 3);
            this.imageQualityPropertiesGroupBox.Name = "imageQualityPropertiesGroupBox";
            this.imageQualityPropertiesGroupBox.Size = new System.Drawing.Size(389, 292);
            this.imageQualityPropertiesGroupBox.TabIndex = 1;
            this.imageQualityPropertiesGroupBox.TabStop = false;
            this.imageQualityPropertiesGroupBox.Text = "Image Quality Properties";
            // 
            // whiteBalanceDirectShowPropertyControl
            // 
            this.whiteBalanceDirectShowPropertyControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.whiteBalanceDirectShowPropertyControl.Location = new System.Drawing.Point(6, 228);
            this.whiteBalanceDirectShowPropertyControl.MinimumSize = new System.Drawing.Size(270, 27);
            this.whiteBalanceDirectShowPropertyControl.Name = "whiteBalanceDirectShowPropertyControl";
            this.whiteBalanceDirectShowPropertyControl.PropertyDescriptionText = "White balance:";
            this.whiteBalanceDirectShowPropertyControl.PropertyDescriptionWidth = 126F;
            this.whiteBalanceDirectShowPropertyControl.Size = new System.Drawing.Size(377, 27);
            this.whiteBalanceDirectShowPropertyControl.TabIndex = 42;
            this.whiteBalanceDirectShowPropertyControl.PropertyChanged += new System.EventHandler<DemosCommonCode.Imaging.DirectShowPropertyChangedEventArgs>(this.whiteBalanceDirectShowPropertyControl_PropertyChanged);
            // 
            // sharpnessDirectShowPropertyControl
            // 
            this.sharpnessDirectShowPropertyControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sharpnessDirectShowPropertyControl.Location = new System.Drawing.Point(6, 204);
            this.sharpnessDirectShowPropertyControl.MinimumSize = new System.Drawing.Size(270, 27);
            this.sharpnessDirectShowPropertyControl.Name = "sharpnessDirectShowPropertyControl";
            this.sharpnessDirectShowPropertyControl.PropertyDescriptionText = "Sharpness:";
            this.sharpnessDirectShowPropertyControl.PropertyDescriptionWidth = 126F;
            this.sharpnessDirectShowPropertyControl.Size = new System.Drawing.Size(377, 27);
            this.sharpnessDirectShowPropertyControl.TabIndex = 41;
            this.sharpnessDirectShowPropertyControl.PropertyChanged += new System.EventHandler<DemosCommonCode.Imaging.DirectShowPropertyChangedEventArgs>(this.sharpnessDirectShowPropertyControl_PropertyChanged);
            // 
            // saturationDirectShowPropertyControl
            // 
            this.saturationDirectShowPropertyControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saturationDirectShowPropertyControl.Location = new System.Drawing.Point(6, 181);
            this.saturationDirectShowPropertyControl.MinimumSize = new System.Drawing.Size(270, 27);
            this.saturationDirectShowPropertyControl.Name = "saturationDirectShowPropertyControl";
            this.saturationDirectShowPropertyControl.PropertyDescriptionText = "Saturation:";
            this.saturationDirectShowPropertyControl.PropertyDescriptionWidth = 126F;
            this.saturationDirectShowPropertyControl.Size = new System.Drawing.Size(377, 27);
            this.saturationDirectShowPropertyControl.TabIndex = 40;
            this.saturationDirectShowPropertyControl.PropertyChanged += new System.EventHandler<DemosCommonCode.Imaging.DirectShowPropertyChangedEventArgs>(this.saturationDirectShowPropertyControl_PropertyChanged);
            // 
            // hueDirectShowPropertyControl
            // 
            this.hueDirectShowPropertyControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hueDirectShowPropertyControl.Location = new System.Drawing.Point(6, 158);
            this.hueDirectShowPropertyControl.MinimumSize = new System.Drawing.Size(270, 27);
            this.hueDirectShowPropertyControl.Name = "hueDirectShowPropertyControl";
            this.hueDirectShowPropertyControl.PropertyDescriptionText = "Hue:";
            this.hueDirectShowPropertyControl.PropertyDescriptionWidth = 126F;
            this.hueDirectShowPropertyControl.Size = new System.Drawing.Size(377, 27);
            this.hueDirectShowPropertyControl.TabIndex = 39;
            this.hueDirectShowPropertyControl.PropertyChanged += new System.EventHandler<DemosCommonCode.Imaging.DirectShowPropertyChangedEventArgs>(this.hueDirectShowPropertyControl_PropertyChanged);
            // 
            // gammaDirectShowPropertyControl
            // 
            this.gammaDirectShowPropertyControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gammaDirectShowPropertyControl.Location = new System.Drawing.Point(6, 135);
            this.gammaDirectShowPropertyControl.MinimumSize = new System.Drawing.Size(270, 27);
            this.gammaDirectShowPropertyControl.Name = "gammaDirectShowPropertyControl";
            this.gammaDirectShowPropertyControl.PropertyDescriptionText = "Gamma:";
            this.gammaDirectShowPropertyControl.PropertyDescriptionWidth = 126F;
            this.gammaDirectShowPropertyControl.Size = new System.Drawing.Size(377, 27);
            this.gammaDirectShowPropertyControl.TabIndex = 38;
            this.gammaDirectShowPropertyControl.PropertyChanged += new System.EventHandler<DemosCommonCode.Imaging.DirectShowPropertyChangedEventArgs>(this.gammaDirectShowPropertyControl_PropertyChanged);
            // 
            // gainDirectShowPropertyControl
            // 
            this.gainDirectShowPropertyControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gainDirectShowPropertyControl.Location = new System.Drawing.Point(6, 112);
            this.gainDirectShowPropertyControl.MinimumSize = new System.Drawing.Size(270, 27);
            this.gainDirectShowPropertyControl.Name = "gainDirectShowPropertyControl";
            this.gainDirectShowPropertyControl.PropertyDescriptionText = "Gain:";
            this.gainDirectShowPropertyControl.PropertyDescriptionWidth = 126F;
            this.gainDirectShowPropertyControl.Size = new System.Drawing.Size(377, 27);
            this.gainDirectShowPropertyControl.TabIndex = 37;
            this.gainDirectShowPropertyControl.PropertyChanged += new System.EventHandler<DemosCommonCode.Imaging.DirectShowPropertyChangedEventArgs>(this.gainDirectShowPropertyControl_PropertyChanged);
            // 
            // contrastDirectShowPropertyControl
            // 
            this.contrastDirectShowPropertyControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contrastDirectShowPropertyControl.Location = new System.Drawing.Point(6, 88);
            this.contrastDirectShowPropertyControl.MinimumSize = new System.Drawing.Size(270, 27);
            this.contrastDirectShowPropertyControl.Name = "contrastDirectShowPropertyControl";
            this.contrastDirectShowPropertyControl.PropertyDescriptionText = "Contrast:";
            this.contrastDirectShowPropertyControl.PropertyDescriptionWidth = 126F;
            this.contrastDirectShowPropertyControl.Size = new System.Drawing.Size(377, 27);
            this.contrastDirectShowPropertyControl.TabIndex = 36;
            this.contrastDirectShowPropertyControl.PropertyChanged += new System.EventHandler<DemosCommonCode.Imaging.DirectShowPropertyChangedEventArgs>(this.contrastDirectShowPropertyControl_PropertyChanged);
            // 
            // colorEnableDirectShowPropertyControl
            // 
            this.colorEnableDirectShowPropertyControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorEnableDirectShowPropertyControl.Location = new System.Drawing.Point(6, 65);
            this.colorEnableDirectShowPropertyControl.MinimumSize = new System.Drawing.Size(270, 27);
            this.colorEnableDirectShowPropertyControl.Name = "colorEnableDirectShowPropertyControl";
            this.colorEnableDirectShowPropertyControl.PropertyDescriptionText = "Color Enable:";
            this.colorEnableDirectShowPropertyControl.PropertyDescriptionWidth = 126F;
            this.colorEnableDirectShowPropertyControl.Size = new System.Drawing.Size(377, 27);
            this.colorEnableDirectShowPropertyControl.TabIndex = 35;
            this.colorEnableDirectShowPropertyControl.PropertyChanged += new System.EventHandler<DemosCommonCode.Imaging.DirectShowPropertyChangedEventArgs>(this.colorEnableDirectShowPropertyControl_PropertyChanged);
            // 
            // brightnessDirectShowPropertyControl
            // 
            this.brightnessDirectShowPropertyControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.brightnessDirectShowPropertyControl.Location = new System.Drawing.Point(6, 42);
            this.brightnessDirectShowPropertyControl.MinimumSize = new System.Drawing.Size(270, 27);
            this.brightnessDirectShowPropertyControl.Name = "brightnessDirectShowPropertyControl";
            this.brightnessDirectShowPropertyControl.PropertyDescriptionText = "Brightness:";
            this.brightnessDirectShowPropertyControl.PropertyDescriptionWidth = 126F;
            this.brightnessDirectShowPropertyControl.Size = new System.Drawing.Size(377, 27);
            this.brightnessDirectShowPropertyControl.TabIndex = 34;
            this.brightnessDirectShowPropertyControl.PropertyChanged += new System.EventHandler<DemosCommonCode.Imaging.DirectShowPropertyChangedEventArgs>(this.brightnessDirectShowPropertyControl_PropertyChanged);
            // 
            // backlightCompensationDirectShowPropertyControl
            // 
            this.backlightCompensationDirectShowPropertyControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.backlightCompensationDirectShowPropertyControl.Location = new System.Drawing.Point(6, 19);
            this.backlightCompensationDirectShowPropertyControl.MinimumSize = new System.Drawing.Size(270, 27);
            this.backlightCompensationDirectShowPropertyControl.Name = "backlightCompensationDirectShowPropertyControl";
            this.backlightCompensationDirectShowPropertyControl.PropertyDescriptionText = "Backlight compensation:";
            this.backlightCompensationDirectShowPropertyControl.PropertyDescriptionWidth = 126F;
            this.backlightCompensationDirectShowPropertyControl.Size = new System.Drawing.Size(377, 27);
            this.backlightCompensationDirectShowPropertyControl.TabIndex = 2;
            this.backlightCompensationDirectShowPropertyControl.PropertyChanged += new System.EventHandler<DemosCommonCode.Imaging.DirectShowPropertyChangedEventArgs>(this.backlightCompensationDirectShowPropertyControl_PropertyChanged);
            // 
            // restoreButton
            // 
            this.restoreButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.restoreButton.Location = new System.Drawing.Point(226, 260);
            this.restoreButton.Name = "restoreButton";
            this.restoreButton.Size = new System.Drawing.Size(75, 23);
            this.restoreButton.TabIndex = 33;
            this.restoreButton.Text = "Restore";
            this.restoreButton.UseVisualStyleBackColor = true;
            this.restoreButton.Click += new System.EventHandler(this.restoreButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.resetButton.Location = new System.Drawing.Point(307, 260);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 30;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // DirectShowImageQualityPropertiesControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.imageQualityPropertiesGroupBox);
            this.Name = "DirectShowImageQualityPropertiesControl";
            this.Size = new System.Drawing.Size(395, 298);
            this.Load += new System.EventHandler(this.DirectShowImageQualityPropertiesControl_Load);
            this.imageQualityPropertiesGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox imageQualityPropertiesGroupBox;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button restoreButton;
        private DirectShowPropertyControl backlightCompensationDirectShowPropertyControl;
        private DirectShowPropertyControl brightnessDirectShowPropertyControl;
        private DirectShowPropertyControl colorEnableDirectShowPropertyControl;
        private DirectShowPropertyControl contrastDirectShowPropertyControl;
        private DirectShowPropertyControl gainDirectShowPropertyControl;
        private DirectShowPropertyControl gammaDirectShowPropertyControl;
        private DirectShowPropertyControl hueDirectShowPropertyControl;
        private DirectShowPropertyControl saturationDirectShowPropertyControl;
        private DirectShowPropertyControl sharpnessDirectShowPropertyControl;
        private DirectShowPropertyControl whiteBalanceDirectShowPropertyControl;
    }
}