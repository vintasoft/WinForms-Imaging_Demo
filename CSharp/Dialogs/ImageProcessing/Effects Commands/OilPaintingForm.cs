using Vintasoft.Imaging.ImageProcessing.Effects;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and edit settings of the OilPaintingCommand.
    /// </summary>
	public partial class OilPaintingForm : TwoParamsConfigForm
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OilPaintingForm"/> class.
        /// </summary>
        /// <param name="viewer">The image viewer for image preview.</param>
        public OilPaintingForm(ImageViewer viewer)
            : base(viewer,
            "Oil painting",
            new ImageProcessingParameter("Radius", 1, 32, 3),
            new ImageProcessingParameter("Intensity levels", 3, 255, 50))
        {
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets the radius value.
        /// </summary>
        public int Radius
        {
            get
            {
                return Parameter1;
            }
        }

        /// <summary>
        /// Gets the intensity levels value.
        /// </summary>
		public int IntensityLevels
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
            return new OilPaintingCommand(Radius, IntensityLevels);
        }

        #endregion

    }
}