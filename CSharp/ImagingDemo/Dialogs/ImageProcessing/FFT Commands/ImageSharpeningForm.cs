using System;
using System.Drawing;

using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Fft.Filtering;
using Vintasoft.Imaging.ImageProcessing.Fft.Filters;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and change settings for the image sharpening command.
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
        /// Indicates that grayscale filtration should be used.
        /// </summary>
        bool _grayscaleFiltration = true;

        /// <summary>
        /// Indicates that form is initializing.
        /// </summary>
        bool _formInitialize = true;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageSharpeningForm"/> class.
        /// </summary>
        public ImageSharpeningForm()
            : base()
        {
            InitializeComponent();
            _formInitialize = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageSharpeningForm"/> class.
        /// </summary>
        /// <param name="viewer">Image viewer.</param>
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

            _formInitialize = false;
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether the preview in ImageViewer is enabled.
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
        /// Returns the current image processing command.
        /// </summary>
        /// <returns>Current image processing command.</returns>
        public override Vintasoft.Imaging.ImageProcessing.ProcessingCommandBase GetProcessingCommand()
        {
            ImageSharpeningCommand command = new ImageSharpeningCommand();
            command.Radius = radiusEditorControl.Value;
            command.OverlayAlpha = overlayAlphaEditorControl.Value;
            command.BlendingMode = _blendingMode;
            command.Filter = _filter;
            command.GrayscaleFiltration = _grayscaleFiltration;
            return command;
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// "OK" button is clicked.
        /// </summary>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        /// <summary>
        /// "Cancel" button is clicked.
        /// </summary>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        /// <summary>
        /// The value in a value editor is changed.
        /// </summary>
        private void amountEditorControl_ValueChanged(object sender, EventArgs e)
        {
            if (_formInitialize)
                return;
            ExecuteProcessing();
        }

        /// <summary>
        /// The checked state in the preview check box is changed.
        /// </summary>
        private void previewCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_formInitialize)
                return;
            IsPreviewEnabled = previewCheckBox.Checked;
            if (IsPreviewEnabled)
                previewCheckBox.ForeColor = Color.Black;
            else
                previewCheckBox.ForeColor = Color.Green;
        }

        /// <summary>
        /// The selected index of "Blending Mode" combo box is changed.
        /// </summary>
        private void blendingModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_formInitialize)
                return;
            _blendingMode = (BlendingMode)blendingModeComboBox.SelectedItem;
            ExecuteProcessing();
        }

        /// <summary>
        /// The selected index of "Filter Type combo box is changed.
        /// </summary>
        private void filterTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_formInitialize)
                return;
            _filter = (FrequencyFilterType)filterTypeComboBox.SelectedItem;
            ExecuteProcessing();
        }

        /// <summary>
        /// The checked state of "Use Grayscale Filtration" check box is changed.
        /// </summary>
        private void grayscaleFiltrationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_formInitialize)
                return;
            _grayscaleFiltration = grayscaleFiltrationCheckBox.Checked;
            ExecuteProcessing();
        }

        #endregion

        #endregion

    }
}
