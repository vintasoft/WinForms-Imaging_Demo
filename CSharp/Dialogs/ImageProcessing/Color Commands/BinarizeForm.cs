using Vintasoft.Imaging;
using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Color;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and edit settings of the 
    /// ChangePixelFormatToBlackWhiteCommand and BinarizeCommand.
    /// </summary>
    public partial class BinarizeForm : OneParamConfigForm
    {

        #region Fields

        /// <summary>
        /// A value indicating whether the pixel format must be changed.
        /// </summary>
        bool _changePixelFormat;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarizeForm"/> class.
        /// </summary>
        /// <param name="viewer">The image viewer for image preview.</param>
        /// <param name="changePixelFormat">A value indicating whether the pixel fromat must be changed.</param>
        public BinarizeForm(ImageViewer viewer, bool changePixelFormat)
            : base(viewer,
            "Black and White",
            new ImageProcessingParameter("Threshold", 0, 255 * 3, (255 * 3) / 2))
        {
            _changePixelFormat = changePixelFormat;
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets the threshold value.
        /// </summary>
        public int Threshold
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
            if (_changePixelFormat)
                return new ChangePixelFormatToBlackWhiteCommand(Threshold);

            return new BinarizeCommand(Threshold);
        }

        #endregion

    }
}