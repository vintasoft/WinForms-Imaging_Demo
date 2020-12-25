using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Color;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and edit settings of the PosterizeCommand.
    /// </summary>
    public partial class PosterizeForm : OneParamConfigForm
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PosterizeForm"/> class.
        /// </summary>
        /// <param name="viewer">The image viewer for image preview.</param>
        public PosterizeForm(ImageViewer viewer)
            : base(viewer,
            "Posterize",
            new ImageProcessingParameter("Levels", 2, 256, 6))
        {
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets the levels count.
        /// </summary>
        public int Levels
        {
            get
            {
                return Parameter1;
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
            return new PosterizeCommand(Levels);
        }

        #endregion

    }
}