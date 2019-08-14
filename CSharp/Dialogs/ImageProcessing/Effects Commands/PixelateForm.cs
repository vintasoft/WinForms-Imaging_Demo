using System.Drawing;
using Vintasoft.Imaging;
using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Effects;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
	public partial class PixelateForm : OneParamConfigForm
	{

		#region Constructor

		public PixelateForm(ImageViewer viewer)
			: base(viewer,
            "Pixelate",
            new ImageProcessingParameter("Cell size (pixels)", 2, 100, 4))
		{
		}

		#endregion


		#region Properties

		public int CellSize
		{
			get
			{
				return Parameter1;
			}
		}

		#endregion


        #region Methods

        /// <summary>
        /// Gets the current image processing command.
        /// </summary>
        /// <returns>Current image processing command.</returns>
        public override ProcessingCommandBase GetProcessingCommand()
        {
            return new PixelateCommand(CellSize);
        }

        #endregion

    }
}