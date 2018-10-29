using System;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ImagingDemo
{
    public partial class ResampleForm : Form
    {

        #region Constructor

        public ResampleForm(float horizontalResolution, float verticalResolution, InterpolationMode interpolationMode, string dlgCaption, bool resample)
        {
            InitializeComponent();
            this.Text = dlgCaption;
            _horizontalResolution = horizontalResolution;
            _verticalResolution = verticalResolution;

            interpolationModeComboBox.Items.Add(InterpolationMode.Default);
            interpolationModeComboBox.Items.Add(InterpolationMode.Low);
            interpolationModeComboBox.Items.Add(InterpolationMode.High);
            interpolationModeComboBox.Items.Add(InterpolationMode.Bilinear);
            interpolationModeComboBox.Items.Add(InterpolationMode.Bicubic);
            interpolationModeComboBox.Items.Add(InterpolationMode.NearestNeighbor);
            interpolationModeComboBox.Items.Add(InterpolationMode.HighQualityBilinear);
            interpolationModeComboBox.Items.Add(InterpolationMode.HighQualityBicubic);

            interpolationModeComboBox.SelectedItem = interpolationMode;

            nHorizontalResolution.Value = Math.Min((decimal)horizontalResolution, nHorizontalResolution.Maximum);
            nVerticalResolution.Value = Math.Min((decimal)verticalResolution, nVerticalResolution.Maximum);
        }

        #endregion



        #region Properties

        private float _horizontalResolution;
        public float HorizontalResolution
        {
            get
            {
                return _horizontalResolution;
            }
        }

        private float _verticalResolution;
        public float VerticalResolution
        {
            get
            {
                return _verticalResolution;
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

        public bool ShowInterpolationComboBox
        {
            get
            {
                return label1.Visible && interpolationModeComboBox.Visible;
            }
            set
            {
                label1.Visible = value;
                interpolationModeComboBox.Visible = value;
            }
        }

        #endregion



        #region Methods

        private void btOk_Click(object sender, EventArgs e)
        {
            _horizontalResolution = (float)nHorizontalResolution.Value;
            _verticalResolution = (float)nVerticalResolution.Value;
            _interpolationMode = (InterpolationMode)interpolationModeComboBox.SelectedItem;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        #endregion

    }
}