namespace ImagingDemo
{
    partial class ColorBlendForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.blackColorPanel = new System.Windows.Forms.Panel();
            this.whiteColorPanel = new System.Windows.Forms.Panel();
            this.labelAlpha = new System.Windows.Forms.Label();
            this.labelBlue = new System.Windows.Forms.Label();
            this.labelGreen = new System.Windows.Forms.Label();
            this.labelRed = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lockRgbCheckBox = new System.Windows.Forms.CheckBox();
            this.channelGreenTrackBar = new System.Windows.Forms.TrackBar();
            this.channelBlueTrackBar = new System.Windows.Forms.TrackBar();
            this.channelAlphaTrackBar = new System.Windows.Forms.TrackBar();
            this.channelRedTrackBar = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.blendModeComboBox = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.channelGreenTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.channelBlueTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.channelAlphaTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.channelRedTrackBar)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(335, 236);
            this.panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.blackColorPanel);
            this.groupBox2.Controls.Add(this.whiteColorPanel);
            this.groupBox2.Controls.Add(this.labelAlpha);
            this.groupBox2.Controls.Add(this.labelBlue);
            this.groupBox2.Controls.Add(this.labelGreen);
            this.groupBox2.Controls.Add(this.labelRed);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lockRgbCheckBox);
            this.groupBox2.Controls.Add(this.channelGreenTrackBar);
            this.groupBox2.Controls.Add(this.channelBlueTrackBar);
            this.groupBox2.Controls.Add(this.channelAlphaTrackBar);
            this.groupBox2.Controls.Add(this.channelRedTrackBar);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(329, 230);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Color";
            // 
            // blackColorPanel
            // 
            this.blackColorPanel.BackColor = System.Drawing.Color.Black;
            this.blackColorPanel.Location = new System.Drawing.Point(290, 191);
            this.blackColorPanel.Name = "blackColorPanel";
            this.blackColorPanel.Size = new System.Drawing.Size(33, 33);
            this.blackColorPanel.TabIndex = 21;
            // 
            // whiteColorPanel
            // 
            this.whiteColorPanel.BackColor = System.Drawing.Color.White;
            this.whiteColorPanel.Location = new System.Drawing.Point(257, 191);
            this.whiteColorPanel.Name = "whiteColorPanel";
            this.whiteColorPanel.Size = new System.Drawing.Size(33, 33);
            this.whiteColorPanel.TabIndex = 20;
            // 
            // labelAlpha
            // 
            this.labelAlpha.AutoSize = true;
            this.labelAlpha.Location = new System.Drawing.Point(7, 165);
            this.labelAlpha.Name = "labelAlpha";
            this.labelAlpha.Size = new System.Drawing.Size(13, 13);
            this.labelAlpha.TabIndex = 25;
            this.labelAlpha.Text = "0";
            // 
            // labelBlue
            // 
            this.labelBlue.AutoSize = true;
            this.labelBlue.Location = new System.Drawing.Point(7, 118);
            this.labelBlue.Name = "labelBlue";
            this.labelBlue.Size = new System.Drawing.Size(13, 13);
            this.labelBlue.TabIndex = 24;
            this.labelBlue.Text = "0";
            // 
            // labelGreen
            // 
            this.labelGreen.AutoSize = true;
            this.labelGreen.Location = new System.Drawing.Point(7, 75);
            this.labelGreen.Name = "labelGreen";
            this.labelGreen.Size = new System.Drawing.Size(13, 13);
            this.labelGreen.TabIndex = 23;
            this.labelGreen.Text = "0";
            // 
            // labelRed
            // 
            this.labelRed.AutoSize = true;
            this.labelRed.Location = new System.Drawing.Point(7, 34);
            this.labelRed.Name = "labelRed";
            this.labelRed.Size = new System.Drawing.Size(13, 13);
            this.labelRed.TabIndex = 22;
            this.labelRed.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Alpha";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Blue";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Green";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Red";
            // 
            // lockRgbCheckBox
            // 
            this.lockRgbCheckBox.AutoSize = true;
            this.lockRgbCheckBox.Location = new System.Drawing.Point(9, 203);
            this.lockRgbCheckBox.Name = "lockRgbCheckBox";
            this.lockRgbCheckBox.Size = new System.Drawing.Size(123, 17);
            this.lockRgbCheckBox.TabIndex = 13;
            this.lockRgbCheckBox.Text = "Lock RGB Channels";
            this.lockRgbCheckBox.UseVisualStyleBackColor = true;
            // 
            // channelGreenTrackBar
            // 
            this.channelGreenTrackBar.LargeChange = 8;
            this.channelGreenTrackBar.Location = new System.Drawing.Point(41, 58);
            this.channelGreenTrackBar.Maximum = 255;
            this.channelGreenTrackBar.Name = "channelGreenTrackBar";
            this.channelGreenTrackBar.Size = new System.Drawing.Size(282, 45);
            this.channelGreenTrackBar.TabIndex = 12;
            this.channelGreenTrackBar.TickFrequency = 2;
            this.channelGreenTrackBar.ValueChanged += new System.EventHandler(this.channel_ValueChanged);
            // 
            // channelBlueTrackBar
            // 
            this.channelBlueTrackBar.LargeChange = 8;
            this.channelBlueTrackBar.Location = new System.Drawing.Point(41, 106);
            this.channelBlueTrackBar.Maximum = 255;
            this.channelBlueTrackBar.Name = "channelBlueTrackBar";
            this.channelBlueTrackBar.Size = new System.Drawing.Size(282, 45);
            this.channelBlueTrackBar.TabIndex = 11;
            this.channelBlueTrackBar.TickFrequency = 2;
            this.channelBlueTrackBar.ValueChanged += new System.EventHandler(this.channel_ValueChanged);
            // 
            // channelAlphaTrackBar
            // 
            this.channelAlphaTrackBar.LargeChange = 8;
            this.channelAlphaTrackBar.Location = new System.Drawing.Point(41, 152);
            this.channelAlphaTrackBar.Maximum = 255;
            this.channelAlphaTrackBar.Name = "channelAlphaTrackBar";
            this.channelAlphaTrackBar.Size = new System.Drawing.Size(282, 45);
            this.channelAlphaTrackBar.TabIndex = 10;
            this.channelAlphaTrackBar.TickFrequency = 2;
            this.channelAlphaTrackBar.ValueChanged += new System.EventHandler(this.channel_ValueChanged);
            // 
            // channelRedTrackBar
            // 
            this.channelRedTrackBar.LargeChange = 8;
            this.channelRedTrackBar.Location = new System.Drawing.Point(41, 14);
            this.channelRedTrackBar.Maximum = 255;
            this.channelRedTrackBar.Name = "channelRedTrackBar";
            this.channelRedTrackBar.Size = new System.Drawing.Size(282, 45);
            this.channelRedTrackBar.TabIndex = 9;
            this.channelRedTrackBar.TickFrequency = 2;
            this.channelRedTrackBar.ValueChanged += new System.EventHandler(this.channel_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Blending Mode";
            // 
            // blendModeComboBox
            // 
            this.blendModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.blendModeComboBox.FormattingEnabled = true;
            this.blendModeComboBox.Location = new System.Drawing.Point(119, 12);
            this.blendModeComboBox.Name = "blendModeComboBox";
            this.blendModeComboBox.Size = new System.Drawing.Size(207, 21);
            this.blendModeComboBox.TabIndex = 18;
            this.blendModeComboBox.SelectedValueChanged += new System.EventHandler(this.comboBoxBlendMode_SelectedValueChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 236);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(335, 78);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(3);
            this.panel4.Size = new System.Drawing.Size(335, 0);
            this.panel4.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonCancel);
            this.panel3.Controls.Add(this.okButton);
            this.panel3.Controls.Add(this.blendModeComboBox);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, -3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(335, 81);
            this.panel3.TabIndex = 2;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(251, 46);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(170, 46);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.btOk_Click);
            // 
            // ColorBlendForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(335, 314);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(40, 110);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColorBlendForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Color Blending";
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.channelGreenTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.channelBlueTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.channelAlphaTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.channelRedTrackBar)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.CheckBox lockRgbCheckBox;
        private System.Windows.Forms.TrackBar channelGreenTrackBar;
        private System.Windows.Forms.TrackBar channelBlueTrackBar;
        private System.Windows.Forms.TrackBar channelAlphaTrackBar;
        private System.Windows.Forms.TrackBar channelRedTrackBar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox blendModeComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel blackColorPanel;
        private System.Windows.Forms.Panel whiteColorPanel;
        private System.Windows.Forms.Label labelAlpha;
        private System.Windows.Forms.Label labelBlue;
        private System.Windows.Forms.Label labelGreen;
        private System.Windows.Forms.Label labelRed;
    }
}