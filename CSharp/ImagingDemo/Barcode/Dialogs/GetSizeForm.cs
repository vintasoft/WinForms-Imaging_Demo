using System;
using System.Globalization;
using System.Windows.Forms;
using Vintasoft.Barcode;

namespace ImagingDemo.Barcode
{
    public partial class GetSizeForm : Form
    {

        #region Constructors

        public GetSizeForm(string variable, float value, int dpi, UnitOfMeasure units)
        {
            InitializeComponent();
            cbUnits.Items.Add(UnitOfMeasure.Pixels);
            cbUnits.Items.Add(UnitOfMeasure.Inches);
            cbUnits.Items.Add(UnitOfMeasure.Centimeters);
            cbUnits.Items.Add(UnitOfMeasure.Millimeters);
            cbUnits.SelectedItem = units;
            variableValue.Text = value.ToString(CultureInfo.InvariantCulture);
            dpiValue.Value = dpi;
            Text = string.Format(Text, variable);
            labelSize.Text = string.Format(labelSize.Text, variable);
            _dpi = dpi;
            _value = value;
            _units = units;
        }



        #endregion



        #region Properties

        float _value;
        internal float Value
        {
            get
            {
                return _value;
            }
        }

        int _dpi;
        internal int Resolution
        {
            get
            {
                return _dpi;
            }
        }

        UnitOfMeasure _units;
        internal UnitOfMeasure Units
        {
            get
            {
                return _units;
            }
        }

        #endregion 



        #region Methods

        private void buttonOK_Click(object sender, EventArgs e)
        {
            _units = (UnitOfMeasure)cbUnits.SelectedItem;
            _dpi = (int)dpiValue.Value;
            _value = float.Parse(variableValue.Text.Replace(',', '.'), CultureInfo.InvariantCulture);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion

    }
}