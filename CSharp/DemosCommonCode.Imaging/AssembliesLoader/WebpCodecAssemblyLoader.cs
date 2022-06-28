namespace DemosCommonCode
{
    /// <summary>
    /// Loads the Vintasoft.Imaging.WebpCodec assembly.
    /// </summary>
    public class WebpCodecAssemblyLoader
    {

        /// <summary>
        /// Loads the Vintasoft.Imaging.WebpCodec assembly.
        /// </summary>
        public static void Load()
        {
#if NETCOREAPP
#if REMOVE_WEBP_PLUGIN
            Vintasoft.Imaging.Codecs.AvailableCodecs.RemoveCodecByName("Webp");
#else
            using (Vintasoft.Imaging.Codecs.Decoders.WebpDecoder decoder = 
                new Vintasoft.Imaging.Codecs.Decoders.WebpDecoder())
            {
            }
#endif
#endif
        }

    }
}
