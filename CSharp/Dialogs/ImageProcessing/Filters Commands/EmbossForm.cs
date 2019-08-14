using Vintasoft.Imaging;
using System.Drawing;
using Vintasoft.Imaging.ImageProcessing.Color;
using Vintasoft.Imaging.ImageProcessing.Effects;
using Vintasoft.Imaging.ImageProcessing.Filters;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
	public partial class EmbossForm : TwoParamsConfigForm
	{

		#region Constructor

        public EmbossForm(ImageViewer viewer)
            : base(viewer,
            "Convolution.Emboss",
            new ImageProcessingParameter("Light direction", 0, 359, 45),
            new ImageProcessingParameter("Depth", 1, 10, 1))
        {
        }
		
        #endregion



		#region Properties

        /// <summary>
        /// Gets the radius value.
        /// </summary>
        public int LightDirection
		{
			get
			{
				return Parameter1;
			}
		}

        /// <summary>
        /// Gets the intensity levels value.
        /// </summary>
        public int Depth
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
            return new EmbossCommand(LightDirection, Depth);
        }

        #endregion

	}
}