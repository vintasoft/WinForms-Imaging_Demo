using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Effects;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and edit settings of the RedEyeRemovalCommand.
    /// </summary>
    public partial class RedEyeRemovalForm : TwoParamsConfigForm
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RedEyeRemovalForm"/> class.
        /// </summary>
        /// <param name="viewer">The image viewer for image preview.</param>
        public RedEyeRemovalForm(ImageViewer viewer)
            : base(viewer,
            "Red Eye Removal",
            new ImageProcessingParameter("Tolerance", 35, 100, 70),
            new ImageProcessingParameter("Saturation (percents)", 50, 100, 90))
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
            return new RedEyeRemovalCommand(this.Parameter1, this.Parameter2);
        }

        #endregion

    }
}