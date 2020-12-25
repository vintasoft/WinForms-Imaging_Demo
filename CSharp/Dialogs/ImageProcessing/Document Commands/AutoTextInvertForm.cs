#if !REMOVE_DOCCLEANUP_PLUGIN

using Vintasoft.Imaging.ImageProcessing.Document;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and edit settings of the AutoTextInvertCommand.
    /// </summary>
    public partial class AutoTextInvertForm : SixParamsConfigForm
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AutoTextInvertForm"/> class.
        /// </summary>
        /// <param name="viewer">The image viewer for image preview.</param>
        public AutoTextInvertForm(ImageViewer viewer)
            : base(viewer,
            "Auto Text Invert",
            new ImageProcessingParameter("Min Width", 10, 500, 50),
            new ImageProcessingParameter("Max Width", 10, 4000, 1500),
            new ImageProcessingParameter("Min Height", 10, 300, 20),
            new ImageProcessingParameter("Max Height", 10, 400, 200),
            new ImageProcessingParameter("Min White (%)", 0, 49, 1),
            new ImageProcessingParameter("Max White (%)", 0, 49, 40))
        {
        }

        #endregion



        #region Methods

        /// <summary>
        /// Returns the image processing command.
        /// </summary>
        /// <returns>The image processing command.</returns>
        public override Vintasoft.Imaging.ImageProcessing.ProcessingCommandBase GetProcessingCommand()
        {
            return new AutoTextInvertCommand(this.Parameter1, this.Parameter2, this.Parameter3, this.Parameter4, this.Parameter5, this.Parameter6);
        }

        #endregion

    }
}

#endif