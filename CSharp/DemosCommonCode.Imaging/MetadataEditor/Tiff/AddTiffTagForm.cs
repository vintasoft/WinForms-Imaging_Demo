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

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AddTiffTagForm"/> class.
        /// </summary>
        public AddTiffTagForm()
        {
            InitializeComponent();
        }

        #endregion



        #region Properties

        ushort _tagId = 58000;
        /// <summary>
        /// Gets the TIFF tag identifier.
        /// </summary>
        /// <value>
        /// Default value is <b>58000</b>.
        /// </value>
        public ushort TagId
        {
            get
            {
                return _tagId;
            }
        }

        TiffTagDataType _tagDataType = TiffTagDataType.Ascii;
        /// <summary>
        /// Get the TIFF tag data type.
        /// </summary>
        /// <value>
        /// Default value is <see cref="TiffTagDataType"/>.Ascii.
        /// </value>
        public TiffTagDataType TagDataType
        {
            get
            {
                return _tagDataType;
            }
        }

        /// <summary>
        /// Gets the tag value as string.
        /// </summary>
        public string StringValue
        {
            get
            {
                return stringValueTextBox.Text;
            }
        }

        /// <summary>
        /// Gets the tag value as integer.
        /// </summary>
        public int IntegerValue
        {
            get
            {
                return (int)integerValueNumericUpDown.Value;
            }
        }

        /// <summary>
        /// Gets the tag value as double.
        /// </summary>
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

        /// <summary>
        /// Gets the tag numerator value.
        /// </summary>
        public int NumeratorValue
        {
            get
            {
                return (int)rationalValueNumeratorNumericUpDown.Value;
            }
        }

        /// <summary>
        /// Gets the tag denomerator value.
        /// </summary>
        public int DenominatorValue
        {
            get
            {
                return (int)rationalValueDenominatorNumericUpDown.Value;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Handles the Click event of OkButton object.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                // if current tag is read only
                if (Enum.IsDefined(typeof(ReadOnlyTiffTagId), (ReadOnlyTiffTagId)_tagId))
                {
                    MessageBox.Show("Tag with ID from ReadOnlyTiffTagId enumeration cannot be added/updated.", "Add tag");
                    return;
                }
            }
            catch (ArgumentException)
            {
            }

            // if current tag value is real
            if (_tagDataType == TiffTagDataType.Float ||
                _tagDataType == TiffTagDataType.Double)
            {
                double value;
                // if current tag value can not be conterted to double value
                if (!double.TryParse(doubleValueTextBox.Text, out value))
                {
                    MessageBox.Show("Double value is incorrect!", "Add tag");
                    return;
                }
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of TagDataTypeComboBox object.
        /// </summary>
        private void tagDataTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // update TIFF tag data type

            switch (tagDataTypeComboBox.SelectedIndex)
            {
                case 0:
                    _tagDataType = TiffTagDataType.Ascii;
                    break;

                case 1:
                    _tagDataType = TiffTagDataType.SShort;
                    break;

                case 2:
                    _tagDataType = TiffTagDataType.Short;
                    break;

                case 3:
                    _tagDataType = TiffTagDataType.SLong;
                    break;

                case 4:
                    _tagDataType = TiffTagDataType.Long;
                    break;

                case 5:
                    _tagDataType = TiffTagDataType.Float;
                    break;

                case 6:
                    _tagDataType = TiffTagDataType.Double;
                    break;

                case 7:
                    _tagDataType = TiffTagDataType.Rational;
                    break;

                case 8:
                    _tagDataType = TiffTagDataType.SRational;
                    break;
            }


            // update user interface

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

        /// <summary>
        /// Handles the ValueChanged event of TagIdNumericUpDown object.
        /// </summary>
        private void tagIdNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            // update the TIFF tag data indentifier
            _tagId = (ushort)tagIdNumericUpDown.Value;
        }

        #endregion

    }
}
