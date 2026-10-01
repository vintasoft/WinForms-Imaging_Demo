namespace CommonCode.Imaging
{
    partial class ImagePreviewForm
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
            Vintasoft.Imaging.UI.ThumbnailAppearance thumbnailAppearance1 = new Vintasoft.Imaging.UI.ThumbnailAppearance();
            Vintasoft.Imaging.UI.ThumbnailAppearance thumbnailAppearance2 = new Vintasoft.Imaging.UI.ThumbnailAppearance();
            Vintasoft.Imaging.UI.ThumbnailAppearance thumbnailAppearance3 = new Vintasoft.Imaging.UI.ThumbnailAppearance();
            Vintasoft.Imaging.UI.ThumbnailAppearance thumbnailAppearance4 = new Vintasoft.Imaging.UI.ThumbnailAppearance();
            Vintasoft.Imaging.UI.ThumbnailAppearance thumbnailAppearance5 = new Vintasoft.Imaging.UI.ThumbnailAppearance();
            Vintasoft.Imaging.UI.ThumbnailCaption thumbnailCaption1 = new Vintasoft.Imaging.UI.ThumbnailCaption();
            Vintasoft.Imaging.UI.ThumbnailAppearance thumbnailAppearance6 = new Vintasoft.Imaging.UI.ThumbnailAppearance();
            Vintasoft.Imaging.UI.ThumbnailAppearance thumbnailAppearance7 = new Vintasoft.Imaging.UI.ThumbnailAppearance();
            Vintasoft.Imaging.UI.ThumbnailAppearance thumbnailAppearance8 = new Vintasoft.Imaging.UI.ThumbnailAppearance();
            Vintasoft.Imaging.UI.ThumbnailAppearance thumbnailAppearance9 = new Vintasoft.Imaging.UI.ThumbnailAppearance();
            Vintasoft.Imaging.UI.ThumbnailAppearance thumbnailAppearance10 = new Vintasoft.Imaging.UI.ThumbnailAppearance();
            Vintasoft.Imaging.UI.ThumbnailCaption thumbnailCaption2 = new Vintasoft.Imaging.UI.ThumbnailCaption();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.folderPathTextBox = new System.Windows.Forms.TextBox();
            this.folderThumbnailViewer1 = new Vintasoft.Imaging.UI.FolderThumbnailViewer();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.thumbnailViewer1 = new Vintasoft.Imaging.UI.ThumbnailViewer();
            this.changeDirectoryButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.addAllButton = new System.Windows.Forms.Button();
            this.addSelectedButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.folderPathTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.folderThumbnailViewer1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.fileNameTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.thumbnailViewer1);
            this.splitContainer1.Size = new System.Drawing.Size(969, 508);
            this.splitContainer1.SplitterDistance = 484;
            this.splitContainer1.TabIndex = 0;
            // 
            // folderPathTextBox
            // 
            this.folderPathTextBox.Location = new System.Drawing.Point(0, 3);
            this.folderPathTextBox.Name = "folderPathTextBox";
            this.folderPathTextBox.ReadOnly = true;
            this.folderPathTextBox.Size = new System.Drawing.Size(481, 20);
            this.folderPathTextBox.TabIndex = 1;
            this.folderPathTextBox.WordWrap = false;
            this.folderPathTextBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.folderPathTextBox_MouseDoubleClick);
            // 
            // folderThumbnailViewer1
            // 
            this.folderThumbnailViewer1.AllowDrop = true;
            this.folderThumbnailViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.folderThumbnailViewer1.AutoScrollMinSize = new System.Drawing.Size(1, 1);
            this.folderThumbnailViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            thumbnailAppearance1.BackColor = System.Drawing.Color.Transparent;
            thumbnailAppearance1.BorderColor = System.Drawing.Color.Gray;
            thumbnailAppearance1.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Dotted;
            thumbnailAppearance1.BorderWidth = 1;
            this.folderThumbnailViewer1.FocusedThumbnailAppearance = thumbnailAppearance1;
            this.folderThumbnailViewer1.FolderPath = null;
            thumbnailAppearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(186)))), ((int)(((byte)(210)))), ((int)(((byte)(235)))));
            thumbnailAppearance2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(186)))), ((int)(((byte)(210)))), ((int)(((byte)(235)))));
            thumbnailAppearance2.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            thumbnailAppearance2.BorderWidth = 2;
            this.folderThumbnailViewer1.HoveredThumbnailAppearance = thumbnailAppearance2;
            this.folderThumbnailViewer1.ImageRotationAngle = 0;
            this.folderThumbnailViewer1.Location = new System.Drawing.Point(0, 26);
            this.folderThumbnailViewer1.MultiSelect = false;
            this.folderThumbnailViewer1.Name = "folderThumbnailViewer1";
            thumbnailAppearance3.BackColor = System.Drawing.Color.Black;
            thumbnailAppearance3.BorderColor = System.Drawing.Color.Black;
            thumbnailAppearance3.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            thumbnailAppearance3.BorderWidth = 0;
            this.folderThumbnailViewer1.NotReadyThumbnailAppearance = thumbnailAppearance3;
            thumbnailAppearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(238)))), ((int)(((byte)(253)))));
            thumbnailAppearance4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(222)))), ((int)(((byte)(253)))));
            thumbnailAppearance4.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            thumbnailAppearance4.BorderWidth = 1;
            this.folderThumbnailViewer1.SelectedThumbnailAppearance = thumbnailAppearance4;
            this.folderThumbnailViewer1.Size = new System.Drawing.Size(481, 480);
            this.folderThumbnailViewer1.TabIndex = 0;
            this.folderThumbnailViewer1.Text = "folderThumbnailViewer1";
            thumbnailAppearance5.BackColor = System.Drawing.Color.Transparent;
            thumbnailAppearance5.BorderColor = System.Drawing.Color.Transparent;
            thumbnailAppearance5.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            thumbnailAppearance5.BorderWidth = 1;
            this.folderThumbnailViewer1.ThumbnailAppearance = thumbnailAppearance5;
            thumbnailCaption1.IsVisible = true;
            thumbnailCaption1.Padding = new Vintasoft.Imaging.PaddingF(0F, 0F, 0F, 0F);
            thumbnailCaption1.TextColor = System.Drawing.Color.Black;
            this.folderThumbnailViewer1.ThumbnailCaption = thumbnailCaption1;
            this.folderThumbnailViewer1.ThumbnailFlowStyle = Vintasoft.Imaging.UI.ThumbnailFlowStyle.WrappedRows;
            this.folderThumbnailViewer1.ThumbnailMargin = new System.Windows.Forms.Padding(3);
            this.folderThumbnailViewer1.ThumbnailSize = new System.Drawing.Size(100, 145);
            this.folderThumbnailViewer1.FocusedIndexChanged += new System.EventHandler<Vintasoft.Imaging.UI.FocusedIndexChangedEventArgs>(this.folderThumbnailViewer1_FocusedIndexChanged);
            this.folderThumbnailViewer1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.folderThumbnailViewer1_MouseDoubleClick);
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fileNameTextBox.Location = new System.Drawing.Point(0, 3);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.ReadOnly = true;
            this.fileNameTextBox.Size = new System.Drawing.Size(479, 20);
            this.fileNameTextBox.TabIndex = 2;
            this.fileNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fileNameTextBox.WordWrap = false;
            // 
            // thumbnailViewer1
            // 
            this.thumbnailViewer1.AllowDrop = true;
            this.thumbnailViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.thumbnailViewer1.AutoScrollMinSize = new System.Drawing.Size(1, 1);
            this.thumbnailViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            thumbnailAppearance6.BackColor = System.Drawing.Color.Transparent;
            thumbnailAppearance6.BorderColor = System.Drawing.Color.Gray;
            thumbnailAppearance6.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Dotted;
            thumbnailAppearance6.BorderWidth = 1;
            this.thumbnailViewer1.FocusedThumbnailAppearance = thumbnailAppearance6;
            thumbnailAppearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(186)))), ((int)(((byte)(210)))), ((int)(((byte)(235)))));
            thumbnailAppearance7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(186)))), ((int)(((byte)(210)))), ((int)(((byte)(235)))));
            thumbnailAppearance7.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            thumbnailAppearance7.BorderWidth = 2;
            this.thumbnailViewer1.HoveredThumbnailAppearance = thumbnailAppearance7;
            this.thumbnailViewer1.ImageRotationAngle = 0;
            this.thumbnailViewer1.Location = new System.Drawing.Point(0, 26);
            this.thumbnailViewer1.Name = "thumbnailViewer1";
            thumbnailAppearance8.BackColor = System.Drawing.Color.Black;
            thumbnailAppearance8.BorderColor = System.Drawing.Color.Black;
            thumbnailAppearance8.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            thumbnailAppearance8.BorderWidth = 0;
            this.thumbnailViewer1.NotReadyThumbnailAppearance = thumbnailAppearance8;
            thumbnailAppearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(238)))), ((int)(((byte)(253)))));
            thumbnailAppearance9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(222)))), ((int)(((byte)(253)))));
            thumbnailAppearance9.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            thumbnailAppearance9.BorderWidth = 1;
            this.thumbnailViewer1.SelectedThumbnailAppearance = thumbnailAppearance9;
            this.thumbnailViewer1.Size = new System.Drawing.Size(479, 482);
            this.thumbnailViewer1.TabIndex = 0;
            this.thumbnailViewer1.Text = "thumbnailViewer1";
            thumbnailAppearance10.BackColor = System.Drawing.Color.Transparent;
            thumbnailAppearance10.BorderColor = System.Drawing.Color.Transparent;
            thumbnailAppearance10.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            thumbnailAppearance10.BorderWidth = 1;
            this.thumbnailViewer1.ThumbnailAppearance = thumbnailAppearance10;
            thumbnailCaption2.CaptionFormat = "Page {PageNumber}";
            thumbnailCaption2.IsVisible = true;
            thumbnailCaption2.Padding = new Vintasoft.Imaging.PaddingF(0F, 0F, 0F, 0F);
            thumbnailCaption2.TextColor = System.Drawing.Color.Black;
            this.thumbnailViewer1.ThumbnailCaption = thumbnailCaption2;
            this.thumbnailViewer1.ThumbnailFlowStyle = Vintasoft.Imaging.UI.ThumbnailFlowStyle.WrappedRows;
            this.thumbnailViewer1.ThumbnailMargin = new System.Windows.Forms.Padding(3);
            this.thumbnailViewer1.ThumbnailSize = new System.Drawing.Size(150, 200);
            // 
            // changeDirectoryButton
            // 
            this.changeDirectoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.changeDirectoryButton.Location = new System.Drawing.Point(3, 519);
            this.changeDirectoryButton.Name = "changeDirectoryButton";
            this.changeDirectoryButton.Size = new System.Drawing.Size(135, 23);
            this.changeDirectoryButton.TabIndex = 1;
            this.changeDirectoryButton.Text = "Change Directory...";
            this.changeDirectoryButton.UseVisualStyleBackColor = true;
            this.changeDirectoryButton.Click += new System.EventHandler(this.changeDirectoryButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(889, 519);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Colose";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // addAllButton
            // 
            this.addAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addAllButton.Location = new System.Drawing.Point(619, 519);
            this.addAllButton.Name = "addAllButton";
            this.addAllButton.Size = new System.Drawing.Size(129, 23);
            this.addAllButton.TabIndex = 3;
            this.addAllButton.Text = "Add All Images";
            this.addAllButton.UseVisualStyleBackColor = true;
            this.addAllButton.Click += new System.EventHandler(this.addAllButton_Click);
            // 
            // addSelectedButton
            // 
            this.addSelectedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addSelectedButton.Location = new System.Drawing.Point(754, 519);
            this.addSelectedButton.Name = "addSelectedButton";
            this.addSelectedButton.Size = new System.Drawing.Size(129, 23);
            this.addSelectedButton.TabIndex = 4;
            this.addSelectedButton.Text = "Add Selected Images";
            this.addSelectedButton.UseVisualStyleBackColor = true;
            this.addSelectedButton.Click += new System.EventHandler(this.addSelectedButton_Click);
            // 
            // ImagePreviewForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 551);
            this.Controls.Add(this.addSelectedButton);
            this.Controls.Add(this.addAllButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.changeDirectoryButton);
            this.Controls.Add(this.splitContainer1);
            this.MinimizeBox = false;
            this.Name = "ImagePreviewForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Images Preview";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Vintasoft.Imaging.UI.ThumbnailViewer thumbnailViewer1;
        private System.Windows.Forms.Button changeDirectoryButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button addAllButton;
        private System.Windows.Forms.Button addSelectedButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private Vintasoft.Imaging.UI.FolderThumbnailViewer folderThumbnailViewer1;
        private System.Windows.Forms.TextBox folderPathTextBox;
        private System.Windows.Forms.TextBox fileNameTextBox;
    }
}