using System;
using System.Drawing;

using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
    /// A form with property grid for image processing command.
    /// </summary>
    public partial class PropertyGridConfigForm : ParamsConfigForm
    {

        #region Fields

        /// <summary>
        /// Image processing command.
        /// </summary>
        ProcessingCommandBase _command;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyGridConfigForm"/> class.
        /// </summary>
        public PropertyGridConfigForm()
            : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyGridConfigForm"/> class.
        /// </summary>
        /// <param name="viewer">The image viewer for image preview.</param>
        /// <param name="command">Image processing command.</param>
        public PropertyGridConfigForm(ImageViewer viewer, ProcessingCommandBase command)
            : base(viewer)
        {
            InitializeComponent();

            _command = command;

            Text = command.Name;

            propertyGrid1.SelectedObject = command;

            previewCheckBox.Checked = IsPreviewEnabled;
        }

        #endregion



        #region Properties

        bool _isPreviewAvailable = true;
        /// <summary>
        /// Gets or sets a value indicating whether the preview in image viewer is available.
        /// </summary>
        public bool IsPreviewAvailable
        {
            get
            {
                return _isPreviewAvailable;
            }
            set
            {
                _isPreviewAvailable = value;
                IsPreviewEnabled = _isPreviewAvailable;
                previewCheckBox.Visible = _isPreviewAvailable;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the preview in image viewer is enabled.
        /// </summary>
        public override bool IsPreviewEnabled
        {
            get
            {
                return base.IsPreviewEnabled;
            }
            set
            {
                if (IsPreviewEnabled != value)
                {
                    base.IsPreviewEnabled = value;
                    previewCheckBox.Checked = value;
                }
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
            return _command;
        }

        #endregion


        #region PROTECTED

        /// <summary>
        /// Executes the processing command.
        /// </summary>
        protected override void ExecuteProcessing()
        {
            base.ExecuteProcessing();
            propertyGrid1.SelectedObject = null;
            propertyGrid1.SelectedObject = _command;
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

        /// <summary>
        /// Handles the PropertyValueChanged event of propertyGrid1 object.
        /// </summary>
        private void propertyGrid1_PropertyValueChanged(object s, System.Windows.Forms.PropertyValueChangedEventArgs e)
        {
            ExecuteProcessing();
        }

        #endregion

        #endregion

        #endregion

    }
}
