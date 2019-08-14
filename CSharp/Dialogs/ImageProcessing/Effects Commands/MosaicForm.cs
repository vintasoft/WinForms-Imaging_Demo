using System.Drawing;
using Vintasoft.Imaging;
using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Effects;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
	public partial class MosaicForm : OneParamConfigForm
	{

		#region Constructor

        public MosaicForm(ImageViewer viewer)
			: base(viewer,
            "Mosaic",
            new ImageProcessingParameter("Tile size (pixels)", 2, 100, 4))
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
            return new MosaicCommand(Parameter1);
        }

        #endregion

    }
}