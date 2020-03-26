namespace ImagingDemo
{
    partial class HalftoneRemovalForm
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
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.resetButton1 = new System.Windows.Forms.Button();
            this.resetButton2 = new System.Windows.Forms.Button();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.resetButton3 = new System.Windows.Forms.Button();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.maxValueLabel1 = new System.Windows.Forms.Label();
            this.minValueLabel1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.minValueLabel2 = new System.Windows.Forms.Label();
            this.maxValueLabel2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.minValueLabel3 = new System.Windows.Forms.Label();
            this.maxValueLabel3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.minValueLabel4 = new System.Windows.Forms.Label();
            this.maxValueLabel4 = new System.Windows.Forms.Label();
            this.trackBar4 = new System.Windows.Forms.TrackBar();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.resetButton4 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.minValueLabel5 = new System.Windows.Forms.Label();
            this.maxValueLabel5 = new System.Windows.Forms.Label();
            this.trackBar5 = new System.Windows.Forms.TrackBar();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.resetButton5 = new System.Windows.Forms.Button();
            this.previewCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.minValueLabel6 = new System.Windows.Forms.Label();
            this.maxValueLabel6 = new System.Windows.Forms.Label();
            this.trackBar6 = new System.Windows.Forms.TrackBar();
            this.numericUpDown6 = new System.Windows.Forms.NumericUpDown();
            this.resetButton6 = new System.Windows.Forms.Button();
            this.autoThresholdCheckBox = new System.Windows.Forms.CheckBox();
            this.halftoneRecognitionGroupBox = new System.Windows.Forms.GroupBox();
            this.restoreTextGroupBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).BeginInit();
            this.halftoneRecognitionGroupBox.SuspendLayout();
            this.restoreTextGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(176, 550);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.btOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(258, 550);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(6, 14);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Minimum = -100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(226, 45);
            this.trackBar1.TabIndex = 50;
            this.trackBar1.TickFrequency = 5;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(6, 14);
            this.trackBar2.Maximum = 100;
            this.trackBar2.Minimum = -100;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(226, 45);
            this.trackBar2.TabIndex = 10;
            this.trackBar2.TickFrequency = 5;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // trackBar3
            // 
            this.trackBar3.Location = new System.Drawing.Point(6, 14);
            this.trackBar3.Maximum = 100;
            this.trackBar3.Minimum = -100;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(226, 45);
            this.trackBar3.TabIndex = 25;
            this.trackBar3.TickFrequency = 5;
            this.trackBar3.Scroll += new System.EventHandler(this.trackBar3_Scroll);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(238, 14);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(75, 20);
            this.numericUpDown1.TabIndex = 29;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // resetButton1
            // 
            this.resetButton1.Location = new System.Drawing.Point(238, 40);
            this.resetButton1.Name = "resetButton1";
            this.resetButton1.Size = new System.Drawing.Size(75, 22);
            this.resetButton1.TabIndex = 30;
            this.resetButton1.Text = "Reset";
            this.resetButton1.UseVisualStyleBackColor = true;
            this.resetButton1.Click += new System.EventHandler(this.buttonReset1_Click);
            // 
            // resetButton2
            // 
            this.resetButton2.Location = new System.Drawing.Point(238, 40);
            this.resetButton2.Name = "resetButton2";
            this.resetButton2.Size = new System.Drawing.Size(75, 22);
            this.resetButton2.TabIndex = 32;
            this.resetButton2.Text = "Reset";
            this.resetButton2.UseVisualStyleBackColor = true;
            this.resetButton2.Click += new System.EventHandler(this.buttonReset2_Click);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(238, 14);
            this.numericUpDown2.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(75, 20);
            this.numericUpDown2.TabIndex = 31;
            this.numericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // resetButton3
            // 
            this.resetButton3.Location = new System.Drawing.Point(238, 40);
            this.resetButton3.Name = "resetButton3";
            this.resetButton3.Size = new System.Drawing.Size(75, 22);
            this.resetButton3.TabIndex = 34;
            this.resetButton3.Text = "Reset";
            this.resetButton3.UseVisualStyleBackColor = true;
            this.resetButton3.Click += new System.EventHandler(this.buttonReset3_Click);
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(238, 14);
            this.numericUpDown3.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(75, 20);
            this.numericUpDown3.TabIndex = 33;
            this.numericUpDown3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown3.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.maxValueLabel1);
            this.groupBox1.Controls.Add(this.minValueLabel1);
            this.groupBox1.Controls.Add(this.trackBar1);
            this.groupBox1.Controls.Add(this.resetButton1);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Location = new System.Drawing.Point(14, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 70);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Amount1";
            // 
            // maxValueLabel1
            // 
            this.maxValueLabel1.AutoSize = true;
            this.maxValueLabel1.Location = new System.Drawing.Point(205, 49);
            this.maxValueLabel1.Name = "maxValueLabel1";
            this.maxValueLabel1.Size = new System.Drawing.Size(25, 13);
            this.maxValueLabel1.TabIndex = 52;
            this.maxValueLabel1.Text = "100";
            // 
            // minValueLabel1
            // 
            this.minValueLabel1.AutoSize = true;
            this.minValueLabel1.Location = new System.Drawing.Point(3, 49);
            this.minValueLabel1.Name = "minValueLabel1";
            this.minValueLabel1.Size = new System.Drawing.Size(28, 13);
            this.minValueLabel1.TabIndex = 51;
            this.minValueLabel1.Text = "-100";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.minValueLabel2);
            this.groupBox2.Controls.Add(this.maxValueLabel2);
            this.groupBox2.Controls.Add(this.trackBar2);
            this.groupBox2.Controls.Add(this.numericUpDown2);
            this.groupBox2.Controls.Add(this.resetButton2);
            this.groupBox2.Location = new System.Drawing.Point(14, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(324, 70);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Amount2";
            // 
            // minValueLabel2
            // 
            this.minValueLabel2.AutoSize = true;
            this.minValueLabel2.Location = new System.Drawing.Point(3, 49);
            this.minValueLabel2.Name = "minValueLabel2";
            this.minValueLabel2.Size = new System.Drawing.Size(28, 13);
            this.minValueLabel2.TabIndex = 54;
            this.minValueLabel2.Text = "-100";
            // 
            // maxValueLabel2
            // 
            this.maxValueLabel2.AutoSize = true;
            this.maxValueLabel2.Location = new System.Drawing.Point(205, 49);
            this.maxValueLabel2.Name = "maxValueLabel2";
            this.maxValueLabel2.Size = new System.Drawing.Size(25, 13);
            this.maxValueLabel2.TabIndex = 54;
            this.maxValueLabel2.Text = "100";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.minValueLabel3);
            this.groupBox3.Controls.Add(this.maxValueLabel3);
            this.groupBox3.Controls.Add(this.trackBar3);
            this.groupBox3.Controls.Add(this.numericUpDown3);
            this.groupBox3.Controls.Add(this.resetButton3);
            this.groupBox3.Location = new System.Drawing.Point(14, 171);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(324, 70);
            this.groupBox3.TabIndex = 37;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Amount3";
            // 
            // minValueLabel3
            // 
            this.minValueLabel3.AutoSize = true;
            this.minValueLabel3.Location = new System.Drawing.Point(3, 49);
            this.minValueLabel3.Name = "minValueLabel3";
            this.minValueLabel3.Size = new System.Drawing.Size(28, 13);
            this.minValueLabel3.TabIndex = 56;
            this.minValueLabel3.Text = "-100";
            // 
            // maxValueLabel3
            // 
            this.maxValueLabel3.AutoSize = true;
            this.maxValueLabel3.Location = new System.Drawing.Point(205, 49);
            this.maxValueLabel3.Name = "maxValueLabel3";
            this.maxValueLabel3.Size = new System.Drawing.Size(25, 13);
            this.maxValueLabel3.TabIndex = 55;
            this.maxValueLabel3.Text = "100";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.minValueLabel4);
            this.groupBox4.Controls.Add(this.maxValueLabel4);
            this.groupBox4.Controls.Add(this.trackBar4);
            this.groupBox4.Controls.Add(this.numericUpDown4);
            this.groupBox4.Controls.Add(this.resetButton4);
            this.groupBox4.Location = new System.Drawing.Point(14, 247);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(324, 70);
            this.groupBox4.TabIndex = 57;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Amount4";
            // 
            // minValueLabel4
            // 
            this.minValueLabel4.AutoSize = true;
            this.minValueLabel4.Location = new System.Drawing.Point(3, 49);
            this.minValueLabel4.Name = "minValueLabel4";
            this.minValueLabel4.Size = new System.Drawing.Size(28, 13);
            this.minValueLabel4.TabIndex = 56;
            this.minValueLabel4.Text = "-100";
            // 
            // maxValueLabel4
            // 
            this.maxValueLabel4.AutoSize = true;
            this.maxValueLabel4.Location = new System.Drawing.Point(205, 49);
            this.maxValueLabel4.Name = "maxValueLabel4";
            this.maxValueLabel4.Size = new System.Drawing.Size(25, 13);
            this.maxValueLabel4.TabIndex = 55;
            this.maxValueLabel4.Text = "100";
            // 
            // trackBar4
            // 
            this.trackBar4.Location = new System.Drawing.Point(6, 14);
            this.trackBar4.Maximum = 100;
            this.trackBar4.Minimum = -100;
            this.trackBar4.Name = "trackBar4";
            this.trackBar4.Size = new System.Drawing.Size(226, 45);
            this.trackBar4.TabIndex = 25;
            this.trackBar4.TickFrequency = 5;
            this.trackBar4.Scroll += new System.EventHandler(this.trackBar4_Scroll);
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(238, 14);
            this.numericUpDown4.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(75, 20);
            this.numericUpDown4.TabIndex = 33;
            this.numericUpDown4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown4.ValueChanged += new System.EventHandler(this.numericUpDown4_ValueChanged);
            // 
            // resetButton4
            // 
            this.resetButton4.Location = new System.Drawing.Point(238, 40);
            this.resetButton4.Name = "resetButton4";
            this.resetButton4.Size = new System.Drawing.Size(75, 22);
            this.resetButton4.TabIndex = 34;
            this.resetButton4.Text = "Reset";
            this.resetButton4.UseVisualStyleBackColor = true;
            this.resetButton4.Click += new System.EventHandler(this.buttonReset4_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.minValueLabel5);
            this.groupBox5.Controls.Add(this.maxValueLabel5);
            this.groupBox5.Controls.Add(this.trackBar5);
            this.groupBox5.Controls.Add(this.numericUpDown5);
            this.groupBox5.Controls.Add(this.resetButton5);
            this.groupBox5.Location = new System.Drawing.Point(17, 40);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(324, 70);
            this.groupBox5.TabIndex = 58;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Amount5";
            // 
            // minValueLabel5
            // 
            this.minValueLabel5.AutoSize = true;
            this.minValueLabel5.Location = new System.Drawing.Point(3, 49);
            this.minValueLabel5.Name = "minValueLabel5";
            this.minValueLabel5.Size = new System.Drawing.Size(28, 13);
            this.minValueLabel5.TabIndex = 56;
            this.minValueLabel5.Text = "-100";
            // 
            // maxValueLabel5
            // 
            this.maxValueLabel5.AutoSize = true;
            this.maxValueLabel5.Location = new System.Drawing.Point(205, 49);
            this.maxValueLabel5.Name = "maxValueLabel5";
            this.maxValueLabel5.Size = new System.Drawing.Size(25, 13);
            this.maxValueLabel5.TabIndex = 55;
            this.maxValueLabel5.Text = "100";
            // 
            // trackBar5
            // 
            this.trackBar5.Location = new System.Drawing.Point(6, 14);
            this.trackBar5.Maximum = 100;
            this.trackBar5.Minimum = -100;
            this.trackBar5.Name = "trackBar5";
            this.trackBar5.Size = new System.Drawing.Size(226, 45);
            this.trackBar5.TabIndex = 25;
            this.trackBar5.TickFrequency = 5;
            this.trackBar5.Scroll += new System.EventHandler(this.trackBar5_Scroll);
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.Location = new System.Drawing.Point(238, 14);
            this.numericUpDown5.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(75, 20);
            this.numericUpDown5.TabIndex = 33;
            this.numericUpDown5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown5.ValueChanged += new System.EventHandler(this.numericUpDown5_ValueChanged);
            // 
            // resetButton5
            // 
            this.resetButton5.Location = new System.Drawing.Point(238, 40);
            this.resetButton5.Name = "resetButton5";
            this.resetButton5.Size = new System.Drawing.Size(75, 22);
            this.resetButton5.TabIndex = 34;
            this.resetButton5.Text = "Reset";
            this.resetButton5.UseVisualStyleBackColor = true;
            this.resetButton5.Click += new System.EventHandler(this.buttonReset5_Click);
            // 
            // previewCheckBox
            // 
            this.previewCheckBox.AutoSize = true;
            this.previewCheckBox.Location = new System.Drawing.Point(9, 554);
            this.previewCheckBox.Name = "previewCheckBox";
            this.previewCheckBox.Size = new System.Drawing.Size(143, 17);
            this.previewCheckBox.TabIndex = 59;
            this.previewCheckBox.Text = "Preview on ImageViewer";
            this.previewCheckBox.UseVisualStyleBackColor = true;
            this.previewCheckBox.CheckedChanged += new System.EventHandler(this.previewCheckBox_CheckedChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.minValueLabel6);
            this.groupBox6.Controls.Add(this.maxValueLabel6);
            this.groupBox6.Controls.Add(this.trackBar6);
            this.groupBox6.Controls.Add(this.numericUpDown6);
            this.groupBox6.Controls.Add(this.resetButton6);
            this.groupBox6.Location = new System.Drawing.Point(17, 116);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(324, 70);
            this.groupBox6.TabIndex = 60;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Amount6";
            // 
            // minValueLabel6
            // 
            this.minValueLabel6.AutoSize = true;
            this.minValueLabel6.Location = new System.Drawing.Point(3, 49);
            this.minValueLabel6.Name = "minValueLabel6";
            this.minValueLabel6.Size = new System.Drawing.Size(28, 13);
            this.minValueLabel6.TabIndex = 56;
            this.minValueLabel6.Text = "-100";
            // 
            // maxValueLabel6
            // 
            this.maxValueLabel6.AutoSize = true;
            this.maxValueLabel6.Location = new System.Drawing.Point(205, 49);
            this.maxValueLabel6.Name = "maxValueLabel6";
            this.maxValueLabel6.Size = new System.Drawing.Size(25, 13);
            this.maxValueLabel6.TabIndex = 55;
            this.maxValueLabel6.Text = "100";
            // 
            // trackBar6
            // 
            this.trackBar6.Location = new System.Drawing.Point(6, 14);
            this.trackBar6.Maximum = 100;
            this.trackBar6.Minimum = -100;
            this.trackBar6.Name = "trackBar6";
            this.trackBar6.Size = new System.Drawing.Size(226, 45);
            this.trackBar6.TabIndex = 25;
            this.trackBar6.TickFrequency = 5;
            this.trackBar6.Scroll += new System.EventHandler(this.trackBar6_Scroll);
            // 
            // numericUpDown6
            // 
            this.numericUpDown6.Location = new System.Drawing.Point(238, 14);
            this.numericUpDown6.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown6.Name = "numericUpDown6";
            this.numericUpDown6.Size = new System.Drawing.Size(75, 20);
            this.numericUpDown6.TabIndex = 33;
            this.numericUpDown6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown6.ValueChanged += new System.EventHandler(this.numericUpDown6_ValueChanged);
            // 
            // resetButton6
            // 
            this.resetButton6.Location = new System.Drawing.Point(238, 40);
            this.resetButton6.Name = "resetButton6";
            this.resetButton6.Size = new System.Drawing.Size(75, 22);
            this.resetButton6.TabIndex = 34;
            this.resetButton6.Text = "Reset";
            this.resetButton6.UseVisualStyleBackColor = true;
            this.resetButton6.Click += new System.EventHandler(this.buttonReset6_Click);
            // 
            // autoThresholdCheckBox
            // 
            this.autoThresholdCheckBox.AutoSize = true;
            this.autoThresholdCheckBox.Location = new System.Drawing.Point(17, 17);
            this.autoThresholdCheckBox.Name = "autoThresholdCheckBox";
            this.autoThresholdCheckBox.Size = new System.Drawing.Size(103, 17);
            this.autoThresholdCheckBox.TabIndex = 61;
            this.autoThresholdCheckBox.Text = "Auto Thresholds";
            this.autoThresholdCheckBox.UseVisualStyleBackColor = true;
            this.autoThresholdCheckBox.CheckedChanged += new System.EventHandler(this.autoThresholdCheckBox_CheckedChanged);
            // 
            // halftoneRecognitionGroupBox
            // 
            this.halftoneRecognitionGroupBox.Controls.Add(this.groupBox1);
            this.halftoneRecognitionGroupBox.Controls.Add(this.groupBox2);
            this.halftoneRecognitionGroupBox.Controls.Add(this.groupBox3);
            this.halftoneRecognitionGroupBox.Controls.Add(this.groupBox4);
            this.halftoneRecognitionGroupBox.Location = new System.Drawing.Point(9, 12);
            this.halftoneRecognitionGroupBox.Name = "halftoneRecognitionGroupBox";
            this.halftoneRecognitionGroupBox.Size = new System.Drawing.Size(344, 327);
            this.halftoneRecognitionGroupBox.TabIndex = 62;
            this.halftoneRecognitionGroupBox.TabStop = false;
            this.halftoneRecognitionGroupBox.Text = "Halftone Recognition";
            // 
            // restoreTextGroupBox
            // 
            this.restoreTextGroupBox.Controls.Add(this.autoThresholdCheckBox);
            this.restoreTextGroupBox.Controls.Add(this.groupBox5);
            this.restoreTextGroupBox.Controls.Add(this.groupBox6);
            this.restoreTextGroupBox.Location = new System.Drawing.Point(9, 345);
            this.restoreTextGroupBox.Name = "restoreTextGroupBox";
            this.restoreTextGroupBox.Size = new System.Drawing.Size(344, 199);
            this.restoreTextGroupBox.TabIndex = 63;
            this.restoreTextGroupBox.TabStop = false;
            this.restoreTextGroupBox.Text = "Restore Text From Halftone";
            // 
            // HalftoneRemovalForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(365, 582);
            this.Controls.Add(this.restoreTextGroupBox);
            this.Controls.Add(this.halftoneRecognitionGroupBox);
            this.Controls.Add(this.previewCheckBox);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(40, 110);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HalftoneRemovalForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Halftone Removal config dialog";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).EndInit();
            this.halftoneRecognitionGroupBox.ResumeLayout(false);
            this.restoreTextGroupBox.ResumeLayout(false);
            this.restoreTextGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button resetButton1;
        private System.Windows.Forms.Button resetButton2;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Button resetButton3;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label maxValueLabel1;
        private System.Windows.Forms.Label minValueLabel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label minValueLabel2;
        private System.Windows.Forms.Label maxValueLabel2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label minValueLabel3;
        private System.Windows.Forms.Label maxValueLabel3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label minValueLabel4;
        private System.Windows.Forms.Label maxValueLabel4;
        private System.Windows.Forms.TrackBar trackBar4;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.Button resetButton4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label minValueLabel5;
        private System.Windows.Forms.Label maxValueLabel5;
        private System.Windows.Forms.TrackBar trackBar5;
        private System.Windows.Forms.NumericUpDown numericUpDown5;
        private System.Windows.Forms.Button resetButton5;
        private System.Windows.Forms.CheckBox previewCheckBox;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label minValueLabel6;
        private System.Windows.Forms.Label maxValueLabel6;
        private System.Windows.Forms.TrackBar trackBar6;
        private System.Windows.Forms.NumericUpDown numericUpDown6;
        private System.Windows.Forms.Button resetButton6;
        private System.Windows.Forms.CheckBox autoThresholdCheckBox;
        private System.Windows.Forms.GroupBox halftoneRecognitionGroupBox;
        private System.Windows.Forms.GroupBox restoreTextGroupBox;
    }
}