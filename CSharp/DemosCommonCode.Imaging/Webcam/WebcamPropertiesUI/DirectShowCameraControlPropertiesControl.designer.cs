namespace DemosCommonCode.Imaging
{
    partial class DirectShowCameraControlPropertiesControl
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
            this.cameraControlPropertiesGroupBox = new System.Windows.Forms.GroupBox();
            this.zoomDirectShowPropertyControl = new DemosCommonCode.Imaging.DirectShowPropertyControl();
            this.tiltDirectShowPropertyControl = new DemosCommonCode.Imaging.DirectShowPropertyControl();
            this.rollDirectShowPropertyControl = new DemosCommonCode.Imaging.DirectShowPropertyControl();
            this.panDirectShowPropertyControl = new DemosCommonCode.Imaging.DirectShowPropertyControl();
            this.irisDirectShowPropertyControl = new DemosCommonCode.Imaging.DirectShowPropertyControl();
            this.focusDirectShowPropertyControl = new DemosCommonCode.Imaging.DirectShowPropertyControl();
            this.exposureDirectShowPropertyControl = new DemosCommonCode.Imaging.DirectShowPropertyControl();
            this.restoreButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.cameraControlPropertiesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // cameraControlPropertiesGroupBox
            // 
            this.cameraControlPropertiesGroupBox.Controls.Add(this.zoomDirectShowPropertyControl);
            this.cameraControlPropertiesGroupBox.Controls.Add(this.tiltDirectShowPropertyControl);
            this.cameraControlPropertiesGroupBox.Controls.Add(this.rollDirectShowPropertyControl);
            this.cameraControlPropertiesGroupBox.Controls.Add(this.panDirectShowPropertyControl);
            this.cameraControlPropertiesGroupBox.Controls.Add(this.irisDirectShowPropertyControl);
            this.cameraControlPropertiesGroupBox.Controls.Add(this.focusDirectShowPropertyControl);
            this.cameraControlPropertiesGroupBox.Controls.Add(this.exposureDirectShowPropertyControl);
            this.cameraControlPropertiesGroupBox.Controls.Add(this.restoreButton);
            this.cameraControlPropertiesGroupBox.Controls.Add(this.resetButton);
            this.cameraControlPropertiesGroupBox.Location = new System.Drawing.Point(3, 3);
            this.cameraControlPropertiesGroupBox.Name = "cameraControlPropertiesGroupBox";
            this.cameraControlPropertiesGroupBox.Size = new System.Drawing.Size(389, 292);
            this.cameraControlPropertiesGroupBox.TabIndex = 1;
            this.cameraControlPropertiesGroupBox.TabStop = false;
            this.cameraControlPropertiesGroupBox.Text = "Camera Control Properties";
            // 
            // zoomDirectShowPropertyControl
            // 
            this.zoomDirectShowPropertyControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomDirectShowPropertyControl.Location = new System.Drawing.Point(7, 163);
            this.zoomDirectShowPropertyControl.MinimumSize = new System.Drawing.Size(270, 27);
            this.zoomDirectShowPropertyControl.Name = "zoomDirectShowPropertyControl";
            this.zoomDirectShowPropertyControl.PropertyDescriptionText = "Zoom:";
            this.zoomDirectShowPropertyControl.PropertyDescriptionWidth = 114F;
            this.zoomDirectShowPropertyControl.Size = new System.Drawing.Size(376, 27);
            this.zoomDirectShowPropertyControl.TabIndex = 39;
            this.zoomDirectShowPropertyControl.PropertyChanged += new System.EventHandler<DemosCommonCode.Imaging.DirectShowPropertyChangedEventArgs>(this.zoomDirectShowPropertyControl_PropertyChanged);
            // 
            // tiltDirectShowPropertyControl
            // 
            this.tiltDirectShowPropertyControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tiltDirectShowPropertyControl.Location = new System.Drawing.Point(7, 138);
            this.tiltDirectShowPropertyControl.MinimumSize = new System.Drawing.Size(270, 27);
            this.tiltDirectShowPropertyControl.Name = "tiltDirectShowPropertyControl";
            this.tiltDirectShowPropertyControl.PropertyDescriptionText = "Tilt:";
            this.tiltDirectShowPropertyControl.PropertyDescriptionWidth = 114F;
            this.tiltDirectShowPropertyControl.Size = new System.Drawing.Size(376, 27);
            this.tiltDirectShowPropertyControl.TabIndex = 38;
            this.tiltDirectShowPropertyControl.PropertyChanged += new System.EventHandler<DemosCommonCode.Imaging.DirectShowPropertyChangedEventArgs>(this.tiltDirectShowPropertyControl_PropertyChanged);
            // 
            // rollDirectShowPropertyControl
            // 
            this.rollDirectShowPropertyControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rollDirectShowPropertyControl.Location = new System.Drawing.Point(7, 113);
            this.rollDirectShowPropertyControl.MinimumSize = new System.Drawing.Size(270, 27);
            this.rollDirectShowPropertyControl.Name = "rollDirectShowPropertyControl";
            this.rollDirectShowPropertyControl.PropertyDescriptionText = "Roll:";
            this.rollDirectShowPropertyControl.PropertyDescriptionWidth = 114F;
            this.rollDirectShowPropertyControl.Size = new System.Drawing.Size(376, 27);
            this.rollDirectShowPropertyControl.TabIndex = 37;
            this.rollDirectShowPropertyControl.PropertyChanged += new System.EventHandler<DemosCommonCode.Imaging.DirectShowPropertyChangedEventArgs>(this.rollDirectShowPropertyControl_PropertyChanged);
            // 
            // panDirectShowPropertyControl
            // 
            this.panDirectShowPropertyControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panDirectShowPropertyControl.Location = new System.Drawing.Point(7, 88);
            this.panDirectShowPropertyControl.MinimumSize = new System.Drawing.Size(270, 27);
            this.panDirectShowPropertyControl.Name = "panDirectShowPropertyControl";
            this.panDirectShowPropertyControl.PropertyDescriptionText = "Pan:";
            this.panDirectShowPropertyControl.PropertyDescriptionWidth = 114F;
            this.panDirectShowPropertyControl.Size = new System.Drawing.Size(376, 27);
            this.panDirectShowPropertyControl.TabIndex = 36;
            this.panDirectShowPropertyControl.PropertyChanged += new System.EventHandler<DemosCommonCode.Imaging.DirectShowPropertyChangedEventArgs>(this.panDirectShowPropertyControl_PropertyChanged);
            // 
            // irisDirectShowPropertyControl
            // 
            this.irisDirectShowPropertyControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.irisDirectShowPropertyControl.Location = new System.Drawing.Point(7, 63);
            this.irisDirectShowPropertyControl.MinimumSize = new System.Drawing.Size(270, 27);
            this.irisDirectShowPropertyControl.Name = "irisDirectShowPropertyControl";
            this.irisDirectShowPropertyControl.PropertyDescriptionText = "Iris:";
            this.irisDirectShowPropertyControl.PropertyDescriptionWidth = 114F;
            this.irisDirectShowPropertyControl.Size = new System.Drawing.Size(376, 27);
            this.irisDirectShowPropertyControl.TabIndex = 35;
            this.irisDirectShowPropertyControl.PropertyChanged += new System.EventHandler<DemosCommonCode.Imaging.DirectShowPropertyChangedEventArgs>(this.irisDirectShowPropertyControl_PropertyChanged);
            // 
            // focusDirectShowPropertyControl
            // 
            this.focusDirectShowPropertyControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.focusDirectShowPropertyControl.Location = new System.Drawing.Point(7, 38);
            this.focusDirectShowPropertyControl.MinimumSize = new System.Drawing.Size(270, 27);
            this.focusDirectShowPropertyControl.Name = "focusDirectShowPropertyControl";
            this.focusDirectShowPropertyControl.PropertyDescriptionText = "Focus:";
            this.focusDirectShowPropertyControl.PropertyDescriptionWidth = 114F;
            this.focusDirectShowPropertyControl.Size = new System.Drawing.Size(376, 27);
            this.focusDirectShowPropertyControl.TabIndex = 34;
            this.focusDirectShowPropertyControl.PropertyChanged += new System.EventHandler<DemosCommonCode.Imaging.DirectShowPropertyChangedEventArgs>(this.focusDirectShowPropertyControl_PropertyChanged);
            // 
            // exposureDirectShowPropertyControl
            // 
            this.exposureDirectShowPropertyControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.exposureDirectShowPropertyControl.Location = new System.Drawing.Point(7, 13);
            this.exposureDirectShowPropertyControl.MinimumSize = new System.Drawing.Size(270, 27);
            this.exposureDirectShowPropertyControl.Name = "exposureDirectShowPropertyControl";
            this.exposureDirectShowPropertyControl.PropertyDescriptionText = "Exposure:";
            this.exposureDirectShowPropertyControl.PropertyDescriptionWidth = 114F;
            this.exposureDirectShowPropertyControl.Size = new System.Drawing.Size(376, 27);
            this.exposureDirectShowPropertyControl.TabIndex = 33;
            this.exposureDirectShowPropertyControl.PropertyChanged += new System.EventHandler<DemosCommonCode.Imaging.DirectShowPropertyChangedEventArgs>(this.exposureDirectShowPropertyControl_PropertyChanged);
            // 
            // restoreButton
            // 
            this.restoreButton.Location = new System.Drawing.Point(226, 260);
            this.restoreButton.Name = "restoreButton";
            this.restoreButton.Size = new System.Drawing.Size(75, 23);
            this.restoreButton.TabIndex = 32;
            this.restoreButton.Text = "Restore";
            this.restoreButton.UseVisualStyleBackColor = true;
            this.restoreButton.Click += new System.EventHandler(this.restoreButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(307, 260);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 31;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // DirectShowCameraControlPropertiesControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cameraControlPropertiesGroupBox);
            this.Name = "DirectShowCameraControlPropertiesControl";
            this.Size = new System.Drawing.Size(395, 298);
            this.Load += new System.EventHandler(this.DirectShowCameraControlPropertiesControl_Load);
            this.cameraControlPropertiesGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox cameraControlPropertiesGroupBox;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button restoreButton;
        private DirectShowPropertyControl exposureDirectShowPropertyControl;
        private DirectShowPropertyControl focusDirectShowPropertyControl;
        private DirectShowPropertyControl irisDirectShowPropertyControl;
        private DirectShowPropertyControl panDirectShowPropertyControl;
        private DirectShowPropertyControl rollDirectShowPropertyControl;
        private DirectShowPropertyControl tiltDirectShowPropertyControl;
        private DirectShowPropertyControl zoomDirectShowPropertyControl;
    }
}