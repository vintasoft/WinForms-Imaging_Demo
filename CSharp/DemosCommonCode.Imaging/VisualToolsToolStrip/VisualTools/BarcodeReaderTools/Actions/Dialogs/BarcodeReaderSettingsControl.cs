using System;
using System.Collections.Generic;
using System.Windows.Forms;

#if !REMOVE_BARCODE_SDK
using Vintasoft.Barcode;
using Vintasoft.Barcode.SymbologySubsets;
using Vintasoft.Barcode.SymbologySubsets.GS1;
using Vintasoft.Barcode.SymbologySubsets.RoyalMailMailmark;
using Vintasoft.Barcode.SymbologySubsets.XFACompressed; 
#endif

namespace DemosCommonCode.Barcode
{
    public partial class BarcodeReaderSettingsControl : UserControl
    {

        #region Constructors

        public BarcodeReaderSettingsControl()
        {
            InitializeComponent();

#if !REMOVE_BARCODE_SDK
            if (Vintasoft.Barcode.BarcodeGlobalSettings.IsDemoVersion)
            {
                barcodeGs1_128CheckBox.Enabled = false;
                barcodeGs1DataBarCheckBox.Enabled = false;
                barcodeGs1DataBarExpandedCheckBox.Enabled = false;
                barcodeGs1DataBarExpandedStackedCheckBox.Enabled = false;
                barcodeGs1DataBarLimitedCheckBox.Enabled = false;
                barcodeGs1DataBarStackedCheckBox.Enabled = false;
                barcodeGs1QRCheckbox.Enabled = false;
                barcodeGs1DataMatrixCheckBox.Enabled = false;
                barcodeGs1AztecCheckBox.Enabled = false;
                barcodeMailmarkCmdmType7CheckBox.Enabled = false;
                barcodeMailmarkCmdmType9CheckBox.Enabled = false;
                barcodeMailmarkCmdmType29CheckBox.Enabled = false;
                barcodeDeutschePostIdentcodeCheckBox.Enabled = false;
                barcodeDeutschePostLeitcodeCheckBox.Enabled = false;
                barcodeSwissPostParcelCheckBox.Enabled = false;
                barcodeFedExGround96CheckBox.Enabled = false;
                barcodeDhlAwbCheckBox.Enabled = false;
                barcodePpn.Enabled = false;
                barcodeOpcCheckBox.Enabled = false;
                barcodeItf14CheckBox.Enabled = false;
                barcodeVin.Enabled = false;
                barcodePzn.Enabled = false;
                barcodeSscc18CheckBox.Enabled = false;
                barcodeVicsBolCheckBox.Enabled = false;
                barcodeVicsScacProCheckBox.Enabled = false;
                barcodeXFAAztec.Enabled = false;
                barcodeXFADataMatrix.Enabled = false;
                barcodeXFAPDF417.Enabled = false;
                barcodeXFAQR.Enabled = false;
                barcodePatchCode.Enabled = false;
            } 
#endif
        }

        #endregion



        #region Methods

