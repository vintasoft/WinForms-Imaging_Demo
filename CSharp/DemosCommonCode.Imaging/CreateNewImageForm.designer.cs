namespace DemosCommonCode.Imaging
{
    partial class CreateNewImageForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.heightImageNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.heightLabel = new System.Windows.Forms.Label();
            this.widthImageNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.widthLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.verticalResolutionTextBox = new System.Windows.Forms.TextBox();
            this.horizontalResolutionTextBox = new System.Windows.Forms.TextBox();
            this.verticalLabel = new System.Windows.Forms.Label();
            this.horizontalLabel = new System.Windows.Forms.Label();
            this.pixelFormatComboBox = new System.Windows.Forms.ComboBox();
            this.okButton = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.pixelFormatLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heightImageNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthImageNumericUpDown)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.heightImageNumericUpDown);
            this.groupBox1.Controls.Add(this.heightLabel);
            this.groupBox1.Controls.Add(this.widthImageNumericUpDown);
            this.groupBox1.Controls.Add(this.widthLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 48);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Size";
            // 
            // heightImageNumericUpDown
            // 
            this.heightImageNumericUpDown.Location = new System.Drawing.Point(212, 20);
            this.heightImageNumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.heightImageNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.heightImageNumericUpDown.Name = "heightImageNumericUpDown";
            this.heightImageNumericUpDown.Size = new System.Drawing.Size(90, 23);
            this.heightImageNumericUpDown.TabIndex = 3;
            this.heightImageNumericUpDown.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(164, 22);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(43, 15);
            this.heightLabel.TabIndex = 2;
            this.heightLabel.Text = "Height";
            // 
            // widthImageNumericUpDown
            // 
            this.widthImageNumericUpDown.Location = new System.Drawing.Point(68, 20);
            this.widthImageNumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.widthImageNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.widthImageNumericUpDown.Name = "widthImageNumericUpDown";
            this.widthImageNumericUpDown.Size = new System.Drawing.Size(90, 23);
            this.widthImageNumericUpDown.TabIndex = 1;
            this.widthImageNumericUpDown.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(8, 22);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(39, 15);
            this.widthLabel.TabIndex = 0;
            this.widthLabel.Text = "Width";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.verticalResolutionTextBox);
            this.groupBox2.Controls.Add(this.horizontalResolutionTextBox);
            this.groupBox2.Controls.Add(this.verticalLabel);
            this.groupBox2.Controls.Add(this.horizontalLabel);
            this.groupBox2.Location = new System.Drawing.Point(12, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(309, 48);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resolution";
            // 
            // verticalResolutionTextBox
            // 
            this.verticalResolutionTextBox.Location = new System.Drawing.Point(212, 18);
            this.verticalResolutionTextBox.Name = "verticalResolutionTextBox";
            this.verticalResolutionTextBox.Size = new System.Drawing.Size(90, 23);
            this.verticalResolutionTextBox.TabIndex = 5;
            // 
            // horizontalResolutionTextBox
            // 
            this.horizontalResolutionTextBox.Location = new System.Drawing.Point(69, 18);
            this.horizontalResolutionTextBox.Name = "horizontalResolutionTextBox";
            this.horizontalResolutionTextBox.Size = new System.Drawing.Size(89, 23);
            this.horizontalResolutionTextBox.TabIndex = 4;
            // 
            // verticalLabel
            // 
            this.verticalLabel.AutoSize = true;
            this.verticalLabel.Location = new System.Drawing.Point(164, 21);
            this.verticalLabel.Name = "verticalLabel";
            this.verticalLabel.Size = new System.Drawing.Size(45, 15);
            this.verticalLabel.TabIndex = 1;
            this.verticalLabel.Text = "Vertical";
            // 
            // horizontalLabel
            // 
            this.horizontalLabel.AutoSize = true;
            this.horizontalLabel.Location = new System.Drawing.Point(8, 21);
            this.horizontalLabel.Name = "horizontalLabel";
            this.horizontalLabel.Size = new System.Drawing.Size(62, 15);
            this.horizontalLabel.TabIndex = 0;
            this.horizontalLabel.Text = "Horizontal";
            // 
            // pixelFormatComboBox
            // 
            this.pixelFormatComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pixelFormatComboBox.FormattingEnabled = true;
            this.pixelFormatComboBox.Location = new System.Drawing.Point(97, 120);
            this.pixelFormatComboBox.Name = "pixelFormatComboBox";
            this.pixelFormatComboBox.Size = new System.Drawing.Size(224, 23);
            this.pixelFormatComboBox.TabIndex = 2;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(85, 147);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(166, 147);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // pixelFormatLabel
            // 
            this.pixelFormatLabel.AutoSize = true;
            this.pixelFormatLabel.Location = new System.Drawing.Point(20, 123);
            this.pixelFormatLabel.Name = "pixelFormatLabel";
            this.pixelFormatLabel.Size = new System.Drawing.Size(71, 15);
            this.pixelFormatLabel.TabIndex = 5;
            this.pixelFormatLabel.Text = "Pixel format";
            // 
            // CreateNewImageForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(326, 175);
            this.Controls.Add(this.pixelFormatLabel);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.pixelFormatComboBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateNewImageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create new image";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heightImageNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthImageNumericUpDown)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox pixelFormatComboBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.NumericUpDown heightImageNumericUpDown;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.NumericUpDown widthImageNumericUpDown;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.Label verticalLabel;
        private System.Windows.Forms.Label horizontalLabel;
        private System.Windows.Forms.Label pixelFormatLabel;
        private System.Windows.Forms.TextBox verticalResolutionTextBox;
        private System.Windows.Forms.TextBox horizontalResolutionTextBox;
    }
}