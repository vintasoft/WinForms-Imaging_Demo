using System;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Codecs.Decoders;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// Contains helper methods, which allow to manage the document layout settings.
    /// </summary>
    public abstract class ImageCollectionLayoutSettingsManager : IDisposable
    {

        #region Fields

        /// <summary>
        /// The image collection.
        /// </summary>
        ImageCollection _images;

        #endregion



        #region Constructors

        /// <summary>
        /// Inititalizes new instance of <see cref="ImageCollectionLayoutSettingsManager"/>.
        /// </summary>
        /// <param name="images">Image collection.</param>
        /// <param name="codecName">Codec name.</param>
        public ImageCollectionLayoutSettingsManager(ImageCollection images, string codecName)
        {
            _codecName = codecName;
            _images = images;
            // subscribe to the layout settings request event
            _images.LayoutSettingsRequest += ImageCollection_LayoutSettingsRequest;
        }

        #endregion



        #region Properties

        string _codecName;
        /// <summary>
        /// Gets the codec name.
        /// </summary>
        public string CodecName
        {
            get
            {
                return _codecName;
            }
        }

        DocumentLayoutSettings _layoutSettings;
        /// <summary>
        /// Gets or sets the document layout settings.
        /// </summary>
        public DocumentLayoutSettings LayoutSettings
        {
            get
            {
                return _layoutSettings;
            }

            set
            {
                if (!Equals(_layoutSettings, value))
                {
                    DocumentLayoutSettings oldSettings = _layoutSettings;
                    _layoutSettings = value;

                    // check images
                    if (_images.Count == 0)
                        return;
                    if (_images[0].SourceInfo.SourceType != ImageSourceType.File)
                        return;
                    if (_images[0].SourceInfo.Decoder.GetDefaultLayoutSettings() == null)
                        return;
                    if (!ContainsSingleDocument(_images))
                        return;
                    if (_images[0].SourceInfo.DecoderName != CodecName)
                        return;

                    // get information about image source
                    bool readOnlyMode = !_images[0].SourceInfo.Stream.CanWrite;
                    string filename = _images[0].SourceInfo.Filename;

                    try
                    {
                        // reload document
                        Reload(filename, readOnlyMode);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        // restore layout settings
                        _layoutSettings = oldSettings;

                        // reload document
                        Reload(filename, readOnlyMode);

                        throw;
                    }
                }
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Edits the document layout settings using DocumentLayoutSettingsDialog.
        /// </summary>
        public bool EditLayoutSettingsUseDialog()
        {
            // create dialog with necessary layout settings
            using (DocumentLayoutSettingsDialog dialog = CreateLayoutSettingsDialog())
            {
                // pass current layout settings to the dialog
                if (LayoutSettings != null)
                    dialog.LayoutSettings = (DocumentLayoutSettings)LayoutSettings.Clone();

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // get layout settings from dialog
                    try
                    {
                        LayoutSettings = dialog.LayoutSettings;
                        return true;
                    }
                    catch (Exception ex)
                    {
                        DemosTools.ShowErrorMessage(ex);
                    }
                }

                return false;
            }
        }

        /// <summary>
        /// Releases all resources used by this <see cref="ImageCollectionLayoutSettingsManager"/> object.
        /// </summary>
        public void Dispose()
        {
            if (_images != null)
            {
                _images.LayoutSettingsRequest -= ImageCollection_LayoutSettingsRequest;
                _images = null;
            }
        }

        #endregion


        #region PROTECTED

        /// <summary>
        /// Returns document layout settings dialog.
        /// </summary>
        /// <returns>
        /// Document layout settings dialog.
        /// </returns>
        protected abstract DocumentLayoutSettingsDialog CreateLayoutSettingsDialog();

        #endregion


        #region PRIVATE

        /// <summary>
        /// Handles the ImageCollection.LayoutSettingsRequest event.
        /// </summary>
        private void ImageCollection_LayoutSettingsRequest(object sender, DocumentLayoutSettingsRequestEventArgs e)
        {
            if (LayoutSettings != null && CodecName == e.Codec.Name)
            {
                // update document layout settings
                LayoutSettings.CopyTo(e.LayoutSettings);
            }
        }

        /// <summary>
        /// Reloads images in image collection.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="readonlyMode">A value indicating whether file should be opened in readonly mode.</param>
        private void Reload(string filename, bool readOnlyMode)
        {
            _images.ClearAndDisposeItems();
            _images.Add(filename, readOnlyMode);
        }

        /// <summary>
        /// Returns a value indication whether image collection contains single document.
        /// </summary>
        /// <param name="images">Image collection.</param>
        /// <returns><b>True</b> if image collection contains single document; otherwise <b>false</b>.</returns>
        private bool ContainsSingleDocument(ImageCollection images)
        {
            if (images.Count == 0)
                return false;
            if (images.Count == 1)
                return true;
            DecoderBase decoder = images[0].SourceInfo.Decoder;
            for (int i = 1; i < images.Count; i++)
            {
                VintasoftImage image = images[i];
                if (decoder != image.SourceInfo.Decoder)
                    return false;
            }
            return true;
        }

        #endregion

        #endregion

    }
}
