namespace DemosCommonCode.CustomControls
{
    partial class TreeViewSearchControl
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
            this.findPatternTextBox = new System.Windows.Forms.TextBox();
            this.findButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // findPatternTextBox
            // 
            this.findPatternTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.findPatternTextBox.Location = new System.Drawing.Point(0, 2);
            this.findPatternTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.findPatternTextBox.Name = "findPatternTextBox";
            this.findPatternTextBox.Size = new System.Drawing.Size(93, 20);
            this.findPatternTextBox.TabIndex = 3;
            this.findPatternTextBox.TextChanged += new System.EventHandler(this.findPatternTextBox_TextChanged);
            this.findPatternTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.findPatternTextBox_KeyUp);
            // 
            // findButton
            // 
            this.findButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findButton.Location = new System.Drawing.Point(93, 1);
            this.findButton.Margin = new System.Windows.Forms.Padding(0);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(75, 23);
            this.findButton.TabIndex = 2;
            this.findButton.Text = "Find";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // TreeViewSearchControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.findPatternTextBox);
            this.Controls.Add(this.findButton);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TreeViewSearchControl";
            this.Size = new System.Drawing.Size(168, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox findPatternTextBox;
        private System.Windows.Forms.Button findButton;
    }
}