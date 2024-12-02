using System.Windows.Forms;
using System.ComponentModel;


#if !REMOVE_BARCODE_SDK
using Vintasoft.Barcode; 
#endif
using System.Drawing;

namespace DemosCommonCode.Barcode
{
    public partial class BarcodeWriterToolForm : Form
    {

        public BarcodeWriterToolForm()
        {
            InitializeComponent();
        }

#if !REMOVE_BARCODE_SDK
        public BarcodeWriterToolForm(WriterSettings settings)
           : this()
        {
            barcodeWriterSettingsControl1.BarcodeWriterSettings = settings;
            barcodeWriterSettingsControl1.CanChangeBarcodeSize = false;
        }
#endif



        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Image BarcodeImage
        {
            set
            {
                barcodeWriterSettingsControl1.BarcodeImage = value;
            }
        }

    }
}
