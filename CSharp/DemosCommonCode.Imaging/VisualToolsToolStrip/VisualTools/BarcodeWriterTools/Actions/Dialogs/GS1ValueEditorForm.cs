using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
#if !REMOVE_BARCODE_SDK
using Vintasoft.Barcode.GS1; 
#endif

namespace DemosCommonCode.Barcode
{
    public partial class GS1ValueEditorForm : Form
    {

        #region Fields

        bool _readOnly = false;
        bool _existsAISelected = false;
#if !REMOVE_BARCODE_SDK
        List<GS1ApplicationIdentifierValue> _identifierValuesList = new List<GS1ApplicationIdentifierValue>(); 
#endif

        #endregion



        #region Constructors

#if !REMOVE_BARCODE_SDK
        public GS1ValueEditorForm(GS1ApplicationIdentifierValue[] gs1ApplicationIdentifierValues, bool readOnly)
        {
            InitializeComponent();
            addButton.Visible = !readOnly;
            deleteButton.Visible = !readOnly;
            aiNumberComboBox.Enabled = !readOnly;
            GS1ApplicationIdentifier[] applicationIdentifiers = GS1ApplicationIdentifiers.ApplicationIdentifiers;
            for (int i = 0; i < applicationIdentifiers.Length; i++)
                aiNumberComboBox.Items.Add(string.Format("{0}: {1}", applicationIdentifiers[i].ApplicationIdentifier, applicationIdentifiers[i].DataTitle));
            _GS1ApplicationIdentifierValues = gs1ApplicationIdentifierValues;
            _identifierValuesList.AddRange(gs1ApplicationIdentifierValues);
            _readOnly = readOnly;
            aiValueTextBox.ReadOnly = readOnly;
            if (readOnly)
            {
                Text = "GS1 Value Decoder";
            }
            else
            {
                Text = "GS1 Value Editor";
            }
            ShowPrintableValue();
            ShowAI();
        } 
#endif

        #endregion



        #region Properties

#if !REMOVE_BARCODE_SDK
        GS1ApplicationIdentifierValue[] _GS1ApplicationIdentifierValues;
        public GS1ApplicationIdentifierValue[] GS1ApplicationIdentifierValues
        {
            get
            {
                return _GS1ApplicationIdentifierValues;
            }
        } 
#endif

        #endregion



        #region Methods

        /// <summary>
        /// Handles the SelectedIndexChanged event of aiNumberComboBox object.
        /// </summary>
        private void aiNumberComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_existsAISelected)
            {
#if !REMOVE_BARCODE_SDK
                GS1ApplicationIdentifier ai = GS1ApplicationIdentifiers.ApplicationIdentifiers[aiNumberComboBox.SelectedIndex];
                aiDataContentLabel.Text = ai.DataContent;
                string format = ai.Format;
                if (ai.IsContainsDecimalPoint)
                    format += " (with decimal point)";
                aiDataFormatLabel.Text = format;
                aiValueTextBox.Text = ""; 
#endif
            }
        }

        /// <summary>
        /// Handles the RowEnter event of aiListDataGridView object.
        /// </summary>
        private void aiListDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (aiListDataGridView.Rows[e.RowIndex].Cells[0].Value != null)
            {
#if !REMOVE_BARCODE_SDK
                aiNumberComboBox.SelectedIndex = GS1ApplicationIdentifiers.IndexOfApplicationIdentifier((string)aiListDataGridView.Rows[e.RowIndex].Cells[0].Value);
                aiValueTextBox.Text = (string)aiListDataGridView.Rows[e.RowIndex].Cells[2].Value; 
#endif
            }
        }

        /// <summary>
        /// Handles the Click event of addButton object.
        /// </summary>
        private void addButton_Click(object sender, EventArgs e)
        {
#if !REMOVE_BARCODE_SDK
            AddAI(GS1ApplicationIdentifiers.ApplicationIdentifiers[aiNumberComboBox.SelectedIndex].ApplicationIdentifier, aiValueTextBox.Text); 
#endif
        }

        /// <summary>
        /// Handles the Click event of deleteButton object.
        /// </summary>
        private void deleteButton_Click(object sender, EventArgs e)
        {
#if !REMOVE_BARCODE_SDK
            if (aiListDataGridView.Rows.Count > 0 && aiListDataGridView.SelectedRows.Count > 0)
            {
                int index = aiListDataGridView.SelectedRows[0].Index;
                _identifierValuesList.RemoveAt(index);
                aiListDataGridView.Rows.RemoveAt(index);
                ShowPrintableValue();
            } 
#endif
        }

        /// <summary>
        /// Handles the Click event of okButton object.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
#if !REMOVE_BARCODE_SDK
            _GS1ApplicationIdentifierValues = _identifierValuesList.ToArray(); 
#endif
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Handles the Click event of buttonCancel object.
        /// </summary>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


        private void ShowAI()
        {
#if !REMOVE_BARCODE_SDK
            if (_GS1ApplicationIdentifierValues.Length == 0)
            {
                aiNumberComboBox.SelectedIndex = 0;
            }
            else
            {
                for (int i = 0; i < _identifierValuesList.Count; i++)
                    AddAIToTable(_identifierValuesList[i]);
            } 
#endif
        }

#if !REMOVE_BARCODE_SDK
        private void AddAIToTable(GS1ApplicationIdentifierValue value)
        {
            int index = aiListDataGridView.Rows.Count;
            aiListDataGridView.Rows.Add();
            aiListDataGridView.Rows[index].Cells[0].Value = value.ApplicationIdentifier.ApplicationIdentifier;
            aiListDataGridView.Rows[index].Cells[1].Value = value.ApplicationIdentifier.DataTitle;
            aiListDataGridView.Rows[index].Cells[2].Value = value.Value;
        } 
#endif

        private void AddAI(string number, string value)
        {
#if !REMOVE_BARCODE_SDK
            GS1ApplicationIdentifierValue ai = null;
            try
            {
                ai = new GS1ApplicationIdentifierValue(GS1ApplicationIdentifiers.FindApplicationIdentifier(number), value);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _identifierValuesList.Add(ai);
            ShowPrintableValue();
            AddAIToTable(ai); 
#endif
        }

        private void ShowPrintableValue()
        {
#if !REMOVE_BARCODE_SDK
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _identifierValuesList.Count; i++)
                sb.Append(_identifierValuesList[i].ToString());
            gs1BarcodePrintableValueLabel.Text = sb.ToString(); 
#endif
        }

        #endregion

    }
}
