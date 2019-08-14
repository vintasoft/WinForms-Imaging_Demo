using System;
using System.Drawing;

using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
    /// A form for image processing command with two parameters.
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
        /// Initializes a new instance of the <see cref="TwoParamsConfigDialog"/> class.
        /// </summary>
        private TwoParamsConfigForm()
            :base()
		{
			InitializeComponent();
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="TwoParamsConfigDialog"/> class.
        /// </summary>
        /// <param name="viewer">Image viewer.</param>
        /// <param name="dialogName">Dialog name.</param>
        /// <param name="parameter1">First image processing parameter.</param>
        /// <param name="parameter2">Second image processing parameter.</param>
        public TwoParamsConfigForm(ImageViewer viewer, string dialogName, ImageProcessingParameter parameter1, ImageProcessingParameter parameter2)
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

		#endregion



        #region Methods
        
        /// <summary>
        /// Execute processing command.
        /// </summary>
        protected override void ExecuteProcessing()
        {
            _parameter1 = (int)valueEditorControl1.Value;
            _parameter2 = (int)valueEditorControl2.Value;
            base.ExecuteProcessing();
        }

        /// <summary>
        /// "OK" button is clicked.
        /// </summary>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            _parameter1 = (int)valueEditorControl1.Value;
            _parameter2 = (int)valueEditorControl2.Value;
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