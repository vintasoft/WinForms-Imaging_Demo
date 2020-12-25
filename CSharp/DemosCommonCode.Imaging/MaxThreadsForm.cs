using System;
using System.Windows.Forms;

using Vintasoft.Imaging;


namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A form that allows to view and edit maximum count of threads (ImagingEnvironment.MaxThreads property), which should be used by SDK.
    /// </summary>
    public partial class MaxThreadsForm : Form
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MaxThreadsForm"/> class.
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
        /// Handles the Click event of OkButton object.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            // update max thread count value
            MaxThreads = (int)maxThreadsTrackBar.Value;
        }

        /// <summary>
        /// Handles the Click event of ResetButton object.
        /// </summary>
        private void resetButton_Click(object sender, EventArgs e)
        {
            // update max thread count value
            maxThreadsTrackBar.Value = _maxThreads;
        }

        /// <summary>
        /// Handles the ValueChanged event of MaxThreadsTrackBar object.
        /// </summary>
        private void maxThreadsTrackBar_ValueChanged(object sender, EventArgs e)
        {
            // if max thread count is changed
            if (maxThreadsNumericUpDown.Value != maxThreadsTrackBar.Value)
                // update max thread count value
                maxThreadsNumericUpDown.Value = maxThreadsTrackBar.Value;
        }

        /// <summary>
        /// Handles the ValueChanged event of MaxThreadsNumericUpDown object.
        /// </summary>
        private void maxThreadsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            // if max thread count is changed
            if (maxThreadsNumericUpDown.Value != maxThreadsTrackBar.Value)
                // update max thread count value
                maxThreadsTrackBar.Value = (int)maxThreadsNumericUpDown.Value;
        }

        #endregion

    }
}
