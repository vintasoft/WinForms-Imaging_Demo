using System;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ImagingDemo
{
    public partial class ResizeForm : Form
    {

        #region Fields

        private bool _firstInit = true;

        #endregion



        #region Constructor

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

        private int _imageWidth;
        public int ImageWidth
        {
            get
            {
                return _imageWidth;
            }
        }

        private int _imageHeight;
        public int ImageHeight
        {
            get
            {
                return _imageHeight;
            }
        }

        private InterpolationMode _interpolationMode;
        public InterpolationMode InterpolationMode
        {
            get
            {
                return _interpolationMode;
            }
        }

        #endregion



        #region Methods

        private void btOk_Click(object sender, EventArgs e)
        {
            _imageWidth = (int)widthNumericUpDown.Value;
            _imageHeight = (int)heightNumericUpDown.Value;
            _interpolationMode = (InterpolationMode)interpolationModeComboBox.SelectedItem;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void nWidth_ValueChanged(object sender, EventArgs e)
        {
            if (!_firstInit && constrainProportionsCheckBox.Checked)
            {
                heightNumericUpDown.Value = Math.Min(Math.Max(1, widthNumericUpDown.Value * (decimal)_imageHeight / _imageWidth), heightNumericUpDown.Maximum);
            }
        }

        private void nHeight_ValueChanged(object sender, EventArgs e)
        {
            if (!_firstInit && constrainProportionsCheckBox.Checked)
            {
                widthNumericUpDown.Value = Math.Min(Math.Max(1, heightNumericUpDown.Value * (decimal)_imageWidth / _imageHeight), widthNumericUpDown.Maximum);
            }
        }

        #endregion

    }
}