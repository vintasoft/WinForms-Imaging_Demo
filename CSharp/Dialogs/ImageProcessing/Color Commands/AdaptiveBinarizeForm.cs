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
    public partial class AdaptiveBinarizeForm : FiveParamsConfigForm
    {

        #region Fields

        /// <summary>
        /// A value indicating whether to change image <see cref="PixelFormat"/>.
        /// </summary>
        bool _changePixelFormat;

        #endregion



        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="AdaptiveBinarizeForm"/> class.
        /// </summary>
        /// <param name="viewer">The image viewer for image preview.</param>
        /// <param name="changePixelFormat">A value indicating whether the pixel format must be changed.</param>
        public AdaptiveBinarizeForm(ImageViewer viewer, bool changePixelFormat)
            : base(viewer,
            "Adaptive Binarization",
            new ImageProcessingParameter("MinLevelDifference", -765, 765, 0),
            new ImageProcessingParameter("MaxLevelDifference", -765, 765, -115),
            new ImageProcessingParameter("ConvertToBlackLevel", 0, 100, 0),
            new ImageProcessingParameter("ConvertToWhiteLevel", 0, 100, 100),
            new ImageProcessingParameter("WindowRadius", 0, 256, 15))
        {
            _changePixelFormat = changePixelFormat;
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets the MinLevelDifference value.
        /// </summary>
        public int MinLevelDifference
        {
            get
            {
                return Parameter1;
            }
        }

        /// <summary>
        /// Gets the MaxLevelDifference value.
        /// </summary>
        public int MaxLevelDifference
        {
            get
            {
                return Parameter2;
            }
        }

        /// <summary>
        /// Gets the ConvertToBlackLevel value.
        /// </summary>
        public int ConvertToBlackLevel
        {
            get
            {
                return Parameter3;
            }
        }

        /// <summary>
        /// Gets the ConvertToWhiteLevel value.
        /// </summary>
        public int ConvertToWhiteLevel
        {
            get
            {
                return Parameter4;
            }
        }

        /// <summary>
        /// Gets the WindowRadius value.
        /// </summary>
        public int WindowRadius
        {
            get
            {
                return Parameter5;
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
                return new ChangePixelFormatToBlackWhiteCommand(MinLevelDifference, MaxLevelDifference, ConvertToBlackLevel / 100.0, ConvertToWhiteLevel / 100.0, WindowRadius);

            return new BinarizeCommand(MinLevelDifference, MaxLevelDifference, ConvertToBlackLevel / 100.0, ConvertToWhiteLevel / 100.0, WindowRadius);
        }

        #endregion

    }
}