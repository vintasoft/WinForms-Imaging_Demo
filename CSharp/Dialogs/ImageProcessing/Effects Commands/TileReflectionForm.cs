using Vintasoft.Imaging.ImageProcessing.Effects;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and edit settings of the TileReflectionCommand.
    /// </summary>
    public partial class TileReflectionForm : ThreeParamsConfigForm
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TileReflectionForm"/> class.
        /// </summary>
        /// <param name="viewer">The image viewer for image preview.</param>
        public TileReflectionForm(ImageViewer viewer)
            : base(viewer,
            "Tile / reflection",
            new ImageProcessingParameter("Rotation angle (degrees)", -45, 45, 30),
            new ImageProcessingParameter("Tile size (pixels)", 2, 200, 40),
            new ImageProcessingParameter("Curvature", -20, 20, 8))
        {
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets the rotation angle in degrees.
        /// </summary>
        public int RotationAngle
        {
            get
            {
                return Parameter1;
            }
        }

        /// <summary>
        /// Gets the tile size in pixels.
        /// </summary>
		public int SquareSize
        {
            get
            {
                return Parameter2;
            }
        }

        /// <summary>
        /// Gets the level of curvature at the borders of the tile.
        /// </summary>
		public int Curvature
        {
            get
            {
                return Parameter3;
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
            return new TileReflectionCommand(RotationAngle, SquareSize, Curvature);
        }

        #endregion 

    }
}