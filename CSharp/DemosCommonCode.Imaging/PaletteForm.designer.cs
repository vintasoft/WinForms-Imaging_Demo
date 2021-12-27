namespace DemosCommonCode.Imaging
{
    partial class PaletteForm
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
            Vintasoft.Imaging.Palette palette1 = new Vintasoft.Imaging.Palette();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.paletteViewer1 = new Vintasoft.Imaging.UI.PaletteViewer();
            this.toGrayButton = new System.Windows.Forms.Button();
            this.invertButton = new System.Windows.Forms.Button();
            this.alphaNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.redNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.greenNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.blueNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.colorIndexNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alphaNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorIndexNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(238, 436);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(319, 436);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.paletteViewer1);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 390);
            this.panel1.TabIndex = 2;
            // 
            // paletteViewer1
            // 
            this.paletteViewer1.EmptyCellColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.paletteViewer1.Location = new System.Drawing.Point(0, 0);
            this.paletteViewer1.Name = "paletteViewer1";
            this.paletteViewer1.Palette = palette1;
            this.paletteViewer1.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.paletteViewer1.SelectedColorIndex = ((byte)(0));
            this.paletteViewer1.SelectionColor = System.Drawing.Color.Lime;
            this.paletteViewer1.Size = new System.Drawing.Size(388, 388);
            this.paletteViewer1.TabIndex = 0;
            this.paletteViewer1.Text = "paletteViewer1";
            this.paletteViewer1.SelectedColorChanged += new System.EventHandler(this.PaletteViewer_SelectedColorChanged);
            // 
            // toGrayButton
            // 
            this.toGrayButton.Location = new System.Drawing.Point(4, 436);
            this.toGrayButton.Name = "toGrayButton";
            this.toGrayButton.Size = new System.Drawing.Size(75, 23);
            this.toGrayButton.TabIndex = 3;
            this.toGrayButton.Text = "To Gray";
            this.toGrayButton.UseVisualStyleBackColor = true;
            this.toGrayButton.Click += new System.EventHandler(this.toGrayButton_Click);
            // 
            // invertButton
            // 
            this.invertButton.Location = new System.Drawing.Point(85, 436);
            this.invertButton.Name = "invertButton";
            this.invertButton.Size = new System.Drawing.Size(75, 23);
            this.invertButton.TabIndex = 4;
            this.invertButton.Text = "Invert";
            this.invertButton.UseVisualStyleBackColor = true;
            this.invertButton.Click += new System.EventHandler(this.invertButton_Click);
            // 
            // alphaNumericUpDown
            // 
            this.alphaNumericUpDown.Location = new System.Drawing.Point(51, 399);
            this.alphaNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.alphaNumericUpDown.Name = "alphaNumericUpDown";
            this.alphaNumericUpDown.Size = new System.Drawing.Size(46, 20);
            this.alphaNumericUpDown.TabIndex = 5;
            this.alphaNumericUpDown.ValueChanged += new System.EventHandler(this.colorNumericUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 403);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "ARGB =";
            // 
            // redNumericUpDown
            // 
            this.redNumericUpDown.Location = new System.Drawing.Point(103, 399);
            this.redNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.redNumericUpDown.Name = "redNumericUpDown";
            this.redNumericUpDown.Size = new System.Drawing.Size(46, 20);
            this.redNumericUpDown.TabIndex = 7;
            this.redNumericUpDown.ValueChanged += new System.EventHandler(this.colorNumericUpDown_ValueChanged);
            // 
            // greenNumericUpDown
            // 
            this.greenNumericUpDown.Location = new System.Drawing.Point(155, 399);
            this.greenNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.greenNumericUpDown.Name = "greenNumericUpDown";
            this.greenNumericUpDown.Size = new System.Drawing.Size(46, 20);
            this.greenNumericUpDown.TabIndex = 8;
            this.greenNumericUpDown.ValueChanged += new System.EventHandler(this.colorNumericUpDown_ValueChanged);
            // 
            // blueNumericUpDown
            // 
            this.blueNumericUpDown.Location = new System.Drawing.Point(207, 399);
            this.blueNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.blueNumericUpDown.Name = "blueNumericUpDown";
            this.blueNumericUpDown.Size = new System.Drawing.Size(46, 20);
            this.blueNumericUpDown.TabIndex = 9;
            this.blueNumericUpDown.ValueChanged += new System.EventHandler(this.colorNumericUpDown_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(300, 403);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Index =";
            // 
            // colorIndexNumericUpDown
            // 
            this.colorIndexNumericUpDown.Location = new System.Drawing.Point(348, 399);
            this.colorIndexNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.colorIndexNumericUpDown.Name = "colorIndexNumericUpDown";
            this.colorIndexNumericUpDown.Size = new System.Drawing.Size(46, 20);
            this.colorIndexNumericUpDown.TabIndex = 11;
            this.colorIndexNumericUpDown.ValueChanged += new System.EventHandler(this.colorIndexNumericUpDown_ValueChanged);
            // 
            // PaletteForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(398, 464);
            this.Controls.Add(this.colorIndexNumericUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.blueNumericUpDown);
            this.Controls.Add(this.greenNumericUpDown);
            this.Controls.Add(this.redNumericUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.alphaNumericUpDown);
            this.Controls.Add(this.invertButton);
            this.Controls.Add(this.toGrayButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PaletteForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Image Palette";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.alphaNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorIndexNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button toGrayButton;
        private System.Windows.Forms.Button invertButton;
        private Vintasoft.Imaging.UI.PaletteViewer paletteViewer1;
        private System.Windows.Forms.NumericUpDown alphaNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown redNumericUpDown;
        private System.Windows.Forms.NumericUpDown greenNumericUpDown;
        private System.Windows.Forms.NumericUpDown blueNumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown colorIndexNumericUpDown;

    }
}