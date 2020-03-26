namespace ImagingDemo
{
	partial class ChangePixelFormatForm
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
            this.pixelFormatComboBox = new System.Windows.Forms.ComboBox();
            this.convertButton = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pixelFormatComboBox
            // 
            this.pixelFormatComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pixelFormatComboBox.FormattingEnabled = true;
            this.pixelFormatComboBox.Items.AddRange(new object[] {
            "1-bpp (Black-white)",
            "1-bpp (Palette)",
            "4-bpp",
            "8-bpp",
            "8-bpp (Grayscale)",
            "8-bpp (Web palette)",
            "16-bpp (Grayscale)",
            "16-bpp (RGB 555)",
            "16-bpp (RGB 565)",
            "24-bpp (RGB)",
            "32-bpp (ARGB)",
            "32-bpp (RGB)",
            "48-bpp (RGB)",
            "64-bpp (ARGB)"});
            this.pixelFormatComboBox.Location = new System.Drawing.Point(115, 9);
            this.pixelFormatComboBox.Name = "pixelFormatComboBox";
            this.pixelFormatComboBox.Size = new System.Drawing.Size(215, 21);
            this.pixelFormatComboBox.TabIndex = 0;
            // 
            // convertButton
            // 
            this.convertButton.Location = new System.Drawing.Point(104, 43);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(75, 23);
            this.convertButton.TabIndex = 1;
            this.convertButton.Text = "Convert";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.btOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(197, 43);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pixel format:";
            // 
            // ChangePixelFormatForm
            // 
            this.AcceptButton = this.convertButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(377, 76);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.convertButton);
            this.Controls.Add(this.pixelFormatComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePixelFormatForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change pixel format of the image";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox pixelFormatComboBox;
		private System.Windows.Forms.Button convertButton;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label label1;
	}
}