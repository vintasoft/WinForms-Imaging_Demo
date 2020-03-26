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
using Vintasoft.Imaging.ImageProcessing.Info;

using DemosCommonCode;
using DemosCommonCode.Imaging;
using DemosCommonCode.Imaging.Codecs;
using DemosCommonCode.Imaging.ColorManagement;
using DemosCommonCode.Twain;
using DemosCommonCode.Barcode;
using Vintasoft.Imaging.Drawing.Gdi;
#if !REMOVE_BARCODE_SDK
using Vintasoft.Barcode; 
#endif
#if !REMOVE_PDF_PLUGIN
using DemosCommonCode.Pdf;
using Vintasoft.Imaging.Pdf.Tree;
using Vintasoft.Imaging.Pdf;
using Vintasoft.Imaging.Pdf.Drawing;
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
        /// Name of the first image file in the image collection of the image viewer.
        /// </summary>
        string _sourceFilename;

        /// <summary>
        /// Decoder name of the first image file in the image collection of the image viewer.
        /// </summary>
        string _sourceDecoderName;

        /// <summary>
        /// Determines that stream of the first image file is readonly.
        /// </summary>
        bool _sourceStreamIsReadOnly = false;

        /// <summary>
        /// Selected "View - Image scale mode" menu item.
        /// </summary>
        ToolStripMenuItem _imageScaleSelectedMenuItem;

        /// <summary>
        /// Image map tool.
        /// </summary>
        ImageMapTool _imageMapTool;

        /// <summary>
        /// Determines that the Open File Dialog is opened.
        /// </summary>
        bool _isFileDialogOpened = false;

        PointF _selectionContextMenuStripLocation;


        #region Load

        /// <summary>
        /// Time when loading of image is started.
        /// </summary>
        DateTime _imageLoadingStartTime;
        /// <summary>
        /// Time of image loading.
        /// </summary>
        TimeSpan _imageLoadingTime = TimeSpan.Zero;

        /// <summary>
        /// Determines that images are changed.
        /// </summary>
        bool _areImagesChanged = false;

        #endregion


        #region Save

        /// <summary>
        /// Filename of the image file to save the image collection of the image viewer.
        /// </summary>
        string _saveFilename;

        /// <summary>
        /// Name of the encoder to save the image collection of the image viewer.
        /// </summary>
        string _encoderName;

        /// <summary>
        /// Determines that saving of image must be canceled.
        /// </summary>
        bool _cancelImageSaving = false;

        #endregion


        #region Print

        /// <summary>
        /// ThumbnailViewer print manager.
        /// </summary>
        ImageViewerPrintManager _thumbnailViewerPrintManager;

        #endregion


        #region Scan

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
        /// A form that shows image processing history.
        /// </summary>
        UndoManagerHistoryForm _historyForm;

        /// <summary>
        /// Determines that undo information for all images must be kept.
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
        /// The undo monitor of image viewer.
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
        /// Form for direct access to pixels of image.
        /// </summary>
        DirectPixelAccessForm _directPixelAccessForm;


        /// <summary>
        /// Determines that ESC key is pressed.
        /// </summary>
        bool _isEscPressed = false;
        /// <summary>
        /// Determines that form of application is closing.
        /// </summary> 
        bool _isFormClosing = false;

        bool _isVisualToolChanging = false;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            Jbig2AssemblyLoader.Load();
            Jpeg2000AssemblyLoader.Load();
            RawAssemblyLoader.Load();
            DicomAssemblyLoader.Load();
            PdfAnnotationsAssemblyLoader.Load();
            DocxAssemblyLoader.Load();
            PdfAssemblyLoader.Load();

            ImagingTypeEditorRegistrator.Register();

            _imageMapTool = new ImageMapTool();

            viewerToolStrip.ImageViewer = imageViewer1;


            thumbnailViewer1.ThumbnailRenderingThreadCount = Math.Max(1, Environment.ProcessorCount / 2);

            imageViewer1.Images.ImageCollectionChanged += new EventHandler<ImageCollectionChangeEventArgs>(Images_CollectionChanged);

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
            _imageProcessingCommandExecutor.ImageProcessingCommandStarted += new EventHandler<ImageProcessingEventArgs>(_imageProcessingCommandExecutor_ImageProcessingCommandStarted);
            _imageProcessingCommandExecutor.ImageProcessingCommandProgress += new EventHandler<ImageProcessingProgressEventArgs>(_imageProcessingCommandExecutor_ImageProcessingCommandProgress);
            _imageProcessingCommandExecutor.ImageProcessingCommandFinished += new EventHandler<ImageProcessedEventArgs>(_imageProcessingCommandExecutor_ImageProcessingCommandFinished);

            // create the image undo managers
            enableUndoRedoToolStripMenuItem.Checked = false;
            CreateUndoManager(_keepUndoForCurrentImageOnly);
            UpdateUndoRedoMenu(_undoManager);

            //
            CodecsFileFilters.SetFilters(openFileDialog1);
            DemosTools.SetDemoImagesFolder(openFileDialog1);
            DemosTools.CatchVisualToolExceptions(imageViewer1);

            editToolStripMenuItem.DropDownOpening += new EventHandler(editToolStripMenuItem_DropDownOpening);


            SelectionVisualToolActionFactory.CreateActions(visualToolsToolStrip1);
            MeasurementVisualToolActionFactory.CreateActions(visualToolsToolStrip1);
            ZoomVisualToolActionFactory.CreateActions(visualToolsToolStrip1);
            ImageProcessingVisualToolActionFactory.CreateActions(visualToolsToolStrip1);
            CustomVisualToolActionFactory.CreateActions(visualToolsToolStrip1);
            BarcodeReaderToolActionFactory.CreateActions(visualToolsToolStrip1);
            BarcodeWriterToolActionFactory.CreateActions(visualToolsToolStrip1);

            UpdateUI();

            imageViewer1.Focus();

            DocumentPasswordForm.EnableAuthentication(imageViewer1);

#if !REMOVE_PDF_PLUGIN
            // set CustomFontProgramsController for all opened PDF documents
            CustomFontProgramsController.EnableUsageOfDefaultFontProgramsController();
