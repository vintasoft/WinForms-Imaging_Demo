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

        const int HISTOGRAM_IMAGE_WIDTH = 600;
        const int HISTOGRAM_IMAGE_HEIGHT = 300;
        const int HISTOGRAM_IMAGE_QUIET_ZONE_SIZE = 10;
        const int HISTOGRAM_IMAGE_BORDER_SIZE = 1;

        const int HISTOGRAM_DATA_SIZE = 256;

        #endregion



        #region Fields

		VintasoftImage _image;

        VintasoftImage _histogramImage;
        HistogramType _histogramType = HistogramType.Luminosity;
        int[] _histogramData;
        
        int _pixelCount;

        System.Drawing.Color _histogramColor = System.Drawing.Color.Red;
        System.Drawing.Color _histogramBackground = System.Drawing.Color.White;

        #endregion



        #region Constructors

        public GetHistogramForm(VintasoftImage image)
        {
            InitializeComponent();

            _image = image;
            _pixelCount = image.Width * image.Height;

            _histogramImage = GetHistogramImage(_image, _histogramType);
            histogramImagePictureBox.Image = _histogramImage.GetAsBitmap();

            histogramTypeComboBox.SelectedIndex = 0;
            pixelCountLabel.Text = string.Format("Pixels: {0}", _pixelCount);
        }

        #endregion



        #region Methods

        private void bOk_Click(object sender, EventArgs e)
		{
			Close();
		}

        /// <summary>
        /// Returns an image with histogram.
        /// </summary>
        /// <param name="image">Source image.</param>
        /// <param name="histogramType">Histogram type.</param>
        /// <returns>Image with histogram.</returns>
        private VintasoftImage GetHistogramImage(VintasoftImage image, HistogramType histogramType)
        {
            // get histogram data

            GetHistogramCommand command = new GetHistogramCommand(histogramType);
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

		private void histogramImage_MouseMove(object sender, MouseEventArgs e)
		{
			int x = e.X;
            int histogramStart = HISTOGRAM_IMAGE_BORDER_SIZE + HISTOGRAM_IMAGE_QUIET_ZONE_SIZE;
            float oneElementWidth = ((float)HISTOGRAM_IMAGE_WIDTH - 2 * HISTOGRAM_IMAGE_QUIET_ZONE_SIZE) / 256;
			int histogramIndex = (int)((x - histogramStart) / oneElementWidth);
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

		private void HistogramDialog_MouseMove(object sender, MouseEventArgs e)
		{
			levelLabel.Text = "Level:";
			countLabel.Text = "Count:";
			percentageLabel.Text = "Percentage:";
		}

        private void cbHistogramType_SelectedIndexChanged(object sender, EventArgs e)
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

            if (_histogramType != histogramType)
            {
                _histogramType = histogramType;

                VintasoftImage oldHistogramImage = _histogramImage;

                _histogramImage = GetHistogramImage(_image, _histogramType);
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

    }
}