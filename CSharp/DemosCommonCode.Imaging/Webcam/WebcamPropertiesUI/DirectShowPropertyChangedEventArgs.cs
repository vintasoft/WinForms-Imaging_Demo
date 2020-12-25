using System;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// Provides data for the <see cref="DirectShowPropertyControl.PropertyChanged"/> event.
    /// </summary>
    public class DirectShowPropertyChangedEventArgs : EventArgs
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectShowPropertyChangedEventArgs"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="isAuto">A value indicating whether the value must be calculated automatically.</param>
        public DirectShowPropertyChangedEventArgs(int value, bool isAuto)
        {
            _value = value;
            _isAuto = isAuto;
        }

        #endregion



        #region Properties

        int _value;
        /// <summary>
        /// Gets the current value.
        /// </summary>
        public int Value
        {
            get
            {
                return _value;
            }
        }

        bool _isAuto;
        /// <summary>
        /// Gets a value indicating whether the value must be calculate is automatically.
        /// </summary>
        /// <value>
        /// <b>True</b> if the value must be calculate is automatically; otherwise, <b>false</b>.
        /// </value>
        public bool IsAuto
        {
            get
            {
                return _isAuto;
            }
        } 

        #endregion

    }
}
