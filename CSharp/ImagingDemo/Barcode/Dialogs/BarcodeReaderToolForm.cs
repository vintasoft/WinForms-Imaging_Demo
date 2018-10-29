using System;
using System.Text;
using System.Windows.Forms;

using DemosCommonCode;

using Vintasoft.Barcode;
using Vintasoft.Barcode.BarcodeInfo;
using Vintasoft.Barcode.GS1;


namespace ImagingDemo.Barcode
{
    public partial class BarcodeReaderToolForm : Form
    {

        #region Fields

        BarcodeReaderTool _readerTool;

        #endregion



        #region Constructors

        public BarcodeReaderToolForm()
        {
            InitializeComponent();
        }

        public BarcodeReaderToolForm(BarcodeReaderTool readerTool)
            : this()
        {
            _readerTool = readerTool;
            _readerTool.RecognitionStarted += new EventHandler(readerTool_RecognitionStarted);
            _readerTool.RecognitionProgress += new EventHandler<BarcodeReaderProgressEventArgs>(readerTool_RecognitionProgress);
            _readerTool.RecognitionFinished += new EventHandler(readerTool_RecognitionFinished);
            barcodeReaderSettingsControl1.RestoreSettings(_readerTool.ReaderSettings);
            recognitionResultsTextBox.AppendText(string.Format("VintaSoftBarcode.NET SDK v{0}", Vintasoft.Barcode.BarcodeGlobalSettings.AssemblyVersion));
            if (Vintasoft.Barcode.BarcodeGlobalSettings.IsDemoVersion)
                recognitionResultsTextBox.AppendText(" (Demo Version)");
        }

        #endregion



        #region Methods

        private void readerTool_RecognitionFinished(object sender, EventArgs e)
        {
            recognitionResultsTextBox.Text = GetRecognitionResults();
            recognizeBarcodeButton.Enabled = true;
        }

        private string GetRecognitionResults()
        {
            if (_readerTool.RecognitionResults != null)
            {
                if (_readerTool.RecognitionResults.Length == 0)
                    return string.Format("No barcodes found. ({0} ms)", _readerTool.RecognizeTime.TotalMilliseconds);
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(string.Format("{0} barcode found. ({1}ms)", _readerTool.RecognitionResults.Length, _readerTool.RecognizeTime.TotalMilliseconds));
                sb.AppendLine();
                for (int i = 0; i < _readerTool.RecognitionResults.Length; i++)
                    sb.AppendLine(GetBarcodeInfo(i, _readerTool.RecognitionResults[i]));
                return sb.ToString();
            }
            return "";
        }

        private string GetBarcodeInfo(int index, IBarcodeInfo info)
        {
            info.ShowNonDataFlagsInValue = true;

            string value = info.Value;
            if (info.BarcodeType == BarcodeType.UPCE)
                value += string.Format(" ({0})", (info as UPCEANInfo).UPCEValue);

            string confidence;
            if (info.Confidence == ReaderSettings.ConfidenceNotAvailable)
                confidence = "N/A";
            else
                confidence = Math.Round(info.Confidence).ToString() + "%";

            if (info is BarcodeSubsetInfo)
            {
                value = string.Format("{0}{1}Base value: {2}",
                    RemoveSpecialCharacters(value), Environment.NewLine,
                    RemoveSpecialCharacters(((BarcodeSubsetInfo)info).BaseBarcodeInfo.Value));
            }
            else
            {
                value = RemoveSpecialCharacters(value);
            }

            string barcodeTypeValue;
            if (info is BarcodeSubsetInfo)
                barcodeTypeValue = ((BarcodeSubsetInfo)info).BarcodeSubset.ToString();
            else
                barcodeTypeValue = info.BarcodeType.ToString();


            StringBuilder result = new StringBuilder();
            result.AppendLine(string.Format("[{0}:{1}]", index + 1, barcodeTypeValue));
            result.AppendLine(string.Format("Value: {0}", value));
            result.AppendLine(string.Format("Confidence: {0}", confidence));
            result.AppendLine(string.Format("Reading quality: {0}", info.ReadingQuality));
            result.AppendLine(string.Format("Threshold: {0}", info.Threshold));
            result.AppendLine(string.Format("Region: {0}", info.Region));
            return result.ToString();
        }

        private string GetGS1BarcodeValue(string value)
        {
            GS1ApplicationIdentifierValue[] ai = GS1Codec.Decode(value);
            if (ai == null)
                return null;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ai.Length; i++)
                sb.Append(ai[i].ToString());
            return sb.ToString();
        }


        private string RemoveSpecialCharacters(string text)
        {
            StringBuilder sb = new StringBuilder();
            if (text != null)
                for (int i = 0; i < text.Length; i++)
                    if (text[i] >= ' ' || text[i] == '\n' || text[i] == '\r' || text[i] == '\t')
                        sb.Append(text[i]);
                    else
                        sb.Append('?');
            return sb.ToString();
        }

        private void readerTool_RecognitionStarted(object sender, EventArgs e)
        {
            recognizeBarcodeButton.Enabled = false;
            barcodeReaderSettingsControl1.SetReaderSettings(_readerTool.ReaderSettings);
        }

        private void recognizeBarcodeButton_Click(object sender, EventArgs e)
        {
            if (!_readerTool.IsRecognitionStarted)
            {
                try
                {
                    _readerTool.ReadBarcodesAsync();
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                }
            }
        }

        private void readerTool_RecognitionProgress(object sender, BarcodeReaderProgressEventArgs e)
        {
            recognitionProgressBar.Value = e.Progress;
        }

        #endregion

    }
}
