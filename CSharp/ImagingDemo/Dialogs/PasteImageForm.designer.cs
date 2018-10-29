namespace ImagingDemo
{
	partial class PasteImageForm
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
            this.xCoordLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.yCoordNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.xCoordNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.yCoordLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yCoordNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xCoordNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // xCoordLabel
            // 
            this.xCoordLabel.AutoSize = true;
            this.xCoordLabel.Location = new System.Drawing.Point(40, 17);
            this.xCoordLabel.Name = "xCoordLabel";
            this.xCoordLabel.Size = new System.Drawing.Size(70, 13);
            this.xCoordLabel.TabIndex = 0;
            this.xCoordLabel.Text = "X coordinate:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.yCoordNumericUpDown);
            this.groupBox1.Controls.Add(this.xCoordNumericUpDown);
            this.groupBox1.Controls.Add(this.yCoordLabel);
            this.groupBox1.Controls.Add(this.xCoordLabel);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 68);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Position";
            // 
            // yCoordNumericUpDown
            // 
            this.yCoordNumericUpDown.Location = new System.Drawing.Point(116, 39);
            this.yCoordNumericUpDown.Name = "yCoordNumericUpDown";
            this.yCoordNumericUpDown.Size = new System.Drawing.Size(100, 20);
            this.yCoordNumericUpDown.TabIndex = 5;
            // 
            // xCoordNumericUpDown
            // 
            this.xCoordNumericUpDown.Location = new System.Drawing.Point(116, 15);
            this.xCoordNumericUpDown.Name = "xCoordNumericUpDown";
            this.xCoordNumericUpDown.Size = new System.Drawing.Size(100, 20);
            this.xCoordNumericUpDown.TabIndex = 4;
            // 
            // yCoordLabel
            // 
            this.yCoordLabel.AutoSize = true;
            this.yCoordLabel.Location = new System.Drawing.Point(40, 39);
            this.yCoordLabel.Name = "yCoordLabel";
            this.yCoordLabel.Size = new System.Drawing.Size(70, 13);
            this.yCoordLabel.TabIndex = 1;
            this.yCoordLabel.Text = "Y coordinate:";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(58, 80);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(139, 80);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // PasteImageForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(272, 113);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PasteImageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Paste image";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yCoordNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xCoordNumericUpDown)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label xCoordLabel;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label yCoordLabel;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.NumericUpDown yCoordNumericUpDown;
		private System.Windows.Forms.NumericUpDown xCoordNumericUpDown;
	}
}