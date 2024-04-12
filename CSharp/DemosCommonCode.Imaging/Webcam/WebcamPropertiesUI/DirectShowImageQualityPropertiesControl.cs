using System;
using System.Windows.Forms;

using Vintasoft.Imaging.Media;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A control that allows to change the image quality properties of webcam.
    /// </summary>
    public partial class DirectShowImageQualityPropertiesControl : UserControl
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectShowImageQualityPropertiesControl"/> class.
        /// </summary>
        public DirectShowImageQualityPropertiesControl()
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
        /// Handles the Load event of DirectShowImageQualityPropertiesControl object.
        /// </summary>
        private void DirectShowImageQualityPropertiesControl_Load(object sender, EventArgs e)
        {
            if (_camera == null)
            {
                imageQualityPropertiesGroupBox.Enabled = false;
                return;
            }

            // get camera control
            DirectShowImageQualityProperties imageQuality = _camera.ImageQuality;

            try
            {
                // load backlight compensation property
                InitializePropertyControl(
                    backlightCompensationDirectShowPropertyControl,
                    imageQuality.BacklightCompensation,
                    imageQuality.GetSupportedBacklightCompensationValues);

                backlightCompensationDirectShowPropertyControl.Enabled = true;
            }
            catch (DirectShowCameraException)
            {
                backlightCompensationDirectShowPropertyControl.Enabled = false;
            }

            try
            {
                // load brightness property
                InitializePropertyControl(
                    brightnessDirectShowPropertyControl,
                    imageQuality.Brightness,
                    imageQuality.GetSupportedBrightnessValues);

                brightnessDirectShowPropertyControl.Enabled = true;
            }
            catch (DirectShowCameraException)
            {
                brightnessDirectShowPropertyControl.Enabled = false;
            }

            try
            {
                // load color enable property
                InitializePropertyControl(
                    colorEnableDirectShowPropertyControl,
                    imageQuality.ColorEnable,
                    imageQuality.GetSupportedColorEnableValues);

                colorEnableDirectShowPropertyControl.Enabled = true;
            }
            catch (DirectShowCameraException)
            {
                colorEnableDirectShowPropertyControl.Enabled = false;
            }

            try
            {
                // load contrast property
                InitializePropertyControl(
                    contrastDirectShowPropertyControl,
                    imageQuality.Contrast,
                    imageQuality.GetSupportedContrastValues);

                contrastDirectShowPropertyControl.Enabled = true;
            }
            catch (DirectShowCameraException)
            {
                contrastDirectShowPropertyControl.Enabled = false;
            }

            try
            {
                // load gain property
                InitializePropertyControl(
                    gainDirectShowPropertyControl,
                    imageQuality.Gain,
                    imageQuality.GetSupportedGainValues);

                gainDirectShowPropertyControl.Enabled = true;
            }
            catch (DirectShowCameraException)
            {
                gainDirectShowPropertyControl.Enabled = false;
            }

            try
            {
                // load gamma property
                InitializePropertyControl(
                    gammaDirectShowPropertyControl,
                    imageQuality.Gamma,
                    imageQuality.GetSupportedGammaValues);

                gammaDirectShowPropertyControl.Enabled = true;
            }
            catch (DirectShowCameraException)
            {
                gammaDirectShowPropertyControl.Enabled = false;
            }

            try
            {
                // load hue property
                InitializePropertyControl(
                    hueDirectShowPropertyControl,
                    imageQuality.Hue,
                    imageQuality.GetSupportedHueValues);

                hueDirectShowPropertyControl.Enabled = true;
            }
            catch (DirectShowCameraException)
            {
                hueDirectShowPropertyControl.Enabled = false;
            }

            try
            {
                // load saturation property
                InitializePropertyControl(
                    saturationDirectShowPropertyControl,
                    imageQuality.Saturation,
                    imageQuality.GetSupportedSaturationValues);

                saturationDirectShowPropertyControl.Enabled = true;
            }
            catch (DirectShowCameraException)
            {
                saturationDirectShowPropertyControl.Enabled = false;
            }

            try
            {
                // load sharpness property
                InitializePropertyControl(
                    sharpnessDirectShowPropertyControl,
                    imageQuality.Sharpness,
                    imageQuality.GetSupportedSharpnessValues);

                sharpnessDirectShowPropertyControl.Enabled = true;
            }
            catch (DirectShowCameraException)
            {
                sharpnessDirectShowPropertyControl.Enabled = false;
            }

            try
            {
                // load white balance property
                InitializePropertyControl(
                    whiteBalanceDirectShowPropertyControl,
                    imageQuality.WhiteBalance,
                    imageQuality.GetSupportedWhiteBalanceValues);

                whiteBalanceDirectShowPropertyControl.Enabled = true;
            }
            catch (DirectShowCameraException)
            {
                whiteBalanceDirectShowPropertyControl.Enabled = false;
            }
        }

        /// <summary>
        /// Handles the Click event of resetButton object.
        /// </summary>
        private void resetButton_Click(object sender, EventArgs e)
        {
            // for each control in this control
            foreach (Control control in imageQualityPropertiesGroupBox.Controls)
            {
                DirectShowPropertyControl propertiesControl = control as DirectShowPropertyControl;
                // if current control is property control
                if (propertiesControl != null)
                    propertiesControl.ResetValue();
            }
        }

        /// <summary>
        /// Handles the Click event of restoreButton object.
        /// </summary>
        private void restoreButton_Click(object sender, EventArgs e)
        {
            // for each control in this control
            foreach (Control control in imageQualityPropertiesGroupBox.Controls)
            {
                DirectShowPropertyControl propertiesControl = control as DirectShowPropertyControl;
                // if current control is property control
                if (propertiesControl != null)
                    propertiesControl.RestoreValue();
            }
        }

        /// <summary>
        /// Handles the PropertyChanged event of backlightCompensationDirectShowPropertyControl object.
        /// </summary>
        private void backlightCompensationDirectShowPropertyControl_PropertyChanged(object sender, DirectShowPropertyChangedEventArgs e)
        {
            try
            {
                // if control is enabled
                if (((Control)sender).Enabled)
                    // update webcam backlight compensation value
                    _camera.ImageQuality.BacklightCompensation = new DirectShowImageQualityPropertyValue(e.Value, e.IsAuto);
            }
            catch (DirectShowCameraException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Handles the PropertyChanged event of brightnessDirectShowPropertyControl object.
        /// </summary>
        private void brightnessDirectShowPropertyControl_PropertyChanged(object sender, DirectShowPropertyChangedEventArgs e)
        {
            try
            {
                // if control is enabled
                if (((Control)sender).Enabled)
                    // update webcam brightness value
                    _camera.ImageQuality.Brightness = new DirectShowImageQualityPropertyValue(e.Value, e.IsAuto);
            }
            catch (DirectShowCameraException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Handles the PropertyChanged event of colorEnableDirectShowPropertyControl object.
        /// </summary>
        private void colorEnableDirectShowPropertyControl_PropertyChanged(object sender, DirectShowPropertyChangedEventArgs e)
        {
            try
            {
                // if control is enabled
                if (((Control)sender).Enabled)
                    // update webcam color enable value
                    _camera.ImageQuality.ColorEnable = new DirectShowImageQualityPropertyValue(e.Value, e.IsAuto);
            }
            catch (DirectShowCameraException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Handles the PropertyChanged event of contrastDirectShowPropertyControl object.
        /// </summary>
        private void contrastDirectShowPropertyControl_PropertyChanged(object sender, DirectShowPropertyChangedEventArgs e)
        {
            try
            {
                // if control is enabled
                if (((Control)sender).Enabled)
                    // update webcam contrast value
                    _camera.ImageQuality.Contrast = new DirectShowImageQualityPropertyValue(e.Value, e.IsAuto);
            }
            catch (DirectShowCameraException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Handles the PropertyChanged event of gainDirectShowPropertyControl object.
        /// </summary>
        private void gainDirectShowPropertyControl_PropertyChanged(object sender, DirectShowPropertyChangedEventArgs e)
        {
            try
            {
                // if control is enabled
                if (((Control)sender).Enabled)
                    // update webcam gain value
                    _camera.ImageQuality.Gain = new DirectShowImageQualityPropertyValue(e.Value, e.IsAuto);
            }
            catch (DirectShowCameraException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Handles the PropertyChanged event of gammaDirectShowPropertyControl object.
        /// </summary>
        private void gammaDirectShowPropertyControl_PropertyChanged(object sender, DirectShowPropertyChangedEventArgs e)
        {
            try
            {
                // if control is enabled
                if (((Control)sender).Enabled)
                    // update webcam gamma value
                    _camera.ImageQuality.Gamma = new DirectShowImageQualityPropertyValue(e.Value, e.IsAuto);
            }
            catch (DirectShowCameraException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Handles the PropertyChanged event of hueDirectShowPropertyControl object.
        /// </summary>
        private void hueDirectShowPropertyControl_PropertyChanged(object sender, DirectShowPropertyChangedEventArgs e)
        {
            try
            {
                // if control is enabled
                if (((Control)sender).Enabled)
                    // update webcam hue value
                    _camera.ImageQuality.Hue = new DirectShowImageQualityPropertyValue(e.Value, e.IsAuto);
            }
            catch (DirectShowCameraException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Handles the PropertyChanged event of saturationDirectShowPropertyControl object.
        /// </summary>
        private void saturationDirectShowPropertyControl_PropertyChanged(object sender, DirectShowPropertyChangedEventArgs e)
        {
            try
            {
                // if control is enabled
                if (((Control)sender).Enabled)
                    // update webcam saturation value
                    _camera.ImageQuality.Saturation = new DirectShowImageQualityPropertyValue(e.Value, e.IsAuto);
            }
            catch (DirectShowCameraException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Handles the PropertyChanged event of sharpnessDirectShowPropertyControl object.
        /// </summary>
        private void sharpnessDirectShowPropertyControl_PropertyChanged(object sender, DirectShowPropertyChangedEventArgs e)
        {
            try
            {
                // if control is enabled
                if (((Control)sender).Enabled)
                    // update webcam sharpness value
                    _camera.ImageQuality.Sharpness = new DirectShowImageQualityPropertyValue(e.Value, e.IsAuto);
            }
            catch (DirectShowCameraException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Handles the PropertyChanged event of whiteBalanceDirectShowPropertyControl object.
        /// </summary>
        private void whiteBalanceDirectShowPropertyControl_PropertyChanged(object sender, DirectShowPropertyChangedEventArgs e)
        {
            try
            {
                // if control is enabled
                if (((Control)sender).Enabled)
                    // update webcam white balance value
                    _camera.ImageQuality.WhiteBalance = new DirectShowImageQualityPropertyValue(e.Value, e.IsAuto);
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
            DirectShowImageQualityPropertyValue currentValue,
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
