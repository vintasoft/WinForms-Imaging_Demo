using Vintasoft.Imaging.ImageProcessing.Filters;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and edit settings of the EmbossCommand.
    /// </summary>
    public partial class EmbossForm : TwoParamsConfigForm
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EmbossForm"/> class.
        /// </summary>
        /// <param name="viewer">The image viewer for image preview.</param>
        public EmbossForm(ImageViewer viewer)
            : base(viewer,
            "Convolution.Emboss",
            new ImageProcessingParameter("Light direction", 0, 359, 45),
            new ImageProcessingParameter("Depth", 1, 10, 1))
        {
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets the radius value.
        /// </summary>
        public int LightDirection
        {
            get
            {
                return Parameter1;
            }
        }

        /// <summary>
        /// Gets the intensity levels value.
        /// </summary>
        public int Depth
        {
            get
            {
                return Parameter2;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Returns the image processing command.
        /// </summary>
        /// <returns>The image processing command.</returns>
        public override Vintasoft.Imaging.ImageProcessing.ProcessingCommandBase GetProcessingCommand()
        {
            return new EmbossCommand(LightDirection, Depth);
        }

        #endregion

    }
}