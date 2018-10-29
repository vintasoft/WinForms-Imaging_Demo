using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImagingDemo
{
    public partial class ThumbnailSizeForm : Form
    {

        #region Constructor

        public ThumbnailSizeForm(Size size)
        {
            InitializeComponent();
            _thumbnailSize = new Size(size.Width, size.Height);
            widthNumericUpDown.Value = size.Width;
            heightNumericUpDown.Value = size.Height;
        }

        #endregion


        #region Properties

        private Size _thumbnailSize;
        public Size ThumbnailSize
        {
            get
            {
                return _thumbnailSize;
            }
        }

        #endregion


        #region Methods

        private void okButton_Click(object sender, EventArgs e)
        {
            _thumbnailSize = new Size((int)widthNumericUpDown.Value, (int)heightNumericUpDown.Value);
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        #endregion

    }
}