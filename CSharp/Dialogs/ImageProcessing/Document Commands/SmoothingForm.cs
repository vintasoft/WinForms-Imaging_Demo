#if !REMOVE_DOCCLEANUP_PLUGIN

using Vintasoft.Imaging;
using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Document;
using Vintasoft.Imaging.UI;


namespace ImagingDemo
{
    public partial class SmoothingForm : OneParamConfigForm
    {

        #region Constructors

        public SmoothingForm(ImageViewer viewer)
            : base(viewer,
            "Smoothing",
            new ImageProcessingParameter("Max Bump Size", 1, 512, 1))
        {
        }

        #endregion



        #region Methods

        /// <summary>
        /// Gets the current image processing command.
        /// </summary>
        /// <returns>Current image processing command.</returns>
        public override ProcessingCommandBase GetProcessingCommand()
        {
            return new SmoothingCommand(this.Parameter1);
        }

        #endregion

    }
}

#endif