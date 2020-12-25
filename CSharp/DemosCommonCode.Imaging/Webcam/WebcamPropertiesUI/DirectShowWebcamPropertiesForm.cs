using System.Windows.Forms;

using Vintasoft.Imaging.Media;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A form that allows to change the webcam settings.
    /// </summary>
    public partial class DirectShowWebcamPropertiesForm : Form
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectShowWebcamPropertiesForm"/> class.
        /// </summary>
        public DirectShowWebcamPropertiesForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectShowWebcamPropertiesForm"/> class.
        /// </summary>
        /// <param name="camera">The webcam.</param>
        public DirectShowWebcamPropertiesForm(DirectShowCamera camera)
            : this()
        {
            directShowImageQualityPropertiesControl1.Camera = camera;
            directShowCameraControlPropertiesControl1.Camera = camera;

            this.Text = string.Format("{0} Properties (CustomUI)", camera.FriendlyName);
        }

        #endregion

    }
}
