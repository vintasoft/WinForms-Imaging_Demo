using System;
using System.ComponentModel;
using System.Drawing;

using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and edit settings of image processing command with one parameter.
    /// </summary>
    public partial class OneParamConfigForm : ParamsConfigForm
    {

        #region Fields

        /// <summary>
        /// Initial value of the first parameter.
        /// </summary>
        private ImageProcessingParameter _initialParameter1;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OneParamConfigForm"/> class.
        /// </summary>
        public OneParamConfigForm()
            :base()
		{
			InitializeComponent();
		}


        /// <summary>
        /// Initializes a new instance of the <see cref="OneParamConfigForm"/> class.
        /// </summary>
        /// <param name="viewer">The image viewer for image preview.</param>
        /// <param name="dialogName">Dialog name.</param>
        /// <param name="parameter1">Image processing parameter.</param>
		public OneParamConfigForm(ImageViewer viewer, string dialogName, ImageProcessingParameter parameter1)
			: base(viewer)
		{
            InitializeComponent();

            Text = dialogName;

            _initialParameter1 = parameter1;
            valueEditor.ValueName = parameter1.Name;
            valueEditor.MinValue = parameter1.MinValue;
            valueEditor.MaxValue = parameter1.MaxValue;
            valueEditor.DefaultValue = parameter1.DefaultValue;
            valueEditor.Value = parameter1.DefaultValue;
            previewCheckBox.Checked = IsPreviewEnabled;
		}

        #endregion



        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether the preview in image viewer is enabled.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        /// <summary>
        /// Gets or sets a value indicating whether the preview in image viewer is possible.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool CanPreview
        {
            get
            {
                return previewCheckBox.Visible;
            }
            set
            {
                if (!value)
                    IsPreviewEnabled = false;
                previewCheckBox.Visible = value;
            }
        }

		private int _parameter1;
        /// <summary>
        /// Gets the value of the first parameter.
        /// </summary>
		public int Parameter1
		{
			get
			{
				return _parameter1;
			}
		}

        #endregion



        #region Methods

        #region PROTECTED

        /// <summary>
        /// Execute processing command.
        /// </summary>
        protected override void ExecuteProcessing()
        {
            _parameter1 = (int)valueEditor.Value;
            base.ExecuteProcessing();
        }

        #endregion


        #region PRIVATE

        #region UI

        /// <summary>
        /// Handles the Click event of buttonOk object.
        /// </summary>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

/// <summary>
/// Handles the Click event of buttonCancel object.
/// </summary>
		private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        /// <summary>
        /// Handles the ValueChanged event of valueEditorControl object.
        /// </summary>
        private void valueEditorControl_ValueChanged(object sender, EventArgs e)
        {
            ExecuteProcessing();
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
