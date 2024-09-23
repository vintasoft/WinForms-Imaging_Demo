using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

using Vintasoft.Data;
using Vintasoft.Imaging;
using Vintasoft.Imaging.Codecs.Decoders;
using Vintasoft.Imaging.Codecs.Encoders;
using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Color;
using Vintasoft.Imaging.ImageProcessing.Document;
using Vintasoft.Imaging.ImageProcessing.Effects;
using Vintasoft.Imaging.ImageProcessing.Fft.Filtering.Highpass;
using Vintasoft.Imaging.ImageProcessing.Fft.Filtering.Lowpass;
using Vintasoft.Imaging.ImageProcessing.Filters;
using Vintasoft.Imaging.ImageProcessing.Transforms;
using Vintasoft.Imaging.Media;
using Vintasoft.Imaging.Metadata;
using Vintasoft.Imaging.UI;
using Vintasoft.Imaging.UIActions;
using Vintasoft.Imaging.UI.VisualTools;
using Vintasoft.Imaging.UI.VisualTools.UserInteraction;
using Vintasoft.Imaging.Undo;

using DemosCommonCode;
using DemosCommonCode.Imaging;
using DemosCommonCode.Imaging.Codecs;
using DemosCommonCode.Imaging.ColorManagement;
using DemosCommonCode.Twain;
using DemosCommonCode.Barcode;
#if !REMOVE_BARCODE_SDK
using Vintasoft.Barcode;
#endif
#if !REMOVE_PDF_PLUGIN
using Vintasoft.Imaging.Pdf.Tree;
using Vintasoft.Imaging.Pdf;
#endif

namespace ImagingDemo
{
    /// <summary>
    /// The main form of Imaging Demo.
    /// </summary>
    public partial class MainForm : Form
    {

        #region Fields

        /// <summary>
        /// Template of the application's title.
        /// </summary>
        string _titlePrefix = "VintaSoft Imaging Demo v" + ImagingGlobalSettings.ProductVersion + " - {0}";

        /// <summary>
        /// Selected "View - Image scale mode" menu item.
        /// </summary>
        ToolStripMenuItem _imageScaleSelectedMenuItem;

        /// <summary>
        /// Image map tool.
        /// </summary>
        ImageMapTool _imageMapTool;

        /// <summary>
        /// The location of the selection tool context menu.
        /// </summary>
        PointF _selectionContextMenuStripLocation;

        /// <summary>
        /// Manages the layout settings of DOCX document image collections.
        /// </summary>
        ImageCollectionDocxLayoutSettingsManager _imageCollectionDocxLayoutSettingsManager;

        /// <summary>
        /// Manages the layout settings of XLSX document image collections.
        /// </summary>
        ImageCollectionXlsxLayoutSettingsManager _imageCollectionXlsxLayoutSettingsManager;


        #region Open

        /// <summary>
        /// Name of the first image file in the image collection of the image viewer.
        /// </summary>
        string _sourceFilename;

        /// <summary>
        /// Decoder name of the first image file in the image collection of the image viewer.
        /// </summary>
        string _sourceDecoderName;

        /// <summary>
        /// Determines that file is opened in read-only mode.
        /// </summary>
        bool _isFileReadOnlyMode = false;

        /// <summary>
        /// Determines that the Open File Dialog is opened.
        /// </summary>
        bool _isFileDialogOpened = false;

        /// <summary>
        /// A value indicating whether the source image file is changing.
        /// </summary> 
        bool _isSourceChanging = false;

        /// <summary>
        /// Manages asynchronous operations of an image viewer images.
        /// </summary>
        ImageViewerImagesManager _imagesManager;

        #endregion


        #region Load

        /// <summary>
        /// The time when image loading is started.
        /// </summary>
        DateTime _imageLoadingStartTime;

        /// <summary>
        /// The image loading time.
        /// </summary>
        TimeSpan _imageLoadingTime = TimeSpan.Zero;

        /// <summary>
        /// A value indicating whether image collection has been changed.
        /// </summary>
        bool _isImageCollectionChanged = false;

        #endregion


        #region Save

        /// <summary>
        /// A name of file, where image collection of image viewer must be saved.
        /// </summary>
        string _saveFilename;

        /// <summary>
        /// A name that defines image encoder that must be used to save image collection of the image viewer.
        /// </summary>
        string _encoderName;

        /// <summary>
        /// An image encoder that must be used to save image collection of the image viewer.
        /// </summary>
        EncoderBase _encoder = null;

        /// <summary>
        /// A value indicating whether image saving must be canceled.
        /// </summary>
        bool _cancelImageSaving = false;

        #endregion


        #region Print

        /// <summary>
        /// ThumbnailViewer print manager.
        /// </summary>
        ImageViewerPrintManager _thumbnailViewerPrintManager;

        #endregion


        #region TWAIN scanning

        /// <summary>
        /// Simple TWAIN manager.
        /// </summary>
        SimpleTwainManager _simpleTwainManager;

        #endregion


        #region Camera

        /// <summary>
        /// Opened webcam preview forms.
        /// </summary>
        List<WebcamPreviewForm> _webcamForms = new List<WebcamPreviewForm>();

        #endregion


        /// <summary>
        /// Image processing command executor.
        /// </summary>
        ImageProcessingCommandExecutor _imageProcessingCommandExecutor;


        #region Image processing undo manager

        /// <summary>
        /// A form that allows to view the image processing history.
        /// </summary>
        UndoManagerHistoryForm _historyForm;

        /// <summary>
        /// A value indicating whether to keep undo information for all images or only for the focused image.
        /// </summary>
        /// <value>
        /// <b>true</b> - undo information for focused image is kept;
        /// <b>false</b> - undo information for all images are kept.
        /// </value>
        bool _keepUndoForCurrentImageOnly = false;

        /// <summary>
        /// The undo manager.
        /// </summary>
        UndoManager _undoManager;

        /// <summary>
        /// The undo monitor of the image viewer.
        /// </summary>
        ImageViewerUndoMonitor _imageViewerUndoMonitor = null;

        /// <summary>
        /// The data storage of undo monitors.
        /// </summary>
        IDataStorage _dataStorage = null;

        /// <summary>
        /// The maximum number of undo levels.
        /// </summary>
        int _undoLevel = 10;

        #endregion


        /// <summary>
        /// A form that allows direct access to the mage pixels.
        /// </summary>
        DirectPixelAccessForm _directPixelAccessForm;

        /// <summary>
        /// A value indicating whether ESC key is pressed.
        /// </summary>
        bool _isEscKeyPressed = false;

        /// <summary>
        /// A value indicating whether the application form is closing.
        /// </summary> 
        bool _isFormClosing = false;

        /// <summary>
        /// A value indicating whether the visual tool is changing.
        /// </summary> 
        bool _isVisualToolChanging = false;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes the <see cref="MainForm"/> class.
        /// </summary>
        static MainForm()
        {
            WsiCodecAssembly.Init();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            // register the evaluation license for VintaSoft Imaging .NET SDK
            Vintasoft.Imaging.ImagingGlobalSettings.Register("REG_USER", "REG_EMAIL", "EXPIRATION_DATE", "REG_CODE");

            InitializeComponent();

            Jbig2AssemblyLoader.Load();
            Jpeg2000AssemblyLoader.Load();
            RawAssemblyLoader.Load();
            DicomAssemblyLoader.Load();
            PdfAnnotationsAssemblyLoader.Load();
            PdfAssemblyLoader.Load();
            DocxAssemblyLoader.Load();
            PdfOfficeAssemblyLoader.Load();
#if NETCORE
            WebpCodecAssemblyLoader.Load();
#endif

            ImagingTypeEditorRegistrator.Register();

            // set CustomFontProgramsController for all opened documents
            CustomFontProgramsController.SetDefaultFontProgramsController();

            _imageMapTool = new ImageMapTool();

            viewerToolStrip.ImageViewer = imageViewer1;

            thumbnailViewer1.ThumbnailRenderingThreadCount = Math.Max(1, Environment.ProcessorCount / 2);

            imageViewer1.Images.ImageCollectionChanged += new EventHandler<ImageCollectionChangeEventArgs>(imageViewer1_Images_ImageCollectionChanged);

            // init "View => Image Display Mode" menu
            singlePageToolStripMenuItem.Tag = ImageViewerDisplayMode.SinglePage;
            twoColumnsToolStripMenuItem.Tag = ImageViewerDisplayMode.TwoColumns;
            singleContinuousRowToolStripMenuItem.Tag = ImageViewerDisplayMode.SingleContinuousRow;
            singleContinuousColumnToolStripMenuItem.Tag = ImageViewerDisplayMode.SingleContinuousColumn;
            twoContinuousRowsToolStripMenuItem.Tag = ImageViewerDisplayMode.TwoContinuousRows;
            twoContinuousColumnsToolStripMenuItem.Tag = ImageViewerDisplayMode.TwoContinuousColumns;

            // init "View => Image Scale Mode" menu
            normalImageToolStripMenuItem.Tag = ImageSizeMode.Normal;
            bestFitToolStripMenuItem.Tag = ImageSizeMode.BestFit;
            fitToWidthToolStripMenuItem.Tag = ImageSizeMode.FitToWidth;
            fitToHeightToolStripMenuItem.Tag = ImageSizeMode.FitToHeight;
            pixelToPixelToolStripMenuItem.Tag = ImageSizeMode.PixelToPixel;
            scaleToolStripMenuItem.Tag = ImageSizeMode.Zoom;
            scale25ToolStripMenuItem.Tag = 25;
            scale50ToolStripMenuItem.Tag = 50;
            scale100ToolStripMenuItem.Tag = 100;
            scale200ToolStripMenuItem.Tag = 200;
            scale400ToolStripMenuItem.Tag = 400;
            _imageScaleSelectedMenuItem = normalImageToolStripMenuItem;
            _imageScaleSelectedMenuItem.Checked = true;

            // create the print manager
            _thumbnailViewerPrintManager = new ImageViewerPrintManager(thumbnailViewer1, imagePrintDocument1, printDialog1);

            // create the image processing executor
            _imageProcessingCommandExecutor = new ImageProcessingCommandExecutor(imageViewer1);
            _imageProcessingCommandExecutor.ImageProcessingCommandStarted += new EventHandler<ImageProcessingEventArgs>(imageProcessingCommandExecutor_ImageProcessingCommandStarted);
            _imageProcessingCommandExecutor.ImageProcessingCommandProgress += new EventHandler<ImageProcessingProgressEventArgs>(imageProcessingCommandExecutor_ImageProcessingCommandProgress);
            _imageProcessingCommandExecutor.ImageProcessingCommandFinished += new EventHandler<ImageProcessedEventArgs>(imageProcessingCommandExecutor_ImageProcessingCommandFinished);

            // create the image undo managers
            enableUndoRedoToolStripMenuItem.Checked = false;
            CreateUndoManager(_keepUndoForCurrentImageOnly);
            UpdateUndoRedoMenu(_undoManager);

            // create images manager
            _imagesManager = new ImageViewerImagesManager(imageViewer1);
            _imagesManager.IsAsync = true;
            _imagesManager.AddStarting += new EventHandler(ImagesManager_AddStarting);
            _imagesManager.AddFinished += new EventHandler(ImagesManager_AddFinished);
            _imagesManager.ImageSourceAddStarting += new EventHandler<ImageSourceEventArgs>(ImagesManager_ImageSourceAddStarting);
            _imagesManager.ImageSourceAddFinished += new EventHandler<ImageSourceEventArgs>(ImagesManager_ImageSourceAddFinished);
            _imagesManager.ImageSourceAddException += new EventHandler<ImageSourceExceptionEventArgs>(ImagesManager_ImageSourceAddException);

            // set filters in open dialog
            CodecsFileFilters.SetOpenFileDialogFilter(openImageFileDialog);

            // set the initial directory in open file dialog
            DemosTools.SetTestFilesFolder(openImageFileDialog);

            DemosTools.CatchVisualToolExceptions(imageViewer1);

            editToolStripMenuItem.DropDownOpening += new EventHandler(editToolStripMenuItem_DropDownOpening);


            SelectionVisualToolActionFactory.CreateActions(visualToolsToolStrip1);
            MeasurementVisualToolActionFactory.CreateActions(visualToolsToolStrip1);
            ZoomVisualToolActionFactory.CreateActions(visualToolsToolStrip1);
            ImageProcessingVisualToolActionFactory.CreateActions(visualToolsToolStrip1);
            CustomVisualToolActionFactory.CreateActions(visualToolsToolStrip1);
            BarcodeReaderToolActionFactory.CreateActions(visualToolsToolStrip1);
            BarcodeWriterToolActionFactory.CreateActions(visualToolsToolStrip1);

            // set default rendering settings
#if REMOVE_PDF_PLUGIN && REMOVE_OFFICE_PLUGIN
            imageViewer1.ImageRenderingSettings = RenderingSettings.Empty;
#elif REMOVE_OFFICE_PLUGIN
            imageViewer1.ImageRenderingSettings = new PdfRenderingSettings();
#elif REMOVE_PDF_PLUGIN
            imageViewer1.ImageRenderingSettings = new CompositeRenderingSettings(
                new DocxRenderingSettings(),
                new XlsxRenderingSettings());
#else
            imageViewer1.ImageRenderingSettings = new CompositeRenderingSettings(
                new PdfRenderingSettings(),
                new DocxRenderingSettings(),
                new XlsxRenderingSettings());
#endif

            // initialize color management in viewer
            ColorManagementHelper.EnableColorManagement(imageViewer1);

            UpdateUI();

            imageViewer1.Focus();

            DocumentPasswordForm.EnableAuthentication(imageViewer1);

#if !REMOVE_OFFICE_PLUGIN
            // specify that image collection of image viewer must handle layout settings requests
            _imageCollectionDocxLayoutSettingsManager = new ImageCollectionDocxLayoutSettingsManager(imageViewer1.Images);
            _imageCollectionXlsxLayoutSettingsManager = new ImageCollectionXlsxLayoutSettingsManager(imageViewer1.Images);
#else
            documentLayoutSettingsToolStripMenuItem.Visible = false;
#endif
        }

        #endregion



        #region Properties

        bool _isImageLoaded = false;
        /// <summary>
        /// Gets or sets a value indicating whether image is loaded.
        /// </summary>
        bool IsImageLoaded
        {
            get { return _isImageLoaded; }
            set
            {
                _isImageLoaded = value;

                UpdateUI();
            }
        }

        bool _isImageProcessing = false;
        /// <summary>
        /// Gets or sets a value indicating whether image is processing.
        /// </summary>
        internal bool IsImageProcessing
        {
            get { return _isImageProcessing; }
            set
            {
                _isImageProcessing = value;

                UpdateUI();
            }
        }

        bool _isFileOpening = false;
        /// <summary>
        /// Gets or sets a value indicating whether file is opening.
        /// </summary>
        internal bool IsFileOpening
        {
            get
            {
                return _isFileOpening;
            }
            set
            {
                _isFileOpening = value;

                if (_isFileOpening)
                {
                    Cursor = Cursors.AppStarting;
                }
                else
                {
                    Cursor = Cursors.Default;
                    imageViewer1.Focus();
                }

                UpdateUI();
            }
        }

        bool _isImageSaving = false;
        /// <summary>
        /// Gets or sets a value indicating whether image is saving.
        /// </summary>
        bool IsImageSaving
        {
            get { return _isImageSaving; }
            set
            {
                _isImageSaving = value;

                InvokeUpdateUI();
            }
        }

        #endregion



        #region Methods

        #region PROTECTED

        /// <summary>
        /// Processes a command key.
        /// </summary>
        /// <param name="msg">A <see cref="T:System.Windows.Forms.Message" />,
        /// passed by reference, that represents the window message to process.</param>
        /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys" /> values
        /// that represents the key to process.</param>
        /// <returns>
        /// <b>true</b> if the character was processed by the control; otherwise, <b>false</b>.
        /// </returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Shift | Keys.Control | Keys.Add))
            {
                RotateViewClockwise();
                return true;
            }

            if (keyData == (Keys.Shift | Keys.Control | Keys.Subtract))
            {
                RotateViewCounterClockwise();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion


        #region PRIVATE

        #region UI

        #region Main form

        /// <summary>
        /// Handles the Shown event of MainForm object.
        /// </summary>
        private void MainForm_Shown(object sender, EventArgs e)
        {
            // process command line of the application
            string[] appArgs = Environment.GetCommandLineArgs();
            if (appArgs.Length > 0)
            {
                Application.DoEvents();
                if (appArgs.Length == 2)
                {
                    try
                    {
                        // add image file to the image viewer
                        OpenFile(appArgs[1]);
                    }
                    catch (Exception ex)
                    {
                        DemosTools.ShowErrorMessage(ex);
                    }
                }
                else
                {
                    // get filenames from application arguments
                    string[] filenames = new string[appArgs.Length - 1];
                    Array.Copy(appArgs, 1, filenames, 0, filenames.Length);

                    try
                    {
                        // add image file(s) to image collection of the image viewer
                        AddFiles(filenames);
                    }
                    catch (Exception ex)
                    {
                        DemosTools.ShowErrorMessage(ex);
                    }
                }
            }

            thumbnailViewer1.Focus();
        }

        /// <summary>
        /// Handles the KeyDown event of MainForm object.
        /// </summary>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            // check if escape key is pressed
            _isEscKeyPressed = e.KeyData == Keys.Escape;
        }

        /// <summary>
        /// Handles the FormClosing event of MainForm object.
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _isFormClosing = true;

            foreach (WebcamPreviewForm form in _webcamForms)
            {
                if (form.Visible)
                    form.Close();
            }

            // do not close the application form while image loading is not canceled/finished
            if (_isFileDialogOpened)
                e.Cancel = true;
        }

        /// <summary>
        /// Handles the FormClosed event of MainForm object.
        /// </summary>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseCurrentFile();

            ClearHistory();

            DisposeUndoManager();

            if (_dataStorage != null)
                _dataStorage.Dispose();

