using System;
using System.ComponentModel;
using System.Windows.Forms;

using Vintasoft.Imaging;

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
        public ResampleForm(float horizontalResolution, float verticalResolution, ImageInterpolationMode interpolationMode, string dlgCaption, bool resample)
        {
            InitializeComponent();
            this.Text = dlgCaption;
            _horizontalResolution = horizontalResolution;
            _verticalResolution = verticalResolution;

            interpolationModeComboBox.Items.Add(ImageInterpolationMode.Bilinear);
            interpolationModeComboBox.Items.Add(ImageInterpolationMode.Bicubic);
            interpolationModeComboBox.Items.Add(ImageInterpolationMode.NearestNeighbor);
            interpolationModeComboBox.Items.Add(ImageInterpolationMode.HighQualityBilinear);
            interpolationModeComboBox.Items.Add(ImageInterpolationMode.HighQualityBicubic);

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

        private ImageInterpolationMode _interpolationMode;
        /// <summary>
        /// Gets the image interpolation mode.
        /// </summary>
        public ImageInterpolationMode InterpolationMode
        {
            get
            {
                return _interpolationMode;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether form must show the interpolation option.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
        /// Handles the Click event of okButton object.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            _horizontalResolution = (float)nHorizontalResolution.Value;
            _verticalResolution = (float)nVerticalResolution.Value;
            _interpolationMode = (ImageInterpolationMode)interpolationModeComboBox.SelectedItem;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        /// <summary>
        /// Handles the Click event of cancelButton object.
        /// </summary>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        #endregion

        #endregion

    }
}
