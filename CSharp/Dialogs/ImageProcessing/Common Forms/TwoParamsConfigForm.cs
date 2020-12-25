using System;
using System.Drawing;

using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and edit settings of image processing command with two parameters.
    /// </summary>
    public partial class TwoParamsConfigForm : ParamsConfigForm
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

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TwoParamsConfigForm"/> class.
        /// </summary>
        private TwoParamsConfigForm()
            :base()
		{
			InitializeComponent();
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="TwoParamsConfigForm"/> class.
        /// </summary>
        /// <param name="viewer">The image viewer for image preview.</param>
        /// <param name="dialogName">Dialog name.</param>
        /// <param name="parameter1">First image processing parameter.</param>
        /// <param name="parameter2">Second image processing parameter.</param>
        public TwoParamsConfigForm(
            ImageViewer viewer,
            string dialogName,
            ImageProcessingParameter parameter1,
            ImageProcessingParameter parameter2)
			: base(viewer)
		{
            InitializeComponent();

            Text = dialogName;

            _initialParameter1 = parameter1;
			_initialParameter2 = parameter2;

            valueEditorControl1.ValueName = parameter1.Name;
            valueEditorControl1.MinValue = parameter1.MinValue;
            valueEditorControl1.MaxValue = parameter1.MaxValue;
            valueEditorControl1.DefaultValue = parameter1.DefaultValue;
            valueEditorControl1.Value = parameter1.DefaultValue;

            valueEditorControl2.ValueName = parameter2.Name;
            valueEditorControl2.MinValue = parameter2.MinValue;
            valueEditorControl2.MaxValue = parameter2.MaxValue;
            valueEditorControl2.DefaultValue = parameter2.DefaultValue;
            valueEditorControl2.Value = parameter2.DefaultValue;

            previewCheckBox.Checked = IsPreviewEnabled;
		}

		#endregion



		#region Properties

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

		int _parameter1;
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

		int _parameter2;
        /// <summary>
        /// Gets the value of the second parameter.
        /// </summary>
		public int Parameter2
		{
			get
			{
				return _parameter2;
			}
		}

        #endregion



        #region Methods

        #region PROTECTED

        /// <summary>
        /// Executes processing command.
        /// </summary>
        protected override void ExecuteProcessing()
        {
            _parameter1 = (int)valueEditorControl1.Value;
            _parameter2 = (int)valueEditorControl2.Value;
            base.ExecuteProcessing();
        }

        #endregion


        #region PRIVATE

        #region UI

        /// <summary>
        /// Handles the Click event of OkButton object.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            _parameter1 = (int)valueEditorControl1.Value;
            _parameter2 = (int)valueEditorControl2.Value;
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
        /// Handles the ValueChanged event of ValueEditorControl object.
        /// </summary>
        private void valueEditorControl_ValueChanged(object sender, EventArgs e)
        {
            ExecuteProcessing();
        }

        /// <summary>
        /// Handles the CheckedChanged event of PreviewCheckBox object.
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
