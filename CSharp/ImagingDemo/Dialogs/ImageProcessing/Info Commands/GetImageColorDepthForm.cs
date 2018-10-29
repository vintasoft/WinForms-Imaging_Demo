using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Info;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    public partial class GetImageColorDepthForm : OneParamConfigForm
    {

        #region Constructors

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
        /// Gets the current image processing command.
        /// </summary>
        /// <returns>Current image processing command.</returns>
        public override ProcessingCommandBase GetProcessingCommand()
        {
            GetImageColorDepthCommand command = new GetImageColorDepthCommand();
            command.MaxInaccuracy = this.Parameter1;
            return command;
        }

        #endregion

    }
}