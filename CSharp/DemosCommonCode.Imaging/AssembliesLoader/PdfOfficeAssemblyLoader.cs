namespace DemosCommonCode
{
    /// <summary>
    /// Loads the Vintasoft.Imaging.Pdf.Office assembly.
    /// </summary>
    public class PdfOfficeAssemblyLoader
    {

        /// <summary>
        /// Loads the Vintasoft.Imaging.Pdf.Office assembly.
        /// </summary>
        public static void Load()
        {
#if !REMOVE_OFFICE_PLUGIN && !REMOVE_PDF_PLUGIN
            Vintasoft.Imaging.PdfOfficeAssembly.Init();
#endif
        }

    }
}
