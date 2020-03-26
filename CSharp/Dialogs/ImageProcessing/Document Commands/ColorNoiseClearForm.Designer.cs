namespace ImagingDemo
{
    partial class ColorNoiseClearForm
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
            this.whiteCheckBox = new System.Windows.Forms.CheckBox();
            this.whiteTrackBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.whiteLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.blackLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.blackTrackBar = new System.Windows.Forms.TrackBar();
            this.blackCheckBox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.redLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.redTrackBar = new System.Windows.Forms.TrackBar();
            this.redCheckBox = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.greenLabel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.greenTrackBar = new System.Windows.Forms.TrackBar();
            this.greenCheckBox = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.blueLabel = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.blueTrackBar = new System.Windows.Forms.TrackBar();
            this.blueCheckBox = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cyanLabel = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.cyanTrackBar = new System.Windows.Forms.TrackBar();
            this.cyanCheckBox = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.magentaLabel = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.magentaTrackBar = new System.Windows.Forms.TrackBar();
            this.magentaCheckBox = new System.Windows.Forms.CheckBox();
            this.label22 = new System.Windows.Forms.Label();
            this.yellowLabel = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.yellowTrackBar = new System.Windows.Forms.TrackBar();
            this.yellowCheckBox = new System.Windows.Forms.CheckBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.interpolationLabel = new System.Windows.Forms.Label();
            this.interpolationTrackBar = new System.Windows.Forms.TrackBar();
            this.label28 = new System.Windows.Forms.Label();
            this.previewCheckBox = new System.Windows.Forms.CheckBox();
            this.okButton = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.whiteTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blackTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cyanTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.magentaTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yellowTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.interpolationTrackBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // whiteCheckBox
            // 
            this.whiteCheckBox.AutoSize = true;
            this.whiteCheckBox.Checked = true;
            this.whiteCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.whiteCheckBox.Location = new System.Drawing.Point(15, 32);
            this.whiteCheckBox.Name = "whiteCheckBox";
            this.whiteCheckBox.Size = new System.Drawing.Size(54, 17);
            this.whiteCheckBox.TabIndex = 0;
            this.whiteCheckBox.Text = "White";
            this.whiteCheckBox.UseVisualStyleBackColor = true;
            this.whiteCheckBox.CheckedChanged += new System.EventHandler(this.colorCheckBox_CheckedChanged);
            // 
            // whiteTrackBar
            // 
            this.whiteTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.whiteTrackBar.Location = new System.Drawing.Point(115, 19);
            this.whiteTrackBar.Maximum = 200;
            this.whiteTrackBar.Name = "whiteTrackBar";
            this.whiteTrackBar.Size = new System.Drawing.Size(340, 45);
            this.whiteTrackBar.TabIndex = 1;
            this.whiteTrackBar.TickFrequency = 5;
            this.whiteTrackBar.Value = 150;
            this.whiteTrackBar.Scroll += new System.EventHandler(this.whiteTrackBar_Scroll);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "0";
            // 
            // whiteLabel
            // 
            this.whiteLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.whiteLabel.AutoSize = true;
            this.whiteLabel.Location = new System.Drawing.Point(265, 51);
            this.whiteLabel.Name = "whiteLabel";
            this.whiteLabel.Size = new System.Drawing.Size(25, 13);
            this.whiteLabel.TabIndex = 3;
            this.whiteLabel.Text = "150";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(430, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "200";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(430, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "200";
            // 
            // blackLabel
            // 
            this.blackLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.blackLabel.AutoSize = true;
            this.blackLabel.Location = new System.Drawing.Point(265, 102);
            this.blackLabel.Name = "blackLabel";
            this.blackLabel.Size = new System.Drawing.Size(25, 13);
            this.blackLabel.TabIndex = 8;
            this.blackLabel.Text = "150";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(112, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "0";
            // 
            // blackTrackBar
            // 
            this.blackTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.blackTrackBar.Location = new System.Drawing.Point(115, 70);
            this.blackTrackBar.Maximum = 200;
            this.blackTrackBar.Name = "blackTrackBar";
            this.blackTrackBar.Size = new System.Drawing.Size(340, 45);
            this.blackTrackBar.TabIndex = 6;
            this.blackTrackBar.TickFrequency = 5;
            this.blackTrackBar.Value = 150;
            this.blackTrackBar.Scroll += new System.EventHandler(this.blackTrackBar_Scroll);
            // 
            // blackCheckBox
            // 
            this.blackCheckBox.AutoSize = true;
            this.blackCheckBox.Checked = true;
            this.blackCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.blackCheckBox.Location = new System.Drawing.Point(15, 83);
            this.blackCheckBox.Name = "blackCheckBox";
            this.blackCheckBox.Size = new System.Drawing.Size(53, 17);
            this.blackCheckBox.TabIndex = 5;
            this.blackCheckBox.Text = "Black";
            this.blackCheckBox.UseVisualStyleBackColor = true;
            this.blackCheckBox.CheckedChanged += new System.EventHandler(this.colorCheckBox_CheckedChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(430, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "200";
            // 
            // redLabel
            // 
            this.redLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.redLabel.AutoSize = true;
            this.redLabel.Location = new System.Drawing.Point(265, 153);
            this.redLabel.Name = "redLabel";
            this.redLabel.Size = new System.Drawing.Size(19, 13);
            this.redLabel.TabIndex = 13;
            this.redLabel.Text = "75";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(112, 153);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "0";
            // 
            // redTrackBar
            // 
            this.redTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.redTrackBar.Location = new System.Drawing.Point(115, 121);
            this.redTrackBar.Maximum = 200;
            this.redTrackBar.Name = "redTrackBar";
            this.redTrackBar.Size = new System.Drawing.Size(340, 45);
            this.redTrackBar.TabIndex = 11;
            this.redTrackBar.TickFrequency = 5;
            this.redTrackBar.Value = 75;
            this.redTrackBar.Scroll += new System.EventHandler(this.redTrackBar_Scroll);
            // 
            // redCheckBox
            // 
            this.redCheckBox.AutoSize = true;
            this.redCheckBox.Checked = true;
            this.redCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.redCheckBox.Location = new System.Drawing.Point(15, 134);
            this.redCheckBox.Name = "redCheckBox";
            this.redCheckBox.Size = new System.Drawing.Size(46, 17);
            this.redCheckBox.TabIndex = 10;
            this.redCheckBox.Text = "Red";
            this.redCheckBox.UseVisualStyleBackColor = true;
            this.redCheckBox.CheckedChanged += new System.EventHandler(this.colorCheckBox_CheckedChanged);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(430, 201);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "200";
            // 
            // greenLabel
            // 
            this.greenLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.greenLabel.AutoSize = true;
            this.greenLabel.Location = new System.Drawing.Point(265, 201);
            this.greenLabel.Name = "greenLabel";
            this.greenLabel.Size = new System.Drawing.Size(19, 13);
            this.greenLabel.TabIndex = 18;
            this.greenLabel.Text = "75";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(112, 201);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(13, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "0";
            // 
            // greenTrackBar
            // 
            this.greenTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.greenTrackBar.Location = new System.Drawing.Point(115, 169);
            this.greenTrackBar.Maximum = 200;
            this.greenTrackBar.Name = "greenTrackBar";
            this.greenTrackBar.Size = new System.Drawing.Size(340, 45);
            this.greenTrackBar.TabIndex = 16;
            this.greenTrackBar.TickFrequency = 5;
            this.greenTrackBar.Value = 75;
            this.greenTrackBar.Scroll += new System.EventHandler(this.greenTrackBar_Scroll);
            // 
            // greenCheckBox
            // 
            this.greenCheckBox.AutoSize = true;
            this.greenCheckBox.Checked = true;
            this.greenCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.greenCheckBox.Location = new System.Drawing.Point(15, 182);
            this.greenCheckBox.Name = "greenCheckBox";
            this.greenCheckBox.Size = new System.Drawing.Size(55, 17);
            this.greenCheckBox.TabIndex = 15;
            this.greenCheckBox.Text = "Green";
            this.greenCheckBox.UseVisualStyleBackColor = true;
            this.greenCheckBox.CheckedChanged += new System.EventHandler(this.colorCheckBox_CheckedChanged);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(430, 252);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(25, 13);
            this.label13.TabIndex = 24;
            this.label13.Text = "200";
            // 
            // blueLabel
            // 
            this.blueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.blueLabel.AutoSize = true;
            this.blueLabel.Location = new System.Drawing.Point(265, 252);
            this.blueLabel.Name = "blueLabel";
            this.blueLabel.Size = new System.Drawing.Size(19, 13);
            this.blueLabel.TabIndex = 23;
            this.blueLabel.Text = "75";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(112, 252);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(13, 13);
            this.label15.TabIndex = 22;
            this.label15.Text = "0";
            // 
            // blueTrackBar
            // 
            this.blueTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.blueTrackBar.Location = new System.Drawing.Point(115, 220);
            this.blueTrackBar.Maximum = 200;
            this.blueTrackBar.Name = "blueTrackBar";
            this.blueTrackBar.Size = new System.Drawing.Size(340, 45);
            this.blueTrackBar.TabIndex = 21;
            this.blueTrackBar.TickFrequency = 5;
            this.blueTrackBar.Value = 75;
            this.blueTrackBar.Scroll += new System.EventHandler(this.blueTrackBar_Scroll);
            // 
            // blueCheckBox
            // 
            this.blueCheckBox.AutoSize = true;
            this.blueCheckBox.Checked = true;
            this.blueCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.blueCheckBox.Location = new System.Drawing.Point(15, 233);
            this.blueCheckBox.Name = "blueCheckBox";
            this.blueCheckBox.Size = new System.Drawing.Size(47, 17);
            this.blueCheckBox.TabIndex = 20;
            this.blueCheckBox.Text = "Blue";
            this.blueCheckBox.UseVisualStyleBackColor = true;
            this.blueCheckBox.CheckedChanged += new System.EventHandler(this.colorCheckBox_CheckedChanged);
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(430, 303);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(25, 13);
            this.label16.TabIndex = 29;
            this.label16.Text = "200";
            // 
            // cyanLabel
            // 
            this.cyanLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cyanLabel.AutoSize = true;
            this.cyanLabel.Location = new System.Drawing.Point(265, 303);
            this.cyanLabel.Name = "cyanLabel";
            this.cyanLabel.Size = new System.Drawing.Size(19, 13);
            this.cyanLabel.TabIndex = 28;
            this.cyanLabel.Text = "75";
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(112, 303);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(13, 13);
            this.label18.TabIndex = 27;
            this.label18.Text = "0";
            // 
            // cyanTrackBar
            // 
            this.cyanTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cyanTrackBar.Location = new System.Drawing.Point(115, 271);
            this.cyanTrackBar.Maximum = 200;
            this.cyanTrackBar.Name = "cyanTrackBar";
            this.cyanTrackBar.Size = new System.Drawing.Size(340, 45);
            this.cyanTrackBar.TabIndex = 26;
            this.cyanTrackBar.TickFrequency = 5;
            this.cyanTrackBar.Value = 75;
            this.cyanTrackBar.Scroll += new System.EventHandler(this.cyanTrackBar_Scroll);
            // 
            // cyanCheckBox
            // 
            this.cyanCheckBox.AutoSize = true;
            this.cyanCheckBox.Checked = true;
            this.cyanCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cyanCheckBox.Location = new System.Drawing.Point(15, 284);
            this.cyanCheckBox.Name = "cyanCheckBox";
            this.cyanCheckBox.Size = new System.Drawing.Size(50, 17);
            this.cyanCheckBox.TabIndex = 25;
            this.cyanCheckBox.Text = "Cyan";
            this.cyanCheckBox.UseVisualStyleBackColor = true;
            this.cyanCheckBox.CheckedChanged += new System.EventHandler(this.colorCheckBox_CheckedChanged);
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(430, 354);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(25, 13);
            this.label19.TabIndex = 34;
            this.label19.Text = "200";
            // 
            // magentaLabel
            // 
            this.magentaLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.magentaLabel.AutoSize = true;
            this.magentaLabel.Location = new System.Drawing.Point(265, 354);
            this.magentaLabel.Name = "magentaLabel";
            this.magentaLabel.Size = new System.Drawing.Size(19, 13);
            this.magentaLabel.TabIndex = 33;
            this.magentaLabel.Text = "75";
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(112, 354);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(13, 13);
            this.label21.TabIndex = 32;
            this.label21.Text = "0";
            // 
            // magentaTrackBar
            // 
            this.magentaTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.magentaTrackBar.Location = new System.Drawing.Point(115, 322);
            this.magentaTrackBar.Maximum = 200;
            this.magentaTrackBar.Name = "magentaTrackBar";
            this.magentaTrackBar.Size = new System.Drawing.Size(340, 45);
            this.magentaTrackBar.TabIndex = 31;
            this.magentaTrackBar.TickFrequency = 5;
            this.magentaTrackBar.Value = 75;
            this.magentaTrackBar.Scroll += new System.EventHandler(this.magentaTrackBar_Scroll);
            // 
            // magentaCheckBox
            // 
            this.magentaCheckBox.AutoSize = true;
            this.magentaCheckBox.Checked = true;
            this.magentaCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.magentaCheckBox.Location = new System.Drawing.Point(15, 334);
            this.magentaCheckBox.Name = "magentaCheckBox";
            this.magentaCheckBox.Size = new System.Drawing.Size(68, 17);
            this.magentaCheckBox.TabIndex = 30;
            this.magentaCheckBox.Text = "Magenta";
            this.magentaCheckBox.UseVisualStyleBackColor = true;
            this.magentaCheckBox.CheckedChanged += new System.EventHandler(this.colorCheckBox_CheckedChanged);
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(430, 402);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(25, 13);
            this.label22.TabIndex = 39;
            this.label22.Text = "200";
            // 
            // yellowLabel
            // 
            this.yellowLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.yellowLabel.AutoSize = true;
            this.yellowLabel.Location = new System.Drawing.Point(265, 402);
            this.yellowLabel.Name = "yellowLabel";
            this.yellowLabel.Size = new System.Drawing.Size(19, 13);
            this.yellowLabel.TabIndex = 38;
            this.yellowLabel.Text = "75";
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(112, 402);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(13, 13);
            this.label24.TabIndex = 37;
            this.label24.Text = "0";
            // 
            // yellowTrackBar
            // 
            this.yellowTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.yellowTrackBar.Location = new System.Drawing.Point(115, 370);
            this.yellowTrackBar.Maximum = 200;
            this.yellowTrackBar.Name = "yellowTrackBar";
            this.yellowTrackBar.Size = new System.Drawing.Size(340, 45);
            this.yellowTrackBar.TabIndex = 36;
            this.yellowTrackBar.TickFrequency = 5;
            this.yellowTrackBar.Value = 75;
            this.yellowTrackBar.Scroll += new System.EventHandler(this.yellowTrackBar_Scroll);
            // 
            // yellowCheckBox
            // 
            this.yellowCheckBox.AutoSize = true;
            this.yellowCheckBox.Checked = true;
            this.yellowCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.yellowCheckBox.Location = new System.Drawing.Point(15, 386);
            this.yellowCheckBox.Name = "yellowCheckBox";
            this.yellowCheckBox.Size = new System.Drawing.Size(57, 17);
            this.yellowCheckBox.TabIndex = 35;
            this.yellowCheckBox.Text = "Yellow";
            this.yellowCheckBox.UseVisualStyleBackColor = true;
            this.yellowCheckBox.CheckedChanged += new System.EventHandler(this.colorCheckBox_CheckedChanged);
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(445, 471);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(22, 13);
            this.label25.TabIndex = 44;
            this.label25.Text = "1.0";
            // 
            // label26
            // 
            this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(124, 471);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(13, 13);
            this.label26.TabIndex = 42;
            this.label26.Text = "0";
            // 
            // interpolationLabel
            // 
            this.interpolationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.interpolationLabel.AutoSize = true;
            this.interpolationLabel.Location = new System.Drawing.Point(277, 471);
            this.interpolationLabel.Name = "interpolationLabel";
            this.interpolationLabel.Size = new System.Drawing.Size(22, 13);
            this.interpolationLabel.TabIndex = 43;
            this.interpolationLabel.Text = "0.5";
            // 
            // interpolationTrackBar
            // 
            this.interpolationTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.interpolationTrackBar.Location = new System.Drawing.Point(127, 439);
            this.interpolationTrackBar.Maximum = 26;
            this.interpolationTrackBar.Name = "interpolationTrackBar";
            this.interpolationTrackBar.Size = new System.Drawing.Size(340, 45);
            this.interpolationTrackBar.TabIndex = 41;
            this.interpolationTrackBar.Value = 13;
            this.interpolationTrackBar.Scroll += new System.EventHandler(this.interpolationTrackBar_Scroll);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(24, 456);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(96, 13);
            this.label28.TabIndex = 45;
            this.label28.Text = "Interpolation radius";
            // 
            // previewCheckBox
            // 
            this.previewCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.previewCheckBox.AutoSize = true;
            this.previewCheckBox.Location = new System.Drawing.Point(12, 496);
            this.previewCheckBox.Name = "previewCheckBox";
            this.previewCheckBox.Size = new System.Drawing.Size(143, 17);
            this.previewCheckBox.TabIndex = 46;
            this.previewCheckBox.Text = "Preview on ImageViewer";
            this.previewCheckBox.UseVisualStyleBackColor = true;
            this.previewCheckBox.CheckedChanged += new System.EventHandler(this.previewCheckBox_CheckedChanged);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(324, 493);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 47;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(405, 493);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 48;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.whiteCheckBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.whiteLabel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.blackCheckBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.blackLabel);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.redCheckBox);
            this.groupBox1.Controls.Add(this.yellowLabel);
            this.groupBox1.Controls.Add(this.yellowCheckBox);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.redLabel);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.magentaLabel);
            this.groupBox1.Controls.Add(this.greenCheckBox);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.magentaCheckBox);
            this.groupBox1.Controls.Add(this.greenLabel);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cyanLabel);
            this.groupBox1.Controls.Add(this.blueCheckBox);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.cyanCheckBox);
            this.groupBox1.Controls.Add(this.blueLabel);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.whiteTrackBar);
            this.groupBox1.Controls.Add(this.blackTrackBar);
            this.groupBox1.Controls.Add(this.redTrackBar);
            this.groupBox1.Controls.Add(this.yellowTrackBar);
            this.groupBox1.Controls.Add(this.greenTrackBar);
            this.groupBox1.Controls.Add(this.magentaTrackBar);
            this.groupBox1.Controls.Add(this.blueTrackBar);
            this.groupBox1.Controls.Add(this.cyanTrackBar);
            this.groupBox1.Location = new System.Drawing.Point(12, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(468, 428);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Colors";
            // 
            // ColorNoiseClearForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(489, 523);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.previewCheckBox);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.interpolationLabel);
            this.Controls.Add(this.interpolationTrackBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColorNoiseClearForm";
            this.Text = "Color Noise Clear";
            ((System.ComponentModel.ISupportInitialize)(this.whiteTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blackTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cyanTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.magentaTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yellowTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.interpolationTrackBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox whiteCheckBox;
        private System.Windows.Forms.TrackBar whiteTrackBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label whiteLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label blackLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar blackTrackBar;
        private System.Windows.Forms.CheckBox blackCheckBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label redLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TrackBar redTrackBar;
        private System.Windows.Forms.CheckBox redCheckBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label greenLabel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TrackBar greenTrackBar;
        private System.Windows.Forms.CheckBox greenCheckBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label blueLabel;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TrackBar blueTrackBar;
        private System.Windows.Forms.CheckBox blueCheckBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label cyanLabel;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TrackBar cyanTrackBar;
        private System.Windows.Forms.CheckBox cyanCheckBox;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label magentaLabel;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TrackBar magentaTrackBar;
        private System.Windows.Forms.CheckBox magentaCheckBox;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label yellowLabel;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TrackBar yellowTrackBar;
        private System.Windows.Forms.CheckBox yellowCheckBox;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label interpolationLabel;
        private System.Windows.Forms.TrackBar interpolationTrackBar;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.CheckBox previewCheckBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}