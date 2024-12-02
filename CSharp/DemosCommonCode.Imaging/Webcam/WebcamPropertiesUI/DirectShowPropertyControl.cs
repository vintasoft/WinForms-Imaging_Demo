using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A control that allows to change the webcam property.
    /// </summary>
    public partial class DirectShowPropertyControl : UserControl
    {

        #region Fields

        /// <summary>
        /// A value indicating whether the value must be calculated automatically.
        /// </summary>
        bool _isAuto;

        /// <summary>
        /// The size of the step.
        /// </summary>
        int _stepSize;

        /// <summary>
        /// The current normalized value.
        /// </summary>
        int _currentNormalizedValue;

        /// <summary>
        /// The default normalized value.
        /// </summary>
        int _defaultNormalizedValue;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectShowPropertyControl"/> class.
        /// </summary>
        public DirectShowPropertyControl()
        {
            InitializeComponent();
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets or sets the property description text.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string PropertyDescriptionText
        {
            get
            {
                return propertyDescriptionLabel.Text;
            }
            set
            {
                propertyDescriptionLabel.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the label width of <see cref="PropertyDescriptionText"/>.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public float PropertyDescriptionWidth
        {
            get
            {
                return tableLayoutPanel1.ColumnStyles[0].Width;
            }
            set
            {
                tableLayoutPanel1.ColumnStyles[0].Width = Math.Max(1, value);
                this.Update();
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Initializes the property.
        /// </summary>
        /// <param name="currentValue">The current value.</param>
        /// <param name="isAuto">A value indicating whether the value must be calculated automatically.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="stepSize">Size of the step.</param>
        public void Initialize(
                int currentValue,
                bool isAuto,
                int defaultValue,
                int minValue,
                int maxValue,
                int stepSize)
        {
            _stepSize = stepSize;

            // normalize minimum value
            int normalizeMinValue = minValue / stepSize;
            // normalize maximum value
            int normalizeMaxValue = maxValue / stepSize;

            // get default normalized value
            _defaultNormalizedValue = GetValueInRange(defaultValue / stepSize, normalizeMinValue, normalizeMaxValue);

            // get current normalized value
            _currentNormalizedValue = GetValueInRange(currentValue / stepSize, normalizeMinValue, normalizeMaxValue);

            _isAuto = isAuto;


            // update track bar

            propertyTrackBar.Minimum = normalizeMinValue;
            propertyTrackBar.Maximum = normalizeMaxValue;
            propertyTrackBar.Value = _currentNormalizedValue;
            propertyTrackBar.Enabled = !_isAuto;

            // update check box
            propertyAutoCheckBox.Checked = _isAuto;
        }

        /// <summary>
        /// Sets a default value.
        /// </summary>
        public void ResetValue()
        {
            SetValue(_defaultNormalizedValue, false);
        }

        /// <summary>
        /// Sets an initialized value.
        /// </summary>
        public void RestoreValue()
        {
            SetValue(_currentNormalizedValue, _isAuto);
        }

        #endregion


        #region PROTECTED

        /// <summary>
        /// Raises the <see cref="PropertyChanged" /> event.
        /// </summary>
        /// <param name="args">The <see cref="DirectShowPropertyChangedEventArgs"/> instance containing the event data.</param>
        protected void OnPropertyChanged(DirectShowPropertyChangedEventArgs args)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, args);
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// Handles the Scroll event of propertyTrackBar object.
        /// </summary>
        private void propertyTrackBar_Scroll(object sender, EventArgs e)
        {
            // update value
            SetValue(propertyTrackBar.Value, false);
        }

        /// <summary>
        /// Handles the CheckedChanged event of propertyAutoCheckBox object.
        /// </summary>
        private void propertyAutoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // update value
            SetValue(propertyTrackBar.Value, propertyAutoCheckBox.Checked);
        }


        /// <summary>
        /// Sets the current value.
        /// </summary>
        /// <param name="normalizadValue">The normalizad value.</param>
        /// <param name="isAuto">A value indicating whether the value must be calculated automatically.</param>
        private void SetValue(int normalizadValue, bool isAuto)
        {
            // raise changed event
            OnPropertyChanged(new DirectShowPropertyChangedEventArgs(normalizadValue * _stepSize, isAuto));

            // if track bar value must be updated
            if (propertyTrackBar.Value != normalizadValue)
                propertyTrackBar.Value = normalizadValue;

            // if check box value must be updated
            if (propertyAutoCheckBox.Checked != isAuto)
                propertyAutoCheckBox.Checked = isAuto;

            propertyTrackBar.Enabled = !isAuto;
        }

        /// <summary>
        /// Returns the value between the specified minimum value and maximum value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns>
        /// The value between the specified minimum value and maximum value.
        /// </returns>
        private int GetValueInRange(int value, int minValue, int maxValue)
        {
            if (value < minValue)
                return minValue;
            if (value > maxValue)
                return maxValue;
            return value;
        }

        #endregion

        #endregion



        #region Events

        /// <summary>
        /// Occurs when the property value is changed.
        /// </summary>
        public event EventHandler<DirectShowPropertyChangedEventArgs> PropertyChanged;

        #endregion

    }
}
