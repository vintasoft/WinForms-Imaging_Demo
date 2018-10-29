namespace ImagingDemo.Barcode
{
    partial class BarcodeWriterToolForm
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
            this.barcodeWriterSettingsControl1 = new ImagingDemo.Barcode.BarcodeWriterSettingsControl();
            this.SuspendLayout();
            // 
            // barcodeWriterSettingsControl1
            // 
            this.barcodeWriterSettingsControl1.BarcodeWriterSettings = null;
            this.barcodeWriterSettingsControl1.Location = new System.Drawing.Point(4, 2);
            this.barcodeWriterSettingsControl1.Name = "barcodeWriterSettingsControl1";
            this.barcodeWriterSettingsControl1.Size = new System.Drawing.Size(277, 530);
            this.barcodeWriterSettingsControl1.TabIndex = 0;
            // 
            // BarcodeWriterToolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 537);
            this.Controls.Add(this.barcodeWriterSettingsControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "BarcodeWriterToolForm";
            this.Text = "BarcodeWriter Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private global::ImagingDemo.Barcode.BarcodeWriterSettingsControl barcodeWriterSettingsControl1;
    }
}