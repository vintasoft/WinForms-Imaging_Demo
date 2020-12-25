using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Info;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and edit settings of the IsImageGrayscaleCommand.
    /// </summary>
    public partial class IsImageGrayscaleForm : OneParamConfigForm
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="IsImageGrayscaleForm"/> class.
        /// </summary>
        /// <param name="viewer">The image viewer for image preview.</param>
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
        /// Returns the image processing command.
        /// </summary>
        /// <returns>The image processing command.</returns>
        public override ProcessingCommandBase GetProcessingCommand()
        {
            IsImageGrayscaleCommand command = new IsImageGrayscaleCommand();
            command.MaxInaccuracy = this.Parameter1;
            return command;
        }

        #endregion

    }
}