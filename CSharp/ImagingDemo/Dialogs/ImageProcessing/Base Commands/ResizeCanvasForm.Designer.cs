namespace ImagingDemo
{
	partial class ResizeCanvasForm
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
            this.labelText1 = new System.Windows.Forms.Label();
            this.labelText2 = new System.Windows.Forms.Label();
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.nWidth = new System.Windows.Forms.NumericUpDown();
            this.nHeight = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.yPositionNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.xPositionNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.canvasColorPanelControl = new DemosCommonCode.ColorPanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.nWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yPositionNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xPositionNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // labelText1
            // 
            this.labelText1.Location = new System.Drawing.Point(9, 61);
            this.labelText1.Name = "labelText1";
            this.labelText1.Size = new System.Drawing.Size(76, 23);
            this.labelText1.TabIndex = 0;
            this.labelText1.Text = "Canvas width:";
            this.labelText1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelText2
            // 
            this.labelText2.Location = new System.Drawing.Point(9, 88);
            this.labelText2.Name = "labelText2";
            this.labelText2.Size = new System.Drawing.Size(87, 20);
            this.labelText2.TabIndex = 2;
            this.labelText2.Text = "Canvas height:";
            this.labelText2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btOk
            // 
            this.btOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOk.Location = new System.Drawing.Point(21, 150);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(75, 23);
            this.btOk.TabIndex = 4;
            this.btOk.Text = "OK";
            this.btOk.UseVisualStyleBackColor = true;
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(102, 150);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 5;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // nWidth
            // 
            this.nWidth.Location = new System.Drawing.Point(102, 63);
            this.nWidth.Maximum = new decimal(new int[] {
            32000,
            0,
            0,
            0});
            this.nWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nWidth.Name = "nWidth";
            this.nWidth.Size = new System.Drawing.Size(82, 20);
            this.nWidth.TabIndex = 6;
            this.nWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nHeight
            // 
            this.nHeight.Location = new System.Drawing.Point(102, 90);
            this.nHeight.Maximum = new decimal(new int[] {
            32000,
            0,
            0,
            0});
            this.nHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nHeight.Name = "nHeight";
            this.nHeight.Size = new System.Drawing.Size(82, 20);
            this.nHeight.TabIndex = 7;
            this.nHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Canvas color:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // yPositionNumericUpDown
            // 
            this.yPositionNumericUpDown.Location = new System.Drawing.Point(102, 37);
            this.yPositionNumericUpDown.Maximum = new decimal(new int[] {
            32000,
            0,
            0,
            0});
            this.yPositionNumericUpDown.Minimum = new decimal(new int[] {
            32000,
            0,
            0,
            -2147483648});
            this.yPositionNumericUpDown.Name = "yPositionNumericUpDown";
            this.yPositionNumericUpDown.Size = new System.Drawing.Size(82, 20);
            this.yPositionNumericUpDown.TabIndex = 14;
            // 
            // xPositionNumericUpDown
            // 
            this.xPositionNumericUpDown.Location = new System.Drawing.Point(102, 10);
            this.xPositionNumericUpDown.Maximum = new decimal(new int[] {
            32000,
            0,
            0,
            0});
            this.xPositionNumericUpDown.Minimum = new decimal(new int[] {
            32000,
            0,
            0,
            -2147483648});
            this.xPositionNumericUpDown.Name = "xPositionNumericUpDown";
            this.xPositionNumericUpDown.Size = new System.Drawing.Size(82, 20);
            this.xPositionNumericUpDown.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Image Y:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "Image X:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // canvasColorPanelControl
            // 
            this.canvasColorPanelControl.Color = System.Drawing.Color.White;
            this.canvasColorPanelControl.ColorButtonWidth = 29;
            this.canvasColorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.canvasColorPanelControl.Location = new System.Drawing.Point(102, 115);
            this.canvasColorPanelControl.Name = "canvasColorPanelControl";
            this.canvasColorPanelControl.Size = new System.Drawing.Size(82, 22);
            this.canvasColorPanelControl.TabIndex = 15;
            // 
            // ResizeCanvasForm
            // 
            this.AcceptButton = this.btOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(200, 185);
            this.Controls.Add(this.canvasColorPanelControl);
            this.Controls.Add(this.yPositionNumericUpDown);
            this.Controls.Add(this.xPositionNumericUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nHeight);
            this.Controls.Add(this.nWidth);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.labelText2);
            this.Controls.Add(this.labelText1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResizeCanvasForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Resize canvas";
            ((System.ComponentModel.ISupportInitialize)(this.nWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yPositionNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xPositionNumericUpDown)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label labelText1;
		private System.Windows.Forms.Label labelText2;
		private System.Windows.Forms.Button btOk;
		private System.Windows.Forms.Button btCancel;
		private System.Windows.Forms.NumericUpDown nWidth;
		private System.Windows.Forms.NumericUpDown nHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown yPositionNumericUpDown;
        private System.Windows.Forms.NumericUpDown xPositionNumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DemosCommonCode.ColorPanelControl canvasColorPanelControl;
	}
}