using System;
using System.Collections.Generic;
using System.Drawing;

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
        /// <param name="viewer">The image viewer for image preview.</param>
        public ColorNoiseClearForm(ImageViewer viewer)
            : base(viewer)
        {
            InitializeComponent();

            previewCheckBox.Checked = base.IsPreviewEnabled;
            UseCurrentViewerZoomWhenPreviewProcessing = true;
        }

        #endregion



        #region Methods

        #region PUBLIC

#if !REMOVE_DOCCLEANUP_PLUGIN
        /// <summary> 
        /// Returns the image processing command.
        /// </summary>
        /// <returns>The image processing command.</returns>
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
        #endregion


        #region PRIVATE

        #region UI

        /// <summary>
        /// Handles the CheckedChanged event of ColorCheckBox object.
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
        /// Handles the Scroll event of WhiteTrackBar object.
        /// </summary>
        private void whiteTrackBar_Scroll(object sender, EventArgs e)
        {
            whiteLabel.Text = whiteTrackBar.Value.ToString();
            ExecuteProcessing();
        }

        /// <summary>
        /// Handles the Scroll event of BlackTrackBar object.
        /// </summary>
        private void blackTrackBar_Scroll(object sender, EventArgs e)
        {
            blackLabel.Text = blackTrackBar.Value.ToString();
            ExecuteProcessing();
        }

        /// <summary>
        /// Handles the Scroll event of RedTrackBar object.
        /// </summary>
        private void redTrackBar_Scroll(object sender, EventArgs e)
        {
            redLabel.Text = redTrackBar.Value.ToString();
            ExecuteProcessing();
        }

        /// <summary>
        /// Handles the Scroll event of GreenTrackBar object.
        /// </summary>
        private void greenTrackBar_Scroll(object sender, EventArgs e)
        {
            greenLabel.Text = greenTrackBar.Value.ToString();
            ExecuteProcessing();
        }

        /// <summary>
        /// Handles the Scroll event of BlueTrackBar object.
        /// </summary>
        private void blueTrackBar_Scroll(object sender, EventArgs e)
        {
            blueLabel.Text = blueTrackBar.Value.ToString();
            ExecuteProcessing();
        }

        /// <summary>
        /// Handles the Scroll event of CyanTrackBar object.
        /// </summary>
        private void cyanTrackBar_Scroll(object sender, EventArgs e)
        {
            cyanLabel.Text = cyanTrackBar.Value.ToString();
            ExecuteProcessing();
        }

        /// <summary>
        /// Handles the Scroll event of MagentaTrackBar object.
        /// </summary>
        private void magentaTrackBar_Scroll(object sender, EventArgs e)
        {
            magentaLabel.Text = magentaTrackBar.Value.ToString();
            ExecuteProcessing();
        }

        /// <summary>
        /// Handles the Scroll event of YellowTrackBar object.
        /// </summary>
        private void yellowTrackBar_Scroll(object sender, EventArgs e)
        {
            yellowLabel.Text = yellowTrackBar.Value.ToString();
            ExecuteProcessing();
        }

        /// <summary>
        /// Handles the Scroll event of InterpolationTrackBar object.
        /// </summary>
        private void interpolationTrackBar_Scroll(object sender, EventArgs e)
        {
            double interpolation = interpolationTrackBar.Value / (double)interpolationTrackBar.Maximum;
            interpolationLabel.Text = interpolation.ToString("0.00");
            ExecuteProcessing();
        }

        /// <summary>
        /// Handles the CheckedChanged event of PreviewCheckBox object.
        /// </summary>
        private void previewCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            IsPreviewEnabled = previewCheckBox.Checked;
        }

        #endregion

        #endregion

        #endregion

    }
}
