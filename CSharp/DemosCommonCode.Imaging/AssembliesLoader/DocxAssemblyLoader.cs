namespace DemosCommonCode
{
    /// <summary>
    /// Loads the Vintasoft.Imaging.Office.OpenXml assembly.
    /// </summary>
    public class DocxAssemblyLoader
    {

        /// <summary>
        /// Loads the Vintasoft.Imaging.Office.OpenXml assembly.
        /// </summary>
        public static void Load()
        {
#if !REMOVE_OFFICE_PLUGIN
            using (Vintasoft.Imaging.Codecs.Decoders.DocxDecoder decoder =
                new Vintasoft.Imaging.Codecs.Decoders.DocxDecoder())
            {
            }
#endif
        }

    }
}
