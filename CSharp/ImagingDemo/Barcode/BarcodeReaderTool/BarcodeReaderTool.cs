using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

using Vintasoft.Barcode;
using Vintasoft.Imaging;
using Vintasoft.Imaging.UI;
using Vintasoft.Imaging.UI.VisualTools;
using Vintasoft.Imaging.UI.VisualTools.UserInteraction;
using Vintasoft.Imaging.ImageProcessing;

using DemosCommonCode;
using Vintasoft.Imaging.Utils;

namespace ImagingDemo.Barcode
{
    /// <summary>
    /// Visual tool for barcode recognition on image in image viewer.
    /// </summary>
    public class BarcodeReaderTool : RectangularSelectionTool
    {

        #region Fields

        /// <summary>
        /// Barcode reader.
        /// </summary>
        BarcodeReader _reader;

        /// <summary>
        /// Indicates that the barcode recognition process should be started.
        /// </summary>
        bool _needStartBarcodeRecognition = false;

        /// <summary>
        /// Indicates that the barcode recognition process is started.
        /// </summary>
        bool _isRecognitionStarted = false;

        /// <summary>
        /// Indicates that the barcode recognition process is started asynchronously.
        /// </summary>
        bool _isAsyncRecognitionStarted = false;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BarcodeReaderTool"/> class. 
        /// </summary>
        public BarcodeReaderTool()
        {
            _reader = new BarcodeReader();
            _reader.Progress += new EventHandler<BarcodeReaderProgressEventArgs>(Reader_Progress);

            base.Cursor = System.Windows.Forms.Cursors.Cross;
            
            RectangularObjectTransformer transformer = new RectangularObjectTransformer(this);
            transformer.HideInteractionPointsWhenMoving = true;
            TransformController = transformer;
            TransformController.Interaction += new EventHandler<InteractionEventArgs>(TransformController_Interaction);

            ActionCursor = new Cursor(ImagingDemoResources.GetResourceAsStream("BarcodeScanner.cur"));
            TransformController.MoveArea.Cursor = ActionCursor;
        }
        
        #endregion



        #region Properties

        /// <summary>
        /// Gets the name of the visual tool.
        /// </summary>
        public override string Name
        {
            get
            {
                return "Barcode reader tool";
            }
        }

        /// <summary>
        /// Gets a value indicating whether the barcode recognition process is started.
        /// </summary>
        public bool IsRecognitionStarted
        {
            get
            {
                return _isRecognitionStarted || _isAsyncRecognitionStarted;
            }
        }

        /// <summary>
        /// Gets an information about barcodes read time.
        /// </summary>
        public TimeSpan RecognizeTime
        {
            get
            {
                return _reader.RecognizeTime;
            }
        }

        /// <summary>
        /// Gets or sets the barcode reader settings.
        /// </summary>
        public ReaderSettings ReaderSettings
        {
            get
            {
                return _reader.Settings;
            }
            set
            {
                _reader.Settings = value;
            }
        }

        IBarcodeInfo[] _recognitionResults;
        /// <summary>
        /// Gets or sets the barcode recognition results.
        /// </summary>
        public IBarcodeInfo[] RecognitionResults
        {
            get
            {
                return _recognitionResults;
            }
            set
            {
                _recognitionResults = value;
                InvalidateViewer();
            }
        }

        Pen _recognizedBarcodePen = new Pen(Color.FromArgb(192, Color.Green), 2);
        /// <summary>
        /// Gets or sets a pen for drawing region of recognized barcode.
        /// </summary>
        public Pen RecognizedBarcodePen
        {
            get
            {
                return _recognizedBarcodePen;
            }
            set
            {
                _recognizedBarcodePen = value;
            }
        }

        Brush _recognizedBarcodeBrush = new SolidBrush(Color.FromArgb(48, Color.Green));
        /// <summary>
        /// Gets or sets a brush for filling region of recognized barcode.
        /// </summary>
        public Brush RecognizedBarcodeBrush
        {
            get
            {
                return _recognizedBarcodeBrush;
            }
            set
            {
                _recognizedBarcodeBrush = value;
            }
        }


