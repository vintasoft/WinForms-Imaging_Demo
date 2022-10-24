using System;
using System.IO;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.ColorManagement;
using Vintasoft.Imaging.ColorManagement.Icc;
using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Color;
using Vintasoft.Imaging.UI;

using DemosCommonCode;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and edit settings of the ColorTransformCommand.
    /// </summary>
    public partial class ColorTransformForm : ParamsConfigForm
    {

        #region Fields

        /// <summary>
        /// Color management decode settings.
        /// </summary>
        ColorManagementDecodeSettings _settings = new ColorManagementDecodeSettings();

        /// <summary>
        /// Image color space format.
        /// </summary>
        ColorSpaceFormat _imageColorSpaceFormat;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorTransformForm"/> class.
        /// </summary>
        /// <param name="viewer">The image viewer for image preview.</param>
        public ColorTransformForm(ImageViewer viewer)
            : base(viewer)
        {
            InitializeComponent();

            // BGR->RGB
            ColorTransform bgrToRgb = new ChannelsOrderConverterTransform(ColorSpaceType.sRGB, new ColorChannelsOrder(2, 1, 0), new ColorChannelsOrder(0, 1, 2));

            // RGB->BGR
            ColorTransform rgbToBgr = new ChannelsOrderConverterTransform(ColorSpaceType.sRGB, new ColorChannelsOrder(0, 1, 2), new ColorChannelsOrder(2, 1, 0));

            // ICC-based color transform
            colorTransformComboBox.Items.Add("ICC-based color transform");

            // RgbToGrayLuminosity
            colorTransformComboBox.Items.Add(FastCompositeColorTransform.Create("Luminosity", bgrToRgb, ColorTransforms.RgbToGrayLuminosity));

            // RgbToGrayAverage
            colorTransformComboBox.Items.Add(FastCompositeColorTransform.Create("Average", bgrToRgb, ColorTransforms.RgbToGrayAverage));

            // RgbToGrayLightness
            colorTransformComboBox.Items.Add(FastCompositeColorTransform.Create("Lightness", bgrToRgb, ColorTransforms.RgbToGrayLightness));

            // GrayToRgb
            colorTransformComboBox.Items.Add(FastCompositeColorTransform.Create("", ColorTransforms.GrayToRgb, rgbToBgr));

            colorTransformComboBox.SelectedIndex = 0;

            _imageColorSpaceFormat = viewer.Image.ColorSpaceFormat;
            this.Text = String.Format("Color Transform ({0})", _imageColorSpaceFormat.ColorSpace);

            renderingIntentComboBox.Items.Add(RenderingIntent.Perceptual);
            renderingIntentComboBox.Items.Add(RenderingIntent.MediaRelativeColorimetric);
            renderingIntentComboBox.Items.Add(RenderingIntent.Saturation);
            renderingIntentComboBox.Items.Add(RenderingIntent.IccAbsoluteColorimetric);

            openFileDialog1.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            useBlackPointCompensationCheckBox.Checked = _settings.UseBlackPointCompensation;
            renderingIntentComboBox.SelectedItem = _settings.RenderingIntent;

            UseCurrentViewerZoomWhenPreviewProcessing = true;
            previewCheckBox.Checked = base.IsPreviewEnabled;
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Returns the image processing command.
        /// </summary>
        /// <returns>The image processing command.</returns>
        public override ProcessingCommandBase GetProcessingCommand()
        {
            ColorTransformCommand command = new ColorTransformCommand();
            _settings.ConstructThreadSafeColorTransforms = true;
            if (colorTransformComboBox.SelectedIndex == 0)
            {
                command.ColorTransform = _settings.GetColorTransform(_imageColorSpaceFormat, _imageColorSpaceFormat);
            }
            else
            {
                command.ColorTransform = (ColorTransform)colorTransformComboBox.SelectedItem;
            }
            return command;
        }

        #endregion


        #region PRIVATE

        #region UI

        /// <summary>
        /// Handles the Click event of InputProfileButton object.
        /// </summary>
        private void inputProfileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                openFileDialog1.InitialDirectory = Path.GetDirectoryName(filePath);

                IccProfile iccProfile = new IccProfile(filePath);
                IccProfile oldProfile = null;

                if (iccProfile.DeviceColorSpace != _imageColorSpaceFormat.ColorSpace)
                {
                    DemosTools.ShowErrorMessage(string.Format("Unexpected profile color space: {0}.\nRequired profile color space: {1}.",
                        iccProfile.DeviceColorSpace, _imageColorSpaceFormat.ColorSpace));
                    oldProfile = iccProfile;
                }
                else
                {
                    if (iccProfile.DeviceColorSpace == ColorSpaceType.sRGB)
                    {
                        oldProfile = _settings.InputRgbProfile;
                        _settings.InputRgbProfile = iccProfile;
                    }
                    else
                    {
                        oldProfile = _settings.InputGrayscaleProfile;
                        _settings.InputGrayscaleProfile = iccProfile;
                    }
                    ExecuteProcessing();
                }

                if (iccProfile != oldProfile)
                    inputProfileTextBox.Text = filePath;

                if (oldProfile != null)
                    oldProfile.Dispose();
            }
        }

        /// <summary>
        /// Handles the Click event of OutputProfileButton object.
        /// </summary>
        private void outputProfileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                openFileDialog1.InitialDirectory = Path.GetDirectoryName(filePath);

                IccProfile iccProfile = new IccProfile(filePath);
                IccProfile oldProfile = null;

                if (iccProfile.DeviceColorSpace != _imageColorSpaceFormat.ColorSpace)
                {
                    DemosTools.ShowErrorMessage(string.Format("Unexpected profile color space: {0}.\nRequired profile color space: {1}.",
                        iccProfile.DeviceColorSpace, _imageColorSpaceFormat.ColorSpace));
                    oldProfile = iccProfile;
                }
                else
                {
                    if (iccProfile.DeviceColorSpace == ColorSpaceType.sRGB)
                    {
                        oldProfile = _settings.InputRgbProfile;
                        _settings.OutputRgbProfile = iccProfile;
                    }
                    else
                    {
                        oldProfile = _settings.InputGrayscaleProfile;
                        _settings.OutputGrayscaleProfile = iccProfile;
                    }
                    ExecuteProcessing();
                }

                if (iccProfile != oldProfile)
                    outputProfileTextBox.Text = filePath;

                if (oldProfile != null)
                    oldProfile.Dispose();
            }
        }

        /// <summary>
        /// Handles the Click event of RemoveInputProfileButton object.
        /// </summary>
        private void removeInputProfileButton_Click(object sender, EventArgs e)
        {
            IccProfile profile = null;
            if (_settings.InputRgbProfile != null)
            {
                profile = _settings.InputRgbProfile;
                _settings.InputRgbProfile = null;
            }
            else if (_settings.InputGrayscaleProfile != null)
            {
                profile = _settings.InputGrayscaleProfile;
                _settings.InputGrayscaleProfile = null;
            }
            if (profile != null)
                profile.Dispose();

            inputProfileTextBox.Text = string.Empty;
            ExecuteProcessing();
        }

        /// <summary>
        /// Handles the Click event of RemoveOutputProfileButton object.
        /// </summary>
        private void removeOutputProfileButton_Click(object sender, EventArgs e)
        {
            IccProfile profile = null;
            if (_settings.OutputRgbProfile != null)
            {
                profile = _settings.OutputRgbProfile;
                _settings.OutputRgbProfile = null;
            }
            else if (_settings.OutputGrayscaleProfile != null)
            {
                profile = _settings.OutputGrayscaleProfile;
                _settings.OutputGrayscaleProfile = null;
            }
            if (profile != null)
                profile.Dispose();

            outputProfileTextBox.Text = string.Empty;
            ExecuteProcessing();
        }

        /// <summary>
        /// Handles the CheckedChanged event of PreviewCheckBox object.
        /// </summary>
        private void previewCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            IsPreviewEnabled = previewCheckBox.Checked;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of RenderingIntentComboBox object.
        /// </summary>
        private void renderingIntentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _settings.RenderingIntent = (RenderingIntent)renderingIntentComboBox.SelectedItem;
            ExecuteProcessing();
        }

        /// <summary>
        /// Handles the CheckedChanged event of UseBlackPointCompensationCheckBox object.
        /// </summary>
        private void useBlackPointCompensationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _settings.UseBlackPointCompensation = useBlackPointCompensationCheckBox.Checked;
            ExecuteProcessing();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of ColorTransformComboBox object.
        /// </summary>
        private void colorTransformComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = colorTransformComboBox.SelectedIndex == 0;
        }

        #endregion

        #endregion

        #endregion

    }
}
