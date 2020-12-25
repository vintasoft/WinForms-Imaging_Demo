namespace DemosCommonCode.Imaging
{
    partial class DirectShowPropertyControl
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

         #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.propertyTrackBar = new System.Windows.Forms.TrackBar();
            this.propertyDescriptionLabel = new System.Windows.Forms.Label();
            this.propertyAutoCheckBox = new System.Windows.Forms.CheckBox();
            this.mainPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.propertyTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.tableLayoutPanel1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(270, 27);
            this.mainPanel.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.propertyTrackBar, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.propertyDescriptionLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.propertyAutoCheckBox, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(270, 27);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // propertyTrackBar
            // 
            this.propertyTrackBar.AutoSize = false;
            this.propertyTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyTrackBar.Location = new System.Drawing.Point(123, 3);
            this.propertyTrackBar.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.propertyTrackBar.Name = "propertyTrackBar";
            this.propertyTrackBar.Size = new System.Drawing.Size(96, 21);
            this.propertyTrackBar.TabIndex = 18;
            this.propertyTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.propertyTrackBar.Scroll += new System.EventHandler(this.propertyTrackBar_Scroll);
            // 
            // propertyDescriptionLabel
            // 
            this.propertyDescriptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyDescriptionLabel.Location = new System.Drawing.Point(3, 0);
            this.propertyDescriptionLabel.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.propertyDescriptionLabel.Name = "propertyDescriptionLabel";
            this.propertyDescriptionLabel.Size = new System.Drawing.Size(117, 27);
            this.propertyDescriptionLabel.TabIndex = 0;
            this.propertyDescriptionLabel.Text = "<Property Description>";
            this.propertyDescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // propertyAutoCheckBox
            // 
            this.propertyAutoCheckBox.AutoSize = true;
            this.propertyAutoCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyAutoCheckBox.Location = new System.Drawing.Point(219, 3);
            this.propertyAutoCheckBox.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.propertyAutoCheckBox.Name = "propertyAutoCheckBox";
            this.propertyAutoCheckBox.Size = new System.Drawing.Size(48, 21);
            this.propertyAutoCheckBox.TabIndex = 1;
            this.propertyAutoCheckBox.Text = "Auto";
            this.propertyAutoCheckBox.UseVisualStyleBackColor = true;
            this.propertyAutoCheckBox.CheckedChanged += new System.EventHandler(this.propertyAutoCheckBox_CheckedChanged);
            // 
            // DirectShowPropertyControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.MinimumSize = new System.Drawing.Size(270, 27);
            this.Name = "DirectShowPropertyControl";
            this.Size = new System.Drawing.Size(270, 27);
            this.mainPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.propertyTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label propertyDescriptionLabel;
        private System.Windows.Forms.CheckBox propertyAutoCheckBox;
        private System.Windows.Forms.TrackBar propertyTrackBar;
    }
}