        Pen _unrecognizedBarcodePen = new Pen(Color.FromArgb(192, Color.Red), 1);
        /// <summary>
        /// Gets or sets a pen for drawing region of unrecognized barcode.
        /// </summary>
        public Pen UnrecognizedBarcodePen
        {
            get
            {
                return _unrecognizedBarcodePen;
            }
            set
            {
                _unrecognizedBarcodePen = value;
            }
        }

        Brush _unrecognizedBarcodeBrush = new SolidBrush(Color.FromArgb(48, Color.Red));
        /// <summary>
        /// Gets or sets a brush for filling region of unrecognized barcode.
        /// </summary>
        public Brush UnrecognizedBarcodeBrush
        {
            get
            {
                return _unrecognizedBarcodeBrush;
            }
            set
            {
                _unrecognizedBarcodeBrush = value;
            }
        }

        Brush _fontBrush = new SolidBrush(Color.Blue);
        /// <summary>
        /// Gets or sets a brush for drawing the barcode value.
        /// </summary>
        public Brush FontBrush
        {
            get
            {
                return _fontBrush;
            }
            set
            {
                _fontBrush = value;
            }
        }

        Font _font = new Font("Courier New", 12, GraphicsUnit.World);
        /// <summary>
        /// Gets or sets a font for drawing the barcode value.
        /// </summary>
        public Font Font
        {
            get
            {
                return _font;
            }
            set
            {
                _font = value;
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Recognizes barcodes synchronously.
        /// </summary>
        public void ReadBarcodesSync()
        {
            if (_isRecognitionStarted)
                throw new InvalidOperationException("Recognition process is executing at this moment.");

            _isRecognitionStarted = true;

            if (InvokeRequired)
                Invoke(new OnRecoginitionStartedDelegate(OnRecoginitionStarted), EventArgs.Empty);
            else
                OnRecoginitionStarted(EventArgs.Empty);

            try
            {
                if (ImageViewer != null)
                {
                    VintasoftImage image = ImageViewer.Image;
                    if (image != null)
                    {
                        ChangePixelFormatCommand convertCommand = null;
                        switch (image.PixelFormat)
                        {
                            case PixelFormat.Gray16:
                                convertCommand = new ChangePixelFormatCommand(PixelFormat.Gray8);
                                break;
                        }
                        if (convertCommand != null)                        
                            image = convertCommand.Execute(image);
                        
                        // set settings
                        if (Rectangle.Size.IsEmpty)
                            ReaderSettings.ScanRectangle = Rectangle.Empty;
                        else
                            ReaderSettings.ScanRectangle = Rectangle;

                        // recognize barcodes
                        using (Image bitmap = image.GetAsBitmap())
                            RecognitionResults = _reader.ReadBarcodes(bitmap);
                        
                        if (convertCommand != null)
                            image.Dispose();
                    }
                    else
                    {
                        RecognitionResults = null;
                    }
                }
                else
                {
                    RecognitionResults = null;
                }

            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
            finally
            {
                _isRecognitionStarted = false;
                _isAsyncRecognitionStarted = false;

                if (InvokeRequired)
                    Invoke(new OnRecoginitionFinishedDelegate(OnRecoginitionFinished), EventArgs.Empty);
                else
                    OnRecoginitionFinished(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Starts the asynchronous barcode recognizes.
        /// </summary>
        public void ReadBarcodesAsync()
        {
            if (IsRecognitionStarted)
                throw new InvalidOperationException("Recognition process is executing at this moment.");
            _isAsyncRecognitionStarted = true;
            Thread thread = new Thread(ReadBarcodesSync);
            thread.IsBackground = true;
            thread.Start();
        }


        /// <summary>
        /// Returns a drawing rectangle of visual tool.
        /// </summary>
        /// <param name="viewer">An image viewer.</param>
        public override RectangleF GetDrawingBox(ImageViewer viewer)
        {
            RectangleF drawingBox = base.GetDrawingBox(viewer);
            if (RecognitionResults != null)
            {
                for (int i = 0; i < _recognitionResults.Length; i++)
                    drawingBox = RectangleF.Union(drawingBox, GetDrawBarcodeInfoBoundingBox(_recognitionResults[i]));
            }
            return drawingBox;
        }

        /// <summary>
        /// Draws the selection on specified System.Drawing.Graphics.
        /// </summary>
        /// <param name="viewer">An image viewer.</param>
        /// <param name="g">A graphics where this tool must be drawn.</param>
        public override void Draw(ImageViewer viewer, System.Drawing.Graphics g)
        {
            if (RecognitionResults != null)
            {
                using (Matrix oldTransformation = g.Transform)
                {
                    g.Transform = GraphicsUtils.ConvertToDrawingMatrix(ImageViewer.ViewerState.GetTransformToViewer());
                    for (int i = 0; i < _recognitionResults.Length; i++)
                        DrawBarcodeInfo(g, _recognitionResults[i]);
                    g.Transform = oldTransformation;
                }
            }
            base.Draw(viewer, g);
        }

        #endregion


        #region PROTECTED

        /// <summary>
        /// Returns a bounding box of barcode info's drawing content.
        /// </summary>
        /// <param name="info">A barcode info.</param>
        protected virtual RectangleF GetDrawBarcodeInfoBoundingBox(IBarcodeInfo info)
        {
            RectangleF rectBBox = info.Region.Rectangle;
            Pen pen;
            if (info.BarcodeType != BarcodeType.UnknownLinear &&
                (info.Confidence > 95 || info.Confidence == ReaderSettings.ConfidenceNotAvailable))
                pen = _recognizedBarcodePen;
            else
                pen = _unrecognizedBarcodePen;
            if (pen != null)
                rectBBox.Inflate(pen.Width, pen.Width);

            if (_fontBrush == null || _font == null)
                return rectBBox;

            string text = GetBarcodeInfoAsString(info);
            if (text == null || text == "")
                return rectBBox;

            RectangleF textBBox = new RectangleF(info.Region.LeftTop.X, info.Region.LeftTop.Y - _font.SizeInPoints * 2, 0, _font.Height);
            textBBox.Width = (float)(_font.SizeInPoints * 96.0 / 72.0 * text.Length);
            return RectangleF.Union(rectBBox, textBBox);
        }

        /// <summary>
        /// Draws information about specified barcode info.
        /// </summary>
        /// <param name="g">A graphics where barcode info must be drawn.</param>
        /// <param name="info">A barcode information.</param>
        protected virtual void DrawBarcodeInfo(Graphics g, IBarcodeInfo info)
        {
            Pen pen;
            Brush brush;
            if (info.BarcodeType != BarcodeType.UnknownLinear &&
                (info.Confidence > 95 || info.Confidence == ReaderSettings.ConfidenceNotAvailable))
            {
                pen = _recognizedBarcodePen;
                brush = _recognizedBarcodeBrush;
            }
            else
            {
                pen = _unrecognizedBarcodePen;
                brush = _unrecognizedBarcodeBrush;
            }
            
            if (brush != null)
                g.FillPolygon(brush, info.Region.GetPoints());
            if (pen != null)
                g.DrawPolygon(pen, info.Region.GetPoints());

            if (_fontBrush != null)
                g.DrawString(GetBarcodeInfoAsString(info), _font, _fontBrush, info.Region.LeftTop.X, info.Region.LeftTop.Y - _font.SizeInPoints * 2);
        }

        /// <summary>
        /// Returns information about barcode as text string.
        /// </summary>
        /// <param name="info">A barcode info.</param>
        protected virtual string GetBarcodeInfoAsString(IBarcodeInfo info)
        {
            info.ShowNonDataFlagsInValue = true;
            int index = Array.IndexOf(_recognitionResults, info);
            return string.Format("[{0}]: {1}", index + 1, info.Value);
        }

        /// <summary>
        /// Resets this tool.
        /// </summary>
        protected override void Reset()
        {
            _recognitionResults = null;
            base.Reset();
        }


        /// <summary>
        /// Raises the <see cref="RecognitionStarted"/> event.
        /// </summary>
        /// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
        protected virtual void OnRecoginitionStarted(EventArgs e)
        {
            if (RecognitionStarted != null)
                RecognitionStarted(this, e);
        }

        /// <summary>
        /// Raises the <see cref="RecognitionProgress"/> event.
        /// </summary>
        /// <param name="e">A <see cref="BarcodeReaderProgressEventArgs"/> that
        /// contains the event data.</param>
        protected virtual void OnRecoginitionProgress(BarcodeReaderProgressEventArgs e)
        {
            if (RecognitionProgress != null)
                RecognitionProgress(this, e);
        }

        /// <summary>
        /// Raises the <see cref="RecognitionFinished"/> event.
        /// </summary>
        /// <param name="e">A <see cref="EventArgs"/> that
        /// contains the event data.</param>
        protected virtual void OnRecoginitionFinished(EventArgs e)
        {
            if (RecognitionFinished != null)
                RecognitionFinished(this, e);
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// BarcodeReader.Progress event handler.
        /// </summary>
        private void Reader_Progress(object sender, BarcodeReaderProgressEventArgs e)
        {
            if (InvokeRequired)
                Invoke(new OnRecoginitionProgressDelegate(OnRecoginitionProgress), e);
            else
                OnRecoginitionProgress(e);
        }

        /// <summary>
        /// TransformController interaction logic.
        /// </summary>
        private void TransformController_Interaction(object sender, InteractionEventArgs e)
        {
            // if interact with move area then
            if (e.Area == TransformController.MoveArea)
                if (TransformController.MoveArea.ActionMouseButton == ActionButton)
                {
                    // if action begins then 
                    if ((e.Action & InteractionAreaAction.Begin) != 0)
                    {
                        _needStartBarcodeRecognition = true;
                    }
                    // if action is mowing
                    else if ((e.Action & InteractionAreaAction.Move) != 0)
                    {
                        // change cursor to "move" cursor
                        _needStartBarcodeRecognition = false;
                        TransformController.MoveArea.Cursor = Cursors.SizeAll;
                    }
                    else if ((e.Action & InteractionAreaAction.End) != 0)
                    {
                        if (_needStartBarcodeRecognition)
                        {
                            try
                            {
                                ReadBarcodesAsync();
                            }
                            catch (InvalidOperationException)
                            {
                            }
                            catch (Exception ex)
                            {
                                DemosTools.ShowErrorMessage(ex);
                            }
                            finally
                            {
                                _needStartBarcodeRecognition = false;
                            }
                        }
                        else
                        {
                            TransformController.MoveArea.Cursor = ActionCursor;
                        }
                    }
                    else if ((e.Action & InteractionAreaAction.Cancel) != 0)
                    {
                        TransformController.MoveArea.Cursor = ActionCursor;
                    }
                }
        }

        #endregion

        #endregion



        #region Events

        /// <summary>
        /// Occurs when barcode recognition process is started.
        /// </summary>
        public event EventHandler RecognitionStarted;

        /// <summary>
        /// Occurs when progress of barcode reading is changed. 
        /// </summary>
        /// <remarks>
        /// Used only in
        /// <see cref="Vintasoft.Barcode.ReaderSettings.AutomaticRecognition">Automatic recognition</see>
        /// and
        /// <see cref="Vintasoft.Imaging.Barcode.ReaderSettings.ThresholdIterations">iteration process</see>.
        /// </remarks>
        public event EventHandler<BarcodeReaderProgressEventArgs> RecognitionProgress;

        /// <summary>
        /// Occurs when barcode recognition process is finished.
        /// </summary>
        public event EventHandler RecognitionFinished;

        #endregion



        #region Delegates

        private delegate void OnRecoginitionStartedDelegate(EventArgs e);

        private delegate void OnRecoginitionProgressDelegate(BarcodeReaderProgressEventArgs e);

        private delegate void OnRecoginitionFinishedDelegate(EventArgs e);

        #endregion

    }
}
