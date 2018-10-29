using Vintasoft.Imaging;
using System.Drawing;
using Vintasoft.Imaging.ImageProcessing.Color;
using Vintasoft.Imaging.ImageProcessing.Effects;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
	public partial class BevelEdgeForm : SixParamsConfigForm
	{

		#region Constructor

        public BevelEdgeForm(ImageViewer viewer)
            : base(viewer,
            "Bevel Edge",
            new ImageProcessingParameter("Edge size", 0, 30, 6),
            new ImageProcessingParameter("Smoothness", 0, 20, 2),
            new ImageProcessingParameter("Left brightness", -100, 100, 30),
            new ImageProcessingParameter("Right brightness", -100, 100, -20),
            new ImageProcessingParameter("Top brightness", -100, 100, 30),
            new ImageProcessingParameter("Bottom brightness", -100, 100, -20))
        {
        }
		
        #endregion


        #region Methods

        /// <summary>
        /// Gets the current image processing command.
        /// </summary>
        /// <returns>Current image processing command.</returns>
        public override Vintasoft.Imaging.ImageProcessing.ProcessingCommandBase GetProcessingCommand()
        {
            return new BevelEdgeCommand(this.Parameter1, this.Parameter2, this.Parameter3, this.Parameter4, this.Parameter5, this.Parameter6);
        }

        #endregion

	}
}