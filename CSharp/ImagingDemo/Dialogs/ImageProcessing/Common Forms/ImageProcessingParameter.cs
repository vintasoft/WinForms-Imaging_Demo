namespace ImagingDemo
{
    /// <summary>
    /// Struct that contains information about parameter of image processing function.
    /// </summary>
	public struct ImageProcessingParameter
    {

        #region Constructor

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
        /// Name of the parameter.
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
        /// Minimal value of parameter.
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
        /// Maximal value of parameter.
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
        /// Default value of parameter.
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
