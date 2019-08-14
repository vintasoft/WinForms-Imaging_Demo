using System;
using System.Drawing.Drawing2D;
using Vintasoft.Imaging;
using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Transforms;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and change settings for the image scaling command.
    /// </summary>
    public partial class ImageScalingForm : ParamsConfigForm
    {

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageScalingForm"/> class.
        /// </summary>
        public ImageScalingForm()
            : base()
        {
            InitializeComponent();

            // initialize interpolation mode combo box
            interpolationModeComboBox.Items.Add(InterpolationMode.Default);
            interpolationModeComboBox.Items.Add(InterpolationMode.Low);
            interpolationModeComboBox.Items.Add(InterpolationMode.High);
            interpolationModeComboBox.Items.Add(InterpolationMode.Bilinear);
            interpolationModeComboBox.Items.Add(InterpolationMode.Bicubic);
            interpolationModeComboBox.Items.Add(InterpolationMode.NearestNeighbor);
            interpolationModeComboBox.Items.Add(InterpolationMode.HighQualityBilinear);
            interpolationModeComboBox.Items.Add(InterpolationMode.HighQualityBicubic);
            interpolationModeComboBox.SelectedItem = InterpolationMode.HighQualityBicubic;
        }

        #endregion



        #region Properties

        ImageScalingCommand _command;
        /// <summary>
        /// Gets or sets the image scaling command.
        /// </summary>
        public ImageScalingCommand Command
        {
            get
            {
                return _command;
            }
            set
            {
                _command = value;
            }
        }    

        /// <summary>
        /// Gets scale of the image.
        /// </summary>
        public float ImageScale
        {
            get
            {
                return (float)valueEditor.Value / 100;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Returns the current image processing command.
        /// </summary>
        /// <returns>Current image processing command.</returns>
        public override ProcessingCommandBase GetProcessingCommand()
        {
            Command.Scale = ImageScale;
            Command.InterpolationMode = (InterpolationMode)interpolationModeComboBox.SelectedItem;
            return Command;
        }

        /// <summary>
        /// "OK" button is clicked.
        /// </summary>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        /// <summary>
        /// "Cancel" button is clicked.
        /// </summary>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        /// <summary>
        /// Value is changed.
        /// </summary>
        private void valueEditorControl_ValueChanged(object sender, EventArgs e)
        {
            ExecuteProcessing();
        }

        #endregion

    }
}