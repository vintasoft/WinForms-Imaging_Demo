using System;
using System.Drawing;

using Vintasoft.Imaging.ImageProcessing.Fft;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and change settings for the frequency spectrum visualizer command.
    /// </summary>
    public partial class FrequencySpectrumVisualizerForm : ParamsConfigForm
    {

        #region Fields

        /// <summary>
        /// Visualization type.
        /// </summary>
        FrequencySpectrumVisualizationType _visualizationType;

        /// <summary>
        /// Specifies that grayscale spectrum should be visualized.
        /// </summary>
        bool _grayscaleVisualiation;

        /// <summary>
        /// Specifies that normalization should be used.
        /// </summary>
        bool _useNormalization;

        /// <summary>
        /// Specifies that absolute values should be used.
        /// </summary>
        bool _useAbsoluteValues;

        /// <summary>
        /// Size of the image spectrum.
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
        /// <param name="viewer">An image viewer.</param>
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

        /// <summary>
        /// "Fixed Spectrum Size" checkbox checked state is changed.
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
        /// The checked state of "Grayscale Visualization" check box is changed.
        /// </summary>
        private void grayscaleVisualizationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _grayscaleVisualiation = grayscaleVisualizationCheckBox.Checked;
            ExecuteProcessing();
        }

        /// <summary>
        /// The checked state of "Use Normalization" check box is changed.
        /// </summary>
        private void normalizationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _useNormalization = normalizationCheckBox.Checked;
            ExecuteProcessing();
        }

        /// <summary>
        /// The checked state of "Use Absolute Values" check box is changed.
        /// </summary>
        private void absoluteValuesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _useAbsoluteValues = absoluteValuesCheckBox.Checked;
            ExecuteProcessing();
        }

        /// <summary>
        /// The selected index of "Visualization Type" combo box is changed.
        /// </summary>
        private void visualizationTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _visualizationType = (FrequencySpectrumVisualizationType)visualizationTypeComboBox.SelectedItem;
            ExecuteProcessing();
        }

        /// <summary>
        /// "OK" button is clicked.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
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
        /// The checked state in the preview check box is changed.
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
        /// The value of "Spectrum Size" numeric up-down is changed.
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

        #endregion

    }
}
