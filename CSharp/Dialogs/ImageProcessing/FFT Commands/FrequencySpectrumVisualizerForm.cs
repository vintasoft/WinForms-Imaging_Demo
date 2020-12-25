using System;
using System.Drawing;

using Vintasoft.Imaging.ImageProcessing.Fft;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and edit settings for the FrequencySpectrumVisualizerCommand.
    /// </summary>
    public partial class FrequencySpectrumVisualizerForm : ParamsConfigForm
    {

        #region Fields

        /// <summary>
        /// Visualization type.
        /// </summary>
        FrequencySpectrumVisualizationType _visualizationType;

        /// <summary>
        /// A value indicating whether the grayscale spectrum should be visualized.
        /// </summary>
        bool _grayscaleVisualiation;

        /// <summary>
        /// A value indicating whether the normalization should be used.
        /// </summary>
        bool _useNormalization;

        /// <summary>
        /// A value indicating whether the absolute values should be used.
        /// </summary>
        bool _useAbsoluteValues;

        /// <summary>
        /// The size of the image spectrum.
        /// </summary>
        int _spectrumSize;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FrequencySpectrumVisualizerForm"/> class.
        /// </summary>
        public FrequencySpectrumVisualizerForm()
            : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FrequencySpectrumVisualizerForm"/> class.
        /// </summary>
        /// <param name="viewer">The image viewer for image preview.</param>
        public FrequencySpectrumVisualizerForm(ImageViewer viewer)
            : base(viewer)
        {
            InitializeComponent();

            visualizationTypeComboBox.Items.Add(FrequencySpectrumVisualizationType.Real);
            visualizationTypeComboBox.Items.Add(FrequencySpectrumVisualizationType.Imaginary);
            visualizationTypeComboBox.Items.Add(FrequencySpectrumVisualizationType.Magnitude);
            visualizationTypeComboBox.Items.Add(FrequencySpectrumVisualizationType.SquareRootMagnitude);
            visualizationTypeComboBox.Items.Add(FrequencySpectrumVisualizationType.LogarithmMagnitude);

            InitializeDefaultValues();
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
            FrequencySpectrumVisualizerCommand command = new FrequencySpectrumVisualizerCommand();
            command.VisualizationType = _visualizationType;
            command.GrayscaleVisualization = _grayscaleVisualiation;
            command.UseNormalization = _useNormalization;
            command.UseAbsoluteValues = _useAbsoluteValues;
            if (fixedSpectrumSizeCheckBox.Checked)
                command.SpectrumImageSize = _spectrumSize;
            else
                command.SpectrumImageSize = 0;
            return command;
        }

        #endregion


        #region PRIVATE

        #region UI

        /// <summary>
        /// Handles the CheckedChanged event of FixedSpectrumSizeCheckBox object.
        /// </summary>
        private void fixedSpectrumSizeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (fixedSpectrumSizeCheckBox.Checked)
            {
                spectrumSizeNumericUpDown.Enabled = true;
            }
            else
            {
                spectrumSizeNumericUpDown.Enabled = false;
            }
            ExecuteProcessing();
        }

        /// <summary>
        /// Handles the CheckedChanged event of GrayscaleVisualizationCheckBox object.
        /// </summary>
        private void grayscaleVisualizationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _grayscaleVisualiation = grayscaleVisualizationCheckBox.Checked;
            ExecuteProcessing();
        }

        /// <summary>
        /// Handles the CheckedChanged event of NormalizationCheckBox object.
        /// </summary>
        private void normalizationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _useNormalization = normalizationCheckBox.Checked;
            ExecuteProcessing();
        }

        /// <summary>
        /// Handles the CheckedChanged event of AbsoluteValuesCheckBox object.
        /// </summary>
        private void absoluteValuesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _useAbsoluteValues = absoluteValuesCheckBox.Checked;
            ExecuteProcessing();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of VisualizationTypeComboBox object.
        /// </summary>
        private void visualizationTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _visualizationType = (FrequencySpectrumVisualizationType)visualizationTypeComboBox.SelectedItem;
            ExecuteProcessing();
        }

        /// <summary>
        /// Handles the Click event of OkButton object.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
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
        /// Handles the CheckedChanged event of PreviewCheckBox object.
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
        /// Handles the ValueChanged event of SpectrumSizeNumericUpDown object.
        /// </summary>
        private void spectrumSizeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            FrequencySpectrumVisualizerCommand command = new FrequencySpectrumVisualizerCommand();
            try
            {
                command.SpectrumImageSize = (int)spectrumSizeNumericUpDown.Value;
            }
            catch
            {
                spectrumSizeNumericUpDown.Value = _spectrumSize;
                return;
            }
            _spectrumSize = (int)spectrumSizeNumericUpDown.Value;
            ExecuteProcessing();
        }

        #endregion


        /// <summary>
        /// Initializes the default values.
        /// </summary>
        private void InitializeDefaultValues()
        {
            FrequencySpectrumVisualizerCommand command = new FrequencySpectrumVisualizerCommand();

            _useAbsoluteValues = command.UseAbsoluteValues;
            _grayscaleVisualiation = command.GrayscaleVisualization;
            _useNormalization = command.UseNormalization;
            _visualizationType = command.VisualizationType;
            _spectrumSize = command.SpectrumImageSize;

            if (_spectrumSize == 0)
                fixedSpectrumSizeCheckBox.Checked = false;
            else
                fixedSpectrumSizeCheckBox.Checked = true;

            spectrumSizeNumericUpDown.Value = _spectrumSize;
            visualizationTypeComboBox.SelectedItem = _visualizationType;
            grayscaleVisualizationCheckBox.Checked = _grayscaleVisualiation;
            normalizationCheckBox.Checked = _useNormalization;
            absoluteValuesCheckBox.Checked = _useAbsoluteValues;
        }

        #endregion

        #endregion

    }
}
