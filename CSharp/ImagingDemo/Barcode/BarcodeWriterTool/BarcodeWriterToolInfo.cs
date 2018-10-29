using System;
using System.Drawing;
using System.Windows.Forms;

using Vintasoft.Barcode;
using Vintasoft.Imaging;

using DemosCommonCode.Imaging;

namespace ImagingDemo.Barcode
{
    /// <summary>
    /// Class that contains information about <see cref="BarcodeWriterTool"/>
    /// used in <see cref="ImageViewerToolStrip"/>.
    /// </summary>
    internal class BarcodeWriterToolInfo : ToolStripVisualToolInfo
    {

        #region Fields

        /// <summary>
        /// A form that allows to set the barcode writer settings.
        /// </summary>
        Form _barcodeWriterToolForm;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BarcodeWriterToolInfo"/> class.
        /// </summary>
        internal BarcodeWriterToolInfo(ToolStripItem toolButton)
            : this(new BarcodeWriterTool(), toolButton)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BarcodeWriterToolInfo"/> class.
        /// </summary>
        private BarcodeWriterToolInfo(BarcodeWriterTool tool, ToolStripItem toolButton)
            : base(tool, toolButton)
        {
            tool.WriterSettings.Barcode = BarcodeType.Code128;
            tool.WriterSettings.PixelFormat = BarcodeImagePixelFormat.Bgra32;
            tool.WriterSettings.Value = "0123456789";
            tool.WriterSettings.Padding = 4;
            tool.Rectangle = new Rectangle(0, 0, 120, 40);
            tool.WriterSettings.Changed += new EventHandler(WriterSettings_Changed);
            tool.RefreshBarcodeImage(true);
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

            _barcodeWriterToolForm = new BarcodeWriterToolForm(((BarcodeWriterTool)Tool).WriterSettings);
            _barcodeWriterToolForm.TopMost = true;
            _barcodeWriterToolForm.StartPosition = FormStartPosition.Manual;
            _barcodeWriterToolForm.Location = new Point(5, 70);
            _barcodeWriterToolForm.Show();
        }

        /// <summary>
        /// Raises the <see cref="Deselected"/> event.
        /// It is called when the visual tool has been deselected.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        protected override void OnDeselected(EventArgs e)
        {
            base.OnDeselected(e);

            _barcodeWriterToolForm.Close();
        }

        void WriterSettings_Changed(object sender, EventArgs e)
        {
            if (_barcodeWriterToolForm == null)
                return;
            BarcodeWriterToolForm form = _barcodeWriterToolForm as BarcodeWriterToolForm;
            try
            {
                BarcodeWriterTool tool = Tool as BarcodeWriterTool;
                using (VintasoftImage barcodeImage = tool.GetBarcodeImage())
                {
                    form.BarcodeImage = barcodeImage.GetAsBitmap();
                }
            }
            catch (WriterSettingsException)
            {
                form.BarcodeImage = null;
            }
        }

        #endregion

    }
}
