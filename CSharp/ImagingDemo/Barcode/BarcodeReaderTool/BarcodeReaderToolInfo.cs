using System;
using System.Windows.Forms;

using Vintasoft.Barcode;

using DemosCommonCode.Imaging;

namespace ImagingDemo.Barcode
{
    /// <summary>
    /// Class that contains information about <see cref="BarcodeReaderTool"/>
    /// used in <see cref="ImageViewerToolStrip"/>.
    /// </summary>
    internal class BarcodeReaderToolInfo : ToolStripVisualToolInfo
    {

        #region Fields

        /// <summary>
        /// A form that allows to set the barcode reader settings and
        /// see the barcode reading results.
        /// </summary>
        Form _barcodeReaderToolForm;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BarcodeReaderToolInfo"/> class.
        /// </summary>
        internal BarcodeReaderToolInfo(ToolStripItem toolButton)
            : this(new BarcodeReaderTool(), toolButton)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BarcodeReaderToolInfo"/> class.
        /// </summary>
        private BarcodeReaderToolInfo(BarcodeReaderTool tool, ToolStripItem toolButton)
            : base(tool, toolButton)
        {
            tool.ReaderSettings.AutomaticRecognition = true;
            tool.ReaderSettings.ScanDirection = ScanDirection.Horizontal | ScanDirection.Vertical;
            tool.ReaderSettings.ScanBarcodeTypes = BarcodeType.Code128 | BarcodeType.Code39;
        }

        #endregion



        #region Methods

        /// <summary>
        /// Raises the <see cref="Selected"/> event.
        /// It is called when the visual tool has been selected.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        protected override void OnSelected(EventArgs e)
        {
            base.OnSelected(e);

            _barcodeReaderToolForm = new BarcodeReaderToolForm((BarcodeReaderTool)Tool);
            _barcodeReaderToolForm.Show();
        }

        /// <summary>
        /// Raises the <see cref="Deselected"/> event.
        /// It is called when the visual tool has been deselected.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        protected override void OnDeselected(EventArgs e)
        {
            base.OnDeselected(e);

            _barcodeReaderToolForm.Close();
        }

        #endregion

    }
}
