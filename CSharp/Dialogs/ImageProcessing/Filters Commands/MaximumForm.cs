using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Filters;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and edit settings of the MaximumCommand.
    /// </summary>
    public partial class MaximumForm : OneParamConfigForm
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MaximumForm"/> class.
        /// </summary>
        /// <param name="viewer">The image viewer for image preview.</param>
        public MaximumForm(ImageViewer viewer)
            : base(viewer, "Arithmetic.Maximum",
            new ImageProcessingParameter("Window Radius", 1, 16, 3))
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
            return new MaximumCommand(WindowSize);
        }

        #endregion

    }
}