using Vintasoft.Imaging.ImageProcessing.Effects;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and edit settings of the MotionBlurCommand.
    /// </summary>
	public partial class MotionBlurForm : TwoParamsConfigForm
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MotionBlurForm"/> class.
        /// </summary>
        /// <param name="viewer">The image viewer for image preview.</param>
        public MotionBlurForm(ImageViewer viewer)
            : base(viewer,
            "Motion blur",
            new ImageProcessingParameter("Direction", 0, 180, 45),
            new ImageProcessingParameter("Depth", 1, 10, 4))
        {
        }

        #endregion



        #region Methods

        /// <summary>
        /// Returns the image processing command.
        /// </summary>
        /// <returns>The image processing command.</returns>
        public override Vintasoft.Imaging.ImageProcessing.ProcessingCommandBase GetProcessingCommand()
        {
            return new MotionBlurCommand(Parameter1, Parameter2);
        }

        #endregion

    }
}