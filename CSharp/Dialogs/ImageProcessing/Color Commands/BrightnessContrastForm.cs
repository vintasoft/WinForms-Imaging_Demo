using Vintasoft.Imaging;
using System.Drawing;
using Vintasoft.Imaging.ImageProcessing.Color;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
	public partial class BrightnessContrastForm : TwoParamsConfigForm
	{

		#region Constructor
        public BrightnessContrastForm(ImageViewer viewer, VintasoftImage image)
			: base(viewer, 
            "Brightness / contrast",
            new ImageProcessingParameter("Brightness", -100, 100, 0),
            new ImageProcessingParameter("Contrast", -100, 100, 0))
		{
		}
		#endregion


		#region Properties

        /// <summary>
        /// Gets the brightness value.
        /// </summary>
		public int Brightness
		{
			get
			{
				return Parameter1;
			}
		}

        /// <summary>
        /// Gets the contrast value.
        /// </summary>
		public int Contrast
		{
			get
			{
				return Parameter2;
			}
		}

		#endregion


        #region Methods

        /// <summary>
        /// Gets the current image processing command.
        /// </summary>
        /// <returns>Current image processing command.</returns>
        public override Vintasoft.Imaging.ImageProcessing.ProcessingCommandBase GetProcessingCommand()
        {
            return new ChangeBrightnessContrastCommand(Brightness, Contrast);
        }

        #endregion

	}
}