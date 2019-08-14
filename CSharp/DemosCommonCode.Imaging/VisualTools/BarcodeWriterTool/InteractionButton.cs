using System;
using System.Drawing;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.UI;
using Vintasoft.Imaging.UI.VisualTools.UserInteraction;
using Vintasoft.Imaging.Utils;

namespace DemosCommonCode.Barcode
{
    /// <summary>
    /// Represents an interaction button.
    /// </summary>
    internal class InteractionButton : InteractionArea
    {

        #region Fields

        /// <summary>
        /// Interactive object with which this interaction button is linked.
        /// </summary>
        IRectangularInteractiveObject _interactiveObject;

        /// <summary>
        /// Vertical distance between this button and interactive object.
        /// </summary>
        int _distance = 6;

        #endregion



        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="InteractionButton"/> class.
        /// </summary>
        /// <param name="interactiveObject">Interactive object with
        /// which this interaction button is linked.</param>
        internal InteractionButton(IRectangularInteractiveObject interactiveObject)
            : base("ExecuteButton", InteractionAreaType.Clickable)
        {
            _interactiveObject = interactiveObject;
            Cursor = Cursors.Arrow;
        }

        #endregion



        #region Properties

        VintasoftImage _image;
        /// <summary>
        /// Gets or sets the button image.
        /// </summary>
        internal VintasoftImage Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
            }
        }

        float _x;
        /// <summary>
        /// Gets or sets X offset of the button relative to the interactive object.
        /// </summary>
        internal float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Draws interaction button on specified graphics.
        /// </summary>
        public override void Draw(ImageViewer viewer, Graphics g)
        {
            if (_image != null)
            {
                RectangleF buttonRect = GetBoundingBox(viewer);
                _image.Draw(g, buttonRect);
            }
        }

        /// <summary>
        /// Returns a bounding box of interaction button in viewer space.
        /// </summary>
        public override RectangleF GetBoundingBox(ImageViewer viewer)
        {
            if (_image == null)
                return Rectangle.Empty;

            double x0, y0, x1, y1;
            _interactiveObject.GetRectangle(out x0, out y0, out x1, out y1);

            RectangleF objectRect = new RectangleF((float)x0, (float)y0, (float)(x1 - x0), (float)(y1 - y0));
            objectRect = GraphicsUtils.TransformRect(objectRect, _interactiveObject.GetPointTransform(viewer));

            return new RectangleF(objectRect.X + X, objectRect.Y - _distance - _image.Height, _image.Width, _image.Height);
        }

        #endregion

    }
}
