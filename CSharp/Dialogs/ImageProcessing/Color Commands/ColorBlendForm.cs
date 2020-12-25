using System;
using System.Drawing;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Color;
using Vintasoft.Imaging.ImageProcessing.Transforms;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and edit settings of the ColorBlendCommand.
    /// </summary>
    public partial class ColorBlendForm : Form
    {

        #region Fields

        /// <summary>
        /// Red channel component.
        /// </summary>
        int _r;

        /// <summary>
        /// Green channel component.
        /// </summary>
        int _g;

        /// <summary>
        /// Blue channel component.
        /// </summary>
        int _b;

        /// <summary>
        /// Alpha channel component.
        /// </summary>
        int _a;

        /// <summary>
        /// Preview manager for image processing.
        /// </summary>
        ImageProcessingPreviewManager _imageProcessingPreviewInViewer;

        /// <summary>
        /// A value indicating whether the color blending functionality must be disabled.
        /// </summary>
        bool _disableBlending = true;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AdaptiveBinarizeForm"/> class.
        /// </summary>
        /// <param name="viewer">The image viewer for image preview.</param>
        /// <param name="rect">Selection rectangle.</param>
        /// <param name="blendColor">Blend color.</param>
        /// <param name="blendMode">Blending mode.</param>
        public ColorBlendForm(ImageViewer viewer, Rectangle rect, Color blendColor, BlendingMode blendMode)
        {
            InitializeComponent();

            _imageProcessingPreviewInViewer = new ImageProcessingPreviewManager(viewer);
            _imageProcessingPreviewInViewer.UseCurrentViewerZoomWhenPreviewProcessing = true;

            _blendMode = blendMode;

            // set available blending modes 
            Array values = Enum.GetValues(typeof(BlendingMode));
            object[] vals = new object[values.Length];
            values.CopyTo(vals, 0);
            blendModeComboBox.Items.AddRange(vals);
            blendModeComboBox.SelectedItem = blendMode;

            // set blend color
            channelAlphaTrackBar.Value = blendColor.A;
            channelRedTrackBar.Value = blendColor.R;
            channelGreenTrackBar.Value = blendColor.G;
            channelBlueTrackBar.Value = blendColor.B;

            _disableBlending = false;
            SetColor();
        }

        #endregion



        #region Properties

        Color _blendColor;
        /// <summary>
        /// Gets the blend color.
        /// </summary>
        public Color BlendColor
        {
            get
            {
                return _blendColor;
            }
        }

        BlendingMode _blendMode;
        /// <summary>
        /// Gets the blending mode.
        /// </summary>
        public BlendingMode BlendMode
        {
            get
            {
                return _blendMode;
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Shows this dialog.
        /// </summary>
        /// <returns><b>True</b> if the color blending confirmed, otherwise - <b>false</b>.</returns>
        public bool ShowProcessingDialog()
        {
            try
            {
                _imageProcessingPreviewInViewer.StartPreview();
                Blend();
            }
            catch (ImageProcessingException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            bool result = ShowDialog() == DialogResult.OK;
            _imageProcessingPreviewInViewer.StopPreview();
            return result;
        }

        /// <summary>
        /// Blends an image.
        /// </summary>
        public void Blend()
        {
            if (_disableBlending)
                return;

            ColorBlendCommand command = new ColorBlendCommand(_blendMode, _blendColor);
            _imageProcessingPreviewInViewer.SetCommand(command);
        }

        #endregion


        #region PRIVATE

        #region UI

        /// <summary>
        /// Handles the ValueChanged event of Channel object.
        /// </summary>
        private void channel_ValueChanged(object sender, EventArgs e)
        {
            if (_disableBlending)
                return;
            SetColor();
            Blend();
        }

        /// <summary>
        /// Handles the Click event of OkButton object.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Handles the Click event of CancelButton object.
        /// </summary>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Handles the SelectedValueChanged event of ComboBoxBlendMode object.
        /// </summary>
        private void comboBoxBlendMode_SelectedValueChanged(object sender, EventArgs e)
        {
            _blendMode = (BlendingMode)blendModeComboBox.SelectedItem;
            Blend();
        }

        #endregion


        /// <summary>
        /// Updates the channels component values.
        /// </summary>
        private void SetColor()
        {
            if (lockRgbCheckBox.Checked)
            {
                // lock RGB channels
                _disableBlending = true;
                int dx = 0;
                if (_r != channelRedTrackBar.Value)
                {
                    dx = channelRedTrackBar.Value - _r;
                }
                else if (_g != channelGreenTrackBar.Value)
                {
                    dx = channelGreenTrackBar.Value - _g;
                }
                else if (_b != channelBlueTrackBar.Value)
                {
                    dx = channelBlueTrackBar.Value - _b;
                }
                _r = Math.Min(255, Math.Max(0, _r + dx));
                _g = Math.Min(255, Math.Max(0, _g + dx));
                _b = Math.Min(255, Math.Max(0, _b + dx));
                channelRedTrackBar.Value = _r;
                channelGreenTrackBar.Value = _g;
                channelBlueTrackBar.Value = _b;
                _disableBlending = false;
            }
            else
            {
                _r = channelRedTrackBar.Value;
                _g = channelGreenTrackBar.Value;
                _b = channelBlueTrackBar.Value;
            }

            // show colors information

            _a = channelAlphaTrackBar.Value;
            _blendColor = Color.FromArgb(_a, Color.FromArgb(_r, _g, _b));

            labelAlpha.Text = _a.ToString();
            labelAlpha.ForeColor = BlendColors(BackColor, Color.FromArgb(_a, Color.Black));

            labelRed.Text = _r.ToString();
            labelRed.ForeColor = Color.FromArgb(_r, 0, 0);

            labelGreen.Text = _g.ToString();
            labelGreen.ForeColor = Color.FromArgb(0, _g, 0);

            labelBlue.Text = _b.ToString();
            labelBlue.ForeColor = Color.FromArgb(0, 0, _b);

            blackColorPanel.BackColor = BlendColors(Color.Black, _blendColor);
            whiteColorPanel.BackColor = BlendColors(Color.White, _blendColor);
        }

        /// <summary>
        /// Blends two colors with alpha component.
        /// </summary>
        /// <returns>Result color.</returns>
        private Color BlendColors(Color sourceColor, Color blendColor)
        {
            int alpha = blendColor.A;
            return Color.FromArgb(
                (sourceColor.R * (255 - alpha)) / 255 + (blendColor.R * alpha) / 255,
                (sourceColor.G * (255 - alpha)) / 255 + (blendColor.G * alpha) / 255,
                (sourceColor.B * (255 - alpha)) / 255 + (blendColor.B * alpha) / 255);
        }

        #endregion

        #endregion

    }
}
