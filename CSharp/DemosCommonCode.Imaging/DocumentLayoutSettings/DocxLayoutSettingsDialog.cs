using System;
using System.ComponentModel;
using System.Windows.Forms;

using Vintasoft.Imaging.Codecs.Decoders;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A form that allows to view and edit DOCX document layout settings.
    /// </summary>
    public partial class DocxLayoutSettingsDialog : DocumentLayoutSettingsDialog
    {

        #region Constructors

        /// <summary>
        /// Inititalizes new instance of <see cref="DocxLayoutSettingsDialog"/>.
        /// </summary>
        public DocxLayoutSettingsDialog()
        {
            InitializeComponent();

            LayoutSettings = CreateDefaultLayoutSettings();
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets or sets the document layout settings.
        /// </summary>
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
                // cast settings to DOCX document layout settings
                DocxDocumentLayoutSettings settings = (DocxDocumentLayoutSettings)value;

                base.LayoutSettings = value;

                // if new value equals to the default settings
                if (value.Equals(CreateDefaultLayoutSettings()))
                    // specify that default settings are used
                    defaultSettingsCheckBox.Checked = true;
                // if new value is not equal to the default settings
                else
                    // specify that custom settings are used
                    defaultSettingsCheckBox.Checked = false;

                showHiddenContentCheckBox.Checked = settings.ShowHiddenContent;
#endif

                // pass the settings to the control
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
            return new DocxDocumentLayoutSettings();
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
            // if default settings must be used
            if (defaultSettingsCheckBox.Checked)
            {
                // create default settings
                LayoutSettings = CreateDefaultLayoutSettings();
            }
            // if custom settings must be used
            else
            {
                // get settings from control
                base.LayoutSettings = documentLayoutSettingsEditorControl1.LayoutSettings;
#if !REMOVE_OFFICE_PLUGIN
                ((DocxDocumentLayoutSettings)LayoutSettings).ShowHiddenContent = showHiddenContentCheckBox.Checked;
#endif
            }

            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Handles the Click event of CancelButton object.
        /// </summary>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        #endregion

        #endregion

        #endregion

    }
}
