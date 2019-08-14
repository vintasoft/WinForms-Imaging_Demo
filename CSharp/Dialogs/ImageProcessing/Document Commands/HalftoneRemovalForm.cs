using System;
using System.Drawing;

using Vintasoft.Imaging;
using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Document;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    public partial class HalftoneRemovalForm : ParamsConfigForm
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

        /// <summary>
        /// Initial value of the fourth parameter.
        /// </summary>
        private ImageProcessingParameter _initialParameter4;

        /// <summary>
        /// Initial value of the fifth parameter.
        /// </summary>
        private ImageProcessingParameter _initialParameter5;

        /// <summary>
        /// Initial value of the sixth parameter.
        /// </summary>
        private ImageProcessingParameter _initialParameter6;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HalftoneRemovalForm"/> class.
        /// </summary>
        private HalftoneRemovalForm()
            : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HalftoneRemovalForm"/> class.
        /// </summary>
        public HalftoneRemovalForm(ImageViewer viewer)
            : base(viewer)
        {
            InitializeComponent();

            ImageProcessingParameter parameter1 = new ImageProcessingParameter("Max segment size", 2, 50, 10);
            ImageProcessingParameter parameter2 = new ImageProcessingParameter("Cell size", 10, 500, 20);
            ImageProcessingParameter parameter3 = new ImageProcessingParameter("Min halftone width", 10, 500, 25);
            ImageProcessingParameter parameter4 = new ImageProcessingParameter("Min halftone height", 10, 500, 25);
            ImageProcessingParameter parameter5 = new ImageProcessingParameter("Black pixel removal threshold", 0, 100, 33);
            ImageProcessingParameter parameter6 = new ImageProcessingParameter("White pixel removal threshold", 0, 100, 33);

            _initialParameter1 = parameter1;
            _initialParameter2 = parameter2;
            _initialParameter3 = parameter3;
            _initialParameter4 = parameter4;
            _initialParameter5 = parameter5;
            _initialParameter6 = parameter6;

            Text = "Halftone removal";

            groupBox1.Text = parameter1.Name;
            trackBar1.Minimum = parameter1.MinValue;
            trackBar1.Maximum = parameter1.MaxValue;
            trackBar1.Value = parameter1.DefaultValue;
            numericUpDown1.Minimum = parameter1.MinValue;
            numericUpDown1.Maximum = parameter1.MaxValue;
            numericUpDown1.Value = parameter1.DefaultValue;
            minValueLabel1.Text = parameter1.MinValue.ToString(System.Globalization.CultureInfo.InvariantCulture);
            maxValueLabel1.Text = parameter1.MaxValue.ToString(System.Globalization.CultureInfo.InvariantCulture);

            groupBox2.Text = parameter2.Name;
            trackBar2.Minimum = parameter2.MinValue;
            trackBar2.Maximum = parameter2.MaxValue;
            trackBar2.Value = parameter2.DefaultValue;
            numericUpDown2.Minimum = parameter2.MinValue;
            numericUpDown2.Maximum = parameter2.MaxValue;
            numericUpDown2.Value = parameter2.DefaultValue;
            minValueLabel2.Text = parameter2.MinValue.ToString(System.Globalization.CultureInfo.InvariantCulture);
            maxValueLabel2.Text = parameter2.MaxValue.ToString(System.Globalization.CultureInfo.InvariantCulture);

            groupBox3.Text = parameter3.Name;
            trackBar3.Minimum = parameter3.MinValue;
            trackBar3.Maximum = parameter3.MaxValue;
            trackBar3.Value = parameter3.DefaultValue;
            numericUpDown3.Minimum = parameter3.MinValue;
            numericUpDown3.Maximum = parameter3.MaxValue;
            numericUpDown3.Value = parameter3.DefaultValue;
            minValueLabel3.Text = parameter3.MinValue.ToString(System.Globalization.CultureInfo.InvariantCulture);
            maxValueLabel3.Text = parameter3.MaxValue.ToString(System.Globalization.CultureInfo.InvariantCulture);

            groupBox4.Text = parameter4.Name;
            trackBar4.Minimum = parameter4.MinValue;
            trackBar4.Maximum = parameter4.MaxValue;
            trackBar4.Value = parameter4.DefaultValue;
            numericUpDown4.Minimum = parameter4.MinValue;
            numericUpDown4.Maximum = parameter4.MaxValue;
            numericUpDown4.Value = parameter4.DefaultValue;
            minValueLabel4.Text = parameter4.MinValue.ToString(System.Globalization.CultureInfo.InvariantCulture);
            maxValueLabel4.Text = parameter4.MaxValue.ToString(System.Globalization.CultureInfo.InvariantCulture);

            autoThresholdCheckBox.Checked = false;

            groupBox5.Text = parameter5.Name;
            trackBar5.Minimum = parameter5.MinValue;
            trackBar5.Maximum = parameter5.MaxValue;
            trackBar5.Value = parameter5.DefaultValue;
            numericUpDown5.Minimum = parameter5.MinValue;
            numericUpDown5.Maximum = parameter5.MaxValue;
            numericUpDown5.Value = parameter5.DefaultValue;
            minValueLabel5.Text = parameter5.MinValue.ToString(System.Globalization.CultureInfo.InvariantCulture);
            maxValueLabel5.Text = parameter5.MaxValue.ToString(System.Globalization.CultureInfo.InvariantCulture);

            groupBox6.Text = parameter6.Name;
            trackBar6.Minimum = parameter6.MinValue;
            trackBar6.Maximum = parameter6.MaxValue;
            trackBar6.Value = parameter6.DefaultValue;
            numericUpDown6.Minimum = parameter6.MinValue;
            numericUpDown6.Maximum = parameter6.MaxValue;
            numericUpDown6.Value = parameter6.DefaultValue;
            minValueLabel6.Text = parameter6.MinValue.ToString(System.Globalization.CultureInfo.InvariantCulture);
            maxValueLabel6.Text = parameter6.MaxValue.ToString(System.Globalization.CultureInfo.InvariantCulture);

            previewCheckBox.Checked = IsPreviewEnabled;
        }

        #endregion



        #region Properties

        private int _parameter1;
        /// <summary>
        /// Value of the first parameter.
        /// </summary>
        public int Parameter1
        {
            get
            {
                return _parameter1;
            }
        }

        private int _parameter2;
        /// <summary>
        /// Value of the second parameter.
        /// </summary>
        public int Parameter2
        {
            get
            {
                return _parameter2;
            }
        }

        private int _parameter3;
        /// <summary>
        /// Value of the third parameter.
        /// </summary>
        public int Parameter3
        {
            get
            {
                return _parameter3;
            }
        }

        private int _parameter4;
        /// <summary>
        /// Value of the fourth parameter.
        /// </summary>
        public int Parameter4
        {
            get
            {
                return _parameter4;
            }
        }

        private int _parameter5;
        /// <summary>
        /// Value of the fifth parameter.
        /// </summary>
        public int Parameter5
        {
            get
            {
                return _parameter5;
            }
        }

        private int _parameter6;
        /// <summary>
        /// Value of the sixth parameter.
        /// </summary>
        public int Parameter6
        {
            get
            {
                return _parameter6;
            }
        }

        #endregion



        #region Methods

