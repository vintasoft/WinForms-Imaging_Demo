using System;
using System.Drawing;

using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Fft.Filtering;
using Vintasoft.Imaging.ImageProcessing.Fft.Filters;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and edit settings for the ImageSharpeningCommand.
    /// </summary>
    public partial class ImageSharpeningForm : ParamsConfigForm
    {

        #region Fields

        /// <summary>
        /// Blending mode.
        /// </summary>
        BlendingMode _blendingMode = BlendingMode.SoftLight;

        /// <summary>
        /// Type of frequency filter.
        /// </summary>
        FrequencyFilterType _filter = FrequencyFilterType.Gaussian;

        /// <summary>
        /// A value indicating whether the grayscale filtration must be used.
        /// </summary>
        bool _useGrayscaleFiltration = true;

        /// <summary>
        /// A value indicating whether the form is initializing.
        /// </summary>
        bool _isFormInitializing = true;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageSharpeningForm"/> class.
        /// </summary>
        public ImageSharpeningForm()
            : base()
        {
            InitializeComponent();
            _isFormInitializing = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageSharpeningForm"/> class.
        /// </summary>
        /// <param name="viewer">The image viewer for image preview.</param>
        public ImageSharpeningForm(ImageViewer viewer)
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
            blendingModeComboBox.SelectedItem = BlendingMode.SoftLight;

            // filter type combo box
            filterTypeComboBox.Items.Add(FrequencyFilterType.Ideal);
            filterTypeComboBox.Items.Add(FrequencyFilterType.Butterworth);
            filterTypeComboBox.Items.Add(FrequencyFilterType.Gaussian);
            filterTypeComboBox.SelectedItem = FrequencyFilterType.Gaussian;

            _isFormInitializing = false;
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
            ImageSharpeningCommand command = new ImageSharpeningCommand();
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
        /// Handles the Click event of ButtonOk object.
        /// </summary>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        /// <summary>
        /// Handles the Click event of ButtonCancel object.
        /// </summary>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        /// <summary>
        /// Handles the ValueChanged event of AmountEditorControl object.
        /// </summary>
        private void amountEditorControl_ValueChanged(object sender, EventArgs e)
        {
            if (_isFormInitializing)
                return;
            ExecuteProcessing();
        }

        /// <summary>
        /// Handles the CheckedChanged event of PreviewCheckBox object.
        /// </summary>
        private void previewCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_isFormInitializing)
                return;
            IsPreviewEnabled = previewCheckBox.Checked;
            if (IsPreviewEnabled)
                previewCheckBox.ForeColor = Color.Black;
            else
                previewCheckBox.ForeColor = Color.Green;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of BlendingModeComboBox object.
        /// </summary>
        private void blendingModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isFormInitializing)
                return;
            _blendingMode = (BlendingMode)blendingModeComboBox.SelectedItem;
            ExecuteProcessing();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of FilterTypeComboBox object.
        /// </summary>
        private void filterTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isFormInitializing)
                return;
            _filter = (FrequencyFilterType)filterTypeComboBox.SelectedItem;
            ExecuteProcessing();
        }

        /// <summary>
        /// Handles the CheckedChanged event of GrayscaleFiltrationCheckBox object.
        /// </summary>
        private void grayscaleFiltrationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_isFormInitializing)
                return;
            _useGrayscaleFiltration = grayscaleFiltrationCheckBox.Checked;
            ExecuteProcessing();
        }

        #endregion

        #endregion

        #endregion

    }
}
