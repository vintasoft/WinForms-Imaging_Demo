using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Info;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and edit settings of the IsImageBlackWhiteCommand.
    /// </summary>
    public partial class IsImageBlackWhiteForm : OneParamConfigForm
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="IsImageBlackWhiteForm"/> class.
        /// </summary>
        /// <param name="viewer">The image viewer for image preview.</param>
        public IsImageBlackWhiteForm(ImageViewer viewer)
            : base(viewer,
            "Is Image Black-White",
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
            IsImageBlackWhiteCommand command = new IsImageBlackWhiteCommand();
            command.MaxInaccuracy = this.Parameter1;
            return command;
        }

        #endregion

    }
}