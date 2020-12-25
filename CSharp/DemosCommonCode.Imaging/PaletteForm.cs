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

        /// <summary>
        /// A value indicating whether the selected color is updating.
        /// </summary>
        bool _isUpdatingSelectedColor = false;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PaletteForm"/> class.
        /// </summary>
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

        #region UI

        /// <summary>
        /// Handles the SelectedColorChanged event of PaletteViewer object.
        /// </summary>
        private void PaletteViewer_SelectedColorChanged(object sender, EventArgs e)
        {
            // update selected color
            UpdateSelectedColor();
        }

        /// <summary>
        /// Handles the Click event of InvertButton object.
        /// </summary>
        private void invertButton_Click(object sender, EventArgs e)
        {
            // invert the current palette
            PaletteViewer.Palette.Invert();
            // update selected color
            UpdateSelectedColor();
        }

        /// <summary>
        /// Handles the Click event of ToGrayButton object.
        /// </summary>
        private void toGrayButton_Click(object sender, EventArgs e)
        {
            // convert the current palette to gray palette
            PaletteViewer.Palette.ConvertToGrayColors();
            // update selected color
            UpdateSelectedColor();
        }

        #endregion


        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Shown" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            // if palette can not be changed
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
            // update selected color
            UpdateSelectedColor();
        }

        /// <summary>
        /// Updates the selected color.
        /// </summary>
        private void UpdateSelectedColor()
        {
            Color selectedColor = PaletteViewer.SelectedColor;
            _isUpdatingSelectedColor = true;
            alphaNumericUpDown.Value = selectedColor.A;
            redNumericUpDown.Value = selectedColor.R;
            greenNumericUpDown.Value = selectedColor.G;
            blueNumericUpDown.Value = selectedColor.B;
            colorIndexNumericUpDown.Value = PaletteViewer.SelectedColorIndex;
            _isUpdatingSelectedColor = false;
            UpdateTitle();
        }

        /// <summary>
        /// Updates the form title.
        /// </summary>
        private void UpdateTitle()
        {
            Color selectedColor = PaletteViewer.SelectedColor;
            Text = string.Format("Palette: Selected index = {0}; RGB({1},{2},{3})",
                PaletteViewer.SelectedColorIndex,
                selectedColor.R,
                selectedColor.G,
                selectedColor.B);
        }

        /// <summary>
        /// Changes the selected color value.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void colorNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            // if selected color is updating
            if (_isUpdatingSelectedColor)
                return;

            // create color
            Color selectedColor = Color.FromArgb(
                (int)redNumericUpDown.Value,
                (int)greenNumericUpDown.Value,
                (int)blueNumericUpDown.Value);
            // create color with alpha channel
            selectedColor = Color.FromArgb((int)alphaNumericUpDown.Value, selectedColor);

            // update selected color
            PaletteViewer.SelectedColor = selectedColor;
        }

        /// <summary>
        /// Changes the selected color.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void colorIndexNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (_isUpdatingSelectedColor)
                return;

            // update selected color index
            PaletteViewer.SelectedColorIndex = (byte)colorIndexNumericUpDown.Value;
        }

        #endregion

    }
}
