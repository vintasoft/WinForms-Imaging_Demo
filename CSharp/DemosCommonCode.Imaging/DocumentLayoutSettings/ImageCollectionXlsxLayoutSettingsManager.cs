using Vintasoft.Imaging;
using Vintasoft.Imaging.Codecs.Decoders;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// Contains helper methods, which allow to manage XLSX document layout settings.
    /// </summary>
    public class ImageCollectionXlsxLayoutSettingsManager : ImageCollectionLayoutSettingsManager
    {

        #region Constructors

        /// <summary>
        /// Inititalizes new instance of <see cref="ImageCollectionXlsxLayoutSettingsManager"/>.
        /// </summary>
        /// <param name="images">Image collection.</param>
        public ImageCollectionXlsxLayoutSettingsManager(ImageCollection images)
            : base(images, "Xlsx")
        {
#if !REMOVE_OFFICE_PLUGIN
            LayoutSettings = new XlsxDocumentLayoutSettings();
            LayoutSettings.FontProgramsController = CustomFontProgramsController.Default;
#endif
        }

        #endregion



        #region Methods

        /// <summary>
        /// Returns document layout settings dialog.
        /// </summary>
        /// <returns>
        /// Document layout settings dialog.
        /// </returns>
        protected override DocumentLayoutSettingsDialog CreateLayoutSettingsDialog()
        {
            return new XlsxLayoutSettingsDialog();
        }

        #endregion

    }
}
