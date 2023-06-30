namespace DemosCommonCode.Imaging
{
    partial class CompositeRenderingSettingsForm
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
            this.showInvisibleTableBordersCheckBox = new System.Windows.Forms.CheckBox();
            this.showNonPrintableCharactersCheckBox = new System.Windows.Forms.CheckBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textRenderingHintLabel = new System.Windows.Forms.Label();
            this.textRenderingHintComboBox = new System.Windows.Forms.ComboBox();
            this.renderingSettingsTabControl = new System.Windows.Forms.TabControl();
            this.commonSettingsTabPage = new System.Windows.Forms.TabPage();
            this.drawSharpImageBordersCheckBox = new System.Windows.Forms.CheckBox();
            this.resolutionSettingsCheckBox = new System.Windows.Forms.CheckBox();
            this.optimizeImageDrawingCheckBox = new System.Windows.Forms.CheckBox();
            this.resolutionSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.verticalResolutionNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.horizontalResolutionNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.smoothingModeComboBox = new System.Windows.Forms.ComboBox();
            this.interpolationModeComboBox = new System.Windows.Forms.ComboBox();
            this.pdfSettingsTabPage = new System.Windows.Forms.TabPage();
            this.drawErrorsCheckBox = new System.Windows.Forms.CheckBox();
            this.annotationRenderingModeLabel = new System.Windows.Forms.Label();
            this.annotationRenderingModeGroupBox = new System.Windows.Forms.GroupBox();
            this.renderDisplayableCheckBox = new System.Windows.Forms.CheckBox();
            this.renderNoViewCheckBox = new System.Windows.Forms.CheckBox();
            this.renderPrintableCheckBox = new System.Windows.Forms.CheckBox();
            this.renderHiddenCheckBox = new System.Windows.Forms.CheckBox();
            this.renderInvisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.markupAnnotationsCheckBox = new System.Windows.Forms.CheckBox();
            this.nonMarkupAnnotationsCheckBox = new System.Windows.Forms.CheckBox();
            this.vintasoftAnnotationsCheckBox = new System.Windows.Forms.CheckBox();
            this.optimizePatternRenderingCheckBox = new System.Windows.Forms.CheckBox();
            this.ignoreImageInterpolationFlagCheckBox = new System.Windows.Forms.CheckBox();
            this.officeSettingsTabPage = new System.Windows.Forms.TabPage();
            this.invisibleTableBordersGroupBox = new System.Windows.Forms.GroupBox();
            this.colorLabel = new System.Windows.Forms.Label();
            this.invisibleTableBordersColorPanelControl = new DemosCommonCode.CustomControls.ColorPanelControl();
            this.renderingSettingsTabControl.SuspendLayout();
            this.commonSettingsTabPage.SuspendLayout();
            this.resolutionSettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.verticalResolutionNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.horizontalResolutionNumericUpDown)).BeginInit();
            this.pdfSettingsTabPage.SuspendLayout();
            this.annotationRenderingModeGroupBox.SuspendLayout();
            this.officeSettingsTabPage.SuspendLayout();
            this.invisibleTableBordersGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // showInvisibleTableBordersCheckBox
            // 
            this.showInvisibleTableBordersCheckBox.AutoSize = true;
            this.showInvisibleTableBordersCheckBox.Checked = true;
            this.showInvisibleTableBordersCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showInvisibleTableBordersCheckBox.Location = new System.Drawing.Point(18, 42);
            this.showInvisibleTableBordersCheckBox.Name = "showInvisibleTableBordersCheckBox";
            this.showInvisibleTableBordersCheckBox.Size = new System.Drawing.Size(163, 17);
            this.showInvisibleTableBordersCheckBox.TabIndex = 0;
            this.showInvisibleTableBordersCheckBox.Text = "Show Invisible Table Borders";
            this.showInvisibleTableBordersCheckBox.UseVisualStyleBackColor = true;
            this.showInvisibleTableBordersCheckBox.CheckedChanged += new System.EventHandler(this.showInvisibleTableBordersCheckBox_CheckedChanged);
            // 
            // showNonPrintableCharactersCheckBox
            // 
            this.showNonPrintableCharactersCheckBox.AutoSize = true;
            this.showNonPrintableCharactersCheckBox.Location = new System.Drawing.Point(10, 102);
            this.showNonPrintableCharactersCheckBox.Name = "showNonPrintableCharactersCheckBox";
            this.showNonPrintableCharactersCheckBox.Size = new System.Drawing.Size(168, 17);
            this.showNonPrintableCharactersCheckBox.TabIndex = 1;
            this.showNonPrintableCharactersCheckBox.Text = "Show Non Printing Characters";
            this.showNonPrintableCharactersCheckBox.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(99, 310);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 4;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(180, 310);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // textRenderingHintLabel
            // 
            this.textRenderingHintLabel.AutoSize = true;
            this.textRenderingHintLabel.Location = new System.Drawing.Point(6, 14);
            this.textRenderingHintLabel.Name = "textRenderingHintLabel";
            this.textRenderingHintLabel.Size = new System.Drawing.Size(102, 13);
            this.textRenderingHintLabel.TabIndex = 6;
            this.textRenderingHintLabel.Text = "Text Rendering Hint";
            // 
            // textRenderingHintComboBox
            // 
            this.textRenderingHintComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.textRenderingHintComboBox.FormattingEnabled = true;
            this.textRenderingHintComboBox.Location = new System.Drawing.Point(123, 11);
            this.textRenderingHintComboBox.Name = "textRenderingHintComboBox";
            this.textRenderingHintComboBox.Size = new System.Drawing.Size(124, 21);
            this.textRenderingHintComboBox.TabIndex = 7;
            // 
            // renderingSettingsTabControl
            // 
            this.renderingSettingsTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.renderingSettingsTabControl.Controls.Add(this.commonSettingsTabPage);
            this.renderingSettingsTabControl.Controls.Add(this.pdfSettingsTabPage);
            this.renderingSettingsTabControl.Controls.Add(this.officeSettingsTabPage);
            this.renderingSettingsTabControl.Location = new System.Drawing.Point(0, 0);
            this.renderingSettingsTabControl.Name = "renderingSettingsTabControl";
            this.renderingSettingsTabControl.SelectedIndex = 0;
            this.renderingSettingsTabControl.Size = new System.Drawing.Size(265, 305);
            this.renderingSettingsTabControl.TabIndex = 8;
            // 
            // commonSettingsTabPage
            // 
            this.commonSettingsTabPage.Controls.Add(this.drawSharpImageBordersCheckBox);
            this.commonSettingsTabPage.Controls.Add(this.resolutionSettingsCheckBox);
            this.commonSettingsTabPage.Controls.Add(this.optimizeImageDrawingCheckBox);
            this.commonSettingsTabPage.Controls.Add(this.resolutionSettingsGroupBox);
            this.commonSettingsTabPage.Controls.Add(this.label3);
            this.commonSettingsTabPage.Controls.Add(this.label6);
            this.commonSettingsTabPage.Controls.Add(this.smoothingModeComboBox);
            this.commonSettingsTabPage.Controls.Add(this.interpolationModeComboBox);
            this.commonSettingsTabPage.Location = new System.Drawing.Point(4, 22);
            this.commonSettingsTabPage.Name = "commonSettingsTabPage";
            this.commonSettingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.commonSettingsTabPage.Size = new System.Drawing.Size(257, 279);
            this.commonSettingsTabPage.TabIndex = 0;
            this.commonSettingsTabPage.Text = "Common";
            this.commonSettingsTabPage.UseVisualStyleBackColor = true;
            // 
            // drawSharpImageBordersCheckBox
            // 
            this.drawSharpImageBordersCheckBox.AutoSize = true;
            this.drawSharpImageBordersCheckBox.Location = new System.Drawing.Point(11, 160);
            this.drawSharpImageBordersCheckBox.Name = "drawSharpImageBordersCheckBox";
            this.drawSharpImageBordersCheckBox.Size = new System.Drawing.Size(153, 17);
            this.drawSharpImageBordersCheckBox.TabIndex = 11;
            this.drawSharpImageBordersCheckBox.Text = "Draw Sharp Image Borders";
            this.drawSharpImageBordersCheckBox.UseVisualStyleBackColor = true;
            // 
            // resolutionSettingsCheckBox
            // 
            this.resolutionSettingsCheckBox.AutoSize = true;
            this.resolutionSettingsCheckBox.Checked = true;
            this.resolutionSettingsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.resolutionSettingsCheckBox.Location = new System.Drawing.Point(18, 13);
            this.resolutionSettingsCheckBox.Name = "resolutionSettingsCheckBox";
            this.resolutionSettingsCheckBox.Size = new System.Drawing.Size(103, 17);
            this.resolutionSettingsCheckBox.TabIndex = 7;
            this.resolutionSettingsCheckBox.Text = "Resolution (DPI)";
            this.resolutionSettingsCheckBox.UseVisualStyleBackColor = true;
            this.resolutionSettingsCheckBox.CheckedChanged += new System.EventHandler(this.resolutionSettingsCheckBox_CheckedChanged);
            // 
            // optimizeImageDrawingCheckBox
            // 
            this.optimizeImageDrawingCheckBox.AutoSize = true;
            this.optimizeImageDrawingCheckBox.Location = new System.Drawing.Point(11, 183);
            this.optimizeImageDrawingCheckBox.Name = "optimizeImageDrawingCheckBox";
            this.optimizeImageDrawingCheckBox.Size = new System.Drawing.Size(140, 17);
            this.optimizeImageDrawingCheckBox.TabIndex = 10;
            this.optimizeImageDrawingCheckBox.Text = "Optimize Image Drawing";
            this.optimizeImageDrawingCheckBox.UseVisualStyleBackColor = true;
            // 
            // resolutionSettingsGroupBox
            // 
            this.resolutionSettingsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resolutionSettingsGroupBox.Controls.Add(this.verticalResolutionNumericUpDown);
            this.resolutionSettingsGroupBox.Controls.Add(this.horizontalResolutionNumericUpDown);
            this.resolutionSettingsGroupBox.Controls.Add(this.label4);
            this.resolutionSettingsGroupBox.Controls.Add(this.label1);
            this.resolutionSettingsGroupBox.Location = new System.Drawing.Point(10, 15);
            this.resolutionSettingsGroupBox.Name = "resolutionSettingsGroupBox";
            this.resolutionSettingsGroupBox.Size = new System.Drawing.Size(237, 78);
            this.resolutionSettingsGroupBox.TabIndex = 9;
            this.resolutionSettingsGroupBox.TabStop = false;
            // 
            // verticalResolutionNumericUpDown
            // 
            this.verticalResolutionNumericUpDown.AccessibleName = "";
            this.verticalResolutionNumericUpDown.Location = new System.Drawing.Point(160, 44);
            this.verticalResolutionNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.verticalResolutionNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.verticalResolutionNumericUpDown.Name = "verticalResolutionNumericUpDown";
            this.verticalResolutionNumericUpDown.Size = new System.Drawing.Size(67, 20);
            this.verticalResolutionNumericUpDown.TabIndex = 5;
            this.verticalResolutionNumericUpDown.Value = new decimal(new int[] {
            96,
            0,
            0,
            0});
            // 
            // horizontalResolutionNumericUpDown
            // 
            this.horizontalResolutionNumericUpDown.Location = new System.Drawing.Point(160, 18);
            this.horizontalResolutionNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.horizontalResolutionNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.horizontalResolutionNumericUpDown.Name = "horizontalResolutionNumericUpDown";
            this.horizontalResolutionNumericUpDown.Size = new System.Drawing.Size(67, 20);
            this.horizontalResolutionNumericUpDown.TabIndex = 4;
            this.horizontalResolutionNumericUpDown.Value = new decimal(new int[] {
            96,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Vertical";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Horizontal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Smoothing Mode";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Interpolation Mode";
            // 
            // smoothingModeComboBox
            // 
            this.smoothingModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.smoothingModeComboBox.FormattingEnabled = true;
            this.smoothingModeComboBox.Location = new System.Drawing.Point(125, 97);
            this.smoothingModeComboBox.Name = "smoothingModeComboBox";
            this.smoothingModeComboBox.Size = new System.Drawing.Size(122, 21);
            this.smoothingModeComboBox.TabIndex = 7;
            // 
            // interpolationModeComboBox
            // 
            this.interpolationModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.interpolationModeComboBox.FormattingEnabled = true;
            this.interpolationModeComboBox.Location = new System.Drawing.Point(125, 128);
            this.interpolationModeComboBox.Name = "interpolationModeComboBox";
            this.interpolationModeComboBox.Size = new System.Drawing.Size(122, 21);
            this.interpolationModeComboBox.TabIndex = 8;
            // 
            // pdfSettingsTabPage
            // 
            this.pdfSettingsTabPage.Controls.Add(this.drawErrorsCheckBox);
            this.pdfSettingsTabPage.Controls.Add(this.annotationRenderingModeLabel);
            this.pdfSettingsTabPage.Controls.Add(this.annotationRenderingModeGroupBox);
            this.pdfSettingsTabPage.Controls.Add(this.optimizePatternRenderingCheckBox);
            this.pdfSettingsTabPage.Controls.Add(this.ignoreImageInterpolationFlagCheckBox);
            this.pdfSettingsTabPage.Location = new System.Drawing.Point(4, 22);
            this.pdfSettingsTabPage.Name = "pdfSettingsTabPage";
            this.pdfSettingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.pdfSettingsTabPage.Size = new System.Drawing.Size(257, 279);
            this.pdfSettingsTabPage.TabIndex = 1;
            this.pdfSettingsTabPage.Text = "PDF";
            this.pdfSettingsTabPage.UseVisualStyleBackColor = true;
            // 
            // drawErrorsCheckBox
            // 
            this.drawErrorsCheckBox.AutoSize = true;
            this.drawErrorsCheckBox.Location = new System.Drawing.Point(11, 261);
            this.drawErrorsCheckBox.Name = "drawErrorsCheckBox";
            this.drawErrorsCheckBox.Size = new System.Drawing.Size(162, 17);
            this.drawErrorsCheckBox.TabIndex = 5;
            this.drawErrorsCheckBox.Text = "Draw Image Resource Errors";
            this.drawErrorsCheckBox.UseVisualStyleBackColor = true;
            // 
            // annotationRenderingModeLabel
            // 
            this.annotationRenderingModeLabel.AutoSize = true;
            this.annotationRenderingModeLabel.Location = new System.Drawing.Point(19, 4);
            this.annotationRenderingModeLabel.Name = "annotationRenderingModeLabel";
            this.annotationRenderingModeLabel.Size = new System.Drawing.Size(140, 13);
            this.annotationRenderingModeLabel.TabIndex = 0;
            this.annotationRenderingModeLabel.Text = "Annotation Rendering Mode";
            // 
            // annotationRenderingModeGroupBox
            // 
            this.annotationRenderingModeGroupBox.Controls.Add(this.renderDisplayableCheckBox);
            this.annotationRenderingModeGroupBox.Controls.Add(this.renderNoViewCheckBox);
            this.annotationRenderingModeGroupBox.Controls.Add(this.renderPrintableCheckBox);
            this.annotationRenderingModeGroupBox.Controls.Add(this.renderHiddenCheckBox);
            this.annotationRenderingModeGroupBox.Controls.Add(this.renderInvisibleCheckBox);
            this.annotationRenderingModeGroupBox.Controls.Add(this.markupAnnotationsCheckBox);
            this.annotationRenderingModeGroupBox.Controls.Add(this.nonMarkupAnnotationsCheckBox);
            this.annotationRenderingModeGroupBox.Controls.Add(this.vintasoftAnnotationsCheckBox);
            this.annotationRenderingModeGroupBox.Location = new System.Drawing.Point(10, 6);
            this.annotationRenderingModeGroupBox.Name = "annotationRenderingModeGroupBox";
            this.annotationRenderingModeGroupBox.Size = new System.Drawing.Size(237, 204);
            this.annotationRenderingModeGroupBox.TabIndex = 4;
            this.annotationRenderingModeGroupBox.TabStop = false;
            // 
            // renderDisplayableCheckBox
            // 
            this.renderDisplayableCheckBox.AutoSize = true;
            this.renderDisplayableCheckBox.Location = new System.Drawing.Point(7, 180);
            this.renderDisplayableCheckBox.Name = "renderDisplayableCheckBox";
            this.renderDisplayableCheckBox.Size = new System.Drawing.Size(118, 17);
            this.renderDisplayableCheckBox.TabIndex = 7;
            this.renderDisplayableCheckBox.Text = "Render Displayable";
            this.renderDisplayableCheckBox.UseVisualStyleBackColor = true;
            // 
            // renderNoViewCheckBox
            // 
            this.renderNoViewCheckBox.AutoSize = true;
            this.renderNoViewCheckBox.Location = new System.Drawing.Point(7, 158);
            this.renderNoViewCheckBox.Name = "renderNoViewCheckBox";
            this.renderNoViewCheckBox.Size = new System.Drawing.Size(101, 17);
            this.renderNoViewCheckBox.TabIndex = 6;
            this.renderNoViewCheckBox.Text = "Render NoView";
            this.renderNoViewCheckBox.UseVisualStyleBackColor = true;
            // 
            // renderPrintableCheckBox
            // 
            this.renderPrintableCheckBox.AutoSize = true;
            this.renderPrintableCheckBox.Location = new System.Drawing.Point(7, 135);
            this.renderPrintableCheckBox.Name = "renderPrintableCheckBox";
            this.renderPrintableCheckBox.Size = new System.Drawing.Size(105, 17);
            this.renderPrintableCheckBox.TabIndex = 5;
            this.renderPrintableCheckBox.Text = "Render Printable";
            this.renderPrintableCheckBox.UseVisualStyleBackColor = true;
            // 
            // renderHiddenCheckBox
            // 
            this.renderHiddenCheckBox.AutoSize = true;
            this.renderHiddenCheckBox.Location = new System.Drawing.Point(7, 112);
            this.renderHiddenCheckBox.Name = "renderHiddenCheckBox";
            this.renderHiddenCheckBox.Size = new System.Drawing.Size(98, 17);
            this.renderHiddenCheckBox.TabIndex = 4;
            this.renderHiddenCheckBox.Text = "Render Hidden";
            this.renderHiddenCheckBox.UseVisualStyleBackColor = true;
            // 
            // renderInvisibleCheckBox
            // 
            this.renderInvisibleCheckBox.AutoSize = true;
            this.renderInvisibleCheckBox.Location = new System.Drawing.Point(7, 89);
            this.renderInvisibleCheckBox.Name = "renderInvisibleCheckBox";
            this.renderInvisibleCheckBox.Size = new System.Drawing.Size(102, 17);
            this.renderInvisibleCheckBox.TabIndex = 3;
            this.renderInvisibleCheckBox.Text = "Render Invisible";
            this.renderInvisibleCheckBox.UseVisualStyleBackColor = true;
            // 
            // markupAnnotationsCheckBox
            // 
            this.markupAnnotationsCheckBox.AutoSize = true;
            this.markupAnnotationsCheckBox.Location = new System.Drawing.Point(7, 66);
            this.markupAnnotationsCheckBox.Name = "markupAnnotationsCheckBox";
            this.markupAnnotationsCheckBox.Size = new System.Drawing.Size(121, 17);
            this.markupAnnotationsCheckBox.TabIndex = 2;
            this.markupAnnotationsCheckBox.Text = "Markup Annotations";
            this.markupAnnotationsCheckBox.UseVisualStyleBackColor = true;
            // 
            // nonMarkupAnnotationsCheckBox
            // 
            this.nonMarkupAnnotationsCheckBox.AutoSize = true;
            this.nonMarkupAnnotationsCheckBox.Location = new System.Drawing.Point(7, 43);
            this.nonMarkupAnnotationsCheckBox.Name = "nonMarkupAnnotationsCheckBox";
            this.nonMarkupAnnotationsCheckBox.Size = new System.Drawing.Size(144, 17);
            this.nonMarkupAnnotationsCheckBox.TabIndex = 1;
            this.nonMarkupAnnotationsCheckBox.Text = "Non Markup Annotations";
            this.nonMarkupAnnotationsCheckBox.UseVisualStyleBackColor = true;
            // 
            // vintasoftAnnotationsCheckBox
            // 
            this.vintasoftAnnotationsCheckBox.AutoSize = true;
            this.vintasoftAnnotationsCheckBox.Location = new System.Drawing.Point(7, 20);
            this.vintasoftAnnotationsCheckBox.Name = "vintasoftAnnotationsCheckBox";
            this.vintasoftAnnotationsCheckBox.Size = new System.Drawing.Size(126, 17);
            this.vintasoftAnnotationsCheckBox.TabIndex = 0;
            this.vintasoftAnnotationsCheckBox.Text = "Vintasoft Annotations";
            this.vintasoftAnnotationsCheckBox.UseVisualStyleBackColor = true;
            // 
            // optimizePatternRenderingCheckBox
            // 
            this.optimizePatternRenderingCheckBox.AutoSize = true;
            this.optimizePatternRenderingCheckBox.Location = new System.Drawing.Point(11, 238);
            this.optimizePatternRenderingCheckBox.Name = "optimizePatternRenderingCheckBox";
            this.optimizePatternRenderingCheckBox.Size = new System.Drawing.Size(155, 17);
            this.optimizePatternRenderingCheckBox.TabIndex = 3;
            this.optimizePatternRenderingCheckBox.Text = "Optimize Pattern Rendering";
            this.optimizePatternRenderingCheckBox.UseVisualStyleBackColor = true;
            // 
            // ignoreImageInterpolationFlagCheckBox
            // 
            this.ignoreImageInterpolationFlagCheckBox.AutoSize = true;
            this.ignoreImageInterpolationFlagCheckBox.Location = new System.Drawing.Point(11, 213);
            this.ignoreImageInterpolationFlagCheckBox.Name = "ignoreImageInterpolationFlagCheckBox";
            this.ignoreImageInterpolationFlagCheckBox.Size = new System.Drawing.Size(172, 17);
            this.ignoreImageInterpolationFlagCheckBox.TabIndex = 2;
            this.ignoreImageInterpolationFlagCheckBox.Text = "Ignore Image Interpolation Flag";
            this.ignoreImageInterpolationFlagCheckBox.UseVisualStyleBackColor = true;
            // 
            // officeSettingsTabPage
            // 
            this.officeSettingsTabPage.Controls.Add(this.showInvisibleTableBordersCheckBox);
            this.officeSettingsTabPage.Controls.Add(this.invisibleTableBordersGroupBox);
            this.officeSettingsTabPage.Controls.Add(this.textRenderingHintLabel);
            this.officeSettingsTabPage.Controls.Add(this.textRenderingHintComboBox);
            this.officeSettingsTabPage.Controls.Add(this.showNonPrintableCharactersCheckBox);
            this.officeSettingsTabPage.Location = new System.Drawing.Point(4, 22);
            this.officeSettingsTabPage.Name = "officeSettingsTabPage";
            this.officeSettingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.officeSettingsTabPage.Size = new System.Drawing.Size(257, 279);
            this.officeSettingsTabPage.TabIndex = 2;
            this.officeSettingsTabPage.Text = "Office";
            this.officeSettingsTabPage.UseVisualStyleBackColor = true;
            // 
            // invisibleTableBordersGroupBox
            // 
            this.invisibleTableBordersGroupBox.Controls.Add(this.colorLabel);
            this.invisibleTableBordersGroupBox.Controls.Add(this.invisibleTableBordersColorPanelControl);
            this.invisibleTableBordersGroupBox.Location = new System.Drawing.Point(10, 44);
            this.invisibleTableBordersGroupBox.Name = "invisibleTableBordersGroupBox";
            this.invisibleTableBordersGroupBox.Size = new System.Drawing.Size(237, 49);
            this.invisibleTableBordersGroupBox.TabIndex = 8;
            this.invisibleTableBordersGroupBox.TabStop = false;
            // 
            // colorLabel
            // 
            this.colorLabel.AutoSize = true;
            this.colorLabel.Location = new System.Drawing.Point(7, 22);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(65, 13);
            this.colorLabel.TabIndex = 3;
            this.colorLabel.Text = "Border Color";
            // 
            // invisibleTableBordersColorPanelControl
            // 
            this.invisibleTableBordersColorPanelControl.CanEditAlphaChannel = false;
            this.invisibleTableBordersColorPanelControl.CanSetColor = false;
            this.invisibleTableBordersColorPanelControl.Color = System.Drawing.Color.Transparent;
            this.invisibleTableBordersColorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.invisibleTableBordersColorPanelControl.Location = new System.Drawing.Point(92, 19);
            this.invisibleTableBordersColorPanelControl.Name = "invisibleTableBordersColorPanelControl";
            this.invisibleTableBordersColorPanelControl.Size = new System.Drawing.Size(136, 22);
            this.invisibleTableBordersColorPanelControl.TabIndex = 2;
            // 
            // CompositeRenderingSettingsForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(263, 342);
            this.Controls.Add(this.renderingSettingsTabControl);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CompositeRenderingSettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rendering Settings";
            this.renderingSettingsTabControl.ResumeLayout(false);
            this.commonSettingsTabPage.ResumeLayout(false);
            this.commonSettingsTabPage.PerformLayout();
            this.resolutionSettingsGroupBox.ResumeLayout(false);
            this.resolutionSettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.verticalResolutionNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.horizontalResolutionNumericUpDown)).EndInit();
            this.pdfSettingsTabPage.ResumeLayout(false);
            this.pdfSettingsTabPage.PerformLayout();
            this.annotationRenderingModeGroupBox.ResumeLayout(false);
            this.annotationRenderingModeGroupBox.PerformLayout();
            this.officeSettingsTabPage.ResumeLayout(false);
            this.officeSettingsTabPage.PerformLayout();
            this.invisibleTableBordersGroupBox.ResumeLayout(false);
            this.invisibleTableBordersGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox showInvisibleTableBordersCheckBox;
        private System.Windows.Forms.CheckBox showNonPrintableCharactersCheckBox;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private DemosCommonCode.CustomControls.ColorPanelControl invisibleTableBordersColorPanelControl;
        private System.Windows.Forms.Label textRenderingHintLabel;
        private System.Windows.Forms.ComboBox textRenderingHintComboBox;
        private System.Windows.Forms.TabControl renderingSettingsTabControl;
        private System.Windows.Forms.TabPage commonSettingsTabPage;
        private System.Windows.Forms.TabPage pdfSettingsTabPage;
        private System.Windows.Forms.TabPage officeSettingsTabPage;
        private System.Windows.Forms.CheckBox optimizeImageDrawingCheckBox;
        private System.Windows.Forms.GroupBox resolutionSettingsGroupBox;
        private System.Windows.Forms.NumericUpDown verticalResolutionNumericUpDown;
        private System.Windows.Forms.NumericUpDown horizontalResolutionNumericUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox smoothingModeComboBox;
        private System.Windows.Forms.ComboBox interpolationModeComboBox;
        private System.Windows.Forms.CheckBox resolutionSettingsCheckBox;
        private System.Windows.Forms.CheckBox optimizePatternRenderingCheckBox;
        private System.Windows.Forms.CheckBox ignoreImageInterpolationFlagCheckBox;
        private System.Windows.Forms.Label annotationRenderingModeLabel;
        private System.Windows.Forms.GroupBox annotationRenderingModeGroupBox;
        private System.Windows.Forms.CheckBox renderDisplayableCheckBox;
        private System.Windows.Forms.CheckBox renderNoViewCheckBox;
        private System.Windows.Forms.CheckBox renderPrintableCheckBox;
        private System.Windows.Forms.CheckBox renderHiddenCheckBox;
        private System.Windows.Forms.CheckBox renderInvisibleCheckBox;
        private System.Windows.Forms.CheckBox markupAnnotationsCheckBox;
        private System.Windows.Forms.CheckBox nonMarkupAnnotationsCheckBox;
        private System.Windows.Forms.CheckBox vintasoftAnnotationsCheckBox;
        private System.Windows.Forms.GroupBox invisibleTableBordersGroupBox;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.CheckBox drawSharpImageBordersCheckBox;
        private System.Windows.Forms.CheckBox drawErrorsCheckBox;
    }
}