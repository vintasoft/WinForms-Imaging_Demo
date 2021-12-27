namespace DemosCommonCode.Barcode
{
    partial class BarcodeReaderToolForm
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
            this.recognizeBarcodeButton = new System.Windows.Forms.Button();
            this.recognitionProgressBar = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.recognitionResultsTextBox = new System.Windows.Forms.TextBox();
            this.barcodeReaderSettingsControl1 = new BarcodeReaderSettingsControl();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // recognizeBarcodeButton
            // 
            this.recognizeBarcodeButton.Location = new System.Drawing.Point(5, 5);
            this.recognizeBarcodeButton.Name = "recognizeBarcodeButton";
            this.recognizeBarcodeButton.Size = new System.Drawing.Size(137, 28);
            this.recognizeBarcodeButton.TabIndex = 45;
            this.recognizeBarcodeButton.Text = "Recognize barcodes";
            this.recognizeBarcodeButton.UseVisualStyleBackColor = true;
            this.recognizeBarcodeButton.Click += new System.EventHandler(this.recognizeBarcodeButton_Click);
            // 
            // recognitionProgressBar
            // 
            this.recognitionProgressBar.Location = new System.Drawing.Point(148, 6);
            this.recognitionProgressBar.Name = "recognitionProgressBar";
            this.recognitionProgressBar.Size = new System.Drawing.Size(137, 26);
            this.recognitionProgressBar.TabIndex = 46;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.recognitionResultsTextBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 569);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 182);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recognition results";
            // 
            // recognitionResultsTextBox
            // 
            this.recognitionResultsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recognitionResultsTextBox.Location = new System.Drawing.Point(3, 16);
            this.recognitionResultsTextBox.Multiline = true;
            this.recognitionResultsTextBox.Name = "recognitionResultsTextBox";
            this.recognitionResultsTextBox.ReadOnly = true;
            this.recognitionResultsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.recognitionResultsTextBox.Size = new System.Drawing.Size(284, 163);
            this.recognitionResultsTextBox.TabIndex = 0;
            // 
            // barcodeReaderSettingsControl1
            // 
            this.barcodeReaderSettingsControl1.Location = new System.Drawing.Point(1, 37);
            this.barcodeReaderSettingsControl1.Name = "barcodeReaderSettingsControl1";
            this.barcodeReaderSettingsControl1.Size = new System.Drawing.Size(286, 530);
            this.barcodeReaderSettingsControl1.TabIndex = 48;
            // 
            // BarcodeReaderToolForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 751);
            this.Controls.Add(this.barcodeReaderSettingsControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.recognitionProgressBar);
            this.Controls.Add(this.recognizeBarcodeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(5, 70);
            this.MaximizeBox = false;
            this.Name = "BarcodeReaderToolForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "BarcodeReader Tool";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button recognizeBarcodeButton;
        private System.Windows.Forms.ProgressBar recognitionProgressBar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox recognitionResultsTextBox;
        private BarcodeReaderSettingsControl barcodeReaderSettingsControl1;
    }
}