#endif
        }

        #endregion



        #region Properties

        bool _isImageLoaded = false;
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
        internal bool IsImageProcessing
        {
            get { return _isImageProcessing; }
            set
            {
                _isImageProcessing = value;

                UpdateUI();
            }
        }

        bool _isImageOpening = false;
        bool IsImageOpening
        {
            get { return _isImageOpening; }
            set
            {
                _isImageOpening = value;
            }
        }

        bool _isImageSaving = false;
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

        #region Main form

        /// <summary>
        /// Main form is shown.
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
                        OpenFile(appArgs[1]);
                    }
                    catch
                    {
                        CloseFile();
                    }
                }
                else
                {
                    for (int i = 1; i < appArgs.Length; i++)
                    {
                        try
                        {
                            imageViewer1.Images.Add(appArgs[i]);
                        }
                        catch
                        {
                        }
                    }
                }
            }

            thumbnailViewer1.Focus();
        }

        /// <summary>
        /// Key is down.
        /// </summary>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            _isEscPressed = e.KeyData == Keys.Escape;
        }

        /// <summary>
        /// Main form is closing.
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
        /// Main form is closed.
        /// </summary>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //
            WaitWhileSavingAndProcessingIsFinished();

            //
            CloseFile();

            ClearHistory();

            DisposeUndoManager();

            if (_dataStorage != null)
                _dataStorage.Dispose();
        }

        #endregion


        #region UI state

        /// <summary>
        /// Updates the user interface of this form.
        /// </summary>
        private void UpdateUI()
        {
            // if application is closing
            if (_isFormClosing)
                // exit
                return;


            // get the current status of application

            int imageCount = imageViewer1.Images.Count;
            VintasoftImage currentImage = imageViewer1.Image;
            bool isImageLoaded = currentImage != null;
            bool isImageProcessing = this.IsImageProcessing;
            bool isImageSaving = this.IsImageSaving;

            bool canSaveToTheSameSource = _sourceFilename != null && !_sourceStreamIsReadOnly;
            if (canSaveToTheSameSource)
            {
                // if format of source does not support multiple images (BMP, PNG, ...)
                if (_sourceDecoderName != null &&
                    AvailableEncoders.CreateMultipageEncoderByName(_sourceDecoderName) == null)
                    // saving of image to the source (save changes) is possible only
                    // if one image is loaded in the viewer
                    canSaveToTheSameSource = imageCount == 1;
            }


            // form title
            if (_sourceFilename == null)
            {
                this.Text = string.Format(_titlePrefix, "(Untitled)");
            }
            else
            {
                string imageSourceInfo = Path.GetFileName(_sourceFilename);
                if (_sourceStreamIsReadOnly)
                    imageSourceInfo += " [Read Only]";
                this.Text = string.Format(_titlePrefix, imageSourceInfo);
            }
            if (!isImageLoaded)
                CloseHistoryForm();


            // "File" menu
            //
            addFromClipboardToolStripMenuItem.Enabled = true;
            //
            saveChangesToolStripMenuItem.Enabled = isImageLoaded && canSaveToTheSameSource && !isImageProcessing && !isImageSaving && (currentImage.IsChanged || currentImage.Metadata.IsChanged || _areImagesChanged);
            saveAsToolStripMenuItem.Enabled = isImageLoaded && !isImageProcessing && !isImageSaving;
            saveToToolStripMenuItem.Enabled = isImageLoaded && !isImageProcessing && !isImageSaving;
            saveCurrentImageToolStripMenuItem.Enabled = isImageLoaded && !isImageProcessing && !isImageSaving;
            //
            printToolStripMenuItem.Enabled = isImageLoaded && !isImageProcessing && !isImageSaving;
            //
            closeToolStripMenuItem.Enabled = _sourceFilename != null && !isImageProcessing && !isImageSaving;

            // "Edit" menu
            //
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
            //
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


            // Toolstip
            viewerToolStrip.CanSaveFile = saveAsToolStripMenuItem.Enabled;
            viewerToolStrip.CanPrint = printToolStripMenuItem.Enabled;
            viewerToolStrip.PageCount = imageViewer1.Images.Count;

            // Image processing history

            if (_historyForm != null)
                _historyForm.Enabled = isImageLoaded && !isImageProcessing && !isImageSaving;

            UpdateUndoRedoMenu(_undoManager);

            // update information about the focused image
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
            bool isEntireImageLoaded = imageViewer1.IsEntireImageLoaded;
            bool isImageProcessing = this.IsImageProcessing;
            bool isImageSaving = this.IsImageSaving;
            //
            copyImageToolStripMenuItem.Enabled = isImageLoaded && !isImageProcessing && !isImageSaving;
            //
            pasteImageToolStripMenuItem.Enabled = isImageLoaded && !isImageProcessing && !isImageSaving;
            setImageFromFileToolStripMenuItem.Enabled = isImageLoaded && !isImageProcessing && !isImageSaving;
            //
            insertImageFromClipboardToolStripMenuItem.Enabled = isImageLoaded && !isImageProcessing && !isImageSaving;
            insertImageFromFileToolStripMenuItem.Enabled = isImageLoaded && !isImageProcessing && !isImageSaving;
            //
            deleteImageToolStripMenuItem.Enabled = isImageLoaded && !isImageProcessing && !isImageSaving;
            //
            editImagePixelsToolStripMenuItem.Enabled = isEntireImageLoaded && !isImageProcessing && !isImageSaving;
        }

        /// <summary>
        /// Updates the "Edit" menu when it is opening.
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

        #endregion


        #region 'File' menu

        /// <summary>
        /// Updates the "File" menu when it is opening.
        /// </summary>
        private void fileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            UpdateUI();
            if (!Clipboard.ContainsImage())
                addFromClipboardToolStripMenuItem.Enabled = false;
        }

        /// <summary>
        /// Creates new image and adds image to the image collection of the image viewer.
        /// </summary>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (CreateNewImageForm dlg = new CreateNewImageForm())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    VintasoftImage image = dlg.CreateImage();
                    imageViewer1.Images.Add(image);
                }
            }
        }

        /// <summary>
        /// Clears image collection of the image viewer and adds image(s) to the image collection
        /// of the image viewer.
        /// </summary>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_isFileDialogOpened)
                return;

            _isFileDialogOpened = true;

            // select image file
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //
                WaitWhileSavingAndProcessingIsFinished();

                // if image collection of image viewer is not empty
                if (imageViewer1.Images.Count > 0)
                    // clear the image collection of the image viewer
                    imageViewer1.Images.ClearAndDisposeItems();

                //
                CloseFile();

                try
                {
                    OpenFile(openFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                }
            }

            _isFileDialogOpened = false;
        }

        /// <summary>
        /// Adds image(s) to the image collection of the image viewer.
        /// </summary>
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_isFileDialogOpened)
                return;

            _isFileDialogOpened = true;
            openFileDialog1.Multiselect = true;

            // select image file(s)
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // add images from selected image sources (files) to temporary image collection
                ImageCollection images = new ImageCollection();
                foreach (string fileName in openFileDialog1.FileNames)
                {
                    try
                    {
                        images.Add(fileName);
                    }
                    catch (Exception ex)
                    {
                        DemosTools.ShowErrorMessage(ex, fileName);
                    }
                }

                // add images from temporary image collection to the image collection of image viewer
                imageViewer1.Images.AddRange(images.ToArray());
            }

            openFileDialog1.Multiselect = false;
            _isFileDialogOpened = false;
        }

        /// <summary>
        /// Adds image from clipboard to the image collection of the image viewer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addFromClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                Image bitmap = Clipboard.GetImage();
                VintasoftImage image = new VintasoftImage(bitmap, true);
                imageViewer1.Images.Add(image);

                // update the UI
                Update();
            }
        }


        /// <summary>
        /// Acquires image(s) from scanner.
        /// </summary>
        private void acquireFromScannerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool scanMenuEnabled = acquireFromScannerToolStripMenuItem.Enabled;
            acquireFromScannerToolStripMenuItem.Enabled = false;
            bool viewerToolStripCanScan = viewerToolStrip.CanScan;
            viewerToolStrip.IsScanEnabled = false;

            try
            {
                if (_simpleTwainManager == null)
                    _simpleTwainManager = new SimpleTwainManager(this, imageViewer1.Images);

                _simpleTwainManager.SelectDeviceAndAcquireImage();
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
            finally
            {
                acquireFromScannerToolStripMenuItem.Enabled = scanMenuEnabled;
                viewerToolStrip.IsScanEnabled = viewerToolStripCanScan;
            }
        }


        /// <summary>
        /// Captures image(s) from camera (webcam).
        /// </summary>
        private void captureFromCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ImageCaptureDevice device = WebcamSelectionForm.SelectWebcam();
                if (device != null)
                {
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
        /// Saves changes in image collection to the source file.
        /// </summary>
        private void saveChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EncoderBase encoder = null;
            try
            {
                if (PluginsEncoderFactory.Default.GetEncoderByName(_sourceDecoderName, out encoder))
                    SaveImageCollection(imageViewer1.Images, _sourceFilename, encoder, true);
                else
                    DemosTools.ShowErrorMessage("Image is not saved.");
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Saves image collection to new source and switches to the new source.
        /// </summary>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_isFileDialogOpened)
                return;
            _isFileDialogOpened = true;

            bool saveSingleImage = imageViewer1.Images.Count == 1;

            try
            {
                CodecsFileFilters.SetFilters(saveFileDialog1, !saveSingleImage);
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string filename = saveFileDialog1.FileName;

                    PluginsEncoderFactory encoderFactory = new PluginsEncoderFactory();
                    encoderFactory.CanAddImagesToExistingFile = false;

                    EncoderBase encoder = null;
                    if (encoderFactory.GetEncoder(filename, out encoder))
                        SaveImageCollection(imageViewer1.Images, filename, encoder, true);
                    else
                        DemosTools.ShowErrorMessage("Images are not saved.");
                }
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }

            _isFileDialogOpened = false;
        }

        /// <summary>
        /// Saves image collection to new source and do NOT switch to the new source.
        /// </summary>
        private void saveToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_isFileDialogOpened)
                return;
            _isFileDialogOpened = true;

            bool saveSingleImage = imageViewer1.Images.Count == 1;

            //
            CodecsFileFilters.SetFilters(saveFileDialog1, !saveSingleImage);
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename = Path.GetFullPath(saveFileDialog1.FileName);
                bool isFileExist = File.Exists(filename);

                try
                {
                    PluginsEncoderFactory encoderFactory = new PluginsEncoderFactory();
                    encoderFactory.CanAddImagesToExistingFile = isFileExist;

                    EncoderBase encoder = null;
                    if (encoderFactory.GetEncoder(filename, out encoder))
                        SaveImageCollection(imageViewer1.Images, filename, encoder, false);
                    else
                        DemosTools.ShowErrorMessage("Image is not saved.");
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                }
            }

            _isFileDialogOpened = false;
        }

        /// <summary>
        /// Saves current image to a file.
        /// </summary>
        private void saveCurrentImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_isFileDialogOpened)
                return;
            _isFileDialogOpened = true;

            //
            CodecsFileFilters.SetFilters(saveFileDialog1, false);
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename = Path.GetFullPath(saveFileDialog1.FileName);
                bool isFileExist = File.Exists(filename);

                PluginsEncoderFactory encoderFactory = new PluginsEncoderFactory();
                encoderFactory.CanAddImagesToExistingFile = isFileExist;

                EncoderBase encoder = null;
                if (encoderFactory.GetEncoder(filename, out encoder))
                {
                    VintasoftImage image = imageViewer1.Images[imageViewer1.FocusedIndex];
                    // save the image
                    SaveSingleImage(image, filename, encoder);
                }
                else
                    DemosTools.ShowErrorMessage("Image is not saved.");
            }

            _isFileDialogOpened = false;
        }


        /// <summary>
        /// Closes the current image file.
        /// </summary>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
            WaitWhileSavingAndProcessingIsFinished();

            imageViewer1.Images.ClearAndDisposeItems();

            //
            CloseFile();

            CloseHistoryForm();

            UpdateUI();
        }


        /// <summary>
        /// Exits the application.
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion


        #region 'Edit' menu

        #region Copy, paste and delete image

        /// <summary>
        /// Copies an image to the clipboard.
        /// </summary>
        private void copyImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyImageToClipboard();
        }


        /// <summary>
        /// Pastes an image from clipboard.
        /// </summary>
        private void pasteImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasteImageFromClipboard();
        }

        /// <summary>
        /// Sets an image from a file.
        /// </summary>
        private void setImageFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    VintasoftImage image = new VintasoftImage(openFileDialog1.FileName);
                    imageViewer1.Image.SetImage(image);
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                }
            }
        }


        /// <summary>
        /// Inserts an image from clipboard to the image viewer.
        /// </summary>
        private void insertImageFromClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                try
                {
                    VintasoftImage image = new VintasoftImage(Clipboard.GetImage(), true);
                    imageViewer1.Images.Insert(imageViewer1.FocusedIndex, image);
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                }
            }
        }

        /// <summary>
        /// Inserts an image from file to the image viewer.
        /// </summary>
        private void insertImageFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    imageViewer1.Images.Insert(imageViewer1.FocusedIndex, openFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                }
            }
        }


        /// <summary>
        /// Deletes an image from image viewer.
        /// </summary>
        private void deleteImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VintasoftImage image = imageViewer1.Images[imageViewer1.FocusedIndex];
            imageViewer1.Images.RemoveAt(imageViewer1.FocusedIndex);
            image.Dispose();
        }

        #endregion


        #region Copy, paste and delete measurement object

        /// <summary>
        /// Copies the selected measurement into "internal" buffer.
        /// </summary>
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // get the copy UI action for current visual tool
            CopyItemUIAction copyUIAction = DemosTools.GetUIAction<CopyItemUIAction>(imageViewer1.VisualTool);
            // if UI action exists
            if (copyUIAction != null)
                // execute the UI action
                copyUIAction.Execute();

            // update the UI
            UpdateUI();
        }

        /// <summary>
        /// Cuts the selected measurement into "internal" buffer.
        /// </summary>
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
        /// Pastes measurement from "internal" buffer and makes it active.
        /// </summary>
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
        /// Removes the selected measurement.
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
        /// Removes all measurements.
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
        /// Shows document metadata window.
        /// </summary>
        private void documentMetadataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocumentMetadata metadata = imageViewer1.Image.SourceInfo.Decoder.GetDocumentMetadata();

            if (metadata != null)
            {
                using (PropertyGridForm propertyForm = new PropertyGridForm(metadata, "Document Metadata"))
                {
                    propertyForm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("File does not contain metadata.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Shows a form for editing image metadata.
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
                    DicomMetadataEditorForm editorForm = new DicomMetadataEditorForm();
                    editorForm.Image = imageViewer1.Image;
                    form = editorForm;
                }
                else
#endif
                {
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
        /// Shows a form for editing image palette.
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

            if (paletteDialog.ShowDialog() != DialogResult.OK)
            {
                if (paletteDialog.PaletteViewer.IsPaletteChanged)
                    imageViewer1.Image.Palette.SetColors(backupPalette.GetAsArray());
            }
        }

        /// <summary>
        /// Shows a form for editing image pixels.
        /// </summary>
        private void editImagePixelsToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            if (editImagePixelsToolStripMenuItem.Checked)
                OpenDirectPixelAccessForm();
            else
                CloseDirectPixelAccessForm();
        }


        #region Undo/redo changes in images

        /// <summary>
        /// Enables/disables the image processing history.
        /// </summary>
        private void enableUndoRedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isEnabled = _undoManager.IsEnabled ^ true;

            enableUndoRedoToolStripMenuItem.Checked = isEnabled;

            if (!isEnabled)
                // clear the image processing history
                _undoManager.Clear();

            _undoManager.IsEnabled = isEnabled;

            // close the image processing history form
            CloseHistoryForm();

            // initialize the "Undo/Redo" menu
            UpdateUndoRedoMenu(_undoManager);
            // update the UI
            UpdateUI();
        }

        /// <summary>
        /// Enables/disables the image processing history for current image only.
        /// </summary>
        private void keepUndoForCurrentImageOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            keepUndoForCurrentImageOnlyToolStripMenuItem.Checked ^= true;

            _keepUndoForCurrentImageOnly = keepUndoForCurrentImageOnlyToolStripMenuItem.Checked;

            CreateUndoManager(_keepUndoForCurrentImageOnly);
        }

        /// <summary>
        /// Undoes changes in image.
        /// </summary>
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _undoManager.Undo(1);

            UpdateUndoRedoMenu(_undoManager);
        }

        /// <summary>
        /// Redoes changes in image.
        /// </summary>
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _undoManager.Redo(1);

            UpdateUndoRedoMenu(_undoManager);
        }

        /// <summary>
        /// Enables/disables showing history only for displayed images.
        /// </summary>
        private void showHistoryForDisplayedImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showHistoryForDisplayedImagesToolStripMenuItem.Checked ^= true;

            _imageViewerUndoMonitor.ShowHistoryForDisplayedImages =
                showHistoryForDisplayedImagesToolStripMenuItem.Checked;
        }

        /// <summary>
        /// Edits the undo manager settings.
        /// </summary>
        private void undoRedoSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (UndoManagerSettingsForm dlg = new UndoManagerSettingsForm(_undoManager, _dataStorage))
            {
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.Owner = this;

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
        /// Shows/hides the form that shows the image processing history.
        /// </summary>
        private void historyDialogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            historyDialogToolStripMenuItem.Checked ^= true;

            if (historyDialogToolStripMenuItem.Checked)
                // show the image processing history form
                ShowHistoryForm();
            else
                // close the image processing history form
                CloseHistoryForm();
        }

        #endregion

        #endregion


        #region 'View' menu

        /// <summary>
        /// Shows the thumbnail viewer settings. 
        /// </summary>
        private void thumbnailViewerSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ThumbnailViewerSettingsForm dlg = new ThumbnailViewerSettingsForm(thumbnailViewer1))
            {
                dlg.ShowDialog();
            }
        }


        /// <summary>
        /// Changes the image display mode of image viewer.
        /// </summary>
        private void ImageDisplayMode_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem imageDisplayModeMenuItem = (ToolStripMenuItem)sender;
            imageViewer1.DisplayMode = (ImageViewerDisplayMode)imageDisplayModeMenuItem.Tag;
            UpdateUI();
        }

        /// <summary>
        /// Changes the image scale mode of image viewer.
        /// </summary>
        private void ImageScale_Click(object sender, EventArgs e)
        {
            _imageScaleSelectedMenuItem.Checked = false;
            _imageScaleSelectedMenuItem = (ToolStripMenuItem)sender;

            // if menu item sets ImageSizeMode
            if (_imageScaleSelectedMenuItem.Tag is ImageSizeMode)
            {
                // set size mode
                imageViewer1.SizeMode = (ImageSizeMode)_imageScaleSelectedMenuItem.Tag;
                _imageScaleSelectedMenuItem.Checked = true;
            }
            // if menu item sets zoom
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
        /// Enables/disables centering of image in image viewer.
        /// </summary>
        private void centerImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (centerImageToolStripMenuItem.Checked)
            {
                imageViewer1.FocusPointAnchor = AnchorType.None;
                imageViewer1.IsFocusPointFixed = true;
                imageViewer1.ScrollToCenter();
            }
            else
            {
                imageViewer1.FocusPointAnchor = AnchorType.Left | AnchorType.Top;
                imageViewer1.IsFocusPointFixed = true;
            }
        }

        /// <summary>
        /// Shows the image viewer settings.
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
        /// Shows the image map settings.
        /// </summary>
        private void imageMapSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ImageMapToolSettingsForm mapSettingsDialog = new ImageMapToolSettingsForm(_imageMapTool))
            {
                mapSettingsDialog.ShowDialog();
            }

            _isVisualToolChanging = true;

            if (_imageMapTool.Enabled)
            {
                if (imageViewer1.VisualTool == null)
                    imageViewer1.VisualTool = _imageMapTool;
                else
                {
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
                if (imageViewer1.VisualTool != null)
                {
                    if (imageViewer1.VisualTool is CompositeVisualTool)
                    {
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
                        imageViewer1.VisualTool = null;
                }
            }

            _isVisualToolChanging = false;
        }

        /// <summary>
        /// Shows the image magnifier settings.
        /// </summary>
        private void magnifierSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MagnifierToolAction magnifierToolAction = visualToolsToolStrip1.FindAction<MagnifierToolAction>();

            if (magnifierToolAction != null)
                magnifierToolAction.ShowVisualToolSettings();
        }

        /// <summary>
        /// Shows the decoding settings of current image.
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
                        imageViewer1.ReloadImage();
                }
            }
        }


        /// <summary>
        /// Edits the color management settings.
        /// </summary>
        private void colorManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorManagementSettingsForm.EditColorManagement(imageViewer1);
        }

        /// <summary>
        /// Shows a dialog that allows to change the count of maximum thread, which can be used for image rendering.
        /// </summary>
        private void maxThreadsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (MaxThreadsForm dlg = new MaxThreadsForm())
            {
                dlg.MaxThreads = ImagingEnvironment.MaxThreads;
                if (dlg.ShowDialog() == DialogResult.OK)
                    ImagingEnvironment.MaxThreads = dlg.MaxThreads;
            }
        }


        #endregion


        #region 'Image processing' menu

        #region Base

        #region Change pixel format

        /// <summary>
        /// Changes pixel format of image to BlackWhite, threshold value is specified by user.
        /// </summary>
        private void changePixelFormatToBlackWhiteThresholdModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imageViewer1.Image.PixelFormat != PixelFormat.BlackWhite)
            {
                using (BinarizeForm dlg = new BinarizeForm(imageViewer1, true))
                {
                    if (dlg.ShowProcessingDialog())
                        _imageProcessingCommandExecutor.ExecuteProcessingCommand(dlg.GetProcessingCommand());
                }
            }
        }

        /// <summary>
        /// Change pixel format of image to BlackWhite, global threshold is detected automatically.
        /// </summary>
        private void changePixelFormatToBlackWhiteGlobalModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteProcessingCommand(new ChangePixelFormatToBlackWhiteCommand(BinarizationMode.Global));
        }

        /// <summary>
        /// Changes pixel format of image to BlackWhite, adaptive threshold is detected automatically.
        /// </summary>
        private void changePixelFormatToBlackWhiteAdaptiveModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imageViewer1.Image.PixelFormat != PixelFormat.BlackWhite)
            {
                using (AdaptiveBinarizeForm dlg = new AdaptiveBinarizeForm(imageViewer1, true))
                    if (dlg.ShowProcessingDialog())
                        _imageProcessingCommandExecutor.ExecuteProcessingCommand(dlg.GetProcessingCommand());
            }
        }

        /// <summary>
        /// Changes pixel format of image to BlackWhite using Halftone binarization.
        /// </summary>
        private void halftoneToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteProcessingCommand(new ChangePixelFormatToBlackWhiteCommand(BinarizationMode.Halftone));
        }

        /// <summary>
        /// Changes pixel format of image to Palette1.
        /// </summary>
        private void changePixelFormatToPalette1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteProcessingCommand(new ChangePixelFormatCommand(Vintasoft.Imaging.PixelFormat.Indexed1));
        }

        /// <summary>
        /// Changes pixel format of image to Gray8.
        /// </summary>
        private void changePixelFormatToGray8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteProcessingCommand(new ChangePixelFormatCommand(PixelFormat.Gray8));
        }

        /// <summary>
        /// Changes pixel format of image to Indexed8.
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
                    _imageProcessingCommandExecutor.ExecuteProcessingCommand(command);
            }
        }

        /// <summary>
        /// Changes pixel format of image to Bgr24.
        /// </summary>
        private void changePixelFormatToBgr24ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteProcessingCommand(new ChangePixelFormatCommand(Vintasoft.Imaging.PixelFormat.Bgr24));
        }

        /// <summary>
        /// Changes pixel format of image to Bgra32.
        /// </summary>
        private void convertToBgra32ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteProcessingCommand(new ChangePixelFormatCommand(Vintasoft.Imaging.PixelFormat.Bgra32));
        }

        /// <summary>
        /// Changes pixel format of image to the custom format.
        /// </summary>
        private void changePixelFormatToCustomFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ChangePixelFormatForm dlg = new ChangePixelFormatForm())
            {
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    _imageProcessingCommandExecutor.ExecuteProcessingCommand(new ChangePixelFormatCommand(dlg.PixelFormat));
            }
        }

        #endregion


        /// <summary>
        /// Crops an image.
        /// </summary>
        private void cropToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imageViewer1.VisualTool is RectangularSelectionToolWithCopyPaste ||
                imageViewer1.VisualTool is CustomSelectionTool)
            {
                try
                {
                    _imageProcessingCommandExecutor.ExecuteProcessingCommand(new CropCommand());
                }
                catch (ImageProcessingException ex)
                {
                    MessageBox.Show(ex.Message, "Image processing exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        /// <summary>
        /// Resizes an image.
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
        /// Adds canvas and resizes an image.
        /// </summary>
        private void resizeCanvasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VintasoftImage image = imageViewer1.Image;
            using (ResizeCanvasForm dlg = new ResizeCanvasForm(image.Width, image.Height))
            {
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ResizeCanvasCommand command = ImageProcessingCommandFactory.CreateCommand<ResizeCanvasCommand>(image);
                    command.Width = dlg.CanvasWidth;
                    command.Height = dlg.CanvasHeight;
                    command.ImagePosition = dlg.ImagePosition;
                    command.CanvasColor = dlg.CanvasColor;
                    _imageProcessingCommandExecutor.ExecuteProcessingCommand(command);
                }
            }
        }

        /// <summary>
        /// Resamples an image.
        /// </summary>
        private void resampleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VintasoftImage image = imageViewer1.Image;
            ResampleCommand command = new ResampleCommand();
            using (ResampleForm dlg = new ResampleForm((float)image.Resolution.Horizontal, (float)image.Resolution.Vertical, command.InterpolationMode, "Resample", true))
            {
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    command.HorizontalResolution = dlg.HorizontalResolution;
                    command.VerticalResolution = dlg.VerticalResolution;
                    command.InterpolationMode = dlg.InterpolationMode;
                    _imageProcessingCommandExecutor.ExecuteProcessingCommand(command);
                }
            }
        }

        /// <summary>
        /// Changes resolution of image.
        /// </summary>
        private void changeResolutionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VintasoftImage image = imageViewer1.Image;
            using (ResampleForm dlg = new ResampleForm((float)image.Resolution.Horizontal,
                (float)image.Resolution.Vertical,
                InterpolationMode.HighQualityBicubic,
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
        /// Fills an image.
        /// </summary>
        private void fillImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(new FillImageForm(imageViewer1));
        }

        /// <summary>
        /// Fills rectangle on an image.
        /// </summary>
        private void fillRectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteFillRectangleCommand();
        }

        /// <summary>
        /// Overlays an image.
        /// </summary>
        private void overlayImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteOverlayCommand();
        }

        /// <summary>
        /// Overlays binary image.
        /// </summary>
        private void overlayBinaryImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteOverlayBinaryCommand();
        }

        /// <summary>
        /// Draws an image.
        /// </summary>
        private void drawImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteDrawImageCommand();
        }

        /// <summary>
        /// Overlays with color blending.
        /// </summary>
        private void overlayWithBlendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteOverlayWithBlendingCommand();
        }

        /// <summary>
        /// Overlays with alpha mask.
        /// </summary>
        private void overlayWithMaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteOverlayMaskedCommand();
        }

        /// <summary>
        /// Compares two images.
        /// </summary>
        private void imageCompareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteComparisonCommand();
        }

        #endregion


        #region Info

        /// <summary>
        /// Shows histogram of image.
        /// </summary>
        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Rectangle selectionRectangle = Rectangle.Empty;

                if (imageViewer1.VisualTool is RectangularSelectionToolWithCopyPaste)
                {
                    RectangularSelectionToolWithCopyPaste selection = imageViewer1.VisualTool as RectangularSelectionToolWithCopyPaste;
                    if (selection != null)
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
        /// Determines that image is black-white.
        /// </summary>
        private void isImageBlackWhiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteIsImageBlackWhiteCommand();
        }

        /// <summary>
        /// Determines that image is grayscale.
        /// </summary>
        private void isImageGrayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteIsImageGrayscaleCommand();
        }

        /// <summary>
        /// Gets the number of colors in image.
        /// </summary>
        private void getColorCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteColorCountCommand();
        }

        /// <summary>
        /// Gets the real color depth of image.
        /// </summary>
        private void getImageColorDepthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteGetImageColorDepthCommand();
        }

        /// <summary>
        /// Gets a border color of image.
        /// </summary>
        private void getBorderColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteGetBorderColorCommand();
        }

        /// <summary>
        /// Gets a backgorund color of image.
        /// </summary>
        private void getBackgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteGetBackgroundColorCommand();
        }


        /// <summary>
        /// Gets the optimal binarization threshold of image.
        /// </summary>
        private void detectThresholdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteGetThresholdCommand();
        }

        /// <summary>
        /// Determines that image is blank.
        /// </summary>
        private void isImageBlankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteIsBlankCommand();
        }

        /// <summary>
        /// Determines that image contains certain color.
        /// </summary>
        private void hasCertainColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteHasCertainColorCommand();
        }

        #endregion


        #region Channels

        /// <summary>
        /// Extracts the alpha channel of image.
        /// </summary>
        private void extractAlphaChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteProcessingCommand(new GetAlphaChannelMaskCommand());
        }


        /// <summary>
        /// Inverts the red channel of image.
        /// </summary>
        private void invertRedChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvertColorChannel(Color.FromArgb(255, 0, 0));
        }

        /// <summary>
        /// Inverts the green channel of image.
        /// </summary>
        private void invertGreenChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvertColorChannel(Color.FromArgb(0, 255, 0));
        }

        /// <summary>
        /// Inverts the blue channel of image.
        /// </summary>
        private void invertBlueChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvertColorChannel(Color.FromArgb(0, 0, 255));
        }


        /// <summary>
        /// Sets a value of alpha channel for all pixels of image to the specified value.
        /// </summary>
        private void setAlphaChannelValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteSetAlphaChannelValueCommand();
        }

        /// <summary>
        /// Changes the alpha channel of image from the specified image-mask.
        /// </summary>
        private void setAlphaChannelFromMaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteSetAlphaChannelCommand();
        }


        /// <summary>
        /// Remove the red channel of image.
        /// </summary>
        private void removeRedChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExtractColorChannels(0, 255, 255);
        }

        /// <summary>
        /// Remove the green channel of image.
        /// </summary>
        private void removeGreenChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExtractColorChannels(255, 0, 255);
        }

        /// <summary>
        /// Remove the blue channel of image.
        /// </summary>
        private void removeBlueChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExtractColorChannels(255, 255, 0);
        }

        #endregion


        #region Color

        /// <summary>
        /// Converts an image to black-white image, threshold value is specified by user.
        /// </summary>
        private void convertToBlackWhiteThresholdByUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imageViewer1.Image.PixelFormat != PixelFormat.BlackWhite)
                ShowAndDisposeProcessingDialog(new BinarizeForm(imageViewer1, false));
        }

        /// <summary>
        /// Converts an image to black-white image, global threshold is detected automatically.
        /// </summary>
        private void convertToBlackWhiteGlobalThresholdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteProcessingCommand(new BinarizeCommand(BinarizationMode.Global));
        }

        /// <summary>
        /// Converts an image to black-white image, adaptive threshold is detected automatically.
        /// </summary>
        private void convertToBlackWhiteAdaptiveThresholdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imageViewer1.Image.PixelFormat != PixelFormat.BlackWhite)
                ShowAndDisposeProcessingDialog(new AdaptiveBinarizeForm(imageViewer1, false));
        }

        /// <summary>
        /// Desaturates an image.
        /// </summary>
        private void desaturateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DesaturateCommand command = ImageProcessingCommandFactory.CreateDesaturateCommand(imageViewer1.Image);
            command.DesaturateMethod = DesaturateMethod.Luminosity;
            _imageProcessingCommandExecutor.ExecuteProcessingCommand(command);
        }

        /// <summary>
        /// Converts an image to a halftone image.
        /// </summary>
        private void convertToHalftoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteProcessingCommand(new HalftoneCommand());
        }

        /// <summary>
        /// Posterizes an image.
        /// </summary>
        private void posterizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imageViewer1.Image.PixelFormat != PixelFormat.BlackWhite)
                ShowAndDisposeProcessingDialog(new PosterizeForm(imageViewer1));
        }

        /// <summary>
        /// Changes the brightness and/or contrast of image.
        /// </summary>
        private void brightnessContrastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(new BrightnessContrastForm(imageViewer1, imageViewer1.Image), true);
        }

        /// <summary>
        /// Changes HSL of image.
        /// </summary>
        private void hueSaturationLuminanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(new HueSaturationLuminanceForm(imageViewer1));
        }

        /// <summary>
        /// Changes gamma of image.
        /// </summary>
        private void gammaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(new GammaForm(imageViewer1), true);
        }

        /// <summary>
        /// Changes levels of image.
        /// </summary>
        private void levelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(new LevelsForm(imageViewer1), true);
        }

        /// <summary>
        /// Inverts an image.
        /// </summary>
        private void invertColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteProcessingCommand(ImageProcessingCommandFactory.CreateInvertCommand(imageViewer1.Image));
        }


        /// <summary>
        /// Replaces a color in image.
        /// </summary>
        private void replaceColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(new ReplaceColorForm(imageViewer1), true);
        }

        /// <summary>
        /// Blends colors of image.
        /// </summary>
        private void colorBlendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteColorBlendCommand();
        }

        /// <summary>
        /// Applies a color transform to an image.
        /// </summary>
        private void colorTransformToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(new ColorTransformForm(imageViewer1));
        }

        #endregion


        #region Transforms

        /// <summary>
        /// Flips an image.
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
        /// Rotates an image.
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
        /// Scales an image.
        /// </summary>
        private void scaleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ImageScalingForm form = new ImageScalingForm();
            form.Command = ImageProcessingCommandFactory.CreateCommand<ImageScalingCommand>(imageViewer1.Image);
            ShowAndDisposeProcessingDialog(form, false, false);
        }

        /// <summary>
        /// Skews an image.
        /// </summary>
        private void skewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(
                new PropertyGridConfigForm(imageViewer1, new SkewCommand()), false, false);
        }

        /// <summary>
        /// Applies quadrilateral warp transformation to an image.
        /// </summary>
        private void quadrilateralWarpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(
                new PropertyGridConfigForm(imageViewer1, new QuadrilateralWarpCommand()), false, false);
        }

        /// <summary>
        /// Applies matrix transformation to an image.
        /// </summary>
        private void matrixTransformToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(
                new PropertyGridConfigForm(imageViewer1, new MatrixTransformCommand()), false, false);
        }

        #endregion


        #region Filters

        #region Arithmetic filters

        /// <summary>
        /// Applies an arithmetic minimum filter to an image.
        /// </summary>
        private void minimumFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(new MinimumForm(imageViewer1));
        }

        /// <summary>
        /// Applies an arithmetic maximum filter to an image.
        /// </summary>
        private void maximumFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(new MaximumForm(imageViewer1));
        }

        /// <summary>
        /// Applies an arithmetic midpoint filter to an image.
        /// </summary>
        private void midPointFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(new MidpointForm(imageViewer1));
        }

        /// <summary>
        /// Applies an arithmetic mean filter to an image.
        /// </summary>
        private void meanFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(new MeanForm(imageViewer1));
        }

        /// <summary>
        /// Applies an arithmetic median filter to an image.
        /// </summary>
        private void medianFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(new MedianForm(imageViewer1));
        }

        #endregion


        #region Morphological filters

        /// <summary>
        /// Applies the morphological dilate filter to an image.
        /// </summary>
        private void dilateFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(new DilateForm(imageViewer1));
        }

        /// <summary>
        /// Applies the morphological erode filter to an image.
        /// </summary>
        private void erodeFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(new ErodeForm(imageViewer1));
        }

        #endregion


        /// <summary>
        /// Applies the Blur filter to an image.
        /// </summary>
        private void blurFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(new BlurForm(imageViewer1));
        }

        /// <summary>
        /// Applies the Gaussian blur filter to an image.
        /// </summary>
        private void gaussianBlurFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(new GaussianBlurForm(imageViewer1));
        }

        /// <summary>
        /// Applies the Sharpen filter to an image.
        /// </summary>
        private void sharpenFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(new SharpenForm(imageViewer1));
        }

        /// <summary>
        /// Applies the Edge Detection filter to an image.
        /// </summary>
        private void edgeDetectionFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteProcessingCommand(new EdgeDetectionCommand());
        }

        /// <summary>
        /// Applies the Emboss filter to an image.
        /// </summary>
        private void embossFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(new EmbossForm(imageViewer1));
        }

        /// <summary>
        /// Applies the Add noise filter to an image.
        /// </summary>
        private void addNoiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(
                new PropertyGridConfigForm(imageViewer1, new AddNoiseCommand()), false, false);
        }

        /// <summary>
        /// Applies the Canny edge detector filter to an image.
        /// </summary>
        private void cannyEdgeDetectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(new CannyEdgeDetectorForm(imageViewer1));
        }

        #endregion


        #region Document Cleanup

        /// <summary>
        /// Determines that image is document image.
        /// </summary>
        private void isDocumentImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteIsDocumentImageCommand();
        }

        /// <summary>
        /// Gets the rotation angle of document image.
        /// </summary>
        private void getDocumentImageRotationAngleToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if !REMOVE_DOCCLEANUP_PLUGIN
            _imageProcessingCommandExecutor.ExecuteGetDocumentImageRotationAngleCommand();
