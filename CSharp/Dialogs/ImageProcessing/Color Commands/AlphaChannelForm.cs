using Vintasoft.Imaging.ImageProcessing.Color;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and edit settings of the SetAlphaChannelValueCommand.
    /// </summary>
    public partial class AlphaChannelForm : OneParamConfigForm
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AlphaChannelForm"/> class.
        /// </summary>
        /// <param name="viewer">The image viewer for image preview.</param>
        public AlphaChannelForm(ImageViewer viewer)
            : base(viewer,
            "Alpha channel",
            new ImageProcessingParameter("Alpha value", 0, 255, 255))
        {
            CanPreview = false;
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets the alpha channel value.
        /// </summary>
        public byte Alpha
        {
            get
            {
                return (byte)Parameter1;
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
            return new SetAlphaChannelValueCommand(Alpha);
        }

        #endregion

    }
}