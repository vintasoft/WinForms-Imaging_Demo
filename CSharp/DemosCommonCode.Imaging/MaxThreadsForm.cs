using System;
using System.Windows.Forms;

using Vintasoft.Imaging;


namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// Represents the editor of ImagingEnvironment.MaxThreads property.
    /// </summary>
    public partial class MaxThreadsForm : Form
    {

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the MaxThreadsForm class.
        /// </summary>
        public MaxThreadsForm()
        {
            InitializeComponent();
        }

        #endregion



        #region Properties

        int _maxThreads = ImagingEnvironment.MaxThreads;
        /// <summary>
        /// Gets or sets the maximum thread count.
        /// </summary>
        public int MaxThreads
        {
            get
            {
                return _maxThreads;
            }
            set
            {
                maxThreadsTrackBar.Value = value;
                _maxThreads = value;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Sets current settings to MaxThreads property.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            MaxThreads = (int)maxThreadsTrackBar.Value;
        }

        /// <summary>
        /// Reset ImagingEnvironment.MaxThreads value.
        /// </summary>
        private void resetButton_Click(object sender, EventArgs e)
        {
            maxThreadsTrackBar.Value = _maxThreads;
        }

        /// <summary>
        /// TrackBar is changed.
        /// </summary>
        private void maxThreadsTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (maxThreadsNumericUpDown.Value != maxThreadsTrackBar.Value)
                maxThreadsNumericUpDown.Value = maxThreadsTrackBar.Value;
        }

        /// <summary>
        /// NumericUpDown is changed.
        /// </summary>
        private void maxThreadsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (maxThreadsNumericUpDown.Value != maxThreadsTrackBar.Value)
                maxThreadsTrackBar.Value = (int)maxThreadsNumericUpDown.Value;
        }

        #endregion

    }
}
