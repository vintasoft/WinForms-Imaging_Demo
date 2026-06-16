namespace CommonCode
{
    /// <summary>
    /// Loads the Vintasoft.Imaging.CadCodec assembly.
    /// </summary>
    public class CadCodecAssemblyLoader
    {

        /// <summary>
        /// Loads the Vintasoft.Imaging.CadCodec assembly.
        /// </summary>
        public static void Load()
        {
#if REMOVE_CAD_CODEC
            Vintasoft.Imaging.Codecs.AvailableCodecs.RemoveCodecByName("Cad");
#else
            using (Vintasoft.Imaging.Codecs.Decoders.CadDecoder decoder =
                new Vintasoft.Imaging.Codecs.Decoders.CadDecoder())
            {
            }
#endif
        }

    }
}
