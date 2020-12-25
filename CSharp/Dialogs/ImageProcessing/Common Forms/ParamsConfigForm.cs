using System.Windows.Forms;
using System.ComponentModel;

using Vintasoft.Imaging;
using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
    /// A base form that allows to view and edit settings of image processing command.
    /// </summary>
    public class ParamsConfigForm : Form
    {

        #region Fields

        /// <summary>
        /// Image processing preview in ImageViewer.
        /// </summary>
        ImageProcessingPreviewManager _imageProcessingPreviewInViewer;

        /// <summary>
        /// A value indicating whether this dialog is currently displayed.
        /// </summary>
        bool _isShown = false;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ParamsConfigForm"/> class.
        /// </summary>
        protected ParamsConfigForm()
            : base()
        {
            _imageProcessingPreviewInViewer = new ImageProcessingPreviewManager(null);
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="ParamsConfigForm"/> class.
        /// </summary>
        /// <param name="viewer">Image viewer to preview the processing result.</param>
        public ParamsConfigForm(ImageViewer viewer)
            : base()
        {
            _imageProcessingPreviewInViewer = new ImageProcessingPreviewManager(viewer);
        }

        #endregion



        #region Properties

        bool _isPreviewEnabled = true;
        /// <summary>
        /// Gets or sets a value indicating whether the preview in image viewer is enabled.
        /// </summary>
        [Browsable(false)]
        public virtual bool IsPreviewEnabled
        {
            get
            {
                return _isPreviewEnabled;
            }
            set
            {
                if (_isPreviewEnabled != value)
                {
                    _isPreviewEnabled = value;
                    if (_isShown)
                    {
                        if (_isPreviewEnabled)
                        {
                            _imageProcessingPreviewInViewer.StartPreview();
                            ExecuteProcessing();
                        }
                        else
                        {
                            _imageProcessingPreviewInViewer.StopPreview();
                        }
                    }
                }
            }
        }

        /// <summary> 
        /// Gets or sets a value indicating whether the zoom value, of image viewer, is used for previewing the image processing.
        /// </summary>
        [Browsable(false)]
        public bool UseCurrentViewerZoomWhenPreviewProcessing
        {
            get
            {
                return _imageProcessingPreviewInViewer.UseCurrentViewerZoomWhenPreviewProcessing;
            }
            set
            {
                _imageProcessingPreviewInViewer.UseCurrentViewerZoomWhenPreviewProcessing = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the processing command need to
        /// convert the processing image to the nearest pixel format without color loss
        /// if processing command does not support pixel format
        /// of the processing image.
        /// </summary>
        [Browsable(false)]
        public bool ExpandSupportedPixelFormats
        {
            get
            {
                return _imageProcessingPreviewInViewer.ExpandSupportedPixelFormats;
            }
            set
            {
                _imageProcessingPreviewInViewer.ExpandSupportedPixelFormats = value;
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Shows the processing dialog.
        /// </summary>
        /// <returns>
        /// <b>true</b> if form is closed and OK button is pressed;
        /// <b>false</b> if form is closed and not OK button is pressed.
        /// </returns>
        public bool ShowProcessingDialog()
        {
            try
            {
                if (IsPreviewEnabled)
                {
                    _imageProcessingPreviewInViewer.StartPreview();
                    ExecuteProcessing();
                }
                _isShown = true;
                return ShowDialog() == DialogResult.OK;
            }
            catch (ImageProcessingException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            finally
            {
                if (IsPreviewEnabled)
                {
                    if (IsPreviewEnabled)
                        _imageProcessingPreviewInViewer.StopPreview();
                    _isShown = false;
                }
            }
        }

        /// <summary>
        /// Returns the image processing command.
        /// </summary>
        /// <returns>The image processing command.</returns>
        public virtual ProcessingCommandBase GetProcessingCommand()
        {
            return null;
        }

        #endregion


        #region PROTECTED

        /// <summary>
        /// Executes the processing command.
        /// </summary>
        protected virtual void ExecuteProcessing()
        {
            ProcessingCommandBase command = GetProcessingCommand();
            if (command != null)
                _imageProcessingPreviewInViewer.SetCommand(command);
        }

        #endregion

        #endregion

    }
}