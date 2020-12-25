using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Filters;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and edit settings of the DilateCommand.
    /// </summary>
    public partial class DilateForm : OneParamConfigForm
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DilateForm"/> class.
        /// </summary>
        /// <param name="viewer">The image viewer for image preview.</param>
        public DilateForm(ImageViewer viewer)
            : base(viewer, "Morphological.Dilate",
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
            return new DilateCommand(WindowSize);
        }

        #endregion

    }
}