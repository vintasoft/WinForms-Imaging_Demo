using Vintasoft.Imaging.ImageProcessing.Color;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and edit settings of the ChangeHueSaturationLuminanceCommand.
    /// </summary>
    public partial class HueSaturationLuminanceForm : ThreeParamsConfigForm
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HueSaturationLuminanceForm"/> class.
        /// </summary>
        /// <param name="viewer">The image viewer for image preview.</param>
        public HueSaturationLuminanceForm(ImageViewer viewer)
            : base(viewer,
            "Hue, saturation and luminance",
            new ImageProcessingParameter("Hue", -180, 180, 0),
            new ImageProcessingParameter("Saturation", -100, 100, 0),
            new ImageProcessingParameter("Luminance", -100, 100, 0))
        {
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets the hue value.
        /// </summary>
        public int Hue
        {
            get
            {
                return Parameter1;
            }
        }

        /// <summary>
        /// Gets the saturation value.
        /// </summary>
        public int Saturation
        {
            get
            {
                return Parameter2;
            }
        }

        /// <summary>
        /// Gets the luminance value.
        /// </summary>
        public int Luminance
        {
            get
            {
                return Parameter3;
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
            return new ChangeHueSaturationLuminanceCommand(Hue, Saturation, Luminance);
        }

        #endregion

    }
}