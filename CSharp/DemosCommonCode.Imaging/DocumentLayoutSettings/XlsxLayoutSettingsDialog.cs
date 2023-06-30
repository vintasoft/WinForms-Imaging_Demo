using System;
using System.ComponentModel;
using System.Windows.Forms;

using Vintasoft.Imaging.Codecs.Decoders;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A form that allows to view and edit XLSX document layout settings.
    /// </summary>
    public partial class XlsxLayoutSettingsDialog : DocumentLayoutSettingsDialog
    {

        #region Constructors

        /// <summary>
        /// Inititalizes new instance of <see cref="XlsxLayoutSettingsDialog"/>.
        /// </summary>
        public XlsxLayoutSettingsDialog()
        {
            InitializeComponent();

            LayoutSettings = CreateDefaultLayoutSettings();
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets or sets the document layout settings.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown if new value is not <see cref="XlsxDocumentLayoutSettings"/>.</exception>
        [Browsable(false)]
        [DefaultValue((DocumentLayoutSettings)null)]
        public override DocumentLayoutSettings LayoutSettings
        {
            get
            {
                if (defaultSettingsCheckBox.Checked)
                    return null;

                return base.LayoutSettings;
            }
            set
            {
                if (DesignMode)
                    return;

#if !REMOVE_OFFICE_PLUGIN
                // cast settings to XLSX document layout settings
                XlsxDocumentLayoutSettings settings = (XlsxDocumentLayoutSettings)value;

                base.LayoutSettings = settings;

                // if new settings are equal to the default settings
                if (settings.Equals(CreateDefaultLayoutSettings()))
                    // specify that default settings are used
                    defaultSettingsCheckBox.Checked = true;
                // if new settings are not equal to the default settings
                else
                    // specify that custom settings are used
                    defaultSettingsCheckBox.Checked = false;

                xlsxPageLayoutSettingsTypeControl1.Settings = settings.PageLayoutSettingsType;
                showHiddenSheetsCheckBox.Checked = settings.ShowHiddenSheets;
                showHiddenGraphicsCheckBox.Checked = settings.ShowHiddenGraphics;
#endif

                // pass settings to the control
                documentLayoutSettingsEditorControl1.LayoutSettings = base.LayoutSettings;
            }
        }

        #endregion



        #region Methods

        #region PROTECTED

        /// <summary>
        /// Returns default document layout settings.
        /// </summary>
        /// <returns>
        /// Default document layout settings.
        /// </returns>
        protected override DocumentLayoutSettings CreateDefaultLayoutSettings()
        {
#if REMOVE_OFFICE_PLUGIN
            return new DocumentLayoutSettings();
#else
            return new XlsxDocumentLayoutSettings(); 
#endif
        }

        #endregion


        #region PRIVATE

        #region UI

        /// <summary>
        /// Handles the CheckedChanged event of DefaultSettingsCheckBox object.
        /// </summary>
        private void defaultSettingsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            settingsGroupBox.Enabled = !defaultSettingsCheckBox.Checked;
        }

        /// <summary>
        /// Handles the Click event of OkButton object.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            if (defaultSettingsCheckBox.Checked)
            {
                // create default settings
                LayoutSettings = CreateDefaultLayoutSettings();
            }
            else
            {
                // get settings
                base.LayoutSettings = documentLayoutSettingsEditorControl1.LayoutSettings;
#if !REMOVE_OFFICE_PLUGIN
                XlsxDocumentLayoutSettings xlsxSettings = (XlsxDocumentLayoutSettings)LayoutSettings;
                xlsxSettings.PageLayoutSettingsType = xlsxPageLayoutSettingsTypeControl1.Settings;
                xlsxSettings.ShowHiddenSheets = showHiddenSheetsCheckBox.Checked;
                xlsxSettings.ShowHiddenGraphics = showHiddenGraphicsCheckBox.Checked;
#endif
            }

            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Handles the Click event of ButtonCancel object.
        /// </summary>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        #endregion

        #endregion

        #endregion

    }
}
