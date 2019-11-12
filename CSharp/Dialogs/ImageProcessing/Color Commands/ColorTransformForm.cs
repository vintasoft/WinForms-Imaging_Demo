﻿using System;
using System.IO;
using System.Windows.Forms;

using Vintasoft.Imaging.ColorManagement;
using Vintasoft.Imaging.ColorManagement.Icc;
using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Color;
using Vintasoft.Imaging.UI;

using DemosCommonCode;


namespace ImagingDemo
{
    /// <summary>
    /// A form that allows to view and change settings for the color transform command.
    /// </summary>
    public partial class ColorTransformForm : ParamsConfigForm
    {

        #region Fields

        /// <summary>
        /// Color management decode settings.
        /// </summary>
        ColorManagementDecodeSettings _settings = new ColorManagementDecodeSettings();

        /// <summary>
        /// Image color space format.
        /// </summary>
        ColorSpaceFormat _imageColorSpaceFormat;

        #endregion



        #region Constructor

        public ColorTransformForm(ImageViewer viewer)
            : base(viewer)
        {
            InitializeComponent();

            _imageColorSpaceFormat = viewer.Image.ColorSpaceFormat;
            this.Text = String.Format("Color Transform ({0})", _imageColorSpaceFormat.ColorSpace);

            renderingIntentComboBox.Items.Add(RenderingIntent.Perceptual);
            renderingIntentComboBox.Items.Add(RenderingIntent.MediaRelativeColorimetric);
            renderingIntentComboBox.Items.Add(RenderingIntent.Saturation);
            renderingIntentComboBox.Items.Add(RenderingIntent.IccAbsoluteColorimetric);

            openFileDialog1.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            useBlackPointCompensationCheckBox.Checked = _settings.UseBlackPointCompensation;
            renderingIntentComboBox.SelectedItem = _settings.RenderingIntent;

            UseCurrentViewerZoomWhenPreviewProcessing = true;
            previewCheckBox.Checked = base.IsPreviewEnabled;
        }

        #endregion



        #region Methods

        /// <summary>
        /// Gets the current image processing command.
        /// </summary>
        /// <returns>Current image processing command.</returns>
        public override ProcessingCommandBase GetProcessingCommand()
        {
            ColorTransformCommand command = new ColorTransformCommand();
            _settings.ConstructThreadSafeColorTransforms = true;
            command.ColorTransform = _settings.GetColorTransform(_imageColorSpaceFormat, _imageColorSpaceFormat);
            return command;
        }

        /// <summary>
        /// Sets an input ICC profile.
        /// </summary>
        private void inputProfileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                openFileDialog1.InitialDirectory = Path.GetDirectoryName(filePath);

                IccProfile iccProfile = new IccProfile(filePath);
                IccProfile oldProfile = null;

                if (iccProfile.DeviceColorSpace != _imageColorSpaceFormat.ColorSpace)
                {
                    DemosTools.ShowErrorMessage(string.Format("Unexpected profile color space: {0}.\nRequired profile color space: {1}.",
                        iccProfile.DeviceColorSpace, _imageColorSpaceFormat.ColorSpace));
                    oldProfile = iccProfile;
                }
                else
                {
                    if (iccProfile.DeviceColorSpace == ColorSpaceType.sRGB)
                    {
                        oldProfile = _settings.InputRgbProfile;
                        _settings.InputRgbProfile = iccProfile;
                    }
                    else
                    {
                        oldProfile = _settings.InputGrayscaleProfile;
                        _settings.InputGrayscaleProfile = iccProfile;
                    }
                    ExecuteProcessing();
                }

                if (iccProfile != oldProfile)
                    inputProfileTextBox.Text = filePath;

                if (oldProfile != null)
                    oldProfile.Dispose();
            }
        }

        /// <summary>
        /// Sets an output ICC profile.
        /// </summary>
        private void outputProfileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                openFileDialog1.InitialDirectory = Path.GetDirectoryName(filePath);

                IccProfile iccProfile = new IccProfile(filePath);
                IccProfile oldProfile = null;

                if (iccProfile.DeviceColorSpace != _imageColorSpaceFormat.ColorSpace)
                {
                    DemosTools.ShowErrorMessage(string.Format("Unexpected profile color space: {0}.\nRequired profile color space: {1}.",
                        iccProfile.DeviceColorSpace, _imageColorSpaceFormat.ColorSpace));
                    oldProfile = iccProfile;
                }
                else
                {
                    if (iccProfile.DeviceColorSpace == ColorSpaceType.sRGB)
                    {
                        oldProfile = _settings.InputRgbProfile;
                        _settings.OutputRgbProfile = iccProfile;
                    }
                    else
                    {
                        oldProfile = _settings.InputGrayscaleProfile;
                        _settings.OutputGrayscaleProfile = iccProfile;
                    }
                    ExecuteProcessing();
                }

                if (iccProfile != oldProfile)
                    outputProfileTextBox.Text = filePath;

                if (oldProfile != null)
                    oldProfile.Dispose();
            }
        }

        /// <summary>
        /// Removes an input ICC profile.
        /// </summary>
        private void removeInputProfileButton_Click(object sender, EventArgs e)
        {
            IccProfile profile = null;
            if (_settings.InputRgbProfile != null)
            {
                profile = _settings.InputRgbProfile;
                _settings.InputRgbProfile = null;
            }
            else if (_settings.InputGrayscaleProfile != null)
            {
                profile = _settings.InputGrayscaleProfile;
                _settings.InputGrayscaleProfile = null;
            }
            if (profile != null)
                profile.Dispose();

            inputProfileTextBox.Text = string.Empty;
            ExecuteProcessing();
        }

        /// <summary>
        /// Removes an output ICC profile.
        /// </summary>
        private void removeOutputProfileButton_Click(object sender, EventArgs e)
        {
            IccProfile profile = null;
            if (_settings.OutputRgbProfile != null)
            {
                profile = _settings.OutputRgbProfile;
                _settings.OutputRgbProfile = null;
            }
            else if (_settings.OutputGrayscaleProfile != null)
            {
                profile = _settings.OutputGrayscaleProfile;
                _settings.OutputGrayscaleProfile = null;
            }
            if (profile != null)
                profile.Dispose();

            outputProfileTextBox.Text = string.Empty;
            ExecuteProcessing();
        }

        private void previewCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            IsPreviewEnabled = previewCheckBox.Checked;
        }

        private void renderingIntentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _settings.RenderingIntent = (RenderingIntent)renderingIntentComboBox.SelectedItem;
            ExecuteProcessing();
        }

        private void useBlackPointCompensationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _settings.UseBlackPointCompensation = useBlackPointCompensationCheckBox.Checked;
            ExecuteProcessing();
        }

        #endregion

    }
}