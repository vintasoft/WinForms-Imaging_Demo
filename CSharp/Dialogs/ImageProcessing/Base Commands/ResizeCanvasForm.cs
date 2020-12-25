using System.Drawing;
using System.Windows.Forms;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and edit settings of the ResizeCanvasCommand.
    /// </summary>
    public partial class ResizeCanvasForm : Form
    {

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ResizeCanvasForm"/> class.
        /// </summary>
        /// <param name="width">Image width.</param>
        /// <param name="height">Image height.</param>
        public ResizeCanvasForm(int width, int height)
        {
            InitializeComponent();

            nWidth.Value = width;
            nHeight.Value = height;
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets the image position.
        /// </summary>
        public Point ImagePosition
        {
            get
            {
                return new Point((int)xPositionNumericUpDown.Value, (int)yPositionNumericUpDown.Value);
            }
        }

        /// <summary>
        /// Gets the canvas width.
        /// </summary>
        public int CanvasWidth
        {
            get
            {
                return (int)nWidth.Value;
            }
        }

        /// <summary>
        /// Gets the canvas height.
        /// </summary>
		public int CanvasHeight
        {
            get
            {
                return (int)nHeight.Value;
            }
        }

        /// <summary>
        /// Gets the canvas color.
        /// </summary>
        public Color CanvasColor
        {
            get
            {
                return canvasColorPanelControl.Color;
            }
        }

        #endregion

    }
}