using System.Windows.Forms;

using Vintasoft.Barcode;
using System.Drawing;

namespace ImagingDemo.Barcode
{
    public partial class BarcodeWriterToolForm : Form
    {

        public BarcodeWriterToolForm()
        {
            InitializeComponent();
        }

        public BarcodeWriterToolForm(WriterSettings settings)
            : this()
        {
            barcodeWriterSettingsControl1.BarcodeWriterSettings = settings;
            barcodeWriterSettingsControl1.CanChangeBarcodeSize = false;
        }

        public Image BarcodeImage
        {
            set
            {
                barcodeWriterSettingsControl1.BarcodeImage = value;
            }
        }

    }
}
