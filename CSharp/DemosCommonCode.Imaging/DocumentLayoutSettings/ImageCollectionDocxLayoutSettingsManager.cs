﻿using Vintasoft.Imaging;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// Contains helper methods, which allow to manage DOCX document layout settings.
    /// </summary>
    public class ImageCollectionDocxLayoutSettingsManager : ImageCollectionLayoutSettingsManager
    {

        #region Constructors

        /// <summary>
        /// Inititalizes new instance of <see cref="ImageCollectionDocxLayoutSettingsManager"/>.
        /// </summary>
        /// <param name="images">Image collection.</param>
        public ImageCollectionDocxLayoutSettingsManager(ImageCollection images)
            : base(images, "Docx")
        {
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
            return new DocxLayoutSettingsDialog();
        }

        #endregion

    }
}
