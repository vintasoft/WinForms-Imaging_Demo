using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

using Vintasoft.Imaging;
using Vintasoft.Imaging.ColorManagement;
using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Color;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to specify parameters for replace color command.
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

        /// <summary>
        /// Gets the current image processing command.
        /// </summary>
        /// <returns>Current image processing command.</returns>
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

        private void ColorPanelControl_ColorChanged(object sender, EventArgs e)
        {
            ExecuteProcessing();
        }

        private void colorToleranceNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            ExecuteProcessing();
        }

        private void colorSpaceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExecuteProcessing();
        }

        private void previewCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            IsPreviewEnabled = previewCheckBox.Checked;
            if (IsPreviewEnabled)
                previewCheckBox.ForeColor = Color.Black;
            else
                previewCheckBox.ForeColor = Color.Green;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        #endregion

    }
}
