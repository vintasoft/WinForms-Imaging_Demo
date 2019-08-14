using System;
using System.Windows.Forms;
using Vintasoft.Imaging.Codecs.ImageFiles.Tiff;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A form that allows to add new TIFF tag to a TIFF image.
    /// </summary>
	public partial class AddTiffTagForm : Form
    {

        #region Constructor

        public AddTiffTagForm()
        {
            InitializeComponent();
        }
        
        #endregion



        #region Properties

        ushort _tagId = 58000;
		public ushort TagId
		{
			get { return _tagId; }
		}

        TiffTagDataType _tagDataType = TiffTagDataType.Ascii;
        public TiffTagDataType TagDataType
		{
			get { return _tagDataType; }
		}

		public string StringValue
		{
			get { return stringValueTextBox.Text; }
		}

		public int IntegerValue
		{
			get { return (int)integerValueNumericUpDown.Value; }
		}

		public double DoubleValue
		{
			get
			{
				double value;
				if (double.TryParse(doubleValueTextBox.Text, out value))
					return value;
				else
					return 0.0;
			}
		}

		public int NumeratorValue
		{
			get { return (int)rationalValueNumeratorNumericUpDown.Value; }
		}

		public int DenominatorValue
		{
			get { return (int)rationalValueDenominatorNumericUpDown.Value; }
		}

        #endregion



        #region Methods

        private void okButton_Click(object sender, EventArgs e)
		{
			try
			{
				if (Enum.IsDefined(typeof(ReadOnlyTiffTagId), (ReadOnlyTiffTagId)_tagId))
				{
					MessageBox.Show("Tag with ID from ReadOnlyTiffTagId enumeration cannot be added/updated.", "Add tag");
					return;
				}
			}
			catch (ArgumentException)
			{
			}

			if (_tagDataType == TiffTagDataType.Float ||
                _tagDataType == TiffTagDataType.Double)
			{
				double value;
				if (!double.TryParse(doubleValueTextBox.Text, out value))
				{
					MessageBox.Show("Double value is incorrect!", "Add tag");
					return;
				}
			}

			DialogResult = System.Windows.Forms.DialogResult.OK;
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			DialogResult = System.Windows.Forms.DialogResult.Cancel;
		}

		private void tagDataTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (tagDataTypeComboBox.SelectedIndex)
			{
				case 0: _tagDataType = TiffTagDataType.Ascii; break;
                case 1: _tagDataType = TiffTagDataType.SShort; break;
                case 2: _tagDataType = TiffTagDataType.Short; break;
                case 3: _tagDataType = TiffTagDataType.SLong; break;
                case 4: _tagDataType = TiffTagDataType.Long; break;
                case 5: _tagDataType = TiffTagDataType.Float; break;
                case 6: _tagDataType = TiffTagDataType.Double; break;
                case 7: _tagDataType = TiffTagDataType.Rational; break;
                case 8: _tagDataType = TiffTagDataType.SRational; break;
			}
			switch (tagDataTypeComboBox.SelectedIndex)
			{
				case 0:
					stringValueGroupBox.Visible = true;
					integerValueGroupBox.Visible = false;
					doubleValueGroup.Visible = false;
					rationalValueGroupBox.Visible = false;
					break;

				case 1:
				case 2:
				case 3:
				case 4:
					stringValueGroupBox.Visible = false;
					integerValueGroupBox.Visible = true;
					doubleValueGroup.Visible = false;
					rationalValueGroupBox.Visible = false;
					break;

				case 5:
				case 6:
					stringValueGroupBox.Visible = false;
					integerValueGroupBox.Visible = false;
					doubleValueGroup.Visible = true;
					rationalValueGroupBox.Visible = false;
					break;

				case 7:
				case 8:
					stringValueGroupBox.Visible = false;
					integerValueGroupBox.Visible = false;
					doubleValueGroup.Visible = false;
					rationalValueGroupBox.Visible = true;
					break;
			}
			Invalidate();
		}

		private void tagIdNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			_tagId = (ushort)tagIdNumericUpDown.Value;
        }

        #endregion

    }
}