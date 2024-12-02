using System;
using System.ComponentModel;
using System.Drawing;

using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and edit settings of image processing command with three parameters.
    /// </summary>
    public partial class ThreeParamsConfigForm : ParamsConfigForm
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

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ThreeParamsConfigForm"/> class.
        /// </summary>
        private ThreeParamsConfigForm()
            :base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ThreeParamsConfigForm"/> class.
        /// </summary>
        /// <param name="viewer">The image viewer for image preview.</param>
        /// <param name="dialogName">Dialog name.</param>
        /// <param name="parameter1">First image processing parameter.</param>
        /// <param name="parameter2">Second image processing parameter.</param>
        /// <param name="parameter3">Third image processing parameter.</param>
        public ThreeParamsConfigForm(
            ImageViewer viewer,
            string dialogName,
            ImageProcessingParameter parameter1,
            ImageProcessingParameter parameter2,
            ImageProcessingParameter parameter3)
            : base(viewer)
        {
            InitializeComponent();

            _initialParameter1 = parameter1;
            _initialParameter2 = parameter2;
            _initialParameter3 = parameter3;

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

        private int _parameter1;
        /// <summary>
        /// Get the value of the first parameter.
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
        /// Get the value of the second parameter.
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
        /// Get the value of the third parameter.
        /// </summary>
        public int Parameter3
        {
            get
            {
                return _parameter3;
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
            _parameter3 = (int)valueEditorControl3.Value;
            base.ExecuteProcessing();
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
