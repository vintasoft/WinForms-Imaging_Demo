using System;
using System.Drawing;

using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
    /// A form for image processing command with six parameters.
    /// </summary>
    public partial class SixParamsConfigForm : ParamsConfigForm
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

        /// <summary>
        /// Initial value of the sixth parameter.
        /// </summary>
        private ImageProcessingParameter _initialParameter6;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SixParamsConfigForm"/> class.
        /// </summary>
        private SixParamsConfigForm()
            : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SixParamsConfigForm"/> class.
        /// </summary>
        public SixParamsConfigForm(
            ImageViewer viewer,
            string dialogName,
            ImageProcessingParameter parameter1,
            ImageProcessingParameter parameter2,
            ImageProcessingParameter parameter3,
            ImageProcessingParameter parameter4,
            ImageProcessingParameter parameter5,
            ImageProcessingParameter parameter6)
            : base(viewer)
        {
            InitializeComponent();

            _initialParameter1 = parameter1;
            _initialParameter2 = parameter2;
            _initialParameter3 = parameter3;
            _initialParameter4 = parameter4;
            _initialParameter5 = parameter5;
            _initialParameter6 = parameter6;

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

            valueEditorControl6.ValueName = parameter6.Name;
            valueEditorControl6.MinValue = parameter6.MinValue;
            valueEditorControl6.MaxValue = parameter6.MaxValue;
            valueEditorControl6.DefaultValue = parameter6.DefaultValue;
            valueEditorControl6.Value = parameter6.DefaultValue;

            previewCheckBox.Checked = IsPreviewEnabled;
        }

        #endregion



        #region Properties

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

        private int _parameter1;
        /// <summary>
        /// Value of the first parameter.
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
        /// Value of the second parameter.
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
        /// Value of the third parameter.
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
        /// Value of the fourth parameter.
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
        /// Value of the fifth parameter.
        /// </summary>
        public int Parameter5
        {
            get
            {
                return _parameter5;
            }
        }

        private int _parameter6;
        /// <summary>
        /// Value of the sixth parameter.
        /// </summary>
        public int Parameter6
        {
            get
            {
                return _parameter6;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Execute processing command.
        /// </summary>
        protected override void ExecuteProcessing()
        {
            _parameter1 = (int)valueEditorControl1.Value;
            _parameter2 = (int)valueEditorControl2.Value;
            _parameter3 = (int)valueEditorControl3.Value;
            _parameter4 = (int)valueEditorControl4.Value;
            _parameter5 = (int)valueEditorControl5.Value;
            _parameter6 = (int)valueEditorControl6.Value;
            base.ExecuteProcessing();
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
        /// Value in a value editor control is changed.
        /// </summary>
        private void valueEditorControl_ValueChanged(object sender, EventArgs e)
        {
            ExecuteProcessing();
        }

        /// <summary>
        /// Checked state in the preview check box is changed.
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

    }
}