using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Color;
using Vintasoft.Imaging.ImageProcessing.Transforms;
using Vintasoft.Imaging.Media;
using Vintasoft.Imaging.UI;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A form that allows to preview image from webcam, change webcam settings and
    /// process the captured images.
    /// </summary>
    public partial class WebcamPreviewForm : Form
    {

        #region Fields

        /// <summary>
        /// Available image capture devices monitor.
        /// </summary>
        ImageCaptureDevicesMonitor _imageCaptureDeviceMonitor;

        /// <summary>
        /// Image capture device.
        /// </summary>
        ImageCaptureDevice _imageCaptureDevice;

        /// <summary>
        /// Image capture source.
        /// </summary>
        ImageCaptureSource _imageCaptureSource;

        /// <summary>
        /// Image capture timeout.
        /// </summary>
        int _imageCaptureTimeout = 0;

        /// <summary>
        /// Processing command that uses to process current frame.
        /// </summary>
        ProcessingCommandBase _processingCommand;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WebcamPreviewForm"/> class.
        /// </summary>
        public WebcamPreviewForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebcamPreviewForm"/> class.
        /// </summary>
        /// <param name="device">The device.</param>
        public WebcamPreviewForm(ImageCaptureDevice device)
            : this()
        {
            _imageCaptureDevice = device;
            Text = device.FriendlyName;

            _imageCaptureSource = new ImageCaptureSource();
            _imageCaptureSource.CaptureCompleted += new EventHandler<ImageCaptureCompletedEventArgs>(CaptureSource_CaptureCompleted);
            _imageCaptureSource.CaptureDevice = _imageCaptureDevice;

            _imageCaptureDeviceMonitor = new ImageCaptureDevicesMonitor();
            _imageCaptureDeviceMonitor.CaptureDevicesChanged += new EventHandler<ImageCaptureDevicesChangedEventArgs>(DeviceMonitor_CaptureDevicesChanged);

            List<uint> imageCaptureFormatSizes = new List<uint>();
            // for each supported format
            for (int i = 0; i < _imageCaptureDevice.SupportedFormats.Count; i++)
            {
                // if format has bit depth less or equal than 12 bit
                if (_imageCaptureDevice.SupportedFormats[i].BitsPerPixel <= 12)
                    // ignore formats with bit depth less or equal than 12 bit because they may cause issues on Windows 8
                    continue;

                uint imageCaptureFormatSize = (uint)(_imageCaptureDevice.SupportedFormats[i].Width | (_imageCaptureDevice.SupportedFormats[i].Height << 16));
                if (!imageCaptureFormatSizes.Contains(imageCaptureFormatSize))
                {
                    imageCaptureFormatSizes.Add(imageCaptureFormatSize);

                    formatsComboBox.Items.Add(_imageCaptureDevice.SupportedFormats[i]);
                }
            }

            formatsComboBox.SelectedItem = _imageCaptureDevice.DesiredFormat;

            invertComboBox.SelectedIndex = 0;
        }

        #endregion



        #region Properties

        ImageViewer _snapshotViewer;
        /// <summary>
        /// Gets or sets an image viewer that stores images captured from webcam.
        /// </summary>
        public ImageViewer SnapshotViewer
        {
            get
            {
                return _snapshotViewer;
            }
            set
            {
                _snapshotViewer = value;
                captureImageButton.Visible = _snapshotViewer != null;
            }
        }

        #endregion



        #region Methods

        #region UI

        /// <summary>
        /// Handles the ValueChanged event of frameDelayNumericUpDown object.
        /// </summary>
        private void frameDelayNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            // update image capture timeout
            _imageCaptureTimeout = (int)frameDelayNumericUpDown.Value;
        }

        /// <summary>
        /// Handles the Click event of propertiesDefaultUiButton object.
        /// </summary>
        private void propertiesDefaultUiButton_Click(object sender, EventArgs e)
        {
            // show properties dialog
            _imageCaptureDevice.ShowPropertiesDialog();
        }

        /// <summary>
        /// Handles the Click event of propertiesCustomUiButton object.
        /// </summary>
        private void propertiesCustomUiButton_Click(object sender, EventArgs e)
        {
            // create custom UI dialog
            using (DirectShowWebcamPropertiesForm dlg = new DirectShowWebcamPropertiesForm((DirectShowCamera)_imageCaptureDevice))
            {
                // show dialog
                dlg.ShowDialog();
            }
        }

        /// <summary>
        /// Handles the Click event of captureImageButton object.
        /// </summary>
        private void captureImageButton_Click(object sender, EventArgs e)
        {
            if (SnapshotViewer != null)
            {
                // get current image
                VintasoftImage image = videoPreviewImageViewer.Image;
                // if current image is specified
                if (image != null)
                {
                    // add image to snapshot viewer
                    SnapshotViewer.Images.Add((VintasoftImage)image.Clone());
                    // change focused index to current image
                    SnapshotViewer.FocusedIndex = SnapshotViewer.Images.Count - 1;
                }
            }
        }


        /// <summary>
        /// Handles the Shown event of WebcamVideoForm object.
        /// </summary>
        private void WebcamVideoForm_Shown(object sender, EventArgs e)
        {
            try
            {
                // start the device monitor
                _imageCaptureDeviceMonitor.Start();
                // start the capture source
                _imageCaptureSource.Start();
                // initialize new image capture request
                _imageCaptureSource.CaptureAsync();
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
                Close();
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of formatsComboBox object.
        /// </summary>
        private void formatsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // disable user interface
            propertiesDefaultUiButton.Enabled = false;
            captureImageButton.Enabled = false;
            try
            {
                // if image capturing is started
                if (_imageCaptureSource.State == ImageCaptureState.Started)
                {
                    try
                    {
                        // stop the capture source
                        _imageCaptureSource.Stop();

                        try
                        {
                            // change desired format
                            _imageCaptureDevice.DesiredFormat = (ImageCaptureFormat)formatsComboBox.SelectedItem;
                        }
                        catch (Exception ex)
                        {
                            DemosTools.ShowErrorMessage(ex);
                        }

                        // start the capture source
                        _imageCaptureSource.Start();

                        // initialize new image capture request
                        _imageCaptureSource.CaptureAsync();
                    }
                    catch (Exception ex)
                    {
                        DemosTools.ShowErrorMessage(ex);
                    }
                }
            }
            finally
            {
                // enable user interface
                propertiesDefaultUiButton.Enabled = true;
                captureImageButton.Enabled = true;
            }
        }

        /// <summary>
        /// Handles the FormClosed event of WebcamVideoForm object.
        /// </summary>
        private void WebcamVideoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // stop the device monitor
            _imageCaptureDeviceMonitor.Stop();
            // stop the capture source
            _imageCaptureSource.Stop();
        }

        #endregion


        #region Camera

        /// <summary>
        /// Updates the captured image in image viewer.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ImageCaptureCompletedEventArgs"/> instance containing the event data.</param>
        private void CaptureSource_CaptureCompleted(object sender, ImageCaptureCompletedEventArgs e)
        {
            // save reference to the previously captured image
            VintasoftImage oldImage = videoPreviewImageViewer.Image;

            // get captured image
            VintasoftImage newImage = e.GetCapturedImage();

            // apply processing
            if (_processingCommand != null)
                _processingCommand.ExecuteInPlace(newImage);

            // show captured image in the preview viewer           
            videoPreviewImageViewer.Image = newImage;

            // if previously captured image is exist
            if (oldImage != null)
                // dispose previously captured image
                oldImage.Dispose();

            // if capture source is started
            if (_imageCaptureSource.State == ImageCaptureState.Started)
            {
                // sleep...
                if (_imageCaptureTimeout > 0)
                    Thread.Sleep(_imageCaptureTimeout);
                // if capture source is started
                if (_imageCaptureSource.State == ImageCaptureState.Started)
                    // initialize new image capture request
                    _imageCaptureSource.CaptureAsync();
            }
        }

        /// <summary>
        /// List of available capturing devices is changed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ImageCaptureDevicesChangedEventArgs"/> instance containing the event data.</param>
        private void DeviceMonitor_CaptureDevicesChanged(object sender, ImageCaptureDevicesChangedEventArgs e)
        {
            // if current capture device is removed
            if (Array.IndexOf(e.RemovedDevices, _imageCaptureDevice) >= 0)
            {
                // close form
                Invoke(new ThreadStart(Close));
            }
        }

        #endregion


        #region Captured Image Processing

        /// <summary>
        /// Builds the proccessing command to process current captured frame.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ChangeProcessingCommandHandler(object sender, EventArgs e)
        {
            List<ProcessingCommandBase> commands = new List<ProcessingCommandBase>();

            // Invert
            switch (invertComboBox.SelectedIndex)
            {
                case 1:
                    commands.Add(new InvertCommand());
                    break;
                case 2:
                    commands.Add(new ColorBlendCommand(BlendingMode.Difference, Color.FromArgb(255, 0, 0)));
                    break;
                case 3:
                    commands.Add(new ColorBlendCommand(BlendingMode.Difference, Color.FromArgb(0, 255, 0)));
                    break;
                case 4:
                    commands.Add(new ColorBlendCommand(BlendingMode.Difference, Color.FromArgb(0, 0, 255)));
                    break;
            }

            // Grayscale
            if (grayscaleCheckBox.Checked)
                commands.Add(new ChangePixelFormatToGrayscaleCommand(PixelFormat.Gray8));

            // Rotate
            int rotate;
            if (int.TryParse(rotateComboBox.Text, out rotate))
            {
                if (rotate != 0)
                {
                    RotateCommand rotateCommand = new RotateCommand(rotate);
                    rotateCommand.BorderColorType = BorderColorType.Black;
                    commands.Add(rotateCommand);
                }
            }

            if (commands.Count == 0)
                _processingCommand = null;
            else if (commands.Count == 1)
                _processingCommand = commands[0];
            else
                _processingCommand = new CompositeCommand(commands.ToArray());
        }

        #endregion

        #endregion

    }
}
