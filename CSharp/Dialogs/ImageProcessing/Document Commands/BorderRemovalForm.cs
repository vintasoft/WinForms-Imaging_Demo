using Vintasoft.Imaging;
using Vintasoft.Imaging.ImageProcessing.Document;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
	public partial class BorderRemovalForm : TwoParamsConfigForm
	{

		#region Constructor

        public BorderRemovalForm(ImageViewer viewer)
            : base(viewer,
            "Border removal",
            new ImageProcessingParameter("BorderSize", 0, 100, 5),
            new ImageProcessingParameter("Max border noise", 0, 100, 0))
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
            BorderRemovalCommand borderRemoval = new BorderRemovalCommand();
            borderRemoval.BorderSize = Parameter1;
            borderRemoval.MaxBorderNoise = Parameter2;
            return borderRemoval;
        }

        #endregion

	}
}