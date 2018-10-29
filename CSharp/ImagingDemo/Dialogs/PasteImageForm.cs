using System;
using System.Windows.Forms;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to specify parameters for pasting an image.
    /// </summary>
    public partial class PasteImageForm : Form
    {

        #region Constructor

        public PasteImageForm(int imageWidth, int imageHeight)
        {
            InitializeComponent();

            xCoordNumericUpDown.Maximum = imageWidth;
            yCoordNumericUpDown.Maximum = imageHeight;
        }

        #endregion



        #region Properties

        int _xCoord = 0;
        public int X
        {
            get { return _xCoord; }
        }

        int _yCoord = 0;
        public int Y
        {
            get { return _yCoord; }
        }

        #endregion



        #region Methods

        private void okButton_Click(object sender, EventArgs e)
        {
            _xCoord = (int)xCoordNumericUpDown.Value;
            _yCoord = (int)yCoordNumericUpDown.Value;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        #endregion

    }
}