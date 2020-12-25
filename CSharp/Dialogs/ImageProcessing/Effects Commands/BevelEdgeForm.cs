using Vintasoft.Imaging.ImageProcessing.Effects;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and edit settings of the BevelEdgeCommand.
    /// </summary>
    public partial class BevelEdgeForm : SixParamsConfigForm
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SmoothingForm"/> class.
        /// </summary>
        /// <param name="viewer">The image viewer for image preview.</param>
        public BevelEdgeForm(ImageViewer viewer)
            : base(viewer,
            "Bevel Edge",
            new ImageProcessingParameter("Edge size", 0, 30, 6),
            new ImageProcessingParameter("Smoothness", 0, 20, 2),
            new ImageProcessingParameter("Left brightness", -100, 100, 30),
            new ImageProcessingParameter("Right brightness", -100, 100, -20),
            new ImageProcessingParameter("Top brightness", -100, 100, 30),
            new ImageProcessingParameter("Bottom brightness", -100, 100, -20))
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
            return new BevelEdgeCommand(this.Parameter1, this.Parameter2, this.Parameter3, this.Parameter4, this.Parameter5, this.Parameter6);
        }

        #endregion

    }
}