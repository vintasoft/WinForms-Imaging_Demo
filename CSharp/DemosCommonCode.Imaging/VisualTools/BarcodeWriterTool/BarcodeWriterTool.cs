using System;
using System.Drawing;
using System.Drawing.Drawing2D;

using Vintasoft.Barcode;
using Vintasoft.Imaging;
using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.UI.VisualTools;
using Vintasoft.Imaging.UI.VisualTools.UserInteraction;
using Vintasoft.Imaging.UI;
using Vintasoft.Imaging.Utils;

namespace DemosCommonCode.Barcode
{
    /// <summary>
    /// Visual tool for barcode generation on image in image viewer.
    /// </summary>
    public class BarcodeWriterTool : RectangularSelectionTool
    {

        #region Fields

        /// <summary>
        /// Barcode writer.
        /// </summary>
        BarcodeWriter _writer;

        /// <summary>
        /// Panel with buttons.
        /// </summary>
        InteractionButtonsPanel _controlButtonsPanel;

        /// <summary>
        /// Button for refreshing the barcode image.
        /// </summary>
        InteractionButton _refreshBarcodeButton;
        /// <summary>
        /// Indicates that the image for "Refresh barcode" button must be disposed after use.
        /// </summary>
        bool _disposeRefreshBarcodeButtonImageAfterUse = true;

        /// <summary>
        /// Button for drawing the barcode image.
        /// </summary>
        InteractionButton _drawBarcodeButton;
        /// <summary>
        /// Indicates that the image for "Draw barcode" button must be disposed after use.
        /// </summary>
        bool _disposeDrawBarcodeButtonImageAfterUse = true;

        /// <summary>
        /// Barcode image rectangle which was used for aligning the selection region of tool
        /// on previous step.
        /// </summary>
        Rectangle _alignedRectangle;

        /// <summary>
        /// Determines that barcode image must be recreated when transformation is finished.
        /// </summary>
        bool _needBuildBarcodeImage = false;

        /// <summary>
        /// Determines when barcode generator settings is changing.
        /// </summary>
        bool _settingsChanging = false;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BarcodeWriterTool"/> class. 
        /// </summary>
        public BarcodeWriterTool()
        {
            _writer = new BarcodeWriter();
            _writer.Settings.Changed += new EventHandler(Settings_Changed);
            _writer.Settings.PixelFormat = BarcodeImagePixelFormat.Bgra32;

            base.Cursor = System.Windows.Forms.Cursors.Cross;
            base.ActionCursor = base.Cursor;

            RectangularObjectTransformer transformer = new RectangularObjectTransformer(this);
            transformer.HideInteractionPointsWhenMoving = true;
            TransformController = transformer;

            // create the "Refresh barcode" button
            _refreshBarcodeButton = new InteractionButton(this);
            _refreshBarcodeButton.Image = DemosResourcesManager.GetResourceAsImage(
                @"DemosCommonCode.Imaging.VisualTools.BarcodeWriterTool.Resources.RefreshBarcodeImage.png");
            // create the "Draw barcode" button
            _drawBarcodeButton = new InteractionButton(this);
            _drawBarcodeButton.Image = DemosResourcesManager.GetResourceAsImage(
                @"DemosCommonCode.Imaging.VisualTools.BarcodeWriterTool.Resources.DrawBarcodeImage.png");
            // create the panel with buttons
            _controlButtonsPanel = new InteractionButtonsPanel(this, _refreshBarcodeButton, _drawBarcodeButton);
            _controlButtonsPanel.Interaction += new EventHandler<InteractionEventArgs>(ControlButtonsPanel_Interaction);
        }

        #endregion



        #region Properties

        #region PUBLIC

        /// <summary>
        /// Gets the name of visual tool.
        /// </summary>
        public override string Name
        {
            get
            {
                return "Barcode writer tool";
            }
        }