            _imagesManager.Dispose();
        }

        #endregion


        #region 'File' menu

        /// <summary>
        /// Handles the DropDownOpening event of fileToolStripMenuItem object.
        /// </summary>
        private void fileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            UpdateUI();
            if (!Clipboard.ContainsImage())
            {
                addFromClipboardToolStripMenuItem.Enabled = false;
            }
        }

        /// <summary>
        /// Handles the Click event of newToolStripMenuItem object.
        /// </summary>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (CreateNewImageForm dlg = new CreateNewImageForm())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    // create and add new image to the image collection of the image viewer
                    VintasoftImage image = dlg.CreateImage();
                    imageViewer1.Images.Add(image);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of openToolStripMenuItem object.
        /// </summary>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_isFileDialogOpened)
                return;

            _isFileDialogOpened = true;

            // select image file
            if (openImageFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    // add image file to image viewer as a source
                    OpenFile(openImageFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                }
            }

            _isFileDialogOpened = false;
        }

        /// <summary>
        /// Handles the Click event of addToolStripMenuItem object.
        /// </summary>
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_isFileDialogOpened)
                return;

            _isFileDialogOpened = true;
            openImageFileDialog.Multiselect = true;

            // select image file(s)
            if (openImageFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    // add image file(s) to image collection of the image viewer
                    AddFiles(openImageFileDialog.FileNames);
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                }
            }

            openImageFileDialog.Multiselect = false;
            _isFileDialogOpened = false;
        }

        /// <summary>
        /// Handles the Click event of docxLayoutSettingsToolStripMenuItem object.
        /// </summary>
        private void docxLayoutSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageCollectionDocxLayoutSettingsManager.EditLayoutSettingsUseDialog();
        }

        /// <summary>
        /// Handles the Click event of xlsxLayoutSettingsToolStripMenuItem object.
        /// </summary>
        private void xlsxLayoutSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageCollectionXlsxLayoutSettingsManager.EditLayoutSettingsUseDialog();
        }

        /// <summary>
        /// Handles the Click event of addFromClipboardToolStripMenuItem object.
        /// </summary>
        private void addFromClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                // add image from clipboard to the image collection of the image viewer
                Image bitmap = Clipboard.GetImage();
                VintasoftImage image = VintasoftImageGdiExtensions.Create(bitmap, true);
                imageViewer1.Images.Add(image);

                // update the UI
                Update();
            }
        }

        /// <summary>
        /// Handles the Click event of acquireFromScannerToolStripMenuItem object.
        /// </summary>
        private void acquireFromScannerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool scanMenuEnabled = acquireFromScannerToolStripMenuItem.Enabled;
            acquireFromScannerToolStripMenuItem.Enabled = false;
            bool viewerToolStripCanScan = viewerToolStrip.CanScan;
            viewerToolStrip.ScanButtonEnabled = false;

            try
            {
                if (_simpleTwainManager == null)
                {
                    _simpleTwainManager = new SimpleTwainManager(this, imageViewer1.Images);
                }

                // acquire image(s) from scanner
                _simpleTwainManager.SelectDeviceAndAcquireImage();
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
            finally
            {
                acquireFromScannerToolStripMenuItem.Enabled = scanMenuEnabled;
                viewerToolStrip.ScanButtonEnabled = viewerToolStripCanScan;
            }
        }

        /// <summary>
        /// Handles the Click event of captureFromCameraToolStripMenuItem object.
        /// </summary>
        private void captureFromCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ImageCaptureDevice device = WebcamSelectionForm.SelectWebcam();
                if (device != null)
                {
                    // capture image(s) from camera (webcam)
                    WebcamPreviewForm webcamForm = new WebcamPreviewForm(device);
                    webcamForm.Owner = this;
                    webcamForm.SnapshotViewer = imageViewer1;
                    _webcamForms.Add(webcamForm);
                    webcamForm.Show();
                }
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of saveChangesToolStripMenuItem object.
        /// </summary>
        private void saveChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EncoderBase encoder = null;
            try
            {
                if (PluginsEncoderFactory.Default.GetEncoderByName(_sourceDecoderName, out encoder))
                {
                    // save changes in image collection to the source file
                    SaveImageCollection(imageViewer1.Images, _sourceFilename, encoder, true);
                }
                else
                {
                    DemosTools.ShowErrorMessage("Image is not saved.");
                }
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of saveAsToolStripMenuItem object.
        /// </summary>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_isFileDialogOpened)
                return;

            _isFileDialogOpened = true;

            bool saveSingleImage = imageViewer1.Images.Count == 1;

            try
            {
                CodecsFileFilters.SetSaveFileDialogFilter(saveImageFileDialog, !saveSingleImage, false);
                if (saveImageFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string filename = saveImageFileDialog.FileName;

                    PluginsEncoderFactory encoderFactory = new PluginsEncoderFactory();
                    encoderFactory.CanAddImagesToExistingFile = false;

                    EncoderBase encoder = null;
                    if (encoderFactory.GetEncoder(filename, out encoder))
                    {
                        // save image collection to a new source and switch to it
                        SaveImageCollection(imageViewer1.Images, filename, encoder, true);
                    }
                    else
                    {
                        DemosTools.ShowErrorMessage("Images are not saved.");
                    }
                }
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }

            _isFileDialogOpened = false;
        }

        /// <summary>
        /// Handles the Click event of saveToToolStripMenuItem object.
        /// </summary>
        private void saveToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_isFileDialogOpened)
                return;

            _isFileDialogOpened = true;

            bool saveSingleImage = imageViewer1.Images.Count == 1;

            CodecsFileFilters.SetSaveFileDialogFilter(saveImageFileDialog, !saveSingleImage, false);
            if (saveImageFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename = Path.GetFullPath(saveImageFileDialog.FileName);
                bool isFileExist = File.Exists(filename);

                try
                {
                    PluginsEncoderFactory encoderFactory = new PluginsEncoderFactory();
                    encoderFactory.CanAddImagesToExistingFile = isFileExist;

                    EncoderBase encoder = null;
                    if (encoderFactory.GetEncoder(filename, out encoder))
                    {
                        // save image collection to a new source without switching to it
                        SaveImageCollection(imageViewer1.Images, filename, encoder, false);
                    }
                    else
                    {
                        DemosTools.ShowErrorMessage("Image is not saved.");
                    }
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                }
            }

            _isFileDialogOpened = false;
        }

        /// <summary>
        /// Handles the Click event of saveToDocxToolStripMenuItem object.
        /// </summary>
        private void saveToDocxToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if !REMOVE_OFFICE_PLUGIN && !REMOVE_PDF_PLUGIN
            if (_isFileDialogOpened)
                return;

            _isFileDialogOpened = true;

            saveImageFileDialog.Filter = "DOCX files|*.docx";
            if (saveImageFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename = Path.GetFullPath(saveImageFileDialog.FileName);
                bool isFileExist = File.Exists(filename);

                try
                {
                    EncoderBase encoder = new PdfDocxEncoder();
                    // save image collection to a new source without switching to it
                    if (!SaveImageCollection(imageViewer1.Images, filename, encoder, false))
                    {
                        DemosTools.ShowErrorMessage("Image is not saved.");
                    }
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                }
            }

            _isFileDialogOpened = false;
