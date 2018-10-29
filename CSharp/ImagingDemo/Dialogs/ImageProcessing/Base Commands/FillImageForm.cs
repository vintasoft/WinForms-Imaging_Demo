using System;
using System.Windows.Forms;
using System.ComponentModel;

using Vintasoft.Imaging;
using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    public partial class FillImageForm : ParamsConfigForm
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FillImageForm"/> class.
        /// </summary>
        protected FillImageForm()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FillImageForm"/> class.
        /// </summary>
        public FillImageForm(ImageViewer viewer)
            : base(viewer)
        {
            InitializeComponent();

            fillColorPanelControl.Color = System.Drawing.Color.Black;
            this.previewCheckBox.Checked = this.IsPreviewEnabled;
        }

        #endregion



        #region Methods

        /// <summary>
        /// Gets the current image processing command.
        /// </summary>
        /// <returns>Current image processing command.</returns>
        public override ProcessingCommandBase GetProcessingCommand()
        {
            return new ClearImageCommand(fillColorPanelControl.Color);
        }

        private void fillColorPanelControl_ColorChanged(object sender, EventArgs e)
        {
            ExecuteProcessing();
        }

        private void previewCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.IsPreviewEnabled = this.previewCheckBox.Checked;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        #endregion

    }
}
