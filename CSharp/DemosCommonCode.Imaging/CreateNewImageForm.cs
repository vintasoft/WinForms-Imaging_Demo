using System;
using System.Windows.Forms;

using Vintasoft.Imaging;


namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A form that allows to specify parameters of new image.
    /// </summary>
    public partial class CreateNewImageForm : Form
    {

        #region Fields

        ImageSize _imageSize = null;
        PixelFormat _pixelFormat;

        #endregion



        #region Constructor

        public CreateNewImageForm()
        {
            InitializeComponent();

            pixelFormatComboBox.Items.Add(PixelFormat.BlackWhite);
            pixelFormatComboBox.Items.Add(PixelFormat.Indexed1);
            pixelFormatComboBox.Items.Add(PixelFormat.Indexed4);
            pixelFormatComboBox.Items.Add(PixelFormat.Indexed8);
            pixelFormatComboBox.Items.Add(PixelFormat.Gray8);
            pixelFormatComboBox.Items.Add(PixelFormat.Gray16);
            pixelFormatComboBox.Items.Add(PixelFormat.Bgr555);
            pixelFormatComboBox.Items.Add(PixelFormat.Bgr565);
            pixelFormatComboBox.Items.Add(PixelFormat.Bgr24);
            pixelFormatComboBox.Items.Add(PixelFormat.Bgr32);
            pixelFormatComboBox.Items.Add(PixelFormat.Bgra32);
            pixelFormatComboBox.Items.Add(PixelFormat.Bgr48);
            pixelFormatComboBox.Items.Add(PixelFormat.Bgra64);

            pixelFormatComboBox.SelectedItem = PixelFormat.Bgr24;

            horizontalResolutionTextBox.Text = Resolution.ScreenResolution.Horizontal.ToString();
            verticalResolutionTextBox.Text = Resolution.ScreenResolution.Vertical.ToString();

            SetImageParams(Resolution.ScreenResolution);
        }

        #endregion



        #region Methods

        #region PUBLIC

        public VintasoftImage CreateImage()
        {
            VintasoftImage image = new VintasoftImage(_imageSize, _pixelFormat);

            Palette palette = null;
            if (_pixelFormat == PixelFormat.Indexed1)
                palette = Palette.CreateBlackWhitePalette();
            else if (_pixelFormat == PixelFormat.Indexed4)
                palette = Palette.CreateGrayscalePalette(16);
            else if (_pixelFormat == PixelFormat.Indexed8)
                palette = Palette.CreateGrayscalePalette();
            
            if (palette != null)
                image.Palette.SetColors(palette.GetAsArray());

            return image;
        }

        #endregion


        #region PRIVATE

        private void SetImageParams(Resolution resolution)
        {
            int widthImage = Convert.ToInt32(widthImageNumericUpDown.Value);
            int heightImage = Convert.ToInt32(heightImageNumericUpDown.Value);
            _imageSize = ImageSize.FromPixels(widthImage, heightImage, resolution);

            _pixelFormat = (PixelFormat)pixelFormatComboBox.SelectedItem;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            float horizontalResolution;
            if (!float.TryParse(horizontalResolutionTextBox.Text, out horizontalResolution))
            {
                MessageBox.Show("Horizontal resolution value is incorrect!", "Create new image");
                horizontalResolutionTextBox.Focus();
                horizontalResolutionTextBox.SelectAll();
                return;
            }
            else if (horizontalResolution <= 0)
            {
                MessageBox.Show("Horizontal resolution value is incorrect!", "Create new image");
                horizontalResolutionTextBox.Focus();
                horizontalResolutionTextBox.SelectAll();
                return;
            }

            float verticalResolution;
            if (!float.TryParse(verticalResolutionTextBox.Text, out verticalResolution))
            {
                MessageBox.Show("Vertical resolution value is incorrect!", "Create new image");
                verticalResolutionTextBox.Focus();
                verticalResolutionTextBox.SelectAll();
                return;
            }
            else if (verticalResolution <= 0)
            {
                MessageBox.Show("Vertical resolution value is incorrect!", "Create new image");
                verticalResolutionTextBox.Focus();
                verticalResolutionTextBox.SelectAll();
                return;
            }

            Resolution resolution = new Resolution(horizontalResolution, verticalResolution);
            SetImageParams(resolution);

            DialogResult = DialogResult.OK;
        }

        #endregion

        #endregion

    }
}