#endif
        }

        /// <summary>
        /// Handles the Click event of saveCurrentImageToolStripMenuItem object.
        /// </summary>
        private void saveCurrentImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_isFileDialogOpened)
                return;
            _isFileDialogOpened = true;

            try
            {

                CodecsFileFilters.SetSaveFileDialogFilter(saveImageFileDialog, false, false);
                if (saveImageFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string filename = Path.GetFullPath(saveImageFileDialog.FileName);
                    bool isFileExist = File.Exists(filename);

                    PluginsEncoderFactory encoderFactory = new PluginsEncoderFactory();
                    encoderFactory.CanAddImagesToExistingFile = isFileExist;

                    EncoderBase encoder = null;

                    // if the encoder for the image is found
                    if (encoderFactory.GetEncoder(filename, out encoder))
                    {
                        VintasoftImage image = imageViewer1.Images[imageViewer1.FocusedIndex];
                        // save image
                        SaveSingleImage(image, filename, encoder);
                    }
                    else
                        DemosTools.ShowErrorMessage("Image is not saved.");
                }
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }

            _isFileDialogOpened = false;
        }

        /// <summary>
        /// Handles the Click event of pageSettingsToolStripMenuItem object.
        /// </summary>
        private void pageSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.ShowDialog();
        }

        /// <summary>
        /// Handles the Click event of printToolStripMenuItem object.
        /// </summary>
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _thumbnailViewerPrintManager.Print();
        }

        /// <summary>
        /// Handles the Click event of closeToolStripMenuItem object.
        /// </summary>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseCurrentFile();

            CloseHistoryForm();

            UpdateUI();
        }

        /// <summary>
        /// Handles the Click event of exitToolStripMenuItem object.
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion


        #region 'Edit' menu

        /// <summary>
        /// Handles the DropDownOpening event of editToolStripMenuItem object.
        /// </summary>
        private void editToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            UpdateEditMenu();
            UpdateEditUIActionMenuItems();
            if (!Clipboard.ContainsImage())
            {
                pasteImageToolStripMenuItem.Enabled = false;
                insertImageFromClipboardToolStripMenuItem.Enabled = false;
            }
        }


        #region Copy, paste and delete image

        /// <summary>
        /// Handles the Click event of copyImageToolStripMenuItem object.
        /// </summary>
        private void copyImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyImageToClipboard();
        }

        /// <summary>
        /// Handles the Click event of pasteImageToolStripMenuItem object.
        /// </summary>
        private void pasteImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasteImageFromClipboard();
        }

        /// <summary>
        /// Handles the Click event of setImageFromFileToolStripMenuItem object.
        /// </summary>
        private void setImageFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openImageFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    // set image from file
                    VintasoftImage image = new VintasoftImage(openImageFileDialog.FileName);
                    imageViewer1.Image.SetImage(image);
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of insertImageFromClipboardToolStripMenuItem object.
        /// </summary>
        private void insertImageFromClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                try
                {
                    // insert image from clipboard into image viewer
                    VintasoftImage image = VintasoftImageGdiExtensions.Create(Clipboard.GetImage(), true);
                    imageViewer1.Images.Insert(imageViewer1.FocusedIndex, image);
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of insertImageFromFileToolStripMenuItem object.
        /// </summary>
        private void insertImageFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openImageFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    // insert image from file to image viewer
                    imageViewer1.Images.Insert(imageViewer1.FocusedIndex, openImageFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of deleteImageToolStripMenuItem object.
        /// </summary>
        private void deleteImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // get focused image and remove it from image viewer
            VintasoftImage image = imageViewer1.Images[imageViewer1.FocusedIndex];
            imageViewer1.Images.RemoveAt(imageViewer1.FocusedIndex);
            image.Dispose();
        }

        #endregion


        #region Copy, paste and delete measurement object

        /// <summary>
        /// Handles the Click event of copyToolStripMenuItem object.
        /// </summary>
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // copy the selected measurement into "internal" buffer,
            // get the copy UI action for current visual tool
            CopyItemUIAction copyUIAction = DemosTools.GetUIAction<CopyItemUIAction>(imageViewer1.VisualTool);

            // if UI action exists
            if (copyUIAction != null)
            {
                // execute the UI action
                copyUIAction.Execute();
            }

            // update the UI
            UpdateUI();
        }

        /// <summary>
        /// Handles the Click event of cutToolStripMenuItem object.
        /// </summary>
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // cut the selected measurement into "internal" buffer,
            // get the cut UI action for current visual tool
            CutItemUIAction cutUIAction = DemosTools.GetUIAction<CutItemUIAction>(imageViewer1.VisualTool);

            // if UI action exists
            if (cutUIAction != null)
                // execute the UI action
                cutUIAction.Execute();

            // update the UI
            UpdateUI();
        }

        /// <summary>
        /// Handles the Click event of pasteToolStripMenuItem object.
        /// </summary>
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // paste measurement from "internal" buffer and make it active,
            // get the paste UI action for current visual tool
            PasteItemWithOffsetUIAction pasteUIAction = DemosTools.GetUIAction<PasteItemWithOffsetUIAction>(imageViewer1.VisualTool);

            // if UI action exists AND UI action is enabled
            if (pasteUIAction != null && pasteUIAction.IsEnabled)
            {
                pasteUIAction.OffsetX = 20;
                pasteUIAction.OffsetY = 20;
                // execute the UI action
                pasteUIAction.Execute();
            }

            // update the UI
            UpdateUI();
        }

        /// <summary>
        /// Handles the Click event of deleteToolStripMenuItem object.
        /// </summary>
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // get the delete UI action for current visual tool
            UIAction deleteUIAction = DemosTools.GetUIAction<DeleteItemUIAction>(imageViewer1.VisualTool);

            // if UI action exists AND UI action is enabled
            if (deleteUIAction != null && deleteUIAction.IsEnabled)
                // execute the UI action
                deleteUIAction.Execute();

            // update the UI
            UpdateUI();
        }

        /// <summary>
        /// Handles the Click event of deleteAllToolStripMenuItem object.
        /// </summary>
        private void deleteAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // get the delete all UI action for current visual tool
            UIAction deleteUIAction = DemosTools.GetUIAction<DeleteAllItemsUIAction>(imageViewer1.VisualTool);
            // if UI action exists AND UI action is enabled
            if (deleteUIAction != null && deleteUIAction.IsEnabled)
                // execute the UI action
                deleteUIAction.Execute();

            // update the UI
            UpdateUI();
        }

        #endregion


        /// <summary>
        /// Handles the Click event of documentMetadataToolStripMenuItem object.
        /// </summary>
        private void documentMetadataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocumentMetadata metadata = imageViewer1.Image.SourceInfo.Decoder.GetDocumentMetadata();

            if (metadata != null)
            {
                using (PropertyGridForm propertyForm = new PropertyGridForm(metadata, "Document Metadata"))
                {
                    // show document metadata window
                    propertyForm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("File does not contain metadata.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Handles the Click event of imageMetadataEditorToolStripMenuItem object.
        /// </summary>
        private void imageMetadataEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VintasoftImage image = imageViewer1.Image;

            Form form = null;

            try
            {
#if !REMOVE_DICOM_PLUGIN
                if (image.Metadata.MetadataTree is DicomFrameMetadata)
                {
                    // show form for editing DICOM image metadata
                    DicomMetadataEditorForm editorForm = new DicomMetadataEditorForm();
                    editorForm.Image = imageViewer1.Image;
                    form = editorForm;
                }
                else
#endif
                {
                    // show a form for editing image metadata
                    MetadataEditorForm editorForm = new MetadataEditorForm();
                    editorForm.Image = imageViewer1.Image;
                    form = editorForm;
                }

                form.ShowDialog();
            }
            finally
            {
                form.Dispose();
            }

            UpdateUI();
        }

        /// <summary>
        /// Handles the Click event of paletteEditorToolStripMenuItem object.
        /// </summary>
        private void paletteEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaletteForm paletteDialog = new PaletteForm();
            paletteDialog.StartPosition = FormStartPosition.Manual;
            paletteDialog.Location = new Point(
                Location.X + (Width - ClientSize.Width),
                Location.Y + (Height - paletteDialog.Height) / 2);

            Palette backupPalette = imageViewer1.Image.Palette.Clone();
            paletteDialog.PaletteViewer.Palette = imageViewer1.Image.Palette;

            // show a form for editing image palette
            if (paletteDialog.ShowDialog() != DialogResult.OK)
            {
                if (paletteDialog.PaletteViewer.IsPaletteChanged)
                {
                    imageViewer1.Image.Palette.SetColors(backupPalette.GetAsArray());
                }
            }
        }

        /// <summary>
        /// Shows a window for editing image pixels.
        /// </summary>
        private void editImagePixelsToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            if (editImagePixelsToolStripMenuItem.Checked)
            {
                bool answerResult = true;
                if (!imageViewer1.IsEntireImageLoaded)
                {
                    VintasoftImage image = imageViewer1.Images[imageViewer1.FocusedIndex];

                    double megabytesPerPixel = image.BitsPerPixel / 8d / 1024d / 1024d;
                    double imageMemory = Math.Round(megabytesPerPixel * image.Width * image.Height, 2);
                    answerResult = MessageBox.Show(
                        string.Format("Image pixels can be edited only if the whole image is loaded in memory. Current image is not loaded in memory and has size {0}Mb. Do you want to load the whole image in memory?", imageMemory),
                        "Pixel direct access", MessageBoxButtons.OKCancel) == DialogResult.OK;
                }

                if (answerResult)
                    OpenDirectPixelAccessForm();
            }
            else
            {
                CloseDirectPixelAccessForm();
            }
        }


        #region Undo/redo changes in images

        /// <summary>
        /// Handles the Click event of enableUndoRedoToolStripMenuItem object.
        /// </summary>
        private void enableUndoRedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isEnabled = _undoManager.IsEnabled ^ true;

            enableUndoRedoToolStripMenuItem.Checked = isEnabled;

            if (!isEnabled)
            {
                // clear image processing history
                _undoManager.Clear();
            }

            _undoManager.IsEnabled = isEnabled;

            // close image processing history form
            CloseHistoryForm();

            // initialize "Undo/Redo" menu
            UpdateUndoRedoMenu(_undoManager);
            // update UI
            UpdateUI();
        }

        /// <summary>
        /// Handles the Click event of keepUndoForCurrentImageOnlyToolStripMenuItem object.
        /// </summary>
        private void keepUndoForCurrentImageOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // enable/disable the image processing history only for current image
            keepUndoForCurrentImageOnlyToolStripMenuItem.Checked ^= true;

            _keepUndoForCurrentImageOnly = keepUndoForCurrentImageOnlyToolStripMenuItem.Checked;

            CreateUndoManager(_keepUndoForCurrentImageOnly);
        }

        /// <summary>
        /// Handles the Click event of undoToolStripMenuItem object.
        /// </summary>
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _undoManager.Undo(1);

            UpdateUndoRedoMenu(_undoManager);
        }

        /// <summary>
        /// Handles the Click event of redoToolStripMenuItem object.
        /// </summary>
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _undoManager.Redo(1);

            UpdateUndoRedoMenu(_undoManager);
        }

        /// <summary>
        /// Handles the Click event of showHistoryForDisplayedImagesToolStripMenuItem object.
        /// </summary>
        private void showHistoryForDisplayedImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // enable/disable showing history only for displayed images
            showHistoryForDisplayedImagesToolStripMenuItem.Checked ^= true;

            _imageViewerUndoMonitor.ShowHistoryForDisplayedImages =
                showHistoryForDisplayedImagesToolStripMenuItem.Checked;
        }

        /// <summary>
        /// Handles the Click event of undoRedoSettingsToolStripMenuItem object.
        /// </summary>
        private void undoRedoSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (UndoManagerSettingsForm dlg = new UndoManagerSettingsForm(_undoManager, _dataStorage))
            {
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.Owner = this;

                // show a form that allows to edit undo manager settings
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _undoLevel = _undoManager.UndoLevel;

                    if (dlg.DataStorage != _dataStorage)
                    {
                        IDataStorage prevDataStorage = _dataStorage;

                        _dataStorage = dlg.DataStorage;

                        _undoManager.Clear();
                        _undoManager.DataStorage = _dataStorage;

                        if (prevDataStorage != null)
                            prevDataStorage.Dispose();

                        if (_imageViewerUndoMonitor != null)
                            _imageViewerUndoMonitor.DataStorage = _dataStorage;
                    }

                    UpdateUndoRedoMenu(_undoManager);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of historyDialogToolStripMenuItem object.
        /// </summary>
        private void historyDialogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // show/hide a form that allows to view the history of image processing
            historyDialogToolStripMenuItem.Checked ^= true;

            if (historyDialogToolStripMenuItem.Checked)
            {
                // show image processing history form
                ShowHistoryForm();
            }
            else
            {
                // close image processing history form
                CloseHistoryForm();
            }
        }

        #endregion

        #endregion


        #region 'View' menu

        /// <summary>
        /// Handles the Click event of thumbnailViewerSettingsToolStripMenuItem object.
        /// </summary>
        private void thumbnailViewerSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ThumbnailViewerSettingsForm dlg = new ThumbnailViewerSettingsForm(thumbnailViewer1))
            {
                dlg.ShowDialog();
            }
        }

        /// <summary>
        /// Handles the Click event of ImageDisplayMode object.
        /// </summary>
        private void ImageDisplayMode_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem imageDisplayModeMenuItem = (ToolStripMenuItem)sender;
            imageViewer1.DisplayMode = (ImageViewerDisplayMode)imageDisplayModeMenuItem.Tag;
            UpdateUI();
        }

        /// <summary>
        /// Handles the Click event of ImageScale object.
        /// </summary>
        private void ImageScale_Click(object sender, EventArgs e)
        {
            _imageScaleSelectedMenuItem.Checked = false;
            _imageScaleSelectedMenuItem = (ToolStripMenuItem)sender;

            // if the menu item sets the ImageSizeMode
            if (_imageScaleSelectedMenuItem.Tag is ImageSizeMode)
            {
                // set size mode
                imageViewer1.SizeMode = (ImageSizeMode)_imageScaleSelectedMenuItem.Tag;
                _imageScaleSelectedMenuItem.Checked = true;
            }
            // if the menu item sets the zoom
            else
            {
                // get zoom value
                int zoomValue = (int)_imageScaleSelectedMenuItem.Tag;
                // set ImageSizeMode as Zoom
                imageViewer1.SizeMode = ImageSizeMode.Zoom;
                // set zoom value
                imageViewer1.Zoom = zoomValue;
            }
        }

        /// <summary>
        /// Handles the Click event of centerImageToolStripMenuItem object.
        /// </summary>
        private void centerImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (centerImageToolStripMenuItem.Checked)
            {
                // enable image centering in image viewer
                imageViewer1.FocusPointAnchor = AnchorType.None;
                imageViewer1.IsFocusPointFixed = true;
                imageViewer1.ScrollToCenter();
            }
            else
            {
                // disable image centering in image viewer
                imageViewer1.FocusPointAnchor = AnchorType.Left | AnchorType.Top;
                imageViewer1.IsFocusPointFixed = true;
            }
        }

        /// <summary>
        /// Handles the Click event of rotateClockwiseToolStripMenuItem object.
        /// </summary>
        private void rotateClockwiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RotateViewClockwise();
        }

        /// <summary>
        /// Handles the Click event of rotateCounterclockwiseToolStripMenuItem object.
        /// </summary>
        private void rotateCounterclockwiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RotateViewCounterClockwise();
        }

        /// <summary>
        /// Handles the Click event of imageViewerSettingsToolStripMenuItem object.
        /// </summary>
        private void imageViewerSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ImageViewerSettingsForm dlg = new ImageViewerSettingsForm(imageViewer1))
            {
                dlg.ShowDialog();
            }
            UpdateUI();
        }

        /// <summary>
        /// Handles the Click event of viewerRenderingSettingsToolStripMenuItem object.
        /// </summary>
        private void viewerRenderingSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (CompositeRenderingSettingsForm viewerRenderingSettingsForm = new CompositeRenderingSettingsForm(imageViewer1.ImageRenderingSettings))
            {
                viewerRenderingSettingsForm.ShowDialog();
            }
            UpdateUI();
        }

        /// <summary>
        /// Handles the Click event of imageMapSettingsToolStripMenuItem object.
        /// </summary>
        private void imageMapSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ImageMapToolSettingsForm dlg = new ImageMapToolSettingsForm(_imageMapTool))
            {
                // show image map settings
                dlg.ShowDialog();
            }

            _isVisualToolChanging = true;

            if (_imageMapTool.Enabled)
            {
                if (imageViewer1.VisualTool == null)
                {
                    // set as image viewer tool
                    imageViewer1.VisualTool = _imageMapTool;
                }
                else
                {
                    // add to existing image viewer tool
                    if (imageViewer1.VisualTool is CompositeVisualTool)
                    {
                        CompositeVisualTool compositeVisualTool = (CompositeVisualTool)imageViewer1.VisualTool;
                        foreach (VisualTool visualTool in compositeVisualTool)
                        {
                            if (visualTool == _imageMapTool)
                            {
                                _isVisualToolChanging = false;
                                return;
                            }
                        }

                        imageViewer1.VisualTool = new CompositeVisualTool(_imageMapTool, compositeVisualTool);
                    }
                    else if (imageViewer1.VisualTool != _imageMapTool)
                    {
                        imageViewer1.VisualTool = new CompositeVisualTool(_imageMapTool, imageViewer1.VisualTool);
                    }
                }
            }
            else
            {
                // disable image map tool in viewer
                if (imageViewer1.VisualTool != null)
                {
                    if (imageViewer1.VisualTool is CompositeVisualTool)
                    {
                        // extract image map tool from image viewer composite tool
                        CompositeVisualTool compositeVisualTool = (CompositeVisualTool)imageViewer1.VisualTool;
                        List<VisualTool> visualTools = new List<VisualTool>();
                        foreach (VisualTool visualTool in compositeVisualTool)
                        {
                            if (visualTool == _imageMapTool)
                                continue;

                            visualTools.Add(visualTool);
                        }

                        if (visualTools.Count == 0)
                            imageViewer1.VisualTool = null;
                        else if (visualTools.Count == 1)
                            imageViewer1.VisualTool = visualTools[0];
                        else
                            imageViewer1.VisualTool = new CompositeVisualTool(visualTools.ToArray());
                    }
                    else if (imageViewer1.VisualTool == _imageMapTool)
                    {
                        imageViewer1.VisualTool = null;
                    }
                }
            }

            _isVisualToolChanging = false;
        }

        /// <summary>
        /// Handles the Click event of magnifierSettingsToolStripMenuItem object.
        /// </summary>
        private void magnifierSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MagnifierToolAction magnifierToolAction = visualToolsToolStrip1.FindAction<MagnifierToolAction>();

            if (magnifierToolAction != null)
            {
                // show magnifier tool settings
                magnifierToolAction.ShowVisualToolSettings();
            }
        }

        /// <summary>
        /// Handles the Click event of currentImageDecodingSettingsToolStripMenuItem object.
        /// </summary>
        private void currentImageDecodingSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DecodingSettings settings = imageViewer1.Image.DecodingSettings;
            if (settings == null)
            {
                DemosTools.ShowInfoMessage("Current image does not have decoding settings.");
            }
            else
            {
                using (PropertyGridForm dlg = new PropertyGridForm(settings, settings.GetType().Name, false))
                {
                    dlg.ShowDialog();
                    if (dlg.PropertyValueChanged)
                    {
                        imageViewer1.Image.Reload(true);
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Click event of colorManagementToolStripMenuItem object.
        /// </summary>
        private void colorManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorManagementSettingsForm.EditColorManagement(imageViewer1);
        }

        /// <summary>
        /// Handles the Click event of maxThreadsToolStripMenuItem object.
        /// </summary>
        private void maxThreadsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (MaxThreadsForm dlg = new MaxThreadsForm())
            {
                dlg.MaxThreads = ImagingEnvironment.MaxThreads;

                // show a dialog that allows to change the count of maximum 
                // thread, which can be used for image rendering
                if (dlg.ShowDialog() == DialogResult.OK)
                    ImagingEnvironment.MaxThreads = dlg.MaxThreads;
            }
        }

        #endregion


        #region 'Image processing' menu

        #region Base

        #region Change pixel format

        /// <summary>
        /// Handles the Click event of changePixelFormatToBlackWhiteThresholdModeToolStripMenuItem object.
        /// </summary>
        private void changePixelFormatToBlackWhiteThresholdModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imageViewer1.Image.PixelFormat != PixelFormat.BlackWhite)
            {
                using (BinarizeForm dlg = new BinarizeForm(imageViewer1, true))
                {
                    if (dlg.ShowProcessingDialog())
                    {
                        // change pixel format of image to BlackWhite, threshold value is specified by user
                        _imageProcessingCommandExecutor.ExecuteProcessingCommand(dlg.GetProcessingCommand());
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Click event of changePixelFormatToBlackWhiteGlobalModeToolStripMenuItem object.
        /// </summary>
        private void changePixelFormatToBlackWhiteGlobalModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // change pixel format of image to BlackWhite, global threshold is detected automatically
            _imageProcessingCommandExecutor.ExecuteProcessingCommand(new ChangePixelFormatToBlackWhiteCommand(BinarizationMode.Global));
        }

        /// <summary>
        /// Handles the Click event of changePixelFormatToBlackWhiteAdaptiveModeToolStripMenuItem object.
        /// </summary>
        private void changePixelFormatToBlackWhiteAdaptiveModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imageViewer1.Image.PixelFormat != PixelFormat.BlackWhite)
            {
                using (AdaptiveBinarizeForm dlg = new AdaptiveBinarizeForm(imageViewer1, true))
                {
                    if (dlg.ShowProcessingDialog())
                    {
                        // change pixel format of image to BlackWhite, adaptive threshold is detected automatically
                        _imageProcessingCommandExecutor.ExecuteProcessingCommand(dlg.GetProcessingCommand());
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Click event of colorGradientBinariaztionToolStripMenuItem object.
        /// </summary>
        private void colorGradientBinariaztionToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if !REMOVE_DOCCLEANUP_PLUGIN
            if (imageViewer1.Image.PixelFormat != PixelFormat.BlackWhite)
            {
                // convert an image to black-white image, use color gradient binarization
                ColorGradientBinarizationForm form = new ColorGradientBinarizationForm(imageViewer1);
                form.ChangePixelFormatToBlackWhite = true;
                ShowAndDisposeProcessingDialog(form, true);
            }
#endif
        }

        /// <summary>
        /// Handles the Click event of halftoneToolStripMenuItem1 object.
        /// </summary>
        private void halftoneToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // change pixel format of image to BlackWhite using Halftone binarization
            _imageProcessingCommandExecutor.ExecuteProcessingCommand(new ChangePixelFormatToBlackWhiteCommand(BinarizationMode.Halftone));
        }

        /// <summary>
        /// Handles the Click event of changePixelFormatToPalette1ToolStripMenuItem object.
        /// </summary>
        private void changePixelFormatToPalette1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // change pixel format of image to Palette1
            _imageProcessingCommandExecutor.ExecuteProcessingCommand(new ChangePixelFormatCommand(Vintasoft.Imaging.PixelFormat.Indexed1));
        }

        /// <summary>
        /// Handles the Click event of changePixelFormatToGray8ToolStripMenuItem object.
        /// </summary>
        private void changePixelFormatToGray8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // change pixel format of image to Gray8
            _imageProcessingCommandExecutor.ExecuteProcessingCommand(new ChangePixelFormatCommand(PixelFormat.Gray8));
        }

        /// <summary>
        /// Handles the Click event of changePixelFormatToPalette8ToolStripMenuItem object.
        /// </summary>
        private void changePixelFormatToPalette8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePixelFormatToPaletteCommand command = new ChangePixelFormatToPaletteCommand(PixelFormat.Indexed8);
            // consider transparency
            command.Transparency = true;
            using (PropertyGridForm propertyGridForm =
                new PropertyGridForm(command, "Change Pixel Format to Indexed8 Command Properties ", true))
            {
                if (propertyGridForm.ShowDialog() == DialogResult.OK)
                {
                    // change pixel format of image to Indexed8
                    _imageProcessingCommandExecutor.ExecuteProcessingCommand(command);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of changePixelFormatToBgr24ToolStripMenuItem object.
        /// </summary>
        private void changePixelFormatToBgr24ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // change pixel format of image to Bgr24
            _imageProcessingCommandExecutor.ExecuteProcessingCommand(new ChangePixelFormatCommand(Vintasoft.Imaging.PixelFormat.Bgr24));
        }

        /// <summary>
        /// Handles the Click event of convertToBgra32ToolStripMenuItem object.
        /// </summary>
        private void convertToBgra32ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // change pixel format of image to Bgra32
            _imageProcessingCommandExecutor.ExecuteProcessingCommand(new ChangePixelFormatCommand(Vintasoft.Imaging.PixelFormat.Bgra32));
        }

        /// <summary>
        /// Handles the Click event of changePixelFormatToCustomFormatToolStripMenuItem object.
        /// </summary>
        private void changePixelFormatToCustomFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ChangePixelFormatForm dlg = new ChangePixelFormatForm())
            {
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // change pixel format of image to custom format
                    _imageProcessingCommandExecutor.ExecuteProcessingCommand(new ChangePixelFormatCommand(dlg.PixelFormat));
                }
            }
        }

        #endregion


        /// <summary>
        /// Handles the Click event of cropToolStripMenuItem object.
        /// </summary>
        private void cropToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (HasCustomSelection() ||
                HasRectangularSelection())
            {
                try
                {
                    // crop image
                    _imageProcessingCommandExecutor.ExecuteProcessingCommand(new CropCommand());
                }
                catch (ImageProcessingException ex)
                {
                    MessageBox.Show(ex.Message, "Image processing exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of resizeToolStripMenuItem object.
        /// </summary>
        private void resizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // get image
            VintasoftImage image = imageViewer1.Image;
            // get resize command
            ResizeCommand command = ImageProcessingCommandFactory.CreateCommand<ResizeCommand>(image);

            int width;
            int height;
            // get selection tool
            RectangularSelectionTool selectionTool = imageViewer1.VisualTool as RectangularSelectionTool;
            // if selection tool exists AND selection is not empty
            if (selectionTool != null && selectionTool.Rectangle.Width != 0 && selectionTool.Rectangle.Height != 0)
            {
                // get selection size
                width = selectionTool.Rectangle.Width;
                height = selectionTool.Rectangle.Height;
            }
            else
            {
                // get image size
                width = image.Width;
                height = image.Height;
            }

            // show resize dialog
            using (ResizeForm dlg = new ResizeForm(width, height, command.InterpolationMode))
            {
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // apply command settings
                    command.Width = dlg.ImageWidth;
                    command.Height = dlg.ImageHeight;
                    command.InterpolationMode = dlg.InterpolationMode;
                    // apply command
                    _imageProcessingCommandExecutor.ExecuteProcessingCommand(command);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of resizeCanvasToolStripMenuItem object.
        /// </summary>
        private void resizeCanvasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VintasoftImage image = imageViewer1.Image;
            using (ResizeCanvasForm dlg = new ResizeCanvasForm(image.Width, image.Height))
            {
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ResizeCanvasCommand command = ImageProcessingCommandFactory.CreateCommand<ResizeCanvasCommand>(image);
                    // apply command settings
                    command.Width = dlg.CanvasWidth;
                    command.Height = dlg.CanvasHeight;
                    command.ImagePosition = dlg.ImagePosition;
                    command.CanvasColor = dlg.CanvasColor;
                    // apply command
                    _imageProcessingCommandExecutor.ExecuteProcessingCommand(command);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of resampleToolStripMenuItem object.
        /// </summary>
        private void resampleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VintasoftImage image = imageViewer1.Image;
            ResampleCommand command = new ResampleCommand();
            using (ResampleForm dlg = new ResampleForm((float)image.Resolution.Horizontal, (float)image.Resolution.Vertical, command.InterpolationMode, "Resample", true))
            {
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // apply command settings
                    command.HorizontalResolution = dlg.HorizontalResolution;
                    command.VerticalResolution = dlg.VerticalResolution;
                    command.InterpolationMode = dlg.InterpolationMode;
                    // apply command
                    _imageProcessingCommandExecutor.ExecuteProcessingCommand(command);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of changeResolutionToolStripMenuItem object.
        /// </summary>
        private void changeResolutionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VintasoftImage image = imageViewer1.Image;
            using (ResampleForm dlg = new ResampleForm((float)image.Resolution.Horizontal,
                (float)image.Resolution.Vertical,
                ImageInterpolationMode.HighQualityBicubic,
                "Change resolution", false))
            {
                dlg.ShowInterpolationComboBox = false;
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        if (!image.IsChanged && image.SourceInfo.Decoder.IsVectorDecoder)
                            DemosTools.ShowErrorMessage("Resolution of vector image", "Cannot change resolution for vector image. Change rendering resolution using RenderingSettings.Resolution property: View -> Image Viewer Settings... -> Image Rendering Settings.");
                        else
                            image.Resolution = new Vintasoft.Imaging.Resolution(dlg.HorizontalResolution, dlg.VerticalResolution);
                    }
                    catch (Exception ex)
                    {
                        DemosTools.ShowErrorMessage(ex);
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Click event of fillImageToolStripMenuItem object.
        /// </summary>
        private void fillImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(new FillImageForm(imageViewer1));
        }

        /// <summary>
        /// Handles the Click event of fillRectangleToolStripMenuItem object.
        /// </summary>
        private void fillRectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // fill rectangle on image
            _imageProcessingCommandExecutor.ExecuteFillRectangleCommand();
        }

        /// <summary>
        /// Handles the Click event of overlayImageToolStripMenuItem object.
        /// </summary>
        private void overlayImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteOverlayCommand();
        }

        /// <summary>
        /// Handles the Click event of overlayBinaryImageToolStripMenuItem object.
        /// </summary>
        private void overlayBinaryImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteOverlayBinaryCommand();
        }

        /// <summary>
        /// Handles the Click event of drawImageToolStripMenuItem object.
        /// </summary>
        private void drawImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteDrawImageCommand();
        }

        /// <summary>
        /// Handles the Click event of overlayWithBlendingToolStripMenuItem object.
        /// </summary>
        private void overlayWithBlendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteOverlayWithBlendingCommand();
        }

        /// <summary>
        /// Handles the Click event of overlayWithMaskToolStripMenuItem object.
        /// </summary>
        private void overlayWithMaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteOverlayMaskedCommand();
        }

        /// <summary>
        /// Handles the Click event of imageCompareToolStripMenuItem object.
        /// </summary>
        private void imageCompareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteComparisonCommand();
        }

        #endregion


        #region Info

        /// <summary>
        /// Handles the Click event of histogramToolStripMenuItem object.
        /// </summary>
        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Rectangle selectionRectangle = Rectangle.Empty;

                // if current tool contains RectangularSelectionToolWithCopyPaste with selection
                if (HasRectangularSelection())
                {
                    RectangularSelectionToolWithCopyPaste selection = CompositeVisualTool.FindVisualTool<RectangularSelectionToolWithCopyPaste>(imageViewer1.VisualTool);

                    selectionRectangle = selection.Rectangle;
                }

                using (GetHistogramForm dlg = new GetHistogramForm(
                    imageViewer1.Image,
                    selectionRectangle,
                    _imageProcessingCommandExecutor.ExpandSupportedPixelFormats))
                {
                    dlg.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of isImageBlackWhiteToolStripMenuItem object.
        /// </summary>
        private void isImageBlackWhiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteIsImageBlackWhiteCommand();
        }

        /// <summary>
        /// Handles the Click event of isImageGrayscaleToolStripMenuItem object.
        /// </summary>
        private void isImageGrayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteIsImageGrayscaleCommand();
        }

        /// <summary>
        /// Handles the Click event of getColorCountToolStripMenuItem object.
        /// </summary>
        private void getColorCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteColorCountCommand();
        }

        /// <summary>
        /// Handles the Click event of getImageColorDepthToolStripMenuItem object.
        /// </summary>
        private void getImageColorDepthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // get real color depth of image
            _imageProcessingCommandExecutor.ExecuteGetImageColorDepthCommand();
        }

        /// <summary>
        /// Handles the Click event of getBorderColorToolStripMenuItem object.
        /// </summary>
        private void getBorderColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteGetBorderColorCommand();
        }

        /// <summary>
        /// Handles the Click event of getBackgroundColorToolStripMenuItem object.
        /// </summary>
        private void getBackgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteGetBackgroundColorCommand();
        }

        /// <summary>
        /// Handles the Click event of detectThresholdToolStripMenuItem object.
        /// </summary>
        private void detectThresholdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // get an optimal binarization threshold of image
            _imageProcessingCommandExecutor.ExecuteGetThresholdCommand();
        }

        /// <summary>
        /// Handles the Click event of isImageBlankToolStripMenuItem object.
        /// </summary>
        private void isImageBlankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteIsBlankCommand();
        }

        /// <summary>
        /// Handles the Click event of hasCertainColorToolStripMenuItem object.
        /// </summary>
        private void hasCertainColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteHasCertainColorCommand();
        }

        #endregion


        #region Transforms

        /// <summary>
        /// Handles the Click event of flipToolStripMenuItem object.
        /// </summary>
        private void flipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageRotateFlipType flipType = ImageRotateFlipType.RotateNoneFlipX;
            if (sender == xToolStripMenuItem || sender == xToolStripMenuItem1)
            {
                flipType = ImageRotateFlipType.RotateNoneFlipX;
            }
            else if (sender == yToolStripMenuItem || sender == yToolStripMenuItem1)
            {
                flipType = ImageRotateFlipType.RotateNoneFlipY;
            }
            else if (sender == xYToolStripMenuItem || sender == xYToolStripMenuItem1)
            {
                flipType = ImageRotateFlipType.RotateNoneFlipXY;
            }

            _imageProcessingCommandExecutor.ExecuteProcessingCommand(new FlipCommand(flipType));
        }

        /// <summary>
        /// Handles the Click event of Rotate object.
        /// </summary>
        private void Rotate_Click(object sender, EventArgs e)
        {
            RotateCommand rotateCommand = ImageProcessingCommandFactory.CreateRotateCommand(imageViewer1.Image);

            if (sender == customToolStripMenuItem || sender == customToolStripMenuItem1)
            {
                using (RotateForm dlg = new RotateForm(imageViewer1.Image.PixelFormat))
                {
                    if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        // if pixel formats are not equal
                        if (dlg.SourceImagePixelFormat != imageViewer1.Image.PixelFormat)
                        {
                            // change pixel format
                            _imageProcessingCommandExecutor.ExecuteProcessingCommand(new ChangePixelFormatCommand(dlg.SourceImagePixelFormat), false);
                        }

                        rotateCommand.Angle = (double)dlg.Angle;
                        rotateCommand.BorderColorType = dlg.BorderColorType;
                        rotateCommand.IsAntialiasingEnabled = dlg.IsAntialiasingEnabled;

                        _imageProcessingCommandExecutor.ExecuteProcessingCommand(rotateCommand);
                    }
                }
            }
            else
            {
                float angle = 0f;
                if (sender == rotate90 || sender == rotate90ToolStripMenuItem)
                {
                    angle = 90f;
                }
                else if (sender == rotate180 || sender == rotate180ToolStripMenuItem)
                {
                    angle = 180f;
                }
                else if (sender == rotate270 || sender == rotate270ToolStripMenuItem)
                {
                    angle = 270f;
                }

                rotateCommand.Angle = angle;
                rotateCommand.BorderColor = Color.Black;
                _imageProcessingCommandExecutor.ExecuteProcessingCommand(rotateCommand);
            }
        }

        /// <summary>
        /// Handles the Click event of scaleToolStripMenuItem1 object.
        /// </summary>
        private void scaleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ImageScalingForm form = new ImageScalingForm();
            form.Command = ImageProcessingCommandFactory.CreateCommand<ImageScalingCommand>(imageViewer1.Image);
            ShowAndDisposeProcessingDialog(form, false, false);
        }

        /// <summary>
        /// Handles the Click event of skewToolStripMenuItem object.
        /// </summary>
        private void skewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(
                new PropertyGridConfigForm(imageViewer1, new SkewCommand()), false, false);
        }

        /// <summary>
        /// Handles the Click event of quadrilateralWarpToolStripMenuItem object.
        /// </summary>
        private void quadrilateralWarpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // apply quadrilateral warp transformation to image
            ShowAndDisposeProcessingDialog(
                new PropertyGridConfigForm(imageViewer1, new QuadrilateralWarpCommand()), false, false);
        }

        /// <summary>
        /// Handles the Click event of matrixTransformToolStripMenuItem object.
        /// </summary>
        private void matrixTransformToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // apply matrix transformation to image
            ShowAndDisposeProcessingDialog(
                new PropertyGridConfigForm(imageViewer1, new MatrixTransformCommand()), false, false);
        }

        #endregion


        #region Channels

        /// <summary>
        /// Handles the Click event of extractAlphaChannelToolStripMenuItem object.
        /// </summary>
        private void extractAlphaChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteProcessingCommand(new GetAlphaChannelMaskCommand());
        }

        /// <summary>
        /// Handles the Click event of invertRedChannelToolStripMenuItem object.
        /// </summary>
        private void invertRedChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvertColorChannel(Color.FromArgb(255, 0, 0));
        }

        /// <summary>
        /// Handles the Click event of invertGreenChannelToolStripMenuItem object.
        /// </summary>
        private void invertGreenChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvertColorChannel(Color.FromArgb(0, 255, 0));
        }

        /// <summary>
        /// Handles the Click event of invertBlueChannelToolStripMenuItem object.
        /// </summary>
        private void invertBlueChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvertColorChannel(Color.FromArgb(0, 0, 255));
        }

        /// <summary>
        /// Handles the Click event of setAlphaChannelValueToolStripMenuItem object.
        /// </summary>
        private void setAlphaChannelValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // set a value of alpha channel for all pixels of image to the specified value
            _imageProcessingCommandExecutor.ExecuteSetAlphaChannelValueCommand();
        }

        /// <summary>
        /// Handles the Click event of setAlphaChannelFromMaskToolStripMenuItem object.
        /// </summary>
        private void setAlphaChannelFromMaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteSetAlphaChannelCommand();
        }


        /// <summary>
        /// Handles the Click event of removeRedChannelToolStripMenuItem object.
        /// </summary>
        private void removeRedChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // remove red channel of image
            ExtractColorChannels(0, 255, 255);
        }

        /// <summary>
        /// Handles the Click event of removeGreenChannelToolStripMenuItem object.
        /// </summary>
        private void removeGreenChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // remove green channel of image
            ExtractColorChannels(255, 0, 255);
        }

        /// <summary>
        /// Handles the Click event of removeBlueChannelToolStripMenuItem object.
        /// </summary>
        private void removeBlueChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // remove blue channel of image
            ExtractColorChannels(255, 255, 0);
        }

        #endregion


        #region Color

        /// <summary>
        /// Handles the Click event of convertToBlackWhiteThresholdByUserToolStripMenuItem object.
        /// </summary>
        private void convertToBlackWhiteThresholdByUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imageViewer1.Image.PixelFormat != PixelFormat.BlackWhite)
            {
                // convert an image to black-white image, threshold value is specified by user
                ShowAndDisposeProcessingDialog(new BinarizeForm(imageViewer1, false));
            }
        }

        /// <summary>
        /// Handles the Click event of convertToBlackWhiteGlobalThresholdToolStripMenuItem object.
        /// </summary>
        private void convertToBlackWhiteGlobalThresholdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // convert an image to black-white image, global threshold is detected automatically
            _imageProcessingCommandExecutor.ExecuteProcessingCommand(new BinarizeCommand(BinarizationMode.Global));
        }

        /// <summary>
        /// Handles the Click event of convertToBlackWhiteAdaptiveThresholdToolStripMenuItem object.
        /// </summary>
        private void convertToBlackWhiteAdaptiveThresholdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imageViewer1.Image.PixelFormat != PixelFormat.BlackWhite)
            {
                // convert an image to black-white image, adaptive threshold is detected automatically
                ShowAndDisposeProcessingDialog(new AdaptiveBinarizeForm(imageViewer1, false));
            }
        }

        /// <summary>
        /// Handles the Click event of colorGradientToolStripMenuItem object.
        /// </summary>
        private void colorGradientToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if !REMOVE_DOCCLEANUP_PLUGIN
            if (imageViewer1.Image.PixelFormat != PixelFormat.BlackWhite)
            {
                // convert an image to black-white image, use color gradient binarization
                ShowAndDisposeProcessingDialog(new ColorGradientBinarizationForm(imageViewer1), true);
            }