        #region PUBLIC

#if !REMOVE_BARCODE_SDK
        public void SetReaderSettings(ReaderSettings readerSettings)
        {
            readerSettings.AutomaticRecognition = true;
            readerSettings.ScanInterval = trackBarScanInterval.Value;
            readerSettings.ExpectedBarcodes = trackBarExpectedBarcodes.Value;
            readerSettings.MinConfidence = 95;

            // set ScanDicrecion
            ScanDirection scanDirection = ScanDirection.None;
            if (directionLR.Checked)
                scanDirection |= ScanDirection.LeftToRight;
            if (directionRL.Checked)
                scanDirection |= ScanDirection.RightToLeft;
            if (directionTB.Checked)
                scanDirection |= ScanDirection.TopToBottom;
            if (directionBT.Checked)
                scanDirection |= ScanDirection.BottomToTop;
            if (directionAngle45.Checked)
                scanDirection |= ScanDirection.Angle45and135;
            readerSettings.ScanDirection = scanDirection;

            // set ScanBarcodes
            BarcodeType scanBarcodeTypes = BarcodeType.None;
            if (barcodeCode11.Checked)
                scanBarcodeTypes |= BarcodeType.Code11;
            if (barcodeMSI.Checked)
                scanBarcodeTypes |= BarcodeType.MSI;
            if (barcodeCode39.Checked)
                scanBarcodeTypes |= BarcodeType.Code39;
            if (barcodeCode93.Checked)
                scanBarcodeTypes |= BarcodeType.Code93;
            if (barcodeCode128.Checked)
                scanBarcodeTypes |= BarcodeType.Code128;
            if (barcodeCodabar.Checked)
                scanBarcodeTypes |= BarcodeType.Codabar;
            if (barcodeEAN.Checked)
                scanBarcodeTypes |= BarcodeType.EAN8 | BarcodeType.EAN13;
            if (barcodeEANPlus.Checked)
                scanBarcodeTypes |= BarcodeType.Plus2 | BarcodeType.Plus5;
            if (barcodeI25.Checked)
                scanBarcodeTypes |= BarcodeType.Interleaved2of5;
            if (barcodeS25.Checked)
                scanBarcodeTypes |= BarcodeType.Standard2of5;
            if (barcodeUPCA.Checked)
                scanBarcodeTypes |= BarcodeType.UPCA;
            if (barcodeUPCE.Checked)
                scanBarcodeTypes |= BarcodeType.UPCE;
            if (barcodeTelepen.Checked)
                scanBarcodeTypes |= BarcodeType.Telepen;
            if (barcodePlanet.Checked)
                scanBarcodeTypes |= BarcodeType.Planet;
            if (barcodeIntelligentMail.Checked)
                scanBarcodeTypes |= BarcodeType.IntelligentMail;
            if (barcodePostnet.Checked)
                scanBarcodeTypes |= BarcodeType.Postnet;
            if (barcodeRoyalMail.Checked)
                scanBarcodeTypes |= BarcodeType.RoyalMail;
            if (barcodeDutchKIX.Checked)
                scanBarcodeTypes |= BarcodeType.DutchKIX;
            if (barcodePatchCode.Checked)
                scanBarcodeTypes |= BarcodeType.PatchCode;
            if (barcodePharmacode.Checked)
                scanBarcodeTypes |= BarcodeType.Pharmacode;
            if (barcodePDF417.Checked)
                scanBarcodeTypes |= BarcodeType.PDF417 | BarcodeType.PDF417Compact;
            if (barcodeMicroPDF417.Checked)
                scanBarcodeTypes |= BarcodeType.MicroPDF417;
            if (barcodeDataMatrix.Checked)
                scanBarcodeTypes |= BarcodeType.DataMatrix;
            if (barcodeQR.Checked)
                scanBarcodeTypes |= BarcodeType.QR;
            if (barcodeMicroQR.Checked)
                scanBarcodeTypes |= BarcodeType.MicroQR;
            if (barcodeMaxiCode.Checked)
                scanBarcodeTypes |= BarcodeType.MaxiCode;
            if (barcodeRSS14.Checked)
                scanBarcodeTypes |= BarcodeType.RSS14;
            if (barcodeRSSLimited.Checked)
                scanBarcodeTypes |= BarcodeType.RSSLimited;
            if (barcodeRSSExpanded.Checked)
                scanBarcodeTypes |= BarcodeType.RSSExpanded;
            if (barcodeRSSExpandedStacked.Checked)
                scanBarcodeTypes |= BarcodeType.RSSExpandedStacked;
            if (barcodeRSS14Stacked.Checked)
                scanBarcodeTypes |= BarcodeType.RSS14Stacked;
            if (barcodeAztec.Checked)
                scanBarcodeTypes |= BarcodeType.Aztec;
            if (barcodeRSS14Stacked.Checked)
                scanBarcodeTypes |= BarcodeType.RSS14Stacked;
            if (barcodeAustralian.Checked)
                scanBarcodeTypes |= BarcodeType.AustralianPost;
            if (barcodeMailmark4CCheckBox.Checked)
                scanBarcodeTypes |= BarcodeType.Mailmark4StateC;
            if (barcodeMailmark4LCheckBox.Checked)
                scanBarcodeTypes |= BarcodeType.Mailmark4StateL;
            if (barcodeIata2of5.Checked)
                scanBarcodeTypes |= BarcodeType.IATA2of5;
            if (barcodeMatrix2of5.Checked)
                scanBarcodeTypes |= BarcodeType.Matrix2of5;
            if (barcodeCode16K.Checked)
                scanBarcodeTypes |= BarcodeType.Code16K;
            if (barcodeHanXinCodeCheckBox.Checked)
                scanBarcodeTypes |= BarcodeType.HanXinCode;
            readerSettings.ScanBarcodeTypes = scanBarcodeTypes;

            List<BarcodeSymbologySubset> scanBarcodeSubsets = readerSettings.ScanBarcodeSubsets;
            scanBarcodeSubsets.Clear();
            if (barcodeCode39.Checked)
                scanBarcodeSubsets.Add(BarcodeSymbologySubsets.Code39Extended);
            if (barcodeGs1_128CheckBox.Checked)
                scanBarcodeSubsets.Add(BarcodeSymbologySubsets.GS1_128);
            if (barcodeGs1DataBarCheckBox.Checked)
                scanBarcodeSubsets.Add(BarcodeSymbologySubsets.GS1DataBar);
            if (barcodeGs1DataBarExpandedCheckBox.Checked)
                scanBarcodeSubsets.Add(BarcodeSymbologySubsets.GS1DataBarExpanded);
            if (barcodeGs1DataBarExpandedStackedCheckBox.Checked)
                scanBarcodeSubsets.Add(BarcodeSymbologySubsets.GS1DataBarExpandedStacked);
            if (barcodeGs1DataBarLimitedCheckBox.Checked)
                scanBarcodeSubsets.Add(BarcodeSymbologySubsets.GS1DataBarLimited);
            if (barcodeGs1DataBarStackedCheckBox.Checked)
                scanBarcodeSubsets.Add(BarcodeSymbologySubsets.GS1DataBarStacked);
            if (barcodeGs1QRCheckbox.Checked)
                scanBarcodeSubsets.Add(BarcodeSymbologySubsets.GS1QR);
            if (barcodeGs1DataMatrixCheckBox.Checked)
                scanBarcodeSubsets.Add(BarcodeSymbologySubsets.GS1DataMatrix);
            if (barcodeGs1AztecCheckBox.Checked)
                scanBarcodeSubsets.Add(BarcodeSymbologySubsets.GS1Aztec);
            if (barcodeMailmarkCmdmType7CheckBox.Checked)
                scanBarcodeSubsets.Add(BarcodeSymbologySubsets.MailmarkCmdmType7);
            if (barcodeMailmarkCmdmType9CheckBox.Checked)
                scanBarcodeSubsets.Add(BarcodeSymbologySubsets.MailmarkCmdmType9);
            if (barcodeMailmarkCmdmType29CheckBox.Checked)
                scanBarcodeSubsets.Add(BarcodeSymbologySubsets.MailmarkCmdmType29);
            if (barcodeDeutschePostIdentcodeCheckBox.Checked)
                scanBarcodeSubsets.Add(BarcodeSymbologySubsets.DeutschePostIdentcode);
            if (barcodeDeutschePostLeitcodeCheckBox.Checked)
                scanBarcodeSubsets.Add(BarcodeSymbologySubsets.DeutschePostLeitcode);
            if (barcodeSwissPostParcelCheckBox.Checked)
                scanBarcodeSubsets.Add(BarcodeSymbologySubsets.SwissPostParcel);
            if (barcodeFedExGround96CheckBox.Checked)
                scanBarcodeSubsets.Add(BarcodeSymbologySubsets.FedExGround96);
            if (barcodeDhlAwbCheckBox.Checked)
                scanBarcodeSubsets.Add(BarcodeSymbologySubsets.DhlAwb);
            if (barcodeCode32.Checked)
                scanBarcodeSubsets.Add(BarcodeSymbologySubsets.Code32);
            if (barcodePpn.Checked)
                scanBarcodeSubsets.Add(BarcodeSymbologySubsets.PPN);
            if (barcodeIsxn.Checked)
            {
                scanBarcodeSubsets.Add(BarcodeSymbologySubsets.ISBN);
                scanBarcodeSubsets.Add(BarcodeSymbologySubsets.ISMN);
                scanBarcodeSubsets.Add(BarcodeSymbologySubsets.ISSN);
                if (barcodeEANPlus.Checked)
                {
                    scanBarcodeSubsets.Add(BarcodeSymbologySubsets.ISBNPlus2);
                    scanBarcodeSubsets.Add(BarcodeSymbologySubsets.ISMNPlus2);
                    scanBarcodeSubsets.Add(BarcodeSymbologySubsets.ISSNPlus2);
                    scanBarcodeSubsets.Add(BarcodeSymbologySubsets.ISBNPlus5);
                    scanBarcodeSubsets.Add(BarcodeSymbologySubsets.ISMNPlus5);
                    scanBarcodeSubsets.Add(BarcodeSymbologySubsets.ISSNPlus5);
                }
            }
            if (barcodeJanCheckBox.Checked)
            {
                scanBarcodeSubsets.Add(BarcodeSymbologySubsets.JAN13);
                scanBarcodeSubsets.Add(BarcodeSymbologySubsets.JAN8);
                if (barcodeEANPlus.Checked)
                {
                    scanBarcodeSubsets.Add(BarcodeSymbologySubsets.JAN13Plus2);
                    scanBarcodeSubsets.Add(BarcodeSymbologySubsets.JAN8Plus2);
                    scanBarcodeSubsets.Add(BarcodeSymbologySubsets.JAN13Plus5);
                    scanBarcodeSubsets.Add(BarcodeSymbologySubsets.JAN8Plus5);
                }
            }
            if (barcodeOpcCheckBox.Checked)
                scanBarcodeSubsets.Add(BarcodeSymbologySubsets.OPC);
            if (barcodeItf14CheckBox.Checked)
                scanBarcodeSubsets.Add(BarcodeSymbologySubsets.ITF14);
            if (barcodeVin.Checked)
                scanBarcodeSubsets.Add(BarcodeSymbologySubsets.VIN);
            if (barcodePzn.Checked)
                scanBarcodeSubsets.Add(BarcodeSymbologySubsets.PZN);
            if (barcodeSscc18CheckBox.Checked)
                scanBarcodeSubsets.Add(BarcodeSymbologySubsets.SSCC18);
            if (barcodeVicsBolCheckBox.Checked)
                scanBarcodeSubsets.Add(BarcodeSymbologySubsets.VicsBol);
            if (barcodeVicsScacProCheckBox.Checked)
                scanBarcodeSubsets.Add(BarcodeSymbologySubsets.VicsScacPro);
            if (barcodeXFAAztec.Checked)
                scanBarcodeSubsets.Add(BarcodeSymbologySubsets.XFACompressedAztec);
            if (barcodeXFADataMatrix.Checked)
                scanBarcodeSubsets.Add(BarcodeSymbologySubsets.XFACompressedDataMatrix);
            if (barcodeXFAPDF417.Checked)
                scanBarcodeSubsets.Add(BarcodeSymbologySubsets.XFACompressedPDF417);
            if (barcodeXFAQR.Checked)
                scanBarcodeSubsets.Add(BarcodeSymbologySubsets.XFACompressedQRCode);
        }

