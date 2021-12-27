namespace DemosCommonCode.Imaging
{
    partial class ImageMapToolSettingsForm
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
            this.enabledCheckBox = new System.Windows.Forms.CheckBox();
            this.alwaysVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.zoomComboBox = new System.Windows.Forms.ComboBox();
            this.sizeComboBox = new System.Windows.Forms.ComboBox();
            this.locationComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.canvasPenCheckBox = new System.Windows.Forms.CheckBox();
            this.visibleRectPenCheckBox = new System.Windows.Forms.CheckBox();
            this.imageBufferPenCheckBox = new System.Windows.Forms.CheckBox();
            this.imageBufferPenColorPanelControl = new DemosCommonCode.CustomControls.ColorPanelControl();
            this.visibleRectPenColorPanelControl = new DemosCommonCode.CustomControls.ColorPanelControl();
            this.canvasPenColorPanelControl = new DemosCommonCode.CustomControls.ColorPanelControl();
            this.SuspendLayout();
            // 
            // enabledCheckBox
            // 
            this.enabledCheckBox.AutoSize = true;
            this.enabledCheckBox.Location = new System.Drawing.Point(15, 12);
            this.enabledCheckBox.Name = "enabledCheckBox";
            this.enabledCheckBox.Size = new System.Drawing.Size(65, 17);
            this.enabledCheckBox.TabIndex = 0;
            this.enabledCheckBox.Text = "Enabled";
            this.enabledCheckBox.UseVisualStyleBackColor = true;
            this.enabledCheckBox.CheckedChanged += new System.EventHandler(this.enabledCheckBox_CheckedChanged);
            // 
            // alwaysVisibleCheckBox
            // 
            this.alwaysVisibleCheckBox.AutoSize = true;
            this.alwaysVisibleCheckBox.Enabled = false;
            this.alwaysVisibleCheckBox.Location = new System.Drawing.Point(242, 12);
            this.alwaysVisibleCheckBox.Name = "alwaysVisibleCheckBox";
            this.alwaysVisibleCheckBox.Size = new System.Drawing.Size(92, 17);
            this.alwaysVisibleCheckBox.TabIndex = 1;
            this.alwaysVisibleCheckBox.Text = "Always Visible";
            this.alwaysVisibleCheckBox.UseVisualStyleBackColor = true;
            // 
            // zoomComboBox
            // 
            this.zoomComboBox.Enabled = false;
            this.zoomComboBox.FormattingEnabled = true;
            this.zoomComboBox.Location = new System.Drawing.Point(81, 45);
            this.zoomComboBox.Name = "zoomComboBox";
            this.zoomComboBox.Size = new System.Drawing.Size(138, 21);
            this.zoomComboBox.TabIndex = 2;
            // 
            // sizeComboBox
            // 
            this.sizeComboBox.Enabled = false;
            this.sizeComboBox.FormattingEnabled = true;
            this.sizeComboBox.Location = new System.Drawing.Point(81, 72);
            this.sizeComboBox.Name = "sizeComboBox";
            this.sizeComboBox.Size = new System.Drawing.Size(138, 21);
            this.sizeComboBox.TabIndex = 3;
            // 
            // locationComboBox
            // 
            this.locationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.locationComboBox.Enabled = false;
            this.locationComboBox.FormattingEnabled = true;
            this.locationComboBox.Location = new System.Drawing.Point(81, 99);
            this.locationComboBox.Name = "locationComboBox";
            this.locationComboBox.Size = new System.Drawing.Size(138, 21);
            this.locationComboBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Zoom";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Location";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Size";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(155, 136);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 8;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(242, 136);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // canvasPenCheckBox
            // 
            this.canvasPenCheckBox.AutoSize = true;
            this.canvasPenCheckBox.Enabled = false;
            this.canvasPenCheckBox.Location = new System.Drawing.Point(242, 47);
            this.canvasPenCheckBox.Name = "canvasPenCheckBox";
            this.canvasPenCheckBox.Size = new System.Drawing.Size(84, 17);
            this.canvasPenCheckBox.TabIndex = 10;
            this.canvasPenCheckBox.Text = "Canvas Pen";
            this.canvasPenCheckBox.UseVisualStyleBackColor = true;
            this.canvasPenCheckBox.CheckedChanged += new System.EventHandler(this.canvasPenCheckBox_CheckedChanged);
            // 
            // visibleRectPenCheckBox
            // 
            this.visibleRectPenCheckBox.AutoSize = true;
            this.visibleRectPenCheckBox.Enabled = false;
            this.visibleRectPenCheckBox.Location = new System.Drawing.Point(242, 74);
            this.visibleRectPenCheckBox.Name = "visibleRectPenCheckBox";
            this.visibleRectPenCheckBox.Size = new System.Drawing.Size(104, 17);
            this.visibleRectPenCheckBox.TabIndex = 11;
            this.visibleRectPenCheckBox.Text = "Visible Rect Pen";
            this.visibleRectPenCheckBox.UseVisualStyleBackColor = true;
            this.visibleRectPenCheckBox.CheckedChanged += new System.EventHandler(this.visibleRectPenCheckBox_CheckedChanged);
            // 
            // imageBufferPenCheckBox
            // 
            this.imageBufferPenCheckBox.AutoSize = true;
            this.imageBufferPenCheckBox.Enabled = false;
            this.imageBufferPenCheckBox.Location = new System.Drawing.Point(242, 101);
            this.imageBufferPenCheckBox.Name = "imageBufferPenCheckBox";
            this.imageBufferPenCheckBox.Size = new System.Drawing.Size(108, 17);
            this.imageBufferPenCheckBox.TabIndex = 12;
            this.imageBufferPenCheckBox.Text = "Image Buffer Pen";
            this.imageBufferPenCheckBox.UseVisualStyleBackColor = true;
            this.imageBufferPenCheckBox.CheckedChanged += new System.EventHandler(this.imageBufferPenCheckBox_CheckedChanged);
            // 
            // imageBufferPenColorPanelControl
            // 
            this.imageBufferPenColorPanelControl.Color = System.Drawing.Color.Black;
            this.imageBufferPenColorPanelControl.ColorButtonMargin = 8;
            this.imageBufferPenColorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.imageBufferPenColorPanelControl.Location = new System.Drawing.Point(355, 98);
            this.imageBufferPenColorPanelControl.Name = "imageBufferPenColorPanelControl";
            this.imageBufferPenColorPanelControl.Size = new System.Drawing.Size(110, 22);
            this.imageBufferPenColorPanelControl.TabIndex = 20;
            // 
            // visibleRectPenColorPanelControl
            // 
            this.visibleRectPenColorPanelControl.Color = System.Drawing.Color.Black;
            this.visibleRectPenColorPanelControl.ColorButtonMargin = 8;
            this.visibleRectPenColorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.visibleRectPenColorPanelControl.Location = new System.Drawing.Point(355, 71);
            this.visibleRectPenColorPanelControl.Name = "visibleRectPenColorPanelControl";
            this.visibleRectPenColorPanelControl.Size = new System.Drawing.Size(110, 22);
            this.visibleRectPenColorPanelControl.TabIndex = 19;
            // 
            // canvasPenColorPanelControl
            // 
            this.canvasPenColorPanelControl.Color = System.Drawing.Color.Black;
            this.canvasPenColorPanelControl.ColorButtonMargin = 8;
            this.canvasPenColorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.canvasPenColorPanelControl.Location = new System.Drawing.Point(355, 44);
            this.canvasPenColorPanelControl.Name = "canvasPenColorPanelControl";
            this.canvasPenColorPanelControl.Size = new System.Drawing.Size(110, 22);
            this.canvasPenColorPanelControl.TabIndex = 18;
            // 
            // ImageMapToolSettingsForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(477, 166);
            this.Controls.Add(this.imageBufferPenColorPanelControl);
            this.Controls.Add(this.visibleRectPenColorPanelControl);
            this.Controls.Add(this.canvasPenColorPanelControl);
            this.Controls.Add(this.imageBufferPenCheckBox);
            this.Controls.Add(this.visibleRectPenCheckBox);
            this.Controls.Add(this.canvasPenCheckBox);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.locationComboBox);
            this.Controls.Add(this.sizeComboBox);
            this.Controls.Add(this.zoomComboBox);
            this.Controls.Add(this.alwaysVisibleCheckBox);
            this.Controls.Add(this.enabledCheckBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImageMapToolSettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Image Map Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox enabledCheckBox;
        private System.Windows.Forms.CheckBox alwaysVisibleCheckBox;
        private System.Windows.Forms.ComboBox zoomComboBox;
        private System.Windows.Forms.ComboBox sizeComboBox;
        private System.Windows.Forms.ComboBox locationComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox canvasPenCheckBox;
        private System.Windows.Forms.CheckBox visibleRectPenCheckBox;
        private System.Windows.Forms.CheckBox imageBufferPenCheckBox;
        private DemosCommonCode.CustomControls.ColorPanelControl canvasPenColorPanelControl;
        private DemosCommonCode.CustomControls.ColorPanelControl visibleRectPenColorPanelControl;
        private DemosCommonCode.CustomControls.ColorPanelControl imageBufferPenColorPanelControl;
    }
}