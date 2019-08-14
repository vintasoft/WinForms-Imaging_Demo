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

        #region Structs

        /// <summary>
        /// Stores information about values of the image quality property.
        /// </summary>
        class ImageQualityPropertyInfo
        {
            internal bool Auto;
            internal int CurrentValue;
            internal int DefaultValue;
            internal int MinValue;
            internal int MaxValue;
            internal int StepSize;


            internal ImageQualityPropertyInfo(
                DirectShowImageQualityPropertyValue currentValue,
                int defaultValue,
                int minValue,
                int maxValue,
                int stepSize)
            {
                this.StepSize = stepSize;

                this.MinValue = minValue / stepSize;
                this.MaxValue = maxValue / stepSize;

                this.DefaultValue = GetValueInRange(defaultValue / stepSize);

                this.CurrentValue = GetValueInRange(currentValue.Value / stepSize);
                this.Auto = currentValue.Auto;
            }



            private int GetValueInRange(int value)
            {
                if (value < MinValue)
                    return MinValue;
                if (value > MaxValue)
                    return MaxValue;
                return value;
            }
        }

        #endregion



        #region Fields

        ImageQualityPropertyInfo _backlightCompensationPropertyInfo;
        ImageQualityPropertyInfo _brightnessPropertyInfo;
        ImageQualityPropertyInfo _colorEnablePropertyInfo;
        ImageQualityPropertyInfo _contrastPropertyInfo;
        ImageQualityPropertyInfo _gainPropertyInfo;
        ImageQualityPropertyInfo _gammaPropertyInfo;
        ImageQualityPropertyInfo _huePropertyInfo;
        ImageQualityPropertyInfo _saturationPropertyInfo;
        ImageQualityPropertyInfo _sharpnessPropertyInfo;
        ImageQualityPropertyInfo _whiteBalancePropertyInfo;

        bool _isInitialized;

        #endregion



        #region Constructors

        public DirectShowImageQualityPropertiesControl()
        {
            InitializeComponent();
        }

        #endregion



        #region Properties

        DirectShowCamera _camera;
        /// <summary>
        /// Webcam to manage.
        /// </summary>
        public DirectShowCamera Camera
        {
            get { return _camera; }
            set { _camera = value; }
        }

        #endregion



        #region Methods

        private void DirectShowImageQualityPropertiesControl_Load(object sender, EventArgs e)
        {
            if (_camera == null)
            {
                imageQualityPropertiesGroupBox.Enabled = false;
                return;
            }

            DirectShowImageQualityPropertyValue currentValue;
            int defaultValue, minValue, maxValue, stepSize;

            // backlight compensation
            try
            {
                _camera.ImageQuality.GetSupportedBacklightCompensationValues(out minValue, out maxValue, out stepSize, out defaultValue);
                currentValue = _camera.ImageQuality.BacklightCompensation;

                _backlightCompensationPropertyInfo = new ImageQualityPropertyInfo(currentValue, defaultValue, minValue, maxValue, stepSize);
                InitProperty(backlightCompensationTrackBar, backlightCompensationCheckBox, _backlightCompensationPropertyInfo);
            }
            catch (DirectShowCameraException)
            {
                DisableProperty(backlightCompensationLabel, backlightCompensationTrackBar, backlightCompensationCheckBox);
            }

            // brightness
            try
            {
                _camera.ImageQuality.GetSupportedBrightnessValues(out minValue, out maxValue, out stepSize, out defaultValue);
                currentValue = _camera.ImageQuality.Brightness;

                _brightnessPropertyInfo = new ImageQualityPropertyInfo(currentValue, defaultValue, minValue, maxValue, stepSize);
                InitProperty(brightnessTrackBar, brightnessCheckBox, _brightnessPropertyInfo);
            }
            catch (DirectShowCameraException)
            {
                DisableProperty(brightnessLabel, brightnessTrackBar, brightnessCheckBox);
            }

            // color enable
            try
            {
                _camera.ImageQuality.GetSupportedColorEnableValues(out minValue, out maxValue, out stepSize, out defaultValue);
                currentValue = _camera.ImageQuality.ColorEnable;

                _colorEnablePropertyInfo = new ImageQualityPropertyInfo(currentValue, defaultValue, minValue, maxValue, stepSize);
                InitProperty(colorEnableTrackBar, colorEnableCheckBox, _colorEnablePropertyInfo);
            }
            catch (DirectShowCameraException)
            {
                DisableProperty(colorEnableLabel, colorEnableTrackBar, colorEnableCheckBox);
            }

            // contrast
            try
            {
                _camera.ImageQuality.GetSupportedContrastValues(out minValue, out maxValue, out stepSize, out defaultValue);
                currentValue = _camera.ImageQuality.Contrast;

                _contrastPropertyInfo = new ImageQualityPropertyInfo(currentValue, defaultValue, minValue, maxValue, stepSize);
                InitProperty(contrastTrackBar, contrastCheckBox, _contrastPropertyInfo);
            }
            catch (DirectShowCameraException)
            {
                DisableProperty(contrastLabel, contrastTrackBar, contrastCheckBox);
            }

            // gain
            try
            {
                _camera.ImageQuality.GetSupportedGainValues(out minValue, out maxValue, out stepSize, out defaultValue);
                currentValue = _camera.ImageQuality.Gain;

                _gainPropertyInfo = new ImageQualityPropertyInfo(currentValue, defaultValue, minValue, maxValue, stepSize);
                InitProperty(gainTrackBar, gainCheckBox, _gainPropertyInfo);
            }
            catch (DirectShowCameraException)
            {
                DisableProperty(gainLabel, gainTrackBar, gainCheckBox);
            }

            // gamma
            try
            {
                _camera.ImageQuality.GetSupportedGammaValues(out minValue, out maxValue, out stepSize, out defaultValue);
                currentValue = _camera.ImageQuality.Gamma;

                _gammaPropertyInfo = new ImageQualityPropertyInfo(currentValue, defaultValue, minValue, maxValue, stepSize);
                InitProperty(gammaTrackBar, gammaCheckBox, _gammaPropertyInfo);
            }
            catch (DirectShowCameraException)
            {
                DisableProperty(gammaLabel, gammaTrackBar, gammaCheckBox);
            }

            // hue
            try
            {
                _camera.ImageQuality.GetSupportedHueValues(out minValue, out maxValue, out stepSize, out defaultValue);
                currentValue = _camera.ImageQuality.Hue;

                _huePropertyInfo = new ImageQualityPropertyInfo(currentValue, defaultValue, minValue, maxValue, stepSize);
                InitProperty(hueTrackBar, hueCheckBox, _huePropertyInfo);
            }
            catch (DirectShowCameraException)
            {
                DisableProperty(hueLabel, hueTrackBar, hueCheckBox);
            }

            // saturation
            try
            {
                _camera.ImageQuality.GetSupportedSaturationValues(out minValue, out maxValue, out stepSize, out defaultValue);
                currentValue = _camera.ImageQuality.Saturation;

                _saturationPropertyInfo = new ImageQualityPropertyInfo(currentValue, defaultValue, minValue, maxValue, stepSize);
                InitProperty(saturationTrackBar, saturationCheckBox, _saturationPropertyInfo);
            }
            catch (DirectShowCameraException)
            {
                DisableProperty(saturationLabel, saturationTrackBar, saturationCheckBox);
            }

            // sharpness
            try
            {
                _camera.ImageQuality.GetSupportedSharpnessValues(out minValue, out maxValue, out stepSize, out defaultValue);
                currentValue = _camera.ImageQuality.Sharpness;

                _sharpnessPropertyInfo = new ImageQualityPropertyInfo(currentValue, defaultValue, minValue, maxValue, stepSize);
                InitProperty(sharpnessTrackBar, sharpnessCheckBox, _sharpnessPropertyInfo);
            }
            catch (DirectShowCameraException)
            {
                DisableProperty(sharpnessLabel, sharpnessTrackBar, sharpnessCheckBox);
            }

            // white balance
            try
            {
                _camera.ImageQuality.GetSupportedWhiteBalanceValues(out minValue, out maxValue, out stepSize, out defaultValue);
                currentValue = _camera.ImageQuality.WhiteBalance;

                _whiteBalancePropertyInfo = new ImageQualityPropertyInfo(currentValue, defaultValue, minValue, maxValue, stepSize);
                InitProperty(whiteBalanceTrackBar, whiteBalanceCheckBox, _whiteBalancePropertyInfo);
            }
            catch (DirectShowCameraException)
            {
                DisableProperty(whiteBalanceLabel, whiteBalanceTrackBar, whiteBalanceCheckBox);
            }

            _isInitialized = true;
        }

        private void InitProperty(
            TrackBar trackBar,
            CheckBox checkBox,
            ImageQualityPropertyInfo propertyInfo)
        {
            trackBar.Minimum = propertyInfo.MinValue;
            trackBar.Maximum = propertyInfo.MaxValue;
            trackBar.Value = propertyInfo.CurrentValue;
            trackBar.Enabled = !propertyInfo.Auto;

            checkBox.Checked = propertyInfo.Auto;
        }

        private void DisableProperty(Label label, TrackBar trackBar, CheckBox checkBox)
        {
            label.Enabled = false;
            trackBar.Enabled = false;
            checkBox.Enabled = false;
        }


        #region Trackbars

        private void backlightCompensationTrackBar_Scroll(object sender, System.EventArgs e)
        {
            SetBacklightCompensationValue(backlightCompensationTrackBar.Value, false);
        }

        private void brightnessTrackBar_Scroll(object sender, System.EventArgs e)
        {
            SetBrightnessValue(brightnessTrackBar.Value, false);
        }

        private void colorEnableTrackBar_Scroll(object sender, System.EventArgs e)
        {
            SetColorEnableValue(colorEnableTrackBar.Value, false);
        }

        private void contrastTrackBar_Scroll(object sender, System.EventArgs e)
        {
            SetContrastValue(contrastTrackBar.Value, false);
        }

        private void gainTrackBar_Scroll(object sender, System.EventArgs e)
        {
            SetGainValue(gainTrackBar.Value, false);
        }

        private void gammaTrackBar_Scroll(object sender, System.EventArgs e)
        {
            SetGammaValue(gammaTrackBar.Value, false);
        }

        private void hueTrackBar_Scroll(object sender, System.EventArgs e)
        {
            SetHueValue(hueTrackBar.Value, false);
        }

        private void saturationTrackBar_Scroll(object sender, System.EventArgs e)
        {
            SetSaturationValue(saturationTrackBar.Value, false);
        }

        private void sharpnessTrackBar_Scroll(object sender, System.EventArgs e)
        {
            SetSharpnessValue(sharpnessTrackBar.Value, false);
        }

        private void whiteBalanceTrackBar_Scroll(object sender, System.EventArgs e)
        {
            SetWhiteBalanceValue(whiteBalanceTrackBar.Value, false);
        }

        #endregion


        #region Check boxes

        private void backlightCompensationCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            SetBacklightCompensationValue(backlightCompensationTrackBar.Value, backlightCompensationCheckBox.Checked);
        }

        private void brightnessCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            SetBrightnessValue(brightnessTrackBar.Value, brightnessCheckBox.Checked);
        }

        private void colorEnableCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            SetColorEnableValue(colorEnableTrackBar.Value, colorEnableCheckBox.Checked);
        }

        private void contrastCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            SetContrastValue(contrastTrackBar.Value, contrastCheckBox.Checked);
        }

        private void gainCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            SetGainValue(gainTrackBar.Value, gainCheckBox.Checked);
        }

        private void gammaCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            SetGammaValue(gammaTrackBar.Value, gammaCheckBox.Checked);
        }

        private void hueCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            SetHueValue(hueTrackBar.Value, hueCheckBox.Checked);
        }

        private void saturationCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            SetSaturationValue(saturationTrackBar.Value, saturationCheckBox.Checked);
        }

        private void sharpnessCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            SetSharpnessValue(sharpnessTrackBar.Value, sharpnessCheckBox.Checked);
        }

        private void whiteBalanceCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            SetWhiteBalanceValue(whiteBalanceTrackBar.Value, whiteBalanceCheckBox.Checked);
        }

        #endregion


        /// <summary>
        /// Resets the values of image quality properties.
        /// </summary>
        private void resetButton_Click(object sender, EventArgs e)
        {
            if (backlightCompensationLabel.Enabled)
                SetBacklightCompensationValue(_backlightCompensationPropertyInfo.DefaultValue, false);

            if (brightnessLabel.Enabled)
                SetBrightnessValue(_brightnessPropertyInfo.DefaultValue, false);

            if (colorEnableLabel.Enabled)
                SetColorEnableValue(_colorEnablePropertyInfo.DefaultValue, false);

            if (contrastLabel.Enabled)
                SetContrastValue(_contrastPropertyInfo.DefaultValue, false);

            if (gainLabel.Enabled)
                SetGainValue(_gainPropertyInfo.DefaultValue, false);

            if (gammaLabel.Enabled)
                SetGammaValue(_gammaPropertyInfo.DefaultValue, false);

            if (hueLabel.Enabled)
                SetHueValue(_huePropertyInfo.DefaultValue, false);

            if (saturationLabel.Enabled)
                SetSaturationValue(_saturationPropertyInfo.DefaultValue, false);

            if (sharpnessLabel.Enabled)
                SetSharpnessValue(_sharpnessPropertyInfo.DefaultValue, false);

            if (whiteBalanceLabel.Enabled)
                SetWhiteBalanceValue(_whiteBalancePropertyInfo.DefaultValue, false);
        }

        /// <summary>
        /// Restores the values of image quality properties.
        /// </summary>
        private void restoreButton_Click(object sender, EventArgs e)
        {
            if (backlightCompensationLabel.Enabled)
                SetBacklightCompensationValue(_backlightCompensationPropertyInfo.CurrentValue, _backlightCompensationPropertyInfo.Auto);

            if (brightnessLabel.Enabled)
                SetBrightnessValue(_brightnessPropertyInfo.CurrentValue, _brightnessPropertyInfo.Auto);

            if (colorEnableLabel.Enabled)
                SetColorEnableValue(_colorEnablePropertyInfo.CurrentValue, _colorEnablePropertyInfo.Auto);

            if (contrastLabel.Enabled)
                SetContrastValue(_contrastPropertyInfo.CurrentValue, _contrastPropertyInfo.Auto);

            if (gainLabel.Enabled)
                SetGainValue(_gainPropertyInfo.CurrentValue, _gainPropertyInfo.Auto);

            if (gammaLabel.Enabled)
                SetGammaValue(_gammaPropertyInfo.CurrentValue, _gammaPropertyInfo.Auto);

            if (hueLabel.Enabled)
                SetHueValue(_huePropertyInfo.CurrentValue, _huePropertyInfo.Auto);

            if (saturationLabel.Enabled)
                SetSaturationValue(_saturationPropertyInfo.CurrentValue, _saturationPropertyInfo.Auto);

            if (sharpnessLabel.Enabled)
                SetSharpnessValue(_sharpnessPropertyInfo.CurrentValue, _sharpnessPropertyInfo.Auto);

            if (whiteBalanceLabel.Enabled)
                SetWhiteBalanceValue(_whiteBalancePropertyInfo.CurrentValue, _whiteBalancePropertyInfo.Auto);
        }


        #region Set property value

        /// <summary>
        /// Sets the backlight compensation value.
        /// </summary>
        private void SetBacklightCompensationValue(int value, bool autoMode)
        {
            if (!_isInitialized)
                return;

            try
            {
                _camera.ImageQuality.BacklightCompensation = new DirectShowImageQualityPropertyValue(value * _backlightCompensationPropertyInfo.StepSize, autoMode);

                if (backlightCompensationTrackBar.Value != value)
                    backlightCompensationTrackBar.Value = value;

                if (backlightCompensationCheckBox.Checked != autoMode)
                    backlightCompensationCheckBox.Checked = autoMode;

                backlightCompensationTrackBar.Enabled = !autoMode;
            }
            catch (DirectShowCameraException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Sets the brightness value.
        /// </summary>
        private void SetBrightnessValue(int value, bool autoMode)
        {
            if (!_isInitialized)
                return;

            try
            {
                _camera.ImageQuality.Brightness = new DirectShowImageQualityPropertyValue(value * _brightnessPropertyInfo.StepSize, autoMode);

                if (brightnessTrackBar.Value != value)
                    brightnessTrackBar.Value = value;

                if (brightnessCheckBox.Checked != autoMode)
                    brightnessCheckBox.Checked = autoMode;

                brightnessTrackBar.Enabled = !autoMode;
            }
            catch (DirectShowCameraException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Sets the color enable value.
        /// </summary>
        private void SetColorEnableValue(int value, bool autoMode)
        {
            if (!_isInitialized)
                return;

            try
            {
                _camera.ImageQuality.ColorEnable = new DirectShowImageQualityPropertyValue(value * _colorEnablePropertyInfo.StepSize, autoMode);

                if (colorEnableTrackBar.Value != value)
                    colorEnableTrackBar.Value = value;

                if (colorEnableCheckBox.Checked != autoMode)
                    colorEnableCheckBox.Checked = autoMode;

                colorEnableTrackBar.Enabled = !autoMode;
            }
            catch (DirectShowCameraException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Sets the contrast value.
        /// </summary>
        private void SetContrastValue(int value, bool autoMode)
        {
            if (!_isInitialized)
                return;

            try
            {
                _camera.ImageQuality.Contrast = new DirectShowImageQualityPropertyValue(value * _contrastPropertyInfo.StepSize, autoMode);

                if (contrastTrackBar.Value != value)
                    contrastTrackBar.Value = value;

                if (contrastCheckBox.Checked != autoMode)
                    contrastCheckBox.Checked = autoMode;

                contrastTrackBar.Enabled = !autoMode;
            }
            catch (DirectShowCameraException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Sets the gain value.
        /// </summary>
        private void SetGainValue(int value, bool autoMode)
        {
            if (!_isInitialized)
                return;

            try
            {
                _camera.ImageQuality.Gain = new DirectShowImageQualityPropertyValue(value * _gainPropertyInfo.StepSize, autoMode);

                if (gainTrackBar.Value != value)
                    gainTrackBar.Value = value;

                if (gainCheckBox.Checked != autoMode)
                    gainCheckBox.Checked = autoMode;

                gainTrackBar.Enabled = !autoMode;
            }
            catch (DirectShowCameraException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Sets the gamma value.
        /// </summary>
        private void SetGammaValue(int value, bool autoMode)
        {
            if (!_isInitialized)
                return;

            try
            {
                _camera.ImageQuality.Gamma = new DirectShowImageQualityPropertyValue(value * _gammaPropertyInfo.StepSize, autoMode);

                if (gammaTrackBar.Value != value)
                    gammaTrackBar.Value = value;

                if (gammaCheckBox.Checked != autoMode)
                    gammaCheckBox.Checked = autoMode;

                gammaTrackBar.Enabled = !autoMode;
            }
            catch (DirectShowCameraException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Sets the hue value.
        /// </summary>
        private void SetHueValue(int value, bool autoMode)
        {
            if (!_isInitialized)
                return;

            try
            {
                _camera.ImageQuality.Hue = new DirectShowImageQualityPropertyValue(value * _huePropertyInfo.StepSize, autoMode);

                if (hueTrackBar.Value != value)
                    hueTrackBar.Value = value;

                if (hueCheckBox.Checked != autoMode)
                    hueCheckBox.Checked = autoMode;

                hueTrackBar.Enabled = !autoMode;
            }
            catch (DirectShowCameraException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Sets the saturation value.
        /// </summary>
        private void SetSaturationValue(int value, bool autoMode)
        {
            if (!_isInitialized)
                return;

            try
            {
                _camera.ImageQuality.Saturation = new DirectShowImageQualityPropertyValue(value * _saturationPropertyInfo.StepSize, autoMode);

                if (saturationTrackBar.Value != value)
                    saturationTrackBar.Value = value;

                if (saturationCheckBox.Checked != autoMode)
                    saturationCheckBox.Checked = autoMode;

                saturationTrackBar.Enabled = !autoMode;
            }
            catch (DirectShowCameraException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Sets the sharpness value.
        /// </summary>
        private void SetSharpnessValue(int value, bool autoMode)
        {
            if (!_isInitialized)
                return;

            try
            {
                _camera.ImageQuality.Sharpness = new DirectShowImageQualityPropertyValue(value * _sharpnessPropertyInfo.StepSize, autoMode);

                if (sharpnessTrackBar.Value != value)
                    sharpnessTrackBar.Value = value;

                if (sharpnessCheckBox.Checked != autoMode)
                    sharpnessCheckBox.Checked = autoMode;

                sharpnessTrackBar.Enabled = !autoMode;
            }
            catch (DirectShowCameraException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Sets the white balance value.
        /// </summary>
        private void SetWhiteBalanceValue(int value, bool autoMode)
        {
            if (!_isInitialized)
                return;

            try
            {
                _camera.ImageQuality.WhiteBalance = new DirectShowImageQualityPropertyValue(value * _whiteBalancePropertyInfo.StepSize, autoMode);

                if (whiteBalanceTrackBar.Value != value)
                    whiteBalanceTrackBar.Value = value;

                if (whiteBalanceCheckBox.Checked != autoMode)
                    whiteBalanceCheckBox.Checked = autoMode;

                whiteBalanceTrackBar.Enabled = !autoMode;
            }
            catch (DirectShowCameraException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #endregion

    }
}
