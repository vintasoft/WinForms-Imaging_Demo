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

        public DirectShowWebcamPropertiesForm()
        {
            InitializeComponent();
        }

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
