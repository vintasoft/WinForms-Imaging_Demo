using System;
using System.Windows.Forms;

using Vintasoft.Imaging;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to display an image animation.
    /// </summary>
    public partial class ShowAnimationForm : Form
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ShowAnimationForm"/> class.
        /// </summary>
        /// <param name="images">The images that make up the animation.</param>
        public ShowAnimationForm(ImageCollection images)
        {
            InitializeComponent();

            animatedImageViewer1.Images.AddRange(images.ToArray());
            animatedImageViewer1.FocusedIndex = 0;
            animatedImageViewer1.Animation = true;
            animatedImageViewer1.DefaultDelay = (int)defaultDelayNumericUpDown.Value;
            animatedImageViewer1.DisableAutoScrollToFocusedImage();

            stopButton.Enabled = true;
            startButton.Enabled = false;
        }

        #endregion



        #region Methods

        #region UI

        /// <summary>
        /// Handles the ValueChanged event of defaultDelayNumericUpDown object.
        /// </summary>
        private void defaultDelayNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            animatedImageViewer1.DefaultDelay = (int)defaultDelayNumericUpDown.Value;
        }

        /// <summary>
        /// Handles the Click event of startButton object.
        /// </summary>
        private void startButton_Click(object sender, EventArgs e)
        {
            animatedImageViewer1.Animation = true;

            stopButton.Enabled = true;
            startButton.Enabled = false;
        }

        /// <summary>
        /// Handles the Click event of stropButton object.
        /// </summary>
        private void stropButton_Click(object sender, EventArgs e)
        {
            animatedImageViewer1.Animation = false;

            startButton.Enabled = true;
            stopButton.Enabled = false;
        }

        /// <summary>
        /// Handles the FormClosed event of ShowAnimationForm object.
        /// </summary>
        private void ShowAnimationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            animatedImageViewer1.Animation = false;
        }

        #endregion

        #endregion

    }
}
