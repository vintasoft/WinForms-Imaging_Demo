using System.Drawing;
using Vintasoft.Imaging;
using Vintasoft.Imaging.ImageProcessing.Color;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
	public partial class AlphaChannelForm : OneParamConfigForm
	{

		#region Constructor

        public AlphaChannelForm(ImageViewer viewer)
            : base(viewer,
            "Alpha channel",
            new ImageProcessingParameter("Alpha value", 0, 255, 255))
        {
            CanPreview = false;
        }

		#endregion


		#region Properties

        /// <summary>
        /// Gets the alpha value.
        /// </summary>
		public byte Alpha
		{
			get
			{
				return (byte)Parameter1;
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
            return new SetAlphaChannelValueCommand(Alpha);
        }

        #endregion

    }
}