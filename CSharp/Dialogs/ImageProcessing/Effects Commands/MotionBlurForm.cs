using Vintasoft.Imaging;
using System.Drawing;
using Vintasoft.Imaging.ImageProcessing.Color;
using Vintasoft.Imaging.ImageProcessing.Effects;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
	public partial class MotionBlurForm : TwoParamsConfigForm
	{

		#region Constructor

        public MotionBlurForm(ImageViewer viewer)
            : base(viewer,
            "Motion blur",
            new ImageProcessingParameter("Direction", 0, 180, 45),
            new ImageProcessingParameter("Depth", 1, 10, 4))
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
            return new MotionBlurCommand(Parameter1, Parameter2);
        }

        #endregion

	}
}