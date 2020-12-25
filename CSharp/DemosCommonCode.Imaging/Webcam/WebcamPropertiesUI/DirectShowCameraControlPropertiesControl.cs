using System;
using System.Windows.Forms;

using Vintasoft.Imaging.Media;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A control that allows to change the camera control properties.
    /// </summary>
    public partial class DirectShowCameraControlPropertiesControl : UserControl
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectShowCameraControlPropertiesControl"/> class.
        /// </summary>
        public DirectShowCameraControlPropertiesControl()
        {
            InitializeComponent();
        }

        #endregion



        #region Properties

        DirectShowCamera _camera;
        /// <summary>
        /// Gets or sets the webcam.
        /// </summary>
        public DirectShowCamera Camera
        {
            get
            {
                return _camera;
            }
            set
            {
                _camera = value;
            }
        }

        #endregion



        #region Methods

        #region UI

        /// <summary>
        /// Handles the Load event of DirectShowCameraControlPropertiesControl object.
        /// </summary>
        private void DirectShowCameraControlPropertiesControl_Load(object sender, EventArgs e)
        {
            // if webcam is not specified
            if (_camera == null)
            {
                cameraControlPropertiesGroupBox.Enabled = false;
                return;
            }

            // get camera control
            DirectShowCameraControlProperties cameraControl = _camera.CameraControl;

            try
            {
                // load exposure property
                InitializePropertyControl(
                    exposureDirectShowPropertyControl,
                    cameraControl.Exposure,
                    cameraControl.GetSupportedExposureValues);

                exposureDirectShowPropertyControl.Enabled = true;
            }
            catch (DirectShowCameraException)
            {
                exposureDirectShowPropertyControl.Enabled = false;
            }

            try
            {
                // load focus property
                InitializePropertyControl(
                    focusDirectShowPropertyControl,
                    cameraControl.Focus,
                    cameraControl.GetSupportedFocusValues);

                focusDirectShowPropertyControl.Enabled = true;
            }
            catch (DirectShowCameraException)
            {
                focusDirectShowPropertyControl.Enabled = false;
            }

            try
            {
                // load iris property
                InitializePropertyControl(
                    irisDirectShowPropertyControl,
                    cameraControl.Iris,
                    cameraControl.GetSupportedIrisValues);

                irisDirectShowPropertyControl.Enabled = true;
            }
            catch (DirectShowCameraException)
            {
                irisDirectShowPropertyControl.Enabled = false;
            }

            try
            {
                // load pan property
                InitializePropertyControl(
                    panDirectShowPropertyControl,
                    cameraControl.Pan,
                    cameraControl.GetSupportedPanValues);

                panDirectShowPropertyControl.Enabled = true;
            }
            catch (DirectShowCameraException)
            {
                panDirectShowPropertyControl.Enabled = false;
            }

            try
            {
                // load roll property
                InitializePropertyControl(
                    rollDirectShowPropertyControl,
                    cameraControl.Roll,
                    cameraControl.GetSupportedRollValues);

                rollDirectShowPropertyControl.Enabled = true;
            }
            catch (DirectShowCameraException)
            {
                rollDirectShowPropertyControl.Enabled = false;
            }

            try
            {
                // load tilt property
                InitializePropertyControl(
                    tiltDirectShowPropertyControl,
                    cameraControl.Tilt,
                    cameraControl.GetSupportedTiltValues);

                tiltDirectShowPropertyControl.Enabled = true;
            }
            catch (DirectShowCameraException)
            {
                tiltDirectShowPropertyControl.Enabled = false;
            }

            try
            {
                // load zoom property
                InitializePropertyControl(
                    zoomDirectShowPropertyControl,
                    cameraControl.Zoom,
                    cameraControl.GetSupportedZoomValues);

                zoomDirectShowPropertyControl.Enabled = true;
            }
            catch (DirectShowCameraException)
            {
                zoomDirectShowPropertyControl.Enabled = false;
            }
        }

        /// <summary>
        /// Handles the Click event of ResetButton object.
        /// </summary>
        private void resetButton_Click(object sender, EventArgs e)
        {
            // for each control in this control
            foreach (Control control in cameraControlPropertiesGroupBox.Controls)
            {
                DirectShowPropertyControl propertiesControl = control as DirectShowPropertyControl;
                // if current control is property control
                if (propertiesControl != null)
                    propertiesControl.ResetValue();
            }
        }

        /// <summary>
        /// Handles the Click event of RestoreButton object.
        /// </summary>
        private void restoreButton_Click(object sender, EventArgs e)
        {
            // for each control in this control
            foreach (Control control in cameraControlPropertiesGroupBox.Controls)
            {
                DirectShowPropertyControl propertiesControl = control as DirectShowPropertyControl;
                // if current control is property control
                if (propertiesControl != null)
                    propertiesControl.RestoreValue();
            }
        }

        /// <summary>
        /// Handles the PropertyChanged event of ExposureDirectShowPropertyControl object.
        /// </summary>
        private void exposureDirectShowPropertyControl_PropertyChanged(object sender, DirectShowPropertyChangedEventArgs e)
        {
            try
            {
                // if control is enabled
                if (((Control)sender).Enabled)
                    // update webcam exposure value
                    _camera.CameraControl.Exposure = new DirectShowCameraControlPropertyValue(e.Value, e.IsAuto);
            }
            catch (DirectShowCameraException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Handles the PropertyChanged event of FocusDirectShowPropertyControl object.
        /// </summary>
        private void focusDirectShowPropertyControl_PropertyChanged(object sender, DirectShowPropertyChangedEventArgs e)
        {
            try
            {
                // if control is enabled
                if (((Control)sender).Enabled)
                    // update webcam focus value
                    _camera.CameraControl.Focus = new DirectShowCameraControlPropertyValue(e.Value, e.IsAuto);
            }
            catch (DirectShowCameraException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Handles the PropertyChanged event of IrisDirectShowPropertyControl object.
        /// </summary>
        private void irisDirectShowPropertyControl_PropertyChanged(object sender, DirectShowPropertyChangedEventArgs e)
        {
            try
            {
                // if control is enabled
                if (((Control)sender).Enabled)
                    // update webcam iris value
                    _camera.CameraControl.Iris = new DirectShowCameraControlPropertyValue(e.Value, e.IsAuto);
            }
            catch (DirectShowCameraException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Handles the PropertyChanged event of PanDirectShowPropertyControl object.
        /// </summary>
        private void panDirectShowPropertyControl_PropertyChanged(object sender, DirectShowPropertyChangedEventArgs e)
        {
            try
            {
                // if control is enabled
                if (((Control)sender).Enabled)
                    // update webcam pan value
                    _camera.CameraControl.Pan = new DirectShowCameraControlPropertyValue(e.Value, e.IsAuto);
            }
            catch (DirectShowCameraException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Handles the PropertyChanged event of RollDirectShowPropertyControl object.
        /// </summary>
        private void rollDirectShowPropertyControl_PropertyChanged(object sender, DirectShowPropertyChangedEventArgs e)
        {
            try
            {
                // if control is enabled
                if (((Control)sender).Enabled)
                    // update webcam roll value
                    _camera.CameraControl.Roll = new DirectShowCameraControlPropertyValue(e.Value, e.IsAuto);
            }
            catch (DirectShowCameraException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Handles the PropertyChanged event of TiltDirectShowPropertyControl object.
        /// </summary>
        private void tiltDirectShowPropertyControl_PropertyChanged(object sender, DirectShowPropertyChangedEventArgs e)
        {
            try
            {
                // if control is enabled
                if (((Control)sender).Enabled)
                    // update webcam tilt value
                    _camera.CameraControl.Tilt = new DirectShowCameraControlPropertyValue(e.Value, e.IsAuto);
            }
            catch (DirectShowCameraException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Handles the PropertyChanged event of ZoomDirectShowPropertyControl object.
        /// </summary>
        private void zoomDirectShowPropertyControl_PropertyChanged(object sender, DirectShowPropertyChangedEventArgs e)
        {
            try
            {
                // if control is enabled
                if (((Control)sender).Enabled)
                    // update webcam zoom value
                    _camera.CameraControl.Zoom = new DirectShowCameraControlPropertyValue(e.Value, e.IsAuto);
            }
            catch (DirectShowCameraException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion


        /// <summary>
        /// Initializes the specified <see cref="DirectShowPropertyControl"/>.
        /// </summary>
        /// <param name="propertyControl">The property control.</param>
        /// <param name="currentValue">The current property value.</param>
        /// <param name="supportedValueDelegate">A delegate that allows to get camera supported values.</param>
        private void InitializePropertyControl(
            DirectShowPropertyControl propertyControl,
            DirectShowCameraControlPropertyValue currentValue,
            GetSupportedValuesDelegate supportedValueDelegate)
        {
            int defaultValue, minValue, maxValue, stepSize;
            // get supported values
            supportedValueDelegate(out minValue, out maxValue, out stepSize, out defaultValue);

            // initialize control
            propertyControl.Initialize(currentValue.Value, currentValue.Auto, defaultValue, minValue, maxValue, stepSize);
        }

        #endregion



        #region Delegates

        /// <summary>
        /// A delegate that allows to get camera supported values.
        /// </summary>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="stepSize">The step size.</param>
        /// <param name="defaultValue">The default value.</param>
        delegate void GetSupportedValuesDelegate(out int minValue, out int maxValue, out int stepSize, out int defaultValue);

        #endregion

    }
}
