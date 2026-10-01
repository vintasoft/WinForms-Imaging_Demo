using System;
using System.ComponentModel;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Codecs.Decoders;
using Vintasoft.Imaging.Utils;

namespace CommonCode.Imaging
{
    /// <summary>
    /// A form that allows to view and edit Email document layout settings.
    /// </summary>
    public partial class EmailLayoutSettingsDialog :  DocumentLayoutSettingsDialog
    {

        #region Constructors

        /// <summary>
        /// Inititalizes new instance of <see cref="EmailLayoutSettingsDialog"/>.
        /// </summary>
        public EmailLayoutSettingsDialog()
        {
            InitializeComponent();

            // init "PageSize"
            pageSizeComboBox.Items.Add("Undefined");

            Array paperSizeKindValues = Enum.GetValues(typeof(PaperSizeKind));
            string[] paperSizeKindValuesText = new string[paperSizeKindValues.Length];
            for (int i = 0; i < paperSizeKindValues.Length; i++)
                paperSizeKindValuesText[i] = paperSizeKindValues.GetValue(i).ToString();
            Array.Sort(paperSizeKindValuesText, paperSizeKindValues);

            foreach (object item in paperSizeKindValues)
                pageSizeComboBox.Items.Add(item);
        }

        /// <summary>
        /// Inititalizes new instance of <see cref="EmailLayoutSettingsDialog"/>.
        /// </summary>
        public EmailLayoutSettingsDialog(ImageCollection images)
            : this()
        {
            LayoutSettingsManager = images.LayoutSettings;
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets the name of the codec.
        /// </summary>
        [Browsable(false)]
        public override string CodecName
        {
            get
            {
                return "Email";
            }
        }

        /// <summary>
        /// Gets or sets the document layout settings.
        /// </summary>
        [Browsable(false)]
        [DefaultValue((DocumentLayoutSettings)null)]
        public override DocumentLayoutSettings LayoutSettings
        {
            get
            {
                return base.LayoutSettings;
            }
            set
            {
                if (DesignMode)
                    return;

#if !REMOVE_EMAIL_CODEC
                EmailLayoutSettings emailLayoutSettings = value as EmailLayoutSettings;
                if (emailLayoutSettings == null)
                {
                    emailLayoutSettings = (EmailLayoutSettings)EmailLayoutSettings.DefaultEmailSettings.Clone();
                    if (value != null)
                        value.CopyTo(emailLayoutSettings);
                }

                base.LayoutSettings = emailLayoutSettings;

                // if new value equals to the default settings
                if (value.Equals(CreateDefaultLayoutSettings()))
                    // specify that default settings are used
                    defaultSettingsCheckBox.Checked = true;
                // if new value is not equal to the default settings
                else
                    // specify that custom settings are used
                    defaultSettingsCheckBox.Checked = false;

              
                // update controls
                if (PageLayoutSettings.PageSize != null)
                    pageSizeComboBox.SelectedItem = PageLayoutSettings.PageSize.PaperSizeKind;
                else
                    pageSizeComboBox.SelectedItem = "Undefined";

                createHeaderCheckBox.Checked = emailLayoutSettings.EmailConverterSettings.CreateHeader;
                createAttachmentsCheckBox.Checked = emailLayoutSettings.EmailConverterSettings.CreateAttachmentsInHeader;
                createUnknownHeadersCheckBox.Checked = emailLayoutSettings.EmailConverterSettings.CreateUnknownHeadersInHeader;
#endif
            }
        }

        /// <summary>
        /// Gets or sets the current page layout settings.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public PageLayoutSettings PageLayoutSettings
        {
            get
            {
                return LayoutSettings.PageLayoutSettings;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Handles the CheckedChanged event of defaultSettingsCheckBox object.
        /// </summary>
        private void defaultSettingsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            settingsGroupBox.Enabled = !defaultSettingsCheckBox.Checked;
        }

        /// <summary>
        /// Handles the Click event of okButton object.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
#if !REMOVE_EMAIL_CODEC
            EmailLayoutSettings layoutSettings;

            if (defaultSettingsCheckBox.Checked)
            {
                // create default settings
                layoutSettings = (EmailLayoutSettings)CreateDefaultLayoutSettings();
            }
            // if custom settings must be used
            else
            {
                layoutSettings = (EmailLayoutSettings)LayoutSettings;
                layoutSettings.EmailConverterSettings.CreateHeader = createHeaderCheckBox.Checked;
                layoutSettings.EmailConverterSettings.CreateAttachmentsInHeader = createAttachmentsCheckBox.Checked;
                layoutSettings.EmailConverterSettings.CreateUnknownHeadersInHeader = createUnknownHeadersCheckBox.Checked;
            }

            try
            {
                LayoutSettingsManager[CodecName] = layoutSettings;
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
                DialogResult = DialogResult.Cancel;
            }
#endif
        }

        /// <summary>
        /// Handles the Click event of cancelBtn object.
        /// </summary>
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


        /// <summary>
        /// Handles the SelectedIndexChanged event of pageSizeComboBox object.
        /// </summary>
        private void pageSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pageSizeComboBox.SelectedItem.ToString() != "Undefined")
            {
                ImageSize size;

                // if custom page size selected
                if (pageSizeComboBox.SelectedItem.ToString() == "Custom")
                {
                    pageWidthNumericUpDown.Enabled = true;
                    pageHeightNumericUpDown.Enabled = true;

                    // if page size already set
                    if (PageLayoutSettings.PageSize != null)
                    {
                        // create custom page size with current values
                        size = ImageSize.FromInches(
                            PageLayoutSettings.PageSize.WidthInInch,
                            PageLayoutSettings.PageSize.HeightInInch,
                            PageLayoutSettings.PageSize.Resolution);
                    }
                    else
                    {
                        // create custom page size with default values
                        size = ImageSize.FromMillimeters(100, 100, ImagingEnvironment.ScreenResolution);
                    }
                }
                else
                {
                    // get page size from paper kind
                    size = ImageSize.FromPaperKind((PaperSizeKind)pageSizeComboBox.SelectedItem);
                    pageWidthNumericUpDown.Enabled = false;
                    pageHeightNumericUpDown.Enabled = false;
                }

                PageLayoutSettings.PageSize = size;

                // update page width and height containers
                pageWidthNumericUpDown.Value = (int)Math.Round(UnitOfMeasureConverter.ConvertToMillimeters(size.WidthInInch, UnitOfMeasure.Inches));
                pageHeightNumericUpDown.Value = (int)Math.Round(UnitOfMeasureConverter.ConvertToMillimeters(size.HeightInInch, UnitOfMeasure.Inches));
            }
            else
            {
                PageLayoutSettings.PageSize = null;
                pageWidthNumericUpDown.Enabled = false;
                pageHeightNumericUpDown.Enabled = false;
            }
        }

        /// <summary>
        /// Handles the ValueChanged event of pageSizeNumericUpDown object.
        /// </summary>
        private void pageSizeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (pageSizeComboBox.SelectedItem != null)
            {
                if (pageSizeComboBox.SelectedItem.ToString() == "Custom")
                {
                    // create custom page size
                    PageLayoutSettings.PageSize = ImageSize.FromMillimeters(
                        (int)pageWidthNumericUpDown.Value,
                        (int)pageHeightNumericUpDown.Value,
                        ImagingEnvironment.ScreenResolution);
                }
            }
        }

        #endregion

    }
}
