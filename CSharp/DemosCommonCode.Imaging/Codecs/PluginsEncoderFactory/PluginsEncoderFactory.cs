using System.Windows.Forms;

using Vintasoft.Imaging.Codecs.Encoders;

using DemosCommonCode.Imaging.Codecs.Dialogs;


namespace DemosCommonCode.Imaging.Codecs
{
    /// <summary>
    /// Provides the ability to create the encoder (<see cref="EncoderBase"/> or 
    /// <see cref="MultipageEncoderBase"/>) for filename or encoder name.
    /// </summary>
    public class PluginsEncoderFactory : ImagingEncoderFactory
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PluginsEncoderFactory"/> class.
        /// </summary>
        public PluginsEncoderFactory()
            : base()
        {
        }

        #endregion



        #region Properties

        static PluginsEncoderFactory _default = null;
        /// <summary>
        /// Gets the default <see cref="PluginsEncoderFactory"/>.
        /// </summary>
        public static new PluginsEncoderFactory Default
        {
            get
            {
                if (_default == null)
                    _default = new PluginsEncoderFactory();

                return _default;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Shows the encoder settings dialog.
        /// </summary>
        /// <param name="encoder">The encoder.</param>
        /// <param name="canAddImagesToExistingFile">The value indicating whether encoder can add images to the existing multipage image file.</param>
        /// <returns>
        /// <b>True</b> if settings are applied to the encoder; otherwise, <b>false</b>.
        /// </returns>
        protected override bool ShowEncoderSettingsDialog(
            ref EncoderBase encoder,
            bool canAddImagesToExistingFile)
        {
            if (base.ShowEncoderSettingsDialog(ref encoder, canAddImagesToExistingFile))
                return true;

            // set encoder settings
            switch (encoder.Name)
            {
                case "Jpeg2000":
                    using (Jpeg2000EncoderSettingsForm jpeg2000EncoderSettingsForm = new Jpeg2000EncoderSettingsForm())
                    {
                        SetEncoderSettingsDialogProperties(jpeg2000EncoderSettingsForm);
                        if (jpeg2000EncoderSettingsForm.ShowDialog() != DialogResult.OK)
                            return false;

                        ((IJpeg2000Encoder)encoder).Settings = jpeg2000EncoderSettingsForm.EncoderSettings;
                        return true;
                    }

#if !REMOVE_PDF_PLUGIN
                case "Pdf":
                    using (PdfEncoderSettingsForm pdfEncoderSettingsForm = new PdfEncoderSettingsForm())
                    {
                        SetEncoderSettingsDialogProperties(pdfEncoderSettingsForm);
                        pdfEncoderSettingsForm.AppendExistingDocumentEnabled = canAddImagesToExistingFile;
                        if (pdfEncoderSettingsForm.ShowDialog() != DialogResult.OK)
                            return false;
#if !REMOVE_DOCCLEANUP_PLUGIN
                        if (pdfEncoderSettingsForm.MrcCompressionSettings != null &&
                            pdfEncoderSettingsForm.MrcCompressionSettings.EnableMrcCompression)
                        {
                            encoder.Dispose();
                            encoder = new PdfMrcEncoder();
                            ((PdfMrcEncoder)encoder).MrcCompressionSettings = pdfEncoderSettingsForm.MrcCompressionSettings;
                        }
#endif
                        ((IPdfEncoder)encoder).Settings = pdfEncoderSettingsForm.EncoderSettings;
                        ((MultipageEncoderBase)encoder).CreateNewFile = !pdfEncoderSettingsForm.AppendExistingDocument;
                        return true;
                    }
#endif

                case "Jbig2":
                    using (Jbig2EncoderSettingsForm jbig2EncoderSettingsForm = new Jbig2EncoderSettingsForm())
                    {
                        SetEncoderSettingsDialogProperties(jbig2EncoderSettingsForm);
                        jbig2EncoderSettingsForm.AppendExistingDocumentEnabled = canAddImagesToExistingFile;
                        if (jbig2EncoderSettingsForm.ShowDialog() != DialogResult.OK)
                            return false;

                        ((IJbig2Encoder)encoder).Settings = jbig2EncoderSettingsForm.EncoderSettings;
                        ((MultipageEncoderBase)encoder).CreateNewFile = !jbig2EncoderSettingsForm.AppendExistingDocument;
                        return true;
                    }
            }

            return false;
        }

        #endregion

    }
}
