using System;
using System.Drawing;

using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and edit settings of image processing command with five parameters.
    /// </summary>
    public partial class FiveParamsConfigForm : ParamsConfigForm
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

        /// <summary>
        /// Initial value of the third parameter.
        /// </summary>
        private ImageProcessingParameter _initialParameter3;

        /// <summary>
        /// Initial value of the fourth parameter.
        /// </summary>
        private ImageProcessingParameter _initialParameter4;

        /// <summary>
        /// Initial value of the fifth parameter.
        /// </summary>
        private ImageProcessingParameter _initialParameter5;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FiveParamsConfigForm"/> class.
        /// </summary>
        private FiveParamsConfigForm()
            : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FiveParamsConfigForm"/> class.
        /// </summary>
        /// <param name="viewer">The image viewer for image preview.</param>
        /// <param name="dialogName">Dialog name.</param>
        /// <param name="parameter1">First image processing parameter.</param>
        /// <param name="parameter2">Second image processing parameter.</param>
        /// <param name="parameter3">Third image processing parameter.</param>
        /// <param name="parameter4">Fourth image processing parameter.</param>
        /// <param name="parameter5">Fifth image processing parameter.</param>
        public FiveParamsConfigForm(
            ImageViewer viewer,
            string dialogName,
            ImageProcessingParameter parameter1,
            ImageProcessingParameter parameter2,
            ImageProcessingParameter parameter3,
            ImageProcessingParameter parameter4,
            ImageProcessingParameter parameter5)
            : base(viewer)
        {
            InitializeComponent();

            _initialParameter1 = parameter1;
            _initialParameter2 = parameter2;
            _initialParameter3 = parameter3;
            _initialParameter4 = parameter4;
            _initialParameter5 = parameter5;

            Text = dialogName;


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

            valueEditorControl3.ValueName = parameter3.Name;
            valueEditorControl3.MinValue = parameter3.MinValue;
            valueEditorControl3.MaxValue = parameter3.MaxValue;
            valueEditorControl3.DefaultValue = parameter3.DefaultValue;
            valueEditorControl3.Value = parameter3.DefaultValue;

            valueEditorControl4.ValueName = parameter4.Name;
            valueEditorControl4.MinValue = parameter4.MinValue;
            valueEditorControl4.MaxValue = parameter4.MaxValue;
            valueEditorControl4.DefaultValue = parameter4.DefaultValue;
            valueEditorControl4.Value = parameter4.DefaultValue;

            valueEditorControl5.ValueName = parameter5.Name;
            valueEditorControl5.MinValue = parameter5.MinValue;
            valueEditorControl5.MaxValue = parameter5.MaxValue;
            valueEditorControl5.DefaultValue = parameter5.DefaultValue;
            valueEditorControl5.Value = parameter5.DefaultValue;

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

        private int _parameter2;
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

        private int _parameter3;
        /// <summary>
        /// Gets the value of the third parameter.
        /// </summary>
        public int Parameter3
        {
            get
            {
                return _parameter3;
            }
        }

        private int _parameter4;
        /// <summary>
        /// Gets the value of the fourth parameter.
        /// </summary>
        public int Parameter4
        {
            get
            {
                return _parameter4;
            }
        }

        private int _parameter5;
        /// <summary>
        /// Gets the value of the fifth parameter.
        /// </summary>
        public int Parameter5
        {
            get
            {
                return _parameter5;
            }
        }

        #endregion



        #region Methods

        #region PROTECTED

        /// <summary>
        /// Executes the processing command.
        /// </summary>
        protected override void ExecuteProcessing()
        {
            _parameter1 = (int)valueEditorControl1.Value;
            _parameter2 = (int)valueEditorControl2.Value;
            _parameter3 = (int)valueEditorControl3.Value;
            _parameter4 = (int)valueEditorControl4.Value;
            _parameter5 = (int)valueEditorControl5.Value;
            base.ExecuteProcessing();
        }

        #endregion


        #region PRIVATE

        #region UI

        /// <summary>
        /// Handles the Click event of ButtonOk object.
        /// </summary>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        /// <summary>
        /// Handles the Click event of ButtonCancel object.
        /// </summary>
        private void buttonCancel_Click(object sender, EventArgs e)
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
