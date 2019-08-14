using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;


#if !REMOVE_DICOM_PLUGIN
using Vintasoft.Imaging.Codecs.ImageFiles.Dicom;
#endif
using Vintasoft.Imaging.Metadata;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// Represents a form that allows to add a DICOM data element to a DICOM data set of DICOM file.
    /// </summary>
    public partial class AddDicomDataElementForm : Form
    {

        #region Fields

#if !REMOVE_DICOM_PLUGIN
        /// <summary>
        /// The metadata of DICOM file.
        /// </summary>
        MetadataNode _metadata = null;
#endif

        #endregion



        #region Constructors

#if !REMOVE_DICOM_PLUGIN
        /// <summary>
        /// Initializes a new instance of the <see cref="AddDicomDataElementForm"/> class.
        /// </summary>
        /// <param name="metadata">The metadata of DICOM file.</param>
        public AddDicomDataElementForm(MetadataNode metadata)
        {
            if (metadata == null)
                throw new ArgumentNullException();

            InitializeComponent();


            // init combo-box with supported DICOM value types

            valueRepresentationComboBox.BeginUpdate();
            foreach (DicomValueRepresentation vr in Enum.GetValues(typeof(DicomValueRepresentation)))
            {
                if (vr == DicomValueRepresentation.UN)
                    continue;
                valueRepresentationComboBox.Items.Add(vr);
            }
            valueRepresentationComboBox.SelectedItem = DicomValueRepresentation.UT;
            valueRepresentationComboBox.EndUpdate();

            _metadata = metadata;
        }
#endif

        #endregion



        #region Methods

        /// <summary>
        /// Value type is changed.
        /// </summary>
        private void valueRepresentationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
#if !REMOVE_DICOM_PLUGIN
            if (valueRepresentationComboBox.SelectedItem == null)
                return;

            // get DICOM value type from combo-box
            DicomValueRepresentation vr = (DicomValueRepresentation)valueRepresentationComboBox.SelectedItem;


            // reset the user interface

            valueLabel.Visible = true;
            valueLabel.Text = "Value";

            valueTextBox.Visible = false;
            valueTextBox.Text = string.Empty;
            valueTextBox.MaxLength = int.MaxValue;

            valueDatePicker.Visible = false;
            valueDatePicker.Value = DateTime.Now;

            valueTimePicker.Visible = false;
            valueTimePicker.Value = DateTime.Now;

            valueAgeComboBox.Visible = false;
            valueAgeComboBox.SelectedIndex = 0;

            valueAgeNumericUpDown.Visible = false;
            valueAgeNumericUpDown.Value = 0;


            // init the user interface

            switch (vr)
            {
                // Age String
                case DicomValueRepresentation.AS:
                    valueAgeNumericUpDown.Visible = true;
                    valueAgeComboBox.Visible = true;
                    break;

                // Date
                case DicomValueRepresentation.DA:
                    valueDatePicker.Visible = true;
                    break;

                // Date Time
                case DicomValueRepresentation.DT:
                    valueDatePicker.Visible = true;
                    valueTimePicker.Visible = true;
                    break;

                // Sequence of Items
                case DicomValueRepresentation.SQ:
                    valueLabel.Visible = false;
                    break;

                // Time
                case DicomValueRepresentation.TM:
                    valueTimePicker.Visible = true;
                    break;

                default:
                    valueTextBox.Visible = true;
                    valueLabel.Text = "Enter string values (value per line)";
                    break;

            }
#endif
        }

        /// <summary>
        /// Key is pressed in text box.
        /// </summary>
        private void valueTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
