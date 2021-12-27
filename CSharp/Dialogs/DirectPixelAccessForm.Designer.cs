namespace ImagingDemo
{
    partial class DirectPixelAccessForm
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
            this.pixelsGroupBox = new System.Windows.Forms.GroupBox();
            this.selectedPixelColorPanel = new System.Windows.Forms.Panel();
            this.selectedPixelLabel = new System.Windows.Forms.Label();
            this.argbPanel = new System.Windows.Forms.Panel();
            this.changeRGBComponentsButton = new System.Windows.Forms.Button();
            this.rgbColorTypeLabel = new System.Windows.Forms.Label();
            this.blueNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.greenNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.redNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.alphaNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.gray16Panel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.gray16LumNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.indexedPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.indexNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.selectInPaletteButton = new System.Windows.Forms.Button();
            this.pixelsGroupBox.SuspendLayout();
            this.argbPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blueNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alphaNumericUpDown)).BeginInit();
            this.gray16Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gray16LumNumericUpDown)).BeginInit();
            this.indexedPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.indexNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // pixelsGroupBox
            // 
            this.pixelsGroupBox.Controls.Add(this.selectedPixelColorPanel);
            this.pixelsGroupBox.Controls.Add(this.selectedPixelLabel);
            this.pixelsGroupBox.Controls.Add(this.argbPanel);
            this.pixelsGroupBox.Controls.Add(this.gray16Panel);
            this.pixelsGroupBox.Controls.Add(this.indexedPanel);
            this.pixelsGroupBox.Location = new System.Drawing.Point(0, 2);
            this.pixelsGroupBox.Name = "pixelsGroupBox";
            this.pixelsGroupBox.Size = new System.Drawing.Size(376, 66);
            this.pixelsGroupBox.TabIndex = 5;
            this.pixelsGroupBox.TabStop = false;
            this.pixelsGroupBox.Text = "Pixels";
            // 
            // selectedPixelColorPanel
            // 
            this.selectedPixelColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectedPixelColorPanel.Location = new System.Drawing.Point(327, 16);
            this.selectedPixelColorPanel.Name = "selectedPixelColorPanel";
            this.selectedPixelColorPanel.Size = new System.Drawing.Size(43, 40);
            this.selectedPixelColorPanel.TabIndex = 11;
            // 
            // selectedPixelLabel
            // 
            this.selectedPixelLabel.AutoSize = true;
            this.selectedPixelLabel.Location = new System.Drawing.Point(3, 16);
            this.selectedPixelLabel.Name = "selectedPixelLabel";
            this.selectedPixelLabel.Size = new System.Drawing.Size(191, 13);
            this.selectedPixelLabel.TabIndex = 8;
            this.selectedPixelLabel.Text = "Selected Pixel: click on image to select";
            // 
            // argbPanel
            // 
            this.argbPanel.Controls.Add(this.changeRGBComponentsButton);
            this.argbPanel.Controls.Add(this.rgbColorTypeLabel);
            this.argbPanel.Controls.Add(this.blueNumericUpDown);
            this.argbPanel.Controls.Add(this.greenNumericUpDown);
            this.argbPanel.Controls.Add(this.redNumericUpDown);
            this.argbPanel.Controls.Add(this.alphaNumericUpDown);
            this.argbPanel.Location = new System.Drawing.Point(6, 32);
            this.argbPanel.Name = "argbPanel";
            this.argbPanel.Size = new System.Drawing.Size(315, 28);
            this.argbPanel.TabIndex = 9;
            this.argbPanel.Visible = false;
            // 
            // changeRGBComponentsButton
            // 
            this.changeRGBComponentsButton.Location = new System.Drawing.Point(279, 4);
            this.changeRGBComponentsButton.Name = "changeRGBComponentsButton";
            this.changeRGBComponentsButton.Size = new System.Drawing.Size(36, 20);
            this.changeRGBComponentsButton.TabIndex = 13;
            this.changeRGBComponentsButton.Text = "...";
            this.changeRGBComponentsButton.UseVisualStyleBackColor = true;
            this.changeRGBComponentsButton.Click += new System.EventHandler(this.changeRGBComponentsButton_Click);
            // 
            // rgbColorTypeLabel
            // 
            this.rgbColorTypeLabel.AutoSize = true;
            this.rgbColorTypeLabel.Location = new System.Drawing.Point(-3, 8);
            this.rgbColorTypeLabel.Name = "rgbColorTypeLabel";
            this.rgbColorTypeLabel.Size = new System.Drawing.Size(58, 13);
            this.rgbColorTypeLabel.TabIndex = 12;
            this.rgbColorTypeLabel.Text = "ARGB32 =";
            // 
            // blueNumericUpDown
            // 
            this.blueNumericUpDown.Location = new System.Drawing.Point(225, 4);
            this.blueNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.blueNumericUpDown.Name = "blueNumericUpDown";
            this.blueNumericUpDown.Size = new System.Drawing.Size(52, 20);
            this.blueNumericUpDown.TabIndex = 7;
            this.blueNumericUpDown.ValueChanged += new System.EventHandler(this.colorChannel_ValueChanged);
            // 
            // greenNumericUpDown
            // 
            this.greenNumericUpDown.Location = new System.Drawing.Point(169, 4);
            this.greenNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.greenNumericUpDown.Name = "greenNumericUpDown";
            this.greenNumericUpDown.Size = new System.Drawing.Size(52, 20);
            this.greenNumericUpDown.TabIndex = 6;
            this.greenNumericUpDown.ValueChanged += new System.EventHandler(this.colorChannel_ValueChanged);
            // 
            // redNumericUpDown
            // 
            this.redNumericUpDown.Location = new System.Drawing.Point(113, 4);
            this.redNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.redNumericUpDown.Name = "redNumericUpDown";
            this.redNumericUpDown.Size = new System.Drawing.Size(52, 20);
            this.redNumericUpDown.TabIndex = 5;
            this.redNumericUpDown.ValueChanged += new System.EventHandler(this.colorChannel_ValueChanged);
            // 
            // alphaNumericUpDown
            // 
            this.alphaNumericUpDown.Location = new System.Drawing.Point(57, 4);
            this.alphaNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.alphaNumericUpDown.Name = "alphaNumericUpDown";
            this.alphaNumericUpDown.Size = new System.Drawing.Size(52, 20);
            this.alphaNumericUpDown.TabIndex = 4;
            this.alphaNumericUpDown.ValueChanged += new System.EventHandler(this.colorChannel_ValueChanged);
            // 
            // gray16Panel
            // 
            this.gray16Panel.Controls.Add(this.label5);
            this.gray16Panel.Controls.Add(this.gray16LumNumericUpDown);
            this.gray16Panel.Location = new System.Drawing.Point(6, 32);
            this.gray16Panel.Name = "gray16Panel";
            this.gray16Panel.Size = new System.Drawing.Size(304, 28);
            this.gray16Panel.TabIndex = 12;
            this.gray16Panel.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-3, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Luminance";
            // 
            // gray16LumNumericUpDown
            // 
            this.gray16LumNumericUpDown.Location = new System.Drawing.Point(72, 4);
            this.gray16LumNumericUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.gray16LumNumericUpDown.Name = "gray16LumNumericUpDown";
            this.gray16LumNumericUpDown.Size = new System.Drawing.Size(78, 20);
            this.gray16LumNumericUpDown.TabIndex = 2;
            this.gray16LumNumericUpDown.ValueChanged += new System.EventHandler(this.gray16LumNumericUpDown_ValueChanged);
            // 
            // indexedPanel
            // 
            this.indexedPanel.Controls.Add(this.label1);
            this.indexedPanel.Controls.Add(this.indexNumericUpDown);
            this.indexedPanel.Controls.Add(this.selectInPaletteButton);
            this.indexedPanel.Location = new System.Drawing.Point(6, 32);
            this.indexedPanel.Name = "indexedPanel";
            this.indexedPanel.Size = new System.Drawing.Size(304, 28);
            this.indexedPanel.TabIndex = 10;
            this.indexedPanel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Color index:";
            // 
            // indexNumericUpDown
            // 
            this.indexNumericUpDown.Location = new System.Drawing.Point(72, 4);
            this.indexNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.indexNumericUpDown.Name = "indexNumericUpDown";
            this.indexNumericUpDown.Size = new System.Drawing.Size(45, 20);
            this.indexNumericUpDown.TabIndex = 2;
            this.indexNumericUpDown.ValueChanged += new System.EventHandler(this.indexNumericUpDown_ValueChanged);
            // 
            // selectInPaletteButton
            // 
            this.selectInPaletteButton.Location = new System.Drawing.Point(123, 3);
            this.selectInPaletteButton.Name = "selectInPaletteButton";
            this.selectInPaletteButton.Size = new System.Drawing.Size(147, 22);
            this.selectInPaletteButton.TabIndex = 3;
            this.selectInPaletteButton.Text = "Select in palette...";
            this.selectInPaletteButton.UseVisualStyleBackColor = true;
            this.selectInPaletteButton.Click += new System.EventHandler(this.selectInPaletteButton_Click);
            // 
            // DirectPixelAccessForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 71);
            this.Controls.Add(this.pixelsGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DirectPixelAccessForm";
            this.Text = "Direct Pixel Access";
            this.pixelsGroupBox.ResumeLayout(false);
            this.pixelsGroupBox.PerformLayout();
            this.argbPanel.ResumeLayout(false);
            this.argbPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blueNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alphaNumericUpDown)).EndInit();
            this.gray16Panel.ResumeLayout(false);
            this.gray16Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gray16LumNumericUpDown)).EndInit();
            this.indexedPanel.ResumeLayout(false);
            this.indexedPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.indexNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel selectedPixelColorPanel;
        private System.Windows.Forms.Label selectedPixelLabel;
        private System.Windows.Forms.Panel argbPanel;
        private System.Windows.Forms.Button changeRGBComponentsButton;
        private System.Windows.Forms.Label rgbColorTypeLabel;
        private System.Windows.Forms.NumericUpDown blueNumericUpDown;
        private System.Windows.Forms.NumericUpDown greenNumericUpDown;
        private System.Windows.Forms.NumericUpDown redNumericUpDown;
        private System.Windows.Forms.NumericUpDown alphaNumericUpDown;
        private System.Windows.Forms.Panel gray16Panel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown gray16LumNumericUpDown;
        private System.Windows.Forms.Panel indexedPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown indexNumericUpDown;
        private System.Windows.Forms.Button selectInPaletteButton;
        private System.Windows.Forms.GroupBox pixelsGroupBox;
    }
}