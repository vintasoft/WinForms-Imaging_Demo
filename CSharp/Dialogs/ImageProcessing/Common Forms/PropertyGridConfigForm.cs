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



        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="OneParamConfigDialog"/> class.
        /// </summary>
        public PropertyGridConfigForm()
            : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OneParamConfigDialog"/> class.
        /// </summary>
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
        /// Gets or sets a flag that indicates when preview in ImageViewer is available.
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
        /// Gets or sets a flag that indicates when preview in ImageViewer is enabled.
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

        protected override void ExecuteProcessing()
        {
            base.ExecuteProcessing();
            propertyGrid1.SelectedObject = null;
            propertyGrid1.SelectedObject = _command;
        }

        /// <summary>
        /// Gets the current image processing command.
        /// </summary>
        /// <returns>Current image processing command.</returns>
        public override ProcessingCommandBase GetProcessingCommand()
        {
            return _command;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void previewCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            IsPreviewEnabled = previewCheckBox.Checked;
            if (IsPreviewEnabled)
                previewCheckBox.ForeColor = Color.Black;
            else
                previewCheckBox.ForeColor = Color.Green;
        }

        private void propertyGrid1_PropertyValueChanged(object s, System.Windows.Forms.PropertyValueChangedEventArgs e)
        {
            ExecuteProcessing();
        }

        #endregion

    }
}