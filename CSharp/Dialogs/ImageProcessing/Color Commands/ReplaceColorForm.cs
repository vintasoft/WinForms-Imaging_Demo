using System;
using System.Drawing;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Color;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and edit settings of the ReplaceColorCommand.
    /// </summary>
    public partial class ReplaceColorForm : ParamsConfigForm
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ReplaceColorForm"/> class.
        /// </summary>
        protected ReplaceColorForm()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReplaceColorForm"/> class.
        /// </summary>
        /// <param name="viewer">The image viewer for image preview.</param>
        public ReplaceColorForm(ImageViewer viewer)
            : base(viewer)
        {
            InitializeComponent();

            this.colorSpaceComboBox.SelectedIndex = 0;
            this.previewCheckBox.Checked = this.IsPreviewEnabled;

            oldColorPanelControl.Color = Color.White;
            newColorPanelControl.Color = Color.Black;
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
            string colorSpaceTypeString = (string)colorSpaceComboBox.SelectedItem;
            ColorSpaceType colorSpaceType;

            if (colorSpaceTypeString == "RGB")
                colorSpaceType = ColorSpaceType.sRGB;
            else
                colorSpaceType = ColorSpaceType.CIELab;

            return new ReplaceColorCommand(
                oldColorPanelControl.Color,
                newColorPanelControl.Color,
                (int)colorToleranceNumericUpDown.Value,
                colorSpaceType);
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
        /// Handles the SelectedIndexChanged event of colorSpaceComboBox object.
        /// </summary>
        private void colorSpaceComboBox_SelectedIndexChanged(object sender, EventArgs e)
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
