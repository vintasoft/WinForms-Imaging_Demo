namespace ImagingDemo
{
	partial class ThreeParamsConfigForm
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
            this.previewCheckBox = new System.Windows.Forms.CheckBox();
            this.valueEditorControl2 = new DemosCommonCode.CustomControls.ValueEditorControl();
            this.valueEditorControl1 = new DemosCommonCode.CustomControls.ValueEditorControl();
            this.valueEditorControl3 = new DemosCommonCode.CustomControls.ValueEditorControl();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(178, 244);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(259, 244);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // previewCheckBox
            // 
            this.previewCheckBox.AutoSize = true;
            this.previewCheckBox.Location = new System.Drawing.Point(12, 248);
            this.previewCheckBox.Name = "previewCheckBox";
            this.previewCheckBox.Size = new System.Drawing.Size(143, 17);
            this.previewCheckBox.TabIndex = 38;
            this.previewCheckBox.Text = "Preview on ImageViewer";
            this.previewCheckBox.UseVisualStyleBackColor = true;
            this.previewCheckBox.CheckedChanged += new System.EventHandler(this.previewCheckBox_CheckedChanged);
            // 
            // valueEditorControl2
            // 
            this.valueEditorControl2.Location = new System.Drawing.Point(1, 80);
            this.valueEditorControl2.Name = "valueEditorControl2";
            this.valueEditorControl2.Size = new System.Drawing.Size(335, 76);
            this.valueEditorControl2.TabIndex = 41;
            this.valueEditorControl2.ValueName = "Value Name";
            this.valueEditorControl2.ValueUnitOfMeasure = "";
            this.valueEditorControl2.ValueChanged += new System.EventHandler(this.valueEditorControl_ValueChanged);
            // 
            // valueEditorControl1
            // 
            this.valueEditorControl1.Location = new System.Drawing.Point(1, 1);
            this.valueEditorControl1.Name = "valueEditorControl1";
            this.valueEditorControl1.Size = new System.Drawing.Size(335, 76);
            this.valueEditorControl1.TabIndex = 40;
            this.valueEditorControl1.ValueName = "Value Name";
            this.valueEditorControl1.ValueUnitOfMeasure = "";
            this.valueEditorControl1.ValueChanged += new System.EventHandler(this.valueEditorControl_ValueChanged);
            // 
            // valueEditorControl3
            // 
            this.valueEditorControl3.Location = new System.Drawing.Point(1, 162);
            this.valueEditorControl3.Name = "valueEditorControl3";
            this.valueEditorControl3.Size = new System.Drawing.Size(335, 76);
            this.valueEditorControl3.TabIndex = 42;
            this.valueEditorControl3.ValueName = "Value Name";
            this.valueEditorControl3.ValueUnitOfMeasure = "";
            this.valueEditorControl3.ValueChanged += new System.EventHandler(this.valueEditorControl_ValueChanged);
            // 
            // ThreeParamsConfigForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(341, 273);
            this.Controls.Add(this.valueEditorControl3);
            this.Controls.Add(this.valueEditorControl2);
            this.Controls.Add(this.valueEditorControl1);
            this.Controls.Add(this.previewCheckBox);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(40, 110);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ThreeParamsConfigForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Three amounts config dialog";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox previewCheckBox;
        private DemosCommonCode.CustomControls.ValueEditorControl valueEditorControl2;
        private DemosCommonCode.CustomControls.ValueEditorControl valueEditorControl1;
        private DemosCommonCode.CustomControls.ValueEditorControl valueEditorControl3;
	}
}