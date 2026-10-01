namespace CommonCode
{
    /// <summary>
    /// Loads the Vintasoft.Imaging.EmailCodec assembly.
    /// </summary>
    public class EmailCodecAssemblyLoader
    {

        /// <summary>
        /// Loads the Vintasoft.Imaging.EmailCodec assembly.
        /// </summary>
        public static void Load()
        {
#if REMOVE_EMAIL_CODEC
            Vintasoft.Imaging.Codecs.AvailableCodecs.RemoveCodecByName("Email");
#else
            using (Vintasoft.Imaging.Codecs.Decoders.EmailDecoder decoder =
                new Vintasoft.Imaging.Codecs.Decoders.EmailDecoder())
            {
            }
#endif
        }

    }
}