        /// <summary>
        /// Gets the value indicating whether this visual tool can modify the image.
        /// </summary>
        public override bool CanModifyImage
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets or sets an interaction controller of barcode writer tool.
        /// </summary>
        public override IInteractionController InteractionController
        {
            get
            {
                return base.InteractionController;
            }
            set
            {
                if (value != null && value == TransformController)
                    value = new CompositeInteractionController(value, _controlButtonsPanel);
                base.InteractionController = value;
            }
        }

        /// <summary>
        /// Gets or sets an image for button that refreshes the barcode image.
        /// </summary>
        public VintasoftImage RefreshBarcodeButtonImage
        {
            get
            {
                return _refreshBarcodeButton.Image;
            }
            set
            {
                if (RefreshBarcodeButtonImage != value)
                {
                    if (_disposeRefreshBarcodeButtonImageAfterUse)
                    {
                        _disposeRefreshBarcodeButtonImageAfterUse = false;
                        _refreshBarcodeButton.Image.Dispose();
                    }
                    _refreshBarcodeButton.Image = value;
                    InvalidateViewer();
                }
            }
        }


        /// <summary>
        /// Gets or sets an image for button that draws a barcode image on the image.
        /// </summary>
        public VintasoftImage DrawBarcodeButtonImage
        {
            get
            {
                return _drawBarcodeButton.Image;
            }
            set
            {
                if (DrawBarcodeButtonImage != value)
                {
                    if (_disposeDrawBarcodeButtonImageAfterUse)
                    {
                        _disposeDrawBarcodeButtonImageAfterUse = false;
                        _drawBarcodeButton.Image.Dispose();
                    }
                    _drawBarcodeButton.Image = value;
                    InvalidateViewer();
                }
            }
        }

        /// <summary>
        /// Gets or sets the barcode writer settings.
        /// </summary>
        public WriterSettings WriterSettings
        {
            get
            {
                return _writer.Settings;
            }
            set
            {
                if (_writer.Settings != value)
                {
                    _writer.Settings.Changed -= new EventHandler(Settings_Changed);
                    _writer.Settings = value;
                    _writer.Settings.Changed += new EventHandler(Settings_Changed);
                }
            }
        }

        #endregion


        #region PRIVATE

        VintasoftImage _barcodeImage;
        /// <summary>
        /// Gets or sets a current barcode image.
        /// </summary>
        private VintasoftImage BarcodeImage
        {
            get
            {
                return _barcodeImage;
            }
            set
            {
                VintasoftImage image = _barcodeImage;
                _barcodeImage = value;
                if (image != null)
                    image.Dispose();
            }
        }

        #endregion

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Returns barcode as <see cref="VintasoftImage"/>.
        /// </summary>
        public VintasoftImage GetBarcodeImage()
        {
            return new VintasoftImage(_writer.GetBarcodeAsBitmap(), true);
        }

        /// <summary>
        /// Returns barcode as <see cref="GraphicsPath"/>.
        /// </summary>
        public GraphicsPath GetBarcodeGraphicsPath()
        {
            return _writer.GetBarcodeAsGraphicsPath();
        }

