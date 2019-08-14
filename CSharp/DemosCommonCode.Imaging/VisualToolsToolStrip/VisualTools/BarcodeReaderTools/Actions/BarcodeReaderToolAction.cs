using System.Windows.Forms;

using Vintasoft.Barcode;

using DemosCommonCode.Imaging;
using System.Drawing;

namespace DemosCommonCode.Barcode
{
    /// <summary>
    /// Contains information about <see cref="BarcodeReaderTool"/>, which is used in <see cref="VisualToolsToolStrip"/>.
    /// </summary>
    public class BarcodeReaderToolAction : VisualToolAction
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
        /// Initializes a new instance of the <see cref="BarcodeReaderToolItem"/> class.
        /// </summary>
        /// <param name="visualTool">The visual tool.</param>
        /// <param name="text">The action text.</param>
        /// <param name="toolTip">The action tool tip.</param>
        /// <param name="icon">The action icon.</param>
        /// <param name="subactions">The sub-actions of the action.</param>
        public BarcodeReaderToolAction(
            BarcodeReaderTool visualTool,
            string text,
            string toolTip,
            Image icon,
            params VisualToolAction[] subactions)
            : base(visualTool, text, toolTip, icon, subactions)
        {
            visualTool.ReaderSettings.AutomaticRecognition = true;
            visualTool.ReaderSettings.ScanDirection = ScanDirection.Horizontal | ScanDirection.Vertical;
            visualTool.ReaderSettings.ScanBarcodeTypes = BarcodeType.Code128 | BarcodeType.Code39;
        }

        #endregion



        #region Methods

        /// <summary>
        /// Activates this item.
        /// </summary>
        public override void Activate()
        {
            base.Activate();

            if (_barcodeReaderToolForm == null)
            {
                _barcodeReaderToolForm = new BarcodeReaderToolForm((BarcodeReaderTool)VisualTool);
                _barcodeReaderToolForm.Show();
            }
        }

        /// <summary>
        /// Deactivates this item.
        /// </summary>
        public override void Deactivate()
        {
            if (_barcodeReaderToolForm != null)
            {
                _barcodeReaderToolForm.Close();
                _barcodeReaderToolForm.Dispose();
                _barcodeReaderToolForm = null;
            }

            base.Deactivate();
        }

        #endregion

    }
}
