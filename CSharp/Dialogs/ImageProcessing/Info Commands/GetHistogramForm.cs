using System;
using System.Drawing;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Info;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view an image histogram.
    /// </summary>
    public partial class GetHistogramForm : Form
    {

        #region Constants

        /// <summary>
        /// Histogram width.
        /// </summary>
        const int HISTOGRAM_IMAGE_WIDTH = 600;

        /// <summary>
        /// Histogram height.
        /// </summary>
        const int HISTOGRAM_IMAGE_HEIGHT = 300;

        /// <summary>
        /// Historgam quiet zone size.
        /// </summary>
        const int HISTOGRAM_IMAGE_QUIET_ZONE_SIZE = 10;

        /// <summary>
        /// Historgam border size.
        /// </summary>
        const int HISTOGRAM_IMAGE_BORDER_SIZE = 1;

        /// <summary>
        /// Historgam data size.
        /// </summary>
        const int HISTOGRAM_DATA_SIZE = 256;

        #endregion



        #region Fields

        /// <summary>
        /// A value indicating whether the processing command need to
        /// convert the processing image to the nearest pixel format without color loss
        /// if processing command does not support pixel format
        /// of the processing image.
        /// </summary>
        bool _expandSupportedPixelFormats = false;

        /// <summary>
        /// The analyzed image.
        /// </summary>
        VintasoftImage _image;

        /// <summary>
        /// Selected image region.
        /// </summary>
        Rectangle _imageRegion;

        /// <summary>
        /// An image with histogram.
        /// </summary>
        VintasoftImage _histogramImage;

        /// <summary>
        /// Selected histogram type.
        /// </summary>
        HistogramType _histogramType = HistogramType.Luminosity;

        /// <summary>
        /// Histogram data.
        /// </summary>
        int[] _histogramData;

        /// <summary>
        /// Image pixel count.
        /// </summary>
        int _pixelCount;

        /// <summary>
        /// Histogram data color.
        /// </summary>
        System.Drawing.Color _histogramColor = System.Drawing.Color.Red;

        /// <summary>
        /// Histogram background color.
        /// </summary>
        System.Drawing.Color _histogramBackground = System.Drawing.Color.White;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GetHistogramForm"/> class.
        /// </summary>
        /// <param name="image">The analyzed image.</param>
        /// <param name="imageRegion">Selected image region.</param>
        /// <param name="expandSupportedPixelFormats">A value indicating whether the processing command need to
        /// convert the processing image to the nearest pixel format.</param>
        public GetHistogramForm(
            VintasoftImage image,
            Rectangle imageRegion,
            bool expandSupportedPixelFormats)
        {
            InitializeComponent();

            _expandSupportedPixelFormats = expandSupportedPixelFormats;
            _image = image;
            _imageRegion = imageRegion;

            if (imageRegion.Size.IsEmpty)
                _pixelCount = image.Width * image.Height;
            else
                _pixelCount = imageRegion.Width * imageRegion.Height;

            _histogramImage = GetHistogramImage(_image, _imageRegion, _histogramType);
            histogramImagePictureBox.Image = _histogramImage.GetAsBitmap();

            histogramTypeComboBox.SelectedIndex = 0;
            pixelCountLabel.Text = string.Format("Pixels: {0}", _pixelCount);
        }

        #endregion



        #region Methods

        #region UI

        /// <summary>
        /// Handles the Click event of closeButton object.
        /// </summary>
        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Handles the MouseMove event of histogramImagePictureBox object.
        /// </summary>
        private void histogramImagePictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int histogramStart = HISTOGRAM_IMAGE_BORDER_SIZE + HISTOGRAM_IMAGE_QUIET_ZONE_SIZE;
            float oneElementWidth = ((float)HISTOGRAM_IMAGE_WIDTH - 2 * HISTOGRAM_IMAGE_QUIET_ZONE_SIZE) / 256;
            int histogramIndex = (int)((x - histogramStart) / oneElementWidth);

            // update values
            if (histogramIndex >= 0 && histogramIndex <= 255)
            {
                levelLabel.Text = string.Format("Level: {0}", histogramIndex);
                countLabel.Text = string.Format("Count: {0}", _histogramData[histogramIndex]);
                percentageLabel.Text = string.Format("Percentage: {0:F2}%", (float)_histogramData[histogramIndex] / _pixelCount * 100);
            }
            else
            {
                levelLabel.Text = "Level:";
                countLabel.Text = "Count:";
                percentageLabel.Text = "Percentage:";
            }
        }

        /// <summary>
        /// Handles the MouseMove event of getHistorgamForm object.
        /// </summary>
        private void getHistorgamForm_MouseMove(object sender, MouseEventArgs e)
        {
            levelLabel.Text = "Level:";
            countLabel.Text = "Count:";
            percentageLabel.Text = "Percentage:";
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of histogramTypeComboBox object.
        /// </summary>
        private void histogramTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            HistogramType histogramType = HistogramType.Luminosity;
            switch (histogramTypeComboBox.SelectedIndex)
            {
                case 1:
                    histogramType = HistogramType.Red;
                    break;

                case 2:
                    histogramType = HistogramType.Green;
                    break;

                case 3:
                    histogramType = HistogramType.Blue;
                    break;
            }

            // if histogram type is changed
            if (_histogramType != histogramType)
            {
                _histogramType = histogramType;

                VintasoftImage oldHistogramImage = _histogramImage;

                // update histogram image
                _histogramImage = GetHistogramImage(_image, _imageRegion, _histogramType);
                histogramImagePictureBox.Image = _histogramImage.GetAsBitmap();

                if (oldHistogramImage != null)
                {
                    oldHistogramImage.Dispose();
                    oldHistogramImage = null;
                }

                Invalidate();
            }
        }

        #endregion


        /// <summary>
        /// Returns an image with histogram.
        /// </summary>
        /// <param name="image">Source image.</param>
        /// <param name="imageRegion">An image region, which should be processed.</param>
        /// <param name="histogramType">Histogram type.</param>
        /// <returns>Image with histogram.</returns>
        private VintasoftImage GetHistogramImage(
            VintasoftImage image,
            Rectangle imageRegion,
            HistogramType histogramType)
        {
            // get histogram data

            GetHistogramCommand command = new GetHistogramCommand(histogramType);
            command.RegionOfInterest = new RegionOfInterest(imageRegion);
            command.ExpandSupportedPixelFormats = _expandSupportedPixelFormats;
            command.Results = new ProcessingCommandResults();
            command.ExecuteInPlace(image);

            GetHistogramCommandResult getHistogramCommandResult = (GetHistogramCommandResult)command.Results[0];
            _histogramData = getHistogramCommandResult.HistogramData;

            // get the maximum value of histogram
            int histogramMaxValue = 0;
            for (int i = 0; i < HISTOGRAM_DATA_SIZE; i++)
            {
                if (histogramMaxValue < _histogramData[i])
                    histogramMaxValue = _histogramData[i];
            }

            // create an image with histogram

            VintasoftImage histogramImage = new VintasoftImage(HISTOGRAM_IMAGE_WIDTH, HISTOGRAM_IMAGE_HEIGHT, PixelFormat.Bgr24);

            int histogramSizeX = HISTOGRAM_IMAGE_WIDTH - 2 * HISTOGRAM_IMAGE_QUIET_ZONE_SIZE;
            int histogramSizeY = HISTOGRAM_IMAGE_HEIGHT - 2 * HISTOGRAM_IMAGE_QUIET_ZONE_SIZE;

            float histogramPenWidth = (float)histogramSizeX / HISTOGRAM_DATA_SIZE;
            Pen histogramPen = new Pen(_histogramColor, histogramPenWidth);
            Brush backgroundBrush = new SolidBrush(_histogramBackground);

            Graphics graphics = histogramImage.OpenGraphics();
            graphics.FillRectangle(backgroundBrush, 0, 0, HISTOGRAM_IMAGE_WIDTH, HISTOGRAM_IMAGE_HEIGHT);
            float x1, y1, x2, y2;
            for (int i = 0; i < HISTOGRAM_DATA_SIZE; i++)
            {
                int v = _histogramData[i];
                x1 = HISTOGRAM_IMAGE_QUIET_ZONE_SIZE + histogramPenWidth * i + histogramPenWidth / 2;
                y1 = HISTOGRAM_IMAGE_HEIGHT - HISTOGRAM_IMAGE_QUIET_ZONE_SIZE;
                x2 = x1;
                y2 = y1 - v * ((float)histogramSizeY / histogramMaxValue);
                if (y2 == y1)
                    y2 = y1 - 1;
                graphics.DrawLine(histogramPen, x1, y1, x2, y2);
            }
            histogramImage.CloseGraphics();


            // return the image with histogram
            return histogramImage;
        }

        #endregion

    }
}
