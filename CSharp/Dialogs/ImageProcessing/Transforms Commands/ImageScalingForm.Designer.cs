namespace ImagingDemo
{
    partial class ImageScalingForm
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
            this.valueEditor = new DemosCommonCode.CustomControls.ValueEditorControl();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.interpolationModeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // valueEditor
            // 
            this.valueEditor.DecimalPlaces = 2;
            this.valueEditor.DefaultValue = 100F;
            this.valueEditor.Location = new System.Drawing.Point(3, 4);
            this.valueEditor.MaxValue = 1000F;
            this.valueEditor.MinValue = 1F;
            this.valueEditor.Name = "valueEditor";
            this.valueEditor.Size = new System.Drawing.Size(335, 76);
            this.valueEditor.Step = 10F;
            this.valueEditor.TabIndex = 41;
            this.valueEditor.Value = 100F;
            this.valueEditor.ValueName = "Scale";
            this.valueEditor.ValueUnitOfMeasure = "%";
            this.valueEditor.ValueChanged += new System.EventHandler(this.valueEditorControl_ValueChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(263, 118);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 39;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(182, 118);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 38;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // interpolationModeComboBox
            // 
            this.interpolationModeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.interpolationModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.interpolationModeComboBox.FormattingEnabled = true;
            this.interpolationModeComboBox.Location = new System.Drawing.Point(121, 86);
            this.interpolationModeComboBox.Name = "interpolationModeComboBox";
            this.interpolationModeComboBox.Size = new System.Drawing.Size(166, 23);
            this.interpolationModeComboBox.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 15);
            this.label1.TabIndex = 42;
            this.label1.Text = "Interpolation Mode";
            // 
            // ImageScalingForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(346, 147);
            this.Controls.Add(this.interpolationModeComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.valueEditor);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImageScalingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Image Scaling";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DemosCommonCode.CustomControls.ValueEditorControl valueEditor;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.ComboBox interpolationModeComboBox;
        private System.Windows.Forms.Label label1;


    }
}