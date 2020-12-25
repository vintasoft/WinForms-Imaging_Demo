using Vintasoft.Imaging;
using Vintasoft.Imaging.ImageProcessing.Color;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and edit settings of the ChangeBrightnessContrastCommand.
    /// </summary>
    public partial class BrightnessContrastForm : TwoParamsConfigForm
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AdaptiveBinarizeForm"/> class.
        /// </summary>
        /// <param name="viewer">The image viewer for image preview.</param>
        /// <param name="image">The image.</param>
        public BrightnessContrastForm(ImageViewer viewer, VintasoftImage image)
            : base(viewer,
            "Brightness / contrast",
            new ImageProcessingParameter("Brightness", -100, 100, 0),
            new ImageProcessingParameter("Contrast", -100, 100, 0))
        {
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets the brightness value.
        /// </summary>
        public int Brightness
        {
            get
            {
                return Parameter1;
            }
        }

        /// <summary>
        /// Gets the contrast value.
        /// </summary>
        public int Contrast
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
            return new ChangeBrightnessContrastCommand(Brightness, Contrast);
        }

        #endregion

    }
}