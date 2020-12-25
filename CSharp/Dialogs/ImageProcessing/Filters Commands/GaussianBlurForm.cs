using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Filters;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and edit settings of the GaussianBlurCommand.
    /// </summary>
    public partial class GaussianBlurForm : OneParamConfigForm
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GaussianBlurForm"/> class.
        /// </summary>
        /// <param name="viewer">The image viewer for image preview.</param>
        public GaussianBlurForm(ImageViewer viewer)
            : base(viewer, "Convolution.GaussianBlur",
            new ImageProcessingParameter("Window Radius", 1, 20, 3))
        {
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets the window size.
        /// </summary>
        public int WindowSize
        {
            get
            {
                return Parameter1 * 2 - 1;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Returns the image processing command.
        /// </summary>
        /// <returns>The image processing command.</returns>
        public override ProcessingCommandBase GetProcessingCommand()
        {
            return new GaussianBlurCommand(WindowSize);
        }

        #endregion

    }
}