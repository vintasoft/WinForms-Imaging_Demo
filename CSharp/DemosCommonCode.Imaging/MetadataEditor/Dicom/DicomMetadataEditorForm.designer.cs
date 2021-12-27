namespace DemosCommonCode.Imaging
{
    partial class DicomMetadataEditorForm
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
            this.dicomMetadataEditorControl1 = new DemosCommonCode.Imaging.DicomMetadataEditorControl();
            this.SuspendLayout();
            // 
            // dicomMetadataEditorControl1
            // 
            this.dicomMetadataEditorControl1.CanEdit = true;
            this.dicomMetadataEditorControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dicomMetadataEditorControl1.Image = null;
            this.dicomMetadataEditorControl1.Location = new System.Drawing.Point(0, 0);
            this.dicomMetadataEditorControl1.Name = "dicomMetadataEditorControl1";
            this.dicomMetadataEditorControl1.RootMetadataNode = null;
            this.dicomMetadataEditorControl1.Size = new System.Drawing.Size(833, 554);
            this.dicomMetadataEditorControl1.TabIndex = 0;
            // 
            // DicomMetadataEditorForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 554);
            this.Controls.Add(this.dicomMetadataEditorControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "DicomMetadataEditorForm";
            this.Text = "DICOM Metadata Editor";
            this.ResumeLayout(false);

        }

        #endregion

        private DicomMetadataEditorControl dicomMetadataEditorControl1;
    }
}