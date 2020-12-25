namespace ImagingDemo
{
    partial class ShowAnimationForm
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.animatedImageViewer1 = new Vintasoft.Imaging.UI.AnimatedImageViewer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.defaultDelayNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.stopButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.defaultDelayNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 364);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.animatedImageViewer1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 55);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(384, 309);
            this.panel3.TabIndex = 1;
            // 
            // animatedImageViewer1
            // 
            this.animatedImageViewer1.AnimationRepeat = true;
            this.animatedImageViewer1.AutoScroll = true;
            this.animatedImageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.animatedImageViewer1.DefaultDelay = 100;
            this.animatedImageViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.animatedImageViewer1.Location = new System.Drawing.Point(0, 0);
            this.animatedImageViewer1.Name = "animatedImageViewer1";
            this.animatedImageViewer1.Size = new System.Drawing.Size(384, 309);
            this.animatedImageViewer1.TabIndex = 0;
            this.animatedImageViewer1.Text = "animatedImageViewer1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.defaultDelayNumericUpDown);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.stopButton);
            this.panel2.Controls.Add(this.startButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(384, 55);
            this.panel2.TabIndex = 0;
            // 
            // defaultDelayNumericUpDown
            // 
            this.defaultDelayNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.defaultDelayNumericUpDown.Location = new System.Drawing.Point(194, 29);
            this.defaultDelayNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.defaultDelayNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.defaultDelayNumericUpDown.Name = "defaultDelayNumericUpDown";
            this.defaultDelayNumericUpDown.Size = new System.Drawing.Size(93, 20);
            this.defaultDelayNumericUpDown.TabIndex = 3;
            this.defaultDelayNumericUpDown.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.defaultDelayNumericUpDown.ValueChanged += new System.EventHandler(this.defaultDelayNumericUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Default Delay (ms)";
            // 
            // stropButton
            // 
            this.stopButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.stopButton.Location = new System.Drawing.Point(194, 4);
            this.stopButton.Name = "stropButton";
            this.stopButton.Size = new System.Drawing.Size(93, 23);
            this.stopButton.TabIndex = 1;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stropButton_Click);
            // 
            // startButton
            // 
            this.startButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.startButton.Location = new System.Drawing.Point(95, 4);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(93, 23);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // ShowAnimationForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 364);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "ShowAnimationForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Animated Image Viewer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ShowAnimationForm_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.defaultDelayNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button startButton;
        private Vintasoft.Imaging.UI.AnimatedImageViewer animatedImageViewer1;
        private System.Windows.Forms.NumericUpDown defaultDelayNumericUpDown;
        private System.Windows.Forms.Label label1;
    }
}
