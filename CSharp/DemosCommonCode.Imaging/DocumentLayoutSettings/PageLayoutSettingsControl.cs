using System;
using System.ComponentModel;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Codecs.Decoders;
using Vintasoft.Imaging.Utils;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A control that allows to edit page layout settings.
    /// </summary>
    public partial class PageLayoutSettingsControl : UserControl
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PageLayoutSettingsControl"/> class.
        /// </summary>
        public PageLayoutSettingsControl()
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

        #endregion



        #region Properties

        PageLayoutSettings _pageLayoutSettings;
        /// <summary>
        /// Gets or sets the current page layout settings.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public PageLayoutSettings PageLayoutSettings
        {
            get
            {
                return _pageLayoutSettings;
            }
            set
            {
                _pageLayoutSettings = value;

                // update UI
                if (value == null || value.Equals(new PageLayoutSettings()))
                    defaultSettingsCheckBox.Checked = true;
                else
                    defaultSettingsCheckBox.Checked = false;
            }
        }

        #endregion



        #region Methods

        #region UI

        /// <summary>
        /// Handles the CheckedChanged event of defaultSettingsCheckBox object.
        /// </summary>
        private void defaultSettingsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            pageSettingsGroupBox.Enabled = !defaultSettingsCheckBox.Checked;

            if (defaultSettingsCheckBox.Checked)
            {
                // reset settings to the default settings
                _pageLayoutSettings = null;

                // update controls
                pageSizeComboBox.SelectedItem = "Undefined";
                pagePaddingFEditorControl.PaddingValue = PaddingF.Empty;
                contentScaleNumericUpDown.Value = 10;
            }
            else
            {
                // if current settings are not specified
                if (PageLayoutSettings == null)
                    // create new settings
                    _pageLayoutSettings = new PageLayoutSettings();

                // update controls

                if (_pageLayoutSettings.PageSize != null)
                    pageSizeComboBox.SelectedItem = _pageLayoutSettings.PageSize.PaperSizeKind;
                else
                    pageSizeComboBox.SelectedItem = "Undefined";

                pagePaddingFEditorControl.PaddingValue =
                    ConvertPaddingToMillimeters(_pageLayoutSettings.PagePadding, UnitOfMeasure.DeviceIndependentPixels);

                if (_pageLayoutSettings.ContentScale != null)
                    contentScaleNumericUpDown.Value = (int)(_pageLayoutSettings.ContentScale * 10);
                else
                    contentScaleNumericUpDown.Value = 10;
            }
        }

        /// <summary>
        /// Handles the PaddingValueChanged event of pagePaddingFEditorControl object.
        /// </summary>
        private void pagePaddingFEditorControl_PaddingValueChanged(object sender, EventArgs e)
        {
            if (PageLayoutSettings != null)
                PageLayoutSettings.PagePadding = ConvertPaddingToDips(pagePaddingFEditorControl.PaddingValue, UnitOfMeasure.Millimeters);
        }

        /// <summary>
        /// Handles the ValueChanged event of contentScaleNumericUpDown object.
        /// </summary>
        private void contentScaleNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (PageLayoutSettings != null)
                PageLayoutSettings.ContentScale = (int)contentScaleNumericUpDown.Value / 10f;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of pageSizeComboBox object.
        /// </summary>
        private void pageSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PageLayoutSettings == null)
                return;

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


        /// <summary>
        /// Returns padding value converted from specified
        /// <see cref="UnitOfMeasure"> to the device independent pixels.
        /// </summary>
        /// <param name="padding">Padding value.</param>
        /// <param name="units">Measure units of input padding value.</param>
        /// <returns> Padding value converted from specified
        /// <see cref="UnitOfMeasure"> to the device independent pixels.</returns>
        private PaddingF ConvertPaddingToDips(PaddingF padding, UnitOfMeasure units)
        {
            return new PaddingF(
                (float)UnitOfMeasureConverter.ConvertToDeviceIndependentPixels(padding.Left, units),
                (float)UnitOfMeasureConverter.ConvertToDeviceIndependentPixels(padding.Top, units),
                (float)UnitOfMeasureConverter.ConvertToDeviceIndependentPixels(padding.Right, units),
                (float)UnitOfMeasureConverter.ConvertToDeviceIndependentPixels(padding.Bottom, units));
        }

        /// <summary>
        /// Returns padding value converted from specified
        /// <see cref="UnitOfMeasure"> to millimeters.
        /// </summary>
        /// <param name="padding">Padding value.</param>
        /// <param name="units">Measure units of input padding value.</param>
        /// <returns> Padding value converted from specified <see cref="UnitOfMeasure"> to millimeters.</returns>
        private PaddingF ConvertPaddingToMillimeters(PaddingF padding, UnitOfMeasure units)
        {
            return new PaddingF(
                (float)UnitOfMeasureConverter.ConvertToMillimeters(padding.Left, units),
                (float)UnitOfMeasureConverter.ConvertToMillimeters(padding.Top, units),
                (float)UnitOfMeasureConverter.ConvertToMillimeters(padding.Right, units),
                (float)UnitOfMeasureConverter.ConvertToMillimeters(padding.Bottom, units));
        }

        #endregion

    }
}
