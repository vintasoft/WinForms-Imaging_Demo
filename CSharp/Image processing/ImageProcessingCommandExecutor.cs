using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Color;
using Vintasoft.Imaging.ImageProcessing.Document;
using Vintasoft.Imaging.ImageProcessing.Info;
using Vintasoft.Imaging.ImageProcessing.Transforms;
using Vintasoft.Imaging.UI;
using Vintasoft.Imaging.UI.VisualTools;
using Vintasoft.Imaging.Undo;

using DemosCommonCode;
using DemosCommonCode.Imaging;
using DemosCommonCode.Imaging.Codecs;
using Vintasoft.Imaging.Drawing.Gdi;

namespace ImagingDemo
{
    /// <summary>
    /// Controls the execution of image processing commands.
    /// </summary>
    internal class ImageProcessingCommandExecutor
    {

        #region Nested classes

        /// <summary>
        /// Image processing command task.
        /// </summary>
        class ProcessingCommandTask
        {

            #region Fields

            /// <summary>
            /// Image processing command to execute.
            /// </summary>
            ProcessingCommandBase _command;

            /// <summary>
            /// Image to process.
            /// </summary>
            VintasoftImage _image;

            #endregion


            #region Constructor

            /// <summary>
            /// Initializes a new instance of the <see cref="ProcessingCommandTask"/> class.
            /// </summary>
            /// <param name="command">Image processing command to execute.</param>
            /// <param name="image">Image to process.</param>
            public ProcessingCommandTask(ProcessingCommandBase command, VintasoftImage image)
            {
                _command = command;
                _image = image;
            }

            #endregion


            #region Methods

            /// <summary>
            /// Executes image processing.
            /// </summary>
            public void Execute()
            {
                try
                {
                    // execute image processing command
                    _command.ExecuteInPlace(_image);
                    // previous image will be disposed automatically
                }
                catch (Exception ex)
                {
                    if (ImageProcessingExceptionOccurs != null)
                        ImageProcessingExceptionOccurs(this, EventArgs.Empty);

                    DemosTools.ShowErrorMessage("Image processing exception", ex);
                }
            }

            #endregion


            #region Events

            /// <summary>
            /// Occurs when an exception occurs during image processing.
            /// </summary>
            public event EventHandler ImageProcessingExceptionOccurs;

            #endregion

        }

        #endregion



        #region Fields

        /// <summary>
        /// Image viewer that shows the image.
        /// </summary>
        ImageViewer _viewer;

        /// <summary>
        /// Open file dialog for SetAlphaChannelMaskCommand.
        /// </summary>
        OpenFileDialog _openFileDialog;

        /// <summary>
        /// Blending mode for ColorBlendCommand.
        /// </summary>
        BlendingMode _blendMode = BlendingMode.Multiply;

        /// <summary>
        /// Blending color for ColorBlendCommand.
        /// </summary>
        Color _blendColor = Color.LightGreen;

        /// <summary>
        /// Overlay image for OverlayCommand, OverlayWithBlendingCommand and OverlayMaskedCommand.
        /// </summary>
        VintasoftImage _overlayImage = null;

        /// <summary>
        /// Mask image for OverlayCommand, OverlayWithBlendingCommand and OverlayMaskedCommand.
        /// </summary>
        VintasoftImage _maskImage = null;

        /// <summary>
        /// Comparison image for ImageComparisonCommand.
        /// </summary>
        VintasoftImage _comparisonImage = null;

        /// <summary>
        /// The image processing command undo monitor.
        /// </summary>
        ImageProcessingUndoMonitor _imageProcessingUndoMonitor = null;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessingCommandTask"/> class.
        /// </summary>
        /// <param name="viewer">Image viewer that shows the image.</param>
        public ImageProcessingCommandExecutor(ImageViewer viewer)
        {
            _viewer = viewer;

            _openFileDialog = new OpenFileDialog();
            CodecsFileFilters.SetOpenFileDialogFilter(_openFileDialog);
        }

        #endregion



        #region Properties

        bool _isImageProcessingWorking = false;
        /// <summary>
        /// Gets a value indicating whether the image is processing.
        /// </summary>
        public bool IsImageProcessingWorking
        {
            get
            {
                return _isImageProcessingWorking;
            }
        }

        bool _executeMultithread = false;
        /// <summary>
        /// Gets a value indicating whether the processing command must be
        /// executed in multiple threads.
        /// </summary>
        public bool ExecuteMultithread
        {
            get
            {
                return _executeMultithread;
            }
            set
            {
                _executeMultithread = value;
            }
        }

