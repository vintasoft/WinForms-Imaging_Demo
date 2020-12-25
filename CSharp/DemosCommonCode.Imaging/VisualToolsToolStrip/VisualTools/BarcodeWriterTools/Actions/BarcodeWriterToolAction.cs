using System;
using System.Drawing;
using System.Windows.Forms;

#if !REMOVE_BARCODE_SDK
using Vintasoft.Barcode; 
#endif
using Vintasoft.Imaging;

using DemosCommonCode.Imaging;

namespace DemosCommonCode.Barcode
{
    /// <summary>
    /// Contains information about <see cref="BarcodeWriterTool"/>, which is used in <see cref="VisualToolsToolStrip"/>.
    /// </summary>
    public class BarcodeWriterToolAction : VisualToolAction
    {

        #region Fields

        /// <summary>
        /// A form that allows to set the barcode writer settings.
        /// </summary>
        Form _barcodeWriterToolForm;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BarcodeWriterToolItem"/> class.
        /// </summary>
        /// <param name="visualTool">The visual tool.</param>
        /// <param name="text">The action text.</param>
        /// <param name="toolTip">The action tool tip.</param>
        /// <param name="icon">The action icon.</param>
        /// <param name="subactions">The sub-actions of the action.</param>
        public BarcodeWriterToolAction(
            BarcodeWriterTool visualTool,
            string text,
            string toolTip,
            Image icon,
            params VisualToolAction[] subactions)
            : base(visualTool, text, toolTip, icon, subactions)
        {
#if !REMOVE_BARCODE_SDK
            visualTool.WriterSettings.Barcode = BarcodeType.Code128;
            visualTool.WriterSettings.PixelFormat = BarcodeImagePixelFormat.Bgra32;
            visualTool.WriterSettings.Value = "0123456789";
            visualTool.WriterSettings.Padding = 4;
            visualTool.Rectangle = new Rectangle(0, 0, 120, 40);
            visualTool.WriterSettings.Changed += new EventHandler(WriterSettings_Changed);
#endif
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Activates this item.
        /// </summary>
        public override void Activate()
        {
            base.Activate();

#if !REMOVE_BARCODE_SDK
            if (_barcodeWriterToolForm == null)
            {
                _barcodeWriterToolForm = new BarcodeWriterToolForm(((BarcodeWriterTool)VisualTool).WriterSettings);
                _barcodeWriterToolForm.TopMost = true;
                _barcodeWriterToolForm.StartPosition = FormStartPosition.Manual;
                _barcodeWriterToolForm.Location = new Point(5, 70);
                _barcodeWriterToolForm.Show();
            } 
#endif
        }

        /// <summary>
        /// Deactivates this item.
        /// </summary>
        public override void Deactivate()
        {
            if (_barcodeWriterToolForm != null)
            {
                _barcodeWriterToolForm.Close();
                _barcodeWriterToolForm.Dispose();
                _barcodeWriterToolForm = null;
            }

            base.Deactivate();
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// Updates barcode image.
        /// </summary>
        private void WriterSettings_Changed(object sender, EventArgs e)
        {
#if !REMOVE_BARCODE_SDK
            if (_barcodeWriterToolForm == null)
                return;
            BarcodeWriterToolForm form = _barcodeWriterToolForm as BarcodeWriterToolForm;
            try
            {
                BarcodeWriterTool tool = (BarcodeWriterTool)VisualTool;
                using (VintasoftImage barcodeImage = tool.GetBarcodeImage())
                {
                    form.BarcodeImage = barcodeImage.GetAsBitmap();
                }
            }
            catch (WriterSettingsException)
            {
                form.BarcodeImage = null;
            } 
#endif
        }

        #endregion

        #endregion

    }
}
