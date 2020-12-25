using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Info;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and edit settings of the GetImageColorDepthCommand.
    /// </summary>
    public partial class GetImageColorDepthForm : OneParamConfigForm
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GetImageColorDepthForm"/> class.
        /// </summary>
        /// <param name="viewer">The image viewer for image preview.</param>
        public GetImageColorDepthForm(ImageViewer viewer)
            : base(viewer,
            "Get Image Color Depth",
            new ImageProcessingParameter("Max Inaccuracy", 0, 128, 0))
        {
            CanPreview = false;
        }

        #endregion



        #region Methods

        /// <summary>
        /// Returns the image processing command.
        /// </summary>
        /// <returns>The image processing command.</returns>
        public override ProcessingCommandBase GetProcessingCommand()
        {
            GetImageColorDepthCommand command = new GetImageColorDepthCommand();
            command.MaxInaccuracy = this.Parameter1;
            return command;
        }

        #endregion

    }
}