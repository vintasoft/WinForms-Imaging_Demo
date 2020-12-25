using Vintasoft.Imaging.ImageProcessing.Color;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and edit settings of the ChangeGammaCommand.
    /// </summary>
    public partial class GammaForm : ThreeParamsConfigForm
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GammaForm"/> class.
        /// </summary>
        /// <param name="viewer">The image viewer for image preview.</param>
        public GammaForm(ImageViewer viewer)
            : base(viewer,
            "Gamma",
            new ImageProcessingParameter("Red gamma (percents)", 20, 500, 100),
            new ImageProcessingParameter("Green gamma (percents)", 20, 500, 100),
            new ImageProcessingParameter("Blue gamma (percents)", 20, 500, 100))
        {
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets the red channel value.
        /// </summary>
        public double Red
        {
            get
            {
                return (double)Parameter1 / 100;
            }
        }

        /// <summary>
        /// Gets the green channel value.
        /// </summary>
        public double Green
        {
            get
            {
                return (double)Parameter2 / 100;
            }
        }

        /// <summary>
        /// Gets the blue channel value.
        /// </summary>
        public double Blue
        {
            get
            {
                return (double)Parameter3 / 100;
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
            return new ChangeGammaCommand(Red, Green, Blue);
        }

        #endregion

    }
}