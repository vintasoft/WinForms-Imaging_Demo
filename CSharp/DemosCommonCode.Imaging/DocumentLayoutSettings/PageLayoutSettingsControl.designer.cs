namespace DemosCommonCode.Imaging
{
    partial class PageLayoutSettingsControl
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
            this.defaultSettingsCheckBox = new System.Windows.Forms.CheckBox();
            this.pageSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.xLabel = new System.Windows.Forms.Label();
            this.mmLabel = new System.Windows.Forms.Label();
            this.pageWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.pageHeightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.pagePaddingFEditorControl = new DemosCommonCode.CustomControls.PaddingFEditorControl();
            this.contentScaleNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.contentScaleLabel = new System.Windows.Forms.Label();
            this.pagePaddingLabel = new System.Windows.Forms.Label();
            this.pageSizeComboBox = new System.Windows.Forms.ComboBox();
            this.pageSizeLabel = new System.Windows.Forms.Label();
            this.pageSettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contentScaleNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultSettingsCheckBox
            // 
            this.defaultSettingsCheckBox.AutoSize = true;
            this.defaultSettingsCheckBox.Location = new System.Drawing.Point(13, 3);
            this.defaultSettingsCheckBox.Name = "defaultSettingsCheckBox";
            this.defaultSettingsCheckBox.Size = new System.Drawing.Size(60, 17);
            this.defaultSettingsCheckBox.TabIndex = 0;
            this.defaultSettingsCheckBox.Text = "Default";
            this.defaultSettingsCheckBox.UseVisualStyleBackColor = true;
            this.defaultSettingsCheckBox.CheckedChanged += new System.EventHandler(this.defaultSettingsCheckBox_CheckedChanged);
            // 
            // pageSettingsGroupBox
            // 
            this.pageSettingsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pageSettingsGroupBox.Controls.Add(this.xLabel);
            this.pageSettingsGroupBox.Controls.Add(this.mmLabel);
            this.pageSettingsGroupBox.Controls.Add(this.pageWidthNumericUpDown);
            this.pageSettingsGroupBox.Controls.Add(this.pageHeightNumericUpDown);
            this.pageSettingsGroupBox.Controls.Add(this.pagePaddingFEditorControl);
            this.pageSettingsGroupBox.Controls.Add(this.contentScaleNumericUpDown);
            this.pageSettingsGroupBox.Controls.Add(this.contentScaleLabel);
            this.pageSettingsGroupBox.Controls.Add(this.pagePaddingLabel);
            this.pageSettingsGroupBox.Controls.Add(this.pageSizeComboBox);
            this.pageSettingsGroupBox.Controls.Add(this.pageSizeLabel);
            this.pageSettingsGroupBox.Location = new System.Drawing.Point(3, 5);
            this.pageSettingsGroupBox.Name = "pageSettingsGroupBox";
            this.pageSettingsGroupBox.Size = new System.Drawing.Size(330, 201);
            this.pageSettingsGroupBox.TabIndex = 1;
            this.pageSettingsGroupBox.TabStop = false;
            // 
            // xLabel
            // 
            this.xLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(203, 59);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(12, 13);
            this.xLabel.TabIndex = 9;
            this.xLabel.Text = "x";
            // 
            // mmLabel
            // 
            this.mmLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mmLabel.AutoSize = true;
            this.mmLabel.Location = new System.Drawing.Point(293, 61);
            this.mmLabel.Name = "mmLabel";
            this.mmLabel.Size = new System.Drawing.Size(29, 13);
            this.mmLabel.TabIndex = 8;
            this.mmLabel.Text = "(mm)";
            // 
            // pageWidthNumericUpDown
            // 
            this.pageWidthNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pageWidthNumericUpDown.Enabled = false;
            this.pageWidthNumericUpDown.Location = new System.Drawing.Point(130, 54);
            this.pageWidthNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.pageWidthNumericUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.pageWidthNumericUpDown.Name = "pageWidthNumericUpDown";
            this.pageWidthNumericUpDown.Size = new System.Drawing.Size(66, 20);
            this.pageWidthNumericUpDown.TabIndex = 6;
            this.pageWidthNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.pageWidthNumericUpDown.ValueChanged += new System.EventHandler(this.pageSizeNumericUpDown_ValueChanged);
            // 
            // pageHeightNumericUpDown
            // 
            this.pageHeightNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pageHeightNumericUpDown.Enabled = false;
            this.pageHeightNumericUpDown.Location = new System.Drawing.Point(218, 54);
            this.pageHeightNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.pageHeightNumericUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.pageHeightNumericUpDown.Name = "pageHeightNumericUpDown";
            this.pageHeightNumericUpDown.Size = new System.Drawing.Size(66, 20);
            this.pageHeightNumericUpDown.TabIndex = 7;
            this.pageHeightNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.pageHeightNumericUpDown.ValueChanged += new System.EventHandler(this.pageSizeNumericUpDown_ValueChanged);
            // 
            // pagePaddingFEditorControl
            // 
            this.pagePaddingFEditorControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pagePaddingFEditorControl.Location = new System.Drawing.Point(128, 87);
            this.pagePaddingFEditorControl.MaximumSize = new System.Drawing.Size(200, 75);
            this.pagePaddingFEditorControl.MinimumSize = new System.Drawing.Size(128, 75);
            this.pagePaddingFEditorControl.Name = "pagePaddingFEditorControl";
            this.pagePaddingFEditorControl.PaddingValue = new Vintasoft.Imaging.PaddingF(0F, 0F, 0F, 0F);
            this.pagePaddingFEditorControl.Size = new System.Drawing.Size(194, 75);
            this.pagePaddingFEditorControl.TabIndex = 5;
            this.pagePaddingFEditorControl.PaddingValueChanged += new System.EventHandler(this.pagePaddingFEditorControl_PaddingValueChanged);
            // 
            // contentScaleNumericUpDown
            // 
            this.contentScaleNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.contentScaleNumericUpDown.Location = new System.Drawing.Point(259, 175);
            this.contentScaleNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.contentScaleNumericUpDown.Name = "contentScaleNumericUpDown";
            this.contentScaleNumericUpDown.Size = new System.Drawing.Size(60, 20);
            this.contentScaleNumericUpDown.TabIndex = 4;
            this.contentScaleNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.contentScaleNumericUpDown.ValueChanged += new System.EventHandler(this.contentScaleNumericUpDown_ValueChanged);
            // 
            // contentScaleLabel
            // 
            this.contentScaleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.contentScaleLabel.AutoSize = true;
            this.contentScaleLabel.Location = new System.Drawing.Point(7, 178);
            this.contentScaleLabel.Name = "contentScaleLabel";
            this.contentScaleLabel.Size = new System.Drawing.Size(100, 13);
            this.contentScaleLabel.TabIndex = 3;
            this.contentScaleLabel.Text = "Content Scale (x10)";
            // 
            // pagePaddingLabel
            // 
            this.pagePaddingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pagePaddingLabel.AutoSize = true;
            this.pagePaddingLabel.Location = new System.Drawing.Point(7, 118);
            this.pagePaddingLabel.Name = "pagePaddingLabel";
            this.pagePaddingLabel.Size = new System.Drawing.Size(99, 13);
            this.pagePaddingLabel.TabIndex = 2;
            this.pagePaddingLabel.Text = "Page Padding (mm)";
            // 
            // pageSizeComboBox
            // 
            this.pageSizeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pageSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pageSizeComboBox.FormattingEnabled = true;
            this.pageSizeComboBox.Location = new System.Drawing.Point(130, 27);
            this.pageSizeComboBox.Name = "pageSizeComboBox";
            this.pageSizeComboBox.Size = new System.Drawing.Size(189, 21);
            this.pageSizeComboBox.TabIndex = 1;
            this.pageSizeComboBox.SelectedIndexChanged += new System.EventHandler(this.pageSizeComboBox_SelectedIndexChanged);
            // 
            // pageSizeLabel
            // 
            this.pageSizeLabel.AutoSize = true;
            this.pageSizeLabel.Location = new System.Drawing.Point(7, 28);
            this.pageSizeLabel.Name = "pageSizeLabel";
            this.pageSizeLabel.Size = new System.Drawing.Size(55, 13);
            this.pageSizeLabel.TabIndex = 0;
            this.pageSizeLabel.Text = "Page Size";
            // 
            // PageLayoutSettingsControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.defaultSettingsCheckBox);
            this.Controls.Add(this.pageSettingsGroupBox);
            this.MinimumSize = new System.Drawing.Size(336, 207);
            this.Name = "PageLayoutSettingsControl";
            this.Size = new System.Drawing.Size(336, 207);
            this.pageSettingsGroupBox.ResumeLayout(false);
            this.pageSettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contentScaleNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox defaultSettingsCheckBox;
        private System.Windows.Forms.GroupBox pageSettingsGroupBox;
        private System.Windows.Forms.ComboBox pageSizeComboBox;
        private System.Windows.Forms.Label pageSizeLabel;
        private System.Windows.Forms.NumericUpDown contentScaleNumericUpDown;
        private System.Windows.Forms.Label contentScaleLabel;
        private System.Windows.Forms.Label pagePaddingLabel;
        private CustomControls.PaddingFEditorControl pagePaddingFEditorControl;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.Label mmLabel;
        private System.Windows.Forms.NumericUpDown pageHeightNumericUpDown;
        private System.Windows.Forms.NumericUpDown pageWidthNumericUpDown;
    }
}