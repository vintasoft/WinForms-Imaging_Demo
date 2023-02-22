using System;
using System.Windows.Forms;

using Vintasoft.Imaging;
#if !REMOVE_TWAIN_SDK
using Vintasoft.Twain; 
#endif

namespace DemosCommonCode.Twain
{
    /// <summary>
    /// Represents a simple TWAIN manager.
    /// </summary>
    public class SimpleTwainManager
    {

        #region Fields

        /// <summary>
        /// Images.
        /// </summary>
        ImageCollection _images;

        /// <summary>
        /// Parent form.
        /// </summary>
        Form _parentForm;

        #endregion



        #region Constructors

        public SimpleTwainManager(Form parentForm, ImageCollection images)
        {
            _parentForm = parentForm;
            _images = images;
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Selects the device and acquires images from device.
        /// </summary>
        public void SelectDeviceAndAcquireImage()
        {
#if !REMOVE_TWAIN_SDK
            DeviceManager deviceManager = new DeviceManager(_parentForm, _parentForm.Handle);
            try
            {
                Device device = null;
                try
                {
                    // try to use TWAIN device manager 2.x
                    deviceManager.IsTwain2Compatible = true;
                    // if TWAIN device manager 2.x is not found
                    if (!deviceManager.IsTwainAvailable)
                    {
                        try
                        {
                            // try to use TWAIN device manager 1.x
                            deviceManager.IsTwain2Compatible = false;
                        }
                        catch
                        {
                            if (IntPtr.Size != 8)
                                throw;
                        }
                        // if TWAIN device manager 1.x is not found
                        if (!deviceManager.IsTwainAvailable)
                        {
                            // show dialog with error message
                            MessageBox.Show("TWAIN device manager is not found.", "TWAIN device manager", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            // open a HTML page with article describing how to solve the problem
                            DemosTools.OpenBrowser("https://www.vintasoft.com/docs/vstwain-dotnet/Programming-Twain-Device_Manager.html");
                            return;
                        }
                    }

                    // if 64-bit TWAIN2 device manager is used
                    if (IntPtr.Size == 8 && deviceManager.IsTwain2Compatible)
                    {
                        if (!InitTwain2DeviceManagerMode(deviceManager))
                            return;
                    }

                    try
                    {
                        // open the device manager
                        deviceManager.Open();
                    }
                    catch (Exception ex)
                    {
                        // show dialog with error message
                        DemosTools.ShowErrorMessage("TWAIN device manager", ex);
                        return;
                    }

                    // if devices are not found in the system
                    if (deviceManager.Devices.Count == 0)
                    {
                        MessageBox.Show("Devices are not found.");
                        return;
                    }

                    // if device is not selected
                    if (!deviceManager.ShowDefaultDeviceSelectionDialog())
                        return;

                    // get reference to the current device
                    device = deviceManager.DefaultDevice;

                    device.ShowUI = true;

                    // acquire image(s) from the device
                    AcquireModalState acquireModalState = AcquireModalState.None;
                    do
                    {
                        acquireModalState = device.AcquireModal();
                        switch (acquireModalState)
                        {
                            case AcquireModalState.ImageAcquired:
                                // get acquired image as Bitmap and add Bitmap to the image collection
                                _images.Add(new VintasoftImage(device.AcquiredImage.GetAsVintasoftBitmap(), true));
                                // dispose the acquired image
                                device.AcquiredImage.Dispose();
                                break;

                            case AcquireModalState.ScanCompleted:
                                break;

                            case AcquireModalState.ScanCanceled:
                                MessageBox.Show("Scan canceled.");
                                break;

                            case AcquireModalState.ScanFailed:
                                MessageBox.Show(string.Format("Scan failed: {0}", device.ErrorString));
                                break;
                        }
                    }
                    while (acquireModalState != AcquireModalState.None);
                }
                catch (TwainInvalidStateException ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                }
                catch (TwainDeviceManagerException ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                }
                catch (TwainDeviceException ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                }
                finally
                {
                    if (device != null && device.State == DeviceState.Opened)
                        // close the device
                        device.Close();

                    if (deviceManager.State != DeviceManagerState.Closed)
                        // close the device manager
                        deviceManager.Close();
                }
            }
            finally
            {
                deviceManager.Dispose();
            }            
#endif
        }

        #endregion


        #region PRIVATE

#if !REMOVE_TWAIN_SDK
        /// <summary>
        /// Initializes the device manager mode.
        /// </summary>
        /// <param name="deviceManager">The TWAIN device manager.</param>
        private bool InitTwain2DeviceManagerMode(DeviceManager deviceManager)
        {
            // create a form that allows to view and edit mode of 64-bit TWAIN2 device manager
            using (SelectDeviceManagerModeForm form = new SelectDeviceManagerModeForm())
            {
                // initialize form
                form.StartPosition = FormStartPosition.CenterParent;
                form.Use32BitDevices = deviceManager.Are32BitDevicesUsed;

                // show dialog
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // if device manager mode is changed
                    if (form.Use32BitDevices != deviceManager.Are32BitDevicesUsed)
                    {
                        try
                        {
                            // if 32-bit devices must be used
                            if (form.Use32BitDevices)
                                deviceManager.Use32BitDevices();
                            else
                                deviceManager.Use64BitDevices();
                        }
                        catch (TwainDeviceManagerException ex)
                        {
                            // show dialog with error message
                            MessageBox.Show(ex.Message, "TWAIN device manager", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        } 
#endif

        #endregion

        #endregion

    }
}
