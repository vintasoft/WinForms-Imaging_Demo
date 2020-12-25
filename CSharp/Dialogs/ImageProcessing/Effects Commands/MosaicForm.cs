using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Effects;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and edit settings of the MosaicCommand.
    /// </summary>
    public partial class MosaicForm : OneParamConfigForm
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MosaicForm"/> class.
        /// </summary>
        /// <param name="viewer">The image viewer for image preview.</param>
        public MosaicForm(ImageViewer viewer)
            : base(viewer,
            "Mosaic",
            new ImageProcessingParameter("Tile size (pixels)", 2, 100, 4))
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
            return new MosaicCommand(Parameter1);
        }

        #endregion

    }
}