        public void RestoreSettings(ReaderSettings readerSettings)
        {
            trackBarExpectedBarcodes.Value = readerSettings.ExpectedBarcodes;
            trackBarScanInterval.Value = readerSettings.ScanInterval;

            ScanDirection scanDirection = readerSettings.ScanDirection;
            directionLR.Checked = (scanDirection & ScanDirection.LeftToRight) != 0;
            directionRL.Checked = (scanDirection & ScanDirection.RightToLeft) != 0;
            directionTB.Checked = (scanDirection & ScanDirection.TopToBottom) != 0;
            directionBT.Checked = (scanDirection & ScanDirection.BottomToTop) != 0;
            directionAngle45.Checked = (scanDirection & ScanDirection.Angle45and135) != 0;
            UpdateDirectionAngle45();

            // barcode types
            BarcodeType scanBarcodeTypes = readerSettings.ScanBarcodeTypes;
            barcodeCode11.Checked = (scanBarcodeTypes & BarcodeType.Code11) != 0;
            barcodeMSI.Checked = (scanBarcodeTypes & BarcodeType.MSI) != 0;
            barcodeCode39.Checked = (scanBarcodeTypes & BarcodeType.Code39) != 0;
            barcodeCode93.Checked = (scanBarcodeTypes & BarcodeType.Code93) != 0;
            barcodeCode128.Checked = (scanBarcodeTypes & BarcodeType.Code128) != 0;
            barcodeCodabar.Checked = (scanBarcodeTypes & BarcodeType.Codabar) != 0;
            barcodeEAN.Checked = (scanBarcodeTypes & BarcodeType.EAN13) != 0 || (scanBarcodeTypes & BarcodeType.EAN8) != 0;
            barcodeEANPlus.Checked = (scanBarcodeTypes & BarcodeType.Plus5) != 0 || (scanBarcodeTypes & BarcodeType.Plus2) != 0;
            barcodeI25.Checked = (scanBarcodeTypes & BarcodeType.Interleaved2of5) != 0;
            barcodeS25.Checked = (scanBarcodeTypes & BarcodeType.Standard2of5) != 0;
            barcodeUPCA.Checked = (scanBarcodeTypes & BarcodeType.UPCA) != 0;
            barcodeUPCE.Checked = (scanBarcodeTypes & BarcodeType.UPCE) != 0;
            barcodeAustralian.Checked = (scanBarcodeTypes & BarcodeType.AustralianPost) != 0;
            barcodeTelepen.Checked = (scanBarcodeTypes & BarcodeType.Telepen) != 0;
            barcodePlanet.Checked = (scanBarcodeTypes & BarcodeType.Planet) != 0;
            barcodeIntelligentMail.Checked = (scanBarcodeTypes & BarcodeType.IntelligentMail) != 0;
            barcodePostnet.Checked = (scanBarcodeTypes & BarcodeType.Postnet) != 0;
            barcodeRoyalMail.Checked = (scanBarcodeTypes & BarcodeType.RoyalMail) != 0;
            barcodeDutchKIX.Checked = (scanBarcodeTypes & BarcodeType.DutchKIX) != 0;
            barcodePatchCode.Checked = (scanBarcodeTypes & BarcodeType.PatchCode) != 0;
            barcodePDF417.Checked = ((scanBarcodeTypes & BarcodeType.PDF417) != 0) || ((scanBarcodeTypes & BarcodeType.PDF417Compact) != 0);
            barcodeMicroPDF417.Checked = (scanBarcodeTypes & BarcodeType.MicroPDF417) != 0;
            barcodeDataMatrix.Checked = (scanBarcodeTypes & BarcodeType.DataMatrix) != 0;
            barcodeQR.Checked = (scanBarcodeTypes & BarcodeType.QR) != 0;
            barcodeMicroQR.Checked = (scanBarcodeTypes & BarcodeType.MicroQR) != 0;
            barcodeMaxiCode.Checked = (scanBarcodeTypes & BarcodeType.MaxiCode) != 0;
            barcodeRSS14.Checked = (scanBarcodeTypes & BarcodeType.RSS14) != 0;
            barcodeRSSLimited.Checked = (scanBarcodeTypes & BarcodeType.RSSLimited) != 0;
            barcodeRSSExpanded.Checked = (scanBarcodeTypes & BarcodeType.RSSExpanded) != 0;
            barcodeRSS14Stacked.Checked = (scanBarcodeTypes & BarcodeType.RSS14Stacked) != 0;
            barcodeRSSExpandedStacked.Checked = (scanBarcodeTypes & BarcodeType.RSSExpandedStacked) != 0;
            barcodeAztec.Checked = (scanBarcodeTypes & BarcodeType.Aztec) != 0;
            barcodePharmacode.Checked = (scanBarcodeTypes & BarcodeType.Pharmacode) != 0;
            barcodeMailmark4CCheckBox.Checked = (scanBarcodeTypes & BarcodeType.Mailmark4StateC) != 0;
            barcodeMailmark4LCheckBox.Checked = (scanBarcodeTypes & BarcodeType.Mailmark4StateL) != 0;
            barcodeIata2of5.Checked = (scanBarcodeTypes & BarcodeType.IATA2of5) != 0;
            barcodeMatrix2of5.Checked = (scanBarcodeTypes & BarcodeType.Matrix2of5) != 0;
            barcodeCode16K.Checked = (scanBarcodeTypes & BarcodeType.Code16K) != 0;
            barcodeHanXinCodeCheckBox.Checked = (scanBarcodeTypes & BarcodeType.HanXinCode) != 0;

            // barcode subsets
            barcodeGs1_128CheckBox.Checked = false;
            barcodeGs1DataBarCheckBox.Checked = false;
            barcodeGs1DataBarExpandedCheckBox.Checked = false;
            barcodeGs1DataBarExpandedStackedCheckBox.Checked = false;
            barcodeGs1DataBarLimitedCheckBox.Checked = false;
            barcodeGs1DataBarStackedCheckBox.Checked = false;
            barcodeGs1QRCheckbox.Checked = false;
            barcodeGs1DataMatrixCheckBox.Checked = false;
            barcodeGs1AztecCheckBox.Checked = false;
            barcodeMailmarkCmdmType7CheckBox.Checked = false;
            barcodeMailmarkCmdmType9CheckBox.Checked = false;
            barcodeMailmarkCmdmType29CheckBox.Checked = false;
            barcodeDeutschePostIdentcodeCheckBox.Checked = false;
            barcodeDeutschePostLeitcodeCheckBox.Checked = false;
            barcodeSwissPostParcelCheckBox.Checked = false;
            barcodeFedExGround96CheckBox.Checked = false;
            barcodeDhlAwbCheckBox.Checked = false;
            barcodeCode32.Checked = false;
            barcodePpn.Checked = false;
            barcodeJanCheckBox.Checked = false;
            barcodeOpcCheckBox.Checked = false;
            barcodeItf14CheckBox.Checked = false;
            barcodeVin.Checked = false;
            barcodePzn.Checked = false;
            barcodeSscc18CheckBox.Checked = false;
            barcodeVicsBolCheckBox.Checked = false;
            barcodeVicsScacProCheckBox.Checked = false;

            List<BarcodeSymbologySubset> scanBarcodeSubsets = readerSettings.ScanBarcodeSubsets;
            foreach (BarcodeSymbologySubset subset in scanBarcodeSubsets)
            {
                if (subset is GS1_128BarcodeSymbology)
                    barcodeGs1_128CheckBox.Checked = true;
                if (subset is GS1DataBarBarcodeSymbology)
                    barcodeGs1DataBarCheckBox.Checked = true;
                if (subset is GS1DataBarExpandedBarcodeSymbology)
                    barcodeGs1DataBarExpandedCheckBox.Checked = true;
                if (subset is GS1DataBarExpandedStackedBarcodeSymbology)
                    barcodeGs1DataBarExpandedStackedCheckBox.Checked = true;
                if (subset is GS1DataBarLimitedBarcodeSymbology)
                    barcodeGs1DataBarLimitedCheckBox.Checked = true;
                if (subset is GS1DataBarStackedBarcodeSymbology)
                    barcodeGs1DataBarStackedCheckBox.Checked = true;
                if (subset is GS1QRBarcodeSymbology)
                    barcodeGs1QRCheckbox.Checked = true;
                if (subset is GS1DataMatrixBarcodeSymbology)
                    barcodeGs1DataMatrixCheckBox.Checked = true;
                if (subset is GS1AztecBarcodeSymbology)
                    barcodeGs1AztecCheckBox.Checked = true;
                if (subset is MailmarkCmdmType7BarcodeSymbology)
                    barcodeMailmarkCmdmType7CheckBox.Checked = true;
                if (subset is MailmarkCmdmType9BarcodeSymbology)
                    barcodeMailmarkCmdmType9CheckBox.Checked = true;
                if (subset is MailmarkCmdmType29BarcodeSymbology)
                    barcodeMailmarkCmdmType29CheckBox.Checked = true;
                if (subset is DeutschePostIdentcodeBarcodeSymbology)
                    barcodeDeutschePostIdentcodeCheckBox.Checked = true;
                if (subset is DeutschePostLeitcodeBarcodeSymbology)
                    barcodeDeutschePostLeitcodeCheckBox.Checked = true;
                if (subset is SwissPostParcelBarcodeSymbology)
                    barcodeSwissPostParcelCheckBox.Checked = true;
                if (subset is FedExGround96BarcodeSymbology)
                    barcodeFedExGround96CheckBox.Checked = true;
                if (subset is DhlAwbBarcodeSymbology)
                    barcodeDhlAwbCheckBox.Checked = true;
                if (subset is Code32BarcodeSymbology)
                    barcodeCode32.Checked = true;
                if (subset is PpnBarcodeSymbology)
                    barcodePpn.Checked = true;
                if (subset is JanBarcodeSymbology)
                    barcodeJanCheckBox.Checked = true;
                if (subset is IsbnBarcodeSymbology ||
                    subset is IsmnBarcodeSymbology ||
                    subset is IssnBarcodeSymbology)
                    barcodeIsxn.Checked = true;
                if (subset is OpcBarcodeSymbology)
                    barcodeOpcCheckBox.Checked = true;
                if (subset is Itf14BarcodeSymbology)
                    barcodeItf14CheckBox.Checked = true;
                if (subset is VinSymbology)
                    barcodeVin.Checked = true;
                if (subset is PznBarcodeSymbology)
                    barcodePzn.Checked = true;
                if (subset is Sscc18BarcodeSymbology)
                    barcodeSscc18CheckBox.Checked = true;
                if (subset is VicsBolBarcodeSymbology)
                    barcodeVicsBolCheckBox.Checked = true;
                if (subset is VicsScacProBarcodeSymbology)
                    barcodeVicsScacProCheckBox.Checked = true;
                if (subset is XFACompressedAztecBarcodeSymbology)
                    barcodeXFAAztec.Checked = true;
                if (subset is XFACompressedDataMatrixBarcodeSymbology)
                    barcodeXFADataMatrix.Checked = true;
                if (subset is XFACompressedPDF417BarcodeSymbology)
                    barcodeXFAPDF417.Checked = true;
                if (subset is XFACompressedQRCodeBarcodeSymbology)
                    barcodeXFAQR.Checked = true;
            }
        } 
#endif

