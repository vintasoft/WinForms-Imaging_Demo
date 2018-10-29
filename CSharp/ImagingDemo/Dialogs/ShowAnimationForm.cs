using System;
using System.Windows.Forms;

using Vintasoft.Imaging;

namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to display an animation.
    /// </summary>
    public partial class ShowAnimationForm : Form
    {

        public ShowAnimationForm(ImageCollection images)
        {
            InitializeComponent();

            animatedImageViewer1.Images.AddRange(images.ToArray());
            animatedImageViewer1.FocusedIndex = 0;
            animatedImageViewer1.Animation = true;
            animatedImageViewer1.DefaultDelay = (int)defaultDelayNumericUpDown.Value;

            stopButton.Enabled = true;
            startButton.Enabled = false;
        }



        private void defaultDelayNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            animatedImageViewer1.DefaultDelay = (int)defaultDelayNumericUpDown.Value;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            animatedImageViewer1.Animation = true;

            stopButton.Enabled = true;
            startButton.Enabled = false;
        }

        private void stropButton_Click(object sender, EventArgs e)
        {
            animatedImageViewer1.Animation = false;

            startButton.Enabled = true;
            stopButton.Enabled = false;
        }

        private void ShowAnimationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            animatedImageViewer1.Animation = false;
        }

    }
}
