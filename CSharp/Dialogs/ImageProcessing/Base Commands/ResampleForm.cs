using System;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and edit settings of the ResampleCommand.
    /// </summary>
    public partial class ResampleForm : Form
    {

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ResampleForm"/> class.
        /// </summary>
        /// <param name="horizontalResolution">The horizontal resolution of the image.</param>
        /// <param name="verticalResolution">The vertical resolution of the image.</param>
        /// <param name="interpolationMode">The image interpolation mode.</param>
        /// <param name="dlgCaption">Title text.</param>
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
        /// <summary>
        /// Gets the image horizontal resolution.
        /// </summary>
        public float HorizontalResolution
        {
            get
            {
                return _horizontalResolution;
            }
        }

        private float _verticalResolution;
        /// <summary>
        /// Gets the image vertical resolution.
        /// </summary>
        public float VerticalResolution
        {
            get
            {
                return _verticalResolution;
            }
        }

        private InterpolationMode _interpolationMode;
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

        /// <summary>
        /// Gets or sets a value indicating whether form must show the interpolation option.
        /// </summary>
        public bool ShowInterpolationComboBox
        {
            get
            {
                return interpolationLabel.Visible && interpolationModeComboBox.Visible;
            }
            set
            {
                interpolationLabel.Visible = value;
                interpolationModeComboBox.Visible = value;
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
            _horizontalResolution = (float)nHorizontalResolution.Value;
            _verticalResolution = (float)nVerticalResolution.Value;
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

        #endregion

        #endregion

    }
}
