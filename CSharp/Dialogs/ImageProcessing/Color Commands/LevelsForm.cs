using System;
using System.Drawing;

using Vintasoft.Imaging.ImageProcessing.Color;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and edit settings of the LevelsCommand.
    /// </summary>
    public partial class LevelsForm : ParamsConfigForm
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LevelsForm"/> class.
        /// </summary>
        public LevelsForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LevelsForm"/> class.
        /// </summary>
        /// <param name="viewer">The image viewer for image preview.</param>
        public LevelsForm(ImageViewer viewer)
            : base(viewer)
        {
            InitializeComponent();

            // disable preview
            IsPreviewEnabled = true;

            SetDefaultSettings();
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
        /// Returns the image processing command.
        /// </summary>
        /// <returns>The image processing command.</returns>
        public override Vintasoft.Imaging.ImageProcessing.ProcessingCommandBase GetProcessingCommand()
        {
            LevelsCommand command = new LevelsCommand();

            ChannelRemapSettings settings = new ChannelRemapSettings(
                (int)sourceMinValueEditorControl.Value,
                (int)sourceMaxValueEditorControl.Value,
                (double)gammaValueEditorControl.Value,
                (int)destinationMinValueEditorControl.Value,
                (int)destinationMaxValueEditorControl.Value);

            if (redCheckBox.Checked)
                command.RedChannelSettings = settings;

            if (greenCheckBox.Checked)
                command.GreenChannelSettings = settings;

            if (blueCheckBox.Checked)
                command.BlueChannelSettings = settings;

            return command;
        }

        #endregion


        #region PRIVATE

        #region UI

        /// <summary>
        /// Handles the ValueChanged event of AmountEditorControl object.
        /// </summary>
        private void amountEditorControl_ValueChanged(object sender, EventArgs e)
        {
            ExecuteProcessing();
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
        /// Handles the Click event of OkButton object.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        #endregion


        /// <summary>
        /// Sets the default settings of value editor controls.
        /// </summary>
        private void SetDefaultSettings()
        {
            LevelsCommand command = new LevelsCommand();
            ChannelRemapSettings settings = command.RedChannelSettings;

            sourceMinValueEditorControl.DefaultValue = settings.InputMin;
            sourceMaxValueEditorControl.DefaultValue = settings.InputMax;
            destinationMinValueEditorControl.DefaultValue = settings.OutputMin;
            destinationMaxValueEditorControl.DefaultValue = settings.OutputMax;
            gammaValueEditorControl.DefaultValue = (float)settings.Gamma;

            sourceMinValueEditorControl.Value = settings.InputMin;
            sourceMaxValueEditorControl.Value = settings.InputMax;
            destinationMinValueEditorControl.Value = settings.OutputMin;
            destinationMaxValueEditorControl.Value = settings.OutputMax;
            gammaValueEditorControl.Value = (float)settings.Gamma;
        }

        #endregion

        #endregion

    }
}
