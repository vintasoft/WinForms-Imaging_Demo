using System;
using System.Windows.Forms;

using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
	/// A form that allows to view and edit settings of the ClearImageCommand.
	/// </summary>
    public partial class FillImageForm : ParamsConfigForm
    {

        #region Fields

        /// <summary>
        /// The image viewer.
        /// </summary>
        ImageViewer _imageViewer;

        #endregion



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
        /// <param name="viewer">The image viewer for image preview.</param>
        public FillImageForm(ImageViewer viewer)
            : base(viewer)
        {
            InitializeComponent();

            fillColorPanelControl.Color = System.Drawing.Color.Black;
            this.previewCheckBox.Checked = this.IsPreviewEnabled;
            _imageViewer = viewer;
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
            ClearImageCommand command = ImageProcessingCommandFactory.CreateClearImageCommand(_imageViewer.Image);
            command.FillColor = fillColorPanelControl.Color;
            return command;
        }

        #endregion


        #region PRIVATE

        #region UI

        /// <summary>
        /// Handles the ColorChanged event of fillColorPanelControl object.
        /// </summary>
        private void fillColorPanelControl_ColorChanged(object sender, EventArgs e)
        {
            ExecuteProcessing();
        }

        /// <summary>
        /// Handles the CheckedChanged event of previewCheckBox object.
        /// </summary>
        private void previewCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.IsPreviewEnabled = this.previewCheckBox.Checked;
        }

        /// <summary>
        /// Handles the Click event of okButton object.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        #endregion

        #endregion

        #endregion

    }
}
