namespace ImagingDemo
{
    partial class ColorTransformForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.useBlackPointCompensationCheckBox = new System.Windows.Forms.CheckBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.renderingIntentComboBox = new System.Windows.Forms.ComboBox();
            this.inputProfileTextBox = new System.Windows.Forms.TextBox();
            this.inputProfileButton = new System.Windows.Forms.Button();
            this.outputProfileTextBox = new System.Windows.Forms.TextBox();
            this.outputProfileButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.previewCheckBox = new System.Windows.Forms.CheckBox();
            this.removeInputProfileButton = new System.Windows.Forms.Button();
            this.removeOutputProfileButton = new System.Windows.Forms.Button();
            this.colorTransformComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input Profile";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Output Profile";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Rendering Intent";
            // 
            // useBlackPointCompensationCheckBox
            // 
            this.useBlackPointCompensationCheckBox.AutoSize = true;
            this.useBlackPointCompensationCheckBox.Location = new System.Drawing.Point(10, 125);
            this.useBlackPointCompensationCheckBox.Name = "useBlackPointCompensationCheckBox";
            this.useBlackPointCompensationCheckBox.Size = new System.Drawing.Size(169, 17);
            this.useBlackPointCompensationCheckBox.TabIndex = 3;
            this.useBlackPointCompensationCheckBox.Text = "Use black point compensation";
            this.useBlackPointCompensationCheckBox.UseVisualStyleBackColor = true;
            this.useBlackPointCompensationCheckBox.CheckedChanged += new System.EventHandler(this.useBlackPointCompensationCheckBox_CheckedChanged);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(235, 199);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 4;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(316, 199);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // renderingIntentComboBox
            // 
            this.renderingIntentComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.renderingIntentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.renderingIntentComboBox.FormattingEnabled = true;
            this.renderingIntentComboBox.Location = new System.Drawing.Point(97, 98);
            this.renderingIntentComboBox.Name = "renderingIntentComboBox";
            this.renderingIntentComboBox.Size = new System.Drawing.Size(219, 21);
            this.renderingIntentComboBox.TabIndex = 6;
            this.renderingIntentComboBox.SelectedIndexChanged += new System.EventHandler(this.renderingIntentComboBox_SelectedIndexChanged);
            // 
            // inputProfileTextBox
            // 
            this.inputProfileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputProfileTextBox.Location = new System.Drawing.Point(10, 33);
            this.inputProfileTextBox.Name = "inputProfileTextBox";
            this.inputProfileTextBox.ReadOnly = true;
            this.inputProfileTextBox.Size = new System.Drawing.Size(306, 20);
            this.inputProfileTextBox.TabIndex = 7;
            // 
            // inputProfileButton
            // 
            this.inputProfileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.inputProfileButton.Location = new System.Drawing.Point(322, 33);
            this.inputProfileButton.Name = "inputProfileButton";
            this.inputProfileButton.Size = new System.Drawing.Size(24, 20);
            this.inputProfileButton.TabIndex = 8;
            this.inputProfileButton.Text = "...";
            this.inputProfileButton.UseVisualStyleBackColor = true;
            this.inputProfileButton.Click += new System.EventHandler(this.inputProfileButton_Click);
            // 
            // outputProfileTextBox
            // 
            this.outputProfileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputProfileTextBox.Location = new System.Drawing.Point(10, 72);
            this.outputProfileTextBox.Name = "outputProfileTextBox";
            this.outputProfileTextBox.ReadOnly = true;
            this.outputProfileTextBox.Size = new System.Drawing.Size(306, 20);
            this.outputProfileTextBox.TabIndex = 9;
            // 
            // outputProfileButton
            // 
            this.outputProfileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.outputProfileButton.Location = new System.Drawing.Point(322, 72);
            this.outputProfileButton.Name = "outputProfileButton";
            this.outputProfileButton.Size = new System.Drawing.Size(24, 20);
            this.outputProfileButton.TabIndex = 10;
            this.outputProfileButton.Text = "...";
            this.outputProfileButton.UseVisualStyleBackColor = true;
            this.outputProfileButton.Click += new System.EventHandler(this.outputProfileButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "ICC profiles|*.icc;*.icm|All files|*.*";
            // 
            // previewCheckBox
            // 
            this.previewCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.previewCheckBox.AutoSize = true;
            this.previewCheckBox.Location = new System.Drawing.Point(16, 203);
            this.previewCheckBox.Name = "previewCheckBox";
            this.previewCheckBox.Size = new System.Drawing.Size(143, 17);
            this.previewCheckBox.TabIndex = 47;
            this.previewCheckBox.Text = "Preview on ImageViewer";
            this.previewCheckBox.UseVisualStyleBackColor = true;
            this.previewCheckBox.CheckedChanged += new System.EventHandler(this.previewCheckBox_CheckedChanged);
            // 
            // removeInputProfileButton
            // 
            this.removeInputProfileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeInputProfileButton.Location = new System.Drawing.Point(350, 33);
            this.removeInputProfileButton.Name = "removeInputProfileButton";
            this.removeInputProfileButton.Size = new System.Drawing.Size(24, 20);
            this.removeInputProfileButton.TabIndex = 48;
            this.removeInputProfileButton.Text = "X";
            this.removeInputProfileButton.UseVisualStyleBackColor = true;
            this.removeInputProfileButton.Click += new System.EventHandler(this.removeInputProfileButton_Click);
            // 
            // removeOutputProfileButton
            // 
            this.removeOutputProfileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeOutputProfileButton.Location = new System.Drawing.Point(350, 72);
            this.removeOutputProfileButton.Name = "removeOutputProfileButton";
            this.removeOutputProfileButton.Size = new System.Drawing.Size(24, 20);
            this.removeOutputProfileButton.TabIndex = 49;
            this.removeOutputProfileButton.Text = "X";
            this.removeOutputProfileButton.UseVisualStyleBackColor = true;
            this.removeOutputProfileButton.Click += new System.EventHandler(this.removeOutputProfileButton_Click);
            // 
            // colorTransformComboBox
            // 
            this.colorTransformComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorTransformComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorTransformComboBox.FormattingEnabled = true;
            this.colorTransformComboBox.Location = new System.Drawing.Point(12, 12);
            this.colorTransformComboBox.Name = "colorTransformComboBox";
            this.colorTransformComboBox.Size = new System.Drawing.Size(381, 21);
            this.colorTransformComboBox.TabIndex = 50;
            this.colorTransformComboBox.SelectedIndexChanged += new System.EventHandler(this.colorTransformComboBox_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.useBlackPointCompensationCheckBox);
            this.groupBox1.Controls.Add(this.removeOutputProfileButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.removeInputProfileButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.outputProfileButton);
            this.groupBox1.Controls.Add(this.renderingIntentComboBox);
            this.groupBox1.Controls.Add(this.outputProfileTextBox);
            this.groupBox1.Controls.Add(this.inputProfileTextBox);
            this.groupBox1.Controls.Add(this.inputProfileButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 148);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ICC Color Transform";
            // 
            // ColorTransformForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(403, 234);
            this.Controls.Add(this.colorTransformComboBox);
            this.Controls.Add(this.previewCheckBox);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColorTransformForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Color Transform";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox useBlackPointCompensationCheckBox;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox renderingIntentComboBox;
        private System.Windows.Forms.TextBox inputProfileTextBox;
        private System.Windows.Forms.Button inputProfileButton;
        private System.Windows.Forms.TextBox outputProfileTextBox;
        private System.Windows.Forms.Button outputProfileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox previewCheckBox;
        private System.Windows.Forms.Button removeInputProfileButton;
        private System.Windows.Forms.Button removeOutputProfileButton;
        private System.Windows.Forms.ComboBox colorTransformComboBox;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}