namespace DemosCommonCode.Imaging
{
    partial class DocumentLayoutSettingsEditorControl
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
            this.documentSettingsTabControl = new System.Windows.Forms.TabControl();
            this.allPagesLayoutSettingsTabPage = new System.Windows.Forms.TabPage();
            this.allPagesLayoutSettingsControl = new DemosCommonCode.Imaging.PageLayoutSettingsControl();
            this.evenPagesLayoutSettingsTabPage = new System.Windows.Forms.TabPage();
            this.evenPagesLayoutSettingsControl = new DemosCommonCode.Imaging.PageLayoutSettingsControl();
            this.oddPagesLayoutSettingsTabPage = new System.Windows.Forms.TabPage();
            this.oddPagesLayoutSettingsControl = new DemosCommonCode.Imaging.PageLayoutSettingsControl();
            this.documentSettingsTabControl.SuspendLayout();
            this.allPagesLayoutSettingsTabPage.SuspendLayout();
            this.evenPagesLayoutSettingsTabPage.SuspendLayout();
            this.oddPagesLayoutSettingsTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // documentSettingsTabControl
            // 
            this.documentSettingsTabControl.Controls.Add(this.allPagesLayoutSettingsTabPage);
            this.documentSettingsTabControl.Controls.Add(this.evenPagesLayoutSettingsTabPage);
            this.documentSettingsTabControl.Controls.Add(this.oddPagesLayoutSettingsTabPage);
            this.documentSettingsTabControl.Location = new System.Drawing.Point(0, 0);
            this.documentSettingsTabControl.Name = "documentSettingsTabControl";
            this.documentSettingsTabControl.SelectedIndex = 0;
            this.documentSettingsTabControl.Size = new System.Drawing.Size(352, 244);
            this.documentSettingsTabControl.TabIndex = 6;
            // 
            // allPagesLayoutSettingsTabPage
            // 
            this.allPagesLayoutSettingsTabPage.Controls.Add(this.allPagesLayoutSettingsControl);
            this.allPagesLayoutSettingsTabPage.Location = new System.Drawing.Point(4, 22);
            this.allPagesLayoutSettingsTabPage.Name = "allPagesLayoutSettingsTabPage";
            this.allPagesLayoutSettingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.allPagesLayoutSettingsTabPage.Size = new System.Drawing.Size(344, 218);
            this.allPagesLayoutSettingsTabPage.TabIndex = 0;
            this.allPagesLayoutSettingsTabPage.Text = "All pages";
            this.allPagesLayoutSettingsTabPage.UseVisualStyleBackColor = true;
            // 
            // allPagesLayoutSettingsControl
            // 
            this.allPagesLayoutSettingsControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.allPagesLayoutSettingsControl.Location = new System.Drawing.Point(6, 8);
            this.allPagesLayoutSettingsControl.MinimumSize = new System.Drawing.Size(223, 174);
            this.allPagesLayoutSettingsControl.Name = "allPagesLayoutSettingsControl";
            this.allPagesLayoutSettingsControl.PageLayoutSettings = null;
            this.allPagesLayoutSettingsControl.Size = new System.Drawing.Size(332, 204);
            this.allPagesLayoutSettingsControl.TabIndex = 1;
            // 
            // evenPagesLayoutSettingsTabPage
            // 
            this.evenPagesLayoutSettingsTabPage.Controls.Add(this.evenPagesLayoutSettingsControl);
            this.evenPagesLayoutSettingsTabPage.Location = new System.Drawing.Point(4, 22);
            this.evenPagesLayoutSettingsTabPage.Name = "evenPagesLayoutSettingsTabPage";
            this.evenPagesLayoutSettingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.evenPagesLayoutSettingsTabPage.Size = new System.Drawing.Size(344, 218);
            this.evenPagesLayoutSettingsTabPage.TabIndex = 1;
            this.evenPagesLayoutSettingsTabPage.Text = "Even pages";
            this.evenPagesLayoutSettingsTabPage.UseVisualStyleBackColor = true;
            // 
            // evenPagesLayoutSettingsControl
            // 
            this.evenPagesLayoutSettingsControl.Location = new System.Drawing.Point(6, 8);
            this.evenPagesLayoutSettingsControl.MinimumSize = new System.Drawing.Size(223, 174);
            this.evenPagesLayoutSettingsControl.Name = "evenPagesLayoutSettingsControl";
            this.evenPagesLayoutSettingsControl.PageLayoutSettings = null;
            this.evenPagesLayoutSettingsControl.Size = new System.Drawing.Size(332, 204);
            this.evenPagesLayoutSettingsControl.TabIndex = 1;
            // 
            // oddPagesLayoutSettingsTabPage
            // 
            this.oddPagesLayoutSettingsTabPage.Controls.Add(this.oddPagesLayoutSettingsControl);
            this.oddPagesLayoutSettingsTabPage.Location = new System.Drawing.Point(4, 22);
            this.oddPagesLayoutSettingsTabPage.Name = "oddPagesLayoutSettingsTabPage";
            this.oddPagesLayoutSettingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.oddPagesLayoutSettingsTabPage.Size = new System.Drawing.Size(344, 218);
            this.oddPagesLayoutSettingsTabPage.TabIndex = 2;
            this.oddPagesLayoutSettingsTabPage.Text = "Odd pages";
            this.oddPagesLayoutSettingsTabPage.UseVisualStyleBackColor = true;
            // 
            // oddPagesLayoutSettingsControl
            // 
            this.oddPagesLayoutSettingsControl.Location = new System.Drawing.Point(6, 8);
            this.oddPagesLayoutSettingsControl.MinimumSize = new System.Drawing.Size(223, 174);
            this.oddPagesLayoutSettingsControl.Name = "oddPagesLayoutSettingsControl";
            this.oddPagesLayoutSettingsControl.PageLayoutSettings = null;
            this.oddPagesLayoutSettingsControl.Size = new System.Drawing.Size(332, 204);
            this.oddPagesLayoutSettingsControl.TabIndex = 1;
            // 
            // DocumentLayoutSettingsEditorControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.documentSettingsTabControl);
            this.Name = "DocumentLayoutSettingsEditorControl";
            this.Size = new System.Drawing.Size(352, 244);
            this.documentSettingsTabControl.ResumeLayout(false);
            this.allPagesLayoutSettingsTabPage.ResumeLayout(false);
            this.evenPagesLayoutSettingsTabPage.ResumeLayout(false);
            this.oddPagesLayoutSettingsTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl documentSettingsTabControl;
        private System.Windows.Forms.TabPage allPagesLayoutSettingsTabPage;
        private PageLayoutSettingsControl allPagesLayoutSettingsControl;
        private System.Windows.Forms.TabPage evenPagesLayoutSettingsTabPage;
        private PageLayoutSettingsControl evenPagesLayoutSettingsControl;
        private System.Windows.Forms.TabPage oddPagesLayoutSettingsTabPage;
        private PageLayoutSettingsControl oddPagesLayoutSettingsControl;
    }
}