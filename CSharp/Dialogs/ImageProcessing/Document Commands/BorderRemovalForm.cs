using Vintasoft.Imaging.ImageProcessing.Document;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and edit settings of the BorderRemovalForm.
    /// </summary>
    public partial class BorderRemovalForm : TwoParamsConfigForm
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BorderRemovalForm"/> class.
        /// </summary>
        /// <param name="viewer">The image viewer for image preview.</param>
        public BorderRemovalForm(ImageViewer viewer)
            : base(viewer,
            "Border removal",
            new ImageProcessingParameter("BorderSize", 0, 100, 5),
            new ImageProcessingParameter("Max border noise", 0, 100, 0))
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
            BorderRemovalCommand borderRemoval = new BorderRemovalCommand();
            borderRemoval.BorderSize = Parameter1;
            borderRemoval.MaxBorderNoise = Parameter2;
            return borderRemoval;
        }

        #endregion

    }
}