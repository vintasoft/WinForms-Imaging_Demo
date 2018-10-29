using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Info;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    public partial class IsImageGrayscaleForm : OneParamConfigForm
    {

        #region Constructors

        public IsImageGrayscaleForm(ImageViewer viewer)
            : base(viewer,
            "Is Image Grayscale",
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
            IsImageGrayscaleCommand command = new IsImageGrayscaleCommand();
            command.MaxInaccuracy = this.Parameter1;
            return command;
        }

        #endregion

    }
}