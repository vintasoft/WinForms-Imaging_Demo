using System;
using System.Collections.Generic;
using System.Drawing;

using Vintasoft.Imaging;
using Vintasoft.Imaging.ImageColors;
using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Document;
using Vintasoft.Imaging.UI;


namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and edit settings of the ColorNoiseClearCommand.
    /// </summary>
    public partial class ColorNoiseClearForm : ParamsConfigForm
    {

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorNoiseClearForm"/> class.
        /// </summary>
        public ColorNoiseClearForm(ImageViewer viewer)
            : base(viewer)
        {
            InitializeComponent();

            previewCheckBox.Checked = base.IsPreviewEnabled;
            UseCurrentViewerZoomWhenPreviewProcessing = true;
        }

        #endregion



        #region Methods

#if !REMOVE_DOCCLEANUP_PLUGIN
        /// <summary> 
        /// Returns the current image processing command.
        /// </summary>
        /// <returns>Current image processing command.</returns>
        public override ProcessingCommandBase GetProcessingCommand()
        {
            ColorNoiseClearCommand command = new ColorNoiseClearCommand();
            command.InterpolationRadius = 1.0 - interpolationTrackBar.Value / (double)interpolationTrackBar.Maximum;

            List<ColorSphere> colorSpheres = new List<ColorSphere>();
            if (whiteCheckBox.Checked)
                colorSpheres.Add(new ColorSphere(new Rgb24Color(Color.White), whiteTrackBar.Value));
            if (blackCheckBox.Checked)
                colorSpheres.Add(new ColorSphere(new Rgb24Color(Color.Black), blackTrackBar.Value));
            if (redCheckBox.Checked)
                colorSpheres.Add(new ColorSphere(new Rgb24Color(Color.Red), redTrackBar.Value));
            if (greenCheckBox.Checked)
                colorSpheres.Add(new ColorSphere(new Rgb24Color(Color.Green), greenTrackBar.Value));
            if (blueCheckBox.Checked)
                colorSpheres.Add(new ColorSphere(new Rgb24Color(Color.Blue), blueTrackBar.Value));
            if (cyanCheckBox.Checked)
                colorSpheres.Add(new ColorSphere(new Rgb24Color(Color.Cyan), cyanTrackBar.Value));
            if (magentaCheckBox.Checked)
                colorSpheres.Add(new ColorSphere(new Rgb24Color(Color.Magenta), magentaTrackBar.Value));
            if (yellowCheckBox.Checked)
                colorSpheres.Add(new ColorSphere(new Rgb24Color(Color.Yellow), yellowTrackBar.Value));

            if (colorSpheres.Count == 0)
                colorSpheres.Add(new ColorSphere(new Rgb24Color(Color.White), 0));

            command.ColorSpheres = colorSpheres.ToArray();
            return command;
        }
#endif

        /// <summary>
        /// The color noise removal is enabled/disabled.
        /// </summary>
        private void colorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            whiteTrackBar.Enabled = whiteCheckBox.Checked;
            blackTrackBar.Enabled = blackCheckBox.Checked;
            redTrackBar.Enabled = redCheckBox.Checked;
            greenTrackBar.Enabled = greenCheckBox.Checked;
            blueTrackBar.Enabled = blueCheckBox.Checked;
            cyanTrackBar.Enabled = cyanCheckBox.Checked;
            magentaTrackBar.Enabled = magentaCheckBox.Checked;
            yellowTrackBar.Enabled = yellowCheckBox.Checked;
            ExecuteProcessing();
        }

        /// <summary>
        /// Radius of white sphere is changed.
        /// </summary>
        private void whiteTrackBar_Scroll(object sender, EventArgs e)
        {
            whiteLabel.Text = whiteTrackBar.Value.ToString();
            ExecuteProcessing();
        }

        /// <summary>
        /// Radius of black sphere is changed.
        /// </summary>
        private void blackTrackBar_Scroll(object sender, EventArgs e)
        {
            blackLabel.Text = blackTrackBar.Value.ToString();
            ExecuteProcessing();
        }

        /// <summary>
        /// Radius of red sphere is changed.
        /// </summary>
        private void redTrackBar_Scroll(object sender, EventArgs e)
        {
            redLabel.Text = redTrackBar.Value.ToString();
            ExecuteProcessing();
        }

        /// <summary>
        /// Radius of green sphere is changed.
        /// </summary>
        private void greenTrackBar_Scroll(object sender, EventArgs e)
        {
            greenLabel.Text = greenTrackBar.Value.ToString();
            ExecuteProcessing();
        }

        /// <summary>
        /// Radius of blue sphere is changed.
        /// </summary>
        private void blueTrackBar_Scroll(object sender, EventArgs e)
        {
            blueLabel.Text = blueTrackBar.Value.ToString();
            ExecuteProcessing();
        }

        /// <summary>
        /// Radius of cyan sphere is changed.
        /// </summary>
        private void cyanTrackBar_Scroll(object sender, EventArgs e)
        {
            cyanLabel.Text = cyanTrackBar.Value.ToString();
            ExecuteProcessing();
        }

        /// <summary>
        /// Radius of magenta sphere is changed.
        /// </summary>
        private void magentaTrackBar_Scroll(object sender, EventArgs e)
        {
            magentaLabel.Text = magentaTrackBar.Value.ToString();
            ExecuteProcessing();
        }

        /// <summary>
        /// Radius of yellow sphere is changed.
        /// </summary>
        private void yellowTrackBar_Scroll(object sender, EventArgs e)
        {
            yellowLabel.Text = yellowTrackBar.Value.ToString();
            ExecuteProcessing();
        }

        /// <summary>
        /// Interpolation radius is changed.
        /// </summary>
        private void interpolationTrackBar_Scroll(object sender, EventArgs e)
        {
            double interpolation = interpolationTrackBar.Value / (double)interpolationTrackBar.Maximum;
            interpolationLabel.Text = interpolation.ToString("0.00");
            ExecuteProcessing();
        }

        /// <summary>
        /// Image processing preview on image viewer is enabled/disabled.
        /// </summary>
        private void previewCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            IsPreviewEnabled = previewCheckBox.Checked;
        }

        #endregion

    }
}