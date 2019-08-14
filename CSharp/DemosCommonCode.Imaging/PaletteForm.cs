using System;
using System.Drawing;
using System.Windows.Forms;
using Vintasoft.Imaging.UI;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A form that allows to view and edit an image palette.
    /// </summary>
    public partial class PaletteForm : Form
    {

        #region Fields

        bool _showingColor = false;

        #endregion



        #region Constructor

        public PaletteForm()
        {
            InitializeComponent();
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets the <see cref="PaletteViewer"/>.
        /// </summary>
        public PaletteViewer PaletteViewer
        {
            get
            {
                return paletteViewer1;
            }
        }

        /// <summary>
        /// Gets value indicating whether the <see cref="PaletteViewer"/> can change palette.
        /// </summary>
        public bool CanChangePalette
        {
            get
            {
                return PaletteViewer.CanChangePalette;
            }
            set
            {
                PaletteViewer.CanChangePalette = value;
                toGrayButton.Visible = value;
                invertButton.Visible = value;
            }
        }

        #endregion



        #region Methods

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (!PaletteViewer.CanChangePalette)
            {
                toGrayButton.Visible = false;
                invertButton.Visible = false;
                alphaNumericUpDown.Enabled = false;
                redNumericUpDown.Enabled = false;
                greenNumericUpDown.Enabled = false;
                blueNumericUpDown.Enabled = false;

            }
            colorIndexNumericUpDown.Maximum = PaletteViewer.Palette.ColorCount - 1;
            UpdateColor();
        }

        private void PaletteViewer_SelectedColorChanged(object sender, EventArgs e)
        {
            UpdateColor();
        }

        private void UpdateColor()
        {
            Color selectedColor = PaletteViewer.SelectedColor;
            _showingColor = true;
            alphaNumericUpDown.Value = selectedColor.A;
            redNumericUpDown.Value = selectedColor.R;
            greenNumericUpDown.Value = selectedColor.G;
            blueNumericUpDown.Value = selectedColor.B;
            colorIndexNumericUpDown.Value = PaletteViewer.SelectedColorIndex;
            _showingColor = false;
            UpdateTitle();
        }

        private void UpdateTitle()
        {
            Color selectedColor = PaletteViewer.SelectedColor;
            Text = string.Format("Palette: Selected index = {0}; RGB({1},{2},{3})",
                PaletteViewer.SelectedColorIndex,
                selectedColor.R,
                selectedColor.G,
                selectedColor.B);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void invertButton_Click(object sender, EventArgs e)
        {
            PaletteViewer.Palette.Invert();
            UpdateColor();
        }

        private void toGrayButton_Click(object sender, EventArgs e)
        {
            PaletteViewer.Palette.ConvertToGrayColors();
            UpdateColor();
        }

        private void colorNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!_showingColor)
            {
                Color selectedColor = Color.FromArgb(
                    (int)redNumericUpDown.Value,
                    (int)greenNumericUpDown.Value,
                    (int)blueNumericUpDown.Value);
                selectedColor = Color.FromArgb((int)alphaNumericUpDown.Value, selectedColor);
                PaletteViewer.SelectedColor = selectedColor;
            }
        }

        private void colorIndexNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!_showingColor)
            {
                PaletteViewer.SelectedColorIndex = (byte)colorIndexNumericUpDown.Value;
            }
        }

        #endregion

    }
}
