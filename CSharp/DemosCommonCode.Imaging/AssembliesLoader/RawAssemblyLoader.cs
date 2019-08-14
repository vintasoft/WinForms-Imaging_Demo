namespace DemosCommonCode
{
    /// <summary>
    /// Loads the Vintasoft.Imaging.RawCodec assembly.
    /// </summary>
    public class RawAssemblyLoader
    {

        /// <summary>
        /// Loads the Vintasoft.Imaging.RawCodec assembly.
        /// </summary>
        public static void Load()
        {
#if !REMOVE_RAW_PLUGIN
            using (Vintasoft.Imaging.Codecs.Decoders.RawDecoder decoder = 
                new Vintasoft.Imaging.Codecs.Decoders.RawDecoder())
            {
            }
#endif
        }

    }
}
