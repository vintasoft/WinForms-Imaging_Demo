using System.Drawing;
using Vintasoft.Imaging;
using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Color;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    public partial class PosterizeForm : OneParamConfigForm
    {

        #region Constructor

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
        /// Gets the current image processing command.
        /// </summary>
        /// <returns>Current image processing command.</returns>
        public override ProcessingCommandBase GetProcessingCommand()
        {
            return new PosterizeCommand(Levels);
        }

        #endregion

    }
}