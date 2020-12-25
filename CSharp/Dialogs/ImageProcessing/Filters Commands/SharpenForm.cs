using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Filters;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and edit settings of the SharpenCommand.
    /// </summary>
    public partial class SharpenForm : OneParamConfigForm
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SharpenForm"/> class.
        /// </summary>
        /// <param name="viewer">The image viewer for image preview.</param>
        public SharpenForm(ImageViewer viewer)
            : base(viewer, "Convolution.Sharpen",
            new ImageProcessingParameter("Amount", 1, 10, 1))
        {
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets the amount.
        /// </summary>
        public int Amount
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
            return new SharpenCommand(Amount);
        }

        #endregion

    }
}
