using System;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and edit settings of the ResizeCommand.
    /// </summary>
    public partial class ResizeForm : Form
    {

        #region Fields

        /// <summary>
        /// A value indicating whether the form is initialized for the first time.
        /// </summary>
        private bool _firstInit = true;

        #endregion



        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ResizeForm"/> class.
        /// </summary>
        /// <param name="width">Image width.</param>
        /// <param name="height">Image height.</param>
        /// <param name="interpolationMode">Image interpolation mode.</param>
        public ResizeForm(int width, int height, InterpolationMode interpolationMode)
        {
            InitializeComponent();

            _imageWidth = width;
            _imageHeight = height;

            widthNumericUpDown.Value = width;
            heightNumericUpDown.Value = height;

            interpolationModeComboBox.Items.Add(InterpolationMode.Default);
            interpolationModeComboBox.Items.Add(InterpolationMode.Low);
            interpolationModeComboBox.Items.Add(InterpolationMode.High);
            interpolationModeComboBox.Items.Add(InterpolationMode.Bilinear);
            interpolationModeComboBox.Items.Add(InterpolationMode.Bicubic);
            interpolationModeComboBox.Items.Add(InterpolationMode.NearestNeighbor);
            interpolationModeComboBox.Items.Add(InterpolationMode.HighQualityBilinear);
            interpolationModeComboBox.Items.Add(InterpolationMode.HighQualityBicubic);

            interpolationModeComboBox.SelectedItem = interpolationMode;

            _firstInit = false;
        }

        #endregion



        #region Properties

        int _imageWidth;
        /// <summary>
        /// Gets the image width.
        /// </summary>
        public int ImageWidth
        {
            get
            {
                return _imageWidth;
            }
        }

        int _imageHeight;
        /// <summary>
        /// Gets the image height.
        /// </summary>
        public int ImageHeight
        {
            get
            {
                return _imageHeight;
            }
        }

        InterpolationMode _interpolationMode;
        /// <summary>
        /// Gets the image interpolation mode.
        /// </summary>
        public InterpolationMode InterpolationMode
        {
            get
            {
                return _interpolationMode;
            }
        }

        #endregion



        #region Methods

        #region UI

        /// <summary>
        /// Handles the Click event of OkButton object.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            _imageWidth = (int)widthNumericUpDown.Value;
            _imageHeight = (int)heightNumericUpDown.Value;
            _interpolationMode = (InterpolationMode)interpolationModeComboBox.SelectedItem;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        /// <summary>
        /// Handles the Click event of CancelButton object.
        /// </summary>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        /// <summary>
        /// Handles the ValueChanged event of NWidth object.
        /// </summary>
        private void nWidth_ValueChanged(object sender, EventArgs e)
        {
            if (!_firstInit && constrainProportionsCheckBox.Checked)
            {
                heightNumericUpDown.Value = Math.Min(Math.Max(1, widthNumericUpDown.Value * (decimal)_imageHeight / _imageWidth), heightNumericUpDown.Maximum);
            }
        }

        /// <summary>
        /// Handles the ValueChanged event of NHeight object.
        /// </summary>
        private void nHeight_ValueChanged(object sender, EventArgs e)
        {
            if (!_firstInit && constrainProportionsCheckBox.Checked)
            {
                widthNumericUpDown.Value = Math.Min(Math.Max(1, heightNumericUpDown.Value * (decimal)_imageWidth / _imageHeight), widthNumericUpDown.Maximum);
            }
        }

        #endregion

        #endregion

    }
}
