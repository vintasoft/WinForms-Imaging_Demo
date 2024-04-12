using System;
using System.Drawing;
using Vintasoft.Imaging;
using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Fft.Filtering;
using Vintasoft.Imaging.ImageProcessing.Fft.Filters;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and edit settings for ImageSmoothingCommand.
    /// </summary>
    public partial class ImageSmoothingForm : ParamsConfigForm
    {

        #region Fields

        /// <summary>
        /// Blending mode.
        /// </summary>
        BlendingMode _blendingMode = BlendingMode.Normal;

        /// <summary>
        /// Type of frequency filter.
        /// </summary>
        FrequencyFilterType _filter = FrequencyFilterType.Gaussian;

        /// <summary>
        /// A value indicating whether the grayscale filtration must be used.
        /// </summary>
        bool _useGrayscaleFiltration = false;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageSmoothingForm"/> class.
        /// </summary>
        public ImageSmoothingForm()
            : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageSmoothingForm"/> class.
        /// </summary>
        /// <param name="viewer">The image viewer for image preview.</param>
        public ImageSmoothingForm(ImageViewer viewer)
            : base(viewer)
        {
            InitializeComponent();

            // disable preview
            IsPreviewEnabled = false;

            // blending mode combo box
            blendingModeComboBox.Items.Add(BlendingMode.Normal);
            blendingModeComboBox.Items.Add(BlendingMode.Multiply);
            blendingModeComboBox.Items.Add(BlendingMode.Screen);
            blendingModeComboBox.Items.Add(BlendingMode.Overlay);
            blendingModeComboBox.Items.Add(BlendingMode.Darken);
            blendingModeComboBox.Items.Add(BlendingMode.Lighten);
            blendingModeComboBox.Items.Add(BlendingMode.ColorDodge);
            blendingModeComboBox.Items.Add(BlendingMode.ColorBurn);
            blendingModeComboBox.Items.Add(BlendingMode.HardLight);
            blendingModeComboBox.Items.Add(BlendingMode.SoftLight);
            blendingModeComboBox.Items.Add(BlendingMode.Difference);
            blendingModeComboBox.Items.Add(BlendingMode.Exclusion);
            blendingModeComboBox.Items.Add(BlendingMode.Hue);
            blendingModeComboBox.Items.Add(BlendingMode.Saturation);
            blendingModeComboBox.Items.Add(BlendingMode.Color);
            blendingModeComboBox.Items.Add(BlendingMode.Luminosity);
            blendingModeComboBox.Items.Add(BlendingMode.Brightness);
            blendingModeComboBox.Items.Add(BlendingMode.Contrast);
            blendingModeComboBox.Items.Add(BlendingMode.Gamma);
            blendingModeComboBox.Items.Add(BlendingMode.Min);
            blendingModeComboBox.Items.Add(BlendingMode.Max);
            blendingModeComboBox.Items.Add(BlendingMode.Sum);
            blendingModeComboBox.Items.Add(BlendingMode.Sub);
            blendingModeComboBox.Items.Add(BlendingMode.Division);
            blendingModeComboBox.SelectedItem = BlendingMode.Normal;

            // filter type combo box
            filterTypeComboBox.Items.Add(FrequencyFilterType.Ideal);
            filterTypeComboBox.Items.Add(FrequencyFilterType.Butterworth);
            filterTypeComboBox.Items.Add(FrequencyFilterType.Gaussian);
            filterTypeComboBox.SelectedItem = FrequencyFilterType.Gaussian;
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether the preview in image viewer is enabled.
        /// </summary>
        public override bool IsPreviewEnabled
        {
            get
            {
                return base.IsPreviewEnabled;
            }
            set
            {
                if (IsPreviewEnabled != value)
                {
                    base.IsPreviewEnabled = value;
                    previewCheckBox.Checked = value;
                }
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Returns the image processing command.
        /// </summary>
        /// <returns>The image processing command.</returns>
        public override Vintasoft.Imaging.ImageProcessing.ProcessingCommandBase GetProcessingCommand()
        {
            ImageSmoothingCommand command = new ImageSmoothingCommand();
            command.Radius = radiusEditorControl.Value;
            command.OverlayAlpha = overlayAlphaEditorControl.Value;
            command.BlendingMode = _blendingMode;
            command.Filter = _filter;
            command.GrayscaleFiltration = _useGrayscaleFiltration;
            return command;
        }

        #endregion


        #region PRIVATE

        #region UI

        /// <summary>
        /// Handles the Click event of buttonOk object.
        /// </summary>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        /// <summary>
        /// Handles the Click event of buttonCancel object.
        /// </summary>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        /// <summary>
        /// Handles the CheckedChanged event of previewCheckBox object.
        /// </summary>
        private void previewCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            IsPreviewEnabled = previewCheckBox.Checked;
            if (IsPreviewEnabled)
                previewCheckBox.ForeColor = Color.Black;
            else
                previewCheckBox.ForeColor = Color.Green;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of blendingModeComboBox object.
        /// </summary>
        private void blendingModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _blendingMode = (BlendingMode)blendingModeComboBox.SelectedItem;
            ExecuteProcessing();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of filterTypeComboBox object.
        /// </summary>
        private void filterTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _filter = (FrequencyFilterType)filterTypeComboBox.SelectedItem;
            ExecuteProcessing();
        }

        /// <summary>
        /// Handles the CheckedChanged event of grayscaleFiltrationCheckBox object.
        /// </summary>
        private void grayscaleFiltrationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _useGrayscaleFiltration = grayscaleFiltrationCheckBox.Checked;
            ExecuteProcessing();
        }

        /// <summary>
        /// Handles the ValueChanged event of valueEditorControl object.
        /// </summary>
        private void valueEditorControl_ValueChanged(object sender, EventArgs e)
        {
            ExecuteProcessing();
        }

        #endregion

        #endregion

        #endregion

    }
}