#endif
        }

        /// <summary>
        /// Gets the rotation angle of image.
        /// </summary>
        private void rotationAngleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteGetRotationAngleCommand();
        }

        /// <summary>
        /// Determines orientation of the text.
        /// </summary>
        private void getTextOrientationToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if !REMOVE_DOCCLEANUP_PLUGIN
            _imageProcessingCommandExecutor.ExecuteGetTextOrientationCommand();
#endif
        }

        /// <summary>
        /// Removes noise in a document image.
        /// </summary>
        private void despeckleToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if !REMOVE_DOCCLEANUP_PLUGIN
            ShowAndDisposeProcessingDialog(new PropertyGridConfigForm(imageViewer1, new DespeckleCommand()));
#endif
        }

        /// <summary>
        /// Automatically corrects the orientation of document image.
        /// </summary>
        private void deskewDocumentImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if !REMOVE_DOCCLEANUP_PLUGIN
            ShowAndDisposeProcessingDialog(
                new PropertyGridConfigForm(imageViewer1, new DeskewDocumentImageCommand()), true, false);
#endif
        }

        /// <summary>
        /// Automatically detects correct position of document image.
        /// </summary>
        private void deskewToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if !REMOVE_DOCCLEANUP_PLUGIN
            ShowAndDisposeProcessingDialog(
                new PropertyGridConfigForm(imageViewer1, new DeskewCommand()), true, false);
