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
            this.resetButton = new System.Windows.Forms.Button();
            this.zoomCheckBox = new System.Windows.Forms.CheckBox();
            this.tiltCheckBox = new System.Windows.Forms.CheckBox();
            this.rollCheckBox = new System.Windows.Forms.CheckBox();
            this.panCheckBox = new System.Windows.Forms.CheckBox();
            this.irisCheckBox = new System.Windows.Forms.CheckBox();
            this.focusCheckBox = new System.Windows.Forms.CheckBox();
            this.exposureCheckBox = new System.Windows.Forms.CheckBox();
            this.tiltTrackBar = new System.Windows.Forms.TrackBar();
            this.tiltLabel = new System.Windows.Forms.Label();
            this.exposureTrackBar = new System.Windows.Forms.TrackBar();
            this.exposureLabel = new System.Windows.Forms.Label();
            this.irisTrackBar = new System.Windows.Forms.TrackBar();
            this.irisLabel = new System.Windows.Forms.Label();
            this.panTrackBar = new System.Windows.Forms.TrackBar();
            this.panLabel = new System.Windows.Forms.Label();
            this.zoomTrackBar = new System.Windows.Forms.TrackBar();
            this.zoomLabel = new System.Windows.Forms.Label();
            this.rollTrackBar = new System.Windows.Forms.TrackBar();
            this.rollLabel = new System.Windows.Forms.Label();
            this.focusTrackBar = new System.Windows.Forms.TrackBar();
            this.focusLabel = new System.Windows.Forms.Label();
            this.restoreButton = new System.Windows.Forms.Button();
            this.cameraControlPropertiesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tiltTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exposureTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.irisTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rollTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // cameraControlPropertiesGroupBox
            // 
            this.cameraControlPropertiesGroupBox.Controls.Add(this.restoreButton);
            this.cameraControlPropertiesGroupBox.Controls.Add(this.resetButton);
            this.cameraControlPropertiesGroupBox.Controls.Add(this.zoomCheckBox);
            this.cameraControlPropertiesGroupBox.Controls.Add(this.tiltCheckBox);
            this.cameraControlPropertiesGroupBox.Controls.Add(this.rollCheckBox);
            this.cameraControlPropertiesGroupBox.Controls.Add(this.panCheckBox);
            this.cameraControlPropertiesGroupBox.Controls.Add(this.irisCheckBox);
            this.cameraControlPropertiesGroupBox.Controls.Add(this.focusCheckBox);
            this.cameraControlPropertiesGroupBox.Controls.Add(this.exposureCheckBox);
            this.cameraControlPropertiesGroupBox.Controls.Add(this.tiltTrackBar);
            this.cameraControlPropertiesGroupBox.Controls.Add(this.tiltLabel);
            this.cameraControlPropertiesGroupBox.Controls.Add(this.exposureTrackBar);
            this.cameraControlPropertiesGroupBox.Controls.Add(this.exposureLabel);
            this.cameraControlPropertiesGroupBox.Controls.Add(this.irisTrackBar);
            this.cameraControlPropertiesGroupBox.Controls.Add(this.irisLabel);
            this.cameraControlPropertiesGroupBox.Controls.Add(this.panTrackBar);
            this.cameraControlPropertiesGroupBox.Controls.Add(this.panLabel);
            this.cameraControlPropertiesGroupBox.Controls.Add(this.zoomTrackBar);
            this.cameraControlPropertiesGroupBox.Controls.Add(this.zoomLabel);
            this.cameraControlPropertiesGroupBox.Controls.Add(this.rollTrackBar);
            this.cameraControlPropertiesGroupBox.Controls.Add(this.rollLabel);
            this.cameraControlPropertiesGroupBox.Controls.Add(this.focusTrackBar);
            this.cameraControlPropertiesGroupBox.Controls.Add(this.focusLabel);
            this.cameraControlPropertiesGroupBox.Location = new System.Drawing.Point(3, 3);
            this.cameraControlPropertiesGroupBox.Name = "cameraControlPropertiesGroupBox";
            this.cameraControlPropertiesGroupBox.Size = new System.Drawing.Size(389, 292);
            this.cameraControlPropertiesGroupBox.TabIndex = 1;
            this.cameraControlPropertiesGroupBox.TabStop = false;
            this.cameraControlPropertiesGroupBox.Text = "Camera Control Properties";
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
            // zoomCheckBox
            // 
            this.zoomCheckBox.AutoSize = true;
            this.zoomCheckBox.Location = new System.Drawing.Point(334, 165);
            this.zoomCheckBox.Name = "zoomCheckBox";
            this.zoomCheckBox.Size = new System.Drawing.Size(48, 17);
            this.zoomCheckBox.TabIndex = 26;
            this.zoomCheckBox.Text = "Auto";
            this.zoomCheckBox.UseVisualStyleBackColor = true;
            this.zoomCheckBox.CheckedChanged += new System.EventHandler(this.zoomCheckBox_CheckedChanged);
            // 
            // tiltCheckBox
            // 
            this.tiltCheckBox.AutoSize = true;
            this.tiltCheckBox.Location = new System.Drawing.Point(335, 141);
            this.tiltCheckBox.Name = "tiltCheckBox";
            this.tiltCheckBox.Size = new System.Drawing.Size(48, 17);
            this.tiltCheckBox.TabIndex = 25;
            this.tiltCheckBox.Text = "Auto";
            this.tiltCheckBox.UseVisualStyleBackColor = true;
            this.tiltCheckBox.CheckedChanged += new System.EventHandler(this.tiltCheckBox_CheckedChanged);
            // 
            // rollCheckBox
            // 
            this.rollCheckBox.AutoSize = true;
            this.rollCheckBox.Location = new System.Drawing.Point(334, 118);
            this.rollCheckBox.Name = "rollCheckBox";
            this.rollCheckBox.Size = new System.Drawing.Size(48, 17);
            this.rollCheckBox.TabIndex = 24;
            this.rollCheckBox.Text = "Auto";
            this.rollCheckBox.UseVisualStyleBackColor = true;
            this.rollCheckBox.CheckedChanged += new System.EventHandler(this.rollCheckBox_CheckedChanged);
            // 
            // panCheckBox
            // 
            this.panCheckBox.AutoSize = true;
            this.panCheckBox.Location = new System.Drawing.Point(334, 94);
            this.panCheckBox.Name = "panCheckBox";
            this.panCheckBox.Size = new System.Drawing.Size(48, 17);
            this.panCheckBox.TabIndex = 23;
            this.panCheckBox.Text = "Auto";
            this.panCheckBox.UseVisualStyleBackColor = true;
            this.panCheckBox.CheckedChanged += new System.EventHandler(this.panCheckBox_CheckedChanged);
            // 
            // irisCheckBox
            // 
            this.irisCheckBox.AutoSize = true;
            this.irisCheckBox.Location = new System.Drawing.Point(334, 70);
            this.irisCheckBox.Name = "irisCheckBox";
            this.irisCheckBox.Size = new System.Drawing.Size(48, 17);
            this.irisCheckBox.TabIndex = 22;
            this.irisCheckBox.Text = "Auto";
            this.irisCheckBox.UseVisualStyleBackColor = true;
            this.irisCheckBox.CheckedChanged += new System.EventHandler(this.irisCheckBox_CheckedChanged);
            // 
            // focusCheckBox
            // 
            this.focusCheckBox.AutoSize = true;
            this.focusCheckBox.Location = new System.Drawing.Point(334, 46);
            this.focusCheckBox.Name = "focusCheckBox";
            this.focusCheckBox.Size = new System.Drawing.Size(48, 17);
            this.focusCheckBox.TabIndex = 21;
            this.focusCheckBox.Text = "Auto";
            this.focusCheckBox.UseVisualStyleBackColor = true;
            this.focusCheckBox.CheckedChanged += new System.EventHandler(this.focusCheckBox_CheckedChanged);
            // 
            // exposureCheckBox
            // 
            this.exposureCheckBox.AutoSize = true;
            this.exposureCheckBox.Location = new System.Drawing.Point(334, 22);
            this.exposureCheckBox.Name = "exposureCheckBox";
            this.exposureCheckBox.Size = new System.Drawing.Size(48, 17);
            this.exposureCheckBox.TabIndex = 20;
            this.exposureCheckBox.Text = "Auto";
            this.exposureCheckBox.UseVisualStyleBackColor = true;
            this.exposureCheckBox.CheckedChanged += new System.EventHandler(this.exposureCheckBox_CheckedChanged);
            // 
            // tiltTrackBar
            // 
            this.tiltTrackBar.AutoSize = false;
            this.tiltTrackBar.Location = new System.Drawing.Point(133, 140);
            this.tiltTrackBar.Name = "tiltTrackBar";
            this.tiltTrackBar.Size = new System.Drawing.Size(201, 21);
            this.tiltTrackBar.TabIndex = 19;
            this.tiltTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tiltTrackBar.Scroll += new System.EventHandler(this.tiltTrackBar_Scroll);
            // 
            // tiltLabel
            // 
            this.tiltLabel.AutoSize = true;
            this.tiltLabel.Location = new System.Drawing.Point(9, 143);
            this.tiltLabel.Name = "tiltLabel";
            this.tiltLabel.Size = new System.Drawing.Size(24, 13);
            this.tiltLabel.TabIndex = 18;
            this.tiltLabel.Text = "Tilt:";
            // 
            // exposureTrackBar
            // 
            this.exposureTrackBar.AutoSize = false;
            this.exposureTrackBar.Location = new System.Drawing.Point(133, 20);
            this.exposureTrackBar.Name = "exposureTrackBar";
            this.exposureTrackBar.Size = new System.Drawing.Size(201, 21);
            this.exposureTrackBar.TabIndex = 17;
            this.exposureTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.exposureTrackBar.Scroll += new System.EventHandler(this.exposureTrackBar_Scroll);
            // 
            // exposureLabel
            // 
            this.exposureLabel.AutoSize = true;
            this.exposureLabel.Location = new System.Drawing.Point(9, 23);
            this.exposureLabel.Name = "exposureLabel";
            this.exposureLabel.Size = new System.Drawing.Size(54, 13);
            this.exposureLabel.TabIndex = 16;
            this.exposureLabel.Text = "Exposure:";
            // 
            // irisTrackBar
            // 
            this.irisTrackBar.AutoSize = false;
            this.irisTrackBar.Location = new System.Drawing.Point(133, 68);
            this.irisTrackBar.Name = "irisTrackBar";
            this.irisTrackBar.Size = new System.Drawing.Size(201, 21);
            this.irisTrackBar.TabIndex = 15;
            this.irisTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.irisTrackBar.Scroll += new System.EventHandler(this.irisTrackBar_Scroll);
            // 
            // irisLabel
            // 
            this.irisLabel.AutoSize = true;
            this.irisLabel.Location = new System.Drawing.Point(9, 71);
            this.irisLabel.Name = "irisLabel";
            this.irisLabel.Size = new System.Drawing.Size(23, 13);
            this.irisLabel.TabIndex = 14;
            this.irisLabel.Text = "Iris:";
            // 
            // panTrackBar
            // 
            this.panTrackBar.AutoSize = false;
            this.panTrackBar.Location = new System.Drawing.Point(133, 92);
            this.panTrackBar.Name = "panTrackBar";
            this.panTrackBar.Size = new System.Drawing.Size(201, 21);
            this.panTrackBar.TabIndex = 13;
            this.panTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.panTrackBar.Scroll += new System.EventHandler(this.panTrackBar_Scroll);
            // 
            // panLabel
            // 
            this.panLabel.AutoSize = true;
            this.panLabel.Location = new System.Drawing.Point(9, 95);
            this.panLabel.Name = "panLabel";
            this.panLabel.Size = new System.Drawing.Size(29, 13);
            this.panLabel.TabIndex = 12;
            this.panLabel.Text = "Pan:";
            // 
            // zoomTrackBar
            // 
            this.zoomTrackBar.AutoSize = false;
            this.zoomTrackBar.Location = new System.Drawing.Point(133, 164);
            this.zoomTrackBar.Name = "zoomTrackBar";
            this.zoomTrackBar.Size = new System.Drawing.Size(201, 21);
            this.zoomTrackBar.TabIndex = 5;
            this.zoomTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.zoomTrackBar.Scroll += new System.EventHandler(this.zoomTrackBar_Scroll);
            // 
            // zoomLabel
            // 
            this.zoomLabel.AutoSize = true;
            this.zoomLabel.Location = new System.Drawing.Point(9, 167);
            this.zoomLabel.Name = "zoomLabel";
            this.zoomLabel.Size = new System.Drawing.Size(37, 13);
            this.zoomLabel.TabIndex = 4;
            this.zoomLabel.Text = "Zoom:";
            // 
            // rollTrackBar
            // 
            this.rollTrackBar.AutoSize = false;
            this.rollTrackBar.Location = new System.Drawing.Point(133, 116);
            this.rollTrackBar.Name = "rollTrackBar";
            this.rollTrackBar.Size = new System.Drawing.Size(201, 21);
            this.rollTrackBar.TabIndex = 3;
            this.rollTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.rollTrackBar.Scroll += new System.EventHandler(this.rollTrackBar_Scroll);
            // 
            // rollLabel
            // 
            this.rollLabel.AutoSize = true;
            this.rollLabel.Location = new System.Drawing.Point(9, 119);
            this.rollLabel.Name = "rollLabel";
            this.rollLabel.Size = new System.Drawing.Size(28, 13);
            this.rollLabel.TabIndex = 2;
            this.rollLabel.Text = "Roll:";
            // 
            // focusTrackBar
            // 
            this.focusTrackBar.AutoSize = false;
            this.focusTrackBar.Location = new System.Drawing.Point(133, 44);
            this.focusTrackBar.Name = "focusTrackBar";
            this.focusTrackBar.Size = new System.Drawing.Size(201, 21);
            this.focusTrackBar.TabIndex = 1;
            this.focusTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.focusTrackBar.Scroll += new System.EventHandler(this.focusTrackBar_Scroll);
            // 
            // focusLabel
            // 
            this.focusLabel.AutoSize = true;
            this.focusLabel.Location = new System.Drawing.Point(9, 47);
            this.focusLabel.Name = "focusLabel";
            this.focusLabel.Size = new System.Drawing.Size(39, 13);
            this.focusLabel.TabIndex = 0;
            this.focusLabel.Text = "Focus:";
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
            // DirectShowCameraControlPropertiesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cameraControlPropertiesGroupBox);
            this.Name = "DirectShowCameraControlPropertiesControl";
            this.Size = new System.Drawing.Size(395, 298);
            this.Load += new System.EventHandler(this.DirectShowCameraControlPropertiesControl_Load);
            this.cameraControlPropertiesGroupBox.ResumeLayout(false);
            this.cameraControlPropertiesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tiltTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exposureTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.irisTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rollTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox cameraControlPropertiesGroupBox;
        private System.Windows.Forms.CheckBox zoomCheckBox;
        private System.Windows.Forms.CheckBox tiltCheckBox;
        private System.Windows.Forms.CheckBox rollCheckBox;
        private System.Windows.Forms.CheckBox panCheckBox;
        private System.Windows.Forms.CheckBox irisCheckBox;
        private System.Windows.Forms.CheckBox focusCheckBox;
        private System.Windows.Forms.CheckBox exposureCheckBox;
        private System.Windows.Forms.TrackBar tiltTrackBar;
        private System.Windows.Forms.Label tiltLabel;
        private System.Windows.Forms.TrackBar exposureTrackBar;
        private System.Windows.Forms.Label exposureLabel;
        private System.Windows.Forms.TrackBar irisTrackBar;
        private System.Windows.Forms.Label irisLabel;
        private System.Windows.Forms.TrackBar panTrackBar;
        private System.Windows.Forms.Label panLabel;
        private System.Windows.Forms.TrackBar zoomTrackBar;
        private System.Windows.Forms.Label zoomLabel;
        private System.Windows.Forms.TrackBar rollTrackBar;
        private System.Windows.Forms.Label rollLabel;
        private System.Windows.Forms.TrackBar focusTrackBar;
        private System.Windows.Forms.Label focusLabel;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button restoreButton;
    }
}
