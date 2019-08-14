using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Pdf;
using Vintasoft.Imaging.Pdf.Drawing;
using Vintasoft.Imaging.Pdf.Drawing.GraphicsFigures;
using Vintasoft.Imaging.Pdf.Tree;
using Vintasoft.Imaging.Pdf.UI;
using Vintasoft.Imaging.Print;
using Vintasoft.Imaging.Utils;

namespace ImagingDemo
{    
    public class PdfPrintDocument: PrintDocument
    {

        #region Classes

        class PdfPageGraphicsFigure : GraphicsFigure
        {
            PdfPage _page;

            public PdfPageGraphicsFigure(PdfPage page)
                : base(0, true)
            {
                _page = page;
            }

            public override void DrawFigure(PdfGraphics graphics)
            {
                graphics.DrawPageAsForm(_page);
            }

            public override object Clone()
            {
                return new PdfPageGraphicsFigure(_page);
            }
        }

        #endregion



        #region Fields

        int _index = 0;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfPrintDocument"/> class.
        /// </summary>
        /// <param name="images">The images.</param>
        public PdfPrintDocument(ImageCollection images)
        {
            _images = images;
        }

        #endregion



        #region Properties

        bool _center = true;
        /// <summary>
        /// Gets or sets a value indicating whether the bitmap is centered.
        /// </summary>
        public bool Center
        {
            get
            {
                return _center;
            }
            set
            {
                _center = value;
            }
        }

        PrintScaleMode _printScaleMode = PrintScaleMode.BestFit;
        /// <summary>
        /// Gets or sets a value indicating how to scale bitmap.
        /// </summary>
        public PrintScaleMode PrintScaleMode
        {
            get
            {
                return _printScaleMode;
            }
            set
            {
                _printScaleMode = value;
            }
        }

        ImageCollection _images;        
        /// <summary>
        /// Gets or sets the images.
        /// </summary>
        public ImageCollection Images
        {
            get
            {
                return _images;
            }
            set
            {
                _images = value;
            }
        }

        #endregion



        #region Methods

        public static void Print(ImageCollection images)
        {
            PdfPrintDocument printDocument = new PdfPrintDocument(images);
            PrintDialog printDialog = new PrintDialog();
            printDialog.UseEXDialog = true;
            printDialog.PrinterSettings.FromPage = 1;
            printDialog.PrinterSettings.ToPage = images.Count;
            printDialog.Document = printDocument;
            PageSetupDialog pageSetupDialog = new PageSetupDialog();
            pageSetupDialog.Document = printDocument;
            if (printDialog.ShowDialog() == DialogResult.OK)
                if (pageSetupDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                }
        }

        protected override void OnBeginPrint(PrintEventArgs e)
        {
            _index = 0;
            base.OnBeginPrint(e);
        }

        protected override void OnPrintPage(PrintPageEventArgs e)
        {
            base.OnPrintPage(e);

            if (DesignMode)
                return;


            // printer resolution
            float printResolutionX = e.PageSettings.PrinterResolution.X;
            float printResolutionY = e.PageSettings.PrinterResolution.Y;

            // check resolution
            if (printResolutionX > 0 && printResolutionY == 0)
                printResolutionY = printResolutionX;
            if (printResolutionX <= 0 || printResolutionY <= 0)
            {
                printResolutionX = e.Graphics.DpiX;
                printResolutionY = e.Graphics.DpiY;
            }


            // margin in inch
            float printAreaMarginX = (float)e.MarginBounds.X / 100;
            float printAreaMarginY = (float)e.MarginBounds.Y / 100;
            if (!this.PrintController.IsPreview)
            {
                float pageHardMarginX = (float)e.PageSettings.HardMarginX / 100;
                float pageHardMarginY = (float)e.PageSettings.HardMarginY / 100;
                printAreaMarginX -= pageHardMarginX;
                printAreaMarginY -= pageHardMarginY;
            }

            // print area in inch
            float printAreaWidth = ((float)e.MarginBounds.Width / 100);
            float printAreaHeight = ((float)e.MarginBounds.Height / 100);

            // PDF page
            PdfPage page = PdfDocumentController.GetPageAssociatedWithImage(_images[_index]);
            if (page == null)
                // supprots print only PDF page
                throw new NotImplementedException();

            float imageX = printAreaMarginX * printResolutionX;
            float imageY = printAreaMarginY * printResolutionY;
            float imageWidth = (float)UnitOfMeasureConverter.ConvertToInches(page.Size.Width, UnitOfMeasure.PdfUserUnits);
            float imageHeight = (float)UnitOfMeasureConverter.ConvertToInches(page.Size.Height, UnitOfMeasure.PdfUserUnits);

            // page transform
            AffineMatrix transform = new AffineMatrix();
            transform.Scale(printResolutionX / 96.0, printResolutionY / 96.0);
            switch (PrintScaleMode)
            {
                case PrintScaleMode.None:
                    if (_center)
                    {
                        float difference = printAreaWidth - imageWidth;
                        imageX = printAreaMarginX;
                        if (difference > 0)
                            imageX += difference / 2;
                        difference = printAreaHeight - imageHeight;
                        imageY = printAreaMarginY;
                        if (difference > 0)
                            imageY += difference / 2;
                        imageX *= printResolutionX;
                        imageY *= printResolutionY;
                    }
                    else
                    {
                        imageX = printAreaMarginX * printResolutionX;
                        imageY = printAreaMarginY * printResolutionY;
                    }
                    break;
                case PrintScaleMode.BestFit:
                    float width = printAreaWidth;
                    float height = printAreaHeight;

                    float widthProportion = width / imageWidth;
                    float heightProportion = height / imageHeight;
                    float scale = Math.Min(widthProportion, heightProportion);
                    transform.Scale(scale, scale);
                    if (widthProportion < heightProportion)
                    {
                        height = imageHeight * widthProportion;
                    }
                    if (widthProportion > heightProportion)
                    {
                        width = imageWidth * heightProportion;
                    }

                    imageX = printAreaMarginX;
                    imageY = printAreaMarginY;

                    if (_center)
                    {
                        imageX += (printAreaWidth - width) / 2;
                        imageY += (printAreaHeight - height) / 2;
                    }
                    
                    imageX *= printResolutionX;
                    imageY *= printResolutionY;

                    break;
                default:
                    throw new NotImplementedException();
            }
            transform.Translate(imageX, imageY);
            
            e.Graphics.PageUnit = GraphicsUnit.Pixel;

            // render PDF page on printer graphics 
            GraphicsFigureView.DrawFigureOnGraphics(
                new PdfPageGraphicsFigure(page), 
                new EmptyDrawingSurface(), 
                e.Graphics, 
                transform, 
                page);

            e.Graphics.Flush();

            _index++;
            e.HasMorePages = _index < _images.Count;
        }

        #endregion

    }
}
