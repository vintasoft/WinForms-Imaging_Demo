using System;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.ImageProcessing;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and edit settings of the ChangePixelFormatCommand.
    /// </summary>
    public partial class ChangePixelFormatForm : Form
    {

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangePixelFormatForm"/> class.
        /// </summary>
        public ChangePixelFormatForm()
        {
            InitializeComponent();
        }

        #endregion



        #region Properties

        Vintasoft.Imaging.PixelFormat _pixelFormat;
        /// <summary>
        /// Gets the pixel format.
        /// </summary>
		public Vintasoft.Imaging.PixelFormat PixelFormat
        {
            get { return _pixelFormat; }
        }

        PaletteType _paletteType = PaletteType.Adaptive;
        /// <summary>
        /// Gets the palette type.
        /// </summary>
        public PaletteType PaletteType
        {
            get { return _paletteType; }
        }

        #endregion



        #region Methods

        #region UI

        /// <summary>
        /// Handles the Click event of okButton object.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            switch (pixelFormatComboBox.SelectedIndex)
            {
                case 0:
                    _pixelFormat = Vintasoft.Imaging.PixelFormat.BlackWhite;
                    break;

                case 1:
                    _pixelFormat = Vintasoft.Imaging.PixelFormat.Indexed1;
                    break;

                case 2:
                    _pixelFormat = Vintasoft.Imaging.PixelFormat.Indexed4;
                    break;

                case 3:
                    _pixelFormat = Vintasoft.Imaging.PixelFormat.Indexed8;
                    break;

                case 4:
                    _pixelFormat = Vintasoft.Imaging.PixelFormat.Gray8;
                    break;

                case 5:
                    _pixelFormat = Vintasoft.Imaging.PixelFormat.Indexed8;
                    _paletteType = PaletteType.Web;
                    break;

                case 6:
                    _pixelFormat = Vintasoft.Imaging.PixelFormat.Gray16;
                    break;

                case 7:
                    _pixelFormat = Vintasoft.Imaging.PixelFormat.Bgr555;
                    break;

                case 8:
                    _pixelFormat = Vintasoft.Imaging.PixelFormat.Bgr565;
                    break;

                case 9:
                    _pixelFormat = Vintasoft.Imaging.PixelFormat.Bgr24;
                    break;

                case 10:
                    _pixelFormat = Vintasoft.Imaging.PixelFormat.Bgra32;
                    break;

                case 11:
                    _pixelFormat = Vintasoft.Imaging.PixelFormat.Bgr32;
                    break;

                case 12:
                    _pixelFormat = Vintasoft.Imaging.PixelFormat.Bgr48;
                    break;

                case 13:
                    _pixelFormat = Vintasoft.Imaging.PixelFormat.Bgra64;
                    break;

                default:
                    MessageBox.Show("You should select the pixel format first.");
                    return;
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        /// <summary>
        /// Handles the Click event of cancelButton object.
        /// </summary>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        #endregion

        #endregion

    }
}