#endif
        }

        /// <summary>
        /// Automatically detects and corrects orientation of document image.
        /// </summary>
        private void autoOrientationToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if !REMOVE_DOCCLEANUP_PLUGIN
            ShowAndDisposeProcessingDialog(
                new PropertyGridConfigForm(imageViewer1, new AutoTextOrientationCommand()), true, false);
#endif
        }

        /// <summary>
        /// Inverts text blocks in a document image.
        /// </summary>
        private void textBlockInvertToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if !REMOVE_DOCCLEANUP_PLUGIN
            ShowAndDisposeProcessingDialog(new AutoTextInvertForm(imageViewer1), false, false);
#endif
        }

        /// <summary>
        /// Automatically inverts a document image.
        /// </summary>
        private void automaticInvertToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if !REMOVE_DOCCLEANUP_PLUGIN
            _imageProcessingCommandExecutor.ExecuteProcessingCommand(new AutoInvertCommand());
#endif
        }

        /// <summary>
        /// Clears the border of document image.
        /// </summary>
        private void borderClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if !REMOVE_DOCCLEANUP_PLUGIN
            _imageProcessingCommandExecutor.ExecuteProcessingCommand(new BorderClearCommand());
#endif
        }

        /// <summary>
        /// Removes (crops) border of a document image.
        /// </summary>
        private void detectBorderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(new BorderRemovalForm(imageViewer1));
        }

        /// <summary>
        /// Removes halftone in a document image.
        /// </summary>
        private void halftoneRemovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if !REMOVE_DOCCLEANUP_PLUGIN
            ShowAndDisposeProcessingDialog(new HalftoneRemovalForm(imageViewer1));
