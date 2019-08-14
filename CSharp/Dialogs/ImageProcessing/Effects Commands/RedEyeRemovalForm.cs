using System.Drawing;
using Vintasoft.Imaging;
using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Effects;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
	public partial class RedEyeRemovalForm : TwoParamsConfigForm
	{

		#region Constructor

        public RedEyeRemovalForm(ImageViewer viewer)
			: base(viewer,
            "Red Eye Removal",
            new ImageProcessingParameter("Tolerance", 35, 100, 70),
            new ImageProcessingParameter("Saturation (percents)", 50, 100, 90))
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
            return new RedEyeRemovalCommand(this.Parameter1, this.Parameter2);
        }

        #endregion

    }
}