namespace DemosCommonCode.Imaging
{
    partial class DocxLayoutSettingsDialog
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
            this.cancelBtn = new System.Windows.Forms.Button();
            this.settingsGroupBox = new System.Windows.Forms.GroupBox();
            this.documentLayoutSettingsEditorControl1 = new DemosCommonCode.Imaging.DocumentLayoutSettingsEditorControl();
            this.defaultSettingsCheckBox = new System.Windows.Forms.CheckBox();
            this.settingsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(197, 285);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(278, 285);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // settingsGroupBox
            // 
            this.settingsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsGroupBox.Controls.Add(this.documentLayoutSettingsEditorControl1);
            this.settingsGroupBox.Enabled = false;
            this.settingsGroupBox.Location = new System.Drawing.Point(4, 8);
            this.settingsGroupBox.Name = "settingsGroupBox";
            this.settingsGroupBox.Size = new System.Drawing.Size(356, 263);
            this.settingsGroupBox.TabIndex = 6;
            this.settingsGroupBox.TabStop = false;
            // 
            // documentLayoutSettingsEditorControl1
            // 
            this.documentLayoutSettingsEditorControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentLayoutSettingsEditorControl1.Location = new System.Drawing.Point(3, 16);
            this.documentLayoutSettingsEditorControl1.Name = "documentLayoutSettingsEditorControl1";
            this.documentLayoutSettingsEditorControl1.Size = new System.Drawing.Size(350, 244);
            this.documentLayoutSettingsEditorControl1.TabIndex = 0;
            // 
            // defaultSettingsCheckBox
            // 
            this.defaultSettingsCheckBox.AutoSize = true;
            this.defaultSettingsCheckBox.Checked = true;
            this.defaultSettingsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.defaultSettingsCheckBox.Location = new System.Drawing.Point(10, 6);
            this.defaultSettingsCheckBox.Name = "defaultSettingsCheckBox";
            this.defaultSettingsCheckBox.Size = new System.Drawing.Size(150, 17);
            this.defaultSettingsCheckBox.TabIndex = 6;
            this.defaultSettingsCheckBox.Text = "Use default layout settings";
            this.defaultSettingsCheckBox.UseVisualStyleBackColor = true;
            this.defaultSettingsCheckBox.CheckedChanged += new System.EventHandler(this.defaultSettingsCheckBox_CheckedChanged);
            // 
            // DocxLayoutSettingsDialog
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(365, 317);
            this.Controls.Add(this.defaultSettingsCheckBox);
            this.Controls.Add(this.settingsGroupBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "DocxLayoutSettingsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DOCX Layout Settings";
            this.settingsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.GroupBox settingsGroupBox;
        private System.Windows.Forms.CheckBox defaultSettingsCheckBox;
        private DocumentLayoutSettingsEditorControl documentLayoutSettingsEditorControl1;
    }
}