#endif
        }

        /// <summary>
        /// Handles the Click event of desaturateToolStripMenuItem object.
        /// </summary>
        private void desaturateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DesaturateCommand command = ImageProcessingCommandFactory.CreateDesaturateCommand(imageViewer1.Image);
            command.DesaturateMethod = DesaturateMethod.Luminosity;
            _imageProcessingCommandExecutor.ExecuteProcessingCommand(command);
        }

        /// <summary>
        /// Handles the Click event of convertToHalftoneToolStripMenuItem object.
        /// </summary>
        private void convertToHalftoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteProcessingCommand(new HalftoneCommand());
        }

        /// <summary>
        /// Handles the Click event of posterizeToolStripMenuItem object.
        /// </summary>
        private void posterizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imageViewer1.Image.PixelFormat != PixelFormat.BlackWhite)
                ShowAndDisposeProcessingDialog(new PosterizeForm(imageViewer1));
        }

        /// <summary>
        /// Handles the Click event of brightnessContrastToolStripMenuItem object.
        /// </summary>
        private void brightnessContrastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(new BrightnessContrastForm(imageViewer1, imageViewer1.Image), true);
        }

        /// <summary>
        /// Handles the Click event of hueSaturationLuminanceToolStripMenuItem object.
        /// </summary>
        private void hueSaturationLuminanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(new HueSaturationLuminanceForm(imageViewer1));
        }

        /// <summary>
        /// Handles the Click event of gammaToolStripMenuItem object.
        /// </summary>
        private void gammaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(new GammaForm(imageViewer1), true);
        }

        /// <summary>
        /// Handles the Click event of levelsToolStripMenuItem object.
        /// </summary>
        private void levelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(new LevelsForm(imageViewer1), true);
        }

        /// <summary>
        /// Handles the Click event of invertColorsToolStripMenuItem object.
        /// </summary>
        private void invertColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteProcessingCommand(ImageProcessingCommandFactory.CreateInvertCommand(imageViewer1.Image));
        }

        /// <summary>
        /// Handles the Click event of replaceColorToolStripMenuItem object.
        /// </summary>
        private void replaceColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(new ReplaceColorForm(imageViewer1), true);
        }

        /// <summary>
        /// Handles the Click event of replaceColorGradientToolStripMenuItem object.
        /// </summary>
        private void replaceColorGradientToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if !REMOVE_DOCCLEANUP_PLUGIN
            ShowAndDisposeProcessingDialog(new ReplaceColorGradientForm(imageViewer1), true);
#endif
        }

        /// <summary>
        /// Handles the Click event of colorBlendToolStripMenuItem object.
        /// </summary>
        private void colorBlendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteColorBlendCommand();
        }

        /// <summary>
        /// Handles the Click event of colorTransformToolStripMenuItem object.
        /// </summary>
        private void colorTransformToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(new ColorTransformForm(imageViewer1));
        }

        #endregion


        #region Filters

        #region Arithmetic filters

        /// <summary>
        /// Handles the Click event of minimumFilterToolStripMenuItem object.
        /// </summary>
        private void minimumFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // apply arithmetic minimum filter to image
            ShowAndDisposeProcessingDialog(new MinimumForm(imageViewer1));
        }

        /// <summary>
        /// Handles the Click event of maximumFilterToolStripMenuItem object.
        /// </summary>
        private void maximumFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // apply arithmetic maximum filter to image
            ShowAndDisposeProcessingDialog(new MaximumForm(imageViewer1));
        }

        /// <summary>
        /// Handles the Click event of midPointFilterToolStripMenuItem object.
        /// </summary>
        private void midPointFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // apply arithmetic midpoint filter to image
            ShowAndDisposeProcessingDialog(new MidpointForm(imageViewer1));
        }

        /// <summary>
        /// Handles the Click event of meanFilterToolStripMenuItem object.
        /// </summary>
        private void meanFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // apply arithmetic mean filter to image
            ShowAndDisposeProcessingDialog(new MeanForm(imageViewer1));
        }

        /// <summary>
        /// Handles the Click event of medianFilterToolStripMenuItem object.
        /// </summary>
        private void medianFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // apply arithmetic median filter to image
            ShowAndDisposeProcessingDialog(new MedianForm(imageViewer1));
        }

        #endregion


        #region Morphological filters

        /// <summary>
        /// Handles the Click event of dilateFilterToolStripMenuItem object.
        /// </summary>
        private void dilateFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // apply morphological dilate filter to image
            ShowAndDisposeProcessingDialog(new DilateForm(imageViewer1));
        }

        /// <summary>
        /// Handles the Click event of erodeFilterToolStripMenuItem object.
        /// </summary>
        private void erodeFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // apply morphological erode filter to image
            ShowAndDisposeProcessingDialog(new ErodeForm(imageViewer1));
        }

        #endregion


        /// <summary>
        /// Handles the Click event of blurFilterToolStripMenuItem object.
        /// </summary>
        private void blurFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // apply the Blur filter to an image
            ShowAndDisposeProcessingDialog(new BlurForm(imageViewer1));
        }

        /// <summary>
        /// Handles the Click event of gaussianBlurFilterToolStripMenuItem object.
        /// </summary>
        private void gaussianBlurFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // apply the Gaussian blur filter to an image
            ShowAndDisposeProcessingDialog(new GaussianBlurForm(imageViewer1));
        }

        /// <summary>
        /// Handles the Click event of sharpenFilterToolStripMenuItem object.
        /// </summary>
        private void sharpenFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // apply the Sharpen filter to an image
            ShowAndDisposeProcessingDialog(new SharpenForm(imageViewer1));
        }

        /// <summary>
        /// Handles the Click event of edgeDetectionFilterToolStripMenuItem object.
        /// </summary>
        private void edgeDetectionFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // apply the Edge Detection filter to an image
            _imageProcessingCommandExecutor.ExecuteProcessingCommand(new EdgeDetectionCommand());
        }

        /// <summary>
        /// Handles the Click event of embossFilterToolStripMenuItem object.
        /// </summary>
        private void embossFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // apply the Emboss filter to an image
            ShowAndDisposeProcessingDialog(new EmbossForm(imageViewer1));
        }

        /// <summary>
        /// Handles the Click event of addNoiseToolStripMenuItem object.
        /// </summary>
        private void addNoiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // apply the Add noise filter to an image
            ShowAndDisposeProcessingDialog(
                new PropertyGridConfigForm(imageViewer1, new AddNoiseCommand()), false, false);
        }

        /// <summary>
        /// Handles the Click event of cannyEdgeDetectorToolStripMenuItem object.
        /// </summary>
        private void cannyEdgeDetectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // apply the Canny edge detector filter to an image
            ShowAndDisposeProcessingDialog(new CannyEdgeDetectorForm(imageViewer1));
        }

        #endregion


        #region Document Cleanup

        /// <summary>
        /// Handles the Click event of isDocumentImageToolStripMenuItem object.
        /// </summary>
        private void isDocumentImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // determine that image is document image
            _imageProcessingCommandExecutor.ExecuteIsDocumentImageCommand();
        }

        /// <summary>
        /// Handles the Click event of getDocumentImageRotationAngleToolStripMenuItem object.
        /// </summary>
        private void getDocumentImageRotationAngleToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if !REMOVE_DOCCLEANUP_PLUGIN
            _imageProcessingCommandExecutor.ExecuteGetDocumentImageRotationAngleCommand();
#endif
        }

        /// <summary>
        /// Handles the Click event of rotationAngleToolStripMenuItem object.
        /// </summary>
        private void rotationAngleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteGetRotationAngleCommand();
        }

        /// <summary>
        /// Handles the Click event of getTextOrientationToolStripMenuItem object.
        /// </summary>
        private void getTextOrientationToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if !REMOVE_DOCCLEANUP_PLUGIN
            _imageProcessingCommandExecutor.ExecuteGetTextOrientationCommand();
#endif
        }

        /// <summary>
        /// Handles the Click event of despeckleToolStripMenuItem object.
        /// </summary>
        private void despeckleToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if !REMOVE_DOCCLEANUP_PLUGIN
            // remove noise in document image
            ShowAndDisposeProcessingDialog(new PropertyGridConfigForm(imageViewer1, new DespeckleCommand()));
#endif
        }

        /// <summary>
        /// Handles the Click event of deskewDocumentImageToolStripMenuItem object.
        /// </summary>
        private void deskewDocumentImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if !REMOVE_DOCCLEANUP_PLUGIN
            // correct document image orientation automatically
            ShowAndDisposeProcessingDialog(
                new PropertyGridConfigForm(imageViewer1, new DeskewDocumentImageCommand()), true, false);
#endif
        }

        /// <summary>
        /// Handles the Click event of deskewToolStripMenuItem object.
        /// </summary>
        private void deskewToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if !REMOVE_DOCCLEANUP_PLUGIN
            // detect correct position of document image automatically
            ShowAndDisposeProcessingDialog(
                new PropertyGridConfigForm(imageViewer1, new DeskewCommand()), true, false);
#endif
        }

        /// <summary>
        /// Handles the Click event of autoOrientationToolStripMenuItem object.
        /// </summary>
        private void autoOrientationToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if !REMOVE_DOCCLEANUP_PLUGIN
            ShowAndDisposeProcessingDialog(
                new PropertyGridConfigForm(imageViewer1, new AutoTextOrientationCommand()), true, false);
#endif
        }

        /// <summary>
        /// Handles the Click event of textBlockInvertToolStripMenuItem object.
        /// </summary>
        private void textBlockInvertToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if !REMOVE_DOCCLEANUP_PLUGIN
            ShowAndDisposeProcessingDialog(new AutoTextInvertForm(imageViewer1), false, false);
#endif
        }

        /// <summary>
        /// Handles the Click event of automaticInvertToolStripMenuItem object.
        /// </summary>
        private void automaticInvertToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if !REMOVE_DOCCLEANUP_PLUGIN
            _imageProcessingCommandExecutor.ExecuteProcessingCommand(new AutoInvertCommand());
#endif
        }

        /// <summary>
        /// Handles the Click event of borderClearToolStripMenuItem object.
        /// </summary>
        private void borderClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if !REMOVE_DOCCLEANUP_PLUGIN
            _imageProcessingCommandExecutor.ExecuteProcessingCommand(new BorderClearCommand());
#endif
        }

        /// <summary>
        /// Handles the Click event of detectBorderToolStripMenuItem object.
        /// </summary>
        private void detectBorderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // crop document image border
            ShowAndDisposeProcessingDialog(new BorderRemovalForm(imageViewer1));
        }

        /// <summary>
        /// Handles the Click event of halftoneRemovalToolStripMenuItem object.
        /// </summary>
        private void halftoneRemovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if !REMOVE_DOCCLEANUP_PLUGIN
            ShowAndDisposeProcessingDialog(new HalftoneRemovalForm(imageViewer1));
#endif
        }

        /// <summary>
        /// Handles the Click event of smoothingToolStripMenuItem object.
        /// </summary>
        private void smoothingToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if !REMOVE_DOCCLEANUP_PLUGIN
            ShowAndDisposeProcessingDialog(new SmoothingForm(imageViewer1));
#endif
        }

        /// <summary>
        /// Handles the Click event of holePuchFillingToolStripMenuItem object.
        /// </summary>
        private void holePuchFillingToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if !REMOVE_DOCCLEANUP_PLUGIN
            HolePunchFillingCommand holePunchFillingCommand = new HolePunchFillingCommand();
            holePunchFillingCommand.HolePunchLocation =
                HolePunchLocation.Left |
                HolePunchLocation.Right |
                HolePunchLocation.Top |
                HolePunchLocation.Bottom;
            ShowAndDisposeProcessingDialog(new PropertyGridConfigForm(imageViewer1, holePunchFillingCommand));
#endif
        }

        /// <summary>
        /// Handles the Click event of holePunchRemovalToolStripMenuItem object.
        /// </summary>
        private void holePunchRemovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if !REMOVE_DOCCLEANUP_PLUGIN
            HolePunchRemovalCommand holePunchRemovalCommand = new HolePunchRemovalCommand();
            holePunchRemovalCommand.HolePunchLocation =
                HolePunchLocation.Left |
                HolePunchLocation.Right |
                HolePunchLocation.Top |
                HolePunchLocation.Bottom;
            ShowAndDisposeProcessingDialog(new PropertyGridConfigForm(imageViewer1, holePunchRemovalCommand));
#endif
        }

        /// <summary>
        /// Handles the Click event of lineRemovalToolStripMenuItem object.
        /// </summary>
        private void lineRemovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if !REMOVE_DOCCLEANUP_PLUGIN
            ShowAndDisposeProcessingDialog(
                new PropertyGridConfigForm(imageViewer1, new LineRemovalCommand()), false, false);
