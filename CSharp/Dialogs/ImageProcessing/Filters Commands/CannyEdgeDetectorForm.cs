using System;
using System.Drawing;

using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Filters;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and edit settings of the CannyEdgeDetectorCommand.
    /// </summary>
    public partial class CannyEdgeDetectorForm : ParamsConfigForm
    {

        #region Fields

        /// <summary>
        /// Initial value of the first parameter.
        /// </summary>
        private ImageProcessingParameter _initialParameter1;

        /// <summary>
        /// Initial value of the second parameter.
        /// </summary>
        private ImageProcessingParameter _initialParameter2;

        /// <summary>
        /// Initial value of the third parameter.
        /// </summary>
        private ImageProcessingParameter _initialParameter3;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CannyEdgeDetectorForm"/> class.
        /// </summary>
        private CannyEdgeDetectorForm()
            : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CannyEdgeDetectorForm"/> class.
        /// </summary>
        /// <param name="viewer">The image viewer for image preview.</param>
        public CannyEdgeDetectorForm(ImageViewer viewer)
            : base(viewer)
        {
            InitializeComponent();

            _initialParameter1 = new ImageProcessingParameter("Blur radius", 1, 15, 3);
            _initialParameter2 = new ImageProcessingParameter("High threshold", 0, 255, 80);
            _initialParameter3 = new ImageProcessingParameter("Low threshold", 0, 255, 20);

            groupBox1.Text = _initialParameter1.Name;
            trackBar1.Minimum = _initialParameter1.MinValue;
            trackBar1.Maximum = _initialParameter1.MaxValue;
            trackBar1.Value = _initialParameter1.DefaultValue;
            numericUpDown1.Minimum = _initialParameter1.MinValue;
            numericUpDown1.Maximum = _initialParameter1.MaxValue;
            numericUpDown1.Value = _initialParameter1.DefaultValue;
            minValueLabel1.Text = _initialParameter1.MinValue.ToString(System.Globalization.CultureInfo.InvariantCulture);
            maxValueLabel1.Text = _initialParameter1.MaxValue.ToString(System.Globalization.CultureInfo.InvariantCulture);

            groupBox2.Text = _initialParameter2.Name;
            trackBar2.Minimum = _initialParameter2.MinValue;
            trackBar2.Maximum = _initialParameter2.MaxValue;
            trackBar2.Value = _initialParameter2.DefaultValue;
            numericUpDown2.Minimum = _initialParameter2.MinValue;
            numericUpDown2.Maximum = _initialParameter2.MaxValue;
            numericUpDown2.Value = _initialParameter2.DefaultValue;
            minValueLabel2.Text = trackBar2.Minimum.ToString(System.Globalization.CultureInfo.InvariantCulture);
            maxValueLabel2.Text = trackBar2.Maximum.ToString(System.Globalization.CultureInfo.InvariantCulture);

            groupBox3.Text = _initialParameter3.Name;
            trackBar3.Minimum = _initialParameter3.MinValue;
            trackBar3.Maximum = _initialParameter2.DefaultValue;
            trackBar3.Value = _initialParameter3.DefaultValue;
            numericUpDown3.Minimum = _initialParameter3.MinValue;
            numericUpDown3.Maximum = _initialParameter3.MaxValue;
            numericUpDown3.Value = _initialParameter3.DefaultValue;
            minValueLabel3.Text = trackBar3.Minimum.ToString(System.Globalization.CultureInfo.InvariantCulture);
            maxValueLabel3.Text = trackBar3.Maximum.ToString(System.Globalization.CultureInfo.InvariantCulture);

            previewCheckBox.Checked = IsPreviewEnabled;
        }

        #endregion



        #region Properties

        int _blurRadius;
        /// <summary>
        /// Gets the blur radius.
        /// </summary>
        public int BlurRadius
        {
            get
            {
                return _blurRadius;
            }
        }

        byte _highThreshold;
        /// <summary>
        /// Gets the high threshold.
        /// </summary>
        public byte HighThreshold
        {
            get
            {
                return _highThreshold;
            }
        }

        byte _lowThreshold;
        /// <summary>
        /// Gets the low threshold.
        /// </summary>
        public byte LowThreshold
        {
            get
            {
                return _lowThreshold;
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Returns the image processing command.
        /// </summary>
        /// <returns>The image processing command.</returns>
        public override ProcessingCommandBase GetProcessingCommand()
        {
            if (HighThreshold < LowThreshold)
                return new CannyEdgeDetectorCommand(BlurRadius, HighThreshold, HighThreshold);
            else
                return new CannyEdgeDetectorCommand(BlurRadius, HighThreshold, LowThreshold);
        }

        #endregion


        #region PROTECTED

        /// <summary>
        /// Executes processing command.
        /// </summary>
        protected override void ExecuteProcessing()
        {
            _blurRadius = trackBar1.Value;
            _highThreshold = (byte)trackBar2.Value;
            _lowThreshold = (byte)trackBar3.Value;
            base.ExecuteProcessing();
        }

        #endregion


        #region PRIVATE

        #region UI

        /// <summary>
        /// Handles the Click event of okButton object.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        /// <summary>
        /// Handles the Click event of cancelButton object.
        /// </summary>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        /// <summary>
        /// Handles the Scroll event of trackBar1 object.
        /// </summary>
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (numericUpDown1.Value != trackBar1.Value)
                numericUpDown1.Value = trackBar1.Value;
        }

        /// <summary>
        /// Handles the Scroll event of trackBar2 object.
        /// </summary>
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if (numericUpDown2.Value != trackBar2.Value)
                numericUpDown2.Value = trackBar2.Value;

            trackBar3.Maximum = trackBar2.Value;
            numericUpDown3.Maximum = trackBar2.Value;
            maxValueLabel3.Text = trackBar2.Value.ToString();
        }

        /// <summary>
        /// Handles the Scroll event of trackBar3 object.
        /// </summary>
        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            if (numericUpDown3.Value != trackBar3.Value)
                numericUpDown3.Value = trackBar3.Value;
        }

        /// <summary>
        /// Handles the ValueChanged event of numericUpDown1 object.
        /// </summary>
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            trackBar1.Value = (int)numericUpDown1.Value;
            ExecuteProcessing();
        }

        /// <summary>
        /// Handles the ValueChanged event of numericUpDown2 object.
        /// </summary>
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            trackBar2.Value = (int)numericUpDown2.Value;
            ExecuteProcessing();
        }

        /// <summary>
        /// Handles the ValueChanged event of numericUpDown3 object.
        /// </summary>
        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            trackBar3.Value = (int)numericUpDown3.Value;
            ExecuteProcessing();
        }

        /// <summary>
        /// Handles the Click event of buttonReset1 object.
        /// </summary>
        private void buttonReset1_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = _initialParameter1.DefaultValue;
        }

        /// <summary>
        /// Handles the Click event of buttonReset2 object.
        /// </summary>
        private void buttonReset2_Click(object sender, EventArgs e)
        {
            numericUpDown2.Value = _initialParameter2.DefaultValue;
        }

        /// <summary>
        /// Handles the Click event of buttonReset3 object.
        /// </summary>
        private void buttonReset3_Click(object sender, EventArgs e)
        {
            numericUpDown3.Value = _initialParameter3.DefaultValue;
        }

        /// <summary>
        /// Handles the CheckedChanged event of previewCheckBox object.
        /// </summary>
        private void previewCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            IsPreviewEnabled = previewCheckBox.Checked;
            if (IsPreviewEnabled)
                previewCheckBox.ForeColor = Color.Black;
            else
                previewCheckBox.ForeColor = Color.Green;
        }

        #endregion

        #endregion

        #endregion

    }
}
