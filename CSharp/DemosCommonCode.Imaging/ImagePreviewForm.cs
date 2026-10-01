using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.UI;

namespace CommonCode.Imaging
{
    /// <summary>
    /// A form that allows to add images to an image collection with preview.
    /// </summary>
    public partial class ImagePreviewForm : Form
    {

        #region Fields

        /// <summary>
        /// The last folder path.
        /// </summary>
        static string LastFolderPath = Environment.CurrentDirectory;

        /// <summary>
        /// Manages asynchronous operations of thumbnail viewer images.
        /// </summary>
        ImageViewerImagesManager _imagesManager;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ImagePreviewForm"/> class.
        /// </summary>
        public ImagePreviewForm()
        {
            InitializeComponent();

            _imagesManager = new ImageViewerImagesManager(thumbnailViewer1);

            DocumentPasswordForm.EnableAuthentication(thumbnailViewer1);

            FolderPath = LastFolderPath;

            DestImagesManager = null;

            thumbnailViewer1.SelectedIndices.Changed += SelectedIndices_Changed;
            thumbnailViewer1.Images.ImageCollectionChanged += thumbnailViewer_Images_ImageCollectionChanged;
            addSelectedButton.Enabled = false;
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets or sets the path to the folder that should be monitored by the folder thumbnail viewer.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FolderPath
        {
            get
            {
                return folderThumbnailViewer1.FolderPath;
            }
            set
            {
                folderThumbnailViewer1.FolderPath = value;
                folderPathTextBox.Text = value;
                LastFolderPath = value;
            }
        }

        ImageCollectionManager _destImagesManager = null;
        /// <summary>
        /// Gets or sets the destination images manager, which must be used to add images.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ImageCollectionManager DestImagesManager
        {
            get
            {
                return _destImagesManager;
            }
            set
            {
                _destImagesManager = value;
                addAllButton.Visible = value != null;
                addSelectedButton.Visible = value != null;
                if (value != null)
                {
                    // copy layout settings
                    value.Images.LayoutSettings.CopyTo(folderThumbnailViewer1.Images.LayoutSettings);
                    value.Images.LayoutSettings.CopyTo(thumbnailViewer1.Images.LayoutSettings);
                }
            }
        }

        #endregion



        #region Methods

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (!e.Cancel)
            {
                _imagesManager.Cancel();
                folderThumbnailViewer1.FolderPath = null;
            }
        }

        /// <summary>
        /// Changes folder path in FolderThumbnailViewer.
        /// </summary>
        private void changeDirectoryButton_Click(object sender, EventArgs e)
        {
            ChangeDirectory();
        }

        /// <summary>
        /// Changes folder path.
        /// </summary>
        private void ChangeDirectory()
        {
            folderBrowserDialog1.SelectedPath = FolderPath;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                FolderPath = folderBrowserDialog1.SelectedPath;
        }

        /// <summary>
        /// Sets the focused image file.
        /// </summary>
        private void folderThumbnailViewer1_FocusedIndexChanged(object sender, Vintasoft.Imaging.UI.FocusedIndexChangedEventArgs e)
        {
            _imagesManager.Cancel();
            _imagesManager.Images.ClearAndDisposeItems();
            FolderThumbnailViewer.FileThumbnailInfo fileThumbnailInfo = folderThumbnailViewer1.FocusedFileThumbnailInfo;
            if (fileThumbnailInfo != null)
            {
                if (fileThumbnailInfo.LoadingError != null)
                {
                    DemosTools.ShowErrorMessage(fileThumbnailInfo.LoadingError);
                }
                else
                {
                    _imagesManager.Add(fileThumbnailInfo.Filename, true);
                }
            }
        }

        /// <summary>
        /// Adds all pages to the destiation image collection manager.
        /// </summary>
        private void addAllButton_Click(object sender, EventArgs e)
        {
            DestImagesManager.Add(folderThumbnailViewer1.FocusedFilename);
        }

        /// <summary>
        /// Adds selected pages to the destiation image collection manager.
        /// </summary>
        private void addSelectedButton_Click(object sender, EventArgs e)
        {
            foreach (VintasoftImage image in thumbnailViewer1.GetSelectedImages())
                DestImagesManager.Images.Add(new VintasoftImage(image.SourceInfo.Decoder, image.SourceInfo.PageIndex));
        }

        /// <summary>
        /// Handles the Click event of closeButton object.
        /// </summary>
        private void closeButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Handles the Changed event of SelectedIndices object.
        /// </summary>
        private void SelectedIndices_Changed(object sender, EventArgs e)
        {
            addSelectedButton.Enabled = thumbnailViewer1.SelectedIndices.Count > 0;
        }

        /// <summary>
        /// Handles the Images_ImageCollectionChanged event of thumbnailViewer object.
        /// </summary>
        private void thumbnailViewer_Images_ImageCollectionChanged(object sender, ImageCollectionChangeEventArgs e)
        {
            if (InvokeRequired)
                Invoke(new ThreadStart(UpdateFilenameText));
            else
                UpdateFilenameText();
        }

        /// <summary>
        /// Updates the filename text.
        /// </summary>
        private void UpdateFilenameText()
        {
            int pageCount = thumbnailViewer1.Images.Count;
            if (pageCount == 0)
            {
                if (folderThumbnailViewer1.FocusedFilename != null)
                    fileNameTextBox.Text = Path.GetFileName(folderThumbnailViewer1.FocusedFilename);
                else
                    fileNameTextBox.Text = "";
            }
            else
            {
                string filename = Path.GetFileName(thumbnailViewer1.Images[0].SourceInfo.Filename);
                if (pageCount > 1)
                    fileNameTextBox.Text = string.Format("{0} ({1} pages)", filename, pageCount);
                else
                    fileNameTextBox.Text = filename;
            }
        }

        /// <summary>
        /// Handles the MouseDoubleClick event of folderPathTextBox object.
        /// </summary>
        private void folderPathTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeDirectory();
        }

        /// <summary>
        /// Handles the MouseDoubleClick event of folderThumbnailViewer1 object.
        /// </summary>
        private void folderThumbnailViewer1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (DestImagesManager != null)
            {
                int thumbnailIndex = folderThumbnailViewer1.PointToThumbnailIndex(e.Location);
                if (thumbnailIndex >= 0)
                {
                    DestImagesManager.Images.ImageCollectionChanged += SetFocusedIndexToAddedImage;

                    DestImagesManager.Add(folderThumbnailViewer1.FocusedFilename);

                    DialogResult = DialogResult.OK;
                }
            }
        }

        /// <summary>
        /// Sets the focused index to added image.
        /// </summary>
        private void SetFocusedIndexToAddedImage(object sender, ImageCollectionChangeEventArgs e)
        {
            if (e.Action == ImageCollectionChangeAction.AddImages)
            {
                ((ImageCollection)sender).ImageCollectionChanged -= SetFocusedIndexToAddedImage;
                if (DestImagesManager is ImageViewerImagesManager)
                {
                    ImageViewerBase imageViewer = ((ImageViewerImagesManager)DestImagesManager).ImageViewer;
                    imageViewer.FocusedIndex = imageViewer.Images.IndexOf(e.Images[0]);
                }
            }
        }

        #endregion

    }
}
