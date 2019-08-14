using System;
using System.Drawing;
using System.Windows.Forms;

using DemosCommonCode.Imaging;

namespace ImagingDemo
{
	public partial class ResizeCanvasForm : Form
    {

        #region Constructor

        public ResizeCanvasForm(int width, int height)
		{
			InitializeComponent();

			nWidth.Value = width;
			nHeight.Value = height;
        }

        #endregion



        #region Properties

        public Point ImagePosition
        {
            get
            {
                return new Point((int)xPositionNumericUpDown.Value, (int)yPositionNumericUpDown.Value);
            }
        }

        public int CanvasWidth
		{
			get
			{
				return (int)nWidth.Value;
			}
		}

		public int CanvasHeight
		{
			get
			{
				return (int)nHeight.Value;
			}
        }

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