        /// <summary>
        /// Refreshes the current barcode image.
        /// </summary>
        /// <param name="needAlignRectangleSize">
        /// Indicates that the selection rectangle of this tool must be aligned to the barcode image.
        /// </param>
        public void RefreshBarcodeImage(bool needAlignRectangleSize)
        {
            // if selection is empty
            if (Rectangle.Width <= 0 || Rectangle.Height <= 0)
            {
                BarcodeImage = null;
                return;
            }

            // determines that selection region of tool was aligned to the barcode image on previous step
            bool currentRectangeIsNotAligned = _alignedRectangle.Size != Rectangle.Size;

            // if tool selection region is not aligned on barcode image
            if (currentRectangeIsNotAligned)
            {
                _settingsChanging = true;
                if (WriterSettings.Barcode == BarcodeType.MaxiCode)
                {
                    _writer.Settings.MaxiCodeResolution = (int)(Rectangle.Width / 30.0) * 30;
                }
                else
                {
                    int width = Rectangle.Width - WriterSettings.Padding * WriterSettings.MinWidth * 2;
                    int height = Rectangle.Height - WriterSettings.Padding * WriterSettings.MinWidth * 2;
                    if (width <= 0 || height <= 0)
                    {
                        BarcodeImage = null;
                        return;
                    }

                    bool is2dBarcode =
                        WriterSettings.Barcode == BarcodeType.MicroQR ||
                        WriterSettings.Barcode == BarcodeType.QR ||
                        WriterSettings.Barcode == BarcodeType.PDF417 ||
                        WriterSettings.Barcode == BarcodeType.PDF417Compact ||
                        WriterSettings.Barcode == BarcodeType.DataMatrix ||
                        WriterSettings.Barcode == BarcodeType.Aztec ||
                        WriterSettings.Barcode == BarcodeType.HanXinCode ||
                        WriterSettings.Barcode == BarcodeType.MaxiCode;

                    if ((is2dBarcode && WriterSettings.Value2DVisible) ||
                        (!is2dBarcode && WriterSettings.ValueVisible))
                    {
                        int valueGap = 0;
                        if (WriterSettings.ValueGap > 0)
                            valueGap = WriterSettings.ValueGap;
                        height -= valueGap + WriterSettings.ValueFont.Height;
                    }

                    _writer.Settings.SetWidth(width);
                    _writer.Settings.Height = height;
                }
                _settingsChanging = false;
            }

            // generate the barcode image
            try
            {
                BarcodeImage = new VintasoftImage(_writer.GetBarcodeAsBitmap(), true);
            }
            catch (WriterSettingsException ex)
            {
                // generate image with error message
                VintasoftImage errorMessageImage = new VintasoftImage(Rectangle.Width, Rectangle.Height);
                Graphics g = errorMessageImage.OpenGraphics();
                g.Clear(Color.White);
                Rectangle rect = new Rectangle(0, 0, errorMessageImage.Width - 1, errorMessageImage.Height - 1);
                g.DrawRectangle(Pens.Red, rect);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                g.DrawString(string.Format("WriterSettingsException:\n{0}", ex.Message), ImageViewer.Font, Brushes.Red, rect, format);
                errorMessageImage.CloseGraphics();
                BarcodeImage = errorMessageImage;
            }

            // if selection region of tool must be aligned to the barcode image AND
            // selection region of tool is not aligned on barcode image
            if (needAlignRectangleSize && currentRectangeIsNotAligned)
            {
                Rectangle = new Rectangle(Rectangle.X, Rectangle.Y, BarcodeImage.Width, BarcodeImage.Height);
                _alignedRectangle = Rectangle;
            }
        }

        /// <summary>
        /// Draws the barcode image on an image in image viewer.
        /// </summary>
        public void DrawBarcodeImage()
        {
            if (ImageViewer != null &&
                ImageViewer.Image != null &&
                BarcodeImage != null &&
                !Rectangle.Size.IsEmpty)
            {
                VintasoftImage image = ImageViewer.Image;

                OnImageChanging(new ImageChangedEventArgs(image));

                VintasoftImage barcodeImage = BarcodeImage;
                bool needDisposeBarcodeImage = false;

                Rectangle barcodeRect = GetDestBarcodeImageRectangle();

                // if image size not equals with rectangle size
                if (barcodeRect.Width != BarcodeImage.Width || barcodeRect.Height != BarcodeImage.Height)
                {
                    // resize barcode image
                    needDisposeBarcodeImage = true;
                    ResizeCommand resize = new ResizeCommand(barcodeRect.Width, barcodeRect.Height);
                    barcodeImage = resize.Execute(barcodeImage);
                }

                // draw barcode image on viewer image
                OverlayCommand overaly = new OverlayCommand(barcodeImage, barcodeRect.Location);
                overaly.ExecuteInPlace(image);

                if (needDisposeBarcodeImage)
                    barcodeImage.Dispose();

                Rectangle = Rectangle.Empty;

                OnImageChanged(new ImageChangedEventArgs(image));
            }
        }