#if !REMOVE_DICOM_PLUGIN
            // if a control character is pressed
            if (char.IsControl(e.KeyChar))
                return;

            // get selected type of value
            DicomValueRepresentation valueRepresentation =
                (DicomValueRepresentation)valueRepresentationComboBox.SelectedItem;

            // key is a digit?
            bool isDigit = char.IsDigit(e.KeyChar);
            // key is a letter?
            bool isLetter = char.IsLetter(e.KeyChar);
            // key is negative char
            bool isNegativeChar = false;
            if (e.KeyChar == CultureInfo.CurrentCulture.NumberFormat.NegativeSign[0])
                isNegativeChar = true;
            // key is a separator of decimal?
            bool isDecimalSeparatorChar = false;
            if (e.KeyChar == CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0])
                isDecimalSeparatorChar = true;

            switch (valueRepresentation)
            {
                // Application Entity
                case DicomValueRepresentation.AE:
                    if (!isDigit && !isLetter && e.KeyChar != '\\')
                        e.Handled = true;
                    break;

                // Code String
                case DicomValueRepresentation.CS:
                    if (!isDigit && !isLetter && e.KeyChar != '_' && e.KeyChar != ' ')
                        e.Handled = true;
                    break;

                // Attribute Tag
                case DicomValueRepresentation.AT:
                // Unsigned Long
                case DicomValueRepresentation.UL:
                // Unsigned Short
                case DicomValueRepresentation.US:
                    if (!isDigit)
                        e.Handled = true;
                    break;

                // Integer String
                case DicomValueRepresentation.IS:
                // Signed Long
                case DicomValueRepresentation.SL:
                // Signed Short
                case DicomValueRepresentation.SS:
                    if (!isDigit && !isNegativeChar)
                        e.Handled = true;
                    break;

                // DecimalString
                case DicomValueRepresentation.DS:
                // Floating PointSingle
                case DicomValueRepresentation.FL:
                // Floating Point Double
                case DicomValueRepresentation.FD:
                // Other Double String
                case DicomValueRepresentation.OD:
                // Other Float String
                case DicomValueRepresentation.OF:
                    if (!isDigit && !isNegativeChar && !isDecimalSeparatorChar)
                        e.Handled = true;
                    break;

                // Unique Identifier(UID)
                case DicomValueRepresentation.UI:
                    if (!isDigit && e.KeyChar != '.')
                        e.Handled = true;
                    break;
            }
#endif
        }

        /// <summary>
        /// "OK" button is clicked.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
#if !REMOVE_DICOM_PLUGIN
            // group numer
            ushort groupNumber = (ushort)groupNumberNumericUpDown.Value;
            // element number
            ushort elementNumber = (ushort)elementNumberNumericUpDown.Value;
            // value type
            DicomValueRepresentation valueRepresentation = (DicomValueRepresentation)valueRepresentationComboBox.SelectedItem;
            // DataElement value
            object value = null;

            try
            {
                switch (valueRepresentation)
                {
                    // Unique Identifier(UID)
                    case DicomValueRepresentation.UI:
                        List<DicomUid> uidList = new List<DicomUid>();
                        foreach (string line in valueTextBox.Lines)
                        {
                            if (!string.IsNullOrEmpty(line))
                            {
                                DicomUid uid = new DicomUid(line);
                                uidList.Add(uid);
                            }
                        }
                        value = uidList.ToArray();
                        break;

                    // Age String
                    case DicomValueRepresentation.AS:
                        string ageString = valueAgeNumericUpDown.Value.ToString();
                        string selectedItem = valueAgeComboBox.SelectedItem.ToString();
                        value = ageString + selectedItem[0];
                        break;

                    // Date
                    case DicomValueRepresentation.DA:
                        value = valueDatePicker.Value;
                        break;

                    // Date Time
                    case DicomValueRepresentation.DT:
                        DateTime date = valueDatePicker.Value;
                        DateTime time = valueTimePicker.Value;
                        DateTime dateTime = new DateTime(
                            date.Year, date.Month, date.Day,
                            time.Hour, time.Minute, time.Second);
                        value = dateTime;
                        break;

                    // Sequence of Items
                    case DicomValueRepresentation.SQ:
                        break;

                    // Time
                    case DicomValueRepresentation.TM:
                        value = valueTimePicker.Value.Subtract(valueTimePicker.Value.Date);
                        break;

                    default:
                        value = valueTextBox.Lines;
                        break;
                }

                // if type of value is sequence
                if (valueRepresentation == DicomValueRepresentation.SQ)
                {
                    DicomDataSetMetadata collectionMetadata = _metadata as DicomDataSetMetadata;
                    if (collectionMetadata != null)
                        // sequence not contains value
                        collectionMetadata.AddChild(groupNumber, elementNumber, DicomValueRepresentation.SQ);
                    else
                    {
                        DicomFrameMetadata frameMetadata = _metadata as DicomFrameMetadata;
                        if (frameMetadata != null)
                            frameMetadata.AddChild(groupNumber, elementNumber, DicomValueRepresentation.SQ);
                    }
                }
                else
                {
                    DicomDataSetMetadata collectionMetadata = _metadata as DicomDataSetMetadata;
                    if (collectionMetadata != null)
                        // sequence not contains value
                        collectionMetadata.AddChild(groupNumber, elementNumber, valueRepresentation, value);
                    else
                    {
                        DicomFrameMetadata frameMetadata = _metadata as DicomFrameMetadata;
                        if (frameMetadata != null)
                            frameMetadata.AddChild(groupNumber, elementNumber, valueRepresentation, value);
                    }
                }

                DialogResult = DialogResult.OK;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
#endif
        }

        #endregion

    }
}
