using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Effects;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and edit settings of the PixelateCommand.
    /// </summary>
    public partial class PixelateForm : OneParamConfigForm
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PixelateForm"/> class.
        /// </summary>
        /// <param name="viewer">The image viewer for image preview.</param>
        public PixelateForm(ImageViewer viewer)
            : base(viewer,
            "Pixelate",
            new ImageProcessingParameter("Cell size (pixels)", 2, 100, 4))
        {
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets the cell size.
        /// </summary>
        public int CellSize
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
            return new PixelateCommand(CellSize);
        }

        #endregion

    }
}