#endif
        }

        /// <summary>
        /// Handles the Click event of dottedLineRemovalToolStripMenuItem object.
        /// </summary>
        private void dottedLineRemovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if !REMOVE_DOCCLEANUP_PLUGIN
            ShowAndDisposeProcessingDialog(
                new PropertyGridConfigForm(imageViewer1, new DottedLineRemovalCommand()), false, false);
#endif
        }

        /// <summary>
        /// Handles the Click event of shapeRemovalToolStripMenuItem object.
        /// </summary>
        private void shapeRemovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if !REMOVE_DOCCLEANUP_PLUGIN
            ShowAndDisposeProcessingDialog(
                new PropertyGridConfigForm(imageViewer1, new ShapeRemovalCommand()), false, false);
#endif
        }

        /// <summary>
        /// Handles the Click event of colorNoiseClearToolStripMenuItem object.
        /// </summary>
        private void colorNoiseClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if !REMOVE_DOCCLEANUP_PLUGIN
            ShowAndDisposeProcessingDialog(new ColorNoiseClearForm(imageViewer1));
#endif
        }

        /// <summary>
        /// Handles the Click event of advancedReplaceColorCommandToolStripMenuItem object.
        /// </summary>
        private void advancedReplaceColorCommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteAdvancedReplaceColorCommand();
        }

        /// <summary>
        /// Handles the Click event of documentPerspectiveCorrectionToolStripMenuItem object.
        /// </summary>
        private void documentPerspectiveCorrectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteDocumentPerspectiveCorrectionCommand();
        }

        #endregion


        #region Photo Effects

        /// <summary>
        /// Handles the Click event of autoLevelsToolStripMenuItem object.
        /// </summary>
        private void autoLevelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // apply Auto Levels effect to image
            _imageProcessingCommandExecutor.ExecuteProcessingCommand(new AutoLevelsCommand());
        }

        /// <summary>
        /// Handles the Click event of autoColorsToolStripMenuItem object.
        /// </summary>
        private void autoColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // apply Auto Colors effect to image
            _imageProcessingCommandExecutor.ExecuteProcessingCommand(new AutoColorsCommand());
        }

        /// <summary>
        /// Handles the Click event of autoContrastToolStripMenuItem object.
        /// </summary>
        private void autoContrastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // apply the Auto Contrast effect to image
            _imageProcessingCommandExecutor.ExecuteProcessingCommand(new AutoContrastCommand());
        }

        /// <summary>
        /// Handles the Click event of bevelEdgeToolStripMenuItem object.
        /// </summary>
        private void bevelEdgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // apply the Bevel Edge effect to an image
            ShowAndDisposeProcessingDialog(new BevelEdgeForm(imageViewer1));
        }

        /// <summary>
        /// Handles the Click event of dropShadowToolStripMenuItem object.
        /// </summary>
        private void dropShadowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // apply the Drop Shadow effect to an image
            ShowAndDisposeProcessingDialog(
                new PropertyGridConfigForm(imageViewer1, new DropShadowCommand()), false, false);
        }

        /// <summary>
        /// Handles the Click event of motionBlurToolStripMenuItem object.
        /// </summary>
        private void motionBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // apply the Motion Blur effect to an image
            ShowAndDisposeProcessingDialog(new MotionBlurForm(imageViewer1));
        }

        /// <summary>
        /// Handles the Click event of mozaicToolStripMenuItem object.
        /// </summary>
        private void mozaicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // apply the Mozaic effect to an image
            ShowAndDisposeProcessingDialog(new MosaicForm(imageViewer1));
        }

        /// <summary>
        /// Handles the Click event of oilPaintingToolStripMenuItem object.
        /// </summary>
        private void oilPaintingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // apply the Oil Painting effect to an image
            ShowAndDisposeProcessingDialog(new OilPaintingForm(imageViewer1));
        }

        /// <summary>
        /// Handles the Click event of pixelateToolStripMenuItem object.
        /// </summary>
        private void pixelateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // apply the Pixelate effect to an image
            ShowAndDisposeProcessingDialog(new PixelateForm(imageViewer1));
        }

        /// <summary>
        /// Handles the Click event of redEyeRemovalToolStripMenuItem object.
        /// </summary>
        private void redEyeRemovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // apply the Red Eye Removal effect to an image
            ShowAndDisposeProcessingDialog(new RedEyeRemovalForm(imageViewer1));
        }

        /// <summary>
        /// Handles the Click event of sepiaToolStripMenuItem object.
        /// </summary>
        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // apply the Sepia effect to an image
            _imageProcessingCommandExecutor.ExecuteProcessingCommand(new SepiaCommand());
        }

        /// <summary>
        /// Handles the Click event of solarizeToolStripMenuItem object.
        /// </summary>
        private void solarizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // apply the Solarize effect to an image
            _imageProcessingCommandExecutor.ExecuteProcessingCommand(new SolarizeCommand());
        }

        /// <summary>
        /// Handles the Click event of tileReflectionToolStripMenuItem object.
        /// </summary>
        private void tileReflectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // apply the Tile Reflection effect to an image
            ShowAndDisposeProcessingDialog(new TileReflectionForm(imageViewer1), false, false);
        }

        #endregion


        #region FFT

        #region Filtering

        /// <summary>
        /// Handles the Click event of idealLowpassToolStripMenuItem object.
        /// </summary>
        private void idealLowpassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PropertyGridConfigForm dlg = new PropertyGridConfigForm(imageViewer1, new IdealLowpassCommand());
            dlg.IsPreviewAvailable = true;
            // apply Ideal lowpass filter to image
            ShowAndDisposeProcessingDialog(dlg, true, false);
        }

        /// <summary>
        /// Handles the Click event of butterworthLowpassToolStripMenuItem object.
        /// </summary>
        private void butterworthLowpassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PropertyGridConfigForm dlg = new PropertyGridConfigForm(imageViewer1, new ButterworthLowpassCommand());
            dlg.IsPreviewAvailable = true;
            // apply Butterworth lowpass filter to image
            ShowAndDisposeProcessingDialog(dlg, true, false);
        }

        /// <summary>
        /// Handles the Click event of gaussianLowpassToolStripMenuItem object.
        /// </summary>
        private void gaussianLowpassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PropertyGridConfigForm dlg = new PropertyGridConfigForm(imageViewer1, new GaussianLowpassCommand());
            dlg.IsPreviewAvailable = true;
            // apply Gaussian lowpass filter to image
            ShowAndDisposeProcessingDialog(dlg, true, false);
        }

        /// <summary>
        /// Handles the Click event of idealHighPassToolStripMenuItem object.
        /// </summary>
        private void idealHighPassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PropertyGridConfigForm dlg = new PropertyGridConfigForm(imageViewer1, new IdealHighpassCommand());
            dlg.IsPreviewAvailable = true;
            // apply Ideal highpass filter to image
            ShowAndDisposeProcessingDialog(dlg, true, false);
        }

        /// <summary>
        /// Handles the Click event of butterworthHighPassToolStripMenuItem object.
        /// </summary>
        private void butterworthHighPassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PropertyGridConfigForm dlg = new PropertyGridConfigForm(imageViewer1, new ButterworthHighpassCommand());
            dlg.IsPreviewAvailable = true;
            // apply Butterworth highpass filter to image
            ShowAndDisposeProcessingDialog(dlg, true, false);
        }

        /// <summary>
        /// Handles the Click event of gaussianHighpassToolStripMenuItem object.
        /// </summary>
        private void gaussianHighpassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PropertyGridConfigForm dlg = new PropertyGridConfigForm(imageViewer1, new GaussianHighpassCommand());
            dlg.IsPreviewAvailable = true;
            // apply Gaussian highpass filter to image
            ShowAndDisposeProcessingDialog(dlg, true, false);
        }

        #endregion


        /// <summary>
        /// Handles the Click event of imageSmoothingToolStripMenuItem object.
        /// </summary>
        private void imageSmoothingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // apply image smoothing filter to image
            ShowAndDisposeProcessingDialog(new ImageSmoothingForm(imageViewer1));
        }

        /// <summary>
        /// Handles the Click event of imageSharpeningToolStripMenuItem object.
        /// </summary>
        private void imageSharpeningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // apply image sharpening filter to image
            ShowAndDisposeProcessingDialog(new ImageSharpeningForm(imageViewer1));
        }

        /// <summary>
        /// Handles the Click event of frequencySpectumVisualizerToolStripMenuItem object.
        /// </summary>
        private void frequencySpectumVisualizerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(
                new FrequencySpectrumVisualizerForm(imageViewer1), false, false);
        }

        #endregion


        /// <summary>
        /// Handles the CheckedChanged event of useMultithreadingToolStripMenuItem object.
        /// </summary>
        private void useMultithreadingToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            // enable / disable image processing in multiple threads
            if (_imageProcessingCommandExecutor != null)
                _imageProcessingCommandExecutor.ExecuteMultithread = useMultithreadingToolStripMenuItem.Checked;
        }

        /// <summary>
        /// Handles the CheckedChanged event of expandPixelFormatToolStripMenuItem object.
        /// </summary>
        private void expandPixelFormatToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            // enable/disable expanding of image pixel format during image processing
            if (_imageProcessingCommandExecutor != null)
                _imageProcessingCommandExecutor.ExpandSupportedPixelFormats = expandPixelFormatToolStripMenuItem.Checked;
        }

        /// <summary>
        /// Handles the Click event of loadPathsFromMetadataToolStripMenuItem object.
        /// </summary>
        private void loadPathsFromMetadataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.imageViewer1.Image != null)
            {
                // get image metadata tree
                MetadataNode metadata = this.imageViewer1.Image.Metadata.MetadataTree;

                PhotoshopResourcesMetadata photoshopMetadata = metadata.FindChildNode<PhotoshopResourcesMetadata>();

                bool pathsAreLoaded = false;
                if (photoshopMetadata != null)
                {
                    int width = this.imageViewer1.Image.Width;
                    int height = this.imageViewer1.Image.Height;

                    Vintasoft.Imaging.Drawing.Gdi.GdiGraphicsPath paths = new Vintasoft.Imaging.Drawing.Gdi.GdiGraphicsPath();

                    // find image path resources
                    foreach (PhotoshopResource resource in photoshopMetadata.Resources)
                    {
                        if (resource is PhotoshopImagePathResource)
                        {
                            Vintasoft.Imaging.Drawing.IGraphicsPath path = ((PhotoshopImagePathResource)resource).GetPath(width, height);
                            if (path.PointCount > 0)
                                paths.AddPath(path);
                        }
                    }

                    if (paths.PointCount > 0)
                    {
                        // create selection tool with loaded paths
                        PathSelectionRegion selection = new PathSelectionRegion(paths.Source);
                        selection.InteractionController = selection.TransformInteractionController;
                        CustomSelectionTool tool = new CustomSelectionTool();
                        tool.Selection = selection;

                        this.imageViewer1.VisualTool = tool;
                        pathsAreLoaded = true;
                    }
                }

                if (!pathsAreLoaded)
                    DemosTools.ShowInfoMessage("No clipping paths found in metadata.");
            }
        }

        #endregion


        #region 'Tools' menu

        /// <summary>
        /// Handles the Click event of animationToolStripMenuItem object.
        /// </summary>
        private void animationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ShowAnimationForm dlg = new ShowAnimationForm(imageViewer1.Images))
            {
                // show a form with images animation
                dlg.ShowDialog();
            }
        }

        #endregion


        #region 'Help' menu

        /// <summary>
        /// Handles the Click event of aboutToolStripMenuItem object.
        /// </summary>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutBoxForm dlg = new AboutBoxForm())
            {
                dlg.ShowDialog();
            }
        }

        #endregion


        #region SelectionTool's context menu

        /// <summary>
        /// Handles the Opening event of selectionContextMenuStrip object.
        /// </summary>
        private void selectionContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // clear context menu
            customSelectionToolContextMenuStrip.Items.Clear();

            CustomSelectionTool customSelectionTool = CompositeVisualTool.FindVisualTool<CustomSelectionTool>(imageViewer1.VisualTool);
            RectangularSelectionTool rectangularSelectionTool = CompositeVisualTool.FindVisualTool<RectangularSelectionToolWithCopyPaste>(imageViewer1.VisualTool);

            // if current tool has CustomSelectionTool or RectangularSelectionTool then
            if (customSelectionTool != null || rectangularSelectionTool != null)
            {
                // build the selection context menu
                ToolStripMenuItem copyPasteItem = new ToolStripMenuItem("Copy");
                copyPasteItem.Click += new EventHandler(copyImageToolStripMenuItem_Click);
                customSelectionToolContextMenuStrip.Items.Add(copyPasteItem);

                copyPasteItem = new ToolStripMenuItem("Paste");
                copyPasteItem.Click += new EventHandler(pasteImageToolStripMenuItem_Click);
                customSelectionToolContextMenuStrip.Items.Add(copyPasteItem);

                // if current tool has CustomSelectionTool then
                if (customSelectionTool != null)
                {
                    ToolStripMenuItem transformersItem = new ToolStripMenuItem("Transformers");
                    customSelectionToolContextMenuStrip.Items.Add(transformersItem);

                    // if selection tool has selection then
                    if (customSelectionTool.Selection != null)
                    {
                        // add "None" item to context menu - use selection without transformation
                        AddItemToSelectionContextMenu("None", transformersItem.DropDownItems, null);

                        if (customSelectionTool.Selection.BuildingInteractionController != null)
                        {
                            // add separator
                            transformersItem.DropDownItems.Add(new ToolStripSeparator());
                            // add building interaction controller of current selection to context menu
                            AddItemToSelectionContextMenu("Building", transformersItem.DropDownItems, customSelectionTool.Selection.BuildingInteractionController);
                        }

                        // add separator
                        transformersItem.DropDownItems.Add(new ToolStripSeparator());
                        // for each available transform interactions of current selection
                        foreach (string name in customSelectionTool.Selection.AvailableTransformInteractionControllers.Keys)
                        {
                            // add transform interaction controller to context menu
                            AddItemToSelectionContextMenu(name, transformersItem.DropDownItems, customSelectionTool.Selection.AvailableTransformInteractionControllers[name]);
                        }

                        // if current interaction controller is PointBasedObjectPointTransformer then
                        if (customSelectionTool.Selection.InteractionController is PointBasedObjectPointTransformer)
                        {
                            // add separator
                            customSelectionToolContextMenuStrip.Items.Add(new ToolStripSeparator());
                            ToolStripMenuItem item;

                            // selected points indexes
                            int[] selectedIndexes = (customSelectionTool.Selection.InteractionController as PointBasedObjectPointTransformer).SelectedPointIndexes;
                            if (selectedIndexes.Length > 0)
                            {
                                // add "Remove selected points" context menu item
                                item = new ToolStripMenuItem("Remove selected points");
                                item.Click += new EventHandler(removeSelectedPoints_Click);
                                transformersItem.DropDownItems.Add(item);
                            }

                            // add "Add point" context menu item
                            item = new ToolStripMenuItem("Add point");
                            item.Click += new EventHandler(addPoint_Click);
                            transformersItem.DropDownItems.Add(item);
                        }
                    }
                }
                e.Cancel = false;
                return;
            }
            e.Cancel = true;
        }

        /// <summary>
        /// Handles the Click event of removeSelectedPoints object.
        /// </summary>
        private void removeSelectedPoints_Click(object sender, EventArgs e)
        {
            if (HasCustomSelection())
            {
                CustomSelectionTool selectionTool = CompositeVisualTool.FindVisualTool<CustomSelectionTool>(imageViewer1.VisualTool);

                // gets the PointBasedObjectPointTransformer of current selection
                PointBasedObjectPointTransformer controller = (PointBasedObjectPointTransformer)selectionTool.Selection.InteractionController;

                try
                {
                    // remove selected points
                    controller.RemovePoints(controller.SelectedPointIndexes);
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of addPoint object.
        /// </summary>
        private void addPoint_Click(object sender, EventArgs e)
        {
            if (HasCustomSelection())
            {
                CustomSelectionTool selectionTool = CompositeVisualTool.FindVisualTool<CustomSelectionTool>(imageViewer1.VisualTool);
                // gets the PointBasedObjectPointTransformer of current selection
                PointBasedObjectPointTransformer controller = (PointBasedObjectPointTransformer)selectionTool.Selection.InteractionController;

                try
                {
                    // add point to current selection
                    controller.InsertPoint(_selectionContextMenuStripLocation);
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                }
            }
        }

        #endregion


        #region Image viewer

        /// <summary>
        /// Handles the ImageLoading event of imageViewer1 object.
        /// </summary>
        private void imageViewer1_ImageLoading(object sender, ImageLoadingEventArgs e)
        {
            _imageLoadingStartTime = DateTime.Now;
            _imageLoadingTime = TimeSpan.Zero;

            imageLoadingStatusLabel.Visible = true;
            imageLoadingProgressBar.Visible = true;
        }

        /// <summary>
        /// Handles the ImageLoadingProgress event of imageViewer1 object.
        /// </summary>
        private void imageViewer1_ImageLoadingProgress(object sender, ProgressEventArgs e)
        {
            if (_isFormClosing)
            {
                e.Cancel = true;
                return;
            }

            imageLoadingProgressBar.Value = e.Progress;
        }

        /// <summary>
        /// Handles the ImageLoaded event of imageViewer1 object.
        /// </summary>
        private void imageViewer1_ImageLoaded(object sender, ImageLoadedEventArgs e)
        {
            if (_isFormClosing)
                _isFileDialogOpened = false;
            else
                _imageLoadingTime = DateTime.Now.Subtract(_imageLoadingStartTime);

            imageLoadingStatusLabel.Visible = false;
            imageLoadingProgressBar.Visible = false;

            this.IsImageLoaded = true;
        }

        /// <summary>
        /// Handles the ImageLoadingException event of imageViewer1 object.
        /// </summary>
        private void imageViewer1_ImageLoadingException(object sender, ExceptionEventArgs e)
        {
            imageLoadingStatusLabel.Visible = false;
            imageLoadingProgressBar.Visible = false;
        }

        /// <summary>
        /// Handles the ImageChanged event of imageViewer1 object.
        /// </summary>
        private void imageViewer1_ImageChanged(object sender, ImageChangedEventArgs e)
        {
            this.IsImageLoaded = true;
        }

        /// <summary>
        /// Handles the ImageReloaded event of imageViewer1 object.
        /// </summary>
        private void imageViewer1_ImageReloaded(object sender, ImageReloadEventArgs e)
        {
            this.IsImageLoaded = true;
        }

        /// <summary>
        /// Handles the FocusedIndexChanging event of imageViewer1 object.
        /// </summary>
        private void imageViewer1_FocusedIndexChanging(object sender, FocusedIndexChangedEventArgs e)
        {
            if (_isFormClosing)
                return;
        }

        /// <summary>
        /// Handles the FocusedIndexChanged event of imageViewer1 object.
        /// </summary>
        private void imageViewer1_FocusedIndexChanged(object sender, FocusedIndexChangedEventArgs e)
        {
            if (_isFormClosing)
                return;

            viewerToolStrip.SelectedPageIndex = e.FocusedIndex;

            if (_directPixelAccessForm != null)
                _directPixelAccessForm.SelectPixel(-1, -1);
        }

        /// <summary>
        /// Handles the InsertKeyPressed event of imageViewer1 object.
        /// </summary>
        private void imageViewer1_InsertKeyPressed(object sender, KeyEventArgs e)
        {
            InsertKeyPressed();
        }

        /// <summary>
        /// Handles the MouseUp event of imageViewer1 object.
        /// </summary>
        private void imageViewer1_MouseUp(object sender, MouseEventArgs e)
        {
            // if clicked right button then
            if (e.Button == MouseButtons.Right && imageViewer1.Image != null)
            {
                // if current tool has CustomSelectionTool
                // and selection tool has selection
                if (HasCustomSelection())
                {
                    CustomSelectionTool customSelectionTool = CompositeVisualTool.FindVisualTool<CustomSelectionTool>(imageViewer1.VisualTool);
                    // if clicks on selection then
                    RectangleF rect = imageViewer1.RectangleToImage(new RectangleF(e.X, e.Y, 10, 10));
                    if (customSelectionTool.Selection.IsPointOnObject(rect.X, rect.Y, rect.Width))
                    {
                        // show selection context menu
                        _selectionContextMenuStripLocation = rect.Location;
                        customSelectionToolContextMenuStrip.Show(imageViewer1, e.Location);
                        return;
                    }
                }
                else
                {
                    // if current tool has RectangularSelectionTool
                    // and selection tool has selection
                    if (HasRectangularSelection())
                    {
                        RectangularSelectionTool rectangularSelectionTool = CompositeVisualTool.FindVisualTool<RectangularSelectionToolWithCopyPaste>(imageViewer1.VisualTool);
                        // if clicks on selection then
                        RectangleF rect = imageViewer1.RectangleToImage(new RectangleF(e.X, e.Y, 10, 10));
                        if (rectangularSelectionTool.Rectangle.IntersectsWith(new Rectangle((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height)))
                        {
                            // show selection context menu
                            _selectionContextMenuStripLocation = rect.Location;
                            customSelectionToolContextMenuStrip.Show(imageViewer1, e.Location);
                            return;
                        }
                    }
                }

                // show image viewer context menu
                if (imageViewer1.VisualTool == null || !imageViewer1.VisualTool.DisableContextMenu)
                    imageViewerMenuStrip.Show(imageViewer1, e.Location);
            }
        }

        /// <summary>
        /// Handles the VisualToolChanged event of imageViewer1 object.
        /// </summary>
        private void imageViewer1_VisualToolChanged(object sender, VisualToolChangedEventArgs e)
        {
            if (_isVisualToolChanging)
                return;

            if (_imageMapTool.Enabled)
            {
                _isVisualToolChanging = true;
                if (e.VisualTool != null)
                {
                    if (!ContainsTool(e.VisualTool as CompositeVisualTool, _imageMapTool) &&
                        e.VisualTool != _imageMapTool)
                    {
                        imageViewer1.VisualTool = new CompositeVisualTool(_imageMapTool, e.VisualTool);
                    }
                }
                else
                    imageViewer1.VisualTool = _imageMapTool;
                _isVisualToolChanging = false;
            }
        }

        /// <summary>
        /// Handles the ZoomChanged event of imageViewer1 object.
        /// </summary>
        private void imageViewer1_ZoomChanged(object sender, ZoomChangedEventArgs e)
        {
            _imageScaleSelectedMenuItem.Checked = false;
            switch (imageViewer1.SizeMode)
            {
                case ImageSizeMode.BestFit:
                    _imageScaleSelectedMenuItem = bestFitToolStripMenuItem;
                    break;
                case ImageSizeMode.FitToHeight:
                    _imageScaleSelectedMenuItem = fitToHeightToolStripMenuItem;
                    break;
                case ImageSizeMode.FitToWidth:
                    _imageScaleSelectedMenuItem = fitToWidthToolStripMenuItem;
                    break;
                case ImageSizeMode.Normal:
                    _imageScaleSelectedMenuItem = normalImageToolStripMenuItem;
                    break;
                case ImageSizeMode.PixelToPixel:
                    _imageScaleSelectedMenuItem = pixelToPixelToolStripMenuItem;
                    break;
                case ImageSizeMode.Zoom:
                    _imageScaleSelectedMenuItem = scaleToolStripMenuItem;
                    break;
            }
            _imageScaleSelectedMenuItem.Checked = true;
        }

        /// <summary>
        /// Handles the Images_ImageCollectionChanged event of imageViewer1 object.
        /// </summary>
        private void imageViewer1_Images_ImageCollectionChanged(object sender, ImageCollectionChangeEventArgs e)
        {
            if (imageViewer1.Images.Count == 0)
                _isImageLoaded = false;

            if (!_isSourceChanging)
                _isImageCollectionChanged = true;

            // update the UI
            InvokeUpdateUI();
        }

        #endregion


        #region Thumbnail viewer

        /// <summary>
        /// Handles the ThumbnailsLoadingProgress event of thumbnailViewer1 object.
        /// </summary>
        private void thumbnailViewer1_ThumbnailsLoadingProgress(object sender, ThumbnailsLoadingProgressEventArgs e)
        {
            bool isProgressVisible = e.Progress != 100;
            loadingThumbnailsProgressBar.Value = e.Progress;
            addingThumbnailsStatusLabel.Visible = isProgressVisible;
            loadingThumbnailsProgressBar.Visible = isProgressVisible;
        }

        /// <summary>
        /// Handles the InsertKeyPressed event of thumbnailViewer1 object.
        /// </summary>
        private void thumbnailViewer1_InsertKeyPressed(object sender, KeyEventArgs e)
        {
            InsertKeyPressed();
        }

        /// <summary>
        /// Handles the HoveredThumbnailChanged event of thumbnailViewer1 object.
        /// </summary>
        private void thumbnailViewer1_HoveredThumbnailChanged(object sender, ThumbnailEventArgs e)
        {
            if (e.Thumbnail != null)
            {
                try
                {
                    // get information about hovered image in thumbnail viewer
                    ImageSourceInfo imageSourceInfo = e.Thumbnail.Source.SourceInfo;
                    string filename = null;

                    // if image loaded from file
                    if (imageSourceInfo.SourceType == ImageSourceType.File)
                    {
                        // get image file name
                        filename = Path.GetFileName(imageSourceInfo.Filename);
                    }
                    // if image loaded from stream
                    else if (imageSourceInfo.SourceType == ImageSourceType.Stream)
                    {
                        // if stream is file stream
                        if (imageSourceInfo.Stream is FileStream)
                        {
                            // get image file name
                            filename = Path.GetFileName(((FileStream)imageSourceInfo.Stream).Name);
                        }
                    }
                    // if image is new image
                    else
                    {
                        filename = "Bitmap";
                    }

                    // if image is multipage image
                    if (imageSourceInfo.PageCount > 1)
                        e.Thumbnail.ToolTip = string.Format("{0}, page {1}", filename, imageSourceInfo.PageIndex + 1);
                    else
                        e.Thumbnail.ToolTip = filename;
                }
                catch
                {
                    e.Thumbnail.ToolTip = "";
                }
            }
        }

        #endregion

        #endregion


        #region UI state

        /// <summary>
        /// Updates the user interface of this form.
        /// </summary>
        private void UpdateUI()
        {
            // if application is closing
            if (_isFormClosing)
            {
                // exit
                return;
            }


            // get current status of application

            int imageCount = imageViewer1.Images.Count;
            VintasoftImage currentImage = imageViewer1.Image;
            bool isImageLoaded = currentImage != null;
            bool isImageProcessing = this.IsImageProcessing;
            bool isImageSaving = this.IsImageSaving;
            bool isFileOpening = IsFileOpening;

            bool canSaveToTheSameSource = _sourceFilename != null && !_isFileReadOnlyMode;
            if (canSaveToTheSameSource)
            {
                // if the format of the source does not support multiple images (BMP, PNG, ...)
                if (_sourceDecoderName != null &&
                    AvailableEncoders.CreateMultipageEncoderByName(_sourceDecoderName) == null)
                {
                    // saving of image to the source (save changes) is possible only
                    // if one image is loaded in the viewer
                    canSaveToTheSameSource = imageCount == 1;
                }
            }

            // form title
            if (!isFileOpening)
            {
                string str;
                if (_sourceFilename != null)
                    str = Path.GetFileName(_sourceFilename);
                else
                    str = "(Untitled)";

                if (_isFileReadOnlyMode)
                    str += " [Read Only]";

                Text = string.Format(_titlePrefix, str);
            }

            if (!isImageLoaded)
                CloseHistoryForm();

            // "File" menu
            newToolStripMenuItem.Enabled = !isFileOpening;
            openToolStripMenuItem.Enabled = !isFileOpening;
            documentLayoutSettingsToolStripMenuItem.Enabled = !isFileOpening;
            addFromClipboardToolStripMenuItem.Enabled = !isFileOpening;
            acquireFromScannerToolStripMenuItem.Enabled = !isFileOpening;
            captureFromCameraToolStripMenuItem.Enabled = !isFileOpening;

            saveChangesToolStripMenuItem.Enabled = !isFileOpening && isImageLoaded && canSaveToTheSameSource && !isImageProcessing && !isImageSaving && (currentImage.IsChanged || currentImage.Metadata.IsChanged || _isImageCollectionChanged);
            saveAsToolStripMenuItem.Enabled = !isFileOpening && isImageLoaded && !isImageProcessing && !isImageSaving;
            saveToToolStripMenuItem.Enabled = !isFileOpening && isImageLoaded && !isImageProcessing && !isImageSaving;
            saveToDocxToolStripMenuItem.Enabled = !isFileOpening && isImageLoaded && !isImageProcessing && !isImageSaving;
            saveCurrentImageToolStripMenuItem.Enabled = !isFileOpening && isImageLoaded && !isImageProcessing && !isImageSaving;
            printToolStripMenuItem.Enabled = !isFileOpening && isImageLoaded && !isImageProcessing && !isImageSaving;
            closeToolStripMenuItem.Enabled = imageCount > 0 || isFileOpening;

            // "Edit" menu
            UpdateEditMenu();
            documentMetadataToolStripMenuItem.Enabled = imageCount > 0;
            editImageMetadataToolStripMenuItem.Enabled = isImageLoaded;
            editImagePaletteToolStripMenuItem.Enabled = isImageLoaded && !isImageProcessing && currentImage.BitsPerPixel <= 8 && currentImage.PixelFormat != PixelFormat.Undefined;
            enableUndoRedoToolStripMenuItem.Enabled = isImageLoaded && !isImageProcessing && !isImageSaving;
            keepUndoForCurrentImageOnlyToolStripMenuItem.Enabled = isImageLoaded && !isImageProcessing && !isImageSaving;
            undoToolStripMenuItem.Enabled = isImageLoaded && !isImageProcessing && !isImageSaving;
            redoToolStripMenuItem.Enabled = isImageLoaded && !isImageProcessing && !isImageSaving;
            undoRedoSettingsToolStripMenuItem.Enabled = isImageLoaded && enableUndoRedoToolStripMenuItem.Checked;
            showHistoryForDisplayedImagesToolStripMenuItem.Enabled = isImageLoaded && enableUndoRedoToolStripMenuItem.Checked;
            historyDialogToolStripMenuItem.Enabled = isImageLoaded && !isImageProcessing && !isImageSaving && enableUndoRedoToolStripMenuItem.Checked;

            // "View" menu
            currentImageDecodingSettingsToolStripMenuItem.Enabled = imageCount > 0;

            // update "View => Image Display Mode" menu
            singlePageToolStripMenuItem.Checked = false;
            twoColumnsToolStripMenuItem.Checked = false;
            singleContinuousRowToolStripMenuItem.Checked = false;
            singleContinuousColumnToolStripMenuItem.Checked = false;
            twoContinuousRowsToolStripMenuItem.Checked = false;
            twoContinuousColumnsToolStripMenuItem.Checked = false;
            switch (imageViewer1.DisplayMode)
            {
                case ImageViewerDisplayMode.SinglePage:
                    singlePageToolStripMenuItem.Checked = true;
                    break;

                case ImageViewerDisplayMode.TwoColumns:
                    twoColumnsToolStripMenuItem.Checked = true;
                    break;

                case ImageViewerDisplayMode.SingleContinuousRow:
                    singleContinuousRowToolStripMenuItem.Checked = true;
                    break;

                case ImageViewerDisplayMode.SingleContinuousColumn:
                    singleContinuousColumnToolStripMenuItem.Checked = true;
                    break;

                case ImageViewerDisplayMode.TwoContinuousRows:
                    twoContinuousRowsToolStripMenuItem.Checked = true;
                    break;

                case ImageViewerDisplayMode.TwoContinuousColumns:
                    twoContinuousColumnsToolStripMenuItem.Checked = true;
                    break;
            }

            // "Image processing" menu
            imageProcessingToolStripMenuItem.Enabled = isImageLoaded && !isImageProcessing && !isImageSaving;

            // "Tools" menu
            animationToolStripMenuItem.Enabled = imageViewer1.Images.Count > 1 && !isImageProcessing && !isImageSaving;

            // Thumbnail context menu
            thumbnailViewer_addImageFromClipboardToolStripMenuItem.Enabled = addFromClipboardToolStripMenuItem.Enabled;
            thumbnail_setImageFromClipboardMenuItem.Enabled = pasteImageToolStripMenuItem.Enabled;

            // Image viewer context menu
            imageViewer_setImageFromClipboardToolStripMenuItem.Enabled = pasteImageToolStripMenuItem.Enabled;

            // viewer tool strip
            viewerToolStrip.OpenButtonEnabled = openToolStripMenuItem.Enabled;
            viewerToolStrip.SaveButtonEnabled = saveAsToolStripMenuItem.Enabled;
            viewerToolStrip.ScanButtonEnabled = acquireFromScannerToolStripMenuItem.Enabled;
            viewerToolStrip.CaptureFromCameraButtonEnabled = captureFromCameraToolStripMenuItem.Enabled;
            viewerToolStrip.PrintButtonEnabled = printToolStripMenuItem.Enabled;
            viewerToolStrip.PageCount = imageViewer1.Images.Count;

            // image processing history
            if (_historyForm != null)
                _historyForm.Enabled = isImageLoaded && !isImageProcessing && !isImageSaving;

            UpdateUndoRedoMenu(_undoManager);

            // update the focused image information
            UpdateImageInfo();
        }

        /// <summary>
        /// Update UI safely.
        /// </summary>
        private void InvokeUpdateUI()
        {
            if (InvokeRequired)
                Invoke(new UpdateUIDelegate(UpdateUI));
            else
                UpdateUI();
        }

        /// <summary>
        /// Updates the "Edit" menu.
        /// </summary>
        private void UpdateEditMenu()
        {
            VintasoftImage currentImage = imageViewer1.Image;
            bool isImageLoaded = currentImage != null;
            bool isImageProcessing = this.IsImageProcessing;
            bool isImageSaving = this.IsImageSaving;
            bool isFileOpening = IsFileOpening;

            copyImageToolStripMenuItem.Enabled = isImageLoaded && !isImageProcessing && !isImageSaving;

            pasteImageToolStripMenuItem.Enabled = isImageLoaded && !isImageProcessing && !isImageSaving;
            setImageFromFileToolStripMenuItem.Enabled = isImageLoaded && !isImageProcessing && !isImageSaving;

            insertImageFromClipboardToolStripMenuItem.Enabled = !isFileOpening && isImageLoaded && !isImageProcessing && !isImageSaving;
            insertImageFromFileToolStripMenuItem.Enabled = !isFileOpening && isImageLoaded && !isImageProcessing && !isImageSaving;

            deleteImageToolStripMenuItem.Enabled = isImageLoaded && !isImageProcessing && !isImageSaving;

            editImagePixelsToolStripMenuItem.Enabled = isImageLoaded && !isImageProcessing && !isImageSaving;
        }

        #endregion


        #region File manipulation

        /// <summary>
        /// Opens a stream of the image file and adds opened stream to the image collection of image viewer - this allows
        /// to save modified multipage image files back to the source.
        /// </summary>
        /// <param name="filename">Opening file name.</param>
        private void OpenFile(string filename)
        {
            // close the previosly opened file
            CloseCurrentFile();

            // specify that file source is changing
            _isSourceChanging = true;

            // reset flag
            _isImageCollectionChanged = false;

            // save the source filename
            _sourceFilename = Path.GetFullPath(filename);

            // check the source file for read-write access
            CheckSourceFileForReadWriteAccess();

            // add the source file to the viewer
            _imagesManager.Add(filename, _isFileReadOnlyMode);
        }

        /// <summary>
        /// Adds files to the image collection of image viewer.
        /// </summary>
        /// <param name="filenames">Opening files names.</param>
        private void AddFiles(string[] filenames)
        {
            foreach (string filename in filenames)
            {
                // add the source file to the viewer
                _imagesManager.Add(filename);
            }
        }

        /// <summary>
        /// Closes current file.
        /// </summary>
        private void CloseCurrentFile()
        {
            WaitUntilSavingAndProcessingIsFinished();

            _imagesManager.Cancel();

            _isFileReadOnlyMode = false;
            _sourceFilename = null;
            _sourceDecoderName = null;

            imageViewer1.Images.ClearAndDisposeItems();
        }

        /// <summary>
        /// Checks the source file for read-write access.
        /// </summary>
        private void CheckSourceFileForReadWriteAccess()
        {
            _isFileReadOnlyMode = false;
            Stream stream = null;
            try
            {
                stream = new FileStream(_sourceFilename, FileMode.Open, FileAccess.ReadWrite);
            }
            catch (IOException)
            {
            }
            catch (UnauthorizedAccessException)
            {
            }
            if (stream == null)
            {
                _isFileReadOnlyMode = true;
            }
            else
            {
                stream.Close();
                stream.Dispose();
            }
        }

        /// <summary>
        /// Waits until image saving and/or processing is completed.
        /// </summary>
        private void WaitUntilSavingAndProcessingIsFinished()
        {
            // if image collection is saving at the moment
            if (this.IsImageSaving)
            {
                // send signal that saving must be canceled
                _cancelImageSaving = true;
                // wait until saving is canceled/finished
                while (this.IsImageSaving)
                {
                    Thread.Sleep(5);
                    Application.DoEvents();
                }
            }
            // if image is processing at the moment
            while (_imageProcessingCommandExecutor.IsImageProcessingWorking)
            {
                // wait
                Application.DoEvents();
                Thread.Sleep(5);
            }
        }

        /// <summary>
        /// Handler of the ImageViewerImagesManager.AddStarting event.
        /// </summary>
        private void ImagesManager_AddStarting(object sender, EventArgs e)
        {
            IsFileOpening = true;
        }

        /// <summary>
        /// Handler of the ImageViewerImagesManager.ImageSourceAddStarting event.
        /// </summary>
        private void ImagesManager_ImageSourceAddStarting(object sender, ImageSourceEventArgs e)
        {
            // update window title
            string fileState = string.Format("Opening {0}...", Path.GetFileName(e.SourceFilename));
            Text = string.Format(_titlePrefix, fileState);
        }

        /// <summary>
        /// Handler of the ImageViewerImagesManager.ImageSourceAddFinished event.
        /// </summary>
        private void ImagesManager_ImageSourceAddFinished(object sender, ImageSourceEventArgs e)
        {
            // if source is changed
            if (_isSourceChanging)
            {
                if (imageViewer1.Images.Count > 0)
                {
                    // set new source decoder name
                    _sourceDecoderName = imageViewer1.Images[0].SourceInfo.DecoderName;
                }
                _isSourceChanging = false;
            }
        }

        /// <summary>
        /// Handler of the ImageViewerImagesManager.AddFinished event.
        /// </summary>
        private void ImagesManager_AddFinished(object sender, EventArgs e)
        {
            IsFileOpening = false;
            _isSourceChanging = false;
        }

        /// <summary>
        /// Handler of the ImageViewerImagesManager.ImageSourceAddException event.
        /// </summary>
        private void ImagesManager_ImageSourceAddException(object sender, ImageSourceExceptionEventArgs e)
        {
            // show error message
            string message = string.Format("Cannot open {0} : {1}", Path.GetFileName(e.SourceFilename), e.Exception.Message);
            DemosTools.ShowErrorMessage(message);

            // if new source failed to set, close file
            if (_isSourceChanging)
                CloseCurrentFile();
        }

        #endregion


        #region Image info

        /// <summary>
        /// Updates information about the focused image.
        /// </summary>
        private void UpdateImageInfo()
        {
            try
            {
                if (imageViewer1.FocusedIndex == -1)
                {
                    imageInfoLabel.Text = "";
                    return;
                }

                VintasoftImage image = imageViewer1.Image;

                // show message if image is changed
                string sChanged = "";
                if (image.IsChanged)
                    sChanged = "[Changed] ";

                // show loading time
                string sImageLoadingTime = "";
                if (_imageLoadingTime != TimeSpan.Zero)
                    sImageLoadingTime = string.Format("[Loading time: {0}ms] ", _imageLoadingTime.TotalMilliseconds);

                // show error message if not critical error occurs during image loading
                string sImageLoadingError = "";
                if (image.LoadingError)
                    sImageLoadingError = string.Format("[{0}] ", image.LoadingErrorString);

                // image size (megapixels or gigapixels)
                string sizeInfo;
                float mpx = (float)image.Width * image.Height / (1000f * 1000f);
                if (mpx < 0.01)
                    sizeInfo = (image.Width * image.Height).ToString() + "Px";
                else if (mpx < 10)
                    sizeInfo = mpx.ToString("F2", CultureInfo.InvariantCulture) + "MPx";
                else if (mpx < 1000)
                    sizeInfo = mpx.ToString("F1", CultureInfo.InvariantCulture) + "MPx";
                else
                    sizeInfo = (mpx / 1000f).ToString("F2", CultureInfo.InvariantCulture) + "GPx";

                // show information about current image
                imageInfoLabel.Text = string.Format("{0}{1}{2} Codec={8}; Size={3}x{4} ({5}); PixelFormat={6}; Resolution={7}",
                    sChanged, sImageLoadingTime, sImageLoadingError, image.Width, image.Height,
                    sizeInfo,
                    image.PixelFormat, image.Resolution, GetImageCompression(image));
            }
            catch
            {
            }
        }

        /// <summary>
        /// Returns the image compression name.
        /// </summary>
        /// <param name="image">An image.</param>
        /// <returns>Image compression name.</returns>
        private string GetImageCompression(VintasoftImage image)
        {
            string compression = null;
            switch (image.SourceInfo.DecoderName)
            {
                case "Bmp":
                    BmpMetadata bmpMetadata = image.Metadata.MetadataTree as BmpMetadata;
                    if (bmpMetadata != null)
                        compression = bmpMetadata.Compression.ToString();
                    break;

                case "Tiff":
                    TiffPageMetadata tiffMetadata = image.Metadata.MetadataTree as TiffPageMetadata;
                    if (tiffMetadata != null)
                        compression = tiffMetadata.Compression.ToString();
                    break;

#if !REMOVE_PDF_PLUGIN
                case "Pdf":
                    PdfPage page =
                        PdfDocumentController.GetPageAssociatedWithImage(image);
                    if (page.IsImageOnly)
                        compression = page.BackgroundImage.Compression.ToString();
                    break;
#endif
#if !REMOVE_RAW_PLUGIN
                case "Raw":
                    DigitalCameraRawMetadata rawMetadata = image.Metadata.MetadataTree as DigitalCameraRawMetadata;
                    if (rawMetadata != null)
                        compression = rawMetadata.FileFormat.ToString();
                    break;
#endif
                case "Jpeg":
                    JpegMetadata jpegMetadata = image.Metadata.MetadataTree as JpegMetadata;
                    if (jpegMetadata != null)
                        compression = string.Format("Quality {0}", jpegMetadata.Quality);
                    break;
            }

            if (compression != null)
                return string.Format("{0} ({1})", image.SourceInfo.DecoderName, compression);
            return image.SourceInfo.DecoderName;
        }

        #endregion


        #region Save image(s)

        /// <summary>
        /// Saves a single image.
        /// </summary>
        /// <param name="image">Image to save.</param>
        /// <param name="filename">The name of the file in which the image will be saved.</param>
        /// <param name="encoder">Encoder that is used to save the image.</param>
        /// <returns>Saving result.</returns>
        private bool SaveSingleImage(
            VintasoftImage image,
            string filename,
            EncoderBase encoder)
        {
            bool result = true;

            this.IsImageSaving = true;

            // save image to file and do not switch source
            encoder.SaveAndSwitchSource = false;

            try
            {
                // save image synchronously
                image.Save(filename, encoder, images_ImageSavingProgress);
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);

                result = false;
            }

            this.IsImageSaving = false;

            return result;
        }

        /// <summary>
        /// Saves an image collection.
        /// </summary>
        /// <param name="images">Image collection to save.</param>
        /// <param name="filename">The name of the file in which the images will be saved.</param>
        /// <param name="encoder">Encoder that is used to save images.</param>
        /// <param name="saveAndSwitchSource">A value indicating whether to switch to the source after saving.</param>
        /// <returns>Saving result.</returns>
        private bool SaveImageCollection(
            ImageCollection images,
            string filename,
            EncoderBase encoder,
            bool saveAndSwitchSource)
        {
            _encoder = encoder;
            filename = Path.GetFullPath(filename);

            bool result = true;

            this.IsImageSaving = true;

            RenderingSettingsForm.SetRenderingSettingsIfNeed(images, encoder, imageViewer1.ImageRenderingSettings);

            // subscribe to the events
            images.ImageCollectionSavingProgress += new EventHandler<ProgressEventArgs>(images_ImageCollectionSavingProgress);
            images.ImageSavingProgress += new EventHandler<ProgressEventArgs>(images_ImageSavingProgress);
            images.ImageSavingException += new EventHandler<ExceptionEventArgs>(images_ImageSavingException);
            images.ImageCollectionSavingFinished += new EventHandler(images_ImageCollectionSavingFinished);

            if (saveAndSwitchSource)
            {
                _saveFilename = filename;
                _encoderName = encoder.Name;
            }
            else
            {
                _saveFilename = null;
                _encoderName = null;
            }

            // save images to file and switch source
            encoder.SaveAndSwitchSource = saveAndSwitchSource;

            try
            {
                // save image collection asynchronously
                images.SaveAsync(filename, encoder);
            }
            catch (Exception ex)
            {
                _saveFilename = null;

                result = false;

                if (_encoder != null)
                {
                    _encoder.Dispose();
                    _encoder = null;
                }

                DemosTools.ShowErrorMessage(ex);

                IsImageSaving = false;
            }

            return result;
        }

        /// <summary>
        /// Handler of the ImageCollection.ImageCollectionSavingProgress event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ProgressEventArgs"/> instance containing the event data.</param>
        private void images_ImageCollectionSavingProgress(object sender, ProgressEventArgs e)
        {
            // if saving of image must be canceled (application is closing OR new image is opening)
            if (_cancelImageSaving)
            {
                // if saving of image can be canceled (decoder can cancel saving of image)
                if (e.CanCancel)
                {
                    // send a request to cancel saving of image
                    e.Cancel = true;
                    return;
                }
            }

            if (InvokeRequired)
            {
                Invoke(new UpdateImageCollectionSavingProgressMethod(UpdateImageCollectionSavingProgress), e);
            }
            else
            {
                UpdateImageCollectionSavingProgress(e);
            }
        }

        /// <summary>
        /// Handler of the ImageCollection.ImageSavingProgress and VintasoftImage.ImageSavingProgress events.
        /// </summary>
        private void images_ImageSavingProgress(object sender, ProgressEventArgs e)
        {
            // if saving of image must be canceled (application is closing OR new image is opening)
            if (_cancelImageSaving)
            {
                // if saving of image can be canceled (decoder can cancel saving of image)
                if (e.CanCancel)
                    // send a request to cancel saving of image
                    e.Cancel = _cancelImageSaving;
            }

            if (InvokeRequired)
            {
                Invoke(new UpdateImageSavingProgressMethod(UpdateImageSavingProgress), e);
            }
            else
            {
                UpdateImageSavingProgress(e);
                Application.DoEvents();
            }
        }

        /// <summary>
        /// Handler of the ImageCollection.ImageSavingException event.
        /// </summary>
        private void images_ImageSavingException(object sender, ExceptionEventArgs e)
        {
            // do not show error message if application is closing
            if (!_isFormClosing)
                DemosTools.ShowErrorMessage("Image saving error", e.Exception);

            _saveFilename = null;

            this.IsImageSaving = false;
        }

        /// <summary>
        /// Handler of the ImageCollection.ImageCollectionSavingFinished event.
        /// </summary>
        private void images_ImageCollectionSavingFinished(object sender, EventArgs e)
        {
            ImageCollection images = (ImageCollection)sender;

            // unsubscribe from the events
            images.ImageCollectionSavingProgress -= new EventHandler<ProgressEventArgs>(images_ImageCollectionSavingProgress);
            images.ImageSavingProgress -= new EventHandler<ProgressEventArgs>(images_ImageSavingProgress);
            images.ImageSavingException -= new EventHandler<ExceptionEventArgs>(images_ImageSavingException);
            images.ImageCollectionSavingFinished -= new EventHandler(images_ImageCollectionSavingFinished);

            // if image collection saved to the source OR
            // image collection must be switched to new source
            if (_saveFilename != null)
            {
                _sourceFilename = _saveFilename;
                _sourceDecoderName = _encoderName;
                _isFileReadOnlyMode = false;

                _saveFilename = null;
                _encoderName = null;
            }

            if (_encoder != null)
            {
                _encoder.Dispose();
                _encoder = null;
            }

            // saving images completed successfully
            this.IsImageSaving = false;
        }

        /// <summary>
        /// Updates the status about image collection saving. Thread safe.
        /// </summary>
        /// <param name="e">The <see cref="ProgressEventArgs"/> instance containing the event data.</param>
        private void UpdateImageCollectionSavingProgress(ProgressEventArgs e)
        {
            imageCollectionSavingProgressBar.Value = e.Progress;

            bool isProgressVisible = e.Progress != 100;
            imageCollectionSavingStatusLabel.Visible = isProgressVisible;
            imageCollectionSavingProgressBar.Visible = isProgressVisible;
        }

        /// <summary>
        /// Updates status of image saving. Thread safe.
        /// </summary>
        /// <param name="e">The <see cref="ProgressEventArgs"/> instance containing the event data.</param>
        private void UpdateImageSavingProgress(ProgressEventArgs e)
        {
            imageSavingProgressBar.Value = e.Progress;

            bool isProgressVisible = e.Progress != 100;

            imageSavingStatusLabel.Visible = isProgressVisible;
            imageSavingProgressBar.Visible = isProgressVisible;
        }

        #endregion


        #region Image processing

        /// <summary>
        /// Shows and disposes the processing dialog.
        /// </summary>
        /// <param name="dlg">The dialog.</param>
        private void ShowAndDisposeProcessingDialog(ParamsConfigForm dlg)
        {
            ShowAndDisposeProcessingDialog(dlg, false);
        }

        /// <summary>
        /// Shows and disposes the processing dialog.
        /// </summary>
        /// <param name="dlg">The dialog.</param>
        /// <param name="useCurrentViewerZoomWhenPreviewProcessing">
        /// Indicates that image processing must be previewed with zoom from image viewer.
        /// </param>
        private void ShowAndDisposeProcessingDialog(
            ParamsConfigForm dlg,
            bool useCurrentViewerZoomWhenPreviewProcessing)
        {
            ShowAndDisposeProcessingDialog(dlg, useCurrentViewerZoomWhenPreviewProcessing, true);
        }

        /// <summary>
        /// Shows and disposes the processing dialog.
        /// </summary>
        /// <param name="dlg">The dialog.</param>
        /// <param name="useCurrentViewerZoomWhenPreviewProcessing">
        /// Indicates that image processing must be previewed with zoom from image viewer.
        /// </param>
        /// <param name="isPreviewEnabled">
        /// Indicates that the preview in ImageViewer is enabled.
        /// </param>
        private void ShowAndDisposeProcessingDialog(
            ParamsConfigForm dlg,
            bool useCurrentViewerZoomWhenPreviewProcessing,
            bool isPreviewEnabled)
        {
            if (dlg == null)
                return;

            try
            {
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.Owner = this;
                dlg.ExpandSupportedPixelFormats = _imageProcessingCommandExecutor.ExpandSupportedPixelFormats;
                dlg.UseCurrentViewerZoomWhenPreviewProcessing = useCurrentViewerZoomWhenPreviewProcessing;
                dlg.IsPreviewEnabled = isPreviewEnabled;

                if (dlg.ShowProcessingDialog())
                    _imageProcessingCommandExecutor.ExecuteProcessingCommand(dlg.GetProcessingCommand());
            }
            finally
            {
                dlg.Dispose();
            }
        }

        /// <summary>
        /// Inverts the color channel of the image.
        /// </summary>
        /// <param name="color">The channel color.</param>
        private void InvertColorChannel(Color color)
        {
            ColorBlendCommand command = new ColorBlendCommand(BlendingMode.Difference, color);
            _imageProcessingCommandExecutor.ExecuteProcessingCommand(command);
        }

        /// <summary>
        /// Extracts color channels of the image.
        /// </summary>
        /// <param name="rMask">Red channel mask.</param>
        /// <param name="gMask">Green channel mask.</param>
        /// <param name="bMask">Blue channel mask.</param>
        private void ExtractColorChannels(int rMask, int gMask, int bMask)
        {
            Color blendingColor = Color.FromArgb(rMask, gMask, bMask);
            ColorBlendCommand command = new ColorBlendCommand(BlendingMode.Darken, blendingColor);
            _imageProcessingCommandExecutor.ExecuteProcessingCommand(command);
        }

        /// <summary>
        /// Handler of the ImageProcessingCommandExecutor.ImageProcessingCommandStarted event.
        /// </summary>
        private void imageProcessingCommandExecutor_ImageProcessingCommandStarted(object sender, ImageProcessingEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ImageProcessingEventHandlerDelegate(imageProcessingCommandExecutor_ImageProcessingCommandStarted), sender, e);
            }
            else
            {
                this.Cursor = Cursors.WaitCursor;
                this.IsImageProcessing = true;
            }
        }

        /// <summary>
        /// Handler of the ImageProcessingCommandExecutor.ImageProcessingCommandProgress event.
        /// </summary>
        private void imageProcessingCommandExecutor_ImageProcessingCommandProgress(object sender, ImageProcessingProgressEventArgs e)
        {
            if (e.Progress == 100)
            {
                _isEscKeyPressed = false;
            }
            else if (e.CanCancel)
            {
                if (_isEscKeyPressed || _isFormClosing)
                {
                    e.Cancel = true;
                    _isEscKeyPressed = false;
                }
            }

            if (this.InvokeRequired)
                this.BeginInvoke(new UpdateImageProcessingProgressMethod(UpdateImageProcessingProgress), sender, e);
            else
                UpdateImageProcessingProgress(sender, e);
        }

        /// <summary>
        /// Handler of the ImageProcessingCommandExecutor.ImageProcessingCommandFinished event.
        /// </summary>
        private void imageProcessingCommandExecutor_ImageProcessingCommandFinished(object sender, ImageProcessedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ImageProcessedEventHandlerDelegate(imageProcessingCommandExecutor_ImageProcessingCommandFinished), sender, e);
            }
            else
            {
                this.Cursor = Cursors.Default;
                this.IsImageProcessing = false;
            }
        }

        /// <summary>
        /// Updates the "Image processing" progress info. Thread safe.
        /// </summary>
        private void UpdateImageProcessingProgress(object sender, ImageProcessingProgressEventArgs e)
        {
            if (e.Progress == 100)
            {
                imageProcessingProgressBar.Visible = false;

                TimeSpan imageProcessingTime = DateTime.Now - _imageProcessingCommandExecutor.ProcessingCommandStartTime;
                imageProcessingStatusLabel.Text += string.Format(": {0} ms", imageProcessingTime.TotalMilliseconds);
                imageProcessingStatusLabel.Visible = true;
            }
            else
            {
                ProcessingCommandBase processingCommand = sender as ProcessingCommandBase;
                if (processingCommand is ParallelizingProcessingCommand)
                {
                    ParallelizingProcessingCommand parallelizingCommand = (ParallelizingProcessingCommand)processingCommand;
                    imageProcessingStatusLabel.Text = parallelizingCommand.ProcessingCommand.Name + " (parallelized)";
                }
                else
                    imageProcessingStatusLabel.Text = processingCommand.Name;

                imageProcessingProgressBar.Value = e.Progress;
                imageProcessingProgressBar.Visible = true;
            }
        }

        #endregion


        #region Copy, paste image

        /// <summary>
        /// Returns a value, which determines that image viewer has custom selection.
        /// </summary>
        /// <returns>
        /// <b>true</b> - if image viewer has custom selection; otherwise - <b>false</b>.
        /// </returns>
        private bool HasCustomSelection()
        {
            CustomSelectionTool customSelectionTool = CompositeVisualTool.FindVisualTool<CustomSelectionTool>(imageViewer1.VisualTool);
            if (customSelectionTool != null)
            {
                if (customSelectionTool.Selection != null)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Returns a value, which determines that image viewer has rectangular selection.
        /// </summary>
        /// <returns>
        /// <b>true</b> - if image viewer has rectangular selection; otherwise - <b>false</b>.
        /// </returns>
        private bool HasRectangularSelection()
        {
            RectangularSelectionTool rectangularSelectionTool = CompositeVisualTool.FindVisualTool<RectangularSelectionToolWithCopyPaste>(imageViewer1.VisualTool);
            if (rectangularSelectionTool != null)
            {
                if (rectangularSelectionTool.Rectangle.Width > 0 && rectangularSelectionTool.Rectangle.Height > 0)
                    return true;
            }
            return false;
        }


        #region CopyMethods

        /// <summary>
        /// Copies an image from image viewer to the clipboard.
        /// </summary>
        private void CopyImageFromImageViewer()
        {
            VintasoftImage image = null;
            try
            {
                // set rendering settings
                RenderingSettingsForm.SetRenderingSettingsIfNeed(imageViewer1.Image, null, imageViewer1.ImageRenderingSettings);

                // get image
                image = imageViewer1.Image;
                // if image pixel format is Gray16
                if (image.PixelFormat == PixelFormat.Gray16)
                {
                    // change pixel format to Gray8
                    ChangePixelFormatToGrayscaleCommand command = new ChangePixelFormatToGrayscaleCommand(PixelFormat.Gray8);
                    image = command.Execute(image);
                }

                // copy image to the clipboard
                Clipboard.SetImage(image.GetAsBitmap());

                // update user interface
                UpdateUI();
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
            finally
            {
                // if image is NOT empty AND image is not equal to the image in viewer
                if (image != null && image != imageViewer1.Image)
                {
                    // dispose image
                    image.Dispose();
                }
            }
        }

        /// <summary>
        /// Copies an image from custom selection to the clipboard.
        /// </summary>
        private void CopyImageFromCustomSelection()
        {
            // if current tool contains custom selection tool with selection
            if (HasCustomSelection())
            {
                try
                {
                    // get custom selection tool
                    CustomSelectionTool customSelectionTool = CompositeVisualTool.FindVisualTool<CustomSelectionTool>(imageViewer1.VisualTool);

                    // get selection
                    SelectionRegionBase selection = customSelectionTool.Selection;

                    // get selection as graphics path
                    GraphicsPath path = selection.GetAsGraphicsPath();

                    // crop image
                    VintasoftImage cropImage = ImageProcessingCommandExecutor.CropFocusedImage(imageViewer1, new Vintasoft.Imaging.Drawing.Gdi.GdiGraphicsPath(path, false));
                    if (cropImage != null)
                    {
                        // get image as System.Drawing.Bitmap
                        Bitmap bitmap = cropImage.GetAsBitmap();
                        // copy to the clipboard
                        Clipboard.SetImage(bitmap);
                        cropImage.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                }
            }
            // update user interface
            UpdateUI();
        }


        /// <summary>
        /// Copies an image from rectangular selection to the clipboard.
        /// </summary>
        private void CopyImageFromRectangularSelection()
        {
            // get rectangular selection tool
            RectangularSelectionToolWithCopyPaste rectSelectionTool = CompositeVisualTool.FindVisualTool<RectangularSelectionToolWithCopyPaste>(imageViewer1.VisualTool);
            // if rectangular selection tool exists
            if (rectSelectionTool != null)
            {
                try
                {
                    // copy selection to the clipboard
                    rectSelectionTool.CopyToClipboard();
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                }
            }
        }

        /// <summary>
        /// Copies an image from thumbnail to the clipboard.
        /// </summary>
        private void CopyImageFromThumbnailViewer()
        {
            thumbnailViewer1.DoCopy();
        }

        /// <summary>
        /// Copies an image to the clipboard.
        /// </summary>
        private void CopyImageToClipboard()
        {
            if (thumbnailViewer1.Focused)
            {
                CopyImageFromThumbnailViewer();
            }
            else if (HasCustomSelection())
            {
                CopyImageFromCustomSelection();
            }
            else if (HasRectangularSelection())
            {
                CopyImageFromRectangularSelection();
            }
            else
            {
                CopyImageFromImageViewer();
            }
        }

        #endregion


        #region PasteMethods

        /// <summary>
        /// Pastes an image from clipboard to the image viewer.
        /// </summary>
        private void PasteImageToImageViewer()
        {
            // if clipboard does NOT contain an image
            if (!Clipboard.ContainsImage())
                return;

            try
            {
                // if image viewer has focused image
                if (imageViewer1.FocusedIndex != -1)
                {
                    // insert the image from from clipboard
                    int index = imageViewer1.FocusedIndex;
                    imageViewer1.Images.Insert(index, Clipboard.GetImage(), true);
                    imageViewer1.FocusedIndex = index;
                }
                // if image viewer does NOT have focused image
                else
                {
                    // add image from clipboard as new image
                    imageViewer1.Images.Add(Clipboard.GetImage(), true);
                    imageViewer1.FocusedIndex = imageViewer1.Images.Count - 1;
                }
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Pastes an image from clipboard to the custom selection.
        /// </summary>
        private void PasteImageToCustomSelection()
        {
            // if clipboard does NOT contain an image
            if (!Clipboard.ContainsImage())
                return;

            // if current tool contains custom selection tool with selection
            if (HasCustomSelection())
            {
                try
                {
                    // get image
                    VintasoftImage source = imageViewer1.Images[imageViewer1.FocusedIndex];
                    if (source == null)
                        return;

                    // get custom selection tool
                    CustomSelectionTool customSelectionTool = CompositeVisualTool.FindVisualTool<CustomSelectionTool>(imageViewer1.VisualTool);

                    // get selection
                    SelectionRegionBase selection = customSelectionTool.Selection;
                    // get region to paste
                    RectangleF rect = selection.GetBoundingBox();
                    int left = (int)Math.Floor(rect.Left);
                    int top = (int)Math.Floor(rect.Top);
                    int width = (int)Math.Ceiling(rect.Width);
                    int height = (int)Math.Ceiling(rect.Height);
                    if (width <= 0 || height <= 0)
                        return;

                    if (left >= source.Width || top >= source.Height || left + width <= 0 || top + height <= 0)
                        return;

                    if (left < 0)
                    {
                        width += left;
                        left = 0;
                    }
                    if (top < 0)
                    {
                        height += top;
                        top = 0;
                    }
                    if (left + width > source.Width)
                        width = source.Width - left;
                    if (top + height > source.Height)
                        height = source.Height - top;

                    GraphicsPath path = customSelectionTool.Selection.GetAsGraphicsPath();
                    RectangleF pathBounds = path.GetBounds();
                    if (pathBounds.Width <= 0 && pathBounds.Height <= 0)
                        return;

                    // get image from clipboard
                    using (VintasoftImage imageFromClipboard = VintasoftImageGdiExtensions.Create(Clipboard.GetImage(), true))
                    {
                        if (imageFromClipboard.Width != width || imageFromClipboard.Height != height)
                        {
                            // resize image
                            ResizeCommand resizeCommand = new ResizeCommand(width, height);
                            resizeCommand.ExecuteInPlace(imageFromClipboard);
                        }

                        // paste image from clipboard

                        OverlayCommand overlayCommand = new OverlayCommand(imageFromClipboard);
                        // overlay with path command
                        ProcessPathCommand overlayWithPath =
                            new ProcessPathCommand(overlayCommand, new Vintasoft.Imaging.Drawing.Gdi.GdiGraphicsPath(path, false));
                        overlayWithPath.ExecuteInPlace(source);
                    }
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                }
            }
        }

        /// <summary>
        /// Pastes an image from clipboard to the rectangular selection.
        /// </summary>
        private void PasteImageToRectangularSelection()
        {
            // if clipboard does not contain an image
            if (!Clipboard.ContainsImage())
                return;

            // get rectangular selection tool
            RectangularSelectionToolWithCopyPaste rectSelectionTool = CompositeVisualTool.FindVisualTool<RectangularSelectionToolWithCopyPaste>(imageViewer1.VisualTool);
            // if rectangular selection tool exists
            if (rectSelectionTool != null)
            {
                try
                {
                    // paste image from clipboard
                    rectSelectionTool.PasteFromClipboard();
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                }
            }
        }

        /// <summary>
        /// Pastes an image from clipboard to the thumbnail viewer.
        /// </summary>
        private void PasteImageToThumbnailViewer()
        {
            // if clipboard does NOT contain an image
            if (!Clipboard.ContainsImage())
                return;

            try
            {
                // if thumbnail viewer has focused image
                if (thumbnailViewer1.FocusedIndex != -1)
                {
                    // change the focused image to the image from clipboard
                    thumbnailViewer1.Images[thumbnailViewer1.FocusedIndex].SetImage(Clipboard.GetImage(), true);
                }
                // if thumbnail viewer does NOT have focused image
                else
                {
                    // add image from clipboard as new image
                    thumbnailViewer1.Images.Add(Clipboard.GetImage(), true);
                }
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Pastes an image from clipboard.
        /// </summary>
        private void PasteImageFromClipboard()
        {
            if (thumbnailViewer1.Focused)
            {
                PasteImageToThumbnailViewer();
            }
            if (HasCustomSelection())
            {
                PasteImageToCustomSelection();
            }
            else if (HasRectangularSelection())
            {
                PasteImageToRectangularSelection();
            }
            else
            {
                PasteImageToImageViewer();
            }
        }

        #endregion


        /// <summary>
        /// Inserts image from clipboard.
        /// </summary>
        private void InsertKeyPressed()
        {
            // if clipboard contains the image
            if (Clipboard.ContainsImage())
            {
                PasteImageFromClipboard();
            }
        }

        #endregion


        #region Measurement UI actions

        /// <summary>
        /// Updates the UI action items in "Edit" menu.
        /// </summary>
        private void UpdateEditUIActionMenuItems()
        {
            UpdateEditUIActionMenuItem(copyToolStripMenuItem, DemosTools.GetUIAction<CopyItemUIAction>(imageViewer1.VisualTool), "Copy Measurement");
            UpdateEditUIActionMenuItem(cutToolStripMenuItem, DemosTools.GetUIAction<CutItemUIAction>(imageViewer1.VisualTool), "Cut Measurement");
            UpdateEditUIActionMenuItem(pasteToolStripMenuItem, DemosTools.GetUIAction<PasteItemUIAction>(imageViewer1.VisualTool), "Paste Measurement");
            UpdateEditUIActionMenuItem(deleteToolStripMenuItem, DemosTools.GetUIAction<DeleteItemUIAction>(imageViewer1.VisualTool), "Delete Measurement");
            UpdateEditUIActionMenuItem(deleteAllToolStripMenuItem, DemosTools.GetUIAction<DeleteAllItemsUIAction>(imageViewer1.VisualTool), "Delete All Measurements");
        }

        /// <summary>
        /// Updates the UI action item in "Edit" menu.
        /// </summary>
        /// <param name="editMenuItem">The "Edit" menu item.</param>
        /// <param name="uiAction">The UI action, which is associated with the "Edit" menu item.</param>
        /// <param name="defaultText">The default text for the "Edit" menu item.</param>
        private void UpdateEditUIActionMenuItem(ToolStripMenuItem editMenuItem, UIAction uiAction, string defaultText)
        {
            // if UI action is specified AND UI action is enabled
            if (uiAction != null && uiAction.IsEnabled)
            {
                // enable the menu item
                editMenuItem.Enabled = true;
                // set text to the menu item
                editMenuItem.Text = uiAction.Name;
            }
            else
            {
                // disable the menu item
                editMenuItem.Enabled = false;
                // set the default text to the menu item
                editMenuItem.Text = defaultText;
            }
        }

        #endregion


        #region History (undo/redo)

        /// <summary>
        /// Clears the image processing history.
        /// </summary>
        private void ClearHistory()
        {
            _undoManager.Clear();
        }

        /// <summary>
        /// Creates the undo manager.
        /// </summary>
        /// <param name="keepUndoForCurrentImageOnly">Determines that undo information for all images must be kept.</param>
        private void CreateUndoManager(bool keepUndoForCurrentImageOnly)
        {
            DisposeUndoManager();

            if (keepUndoForCurrentImageOnly)
                _undoManager = new UndoManager();
            else
                _undoManager = new CompositeUndoManager();
            _undoManager.UndoLevel = _undoLevel;
            _undoManager.DataStorage = _dataStorage;
            _undoManager.IsEnabled = enableUndoRedoToolStripMenuItem.Checked;

            _undoManager.Changed += new EventHandler<UndoManagerChangedEventArgs>(undoManager_Changed);
            _undoManager.Navigated += new EventHandler<UndoManagerNavigatedEventArgs>(undoManager_Navigated);

            _imageProcessingCommandExecutor.UndoManager = _undoManager;

            _imageViewerUndoMonitor = new ImageViewerUndoMonitor(_undoManager, imageViewer1);
            _imageViewerUndoMonitor.ShowHistoryForDisplayedImages =
                showHistoryForDisplayedImagesToolStripMenuItem.Checked;

            if (_historyForm != null)
                _historyForm.UndoManager = _undoManager;
        }

        /// <summary>
        /// Disposes the undo manager.
        /// </summary>
        private void DisposeUndoManager()
        {
            if (_undoManager == null)
                return;

            _imageProcessingCommandExecutor.UndoManager = null;

            if (_imageViewerUndoMonitor != null)
                _imageViewerUndoMonitor.Dispose();

            _undoManager.Changed -= undoManager_Changed;
            _undoManager.Navigated -= undoManager_Navigated;
            _undoManager.Dispose();
            _undoManager = null;
        }

        /// <summary>
        /// Handler of the UndoManager.Changed event.
        /// </summary>
        private void undoManager_Changed(object sender, UndoManagerChangedEventArgs e)
        {
            if (InvokeRequired)
                Invoke(new UpdateUndoRedoMenuDelegate(UpdateUndoRedoMenu), sender);
            else
                UpdateUndoRedoMenu((UndoManager)sender);
        }

        /// <summary>
        /// Handler of the UndoManager.Navigated event.
        /// </summary>
        private void undoManager_Navigated(object sender, UndoManagerNavigatedEventArgs e)
        {
            if (InvokeRequired)
                Invoke(new UpdateUndoRedoMenuDelegate(UpdateUndoRedoMenu), sender);
            else
                UpdateUndoRedoMenu((UndoManager)sender);
        }

        /// <summary>
        /// Updates the "Undo/Redo" menu.
        /// </summary>
        /// <param name="undoManager">The undo manager.</param>
        private void UpdateUndoRedoMenu(UndoManager undoManager)
        {
            if (!undoManager.IsEnabled)
            {
                undoToolStripMenuItem.Enabled = false;
                undoToolStripMenuItem.Text = "Undo";
                redoToolStripMenuItem.Enabled = false;
                redoToolStripMenuItem.Text = "Redo";
            }
            else
            {
                undoToolStripMenuItem.Enabled = undoManager.UndoCount > 0;
                undoToolStripMenuItem.Text = string.Format("Undo {0}", undoManager.UndoDescription).Trim();

                redoToolStripMenuItem.Enabled = undoManager.RedoCount > 0;
                redoToolStripMenuItem.Text = string.Format("Redo {0}", undoManager.RedoDescription).Trim();
            }

            keepUndoForCurrentImageOnlyToolStripMenuItem.Enabled = undoManager.IsEnabled && enableUndoRedoToolStripMenuItem.Enabled;
            keepUndoForCurrentImageOnlyToolStripMenuItem.Checked = _keepUndoForCurrentImageOnly;
            undoRedoSettingsToolStripMenuItem.Enabled = undoManager.IsEnabled && enableUndoRedoToolStripMenuItem.Enabled;

            if (IsImageProcessing || IsImageSaving || !IsImageLoaded)
            {
                undoToolStripMenuItem.Enabled = false;
                redoToolStripMenuItem.Enabled = false;
                undoRedoSettingsToolStripMenuItem.Enabled = false;
            }
        }

        /// <summary>
        /// Shows the form with image processing history.
        /// </summary>
        private void ShowHistoryForm()
        {
            if (imageViewer1.Image == null)
                return;

            _historyForm = new UndoManagerHistoryForm(this, _undoManager);
            _historyForm.FormClosed += new FormClosedEventHandler(historyForm_FormClosed);
            _historyForm.Show();
        }

        /// <summary>
        /// Closes the form with image processing history.
        /// </summary>
        private void CloseHistoryForm()
        {
            if (_historyForm != null)
            {
                _historyForm.Close();
                _historyForm = null;
            }
        }

        /// <summary>
        /// Handler of the UndoManagerHistoryForm.FormClosed event.
        /// </summary>
        private void historyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            historyDialogToolStripMenuItem.Checked = false;
            _historyForm = null;
        }

        #endregion


        #region Access to image pixels

        /// <summary>
        /// Opens the form for direct access to image pixels.
        /// </summary>
        private void OpenDirectPixelAccessForm()
        {
            if (_directPixelAccessForm == null)
            {
                _directPixelAccessForm = new DirectPixelAccessForm(imageViewer1);
                _directPixelAccessForm.Owner = this;
                _directPixelAccessForm.FormClosed += new FormClosedEventHandler(directPixeAccessForm_FormClosed);
            }

            _directPixelAccessForm.Show();
        }

        /// <summary>
        /// Closes the form for direct access to image pixels.
        /// </summary>
        private void CloseDirectPixelAccessForm()
        {
            if (_directPixelAccessForm != null)
            {
                _directPixelAccessForm.FormClosed -= new FormClosedEventHandler(directPixeAccessForm_FormClosed);
                _directPixelAccessForm.Close();
                _directPixelAccessForm = null;
            }
        }

        /// <summary>
        /// Handler of the DirectPixelAccessForm.FormClosed event.
        /// </summary>
        private void directPixeAccessForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            editImagePixelsToolStripMenuItem.Checked = false;
        }

        #endregion


        #region SelectionTool's context menu

        /// <summary>
        /// Adds new item to the context menu of CustomSelectionTool.
        /// </summary>
        /// <param name="name">Item name.</param>
        /// <param name="items">Item collection.</param>
        /// <param name="interactionController">Interaction controller.</param>
        private void AddItemToSelectionContextMenu(string name, ToolStripItemCollection items, IInteractionController interactionController)
        {
            ToolStripMenuItem item = new ToolStripMenuItem(name);
            item.Tag = interactionController;
            item.Click += new EventHandler(selectionContextMenuStrip_ChangeInteractionController);
            items.Add(item);
        }

        /// <summary>
        /// Changes current interaction controller of selection area.
        /// </summary>
        private void selectionContextMenuStrip_ChangeInteractionController(object sender, EventArgs e)
        {
            // if current tool contains Custom Selection Tool with selection
            if (HasCustomSelection())
            {
                CustomSelectionTool selectionTool = CompositeVisualTool.FindVisualTool<CustomSelectionTool>(imageViewer1.VisualTool);

                // gets an interaction controller of this context menu item
                IInteractionController interactionController = ((IInteractionController)((ToolStripMenuItem)sender).Tag);
                // if the interaction controller is BuildingInteractionController
                if (interactionController == selectionTool.Selection.BuildingInteractionController)
                {
                    // start or continue building of current selection
                    selectionTool.BeginBuilding();
                }
                else
                {
                    // change transform interaction controller of current selection
                    selectionTool.Selection.TransformInteractionController = interactionController;
                    if (selectionTool.Selection.InteractionController != selectionTool.Selection.TransformInteractionController)
                        selectionTool.Selection.InteractionController = selectionTool.Selection.TransformInteractionController;
                }
            }
        }

        #endregion


        #region Visual Tools

        /// <summary>
        /// Determines whether the visual tool is a child tool of the <see cref="CompositeVisualTool"/>.
        /// </summary>
        /// <param name="compositeVisualTool">The composite visual tool.</param>
        /// <param name="visualTool">The visual tool to check.</param>
        /// <returns>
        /// <b>true</b> if specified visual tool is a child tool of the composite visual tool;
        /// <b>false</b> if specified visual tool is not a child tool of the composite visual tool.
        /// </returns>
        private bool ContainsTool(CompositeVisualTool compositeVisualTool, VisualTool visualTool)
        {
            if (compositeVisualTool != null)
            {
                foreach (VisualTool tool in compositeVisualTool)
                {
                    if (tool == visualTool ||
                        ContainsTool(tool as CompositeVisualTool, visualTool))
                        return true;
                }
            }

            return false;
        }

        #endregion


        #region View Rotation

        /// <summary>
        /// Rotates images in both image viewer and thumbnail viewer by 90 degrees clockwise.
        /// </summary>
        private void RotateViewClockwise()
        {
            imageViewer1.RotateViewClockwise();
            thumbnailViewer1.RotateViewClockwise();
        }

        /// <summary>
        /// Rotates images in both image viewer and thumbnail viewer by 90 degrees counterclockwise.
        /// </summary>
        private void RotateViewCounterClockwise()
        {
            imageViewer1.RotateViewCounterClockwise();
            thumbnailViewer1.RotateViewCounterClockwise();
        }

        #endregion

        #endregion

        #endregion



        #region Delegates

        private delegate void UpdateUIDelegate();

        private delegate void SetIsFileOpeningDelegate(bool isFileOpening);

        private delegate void CloseCurrentFileDelegate();

        private delegate void SetAddingFilenameDelegate(string filename);

        private delegate void UpdateImageCollectionSavingProgressMethod(ProgressEventArgs e);
        private delegate void UpdateImageSavingProgressMethod(ProgressEventArgs e);

        private delegate void UpdateImageProcessingProgressMethod(object sender, ImageProcessingProgressEventArgs e);

        private delegate void ImageProcessingEventHandlerDelegate(object sender, ImageProcessingEventArgs e);
        private delegate void ImageProcessedEventHandlerDelegate(object sender, ImageProcessedEventArgs e);

        private delegate void UpdateUndoRedoMenuDelegate(UndoManager undoManager);



        #endregion

    }
}
