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
    /// A form that allows to specify parameters for color blend command.
    /// </summary>
    public partial class ColorBlendForm : Form
    {

        #region Fields

        // color components
        int _r, _g, _b, _a;

        ImageProcessingPreviewManager _imageProcessingPreviewInViewer;

        bool _disableBlending = true;

        #endregion



        #region Constructor

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
        public Color BlendColor
        {
            get
            {
                return _blendColor;
            }
        }

        BlendingMode _blendMode;
        public BlendingMode BlendMode
        {
            get
            {
                return _blendMode;
            }
        }

        #endregion



        #region Methods

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
        /// Blend the thumbnail.
        /// </summary>
        public void Blend()
        {
            if (_disableBlending)
                return;

            ColorBlendCommand command = new ColorBlendCommand(_blendMode, _blendColor);
            _imageProcessingPreviewInViewer.SetCommand(command);
        }

        private void channel_ValueChanged(object sender, EventArgs e)
        {
            if (_disableBlending)
                return;
            SetColor();
            Blend();
        }

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
        /// Blend two color with alpha component.
        /// </summary>
        private Color BlendColors(Color sourceColor, Color blendColor)
        {
            int alpha = blendColor.A;
            return Color.FromArgb(
                (sourceColor.R * (255 - alpha)) / 255 + (blendColor.R * alpha) / 255,
                (sourceColor.G * (255 - alpha)) / 255 + (blendColor.G * alpha) / 255,
                (sourceColor.B * (255 - alpha)) / 255 + (blendColor.B * alpha) / 255);
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void comboBoxBlendMode_SelectedValueChanged(object sender, EventArgs e)
        {
            _blendMode = (BlendingMode)blendModeComboBox.SelectedItem;
            Blend();
        }

        #endregion

    }
}