#if !REMOVE_DOCCLEANUP_PLUGIN
        /// <summary>
        /// Gets the current image processing command.
        /// </summary>
        /// <returns>Current image processing command.</returns>
        public override ProcessingCommandBase GetProcessingCommand()
        {
            HalftoneRemovalCommand command = new HalftoneRemovalCommand();
            command.MaxSegmentSize = this.Parameter1;
            command.CellSize = this.Parameter2;
            command.MinHalftoneWidth = this.Parameter3;
            command.MinHalftoneHeight = this.Parameter4;
            if (autoThresholdCheckBox.Checked)
            {
                command.AutoThreshold = true;
            }
            else
            {
                command.AutoThreshold = false;
                command.BlackPixelRemovalThreshold = this.Parameter5;
                command.WhitePixelRemovalThreshold = this.Parameter6;
            }
            return command;
        }
#endif

        /// <summary>
        /// Execute processing command.
        /// </summary>
        protected override void ExecuteProcessing()
        {
            _parameter1 = trackBar1.Value;
            _parameter2 = trackBar2.Value;
            _parameter3 = trackBar3.Value;
            _parameter4 = trackBar4.Value;
            _parameter5 = trackBar5.Value;
            _parameter6 = trackBar6.Value;
            base.ExecuteProcessing();
        }


        private void btOk_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }


        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (numericUpDown1.Value != trackBar1.Value)
                numericUpDown1.Value = trackBar1.Value;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if (numericUpDown2.Value != trackBar2.Value)
                numericUpDown2.Value = trackBar2.Value;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            if (numericUpDown3.Value != trackBar3.Value)
                numericUpDown3.Value = trackBar3.Value;
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            if (numericUpDown4.Value != trackBar4.Value)
                numericUpDown4.Value = trackBar4.Value;
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            if (numericUpDown5.Value != trackBar5.Value)
                numericUpDown5.Value = trackBar5.Value;
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            if (numericUpDown6.Value != trackBar6.Value)
                numericUpDown6.Value = trackBar6.Value;
        }


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            trackBar1.Value = (int)numericUpDown1.Value;
            ExecuteProcessing();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            trackBar2.Value = (int)numericUpDown2.Value;
            ExecuteProcessing();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            trackBar3.Value = (int)numericUpDown3.Value;
            ExecuteProcessing();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            trackBar4.Value = (int)numericUpDown4.Value;
            ExecuteProcessing();
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            trackBar5.Value = (int)numericUpDown5.Value;
            ExecuteProcessing();
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            trackBar6.Value = (int)numericUpDown6.Value;
            ExecuteProcessing();
        }


        private void buttonReset1_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = _initialParameter1.DefaultValue;
        }

        private void buttonReset2_Click(object sender, EventArgs e)
        {
            numericUpDown2.Value = _initialParameter2.DefaultValue;
        }

        private void buttonReset3_Click(object sender, EventArgs e)
        {
            numericUpDown3.Value = _initialParameter3.DefaultValue;
        }

        private void buttonReset4_Click(object sender, EventArgs e)
        {
            numericUpDown4.Value = _initialParameter4.DefaultValue;
        }

        private void buttonReset5_Click(object sender, EventArgs e)
        {
            numericUpDown5.Value = _initialParameter5.DefaultValue;
        }

        private void buttonReset6_Click(object sender, EventArgs e)
        {
            numericUpDown6.Value = _initialParameter6.DefaultValue;
        }

        private void autoThresholdCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (autoThresholdCheckBox.Checked)
            {
                groupBox5.Enabled = false;
                groupBox6.Enabled = false;
                previewCheckBox.Enabled = false;
                IsPreviewEnabled = false;
            }
            else
            {
                groupBox5.Enabled = true;
                groupBox6.Enabled = true;
                previewCheckBox.Enabled = true;
                IsPreviewEnabled = previewCheckBox.Checked;
            }

            ExecuteProcessing();
        }

        private void previewCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            IsPreviewEnabled = previewCheckBox.Checked;
            if (IsPreviewEnabled)
                previewCheckBox.ForeColor = Color.Black;
            else
                previewCheckBox.ForeColor = Color.Green;
        }

        #endregion

    }
}
