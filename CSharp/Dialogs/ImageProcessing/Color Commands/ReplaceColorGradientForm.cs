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
    /// A form that allows to view and edit settings of the AdvancedReplaceColorCommand (CreateColorGradientReplaceCommand).
    /// </summary>
    public partial class ReplaceColorGradientForm : ParamsConfigForm
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ReplaceColorGradientForm"/> class.
        /// </summary>
        protected ReplaceColorGradientForm()
            : this(null)
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="ReplaceColorGradientForm"/> class.
        /// </summary>
        /// <param name="viewer">The image viewer for image preview.</param>
        public ReplaceColorGradientForm(ImageViewer viewer)
            : base(viewer)
        {
            InitializeComponent();

            this.previewCheckBox.Checked = this.IsPreviewEnabled;

            startColorPanelControl.Color = Color.Black;
            stopColorPanelControl.Color = Color.Gray;
            replaceColorPanelControl.Color = Color.Red;
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
            AdvancedReplaceColorCommand replaceColor = AdvancedReplaceColorCommand.CreateColorGradientReplaceCommand(
                new Rgb24Color(startColorPanelControl.Color),
                new Rgb24Color(stopColorPanelControl.Color),
                (int)gradientRadiusNumericUpDown.Value,
                new Rgb24Color(replaceColorPanelControl.Color),
                (int)interpolationRadiusNumericUpDown.Value / 10f);
            return replaceColor;
#else
            throw new NotImplementedException();
#endif
        }

        #endregion


        #region PRIVATE

        #region UI

        /// <summary>
        /// Handles the ValueChanged event of ProcessingProperty object.
        /// </summary>
        private void processingProperty_ValueChanged(object sender, EventArgs e)
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
        /// Handles the Click event of ButtonOk object.
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