        bool _expandSupportedPixelFormats = true;
        /// <summary>
        /// Gets or sets a value indicating whether the processing command need to
        /// convert the processing image to the nearest pixel format without color loss
        /// if processing command does not support pixel format
        /// of the processing image.
        /// </summary>
        public bool ExpandSupportedPixelFormats
        {
            get
            {
                return _expandSupportedPixelFormats;
            }
            set
            {
                _expandSupportedPixelFormats = value;
            }
        }

        DateTime _processingCommandStartTime;
        /// <summary>
        /// Gets the time when the image processing is started.
        /// </summary>
        public DateTime ProcessingCommandStartTime
        {
            get
            {
                return _processingCommandStartTime;
            }
        }

        UndoManager _undoManager;
        /// <summary>
        /// Gets or sets the undo manager associated with processing image.
        /// </summary>
        public UndoManager UndoManager
        {
            get
            {
                return _undoManager;
            }
            set
            {
                _undoManager = value;
            }
        }

        /// <summary>
        /// Gets the selection rectangle of viewer.
        /// </summary>
        Rectangle ViewerSelectionRectangle
        {
            get
            {
                Rectangle selectionRect = Rectangle.Empty;
                RectangularSelectionToolWithCopyPaste selection = CompositeVisualTool.FindVisualTool<RectangularSelectionToolWithCopyPaste>(_viewer.VisualTool);
                if (selection != null)
                    selectionRect = selection.Rectangle;
                return selectionRect;
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Executes image processing command asynchronously.
        /// </summary>
        /// <param name="command">Command to execute.</param>
        public void ExecuteProcessingCommand(ProcessingCommandBase command)
        {
            ExecuteProcessingCommand(command, true);
        }

        /// <summary>
        /// Executes image processing command synchronously or asynchronously.
        /// </summary>
        /// <param name="command">Command to execute.</param>
        /// <param name="async">A value indicating whether to execute command asynchronously.</param>
        public bool ExecuteProcessingCommand(ProcessingCommandBase command, bool async)
        {
            RectangularSelectionToolWithCopyPaste rectSelectionTool = CompositeVisualTool.FindVisualTool<RectangularSelectionToolWithCopyPaste>(_viewer.VisualTool);
            CustomSelectionTool customSelectionTool = CompositeVisualTool.FindVisualTool<CustomSelectionTool>(_viewer.VisualTool);

            if (rectSelectionTool != null)
            {
                // set the region of interest
                Rectangle selectionRectangle = ViewerSelectionRectangle;
                ProcessingCommandWithRegion commandWorkWithRegion = command as ProcessingCommandWithRegion;
                if (commandWorkWithRegion != null)
                {
                    commandWorkWithRegion.RegionOfInterest = new RegionOfInterest(selectionRectangle.Left, selectionRectangle.Top, selectionRectangle.Width, selectionRectangle.Height);
                }
                else if (command is DrawImageCommand)
                {
                    ((DrawImageCommand)command).DestRect = selectionRectangle;
                }
                else if (!selectionRectangle.IsEmpty)
                {
                    MessageBox.Show("Selected image processing command cannot work with regions. Entire image will be processed.",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (customSelectionTool != null)
            {
                RectangleF selectionBBox = RectangleF.Empty;
                if (customSelectionTool.Selection != null)
                    selectionBBox = customSelectionTool.Selection.GetBoundingBox();
                if (selectionBBox.Width >= 1 && selectionBBox.Height >= 1)
                {
                    if (command is ChangePixelFormatCommand ||
                        command is ChangePixelFormatToBgrCommand ||
                        command is ChangePixelFormatToBlackWhiteCommand ||
                        command is ChangePixelFormatToGrayscaleCommand ||
                        command is ChangePixelFormatToPaletteCommand ||
                        command is RotateCommand ||
                        command is ResampleCommand ||
                        command is ResizeCommand ||
                        !command.CanModifyImage)
                    {
                        MessageBox.Show("Selected image processing command cannot work with custom selection. Entire image will be processed.",
                            "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        GraphicsPath path = customSelectionTool.Selection.GetAsGraphicsPath();
                        RectangleF pathBounds = path.GetBounds();
                        if (pathBounds.Width > 0 && pathBounds.Height > 0)
                        {
                            if (command is CropCommand)
                            {
                                // crop to custom selection
                                command = GetCropToPathCommand(path, pathBounds, (CropCommand)command);
                                // clear selection
                                customSelectionTool.Selection = null;
                            }
                            else
                            {
                                // process path
                                command = new ProcessPathCommand(command, new GdiGraphicsPath(path, false));
                            }
                        }
                        else
                        {
                            MessageBox.Show("Selected path is empty.",
                                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                    }
                }
            }

            // get a reference to the image for processing
            VintasoftImage imageToProcess = _viewer.Image;

            ProcessingCommandBase executeCommand = command;
            if (_executeMultithread)
            {
                ParallelizingProcessingCommand parallelizingCommand = new ParallelizingProcessingCommand(command);
                if (command is ProcessingCommandWithRegion)
                    parallelizingCommand.RegionOfInterest = ((ProcessingCommandWithRegion)command).RegionOfInterest;
                executeCommand = parallelizingCommand;
            }

            if (UndoManager != null)
                _imageProcessingUndoMonitor = new ImageProcessingUndoMonitor(UndoManager, executeCommand);

            // subscribe to the events of the image processing command
            executeCommand.Started += new EventHandler<ImageProcessingEventArgs>(command_Started);
            executeCommand.Progress += new EventHandler<ImageProcessingProgressEventArgs>(command_Progress);
            executeCommand.Finished += new EventHandler<ImageProcessedEventArgs>(command_Finished);

            executeCommand.ExpandSupportedPixelFormats = ExpandSupportedPixelFormats;
            executeCommand.RestoreSourcePixelFormat = false;

            // specify that image processing command is working (several commands cannot work together)
            _isImageProcessingWorking = true;
            // get the start time of the image processing command
            _processingCommandStartTime = DateTime.Now;

            // if image processing command should be executed asynchronously
            if (async)
            {
                // start the image processing command asynchronously
                ProcessingCommandTask executor = new ProcessingCommandTask(executeCommand, imageToProcess);
                executor.ImageProcessingExceptionOccurs += new EventHandler(executor_ImageProcessingExceptionOccurs);
                Thread thread = new Thread(executor.Execute);
                thread.IsBackground = true;
                thread.Start();
            }
            // if image processing command should be executed synchronously
            else
            {
                try
                {
                    // execute the image processing command synchronously
                    executeCommand.ExecuteInPlace(imageToProcess);
                }
                catch (Exception ex)
                {
                    executor_ImageProcessingExceptionOccurs(this, EventArgs.Empty);
                    DemosTools.ShowErrorMessage(ex);
                    return false;
                }
            }

            return true;
        }


        #region Commands

        /// <summary>
        /// Executes the ImageComparisonCommand command.
        /// </summary>
        public void ExecuteComparisonCommand()
        {
            // create the processing command
            ImageComparisonCommand command = new ImageComparisonCommand();

            // set properties of command
            PropertyGridForm propertyGridForm = new PropertyGridForm(command, "Image Comparison Command Properties", true);
            if (propertyGridForm.ShowDialog() != DialogResult.OK)
                return;

            // save a reference to the comparison image, image will be disposed when command is finished
            _comparisonImage = command.Image;

            // execute the command
            ExecuteProcessingCommand(command, true);
        }

        /// <summary>
        /// Executes the DrawImageCommand command.
        /// </summary>
        public void ExecuteDrawImageCommand()
        {
            // create the processing command
            DrawImageCommand command = ImageProcessingCommandFactory.CreateDrawImageCommand(_viewer.Image);

            // set properties of command
            PropertyGridForm propertyGridForm = new PropertyGridForm(command, "Draw Image Command Properties", true);
            if (propertyGridForm.ShowDialog() != DialogResult.OK)
                return;

            // save a reference to the overlay image, image will be disposed when command is finished
            _overlayImage = command.OverlayImage;

            // execute the command
            ExecuteProcessingCommand(command, true);
        }


        /// <summary>
        /// Executes the OverlayCommand command.
        /// </summary>
        public void ExecuteOverlayCommand()
        {
            // create the processing command
            OverlayCommand command = new OverlayCommand();

            // set properties of command
            PropertyGridForm propertyGridForm = new PropertyGridForm(command, "Overlay Command Properties", true);
            if (propertyGridForm.ShowDialog() != DialogResult.OK)
                return;

            // save a reference to the overlay image, image will be disposed when command is finished
            _overlayImage = command.OverlayImage;

            // execute the command
            ExecuteProcessingCommand(command, true);
        }

        /// <summary>
        /// Executes the OverlayBinaryCommand command.
        /// </summary>
        public void ExecuteOverlayBinaryCommand()
        {
            // create the processing command
            OverlayBinaryCommand command = new OverlayBinaryCommand();

            // set properties of command
            PropertyGridForm propertyGridForm = new PropertyGridForm(command, "Overlay Binary Command Properties", true);
            if (propertyGridForm.ShowDialog() != DialogResult.OK)
                return;

            // save a reference to the overlay image, image will be disposed when command is finished
            _overlayImage = command.OverlayImage;

            // execute the command
            ExecuteProcessingCommand(command, true);
        }

        /// <summary>
        /// Executes the OverlayCommand command.
        /// </summary>
        public void ExecuteOverlayWithBlendingCommand()
        {
            // create the processing command
            OverlayWithBlendingCommand command = new OverlayWithBlendingCommand();

            // set properties of command
            PropertyGridForm propertyGridForm = new PropertyGridForm(command, "Overlay with Blending Command Properties", true);
            if (propertyGridForm.ShowDialog() != DialogResult.OK)
                return;

            // save a reference to the overlay image, image will be disposed when command is finished
            _overlayImage = command.OverlayImage;

            // execute the command
            ExecuteProcessingCommand(command, true);
        }

        /// <summary>
        /// Executes the OverlayCommand command.
        /// </summary>
        public void ExecuteOverlayMaskedCommand()
        {
            // create the processing command
            OverlayMaskedCommand command = new OverlayMaskedCommand();

            // set properties of command
            PropertyGridForm propertyGridForm = new PropertyGridForm(command, "Overlay Masked Command Properties", true);
            if (propertyGridForm.ShowDialog() != DialogResult.OK)
                return;

            // save a reference to the overlay image, image will be disposed when command is finished
            _overlayImage = command.OverlayImage;
            // save a reference to the mask image, image will be disposed when command is finished
            _maskImage = command.MaskImage;

            // execute the command
            ExecuteProcessingCommand(command, true);
        }

        /// <summary>
        /// Executes the FillRectangleCommand command.
        /// </summary>
        public void ExecuteFillRectangleCommand()
        {
            // create the processing command
            FillRectangleCommand command = new FillRectangleCommand();

            RectangularSelectionTool visualTool = null;
            if (_viewer.VisualTool != null && _viewer.VisualTool is RectangularSelectionTool)
            {
                visualTool = (RectangularSelectionTool)_viewer.VisualTool;
                if (!visualTool.Rectangle.IsEmpty)
                    command.Rectangles = new Rectangle[] { visualTool.Rectangle };
            }

            // set properties of command
            PropertyGridForm propertyGridForm = new PropertyGridForm(command, "Fill Rectangle Command Properties", true);
            if (propertyGridForm.ShowDialog() != DialogResult.OK)
                return;

            if (visualTool != null)
                visualTool.Rectangle = Rectangle.Empty;

            // execute the command
            ExecuteProcessingCommand(command, true);
        }

        /// <summary>
        /// Executes the IsImageBlackWhiteCommand command.
        /// </summary>
        public void ExecuteIsImageBlackWhiteCommand()
        {
            if (!CommandCanProcessImage(new IsImageBlackWhiteCommand(), _viewer.Image))
                return;
            using (IsImageBlackWhiteForm dlg = new IsImageBlackWhiteForm(_viewer))
            {
                if (dlg.ShowProcessingDialog())
                {
                    IsImageBlackWhiteCommand command = (IsImageBlackWhiteCommand)dlg.GetProcessingCommand();
                    if (ExecuteProcessingCommand(command, false))
                    {
                        if (command.Result.IsImageBlackWhite)
                            MessageBox.Show("Image is black-white");
                        else
                            MessageBox.Show("Image is not black-white");
                    }
                }
            }
        }

        /// <summary>
        /// Executes the IsImageGrayscaleCommand command.
        /// </summary>
        public void ExecuteIsImageGrayscaleCommand()
        {
            if (!CommandCanProcessImage(new IsImageGrayscaleCommand(), _viewer.Image))
                return;
            using (IsImageGrayscaleForm dlg = new IsImageGrayscaleForm(_viewer))
            {
                if (dlg.ShowProcessingDialog())
                {
                    IsImageGrayscaleCommand command = (IsImageGrayscaleCommand)dlg.GetProcessingCommand();
                    if (ExecuteProcessingCommand(command, false))
                    {
                        if (command.Result.IsImageGrayscale)
                            MessageBox.Show("Image is grayscale");
                        else
                            MessageBox.Show("Image is not grayscale");
                    }
                }
            }
        }

        /// <summary>
        /// Executes the GetColorCountCommand command.
        /// </summary>
        public void ExecuteColorCountCommand()
        {
            GetColorCountCommand command = new GetColorCountCommand();
            if (!CommandCanProcessImage(command, _viewer.Image))
                return;
            if (ExecuteProcessingCommand(command, false))
                MessageBox.Show(String.Format("This image has {0} unique colors.", command.ColorCount));
        }

        /// <summary>
        /// Executes the GetImageColorDepthCommand command.
        /// </summary>
        public void ExecuteGetImageColorDepthCommand()
        {
            if (!CommandCanProcessImage(new GetImageColorDepthCommand(), _viewer.Image))
                return;
            using (GetImageColorDepthForm dlg = new GetImageColorDepthForm(_viewer))
            {
                if (dlg.ShowProcessingDialog())
                {
                    GetImageColorDepthCommand command = (GetImageColorDepthCommand)dlg.GetProcessingCommand();
                    if (ExecuteProcessingCommand(command, false))
                    {
                        if (command.Result.PixelFormat == PixelFormat.Undefined)
                            MessageBox.Show("Image color depth can not be reduced.");
                        else
                            MessageBox.Show(string.Format("Detected image color depth is {0}.", command.Result.PixelFormat));
                    }
                }
            }
        }

        /// <summary>
        /// Executes the GetBorderColorCommand command.
        /// </summary>
        public void ExecuteGetBorderColorCommand()
        {
            GetBorderColorCommand command = new GetBorderColorCommand();

            if (ExecuteProcessingCommand(command, false))
            {
                if (command.IsBorderColorFound)
                    MessageBox.Show(String.Format("Most probably border color is {0}.", command.BorderColor.ToString()));
                else
                    MessageBox.Show("Border color is unknown.");
            }
        }

        /// <summary>
        /// Executes the GetBackgroundColorCommand command.
        /// </summary>
        public void ExecuteGetBackgroundColorCommand()
        {
            GetBackgroundColorCommand command = new GetBackgroundColorCommand();

            if (ExecuteProcessingCommand(command, false))
            {
                if (command.IsBackgroundColorFound)
                    MessageBox.Show(String.Format("Most probably background color is {0}.", command.BackgroundColor.ToString()));
                else
                    MessageBox.Show("Background color is unknown.");
            }
        }

        /// <summary>
        /// Executes the GetDocumentImageRotationAngleCommand command.
        /// </summary>
        public void ExecuteGetDocumentImageRotationAngleCommand()
        {
#if !REMOVE_DOCCLEANUP_PLUGIN
            GetDocumentImageRotationAngleCommand command = new GetDocumentImageRotationAngleCommand();

            // set properties of command
            using (PropertyGridForm propertyGridForm = new PropertyGridForm(command, "Get Document ImageRotation Angle Command Properties", true))
            {
                if (propertyGridForm.ShowDialog() != DialogResult.OK)
                    return;

                if (ExecuteProcessingCommand(command, false))
                    MessageBox.Show(String.Format("Most probably rotation angle is {0} degree.", command.Angle.ToString("f2")));
            }
#endif
        }

        /// <summary>
        /// Executes the GetRotationAngleCommand command.
        /// </summary>
        public void ExecuteGetRotationAngleCommand()
        {
            GetRotationAngleCommand command = new GetRotationAngleCommand();

            // set properties of command
            using (PropertyGridForm propertyGridForm = new PropertyGridForm(command, "Get Rotation Angle Command Properties", true))
            {
                if (propertyGridForm.ShowDialog() != DialogResult.OK)
                    return;

                if (ExecuteProcessingCommand(command, false))
                    MessageBox.Show(String.Format("Most probably rotation angle is {0} degree.", command.Angle.ToString("f2")));
            }
        }

        /// <summary>
        /// Executes the GetThresholdCommand command.
        /// </summary>
        public void ExecuteGetThresholdCommand()
        {
            GetThresholdCommand command = new GetThresholdCommand();

            if (ExecuteProcessingCommand(command, false))
                MessageBox.Show(String.Format("Optimal binarization threshold in the range 0..765 is {0}.", command.Threshold.ToString()));
        }

        /// <summary>
        /// Executes the IsImageBlankCommand command.
        /// </summary>
        public void ExecuteIsBlankCommand()
        {
            IsImageBlankCommand command = new IsImageBlankCommand(0.01f);

            if (ExecuteProcessingCommand(command, false))
            {
                if (command.Result)
                {
                    MessageBox.Show(string.Format("Image is blank, noise level is {0}%.\n\nIsImageBlankCommand.MaxNoiseLevel == {1}%.",
                        command.NoiseLevel * 100, command.MaxNoiseLevel * 100));
                }
                else
                {
                    if (command.NoiseLevel < 1)
                        MessageBox.Show(string.Format("Image is not blank, noise level is {0}%.\n\nIsImageBlankCommand.MaxNoiseLevel == {1}%.",
                            command.NoiseLevel * 100, command.MaxNoiseLevel * 100));
                    else
                        MessageBox.Show(string.Format("Image is not blank.\n\nIsImageBlankCommand.MaxNoiseLevel == {0}%.",
                            command.MaxNoiseLevel * 100));
                }
            }
        }

        /// <summary>
        /// Executes the IsDocumentImageCommand command.
        /// </summary>
        public void ExecuteIsDocumentImageCommand()
        {
#if !REMOVE_DOCCLEANUP_PLUGIN
            IsDocumentImageCommand command = new IsDocumentImageCommand();

            // set properties of command
            PropertyGridForm propertyGridForm = new PropertyGridForm(command, "Is Document Image Properties", true);
            if (propertyGridForm.ShowDialog() != DialogResult.OK)
                return;

            if (ExecuteProcessingCommand(command, false))
            {
                if (command.IsDocumentImage)
                {
                    if (command.IsInvertedDocumentImage)
                        MessageBox.Show("Is inverted document image.");
                    else
                        MessageBox.Show("Is document image.");
                }
                else
                {
                    MessageBox.Show("Image is not document image.");
                }
            }
#endif
        }

        /// <summary>
        /// Executes the HasCertainColorCommand command.
        /// </summary>
        public void ExecuteHasCertainColorCommand()
        {
            // create the processing command
            HasCertainColorCommand command = new HasCertainColorCommand();

            // set properties of command
            PropertyGridForm propertyGridForm = new PropertyGridForm(command, "Has Certain Color Command Properties", true);
            if (propertyGridForm.ShowDialog() != DialogResult.OK)
                return;

            if (ExecuteProcessingCommand(command, false))
            {
                if (command.Result)
                    MessageBox.Show(String.Format("Image has {0} color.", command.Color));
                else
                    MessageBox.Show(String.Format("Image does not have {0} color.", command.Color));
            }
        }

        /// <summary>
        /// Executes the GetTextOrientationCommand command.
        /// </summary>
        public void ExecuteGetTextOrientationCommand()
        {
#if !REMOVE_DOCCLEANUP_PLUGIN
            GetTextOrientationCommand command = new GetTextOrientationCommand();
            command.Results = new ProcessingCommandResults();

            // set properties of command
            PropertyGridForm propertyGridForm = new PropertyGridForm(command, "Get Text Orientation Command Properties", true);
            if (propertyGridForm.ShowDialog() != DialogResult.OK)
                return;

            if (ExecuteProcessingCommand(command, false))
            {

                GetTextOrientationCommandResult result = (GetTextOrientationCommandResult)command.Results[0];
                ImageOrthogonalOrientation documentOrientation = result.Orientation;

                switch (documentOrientation)
                {
                    case ImageOrthogonalOrientation.Undefined:
                        MessageBox.Show(String.Format("Document orientation is not defined."));
                        break;
                    case ImageOrthogonalOrientation.Rotated0:
                        MessageBox.Show(String.Format("Document has the right orientation."));
                        break;
                    case ImageOrthogonalOrientation.Rotated90:
                        MessageBox.Show(String.Format("Document is rotated by 90 degrees clockwise."));
                        break;
                    case ImageOrthogonalOrientation.Rotated180:
                        MessageBox.Show(String.Format("Document is rotated by 180 degrees clockwise."));
                        break;
                    case ImageOrthogonalOrientation.Rotated270:
                        MessageBox.Show(String.Format("Document is rotated by 270 degrees clockwise."));
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
#endif
        }

        /// <summary>
        /// Executes the BinarizeCommand command.
        /// </summary>
        public void ExecuteBinarizeCommand()
        {
            if (_viewer.Image.PixelFormat != PixelFormat.BlackWhite)
            {
                BinarizeForm dlg = new BinarizeForm(_viewer, false);
                if (dlg.ShowProcessingDialog())
                {
                    BinarizeCommand command = new BinarizeCommand(dlg.Threshold);
                    ExecuteProcessingCommand(command);
                }
            }
        }

        /// <summary>
        /// Executes the SetAlphaChannelValueCommand command.
        /// </summary>
        public void ExecuteSetAlphaChannelValueCommand()
        {
            AlphaChannelForm dlg = new AlphaChannelForm(_viewer);
            if (dlg.ShowProcessingDialog())
            {
                SetAlphaChannelValueCommand command = new SetAlphaChannelValueCommand(dlg.Alpha);
                ExecuteProcessingCommand(command);
            }
        }

        /// <summary>
        /// Executes the SetAlphaChannelCommand command.
        /// </summary>
        public void ExecuteSetAlphaChannelCommand()
        {
            if (_openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            VintasoftImage maskImage;
            try
            {
                maskImage = new VintasoftImage(_openFileDialog.FileName);
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage("SetAlphaChannelMaskCommand", ex);
                return;
            }

            SetAlphaChannelMaskCommand command = new SetAlphaChannelMaskCommand(maskImage);
            ExecuteProcessingCommand(command, false);

            maskImage.Dispose();
        }

        /// <summary>
        /// Executes the ColorBlendCommand command.
        /// </summary>
        public void ExecuteColorBlendCommand()
        {
            ColorBlendForm dlg;
            try
            {
                dlg = new ColorBlendForm(_viewer, ViewerSelectionRectangle, _blendColor, _blendMode);
            }
            catch (ImageProcessingException ex)
            {
                MessageBox.Show(ex.Message, "Image processing exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (dlg.ShowProcessingDialog())
            {
                _blendMode = dlg.BlendMode;
                _blendColor = dlg.BlendColor;
                ColorBlendCommand command = ImageProcessingCommandFactory.CreateColorBlendCommand(_viewer.Image);
                command.BlendingMode = _blendMode;
                command.BlendColor = _blendColor;
                ExecuteProcessingCommand(command);
            }
        }

        /// <summary>
        /// Executes the AdvancedReplaceColorCommand command.
        /// </summary>
        public void ExecuteAdvancedReplaceColorCommand()
        {
#if !REMOVE_DOCCLEANUP_PLUGIN
            // create the processing command
            AdvancedReplaceColorCommand command = new AdvancedReplaceColorCommand();

            // set properties of command
            PropertyGridForm propertyGridForm = new PropertyGridForm(command, "Advanced Replace Color Command Properties", true);
            if (propertyGridForm.ShowDialog() != DialogResult.OK)
                return;

            ExecuteProcessingCommand(command, true);
#endif
        }

        #endregion

        #endregion


        #region PRIVATE

        /// <summary>
        /// Determines whether specified processing command can process the specified image.
        /// </summary>
        /// <param name="command">Image processing command.</param>
        /// <param name="image">Image to process.</param>
        /// <returns>
        /// <b>true</b> - processing command can process image;
        /// otherwise, <b>false</b>.
        /// </returns>
        private bool CommandCanProcessImage(ProcessingCommandBase command, VintasoftImage image)
        {
            bool needConvertToSupportedPixelFormat = command.ExpandSupportedPixelFormats;
            command.ExpandSupportedPixelFormats = ExpandSupportedPixelFormats;
            PixelFormat outputPixelFormat = command.GetOutputPixelFormat(image);
            command.ExpandSupportedPixelFormats = needConvertToSupportedPixelFormat;

            if (outputPixelFormat != PixelFormat.Undefined)
                return true;

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            ReadOnlyCollection<PixelFormat> formats = command.SupportedPixelFormats;
            for (int i = 0; i < formats.Count; i++)
            {
                sb.Append(" -");
                sb.Append(formats[i].ToString());
                sb.AppendLine(";");
            }
            string supportedPixelFormatNames = sb.ToString();

            string message = string.Format(
                System.Globalization.CultureInfo.InvariantCulture,
                "{0}: unsupported pixel format - {1}.\n\nProcessing command supports only the following pixel formats:\n{2}\nPlease convert the image to supported pixel format first.",
                command.Name,
                image.PixelFormat,
                supportedPixelFormatNames);

            DemosTools.ShowErrorMessage("Image processing exception", message);
            return false;
        }

        /// <summary>
        /// Returns "Crop to custom selection" composite command. 
        /// </summary>
        /// <param name="path">Custom selection path.</param>
        /// <param name="pathBounds">Selection path bounds.</param>
        /// <param name="crop">Crop command.</param>
        /// <returns>Crop command for custom selection.</returns>
        ProcessingCommandBase GetCropToPathCommand(
            GraphicsPath path,
            RectangleF pathBounds,
            CropCommand crop)
        {
            Rectangle viewerImageRect = new Rectangle(0, 0, _viewer.Image.Width, _viewer.Image.Height);
            crop.RegionOfInterest = new RegionOfInterest(GetBoundingRect(RectangleF.Intersect(pathBounds, viewerImageRect)));

            // overlay command
            _overlayImage = crop.Execute(_viewer.Image);
            OverlayCommand overlay = new OverlayCommand(_overlayImage);

            // overlay with path command
            ProcessPathCommand overlayWithPath = new ProcessPathCommand(overlay, new GdiGraphicsPath(path, false));

            // clear image command
            ClearImageCommand clearImage = new ClearImageCommand(Color.Transparent);

            // create composite command: clear, overlay with path, crop
            return new CompositeCommand(clearImage, overlayWithPath, crop);
        }

        /// <summary>
        /// Returns a bounding rectangle of specified <see cref="RectangleF"/>.
        /// </summary>
        /// <param name="rect">Rectangle of <see cref="RectangleF"/> type.</param>
        /// <returns>Bounding rectangle of <see cref="Rectangle"> type.</returns>
        static Rectangle GetBoundingRect(RectangleF rect)
        {
            float dx = rect.X - (int)rect.X;
            float dy = rect.Y - (int)rect.Y;
            return new Rectangle((int)rect.X, (int)rect.Y, (int)(rect.Width + 1 + dx), (int)(rect.Height + 1 + dy));
        }

        /// <summary>
        /// Handler of the ProcessingCommandTask.ImageProcessingExceptionOccurs event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void executor_ImageProcessingExceptionOccurs(object sender, EventArgs e)
        {
            _isImageProcessingWorking = false;
        }

        /// <summary>
        /// Handler of the ProcessingCommandBase.Started event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ImageProcessingEventArgs"/> instance containing the event data.</param>
        void command_Started(object sender, ImageProcessingEventArgs e)
        {
            ProcessingCommandBase command = (ProcessingCommandBase)sender;
            command.Started -= new EventHandler<ImageProcessingEventArgs>(command_Started);

            OnImageProcessingCommandStarted((ProcessingCommandBase)sender, e);
        }

        /// <summary>
        /// Handler of the ProcessingCommandBase.Progress event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ImageProcessingProgressEventArgs"/> instance containing the event data.</param>
        void command_Progress(object sender, ImageProcessingProgressEventArgs e)
        {
            OnImageProcessingCommandProgress((ProcessingCommandBase)sender, e);
        }

        /// <summary>
        /// Handler of the ProcessingCommandBase.Finished event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ImageProcessedEventArgs"/> instance containing the event data.</param>
        void command_Finished(object sender, ImageProcessedEventArgs e)
        {
            ProcessingCommandBase command = (ProcessingCommandBase)sender;
            command.Finished -= new EventHandler<ImageProcessedEventArgs>(command_Finished);

            if (command is ParallelizingProcessingCommand)
                command = ((ParallelizingProcessingCommand)command).ProcessingCommand;

            if (command is OverlayCommand ||
                command is OverlayWithBlendingCommand ||
                command is OverlayMaskedCommand)
            {
                if (_overlayImage != null)
                {
                    // dispose the temporary overlay image because the processing command is finished
                    _overlayImage.Dispose();
                    _overlayImage = null;
                }
                if (_maskImage != null)
                {
                    // dispose the temporary mask image because the processing command is finished
                    _maskImage.Dispose();
                    _maskImage = null;
                }
            }

            if (command is ImageComparisonCommand)
                if (_comparisonImage != null)
                {
                    _comparisonImage.Dispose();
                    _comparisonImage = null;
                }

            _isImageProcessingWorking = false;

            if (_imageProcessingUndoMonitor != null)
            {
                _imageProcessingUndoMonitor.Dispose();
                _imageProcessingUndoMonitor = null;
            }

            OnImageProcessingCommandFinished((ProcessingCommandBase)sender, e);
        }

        /// <summary>
        /// Raises the ImageProcessingCommandStarted event.
        /// </summary>
        /// <param name="command">Executing command.</param>
        /// <param name="e">The <see cref="ImageProcessingEventArgs"/> instance containing the event data.</param>
        void OnImageProcessingCommandStarted(ProcessingCommandBase command, ImageProcessingEventArgs e)
        {
            if (ImageProcessingCommandStarted != null)
                ImageProcessingCommandStarted(command, e);
        }

        /// <summary>
        /// Raises the ImageProcessingCommandProgress event.
        /// </summary>
        /// <param name="command">Executing command.</param>
        /// <param name="e">The <see cref="ImageProcessingProgressEventArgs"/> instance containing the event data.</param>
        void OnImageProcessingCommandProgress(ProcessingCommandBase command, ImageProcessingProgressEventArgs e)
        {
            if (ImageProcessingCommandProgress != null)
                ImageProcessingCommandProgress(command, e);
        }

        /// <summary>
        /// Raises the ImageProcessingCommandFinished event.
        /// </summary>
        /// <param name="command">Executed command.</param>
        /// <param name="e">The <see cref="ImageProcessedEventArgs"/> instance containing the event data.</param>
        void OnImageProcessingCommandFinished(ProcessingCommandBase command, ImageProcessedEventArgs e)
        {
            if (ImageProcessingCommandFinished != null)
                ImageProcessingCommandFinished(command, e);
        }

        #endregion

        #endregion



        #region Events

        /// <summary>
        /// Occurs when image processing command is started.
        /// </summary>
        public event EventHandler<ImageProcessingEventArgs> ImageProcessingCommandStarted;

        /// <summary>
        /// Occurs when image processing command progress is changed.
        /// </summary>
        public event EventHandler<ImageProcessingProgressEventArgs> ImageProcessingCommandProgress;

        /// <summary>
        /// Occurs when image processing command is finished.
        /// </summary>
        public event EventHandler<ImageProcessedEventArgs> ImageProcessingCommandFinished;

        #endregion

    }
}
