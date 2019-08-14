using System;
using System.Drawing;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.ImageColors;
using DemosCommonCode;
using DemosCommonCode.Imaging;
using Vintasoft.Imaging.UI;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to get direct access to an image pixels.
    /// </summary>
    public partial class DirectPixelAccessForm : Form
    {

        #region Fields

        ColorBase _selectedColor;
        int _selectedColorX;
        int _selectedColorY;
        bool _pixelSelect = false;
        ImageViewer _viewer;

        #endregion



        #region Constructors

        public DirectPixelAccessForm(ImageViewer viewer)
        {
            InitializeComponent();

            _viewer = viewer;
            _viewer.MouseMove += new MouseEventHandler(viewer_MouseMove);
            _viewer.MouseDown += new MouseEventHandler(viewer_MouseDown);
        }

        #endregion



        #region Methods

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            _viewer.MouseMove -= viewer_MouseMove;
            _viewer.MouseDown -= viewer_MouseDown;
        }

        // Updates information about selected pixel.
        void viewer_MouseDown(object sender, MouseEventArgs e)
        {
            if (pixelsGroupBox.Enabled && _viewer.IsEntireImageLoaded)
            {
                if (_viewer.FocusedIndex >= 0)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        Point pt = _viewer.PointToImage(e.Location);
                        SelectPixel(pt.X, pt.Y);
                    }
                }
            }
        }

        // Updates information about focused pixel.
        void viewer_MouseMove(object sender, MouseEventArgs e)
        {
            if (_viewer.FocusedIndex >= 0)
            {
                Point pt = _viewer.PointToImage(e.Location);
                string text = string.Format("Pixel (X={0},Y={1})", pt.X, pt.Y);
                if (text != pixelsGroupBox.Text)
                {
                    pixelsGroupBox.Text = text;
                    if (e.Button == MouseButtons.Left && pixelsGroupBox.Enabled && _viewer.IsEntireImageLoaded)
                    {
                        SelectPixel(pt.X, pt.Y);
                    }
                }
            }
            else
            {
                pixelsGroupBox.Text = string.Format("Pixel");
            }
        }
       

        internal void SelectPixel(int x, int y)
        {
            if (x >= 0 && y >= 0)
            {
                VintasoftImage image = _viewer.Image;
                if (x < image.Width && y < image.Height)
                {
                    try
                    {
                        ColorBase pixelColor = _viewer.Image.GetPixelColor(x, y);
                        ShowSelectedPixelColor(x, y, pixelColor);
                    }
                    catch (Exception e)
                    {
                        DemosTools.ShowErrorMessage(e);
                    }
                    return;
                }
            }
            selectedPixelLabel.Text = "Selected Pixel: click on image to select";
            argbPanel.Visible = false;
            indexedPanel.Visible = false;
            gray16Panel.Visible = false;
            selectedPixelColorPanel.BackColor = Color.Transparent;
        }

        private void selectInPaletteButton_Click(object sender, EventArgs e)
        {
            PaletteForm paletteDlg = new PaletteForm();
            paletteDlg.PaletteViewer.CanChangePalette = false;
            IndexedColor indColor = ((IndexedColor)_selectedColor);
            paletteDlg.PaletteViewer.Palette = indColor.Palette;
            paletteDlg.PaletteViewer.SelectedColorIndex = indColor.Index;
            if (paletteDlg.ShowDialog() == DialogResult.OK)
            {
                indexNumericUpDown.Value = (int)paletteDlg.PaletteViewer.SelectedColorIndex;
                ShowSelectedPixelColor(_selectedColorX, _selectedColorY, new IndexedColor(paletteDlg.PaletteViewer.Palette, paletteDlg.PaletteViewer.SelectedColorIndex));
                SetColorOfSelectedPixel();
            }
        }

        private void UpdateSelectedPixelColorValue(int alpha, int red, int green, int blue, bool isNativeValues)
        {
            byte alpha8 = (byte)alpha;
            byte red8 = (byte)red;
            byte green8 = (byte)green;
            byte blue8 = (byte)blue;
            if (isNativeValues)
            {
                // create color
                if (_selectedColor is Argb32Color)
                    _selectedColor = new Argb32Color(alpha8, red8, green8, blue8);
                else if (_selectedColor is Rgb24Color)
                    _selectedColor = new Rgb24Color(red8, green8, blue8);
                else if (_selectedColor is Rgb16Color555)
                    _selectedColor = new Rgb16Color555(red8, green8, blue8);
                else if (_selectedColor is Rgb16Color565)
                    _selectedColor = new Rgb16Color565(red8, green8, blue8);
                else if (_selectedColor is Argb64Color)
                    _selectedColor = new Argb64Color(alpha, red, green, blue);
                else if (_selectedColor is Rgb48Color)
                    _selectedColor = new Rgb48Color(red, green, blue);
                else
                    _selectedColor = new Rgb24Color(red8, green8, blue8);
            }
            else
            {
                // convert from 8-bit per color to dest color depth and create color
                if (_selectedColor is Argb32Color)
                    _selectedColor = new Argb32Color(alpha8, red8, green8, blue8);
                else if (_selectedColor is Rgb24Color)
                    _selectedColor = new Rgb24Color(red8, green8, blue8);
                else if (_selectedColor is Rgb16Color555)
                    _selectedColor = new Rgb16Color555(new Rgb24Color(red8, green8, blue8));
                else if (_selectedColor is Rgb16Color565)
                    _selectedColor = new Rgb16Color565(new Rgb24Color(red8, green8, blue8));
                else if (_selectedColor is Argb64Color)
                    _selectedColor = new Argb64Color(new Argb32Color(alpha8, red8, green8, blue8));
                else if (_selectedColor is Rgb48Color)
                    _selectedColor = new Rgb48Color(new Rgb24Color(red8, green8, blue8));
                else
                    _selectedColor = new Rgb24Color(red8, green8, blue8);
            }
        }

        private void changeRGBComponentsButton_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = _selectedColor.ToColor();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Color newColor = dialog.Color;
                UpdateSelectedPixelColorValue((int)alphaNumericUpDown.Value, newColor.R, newColor.G, newColor.B, false);

                ShowSelectedPixelColor(
                    _selectedColorX,
                    _selectedColorY,
                    _selectedColor);

                SetColorOfSelectedPixel();
            }
        }

        private void ShowSelectedPixelColor(int x, int y, ColorBase pixelColor)
        {
            VintasoftImage image = _viewer.Image;
            _selectedColorX = x;
            _selectedColorY = y;
            _selectedColor = pixelColor;
            selectedPixelLabel.Text = string.Format("Selected Pixel: X={0},Y={1}; ColorType={2}", x, y, pixelColor.GetType().Name);
            _pixelSelect = true;
            if (pixelColor is Rgb24Color)
            {
                Rgb24Color rgbColor = (Rgb24Color)pixelColor;
                argbPanel.Visible = true;
                indexedPanel.Visible = false;
                gray16Panel.Visible = false;
                redNumericUpDown.Maximum = 255;
                redNumericUpDown.Value = rgbColor.Red;
                greenNumericUpDown.Maximum = 255;
                greenNumericUpDown.Value = rgbColor.Green;
                blueNumericUpDown.Maximum = 255;
                blueNumericUpDown.Value = rgbColor.Blue;
                if (pixelColor is Argb32Color)
                {
                    alphaNumericUpDown.Maximum = 255;
                    alphaNumericUpDown.Value = ((Argb32Color)pixelColor).Alpha;
                    alphaNumericUpDown.Visible = true;
                    rgbColorTypeLabel.Text = "ARGB32 =";
                }
                else
                {
                    alphaNumericUpDown.Visible = false;
                    rgbColorTypeLabel.Text = "RGB (24bpp) =";
                }
            }
            else if (pixelColor is Rgb48Color)
            {
                Rgb48Color rgb48Color = (Rgb48Color)pixelColor;
                argbPanel.Visible = true;
                indexedPanel.Visible = false;
                gray16Panel.Visible = false;
                redNumericUpDown.Maximum = 65535;
                redNumericUpDown.Value = rgb48Color.Red;
                greenNumericUpDown.Maximum = 65535;
                greenNumericUpDown.Value = rgb48Color.Green;
                blueNumericUpDown.Maximum = 65535;
                blueNumericUpDown.Value = rgb48Color.Blue;
                if (pixelColor is Argb64Color)
                {
                    alphaNumericUpDown.Maximum = 65535;
                    alphaNumericUpDown.Value = ((Argb64Color)pixelColor).Alpha;
                    alphaNumericUpDown.Visible = true;
                    rgbColorTypeLabel.Text = "ARGB64 =";
                }
                else
                {
                    alphaNumericUpDown.Visible = false;
                    rgbColorTypeLabel.Text = "RGB (48bpp) =";
                }
            }
            else if (pixelColor is Rgb16ColorBase)
            {
                Rgb16ColorBase rgb16Color = (Rgb16ColorBase)pixelColor;
                argbPanel.Visible = true;
                indexedPanel.Visible = false;
                gray16Panel.Visible = false;
                redNumericUpDown.Maximum = 31;
                redNumericUpDown.Value = rgb16Color.Red;
                blueNumericUpDown.Maximum = 31;
                blueNumericUpDown.Value = rgb16Color.Blue;
                alphaNumericUpDown.Visible = false;
                if (pixelColor is Rgb16Color555)
                {
                    greenNumericUpDown.Maximum = 31;
                    rgbColorTypeLabel.Text = "RGB16 (5-5-5) =";
                }
                else
                {
                    greenNumericUpDown.Maximum = 63;
                    rgbColorTypeLabel.Text = "RGB16 (5-6-5) =";
                }
                greenNumericUpDown.Value = rgb16Color.Green;
            }
            else if (pixelColor is IndexedColor)
            {
                IndexedColor indexedColor = (IndexedColor)pixelColor;
                argbPanel.Visible = false;
                indexedPanel.Visible = true;
                gray16Panel.Visible = false;
                indexNumericUpDown.Maximum = indexedColor.Palette.ColorCount - 1;
                indexNumericUpDown.Value = indexedColor.Index;
            }
            else if (pixelColor is Gray16Color)
            {
                Gray16Color gray16 = (Gray16Color)pixelColor;
                argbPanel.Visible = false;
                indexedPanel.Visible = false;
                gray16Panel.Visible = true;
                gray16LumNumericUpDown.Value = gray16.Luminance;
            }
            selectedPixelColorPanel.BackColor = pixelColor.ToColor();
            _pixelSelect = false;
            pixelsGroupBox.Refresh();
        }

        private void SetColorOfSelectedPixel()
        {
            try
            {
                _viewer.Image.SetPixelColor(_selectedColorX, _selectedColorY, _selectedColor);
            }
            catch (Exception e)
            {
                DemosTools.ShowErrorMessage(e);
            }
        }

        private void colorChannel_ValueChanged(object sender, EventArgs e)
        {
            if (!_pixelSelect)
            {
                UpdateSelectedPixelColorValue(
                    (int)alphaNumericUpDown.Value,
                    (int)redNumericUpDown.Value,
                    (int)greenNumericUpDown.Value,
                    (int)blueNumericUpDown.Value,
                    true);
                selectedPixelColorPanel.BackColor = _selectedColor.ToColor();
                SetColorOfSelectedPixel();
            }
        }

        private void indexNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!_pixelSelect)
            {
                _selectedColor = new IndexedColor(_viewer.Image.Palette, (byte)indexNumericUpDown.Value);
                selectedPixelColorPanel.BackColor = _selectedColor.ToColor();
                SetColorOfSelectedPixel();
            }
        }

        private void gray16LumNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!_pixelSelect)
            {
                _selectedColor = new Gray16Color((int)gray16LumNumericUpDown.Value);
                selectedPixelColorPanel.BackColor = _selectedColor.ToColor();
                SetColorOfSelectedPixel();
            }
        }

        #endregion

    }
}
