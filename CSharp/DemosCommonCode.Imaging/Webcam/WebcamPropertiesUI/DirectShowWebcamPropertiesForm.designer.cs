namespace DemosCommonCode.Imaging
{
    partial class DirectShowWebcamPropertiesForm
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
            this.directShowImageQualityPropertiesControl1 = new DemosCommonCode.Imaging.DirectShowImageQualityPropertiesControl();
            this.directShowCameraControlPropertiesControl1 = new DemosCommonCode.Imaging.DirectShowCameraControlPropertiesControl();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // directShowImageQualityPropertiesControl1
            // 
            this.directShowImageQualityPropertiesControl1.Camera = null;
            this.directShowImageQualityPropertiesControl1.Location = new System.Drawing.Point(6, 5);
            this.directShowImageQualityPropertiesControl1.Name = "directShowImageQualityPropertiesControl1";
            this.directShowImageQualityPropertiesControl1.Size = new System.Drawing.Size(395, 296);
            this.directShowImageQualityPropertiesControl1.TabIndex = 0;
            // 
            // directShowCameraControlPropertiesControl1
            // 
            this.directShowCameraControlPropertiesControl1.Camera = null;
            this.directShowCameraControlPropertiesControl1.Location = new System.Drawing.Point(405, 5);
            this.directShowCameraControlPropertiesControl1.Name = "directShowCameraControlPropertiesControl1";
            this.directShowCameraControlPropertiesControl1.Size = new System.Drawing.Size(395, 296);
            this.directShowCameraControlPropertiesControl1.TabIndex = 1;
            // 
            // closeButton
            // 
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(366, 307);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // DirectShowWebcamPropertiesForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(806, 342);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.directShowCameraControlPropertiesControl1);
            this.Controls.Add(this.directShowImageQualityPropertiesControl1);
            this.Name = "DirectShowWebcamPropertiesForm";
            this.ResumeLayout(false);

        }

        #endregion

        private DirectShowImageQualityPropertiesControl directShowImageQualityPropertiesControl1;
        private DirectShowCameraControlPropertiesControl directShowCameraControlPropertiesControl1;
        private System.Windows.Forms.Button closeButton;


    }
}