using System;
using System.Drawing;
using System.Windows.Forms;
using Vintasoft.Imaging;
using Vintasoft.Imaging.ImageProcessing.Color;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
	public partial class GammaForm : ThreeParamsConfigForm
    {

        #region Constructor

        public GammaForm(ImageViewer viewer)
			: base(viewer,
            "Gamma",
            new ImageProcessingParameter("Red gamma (percents)", 20, 500, 100),
            new ImageProcessingParameter("Green gamma (percents)", 20, 500, 100),
            new ImageProcessingParameter("Blue gamma (percents)", 20, 500, 100))
		{
        }

        #endregion


        #region Properties

        public double Red
		{
			get
			{
				return (double)Parameter1 / 100;
			}
		}
		public double Green
		{
			get
			{
				return (double)Parameter2 / 100;
			}
		}
		public double Blue
		{
			get
			{
				return (double)Parameter3 / 100;
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
            return new ChangeGammaCommand(Red, Green, Blue);
        }

        #endregion

    }
}