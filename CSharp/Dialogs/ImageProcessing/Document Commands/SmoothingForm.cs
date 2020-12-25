#if !REMOVE_DOCCLEANUP_PLUGIN

using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Document;
using Vintasoft.Imaging.UI;


namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and edit settings of the SmoothingCommand.
    /// </summary>
    public partial class SmoothingForm : OneParamConfigForm
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SmoothingForm"/> class.
        /// </summary>
        /// <param name="viewer">The image viewer for image preview.</param>
        public SmoothingForm(ImageViewer viewer)
            : base(viewer,
            "Smoothing",
            new ImageProcessingParameter("Max Bump Size", 1, 512, 1))
        {
        }

        #endregion



        #region Methods

        /// <summary>
        /// Returns the image processing command.
        /// </summary>
        /// <returns>The image processing command.</returns>
        public override ProcessingCommandBase GetProcessingCommand()
        {
            return new SmoothingCommand(this.Parameter1);
        }

        #endregion

    }
}

#endif