#endif
        }

        /// <summary>
        /// Smoothes a document image.
        /// </summary>
        private void smoothingToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if !REMOVE_DOCCLEANUP_PLUGIN
            ShowAndDisposeProcessingDialog(new SmoothingForm(imageViewer1));
#endif
        }


        /// <summary>
        /// Removes hole punches in a document image.
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
        /// Removes lines in a document image.
        /// </summary>
        private void lineRemovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if !REMOVE_DOCCLEANUP_PLUGIN
            ShowAndDisposeProcessingDialog(
                new PropertyGridConfigForm(imageViewer1, new LineRemovalCommand()), false, false);
#endif
        }

        /// <summary>
        /// Removes a color noise in a document image.
        /// </summary>
        private void colorNoiseClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if !REMOVE_DOCCLEANUP_PLUGIN
            ShowAndDisposeProcessingDialog(new ColorNoiseClearForm(imageViewer1));
#endif
        }

        /// <summary>
        /// Replaces colors in a document image.
        /// </summary>
        private void advancedReplaceColorCommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteAdvancedReplaceColorCommand();
        }

        #endregion


        #region Photo Effects

        /// <summary>
        /// Applies the Auto Levels effect to an image.
        /// </summary>
        private void autoLevelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteProcessingCommand(new AutoLevelsCommand());
        }

        /// <summary>
        /// Applies the Auto Colors effect to an image.
        /// </summary>
        private void autoColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteProcessingCommand(new AutoColorsCommand());
        }

        /// <summary>
        /// Applies the Auto Contrast effect to an image.
        /// </summary>
        private void autoContrastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteProcessingCommand(new AutoContrastCommand());
        }


        /// <summary>
        /// Applies the Bevel Edge effect to an image.
        /// </summary>
        private void bevelEdgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(new BevelEdgeForm(imageViewer1));
        }

        /// <summary>
        /// Applies the Drop Shadow effect to an image.
        /// </summary>
        private void dropShadowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(
                new PropertyGridConfigForm(imageViewer1, new DropShadowCommand()), false, false);
        }

        /// <summary>
        /// Applies the Motion Blur effect to an image.
        /// </summary>
        private void motionBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(new MotionBlurForm(imageViewer1));
        }

        /// <summary>
        /// Applies the Mozaic effect to an image.
        /// </summary>
        private void mozaicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(new MosaicForm(imageViewer1));
        }

        /// <summary>
        /// Applies the Oil Painting effect to an image.
        /// </summary>
        private void oilPaintingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(new OilPaintingForm(imageViewer1));
        }

        /// <summary>
        /// Applies the Pixelate effect to an image.
        /// </summary>
        private void pixelateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(new PixelateForm(imageViewer1));
        }

        /// <summary>
        /// Applies the Red Eye Removal effect to an image.
        /// </summary>
        private void redEyeRemovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(new RedEyeRemovalForm(imageViewer1));
        }

        /// <summary>
        /// Applies the Sepia effect to an image.
        /// </summary>
        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteProcessingCommand(new SepiaCommand());
        }

        /// <summary>
        /// Applies the Solarize effect to an image.
        /// </summary>
        private void solarizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageProcessingCommandExecutor.ExecuteProcessingCommand(new SolarizeCommand());
        }

        /// <summary>
        /// Applies the Tile Reflection effect to an image.
        /// </summary>
        private void tileReflectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(new TileReflectionForm(imageViewer1), false, false);
        }

        #endregion


        #region FFT

        #region Filtering

        /// <summary>
        /// Applies Ideal lowpass filter to an image.
        /// </summary>
        private void idealLowpassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PropertyGridConfigForm dlg = new PropertyGridConfigForm(imageViewer1, new IdealLowpassCommand());
            dlg.IsPreviewAvailable = true;
            ShowAndDisposeProcessingDialog(dlg, true, false);
        }

        /// <summary>
        /// Applies Butterworth lowpass filter to an image.
        /// </summary>
        private void butterworthLowpassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PropertyGridConfigForm dlg = new PropertyGridConfigForm(imageViewer1, new ButterworthLowpassCommand());
            dlg.IsPreviewAvailable = true;
            ShowAndDisposeProcessingDialog(dlg, true, false);
        }

        /// <summary>
        /// Applies Gaussian lowpass filter to an image.
        /// </summary>
        private void gaussianLowpassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PropertyGridConfigForm dlg = new PropertyGridConfigForm(imageViewer1, new GaussianLowpassCommand());
            dlg.IsPreviewAvailable = true;
            ShowAndDisposeProcessingDialog(dlg, true, false);
        }

        /// <summary>
        /// Applies Ideal highpass filter to an image.
        /// </summary>
        private void idealHighPassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PropertyGridConfigForm dlg = new PropertyGridConfigForm(imageViewer1, new IdealHighpassCommand());
            dlg.IsPreviewAvailable = true;
            ShowAndDisposeProcessingDialog(dlg, true, false);
        }

        /// <summary>
        /// Applies Butterworth highpass filter to an image.
        /// </summary>
        private void butterworthHighPassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PropertyGridConfigForm dlg = new PropertyGridConfigForm(imageViewer1, new ButterworthHighpassCommand());
            dlg.IsPreviewAvailable = true;
            ShowAndDisposeProcessingDialog(dlg, true, false);
        }

        /// <summary>
        /// Applies Gaussian highpass filter to an image.
        /// </summary>
        private void gaussianHighpassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PropertyGridConfigForm dlg = new PropertyGridConfigForm(imageViewer1, new GaussianHighpassCommand());
            dlg.IsPreviewAvailable = true;
            ShowAndDisposeProcessingDialog(dlg, true, false);
        }

        #endregion


        /// <summary>
        /// Applies image smoothing filter to an image.
        /// </summary>
        private void imageSmoothingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(new ImageSmoothingForm(imageViewer1));
        }

        /// <summary>
        /// Applies image sharpening filter to an image.
        /// </summary>
        private void imageSharpeningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(new ImageSharpeningForm(imageViewer1));
        }

        /// <summary>
        /// Visualizes image frequency spectrum.
        /// </summary>
        private void frequencySpectumVisualizerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndDisposeProcessingDialog(
                new FrequencySpectrumVisualizerForm(imageViewer1), false, false);
        }

        #endregion


        /// <summary>
        /// Enables/disables the image processing in multiple threads.
        /// </summary>
        private void useMultithreadingToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (_imageProcessingCommandExecutor != null)
                _imageProcessingCommandExecutor.ExecuteMultithread = useMultithreadingToolStripMenuItem.Checked;
        }

        /// <summary>
        /// Enables/disables the expanding of image pixel format during image processing.
        /// </summary>
        private void expandPixelFormatToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (_imageProcessingCommandExecutor != null)
                _imageProcessingCommandExecutor.ExpandSupportedPixelFormats = expandPixelFormatToolStripMenuItem.Checked;
        }

        /// <summary>
        /// Loads clipping paths from metadata of current image.
        /// </summary>
        private void loadPathsFromMetadataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.imageViewer1.Image != null)
            {
                MetadataNode metadata = this.imageViewer1.Image.Metadata.MetadataTree;

                PhotoshopResourcesMetadata photoshopMetadata = metadata.FindChildNode<PhotoshopResourcesMetadata>();

                bool pathsAreLoaded = false;
                if (photoshopMetadata != null)
                {
                    int width = this.imageViewer1.Image.Width;
                    int height = this.imageViewer1.Image.Height;

                    GraphicsPath paths = new GraphicsPath();
                    foreach (PhotoshopResource resource in photoshopMetadata.Resources)
                    {
                        if (resource is PhotoshopImagePathResource)
                        {
                            GraphicsPath path = ((PhotoshopImagePathResource)resource).GetPath(width, height);
                            if (path.PointCount > 0)
                                paths.AddPath(path, false);
                        }
                    }

                    if (paths.PointCount > 0)
                    {
                        PathSelectionRegion selection = new PathSelectionRegion(paths);
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
        /// Shows a form with images animation.
        /// </summary>
        private void animationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ShowAnimationForm dlg = new ShowAnimationForm(imageViewer1.Images))
            {
                dlg.ShowDialog();
            }
        }

        #endregion


        #region 'Help' menu

        /// <summary>
        /// Shows the "About" dialog.
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
        /// Mouse up in image viewer.
        /// </summary>
        private void imageViewer1_MouseUp(object sender, MouseEventArgs e)
        {
            // if clicked right button then
            if (e.Button == MouseButtons.Right && imageViewer1.Image != null)
            {
                CustomSelectionTool customSelectionTool = GetCustomSelectionTool(imageViewer1.VisualTool);
                // if current tool has CustomSelectionTool
                // and selection tool has selection
                if (customSelectionTool != null && customSelectionTool.Selection != null)
                {
                    // if selection tool has selection then
                    if (customSelectionTool.Selection != null)
                    {
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
                }
                else
                {
                    RectangularSelectionTool rectangularSelectionTool = GetRectangularSelectionTool(imageViewer1.VisualTool);
                    // if current tool has RectangularSelectionTool
                    // and selection tool has selection
                    if (rectangularSelectionTool != null && rectangularSelectionTool.Rectangle != RectangleF.Empty)
                    {
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
        /// Context menu of CustomSelectionTool is opening.
        /// </summary>
        private void selectionContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // clear context menu
            customSelectionToolContextMenuStrip.Items.Clear();

            CustomSelectionTool customSelectionTool = GetCustomSelectionTool(imageViewer1.VisualTool);
            RectangularSelectionTool rectangularSelectionTool = GetRectangularSelectionTool(imageViewer1.VisualTool);

            // if current tool has CustomSelectionTool or RectangularSelectionTool then
            if (customSelectionTool != null || rectangularSelectionTool != null)
            {
                // builds the selection context menu
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
                        // foreach available transform interactions of current selection
                        foreach (string name in customSelectionTool.Selection.AvailableTransformInteractionControllers.Keys)
                            // add transform interaction controller to context menu
                            AddItemToSelectionContextMenu(name, transformersItem.DropDownItems, customSelectionTool.Selection.AvailableTransformInteractionControllers[name]);

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
        /// Returns a <see cref="CustomSelectionTool"/> from composite visual tool.
        /// </summary>
        /// <param name="visualTool">A visual tool.</param>
        /// <returns>
        /// The <see cref="CustomSelectionTool"/>.
        /// </returns>
        private CustomSelectionTool GetCustomSelectionTool(VisualTool visualTool)
        {
            // if image viewer visual tool is custom selection tool
            if (visualTool is CustomSelectionTool)
                return (CustomSelectionTool)visualTool;

            // if image viewer visual tool is composite tool
            if (visualTool is CompositeVisualTool)
            {
                // get composite tool
                CompositeVisualTool compositeTool = (CompositeVisualTool)visualTool;
                // for each visual tool
                foreach (VisualTool tool in compositeTool)
                {
                    VisualTool selectionTool = GetCustomSelectionTool(tool);
                    if (selectionTool != null)
                        return (CustomSelectionTool)selectionTool;
                }
            }

            return null;
        }

        /// <summary>
        /// Returns a <see cref="RectangularSelectionToolWithCopyPaste"/> from composite visual tool.
        /// </summary>
        /// <param name="visualTool">A visual tool.</param>
        /// <returns>
        /// The <see cref="RectangularSelectionToolWithCopyPaste"/>.
        /// </returns>
        private RectangularSelectionToolWithCopyPaste GetRectangularSelectionTool(VisualTool visualTool)
        {
            // if image viewer visual tool is custom selection tool
            if (visualTool is RectangularSelectionToolWithCopyPaste)
                return (RectangularSelectionToolWithCopyPaste)visualTool;

            // if image viewer visual tool is composite tool
            if (visualTool is CompositeVisualTool)
            {
                // get composite tool
                CompositeVisualTool compositeTool = (CompositeVisualTool)visualTool;
                // for each visual tool
                foreach (VisualTool tool in compositeTool)
                {
                    VisualTool selectionTool = GetRectangularSelectionTool(tool);
                    if (selectionTool != null)
                        return (RectangularSelectionToolWithCopyPaste)selectionTool;
                }
            }

            return null;
        }

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
            item.Click += new EventHandler(selectionContextMenuStrip_changeInteractionController);
            items.Add(item);
        }

        /// <summary>
        /// Changes a current interaction controller of selection area.
        /// </summary>
        private void selectionContextMenuStrip_changeInteractionController(object sender, EventArgs e)
        {
            // if current tool is CustomSelectionTool then
            if (imageViewer1.VisualTool is CustomSelectionTool)
            {
                CustomSelectionTool selectionTool = (CustomSelectionTool)imageViewer1.VisualTool;
                // if selection tool has selection then
                if (selectionTool.Selection != null)
                {
                    // gets an interaction controller of this context menu item
                    IInteractionController interactionController = ((IInteractionController)((ToolStripMenuItem)sender).Tag);
                    // if interaction controller is BuildingInteractionController then
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
        }

        /// <summary>
        /// Event handler for "Remove selected points" item from the context menu of CustomSelectionTool.
        /// </summary>
        private void removeSelectedPoints_Click(object sender, EventArgs e)
        {
            CustomSelectionTool selectionTool = (CustomSelectionTool)imageViewer1.VisualTool;
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

        /// <summary>
        /// Event handler for "Add point" item from the context menu of CustomSelectionTool.
        /// </summary>
        private void addPoint_Click(object sender, EventArgs e)
        {
            CustomSelectionTool selectionTool = (CustomSelectionTool)imageViewer1.VisualTool;
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

        #endregion


        #region Image viewer

        /// <summary>
        /// Image is loading in image viewer.
        /// </summary>
        private void imageViewer1_ImageLoading(object sender, ImageLoadingEventArgs e)
        {
            _imageLoadingStartTime = DateTime.Now;
            _imageLoadingTime = TimeSpan.Zero;

            imageLoadingStatusLabel.Visible = true;
            imageLoadingProgressBar.Visible = true;
        }

        /// <summary>
        /// Loading of image in image viewer is in progress.
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
        /// Image is loaded in image viewer.
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

            if (editImagePixelsToolStripMenuItem.Checked && !imageViewer1.IsEntireImageLoaded)
                editImagePixelsToolStripMenuItem.Checked = false;
        }

        /// <summary>
        /// Image is not loaded because of error.
        /// </summary>
        private void imageViewer1_ImageLoadingException(object sender, ExceptionEventArgs e)
        {
            imageLoadingStatusLabel.Visible = false;
            imageLoadingProgressBar.Visible = false;
        }


        /// <summary>
        /// Image is changed in image viewer.
        /// </summary>
        private void imageViewer1_ImageChanged(object sender, ImageChangedEventArgs e)
        {
            this.IsImageLoaded = true;
        }

        /// <summary>
        /// Image is reloaded in image viewer.
        /// </summary>
        private void imageViewer1_ImageReloaded(object sender, ImageReloadEventArgs e)
        {
            this.IsImageLoaded = true;
        }


        /// <summary>
        /// Index of focused image in viewer is changing.
        /// </summary>
        private void imageViewer1_FocusedIndexChanging(object sender, FocusedIndexChangedEventArgs e)
        {
            if (_isFormClosing)
                return;
        }

        /// <summary>
        /// Index of focused image in viewer is changed.
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
        /// Insert key is pressed in image viewer.
        /// </summary>
        private void imageViewer1_InsertKeyPressed(object sender, KeyEventArgs e)
        {
            InsertKeyPressed();
        }

        /// <summary>
        /// Visual tool of image viewer is changed.
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
        /// Determines that visual tool is a child tool of the <see cref="CompositeVisualTool"/>.
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

        /// <summary>
        /// Zoom is changed in image viewer.
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

        #endregion


        #region Thumbnail viewer

        /// <summary>
        /// Loading of thumbnails is in progress.
        /// </summary>
        private void thumbnailViewer1_ThumbnailsLoadingProgress(object sender, ThumbnailsLoadingProgressEventArgs e)
        {
            bool isProgressVisible = e.Progress != 100;
            loadingThumbnailsProgressBar.Value = e.Progress;
            addingThumbnailsStatusLabel.Visible = isProgressVisible;
            loadingThumbnailsProgressBar.Visible = isProgressVisible;
        }


        /// <summary>
        /// Insert key is pressed in thumbnail viewer.
        /// </summary>
        private void thumbnailViewer1_InsertKeyPressed(object sender, KeyEventArgs e)
        {
            InsertKeyPressed();
        }

        /// <summary>
        /// Sets the ToolTip of hovered thumbnail.
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
                            // get image file name
                            filename = Path.GetFileName(((FileStream)imageSourceInfo.Stream).Name);
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


        #region File manipulation

        /// <summary>
        /// Opens a stream of the image file and
        /// adds stream of image file to the image collection of image viewer - this allows
        /// to save modified multipage image files back to the source.
        /// </summary>
        private void OpenFile(string filename)
        {
            //
            _sourceFilename = Path.GetFullPath(filename);

            Stream sourceStream = null;
            // try to open file in read-write mode
            try
            {
                sourceStream = new FileStream(_sourceFilename, FileMode.Open, FileAccess.ReadWrite);
            }
            catch (IOException)
            {
            }
            catch (UnauthorizedAccessException)
            {
            }

            if (sourceStream == null)
            {
                // open file in read-only mode
                _sourceStreamIsReadOnly = true;
            }
            else
            {
                _sourceStreamIsReadOnly = false;
                sourceStream.Close();
                sourceStream.Dispose();
            }

            IsImageOpening = true;
            //
            imageViewer1.Images.Add(_sourceFilename, _sourceStreamIsReadOnly);
            _sourceDecoderName = imageViewer1.Images[0].SourceInfo.DecoderName;
            _areImagesChanged = false;

            IsImageOpening = false;

            imageViewer1.Focus();
        }

        /// <summary>
        /// Closes a file marked as a source for image collection in image viewer.
        /// </summary>
        private void CloseFile()
        {
            _sourceFilename = null;
            _sourceDecoderName = null;
        }

        /// <summary>
        /// Waits while image saving and/or processing will be finished.
        /// </summary>
        private void WaitWhileSavingAndProcessingIsFinished()
        {
            // if image collection is saving at the moment
            if (this.IsImageSaving)
            {
                // send signal that saving must be canceled
                _cancelImageSaving = true;
                // wait while saving is canceled/finished
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

        #endregion


        #region Image collection

        /// <summary>
        /// Image collection of image viewer is changed.
        /// </summary>
        private void Images_CollectionChanged(object sender, ImageCollectionChangeEventArgs e)
        {
            if (imageViewer1.Images.Count == 0)
                _isImageLoaded = false;

            if (!IsImageOpening)
                _areImagesChanged = true;

            // update the UI
            UpdateUI();
        }

        #endregion


        #region Image info

        /// <summary>
        /// Updates information about focused image.
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

                // show information about the current image
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


        #region Print image(s)

        /// <summary>
        /// Shows a page settings dialog.
        /// </summary>
        private void pageSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.ShowDialog();
        }

        /// <summary>
        /// Prints the image(s).
        /// </summary>
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _thumbnailViewerPrintManager.Print();
        }

        #endregion


        #region Save image(s)

        /// <summary>
        /// Saves a single image.
        /// </summary>
        private bool SaveSingleImage(
            VintasoftImage image,
            string filename,
            EncoderBase encoder)
        {
            bool result = true;

            //
            this.IsImageSaving = true;

            // save image to file and do not switch source
            encoder.SaveAndSwitchSource = false;

            try
            {
                // save image synchronously
                image.Save(filename, encoder, Images_ImageSavingProgress);
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
        private bool SaveImageCollection(
            ImageCollection images,
            string filename,
            EncoderBase encoder,
            bool saveAndSwitchSource)
        {
            filename = Path.GetFullPath(filename);

            bool result = true;

            //
            this.IsImageSaving = true;

            //
            RenderingSettingsForm.SetRenderingSettingsIfNeed(images, encoder, imageViewer1.ImageRenderingSettings);

            // subscribe to the events
            images.ImageCollectionSavingProgress += new EventHandler<ProgressEventArgs>(Images_ImageCollectionSavingProgress);
            images.ImageSavingProgress += new EventHandler<ProgressEventArgs>(Images_ImageSavingProgress);
            images.ImageSavingException += new EventHandler<ExceptionEventArgs>(Images_ImageSavingException);
            images.ImageCollectionSavingFinished += new EventHandler(images_ImageCollectionSavingFinished);

            //
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

                DemosTools.ShowErrorMessage(ex);

                IsImageSaving = false;
            }

            return result;
        }

        /// <summary>
        /// Image from image collection is saved.
        /// </summary>
        private void Images_ImageCollectionSavingProgress(object sender, ProgressEventArgs e)
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

            //
            if (InvokeRequired)
                Invoke(new UpdateImageCollectionSavingProgressMethod(UpdateImageCollectionSavingProgress), e);
            else
                UpdateImageCollectionSavingProgress(e);
        }

        /// <summary>
        /// Image saving is in progress.
        /// </summary>
        private void Images_ImageSavingProgress(object sender, ProgressEventArgs e)
        {
            // if saving of image must be canceled (application is closing OR new image is opening)
            if (_cancelImageSaving)
            {
                // if saving of image can be canceled (decoder can cancel saving of image)
                if (e.CanCancel)
                    // send a request to cancel saving of image
                    e.Cancel = _cancelImageSaving;
            }

            //
            if (InvokeRequired)
                Invoke(new UpdateImageSavingProgressMethod(UpdateImageSavingProgress), e);
            else
            {
                UpdateImageSavingProgress(e);
                Application.DoEvents();
            }
        }

        /// <summary>
        /// Image collection is NOT saved because of error.
        /// </summary>
        private void Images_ImageSavingException(object sender, ExceptionEventArgs e)
        {
            // do not show error message if application is closing
            if (!_isFormClosing)
                DemosTools.ShowErrorMessage("Image saving error", e.Exception);

            _saveFilename = null;

            //
            this.IsImageSaving = false;
        }

        /// <summary>
        /// Image saving is in-progress.
        /// </summary>
        private void images_ImageCollectionSavingFinished(object sender, EventArgs e)
        {
            ImageCollection images = (ImageCollection)sender;

            // unsubscribe from the events
            images.ImageCollectionSavingProgress -= new EventHandler<ProgressEventArgs>(Images_ImageCollectionSavingProgress);
            images.ImageSavingProgress -= new EventHandler<ProgressEventArgs>(Images_ImageSavingProgress);
            images.ImageSavingException -= new EventHandler<ExceptionEventArgs>(Images_ImageSavingException);
            images.ImageCollectionSavingFinished -= new EventHandler(images_ImageCollectionSavingFinished);

            // if image collection saved to the source OR
            // image collection must be switched to new source
            if (_saveFilename != null)
            {
                _sourceFilename = _saveFilename;
                _sourceDecoderName = _encoderName;
                _sourceStreamIsReadOnly = false;

                _saveFilename = null;
                _encoderName = null;
            }

            // saving of images is finished successfully
            this.IsImageSaving = false;
        }

        /// <summary>
        /// Updates status about image collection saving. Thread safe.
        /// </summary>
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
        private void InvertColorChannel(Color color)
        {
            ColorBlendCommand command = new ColorBlendCommand(BlendingMode.Difference, color);
            _imageProcessingCommandExecutor.ExecuteProcessingCommand(command);
        }

        /// <summary>
        /// Extracts color channels of the image.
        /// </summary>
        private void ExtractColorChannels(int rMask, int gMask, int bMask)
        {
            Color blendingColor = Color.FromArgb(rMask, gMask, bMask);
            ColorBlendCommand command = new ColorBlendCommand(BlendingMode.Darken, blendingColor);
            _imageProcessingCommandExecutor.ExecuteProcessingCommand(command);
        }


        private void colorNoiseClearCommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if !REMOVE_DOCCLEANUP_PLUGIN
            ShowAndDisposeProcessingDialog(new ColorNoiseClearForm(imageViewer1));
#endif
        }


        /// <summary>
        /// Image processing is started.
        /// </summary>
        private void _imageProcessingCommandExecutor_ImageProcessingCommandStarted(object sender, ImageProcessingEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ImageProcessingEventHandlerDelegate(_imageProcessingCommandExecutor_ImageProcessingCommandStarted), sender, e);
            }
            else
            {
                this.Cursor = Cursors.WaitCursor;
                this.IsImageProcessing = true;
            }
        }

        /// <summary>
        /// Image processing is in progress.
        /// </summary>
        private void _imageProcessingCommandExecutor_ImageProcessingCommandProgress(object sender, ImageProcessingProgressEventArgs e)
        {
            if (e.Progress == 100)
            {
                _isEscPressed = false;
            }
            else if (e.CanCancel)
            {
                if (_isEscPressed || _isFormClosing)
                {
                    e.Cancel = true;
                    _isEscPressed = false;
                }
            }

            if (this.InvokeRequired)
                this.BeginInvoke(new UpdateImageProcessingProgressMethod(UpdateImageProcessingProgress), sender, e);
            else
                UpdateImageProcessingProgress(sender, e);
        }

        /// <summary>
        /// Image processing is finished.
        /// </summary>
        private void _imageProcessingCommandExecutor_ImageProcessingCommandFinished(object sender, ImageProcessedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ImageProcessedEventHandlerDelegate(_imageProcessingCommandExecutor_ImageProcessingCommandFinished), sender, e);
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
            CustomSelectionTool customSelectionTool = GetCustomSelectionTool(imageViewer1.VisualTool);
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
            RectangularSelectionTool rectangularSelectionTool = GetRectangularSelectionTool(imageViewer1.VisualTool);
            if (rectangularSelectionTool != null)
            {
                if (rectangularSelectionTool.Rectangle != Rectangle.Empty)
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
            // get custom selection tool
            CustomSelectionTool customSelectionTool = GetCustomSelectionTool(imageViewer1.VisualTool);
            // if custom selection tool exists
            if (customSelectionTool != null)
            {
                try
                {
                    // get custom selection
                    SelectionRegionBase selection = customSelectionTool.Selection;
                    if (selection == null)
                        return;

                    // get selection as graphics path
                    GraphicsPath path = selection.GetAsGraphicsPath();
                    // get bounding box
                    Rectangle bounds = Rectangle.Round(path.GetBounds());
                    if (bounds.Width <= 0 && bounds.Height <= 0)
                        return;

                    // get image viewer rectangle
                    Rectangle viewerImageRect = new Rectangle(0, 0, imageViewer1.Image.Width, imageViewer1.Image.Height);
                    // get copy rectangle
                    Rectangle viewerCopyRect = Rectangle.Intersect(bounds, viewerImageRect);

                    if (viewerCopyRect.Width <= 0 || viewerCopyRect.Height <= 0)
                        return;

                    VintasoftImage clipboardImage;
                    // get image for rectangle
                    using (VintasoftImage image = imageViewer1.GetFocusedImageRect(viewerCopyRect))
                    {
                        if (image == null)
                            return;

                        // create a composite command, which will clear image, overlay image with path and crop the image
                        CompositeCommand compositeCommand = new CompositeCommand(
                            new ClearImageCommand(Color.Transparent),
                            new ProcessPathCommand(new OverlayCommand(image), path),
                            new CropCommand(viewerCopyRect));
                        // apply the composite command to the iamge and get the result image
                        clipboardImage = compositeCommand.Execute(imageViewer1.Image);
                    }

                    // get image as System.Drawing.Bitmap
                    Bitmap bitmap = clipboardImage.GetAsBitmap();
                    // copy to the clipboard
                    Clipboard.SetImage(bitmap);
                    clipboardImage.Dispose();
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
            RectangularSelectionToolWithCopyPaste rectSelectionTool =
                ((RectangularSelectionToolWithCopyPaste)GetRectangularSelectionTool(imageViewer1.VisualTool));
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
                    // change the focused image to the image from clipboard
                    imageViewer1.Image.SetImage(Clipboard.GetImage(), true);
                }
                // if image viewer does NOT have focused image
                else
                {
                    // add image from clipboard as new image
                    imageViewer1.Images.Add(new VintasoftImage(Clipboard.GetImage(), true));
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

            // get custom selection tool
            CustomSelectionTool customSelectionTool = GetCustomSelectionTool(imageViewer1.VisualTool);
            // if custom selection tool is not empty
            if (customSelectionTool != null)
            {
                try
                {
                    // get image
                    VintasoftImage source = imageViewer1.Images[imageViewer1.FocusedIndex];
                    if (source == null)
                        return;

                    // get selection
                    SelectionRegionBase selection = customSelectionTool.Selection;
                    if (selection == null)
                        return;

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
                    using (VintasoftImage imageFromClipboard = new VintasoftImage(Clipboard.GetImage(), true))
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
                        ProcessPathCommand overlayWithPath = new ProcessPathCommand(overlayCommand, path);
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
            RectangularSelectionToolWithCopyPaste rectSelectionTool =
                ((RectangularSelectionToolWithCopyPaste)GetRectangularSelectionTool(imageViewer1.VisualTool));
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
                    thumbnailViewer1.Images.Add(new VintasoftImage(Clipboard.GetImage(), true));
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
        /// <param name="menuItem">The "Edit" menu item.</param>
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

            _undoManager.Changed += new EventHandler<UndoManagerChangedEventArgs>(HistoryManager_Changed);
            _undoManager.Navigated += new EventHandler<UndoManagerNavigatedEventArgs>(HistoryManager_Navigated);

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

            _undoManager.Changed -= HistoryManager_Changed;
            _undoManager.Navigated -= HistoryManager_Navigated;
            _undoManager.Dispose();
            _undoManager = null;
        }

        /// <summary>
        /// Current history manager is changed.
        /// </summary>
        private void HistoryManager_Changed(object sender, UndoManagerChangedEventArgs e)
        {
            if (InvokeRequired)
                Invoke(new UpdateUndoRedoMenuDelegate(UpdateUndoRedoMenu), sender);
            else
                UpdateUndoRedoMenu((UndoManager)sender);
        }

        /// <summary>
        /// Current action in history of current history manager is changed.
        /// </summary>
        private void HistoryManager_Navigated(object sender, UndoManagerNavigatedEventArgs e)
        {
            if (InvokeRequired)
                Invoke(new UpdateUndoRedoMenuDelegate(UpdateUndoRedoMenu), sender);
            else
                UpdateUndoRedoMenu((UndoManager)sender);
        }

        /// <summary>
        /// Updates the "Undo/Redo" menu.
        /// </summary>
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
        /// Shows the form of image processing history.
        /// </summary>
        private void ShowHistoryForm()
        {
            if (imageViewer1.Image == null)
                return;

            _historyForm = new UndoManagerHistoryForm(this, _undoManager);
            _historyForm.FormClosed += new FormClosedEventHandler(HistoryForm_FormClosed);
            _historyForm.Show();
        }

        /// <summary>
        /// Closes the form of image processing history.
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
        /// Image processing history form is closed.
        /// </summary>
        private void HistoryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            historyDialogToolStripMenuItem.Checked = false;
            _historyForm = null;
        }

        #endregion


        #region Access to image pixels

        /// <summary>
        /// Opens a form for direct access to the image pixels.
        /// </summary>
        private void OpenDirectPixelAccessForm()
        {
            if (_directPixelAccessForm == null)
            {
                _directPixelAccessForm = new DirectPixelAccessForm(imageViewer1);
                _directPixelAccessForm.Owner = this;
                _directPixelAccessForm.FormClosed += new FormClosedEventHandler(_directPixeAccessForm_FormClosed);
            }

            _directPixelAccessForm.Show();
        }

        /// <summary>
        /// Closes a form for direct access to the image pixels.
        /// </summary>
        private void CloseDirectPixelAccessForm()
        {
            if (_directPixelAccessForm != null)
            {
                _directPixelAccessForm.FormClosed -= new FormClosedEventHandler(_directPixeAccessForm_FormClosed);
                _directPixelAccessForm.Close();
                _directPixelAccessForm = null;
            }
        }

        /// <summary>
        /// A direct pixel access form is closed.
        /// </summary>
        private void _directPixeAccessForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            editImagePixelsToolStripMenuItem.Checked = false;
        }

        #endregion

        #endregion



        #region Delegates

        private delegate void UpdateUIDelegate();

        private delegate void UpdateImageCollectionSavingProgressMethod(ProgressEventArgs e);
        private delegate void UpdateImageSavingProgressMethod(ProgressEventArgs e);

        private delegate void UpdateImageProcessingProgressMethod(object sender, ImageProcessingProgressEventArgs e);

        private delegate void ImageProcessingEventHandlerDelegate(object sender, ImageProcessingEventArgs e);
        private delegate void ImageProcessedEventHandlerDelegate(object sender, ImageProcessedEventArgs e);

        private delegate void UpdateUndoRedoMenuDelegate(UndoManager undoManager);

        #endregion

    }
}