        /// <summary>
        /// Draws the visual tool on specified <see cref="Graphics"/>.
        /// </summary>
        /// <param name="viewer">An image viewer.</param>
        /// <param name="g">A graphics where this tool must be drawn.</param>
        public override void Draw(ImageViewer viewer, Graphics g)
        {
            if (BarcodeImage == null)
                RefreshBarcodeImage(false);
            if (BarcodeImage != null)
            {
                using (Matrix oldTransformation = g.Transform)
                {
                    g.Transform = VintasoftDrawingConverter.Convert(ImageViewer.ViewerState.GetTransformToViewer());
                    BarcodeImage.Draw(g, GetDestBarcodeImageRectangle());
                    g.Transform = oldTransformation;
                }
            }
            else
            {
                base.Draw(viewer, g);
            }
        }

        #endregion


        #region PROTECTED

        /// <summary>
        /// Raises the interaction event for specified interactive object.
        /// </summary>
        /// <param name="item">The interactive object.</param>
        /// <param name="args">The interaction event args.</param>
        protected override bool OnInteraction(IInteractiveObject item, InteractionEventArgs args)
        {
            bool result = base.OnInteraction(item, args);
            if ((args.Action & InteractionAreaAction.Begin) != 0)
            {
                string interactionName = args.Area.InteractionName;
                if (interactionName == "Resize" || interactionName == "Build")
                    _needBuildBarcodeImage = true;
            }
            return result;
        }

        /// <summary>
        /// Finishes an active interaction.
        /// </summary>
        /// <param name="item">Active item.</param>
        /// <param name="invalidateItem">Need invalidate active item.</param>
        protected override void FinishInteraction(IInteractiveObject item, bool invalidateItem)
        {
            base.FinishInteraction(item, invalidateItem);
            if (_needBuildBarcodeImage)
            {
                RefreshBarcodeImage(false);
                _needBuildBarcodeImage = false;
            }
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// Returns a rectangle where barcode must be drawn.
        /// </summary>
        private Rectangle GetDestBarcodeImageRectangle()
        {
            BarcodeType barcode = WriterSettings.Barcode;

            bool needMaintainAspectRatio = false;
            switch (barcode)
            {
                case BarcodeType.Aztec:
                case BarcodeType.QR:
                case BarcodeType.MicroQR:
                case BarcodeType.DataMatrix:
                case BarcodeType.PDF417:
                case BarcodeType.PDF417Compact:
                case BarcodeType.MaxiCode:
                    needMaintainAspectRatio = true;
                    break;
            }
            // if we do not need to maintain the aspect ratio
            if (!needMaintainAspectRatio)
                // return the selection region of this tool as rectangle where barcode must be drawn
                return Rectangle;

            double imageWidth = BarcodeImage.Width;
            double imageHeight = BarcodeImage.Height;
            double rectWidth = Rectangle.Width;
            double rectHeight = Rectangle.Height;
            double k = Math.Min(rectWidth / imageWidth, rectHeight / imageHeight);
            imageWidth *= k;
            imageHeight *= k;
            return new Rectangle(
                (int)Math.Round(Rectangle.X + (Rectangle.Width - imageWidth) / 2),
                (int)Math.Round(Rectangle.Y + (Rectangle.Height - imageHeight) / 2),
                (int)Math.Round(imageWidth),
                (int)Math.Round(imageHeight)
                );
        }

        /// <summary>
        /// User is interacted with control panel.
        /// </summary>
        private void ControlButtonsPanel_Interaction(object sender, InteractionEventArgs e)
        {
            if (e.Action == InteractionAreaAction.Begin)
            {
                if (e.Area == _refreshBarcodeButton)
                    RefreshBarcodeImage(true);
                else if (e.Area == _drawBarcodeButton)
                    DrawBarcodeImage();
            }
        }

        /// <summary>
        /// Barcode writer settings are changed.
        /// </summary>
        private void Settings_Changed(object sender, EventArgs e)
        {
            if (!_settingsChanging)
            {
                _alignedRectangle = Rectangle.Empty;
                RefreshBarcodeImage(false);
                InvalidateItem(this);
            }
        }

        #endregion

        #endregion

    }
}
