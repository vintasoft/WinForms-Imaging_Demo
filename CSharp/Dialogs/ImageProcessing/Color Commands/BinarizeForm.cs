using Vintasoft.Imaging;
using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Color;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    public partial class BinarizeForm : OneParamConfigForm
    {

        #region Fields

        bool _changePixelFormat;

        #endregion



        #region Constructor

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
        /// Gets the current image processing command.
        /// </summary>
        /// <returns>Current image processing command.</returns>
        public override ProcessingCommandBase GetProcessingCommand()
        {
            if (_changePixelFormat)
                return new ChangePixelFormatToBlackWhiteCommand(Threshold);

            return new BinarizeCommand(Threshold);
        }

        #endregion

    }
}