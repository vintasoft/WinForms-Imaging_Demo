namespace DemosCommonCode.Imaging
{
    partial class MaxThreadsForm
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
            this.okButton = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.maxThreadsTrackBar = new System.Windows.Forms.TrackBar();
            this.maxThreadsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.resetButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.maxThreadsTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxThreadsNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(154, 58);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(235, 57);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // maxThreadsTrackBar
            // 
            this.maxThreadsTrackBar.Location = new System.Drawing.Point(3, 6);
            this.maxThreadsTrackBar.Maximum = 32;
            this.maxThreadsTrackBar.Minimum = 1;
            this.maxThreadsTrackBar.Name = "maxThreadsTrackBar";
            this.maxThreadsTrackBar.Size = new System.Drawing.Size(228, 45);
            this.maxThreadsTrackBar.TabIndex = 2;
            this.maxThreadsTrackBar.Value = 1;
            this.maxThreadsTrackBar.ValueChanged += new System.EventHandler(this.maxThreadsTrackBar_ValueChanged);
            // 
            // maxThreadsNumericUpDown
            // 
            this.maxThreadsNumericUpDown.Location = new System.Drawing.Point(236, 2);
            this.maxThreadsNumericUpDown.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.maxThreadsNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxThreadsNumericUpDown.Name = "maxThreadsNumericUpDown";
            this.maxThreadsNumericUpDown.Size = new System.Drawing.Size(73, 20);
            this.maxThreadsNumericUpDown.TabIndex = 3;
            this.maxThreadsNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxThreadsNumericUpDown.ValueChanged += new System.EventHandler(this.maxThreadsNumericUpDown_ValueChanged);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(235, 24);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 4;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // ImagingEnvironmentMaxThreadsForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(316, 86);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.maxThreadsNumericUpDown);
            this.Controls.Add(this.maxThreadsTrackBar);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImagingEnvironmentMaxThreadsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImagingEnvironment.MaxThreads property";
            ((System.ComponentModel.ISupportInitialize)(this.maxThreadsTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxThreadsNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TrackBar maxThreadsTrackBar;
        private System.Windows.Forms.NumericUpDown maxThreadsNumericUpDown;
        private System.Windows.Forms.Button resetButton;
    }
}