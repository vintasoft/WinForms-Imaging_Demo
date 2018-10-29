using System;
using System.Drawing;
using System.Windows.Forms;
using Vintasoft.Imaging;
using Vintasoft.Imaging.ImageProcessing.Color;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
	public partial class HueSaturationLuminanceForm : ThreeParamsConfigForm
	{

		#region Constructor

        public HueSaturationLuminanceForm(ImageViewer viewer)
			: base(viewer,
            "Hue, saturation and luminance",
            new ImageProcessingParameter("Hue", -180, 180, 0),
            new ImageProcessingParameter("Saturation", -100, 100, 0),
            new ImageProcessingParameter("Luminance", -100, 100, 0))
		{
		}

		#endregion


		#region Properties

		public int Hue
		{
			get
			{
				return Parameter1;
			}
		}

		public int Saturation
		{
			get
			{
				return Parameter2;
			}
		}

		public int Luminance
		{
			get
			{
				return Parameter3;
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
            return new ChangeHueSaturationLuminanceCommand(Hue, Saturation, Luminance);
        }

        #endregion

    }
}