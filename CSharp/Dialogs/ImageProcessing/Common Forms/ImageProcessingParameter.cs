namespace ImagingDemo
{
    /// <summary>
    /// The struct that contains information about parameter of the image processing function.
    /// </summary>
	public struct ImageProcessingParameter
    {

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageProcessingParameter"/> class.
        /// </summary>
        /// <param name="name">Parameter name.</param>
        /// <param name="minValue">Minimum parameter value.</param>
        /// <param name="maxValue">Maximum parameter value.</param>
        /// <param name="defaultValue">Default parameter value.</param>
        public ImageProcessingParameter(string name, int minValue, int maxValue, int defaultValue)
		{
			_name = name;
			_minValue = minValue;
			_maxValue = maxValue;
            _defaultValue = defaultValue;
        }

        #endregion



        #region Properties

        string _name;
        /// <summary>
        /// Gets the parameter name.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
        }

        int _minValue;
        /// <summary>
        /// Gets the minimum value of the parameter.
        /// </summary>
        public int MinValue
        {
            get
            {
                return _minValue;
            }
        }

        int _maxValue;
        /// <summary>
        /// Gets the maximum value of the parameter.
        /// </summary>
        public int MaxValue
        {
            get
            {
                return _maxValue;
            }
        }

        int _defaultValue;
        /// <summary>
        /// Gets the default value of the parameter.
        /// </summary>
        public int DefaultValue
        {
            get
            {
                return _defaultValue;
            }
        }

        #endregion

    }
}
