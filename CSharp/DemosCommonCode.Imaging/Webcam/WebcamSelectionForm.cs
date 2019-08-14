using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;

using Vintasoft.Imaging.Media;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A form that allows to select the webcam from webcam list.
    /// </summary>
    public partial class WebcamSelectionForm : Form
    {

        #region Constructor

        public WebcamSelectionForm()
        {
            InitializeComponent();

            ReadOnlyCollection<ImageCaptureDevice> devices = ImageCaptureDeviceConfiguration.GetCaptureDevices();
            foreach (ImageCaptureDevice device in devices)
                devicesComboBox.Items.Add(device);

            if (devices.Count > 0)
                devicesComboBox.SelectedIndex = 0;
        }

        #endregion



        #region Properties

        public ImageCaptureDevice SelectedWebcam
        {
            get
            {
                return (ImageCaptureDevice)devicesComboBox.SelectedItem;
            }
            set
            {
                if (value != null)
                {
                    devicesComboBox.SelectedItem = value;
                }
            }
        }

        public ImageCaptureFormat SelectedFormat
        {
            get
            {
                return (ImageCaptureFormat)videoFormatComboBox.SelectedItem;
            }
        }

        public bool CanSelectFormat
        {
            get
            {
                return videoFormatLabel.Visible;
            }
            set
            {
                videoFormatLabel.Visible = value;
                videoFormatComboBox.Visible = value;
            }
        }

        #endregion



        #region Methods

        public static ImageCaptureDevice SelectWebcam()
        {
            ReadOnlyCollection<ImageCaptureDevice> devices = ImageCaptureDeviceConfiguration.GetCaptureDevices();
            if (devices.Count == 0)
                throw new Exception("Webcam is not found.");
            if (devices.Count == 1)
                return devices[0];

            using (WebcamSelectionForm dialog = new WebcamSelectionForm())
            {
                dialog.CanSelectFormat = false;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return dialog.SelectedWebcam;
                }
                return null;
            }
        }

        private void devicesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            videoFormatComboBox.Items.Clear();

            if (SelectedWebcam != null)
            {
                List<uint> imageCaptureFormatSizes = new List<uint>();
                for (int i = 0; i < SelectedWebcam.SupportedFormats.Count; i++)
                {
                    // if format has bit depth less or equal than 12 bit
                    if (SelectedWebcam.SupportedFormats[i].BitsPerPixel <= 12)
                        // ignore formats with bit depth less or equal than 12 bit because they may cause issues on Windows 8
                        continue;

                    uint imageCaptureFormatSize = (uint)(SelectedWebcam.SupportedFormats[i].Width | (SelectedWebcam.SupportedFormats[i].Height << 16));
                    if (!imageCaptureFormatSizes.Contains(imageCaptureFormatSize))
                    {
                        imageCaptureFormatSizes.Add(imageCaptureFormatSize);

                        videoFormatComboBox.Items.Add(SelectedWebcam.SupportedFormats[i]);
                    }
                }

                if (SelectedWebcam.DesiredFormat != null && videoFormatComboBox.Items.Contains(SelectedWebcam.DesiredFormat))
                    videoFormatComboBox.SelectedItem = SelectedWebcam.DesiredFormat;
                else
                    videoFormatComboBox.SelectedIndex = -1;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        #endregion

    }
}