        #endregion


        #region PRIVATE

        private void barcodeTypesAllOrClear_Click(object sender, EventArgs e)
        {
            Control.ControlCollection controls = ((TabPage)((Button)sender).Parent).Controls;
            bool value = false;
            foreach (Control c in controls)
                if (c is CheckBox && c.Enabled)
                {
                    value = !(c as CheckBox).Checked;
                    break;
                }
            foreach (Control c in controls)
                if (c is CheckBox && c.Enabled)
                    (c as CheckBox).Checked = value;
        }

        private void trackBarExpectedBarcodes_ValueChanged(object sender, EventArgs e)
        {
            labelExpectedBarcodes.Text = trackBarExpectedBarcodes.Value.ToString();
        }

        private void trackBarScanInterval_ValueChanged(object sender, EventArgs e)
        {
            labelScanInterval.Text = trackBarScanInterval.Value.ToString();
        }

        private void directionAngle45_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDirectionAngle45();
        }

        private void UpdateDirectionAngle45()
        {
            directionLB_RT.Visible = directionLT_RB.Visible = directionRB_LT.Visible = directionRT_LB.Visible = directionAngle45.Checked;
            if (directionAngle45.Checked)
            {
                directionLT_RB.Checked = directionLR.Checked || directionTB.Checked;
                directionRT_LB.Checked = directionTB.Checked || directionRL.Checked;
                directionLB_RT.Checked = directionLR.Checked || directionBT.Checked;
                directionRB_LT.Checked = directionBT.Checked || directionRL.Checked;
            }
        }

        #endregion

        #endregion

    }
}
