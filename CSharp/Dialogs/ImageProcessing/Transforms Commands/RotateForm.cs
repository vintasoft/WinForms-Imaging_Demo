using System;
using System.Text;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.ImageProcessing;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and change settings for rotation operation.
    /// </summary>
    public partial class RotateForm : Form
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RotateForm"/> class.
        /// </summary>
        /// <param name="sourceImagePixelFormat">The pixel format of source image.</param>
        public RotateForm(PixelFormat sourceImagePixelFormat)
        {
            InitializeComponent();

            _sourceImagePixelFormat = sourceImagePixelFormat;
        }

        #endregion



        #region Properties

        decimal _angle;
        /// <summary>
        /// Gets the rotation angle.
        /// </summary>
        public decimal Angle
        {
            get { return _angle; }
        }

        /// <summary>
        /// Gets the type of the border color.
        /// </summary>
        public BorderColorType BorderColorType
        {
            get
            {
                if (blackRadioButton.Checked)
                    return BorderColorType.Black;
                else if (whiteRadioButton.Checked)
                    return BorderColorType.White;
                else if (transparentRadioButton.Checked)
                    return BorderColorType.Transparent;
                return BorderColorType.AutoDetect;
            }
        }

        PixelFormat _sourceImagePixelFormat;
        /// <summary>
        /// Gets the pixel format of the source image.
        /// </summary>
        public PixelFormat SourceImagePixelFormat
        {
            get
            {
                return _sourceImagePixelFormat;
            }
        }

        bool _isAntialiasingEnabled = true;
        /// <summary>
        /// Gets a value indicating whether the antialiasing is enabled.
        /// </summary>
        /// <value>
        /// <b>true</b> if the antialiasing is enabled; otherwise, <b>false</b>.
        /// </value>
        public bool IsAntialiasingEnabled
        {
            get
            {
                return _isAntialiasingEnabled;
            }
        }

        #endregion



        #region Methods

        #region UI

        /// <summary>
        /// Handles the Click event of OkButton object.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            _angle = angleNumericUpDown.Value;
            _isAntialiasingEnabled = isAntialiasingEnabledCheckBox.Checked;

            if (transparentRadioButton.Checked &&
                SourceImagePixelFormat != PixelFormat.Bgra32 &&
                SourceImagePixelFormat != PixelFormat.Bgra64)
            {
                PixelFormat pixelFormatWithTransparencySupport = GetPixelFormatWithTransparencySupport(SourceImagePixelFormat);
                StringBuilder message = new StringBuilder();
                message.AppendLine("You have selected a transparent background but image pixel format does not support transparency.");
                message.AppendLine(string.Format("For using transparency the image should be converted to the {0} pixel format.", pixelFormatWithTransparencySupport));
                message.AppendLine("Press 'OK' for converting an image.");
                message.AppendLine("Press 'Cancel' for detecting the color automatically.");

                if (MessageBox.Show(message.ToString(), "Rotate image", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    _sourceImagePixelFormat = pixelFormatWithTransparencySupport;
                }
                else
                {
                    autoDetectRadioButton.Checked = true;
                }
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        #endregion


        /// <summary>
        /// Returns a pixel format, which supports transparency.
        /// </summary>
        /// <param name="sourceImagePixelFormat">The pixel format of the source image.</param>
        /// <returns>The pixel format, which supports transparency.</returns>
        private PixelFormat GetPixelFormatWithTransparencySupport(PixelFormat sourceImagePixelFormat)
        {
            switch (sourceImagePixelFormat)
            {
                case PixelFormat.Bgr48:
                case PixelFormat.Bgra64:
                case PixelFormat.Gray16:
                    return PixelFormat.Bgra64;
            }
            return PixelFormat.Bgra32;
        }

        #endregion

    }
}
