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

        #region Structs

        /// <summary>
        /// Stores information about values of the camera control property.
        /// </summary>
        class CameraControlPropertyInfo
        {
            internal int CurrentValue;
            internal int DefaultValue;
            internal int MinValue;
            internal int MaxValue;
            internal int StepSize;
            internal bool Auto;


            internal CameraControlPropertyInfo(
                DirectShowCameraControlPropertyValue currentValue,
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

        CameraControlPropertyInfo _exposurePropertyInfo;
        CameraControlPropertyInfo _focusPropertyInfo;
        CameraControlPropertyInfo _irisPropertyInfo;
        CameraControlPropertyInfo _panPropertyInfo;
        CameraControlPropertyInfo _rollPropertyInfo;
        CameraControlPropertyInfo _tiltPropertyInfo;
        CameraControlPropertyInfo _zoomPropertyInfo;

        bool _isInitialized;

        #endregion



        #region Constructors

        public DirectShowCameraControlPropertiesControl()
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

        private void DirectShowCameraControlPropertiesControl_Load(object sender, EventArgs e)
        {
            if (_camera == null)
            {
                cameraControlPropertiesGroupBox.Enabled = false;
                return;
            }

            DirectShowCameraControlPropertyValue currentValue;
            int defaultValue, minValue, maxValue, stepSize;

            // exposure
            try
            {
                _camera.CameraControl.GetSupportedExposureValues(out minValue, out maxValue, out stepSize, out defaultValue);
                currentValue = _camera.CameraControl.Exposure;

                _exposurePropertyInfo = new CameraControlPropertyInfo(currentValue, defaultValue, minValue, maxValue, stepSize);
                InitProperty(exposureTrackBar, exposureCheckBox, _exposurePropertyInfo);
            }
            catch (DirectShowCameraException)
            {
                DisableProperty(exposureLabel, exposureTrackBar, exposureCheckBox);
            }

            // focus
            try
            {
                _camera.CameraControl.GetSupportedFocusValues(out minValue, out maxValue, out stepSize, out defaultValue);
                currentValue = _camera.CameraControl.Focus;

                _focusPropertyInfo = new CameraControlPropertyInfo(currentValue, defaultValue, minValue, maxValue, stepSize);
                InitProperty(focusTrackBar, focusCheckBox, _focusPropertyInfo);
            }
            catch (DirectShowCameraException)
            {
                DisableProperty(focusLabel, focusTrackBar, focusCheckBox);
            }

            // iris
            try
            {
                _camera.CameraControl.GetSupportedIrisValues(out minValue, out maxValue, out stepSize, out defaultValue);
                currentValue = _camera.CameraControl.Iris;

                _irisPropertyInfo = new CameraControlPropertyInfo(currentValue, defaultValue, minValue, maxValue, stepSize);
                InitProperty(irisTrackBar, irisCheckBox, _irisPropertyInfo);
            }
            catch (DirectShowCameraException)
            {
                DisableProperty(irisLabel, irisTrackBar, irisCheckBox);
            }

            // pan
            try
            {
                _camera.CameraControl.GetSupportedPanValues(out minValue, out maxValue, out stepSize, out defaultValue);
                currentValue = _camera.CameraControl.Pan;

                _panPropertyInfo = new CameraControlPropertyInfo(currentValue, defaultValue, minValue, maxValue, stepSize);
                InitProperty(panTrackBar, panCheckBox, _panPropertyInfo);
            }
            catch (DirectShowCameraException)
            {
                DisableProperty(panLabel, panTrackBar, panCheckBox);
            }

            // roll
            try
            {
                _camera.CameraControl.GetSupportedRollValues(out minValue, out maxValue, out stepSize, out defaultValue);
                currentValue = _camera.CameraControl.Roll;

                _rollPropertyInfo = new CameraControlPropertyInfo(currentValue, defaultValue, minValue, maxValue, stepSize);
                InitProperty(rollTrackBar, rollCheckBox, _rollPropertyInfo);
            }
            catch (DirectShowCameraException)
            {
                DisableProperty(rollLabel, rollTrackBar, rollCheckBox);
            }

            // tilt
            try
            {
                _camera.CameraControl.GetSupportedTiltValues(out minValue, out maxValue, out stepSize, out defaultValue);
                currentValue = _camera.CameraControl.Tilt;

                _tiltPropertyInfo = new CameraControlPropertyInfo(currentValue, defaultValue, minValue, maxValue, stepSize);
                InitProperty(tiltTrackBar, tiltCheckBox, _tiltPropertyInfo);
            }
            catch (DirectShowCameraException)
            {
                DisableProperty(tiltLabel, tiltTrackBar, tiltCheckBox);
            }

            // zoom
            try
            {
                _camera.CameraControl.GetSupportedZoomValues(out minValue, out maxValue, out stepSize, out defaultValue);
                currentValue = _camera.CameraControl.Zoom;

                _zoomPropertyInfo = new CameraControlPropertyInfo(currentValue, defaultValue, minValue, maxValue, stepSize);
                InitProperty(zoomTrackBar, zoomCheckBox, _zoomPropertyInfo);
            }
            catch (DirectShowCameraException)
            {
                DisableProperty(zoomLabel, zoomTrackBar, zoomCheckBox);
            }

            _isInitialized = true;
        }

        private void InitProperty(
            TrackBar trackBar,
            CheckBox checkBox,
            CameraControlPropertyInfo propertyInfo)
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

        private void exposureTrackBar_Scroll(object sender, EventArgs e)
        {
            SetExposureValue(exposureTrackBar.Value, false);
        }

        private void focusTrackBar_Scroll(object sender, EventArgs e)
        {
            SetFocusValue(focusTrackBar.Value, false);
        }

        private void irisTrackBar_Scroll(object sender, EventArgs e)
        {
            SetIrisValue(irisTrackBar.Value, false);
        }

        private void panTrackBar_Scroll(object sender, EventArgs e)
        {
            SetPanValue(panTrackBar.Value, false);
        }

        private void rollTrackBar_Scroll(object sender, EventArgs e)
        {
            SetRollValue(rollTrackBar.Value, false);
        }

        private void tiltTrackBar_Scroll(object sender, EventArgs e)
        {
            SetTiltValue(tiltTrackBar.Value, false);
        }

        private void zoomTrackBar_Scroll(object sender, EventArgs e)
        {
            SetZoomValue(zoomTrackBar.Value, false);
        }

        #endregion


        #region Check boxes

        private void exposureCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetExposureValue(exposureTrackBar.Value, exposureCheckBox.Checked);
        }

        private void focusCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetFocusValue(focusTrackBar.Value, focusCheckBox.Checked);
        }

        private void irisCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetIrisValue(irisTrackBar.Value, irisCheckBox.Checked);
        }

        private void panCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetPanValue(panTrackBar.Value, panCheckBox.Checked);
        }

        private void rollCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetRollValue(rollTrackBar.Value, rollCheckBox.Checked);
        }

        private void tiltCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetTiltValue(tiltTrackBar.Value, tiltCheckBox.Checked);
        }

        private void zoomCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetZoomValue(zoomTrackBar.Value, zoomCheckBox.Checked);
        }

        #endregion


        /// <summary>
        /// Resets the values of camera control properties.
        /// </summary>
        private void resetButton_Click(object sender, EventArgs e)
        {
            if (exposureLabel.Enabled)
                SetExposureValue(_exposurePropertyInfo.DefaultValue, false);

            if (focusLabel.Enabled)
                SetExposureValue(_focusPropertyInfo.DefaultValue, false);

            if (irisLabel.Enabled)
                SetIrisValue(_irisPropertyInfo.DefaultValue, false);

            if (panLabel.Enabled)
                SetPanValue(_panPropertyInfo.DefaultValue, false);

            if (rollLabel.Enabled)
                SetRollValue(_rollPropertyInfo.DefaultValue, false);

            if (tiltLabel.Enabled)
                SetTiltValue(_tiltPropertyInfo.DefaultValue, false);

            if (zoomLabel.Enabled)
                SetZoomValue(_zoomPropertyInfo.DefaultValue, false);
        }

        /// <summary>
        /// Restores the values of camera control properties.
        /// </summary>
        private void restoreButton_Click(object sender, EventArgs e)
        {
            if (exposureLabel.Enabled)
                SetExposureValue(_exposurePropertyInfo.CurrentValue, _exposurePropertyInfo.Auto);

            if (focusLabel.Enabled)
                SetExposureValue(_focusPropertyInfo.CurrentValue, _focusPropertyInfo.Auto);

            if (irisLabel.Enabled)
                SetIrisValue(_irisPropertyInfo.CurrentValue, _irisPropertyInfo.Auto);

            if (panLabel.Enabled)
                SetPanValue(_panPropertyInfo.CurrentValue, _panPropertyInfo.Auto);

            if (rollLabel.Enabled)
                SetRollValue(_rollPropertyInfo.CurrentValue, _rollPropertyInfo.Auto);

            if (tiltLabel.Enabled)
                SetTiltValue(_tiltPropertyInfo.CurrentValue, _tiltPropertyInfo.Auto);

            if (zoomLabel.Enabled)
                SetZoomValue(_zoomPropertyInfo.CurrentValue, _zoomPropertyInfo.Auto);
        }


        #region Set property value

        /// <summary>
        /// Sets the exposure value.
        /// </summary>
        private void SetExposureValue(int value, bool autoMode)
        {
            if (!_isInitialized)
                return;

            try
            {
                _camera.CameraControl.Exposure = new DirectShowCameraControlPropertyValue(value * _exposurePropertyInfo.StepSize, autoMode);

                if (exposureTrackBar.Value != value)
                    exposureTrackBar.Value = value;

                if (exposureCheckBox.Checked != autoMode)
                    exposureCheckBox.Checked = autoMode;

                exposureTrackBar.Enabled = !autoMode;
            }
            catch (DirectShowCameraException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Sets the focus value.
        /// </summary>
        private void SetFocusValue(int value, bool autoMode)
        {
            if (!_isInitialized)
                return;

            try
            {
                _camera.CameraControl.Focus = new DirectShowCameraControlPropertyValue(value * _focusPropertyInfo.StepSize, autoMode);

                if (focusTrackBar.Value != value)
                    focusTrackBar.Value = value;

                if (focusCheckBox.Checked != autoMode)
                    focusCheckBox.Checked = autoMode;

                focusTrackBar.Enabled = !autoMode;
            }
            catch (DirectShowCameraException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Sets the iris value.
        /// </summary>
        private void SetIrisValue(int value, bool autoMode)
        {
            if (!_isInitialized)
                return;

            try
            {
                _camera.CameraControl.Iris = new DirectShowCameraControlPropertyValue(value * _irisPropertyInfo.StepSize, autoMode);

                if (irisTrackBar.Value != value)
                    irisTrackBar.Value = value;

                if (irisCheckBox.Checked != autoMode)
                    irisCheckBox.Checked = autoMode;

                irisTrackBar.Enabled = !autoMode;
            }
            catch (DirectShowCameraException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Sets the pan value.
        /// </summary>
        private void SetPanValue(int value, bool autoMode)
        {
            if (!_isInitialized)
                return;

            try
            {
                _camera.CameraControl.Pan = new DirectShowCameraControlPropertyValue(value * _panPropertyInfo.StepSize, autoMode);

                if (panTrackBar.Value != value)
                    panTrackBar.Value = value;

                if (panCheckBox.Checked != autoMode)
                    panCheckBox.Checked = autoMode;

                panTrackBar.Enabled = !autoMode;
            }
            catch (DirectShowCameraException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Sets the roll value.
        /// </summary>
        private void SetRollValue(int value, bool autoMode)
        {
            if (!_isInitialized)
                return;

            try
            {
                _camera.CameraControl.Roll = new DirectShowCameraControlPropertyValue(value * _rollPropertyInfo.StepSize, autoMode);

                if (rollTrackBar.Value != value)
                    rollTrackBar.Value = value;

                if (rollCheckBox.Checked != autoMode)
                    rollCheckBox.Checked = autoMode;

                rollTrackBar.Enabled = !autoMode;
            }
            catch (DirectShowCameraException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Sets the tilt value.
        /// </summary>
        private void SetTiltValue(int value, bool autoMode)
        {
            if (!_isInitialized)
                return;

            try
            {
                _camera.CameraControl.Tilt = new DirectShowCameraControlPropertyValue(value * _tiltPropertyInfo.StepSize, autoMode);

                if (tiltTrackBar.Value != value)
                    tiltTrackBar.Value = value;

                if (tiltCheckBox.Checked != autoMode)
                    tiltCheckBox.Checked = autoMode;

                tiltTrackBar.Enabled = !autoMode;
            }
            catch (DirectShowCameraException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Sets the zoom value.
        /// </summary>
        private void SetZoomValue(int value, bool autoMode)
        {
            if (!_isInitialized)
                return;

            try
            {
                _camera.CameraControl.Zoom = new DirectShowCameraControlPropertyValue(value * _zoomPropertyInfo.StepSize, autoMode);

                if (zoomTrackBar.Value != value)
                    zoomTrackBar.Value = value;

                if (zoomCheckBox.Checked != autoMode)
                    zoomCheckBox.Checked = autoMode;

                zoomTrackBar.Enabled = !autoMode;
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
