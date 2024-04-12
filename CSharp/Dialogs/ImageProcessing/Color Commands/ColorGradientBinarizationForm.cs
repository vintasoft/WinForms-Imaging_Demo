using System;
using System.Drawing;
using System.Windows.Forms;

using Vintasoft.Imaging.ImageColors;
using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Document;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and edit settings of the AdvancedReplaceColorCommand (CreateColorGradientBinarizationCommand).
    /// </summary>
    public partial class ColorGradientBinarizationForm : ParamsConfigForm
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorGradientBinarizationForm"/> class.
        /// </summary>
        protected ColorGradientBinarizationForm()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorGradientBinarizationForm"/> class.
        /// </summary>
        /// <param name="viewer">The image viewer for image preview.</param>
        public ColorGradientBinarizationForm(ImageViewer viewer)
            : base(viewer)
        {
            InitializeComponent();

            this.previewCheckBox.Checked = this.IsPreviewEnabled;

            startColorPanelControl.Color = Color.Black;
            stopColorPanelControl.Color = Color.Gray;
        }

        #endregion



        #region Properties

        bool _changePixelFormatToBlackWhite = false;
        /// <summary>
        /// Gets or sets a value indicating whether image pixel format must be changed to the black-white.
        /// </summary>
        /// <value>
        /// <b>True</b> if image pixel format must be changed to the black-white; otherwise, <b>false</b>.
        /// </value>
        public bool ChangePixelFormatToBlackWhite
        {
            get
            {
                return _changePixelFormatToBlackWhite;
            }
            set
            {
                _changePixelFormatToBlackWhite = value;
            }
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
#if !REMOVE_DOCCLEANUP_PLUGIN
            AdvancedReplaceColorCommand replaceColor = AdvancedReplaceColorCommand.CreateColorGradientBinarizationCommand(
                new Rgb24Color(startColorPanelControl.Color),
                new Rgb24Color(stopColorPanelControl.Color),
                (int)gradientRadiusNumericUpDown.Value);
            if (ChangePixelFormatToBlackWhite)
                return new CompositeCommand(replaceColor, new ChangePixelFormatToBlackWhiteCommand(BinarizationMode.Threshold));
            return replaceColor;
#else
            throw new NotImplementedException();
#endif
        }

        #endregion


        #region PRIVATE

        #region UI

        /// <summary>
        /// Handles the ColorChanged event of ColorPanelControl object.
        /// </summary>
        private void ColorPanelControl_ColorChanged(object sender, EventArgs e)
        {
            ExecuteProcessing();
        }

        /// <summary>
        /// Handles the ValueChanged event of colorToleranceNumericUpDown object.
        /// </summary>
        private void colorToleranceNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            ExecuteProcessing();
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
        /// Handles the Click event of buttonOk object.
        /// </summary>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        #endregion

        #endregion

        #endregion

    }
}
