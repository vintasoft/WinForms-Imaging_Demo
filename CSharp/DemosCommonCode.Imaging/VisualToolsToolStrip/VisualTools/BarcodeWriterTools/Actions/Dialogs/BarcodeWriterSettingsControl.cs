using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using Vintasoft.Barcode;
using Vintasoft.Barcode.BarcodeInfo;
using Vintasoft.Barcode.SymbologySubsets;
using Vintasoft.Barcode.SymbologySubsets.GS1;
using Vintasoft.Barcode.SymbologySubsets.RoyalMailMailmark;
using Vintasoft.Barcode.GS1;
using DemosCommonCode.Imaging;


namespace DemosCommonCode.Barcode
{
    public partial class BarcodeWriterSettingsControl : UserControl
    {

        #region Fields

        GS1ApplicationIdentifierValue[] _GS1ApplicationIdentifierValues;

        MailmarkCmdmValueItem _mailmarkCmdmValueItem = new MailmarkCmdmValueItem();

        PpnBarcodeValue _ppnBarcodeValue = new PpnBarcodeValue();

        #endregion



        #region Constructor

        public BarcodeWriterSettingsControl()
        {
            InitializeComponent();

            // default GS1 value
            _GS1ApplicationIdentifierValues = new GS1ApplicationIdentifierValue[] { 
                new GS1ApplicationIdentifierValue(
                    GS1ApplicationIdentifiers.FindApplicationIdentifier("01"),
                    "0123456789012C")
            };

            // barcode image pixel formats
            AddEnumValues(pixelFormatComboBox, typeof(BarcodeImagePixelFormat));

            // linear
            linearBarcodeTypeComboBox.Items.Add(BarcodeType.Code128);
            linearBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.SSCC18);
            linearBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.SwissPostParcel);
            linearBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.FedExGround96);
            linearBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.VicsBol);
            linearBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.VicsScacPro);
            linearBarcodeTypeComboBox.Items.Add(BarcodeType.Code16K);
            linearBarcodeTypeComboBox.Items.Add(BarcodeType.Code93);
            linearBarcodeTypeComboBox.Items.Add(BarcodeType.Code39);
            linearBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.Code39Extended);
            linearBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.Code32);
            linearBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.VIN);
            linearBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.PZN);
            linearBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.NumlyNumber);
            linearBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.DhlAwb);
            linearBarcodeTypeComboBox.Items.Add(BarcodeType.Code11);
            linearBarcodeTypeComboBox.Items.Add(BarcodeType.Codabar);
            linearBarcodeTypeComboBox.Items.Add(BarcodeType.EAN13);
            linearBarcodeTypeComboBox.Items.Add(BarcodeType.EAN13Plus2);
            linearBarcodeTypeComboBox.Items.Add(BarcodeType.EAN13Plus5);
            linearBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.JAN13);
            linearBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.JAN13Plus2);
            linearBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.JAN13Plus5);
            linearBarcodeTypeComboBox.Items.Add(BarcodeType.EAN8);
            linearBarcodeTypeComboBox.Items.Add(BarcodeType.EAN8Plus2);
            linearBarcodeTypeComboBox.Items.Add(BarcodeType.EAN8Plus5);
            linearBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.JAN8);
            linearBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.JAN8Plus2);
            linearBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.JAN8Plus5);
            linearBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.EANVelocity);
            linearBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.ISBN);
            linearBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.ISBNPlus2);
            linearBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.ISBNPlus5);
            linearBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.ISMN);
            linearBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.ISMNPlus2);
            linearBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.ISMNPlus5);
            linearBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.ISSN);
            linearBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.ISSNPlus2);
            linearBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.ISSNPlus5);
            linearBarcodeTypeComboBox.Items.Add(BarcodeType.Interleaved2of5);
            linearBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.OPC);
            linearBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.DeutschePostIdentcode);
            linearBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.DeutschePostLeitcode);
            linearBarcodeTypeComboBox.Items.Add(BarcodeType.MSI);
            linearBarcodeTypeComboBox.Items.Add(BarcodeType.PatchCode);
            linearBarcodeTypeComboBox.Items.Add(BarcodeType.Pharmacode);
            linearBarcodeTypeComboBox.Items.Add(BarcodeType.RSS14);
            linearBarcodeTypeComboBox.Items.Add(BarcodeType.RSS14Stacked);
            linearBarcodeTypeComboBox.Items.Add(BarcodeType.RSSLimited);
            linearBarcodeTypeComboBox.Items.Add(BarcodeType.RSSExpanded);
            linearBarcodeTypeComboBox.Items.Add(BarcodeType.RSSExpandedStacked);
            linearBarcodeTypeComboBox.Items.Add(BarcodeType.Standard2of5);
            linearBarcodeTypeComboBox.Items.Add(BarcodeType.IATA2of5);
            linearBarcodeTypeComboBox.Items.Add(BarcodeType.Matrix2of5);
            linearBarcodeTypeComboBox.Items.Add(BarcodeType.Telepen);
            linearBarcodeTypeComboBox.Items.Add(BarcodeType.UPCA);
            linearBarcodeTypeComboBox.Items.Add(BarcodeType.UPCAPlus2);
            linearBarcodeTypeComboBox.Items.Add(BarcodeType.UPCAPlus5);
            linearBarcodeTypeComboBox.Items.Add(BarcodeType.UPCE);
            linearBarcodeTypeComboBox.Items.Add(BarcodeType.UPCEPlus2);
            linearBarcodeTypeComboBox.Items.Add(BarcodeType.UPCEPlus5);
            linearBarcodeTypeComboBox.Items.Add(BarcodeType.AustralianPost);
            linearBarcodeTypeComboBox.Items.Add(BarcodeType.IntelligentMail);
            linearBarcodeTypeComboBox.Items.Add(BarcodeType.Planet);
            linearBarcodeTypeComboBox.Items.Add(BarcodeType.Postnet);
            linearBarcodeTypeComboBox.Items.Add(BarcodeType.DutchKIX);
            linearBarcodeTypeComboBox.Items.Add(BarcodeType.RoyalMail);
            linearBarcodeTypeComboBox.Items.Add(BarcodeType.Mailmark4StateC);
            linearBarcodeTypeComboBox.Items.Add(BarcodeType.Mailmark4StateL);
            linearBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.GS1DataBar);
            linearBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.GS1_128);
            linearBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.GS1DataBarStacked);
            linearBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.GS1DataBarLimited);
            linearBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.GS1DataBarExpanded);
            linearBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.GS1DataBarExpandedStacked);
            linearBarcodeTypeComboBox.Items.Add(BarcodeSymbologySubsets.ITF14);

            // sort supported barcode list
            object[] barcodes = new object[linearBarcodeTypeComboBox.Items.Count];
            linearBarcodeTypeComboBox.Items.CopyTo(barcodes, 0);
            string[] names = new string[barcodes.Length];
            for (int i = 0; i < barcodes.Length; i++)
                names[i] = barcodes[i].ToString();
            Array.Sort(names, barcodes);
            linearBarcodeTypeComboBox.Items.Clear();
            linearBarcodeTypeComboBox.Items.AddRange(barcodes);

            linearBarcodeTypeComboBox.SelectedItem = BarcodeType.Code128;

            // 2D
            twoDimensionalBarcodeComboBox.Items.Add(BarcodeType.Aztec);
            twoDimensionalBarcodeComboBox.Items.Add(BarcodeType.DataMatrix);
            twoDimensionalBarcodeComboBox.Items.Add(BarcodeType.PDF417);
            twoDimensionalBarcodeComboBox.Items.Add(BarcodeType.MicroPDF417);
            twoDimensionalBarcodeComboBox.Items.Add(BarcodeType.HanXinCode);
            twoDimensionalBarcodeComboBox.Items.Add(BarcodeType.QR);
            twoDimensionalBarcodeComboBox.Items.Add(BarcodeType.MicroQR);
            twoDimensionalBarcodeComboBox.Items.Add(BarcodeType.MaxiCode);
            twoDimensionalBarcodeComboBox.Items.Add(BarcodeSymbologySubsets.GS1Aztec);
            twoDimensionalBarcodeComboBox.Items.Add(BarcodeSymbologySubsets.GS1DataMatrix);
            twoDimensionalBarcodeComboBox.Items.Add(BarcodeSymbologySubsets.GS1QR);
            twoDimensionalBarcodeComboBox.Items.Add(BarcodeSymbologySubsets.MailmarkCmdmType7);
            twoDimensionalBarcodeComboBox.Items.Add(BarcodeSymbologySubsets.MailmarkCmdmType9);
            twoDimensionalBarcodeComboBox.Items.Add(BarcodeSymbologySubsets.MailmarkCmdmType29);
            twoDimensionalBarcodeComboBox.Items.Add(BarcodeSymbologySubsets.PPN);
            twoDimensionalBarcodeComboBox.Items.Add(BarcodeSymbologySubsets.XFACompressedAztec);
            twoDimensionalBarcodeComboBox.Items.Add(BarcodeSymbologySubsets.XFACompressedDataMatrix);
            twoDimensionalBarcodeComboBox.Items.Add(BarcodeSymbologySubsets.XFACompressedPDF417);
            twoDimensionalBarcodeComboBox.Items.Add(BarcodeSymbologySubsets.XFACompressedQRCode);
            twoDimensionalBarcodeComboBox.SelectedItem = BarcodeType.DataMatrix;

            // fonts
            foreach (FontFamily fontFamily in FontFamily.Families)
                fontSelector.Items.Add(fontFamily.Name);

            // MSI checksum
            msiChecksumComboBox.Items.Add(MSIChecksumType.Mod10);
            msiChecksumComboBox.Items.Add(MSIChecksumType.Mod10Mod10);
            msiChecksumComboBox.Items.Add(MSIChecksumType.Mod11);
            msiChecksumComboBox.Items.Add(MSIChecksumType.Mod11Mod10);

            // Code 128 encoding mode
            code128ModeComboBox.Items.Add(Code128EncodingMode.Undefined);
            code128ModeComboBox.Items.Add(Code128EncodingMode.ModeA);
            code128ModeComboBox.Items.Add(Code128EncodingMode.ModeB);
            code128ModeComboBox.Items.Add(Code128EncodingMode.ModeC);


            // RSS
            for (int i = 2; i <= 20; i += 2)
                rssExpandedStackedSegmentPerRow.Items.Add(i);

            // Postal
            AddEnumValues(australianPostCustomInfoComboBox, typeof(AustralianPostCustomerInfoFormat));


            // Aztec
            AddEnumValues(aztecSymbolComboBox, typeof(AztecSymbolType));
            for (int i = 0; i <= 32; i++)
                aztecLayersCountComboBox.Items.Add(i);
            aztecEncodingModeComboBox.Items.Add(AztecEncodingMode.Undefined);
            aztecEncodingModeComboBox.Items.Add(AztecEncodingMode.Text);
            aztecEncodingModeComboBox.Items.Add(AztecEncodingMode.Byte);

            // DataMatrix
            AddEnumValues(datamatrixEncodingModeComboBox, typeof(DataMatrixEncodingMode));
            AddEnumValues(datamatrixSymbolSizeComboBox, typeof(DataMatrixSymbolType));

            // QR Code
            AddEnumValues(qrEncodingModeComboBox, typeof(QREncodingMode));
            qrSymbolSizeComboBox.Items.Add(QRSymbolVersion.Undefined);
            for (int i = 1; i <= 40; i++)
                qrSymbolSizeComboBox.Items.Add((QRSymbolVersion)i);
            AddEnumValues(qrECCLevelComboBox, typeof(QRErrorCorrectionLevel));


            // Micro QR Code
            AddEnumValues(microQrEncodingModeComboBox, typeof(QREncodingMode));
            microQrSymbolSizeComboBox.Items.Add(QRSymbolVersion.Undefined);
            microQrSymbolSizeComboBox.Items.Add(QRSymbolVersion.VersionM1);
            microQrSymbolSizeComboBox.Items.Add(QRSymbolVersion.VersionM2);
            microQrSymbolSizeComboBox.Items.Add(QRSymbolVersion.VersionM3);
            microQrSymbolSizeComboBox.Items.Add(QRSymbolVersion.VersionM4);
            microQrECCLevelComboBox.Items.Add(QRErrorCorrectionLevel.L);
            microQrECCLevelComboBox.Items.Add(QRErrorCorrectionLevel.M);
            microQrECCLevelComboBox.Items.Add(QRErrorCorrectionLevel.Q);

            // MaxiCode
            maxiCodeEncodingModeComboBox.Items.Add(MaxiCodeEncodingMode.Mode2);
            maxiCodeEncodingModeComboBox.Items.Add(MaxiCodeEncodingMode.Mode3);
            maxiCodeEncodingModeComboBox.Items.Add(MaxiCodeEncodingMode.Mode4);
            maxiCodeEncodingModeComboBox.Items.Add(MaxiCodeEncodingMode.Mode5);
            maxiCodeEncodingModeComboBox.Items.Add(MaxiCodeEncodingMode.Mode6);

            // PDF417
            AddEnumValues(pdf417EncodingModeComboBox, typeof(PDF417EncodingMode));
            AddEnumValues(pdf417ErrorCorrectionComboBox, typeof(PDF417ErrorCorrectionLevel));

            // MicroPDF417
            AddEnumValues(microPDF417EncodingModeComboBox, typeof(PDF417EncodingMode));
            AddEnumValues(microPDF417SymbolSizeComboBox, typeof(MicroPDF417SymbolType));

            // ECI
            EciCharacterEncoding[] eciCharacterEncodings = EciCharacterEncoding.GetEciCharacterEncodings();
            foreach (EciCharacterEncoding characterEncoding in eciCharacterEncodings)
            {
                encodingInfoComboBox.Items.Add(characterEncoding);
                if (characterEncoding.EciAssignmentNumber == 3)
                    encodingInfoComboBox.SelectedItem = characterEncoding;
            }

            // PPN
            _ppnBarcodeValue.PharmacyProductNumber = "110375286414";
            _ppnBarcodeValue.BatchNumber = "12345ABCD";
            _ppnBarcodeValue.ExpiryDate = "150617";
            _ppnBarcodeValue.SerialNumber = "12345ABCDEF98765";

            // Code 16K
            code16KRowsComboBox.Items.Add(0);
            for (int i = 2; i <= 16; i++)
                code16KRowsComboBox.Items.Add(i);
            code16KEncodingModeComboBox.Items.Add(Code128EncodingMode.Undefined);
            code16KEncodingModeComboBox.Items.Add(Code128EncodingMode.ModeA);
            code16KEncodingModeComboBox.Items.Add(Code128EncodingMode.ModeB);
            code16KEncodingModeComboBox.Items.Add(Code128EncodingMode.ModeC);
            code16KEncodingModeComboBox.Items.Add(Code128EncodingMode.Code16K_Mode3);
            code16KEncodingModeComboBox.Items.Add(Code128EncodingMode.Code16K_Mode4);
            code16KEncodingModeComboBox.Items.Add(Code128EncodingMode.Code16K_Mode5);
            code16KEncodingModeComboBox.Items.Add(Code128EncodingMode.Code16K_Mode6);

            // Han Xin Code
            AddEnumValues(hanXinCodeEncodingModeComboBox, typeof(HanXinCodeEncodingMode));
            hanXinCodeSymbolVersionComboBox.Items.Add(HanXinCodeSymbolVersion.Undefined);
            for (int i = 1; i <= 84; i++)
                hanXinCodeSymbolVersionComboBox.Items.Add((HanXinCodeSymbolVersion)i);
            AddEnumValues(hanXinCodeECCLevelComboBox, typeof(HanXinCodeErrorCorrectionLevel));
        }

        #endregion



        #region Properties

        BarcodeSymbologySubset _selectedBarcodeSubset = null;
        /// <summary>
        /// Gets or sets a selected barcode subset.
        /// </summary>
        public BarcodeSymbologySubset SelectedBarcodeSubset
        {
            get
            {
                return _selectedBarcodeSubset;
            }
            set
            {
                _selectedBarcodeSubset = value;
                UpdateUI();
            }
        }

        WriterSettings _barcodeWriterSettings = null;
        /// <summary>
        /// Gest or sets a writer settings.
        /// </summary>
        public WriterSettings BarcodeWriterSettings
        {
            get
            {
                return _barcodeWriterSettings;
            }
            set
            {
                _barcodeWriterSettings = value;

                if (value != null)
                {
                    mainPanel.Enabled = true;

                    linearBarcodeTypeComboBox.SelectedItem = value.Barcode;

                    barcodeValueTextBox.Text = value.Value;
                    foregroundColorPanel.BackColor = value.ForeColor;
                    backgroundColorPanel.BackColor = value.BackColor;
                    pixelFormatComboBox.SelectedItem = value.PixelFormat;
                    if (barcodeWidthPanel.Visible)
                        minWidthNumericUpDown.Value = value.MinWidth;
                    paddingNumericUpDown.Value = value.Padding;
                    widthAdjustNumericUpDown.Value = (decimal)(value.BarsWidthAdjustment * 10);
                    linearBarcodeHeight.Value = value.Height;
                    valueAutoLetterSpacingCheckBox.Checked = value.ValueAutoLetterSpacing;
                    if (barcodeGroupsTabControl.SelectedTab == linearBarcodesTabPage)
                        valueVisibleCheckBox.Checked = value.ValueVisible;
                    else
                        valueVisibleCheckBox.Checked = value.Value2DVisible;
                    valueGapNumericUpDown.Value = value.ValueGap;
                    fontSelector.SelectedItem = value.ValueFont.Name;
                    valueFontSizeNumericUpDown.Value = (decimal)value.ValueFont.SizeInPoints;
                    msiChecksumComboBox.SelectedItem = value.MSIChecksum;
                    code128ModeComboBox.SelectedItem = value.Code128EncodingMode;
                    postalADMiltiplierNumericUpDown.Value = (decimal)(value.PostBarcodesADMultiplier * 10.0);
                    australianPostCustomInfoComboBox.SelectedItem = value.AustralianPostCustomerInfoFormat;
                    aztecSymbolComboBox.SelectedItem = value.AztecSymbol;
                    aztecLayersCountComboBox.SelectedIndex = value.AztecDataLayers;
                    aztecEncodingModeComboBox.SelectedItem = value.AztecEncodingMode;
                    aztecErrorCorrectionNumericUpDown.Value = (decimal)value.AztecErrorCorrectionDataPercent;
                    datamatrixEncodingModeComboBox.SelectedItem = value.DataMatrixEncodingMode;
                    datamatrixSymbolSizeComboBox.SelectedItem = value.DataMatrixSymbol;
                    qrEncodingModeComboBox.SelectedItem = value.QREncodingMode;
                    qrSymbolSizeComboBox.SelectedItem = value.QRSymbol;
                    qrECCLevelComboBox.SelectedItem = value.QRErrorCorrectionLevel;
                    microQrEncodingModeComboBox.SelectedItem = value.QREncodingMode;
                    microQrSymbolSizeComboBox.SelectedItem = value.QRSymbol;
                    microQrECCLevelComboBox.SelectedItem = value.QRErrorCorrectionLevel;
                    maxiCodeResolutonNumericUpDown.Value = (decimal)value.MaxiCodeResolution;
                    maxiCodeEncodingModeComboBox.SelectedItem = value.MaxiCodeEncodingMode;
                    pdf417EncodingModeComboBox.SelectedItem = value.PDF417EncodingMode;
                    pdf417ErrorCorrectionComboBox.SelectedItem = value.PDF417ErrorCorrectionLevel;
                    pdf417RowsNumericUpDown.Value = value.PDF417Rows;
                    pdf417ColsNumericUpDown.Value = value.PDF417Columns;
                    pdf417RowHeightNumericUpDown.Value = value.PDF417RowHeight;
                    microPDF417ColumnsNumericUpDown.Value = value.MicroPDF417Columns;
                    microPDF417EncodingModeComboBox.SelectedItem = value.MicroPDF417EncodingMode;
                    microPDF417SymbolSizeComboBox.SelectedItem = value.MicroPDF417Symbol;
                    microPED417RowHeightNumericUpDown.Value = value.MicroPDF417RowHeight;
                    rss14StackedOmni.Checked = value.RSS14StackedOmnidirectional;
                    rssExpandedStackedSegmentPerRow.SelectedItem = value.RSSExpandedStackedSegmentPerRow;
                    rssLinkageFlag.Checked = value.RSSLinkageFlag;
                    useOptionalCheckSum.Checked = value.OptionalCheckSum;
                    enableTelepenNumericMode.Checked = value.EnableTelepenNumericMode;
                    code16KRowsComboBox.SelectedItem = value.Code16KRows;
                    code16KEncodingModeComboBox.SelectedItem = value.Code16KEncodingMode;
                    hanXinCodeEncodingModeComboBox.SelectedItem = value.HanXinCodeEncodingMode;
                    hanXinCodeSymbolVersionComboBox.SelectedItem = value.HanXinCodeSymbol;
                    hanXinCodeECCLevelComboBox.SelectedItem = value.HanXinCodeErrorCorrectionLevel;
                }
                else
                {
                    mainPanel.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Gets a barcode image.
        /// </summary>
        public Image BarcodeImage
        {
            set
            {
                if (value == null)
                {
                    barcodeImageLabel.Visible = false;
                    barcodeImageSizeLabel.Visible = false;
                }
                else
                {
                    barcodeImageLabel.Visible = true;
                    barcodeImageSizeLabel.Visible = true;
                    barcodeImageSizeLabel.Text = string.Format(
                        "{0}x{1} px; {2}x{3} DPI", value.Width, value.Height,
                        value.HorizontalResolution, value.VerticalResolution);
                }
            }
        }

        bool _canChangeBarcodeSize = true;
        /// <summary>
        /// Gets or sets a value that indicating when can change barcode size.
        /// </summary>
        [DefaultValue(true)]
        public bool CanChangeBarcodeSize
        {
            get
            {
                return _canChangeBarcodeSize;
            }
            set
            {
                _canChangeBarcodeSize = value;
                barcodeWidthPanel.Visible = value;
                linearBarcodeHeight.Visible = value;
                linearBarcodeHeightLabel.Visible = value;
            }
        }

        /// <summary>
        /// Gets a value that indicating when need encode ECI character.
        /// </summary>
        public bool EncodeEciCharacter
        {
            get
            {
                return encodingInfoCheckBox.Checked && encodingInfoCheckBox.Enabled;
            }
        }

        #endregion



        #region Methods

        #region INTERNAL

        internal void UpdateBarcodeWriterSettings()
        {
            if (barcodeWidthPanel.Visible)
                minWidthNumericUpDown.Value = Math.Max(BarcodeWriterSettings.MinWidth, minWidthNumericUpDown.Minimum);
        }

        #endregion


        #region PRIVATE

        #region Common

        private void selectForegroundColorLabel_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = foregroundColorPanel.BackColor;

            if (colorDialog1.ShowDialog() == DialogResult.OK)
                foregroundColorPanel.BackColor = colorDialog1.Color;

            if (BarcodeWriterSettings.ForeColor != foregroundColorPanel.BackColor)
                BarcodeWriterSettings.ForeColor = foregroundColorPanel.BackColor;
        }

        private void selectBackgroundColorButton_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = backgroundColorPanel.BackColor;

            if (colorDialog1.ShowDialog() == DialogResult.OK)
                backgroundColorPanel.BackColor = colorDialog1.Color;

            if (BarcodeWriterSettings.BackColor != backgroundColorPanel.BackColor)
                BarcodeWriterSettings.BackColor = backgroundColorPanel.BackColor;
        }

        private void pixelFormatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BarcodeWriterSettings.PixelFormat = (BarcodeImagePixelFormat)pixelFormatComboBox.SelectedItem;
        }

        private void minWidthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (barcodeWidthPanel.Visible)
                BarcodeWriterSettings.MinWidth = (int)minWidthNumericUpDown.Value;
        }

        private void paddingNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            BarcodeWriterSettings.Padding = (int)paddingNumericUpDown.Value;
        }

        private void widthAdjustNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            BarcodeWriterSettings.BarsWidthAdjustment = (double)widthAdjustNumericUpDown.Value * 0.1;
        }

        private void barcodeValueTextBox_TextChanged(object sender, EventArgs e)
        {
            EncodeValue();
        }

        /// <summary>
        /// Encodes the barcode value.
        /// </summary>
        public bool EncodeValue()
        {
            if (BarcodeWriterSettings == null)
                return false;
            string oldValue = BarcodeWriterSettings.Value;
            try
            {
                if (SelectedBarcodeSubset is GS1BarcodeSymbologySubset)
                {
                    //  encode GS1 barcode value
                    SelectedBarcodeSubset.Encode(new GS1ValueItem(_GS1ApplicationIdentifierValues), BarcodeWriterSettings);
                }
                else if (SelectedBarcodeSubset is MailmarkCmdmBarcodeSymbology)
                {
                    //  encode Mailmark barcode value
                    SelectedBarcodeSubset.Encode(_mailmarkCmdmValueItem, BarcodeWriterSettings);
                }
                else if (SelectedBarcodeSubset is PpnBarcodeSymbology)
                {
                    //  encode PPN barcode value
                    SelectedBarcodeSubset.Encode(_ppnBarcodeValue, BarcodeWriterSettings);
                }
                else if (SelectedBarcodeSubset != null)
                {
                    SelectedBarcodeSubset.Encode(barcodeValueTextBox.Text, BarcodeWriterSettings);
                }
                else
                {
                    if (encodingInfoCheckBox.Checked && encodingInfoCheckBox.Enabled)
                    {
                        EciCharacterEncoder encoder = new EciCharacterEncoder(BarcodeWriterSettings.Barcode);
                        encoder.AppendText((EciCharacterEncoding)encodingInfoComboBox.SelectedItem, barcodeValueTextBox.Text);
                        BarcodeWriterSettings.ValueItems = encoder.ToValueItems();
                        BarcodeWriterSettings.PrintableValue = barcodeValueTextBox.Text;
                    }
                    else
                    {
                        BarcodeWriterSettings.PrintableValue = "";
                        BarcodeWriterSettings.Value = barcodeValueTextBox.Text;
                    }
                }
            }
            catch (WriterSettingsException exc)
            {
                OnWriterException(exc);
                return false;
            }
            return true;
        }


        private void linearBarcodeTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BarcodeWriterSettings == null)
                return;
            BarcodeType oldBarcodeType = BarcodeWriterSettings.Barcode;
            try
            {
                BarcodeWriterSettings.BeginInit();
                if (linearBarcodeTypeComboBox.SelectedItem is BarcodeSymbologySubset)
                {
                    SelectedBarcodeSubset = (BarcodeSymbologySubset)linearBarcodeTypeComboBox.SelectedItem;
                }
                else
                {
                    SelectedBarcodeSubset = null;
                    BarcodeWriterSettings.Barcode = (BarcodeType)linearBarcodeTypeComboBox.SelectedItem;
                }
                EncodeValue();
                BarcodeWriterSettings.EndInit();
            }
            catch (WriterSettingsException exc)
            {
                BarcodeWriterSettings.EndInit();
                OnWriterException(exc);
                BarcodeWriterSettings.Barcode = oldBarcodeType;
                linearBarcodeTypeComboBox.SelectedItem = oldBarcodeType;
            }

            australianPostCustomInfoPanel.Visible = false;
            msiChecksumPanel.Visible = false;
            code128ModePanel.Visible = false;
            postalADMiltiplierPanel.Visible = false;
            barsRatioPanel.Visible = false;
            useOptionalCheckSumPanel.Visible = false;
            enableTelepenNumericModePanel.Visible = false;
            rssLinkageFlagPanel.Visible = false;
            rss14StackedOmniPanel.Visible = false;
            rssExpandedStackedSegmentPerRowPanel.Visible = false;
            code16KEncodeingModePanel.Visible = false;
            code16KRowsPanel.Visible = false;
            if (SelectedBarcodeSubset == null)
            {
                switch (BarcodeWriterSettings.Barcode)
                {
                    case BarcodeType.MSI:
                        barsRatioPanel.Visible = true;
                        msiChecksumPanel.Visible = true;
                        break;

                    case BarcodeType.Code128:
                        code128ModePanel.Visible = true;
                        break;
                    case BarcodeType.Code16K:
                        code16KEncodeingModePanel.Visible = true;
                        code16KRowsPanel.Visible = true;
                        break;
                    case BarcodeType.AustralianPost:
                        postalADMiltiplierPanel.Visible = true;
                        australianPostCustomInfoPanel.Visible = true;
                        break;
                    case BarcodeType.RoyalMail:
                    case BarcodeType.DutchKIX:
                    case BarcodeType.IntelligentMail:
                    case BarcodeType.Postnet:
                    case BarcodeType.Planet:
                        postalADMiltiplierPanel.Visible = true;
                        break;

                    case BarcodeType.Code11:
                    case BarcodeType.Codabar:
                        barsRatioPanel.Visible = true;
                        break;

                    case BarcodeType.Interleaved2of5:
                        useOptionalCheckSumPanel.Visible = true;
                        barsRatioPanel.Visible = true;
                        break;

                    case BarcodeType.Standard2of5:
                        useOptionalCheckSumPanel.Visible = true;
                        barsRatioPanel.Visible = true;
                        break;

                    case BarcodeType.Matrix2of5:
                        useOptionalCheckSumPanel.Visible = true;
                        barsRatioPanel.Visible = true;
                        break;

                    case BarcodeType.IATA2of5:
                        barsRatioPanel.Visible = true;
                        break;

                    case BarcodeType.Code39:
                        barsRatioPanel.Visible = true;
                        useOptionalCheckSumPanel.Visible = true;
                        break;

                    case BarcodeType.Telepen:
                        enableTelepenNumericModePanel.Visible = true;
                        barsRatioPanel.Visible = true;
                        break;

                    case BarcodeType.RSS14:
                    case BarcodeType.RSS14Stacked:
                    case BarcodeType.RSSExpanded:
                    case BarcodeType.RSSExpandedStacked:
                    case BarcodeType.RSSLimited:
                        rssLinkageFlagPanel.Visible = true;
                        if (BarcodeWriterSettings.Barcode == BarcodeType.RSS14Stacked)
                            rss14StackedOmniPanel.Visible = true;
                        else if (BarcodeWriterSettings.Barcode == BarcodeType.RSSExpandedStacked)
                            rssExpandedStackedSegmentPerRowPanel.Visible = true;
                        break;

                }
            }
            else
            {
                switch (SelectedBarcodeSubset.BaseType)
                {

                    case BarcodeType.MSI:
                    case BarcodeType.Code11:
                    case BarcodeType.Codabar:
                    case BarcodeType.Interleaved2of5:
                    case BarcodeType.Standard2of5:
                    case BarcodeType.Matrix2of5:
                    case BarcodeType.IATA2of5:
                    case BarcodeType.Code39:
                    case BarcodeType.Telepen:
                        barsRatioPanel.Visible = true;
                        break;

                    case BarcodeType.RSS14:
                    case BarcodeType.RSS14Stacked:
                    case BarcodeType.RSSExpanded:
                    case BarcodeType.RSSExpandedStacked:
                    case BarcodeType.RSSLimited:
                        rssLinkageFlagPanel.Visible = true;
                        if (BarcodeWriterSettings.Barcode == BarcodeType.RSS14Stacked)
                            rss14StackedOmniPanel.Visible = true;
                        else if (BarcodeWriterSettings.Barcode == BarcodeType.RSSExpandedStacked)
                            rssExpandedStackedSegmentPerRowPanel.Visible = true;
                        break;

                }
                if (SelectedBarcodeSubset is Code39ExtendedBarcodeSymbology)
                    useOptionalCheckSumPanel.Visible = true;
            }
        }

        private void linearBarcodeHeight_ValueChanged(object sender, EventArgs e)
        {
            BarcodeWriterSettings.Height = (int)(linearBarcodeHeight.Value);
        }

        private void valueAutoLetterSpacingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            BarcodeWriterSettings.ValueAutoLetterSpacing = valueAutoLetterSpacingCheckBox.Checked;
        }

        private void valueVisibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool enabled = valueVisibleCheckBox.Checked;
            valueAutoLetterSpacingCheckBox.Enabled = enabled;
            valueGapNumericUpDown.Enabled = enabled;
            valueFontSizeNumericUpDown.Enabled = enabled;
            fontSelector.Enabled = enabled;
            if (barcodeGroupsTabControl.SelectedTab == linearBarcodesTabPage)
                BarcodeWriterSettings.ValueVisible = valueVisibleCheckBox.Checked;
            else
                BarcodeWriterSettings.Value2DVisible = valueVisibleCheckBox.Checked;
        }

        private void valueGapNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            BarcodeWriterSettings.ValueGap = (int)valueGapNumericUpDown.Value;
        }

        private void fontSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fontSelector.SelectedItem != null)
                BarcodeWriterSettings.ValueFont = new Font(fontSelector.SelectedItem.ToString(),
                    (float)valueFontSizeNumericUpDown.Value);
        }


        private void barcodeGroupsTabPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            barcodeWidthPanel.Visible = CanChangeBarcodeSize;
            SelectedBarcodeSubset = null;
            BarcodeType oldValue = BarcodeWriterSettings.Barcode;
            try
            {

                BarcodeWriterSettings.BeginInit();
                if (barcodeGroupsTabControl.SelectedTab == linearBarcodesTabPage)
                {
                    if (linearBarcodeTypeComboBox.SelectedItem is BarcodeSymbologySubset)
                    {
                        SelectedBarcodeSubset = (BarcodeSymbologySubset)linearBarcodeTypeComboBox.SelectedItem;
                    }
                    else
                    {
                        BarcodeWriterSettings.Barcode = (BarcodeType)linearBarcodeTypeComboBox.SelectedItem;
                    }
                    valueVisibleCheckBox.Checked = BarcodeWriterSettings.ValueVisible;
                    barcodeValueTextBox.Enabled = true;
                }
                else
                {
                    BarcodeSymbologySubset barcodeSubset = twoDimensionalBarcodeComboBox.SelectedItem as BarcodeSymbologySubset;
                    BarcodeType baseBarcodeType;
                    if (barcodeSubset != null)
                        baseBarcodeType = barcodeSubset.BaseType;
                    else
                        baseBarcodeType = (BarcodeType)twoDimensionalBarcodeComboBox.SelectedItem;

                    if (baseBarcodeType == BarcodeType.PDF417)
                    {
                        if (pdf417CompactCheckBox.Checked)
                            BarcodeWriterSettings.Barcode = BarcodeType.PDF417Compact;
                        else
                            BarcodeWriterSettings.Barcode = BarcodeType.PDF417;
                    }
                    else if (baseBarcodeType == BarcodeType.MicroPDF417)
                    {
                        BarcodeWriterSettings.Barcode = BarcodeType.MicroPDF417;
                    }
                    else if (baseBarcodeType == BarcodeType.DataMatrix)
                    {
                        BarcodeWriterSettings.Barcode = BarcodeType.DataMatrix;
                        datamatrixSymbolSizeComboBox_SelectedIndexChanged(this, EventArgs.Empty);
                    }
                    else if (baseBarcodeType == BarcodeType.Aztec)
                    {
                        BarcodeWriterSettings.Barcode = BarcodeType.Aztec;
                    }
                    else if (baseBarcodeType == BarcodeType.QR)
                    {
                        BarcodeWriterSettings.Barcode = BarcodeType.QR;
                        BarcodeWriterSettings.QRSymbol = (QRSymbolVersion)qrSymbolSizeComboBox.SelectedItem;
                    }
                    else if (baseBarcodeType == BarcodeType.MicroQR)
                    {
                        BarcodeWriterSettings.Barcode = BarcodeType.MicroQR;
                        BarcodeWriterSettings.QRSymbol = (QRSymbolVersion)microQrSymbolSizeComboBox.SelectedItem;
                    }
                    else if (baseBarcodeType == BarcodeType.MaxiCode)
                    {
                        BarcodeWriterSettings.Barcode = BarcodeType.MaxiCode;
                        barcodeWidthPanel.Visible = false;
                    }
                    else if (baseBarcodeType == BarcodeType.HanXinCode)
                    {
                        BarcodeWriterSettings.Barcode = BarcodeType.HanXinCode;
                    }

                    valueVisibleCheckBox.Checked = BarcodeWriterSettings.Value2DVisible;
                }
                UpdateUI();
                EncodeValue();
                BarcodeWriterSettings.EndInit();
            }
            catch (WriterSettingsException exc)
            {
                OnWriterException(exc);
                BarcodeWriterSettings.Barcode = oldValue;
                BarcodeWriterSettings.EndInit();
            }
        }

        private void UpdateUI()
        {
            if (BarcodeWriterSettings == null)
                return;
            bool canEncodeECI = false;
            if (SelectedBarcodeSubset == null)
                switch (BarcodeWriterSettings.Barcode)
                {
                    case BarcodeType.Aztec:
                    case BarcodeType.DataMatrix:
                    case BarcodeType.QR:
                    case BarcodeType.PDF417:
                    case BarcodeType.PDF417Compact:
                    case BarcodeType.MicroPDF417:
                    case BarcodeType.HanXinCode:
                        canEncodeECI = true;
                        break;
                }
            encodingInfoCheckBox.Enabled = canEncodeECI;
            encodingInfoComboBox.Enabled = canEncodeECI && encodingInfoCheckBox.Checked;
            bool useCustomValueDialog = false;
            if (SelectedBarcodeSubset != null &&
                SelectedBarcodeSubset is GS1BarcodeSymbologySubset ||
                SelectedBarcodeSubset is MailmarkCmdmBarcodeSymbology ||
                SelectedBarcodeSubset is PpnBarcodeSymbology)
                useCustomValueDialog = true;
            subsetBarcodeValueButton.Visible = useCustomValueDialog;
            barcodeValueTextBox.Visible = !useCustomValueDialog;
        }

        private void writerGS1ValueButton_Click(object sender, EventArgs e)
        {
            if (SelectedBarcodeSubset is GS1BarcodeSymbologySubset)
            {
                using (GS1ValueEditorForm gs1Editor = new GS1ValueEditorForm(_GS1ApplicationIdentifierValues, false))
                {
                    if (gs1Editor.ShowDialog() == DialogResult.OK)
                    {
                        _GS1ApplicationIdentifierValues = gs1Editor.GS1ApplicationIdentifierValues;
                        EncodeValue();
                    }
                }
            }
            else if (SelectedBarcodeSubset is MailmarkCmdmBarcodeSymbology)
            {
                using (PropertyGridForm dialog = new PropertyGridForm(_mailmarkCmdmValueItem, "Mailmark CMDM value", false))
                {
                    dialog.PropertyGrid.PropertySort = PropertySort.NoSort;
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        EncodeValue();
                    }
                }
            }
            else if (SelectedBarcodeSubset is PpnBarcodeSymbology)
            {
                using (PropertyGridForm dialog = new PropertyGridForm(_ppnBarcodeValue, "PPN value", false))
                {
                    dialog.PropertyGrid.PropertySort = PropertySort.NoSort;
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        EncodeValue();
                    }
                }
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private void encodingInfoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            EncodeValue();
        }

        private void barsRatioNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            BarcodeWriterSettings.BarsRatio = (double)barsRatioNumericUpDown.Value / 10.0;
        }

        private void encodingInfoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            encodingInfoComboBox.Enabled = encodingInfoCheckBox.Checked;
            EncodeValue();
        }

        #endregion

        #region Common

        private void useOptionalCheckSum_CheckedChanged(object sender, EventArgs e)
        {
            BarcodeWriterSettings.OptionalCheckSum = useOptionalCheckSum.Checked;
        }

        private void twoDimensionalBarcodeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            aztecSettingsPanel.Visible = false;
            qrSettingsPanel.Visible = false;
            microPDF417SettingsPanel.Visible = false;
            pdf417SettingsPanel.Visible = false;
            microQrSettingsPanel.Visible = false;
            dataMatrixSettingsPanel.Visible = false;
            maxiCodeSettingsPanel.Visible = false;
            hanXinCodeSettingsPanel.Visible = false;


            BarcodeSymbologySubset barcodeSubset = twoDimensionalBarcodeComboBox.SelectedItem as BarcodeSymbologySubset;
            BarcodeType baseBarcodeType;
            if (barcodeSubset != null)
                baseBarcodeType = barcodeSubset.BaseType;
            else
                baseBarcodeType = (BarcodeType)twoDimensionalBarcodeComboBox.SelectedItem;

            SelectedBarcodeSubset = barcodeSubset;

            try
            {
                if (BarcodeWriterSettings != null)
                {
                    if (SelectedBarcodeSubset == null)
                    {
                        BarcodeWriterSettings.BeginInit();
                        BarcodeWriterSettings.Barcode = baseBarcodeType;
                    }
                }

                UpdateUI();

                // select settings panel
                switch (baseBarcodeType)
                {
                    case BarcodeType.Aztec:
                        aztecSettingsPanel.Visible = true;
                        break;
                    case BarcodeType.QR:
                        qrSettingsPanel.Visible = true;
                        break;
                    case BarcodeType.MicroQR:
                        microQrSettingsPanel.Visible = true;
                        break;
                    case BarcodeType.PDF417:
                        pdf417SettingsPanel.Visible = true;
                        break;
                    case BarcodeType.MicroPDF417:
                        microPDF417SettingsPanel.Visible = true;
                        break;
                    case BarcodeType.DataMatrix:
                        if (!(SelectedBarcodeSubset is MailmarkCmdmBarcodeSymbology))
                        {
                            dataMatrixSettingsPanel.Visible = true;
                            datamatrixSymbolSizeComboBox_SelectedIndexChanged(this, EventArgs.Empty);
                        }
                        break;
                    case BarcodeType.HanXinCode:
                        hanXinCodeSettingsPanel.Visible = true;
                        break;
                    case BarcodeType.MaxiCode:
                        maxiCodeSettingsPanel.Visible = true;
                        break;
                }
                EncodeValue();
            }
            finally
            {
                if (SelectedBarcodeSubset == null)
                {
                    if (BarcodeWriterSettings != null)
                        BarcodeWriterSettings.EndInit();
                }
            }
        }

        #endregion

        #region MSI

        private void msiChecksumComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BarcodeWriterSettings.MSIChecksum = (MSIChecksumType)msiChecksumComboBox.SelectedItem;
        }

        #endregion

        #region Code128

        private void code128ModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BarcodeWriterSettings.Code128EncodingMode = (Code128EncodingMode)code128ModeComboBox.SelectedItem;
        }

        #endregion

        #region Telepen

        private void enableTelepenNumericMode_CheckedChanged(object sender, EventArgs e)
        {
            BarcodeWriterSettings.EnableTelepenNumericMode = enableTelepenNumericMode.Checked;
        }

        #endregion

        #region RSS

        private void rssLinkageFlag_CheckedChanged(object sender, EventArgs e)
        {
            BarcodeWriterSettings.RSSLinkageFlag = rssLinkageFlag.Checked;
        }

        private void rss14StackedOmni_CheckedChanged(object sender, EventArgs e)
        {
            BarcodeWriterSettings.RSS14StackedOmnidirectional = rss14StackedOmni.Checked;
        }

        private void rssExpandedStackedSegmentPerRow_SelectedIndexChanged(object sender, EventArgs e)
        {
            BarcodeWriterSettings.RSSExpandedStackedSegmentPerRow = (int)rssExpandedStackedSegmentPerRow.SelectedItem;
        }


        #endregion

        #region Postal

        private void postalADMiltiplierNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            BarcodeWriterSettings.PostBarcodesADMultiplier = (double)postalADMiltiplierNumericUpDown.Value / 10.0;
        }

        private void australianPostCustomInfoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BarcodeWriterSettings.AustralianPostCustomerInfoFormat = (AustralianPostCustomerInfoFormat)australianPostCustomInfoComboBox.SelectedItem;
        }

        #endregion

        #region Aztec

        private void aztecSymbolComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AztecSymbolType oldValue = BarcodeWriterSettings.AztecSymbol;
            try
            {
                BarcodeWriterSettings.AztecSymbol = (AztecSymbolType)aztecSymbolComboBox.SelectedItem;
            }
            catch (WriterSettingsException exc)
            {
                OnWriterException(exc);
                BarcodeWriterSettings.AztecSymbol = oldValue;
                aztecSymbolComboBox.SelectedItem = oldValue;
            }
        }

        private void aztecLayersCountComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int oldValue = BarcodeWriterSettings.AztecDataLayers;
            try
            {
                BarcodeWriterSettings.AztecDataLayers = aztecLayersCountComboBox.SelectedIndex;
            }
            catch (WriterSettingsException exc)
            {
                OnWriterException(exc);
                BarcodeWriterSettings.AztecDataLayers = oldValue;
                aztecLayersCountComboBox.SelectedIndex = oldValue;
            }
        }

        private void aztecEncodingModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BarcodeWriterSettings.AztecEncodingMode = (AztecEncodingMode)aztecEncodingModeComboBox.SelectedItem;
        }

        private void aztecErrorCorrectionNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            BarcodeWriterSettings.AztecErrorCorrectionDataPercent = (double)aztecErrorCorrectionNumericUpDown.Value;
        }

        #endregion

        #region DataMatrix

        private void datamatrixEncodingModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BarcodeWriterSettings.DataMatrixEncodingMode = (DataMatrixEncodingMode)datamatrixEncodingModeComboBox.SelectedItem;
        }

        private void datamatrixSymbolSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BarcodeWriterSettings == null)
                return;
            DataMatrixSymbolType oldValue = BarcodeWriterSettings.DataMatrixSymbol;
            try
            {
                BarcodeWriterSettings.DataMatrixSymbol = (DataMatrixSymbolType)datamatrixSymbolSizeComboBox.SelectedItem;
            }
            catch (WriterSettingsException exc)
            {
                OnWriterException(exc);
                BarcodeWriterSettings.DataMatrixSymbol = oldValue;
                datamatrixSymbolSizeComboBox.SelectedItem = oldValue;
            }
        }

        #endregion

        #region QR

        private void qrEncodingModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            QREncodingMode oldValue = BarcodeWriterSettings.QREncodingMode;
            try
            {
                BarcodeWriterSettings.BeginInit();
                try
                {
                    BarcodeWriterSettings.QREncodingMode = (QREncodingMode)qrEncodingModeComboBox.SelectedItem;
                    EncodeValue();
                }
                finally
                {
                    BarcodeWriterSettings.EndInit();
                }
            }
            catch (WriterSettingsException exc)
            {
                OnWriterException(exc);
                BarcodeWriterSettings.QREncodingMode = oldValue;
                qrEncodingModeComboBox.SelectedItem = oldValue;
            }
        }

        private void qrSymbolSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BarcodeWriterSettings.QRSymbol = (QRSymbolVersion)qrSymbolSizeComboBox.SelectedItem;
        }

        private void qrECCLevelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BarcodeWriterSettings.QRErrorCorrectionLevel = (QRErrorCorrectionLevel)qrECCLevelComboBox.SelectedItem;
        }

        #endregion

        #region MicroQR

        private void microQrEncodingModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BarcodeWriterSettings.QREncodingMode = (QREncodingMode)microQrEncodingModeComboBox.SelectedItem;
        }

        private void microQrSymbolSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            QRSymbolVersion oldValue = BarcodeWriterSettings.QRSymbol;
            try
            {
                BarcodeWriterSettings.QRSymbol = (QRSymbolVersion)microQrSymbolSizeComboBox.SelectedItem;
            }
            catch (WriterSettingsException exc)
            {
                OnWriterException(exc);
                BarcodeWriterSettings.QRSymbol = oldValue;
                microQrSymbolSizeComboBox.SelectedItem = oldValue;
            }
        }

        private void microQrECCLevelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BarcodeWriterSettings.QRErrorCorrectionLevel = (QRErrorCorrectionLevel)microQrECCLevelComboBox.SelectedItem;
        }

        #endregion

        #region MaxiCode

        private void maxiCodeResolutonNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            BarcodeWriterSettings.MaxiCodeResolution = (double)maxiCodeResolutonNumericUpDown.Value;
        }

        private void maxiCodeEncodingModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MaxiCodeEncodingMode oldValue = BarcodeWriterSettings.MaxiCodeEncodingMode;
            try
            {
                BarcodeWriterSettings.MaxiCodeEncodingMode = (MaxiCodeEncodingMode)maxiCodeEncodingModeComboBox.SelectedItem;
            }
            catch (WriterSettingsException exc)
            {
                OnWriterException(exc);
                BarcodeWriterSettings.MaxiCodeEncodingMode = oldValue;
                maxiCodeEncodingModeComboBox.SelectedItem = oldValue;
            }
        }

        #endregion

        #region PDF417

        private void pdf417EncodingModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BarcodeWriterSettings.PDF417EncodingMode = (PDF417EncodingMode)pdf417EncodingModeComboBox.SelectedItem;
        }

        private void pdf417ErrorCorrectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BarcodeWriterSettings.PDF417ErrorCorrectionLevel = (PDF417ErrorCorrectionLevel)pdf417ErrorCorrectionComboBox.SelectedItem;
        }

        private void pdf417RowsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            BarcodeWriterSettings.PDF417Rows = (int)pdf417RowsNumericUpDown.Value;
        }

        private void pdf417ColsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            int oldValue = BarcodeWriterSettings.PDF417Columns;
            try
            {
                BarcodeWriterSettings.PDF417Columns = (int)pdf417ColsNumericUpDown.Value;
            }
            catch (WriterSettingsException exc)
            {
                OnWriterException(exc);
                BarcodeWriterSettings.PDF417Columns = oldValue;
                pdf417ColsNumericUpDown.Value = oldValue;
            }
        }

        private void pdf417RowHeightNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            BarcodeWriterSettings.PDF417RowHeight = (int)pdf417RowHeightNumericUpDown.Value;
        }

        private void pdf417CompactCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (pdf417CompactCheckBox.Checked)
                BarcodeWriterSettings.Barcode = BarcodeType.PDF417Compact;
            else
                BarcodeWriterSettings.Barcode = BarcodeType.PDF417;
        }

        #endregion

        #region Micro PDF417

        private void microPDF417EncodingModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BarcodeWriterSettings.MicroPDF417EncodingMode = (PDF417EncodingMode)microPDF417EncodingModeComboBox.SelectedItem;
        }

        private void micropDF417SymbolSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BarcodeWriterSettings.MicroPDF417Symbol = (MicroPDF417SymbolType)microPDF417SymbolSizeComboBox.SelectedItem;
        }

        private void microPDF417ColumnsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            BarcodeWriterSettings.MicroPDF417Columns = (int)microPDF417ColumnsNumericUpDown.Value;
        }

        private void microPED417RowHeightNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            BarcodeWriterSettings.MicroPDF417RowHeight = (int)microPED417RowHeightNumericUpDown.Value;
        }

        #endregion

        #region Code 16K

        private void code16KEncodingModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BarcodeWriterSettings.Code16KEncodingMode = (Code128EncodingMode)code16KEncodingModeComboBox.SelectedItem;
        }

        private void code16KRowsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BarcodeWriterSettings.Code16KRows = (int)code16KRowsComboBox.SelectedItem;
        }


        #endregion

        #region Han Xin Code

        private void hanXinCodeEncodingModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            HanXinCodeEncodingMode oldValue = BarcodeWriterSettings.HanXinCodeEncodingMode;
            try
            {
                BarcodeWriterSettings.BeginInit();
                try
                {
                    BarcodeWriterSettings.HanXinCodeEncodingMode = (HanXinCodeEncodingMode)hanXinCodeEncodingModeComboBox.SelectedItem;
                    EncodeValue();
                }
                finally
                {
                    BarcodeWriterSettings.EndInit();
                }
            }
            catch (WriterSettingsException exc)
            {
                OnWriterException(exc);
                BarcodeWriterSettings.HanXinCodeEncodingMode = oldValue;
                hanXinCodeEncodingModeComboBox.SelectedItem = oldValue;
            }
        }

        private void hanXinCodeSymbolVersionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BarcodeWriterSettings.HanXinCodeSymbol = (HanXinCodeSymbolVersion)hanXinCodeSymbolVersionComboBox.SelectedItem;
        }

        private void hanXinCodeECCLevelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BarcodeWriterSettings.HanXinCodeErrorCorrectionLevel = (HanXinCodeErrorCorrectionLevel)hanXinCodeECCLevelComboBox.SelectedItem;
        }

        #endregion


        #endregion


        #region Tools

        /// <summary>
        /// Add a enum values to ComboBox items.
        /// </summary>
        private static void AddEnumValues(ComboBox comboBox, Type type)
        {
            Array values = Enum.GetValues(type);
            for (int i = 0; i < values.Length; i++)
                comboBox.Items.Add(values.GetValue(i));
        }

        /// <summary>
        /// Called when writer exception occurs.
        /// </summary>
        /// <param name="exception">The exception.</param>
        private void OnWriterException(WriterSettingsException ex)
        {
            if (WriterException != null)
                WriterException(this, new Vintasoft.Imaging.ExceptionEventArgs(ex));
            else
                MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #endregion



        #region Events

        /// <summary>
        /// Occurs when writer throws exception.        
        /// </summary>
        public event EventHandler<Vintasoft.Imaging.ExceptionEventArgs> WriterException;

        #endregion

    }
}
