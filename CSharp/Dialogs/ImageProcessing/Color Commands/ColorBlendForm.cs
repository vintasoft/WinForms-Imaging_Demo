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
        /// Preview manager for image processing.
        /// </summary>
        ImageProcessingPreviewManager _imageProcessingPreviewInViewer;

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
            colorPickerControl.Color = blendColor;
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets the blend color.
        /// </summary>
        public Color BlendColor
        {
            get
            {
                return colorPickerControl.Color;
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
            ColorBlendCommand command = new ColorBlendCommand(BlendMode, BlendColor);
            _imageProcessingPreviewInViewer.SetCommand(command);
        }

        #endregion


        #region PRIVATE

        #region UI

        /// <summary>
        /// Handles the ColorChanged event of ColorPickerControl object.
        /// </summary>
        private void colorPickerControl_ColorChanged(object sender, EventArgs e)
        {
            if (_imageProcessingPreviewInViewer != null)
                Blend();
        }

        /// <summary>
        /// Handles the SelectedValueChanged event of ComboBoxBlendMode object.
        /// </summary>
        private void comboBoxBlendMode_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_imageProcessingPreviewInViewer != null)
            {
                _blendMode = (BlendingMode)blendModeComboBox.SelectedItem;
                Blend();
            }
        }

        #endregion

        #endregion

        #endregion

    }
}
