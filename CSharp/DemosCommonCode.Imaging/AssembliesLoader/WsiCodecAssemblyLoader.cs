using Vintasoft.Imaging;

namespace CommonCode
{
    /// <summary>
    /// Loads the Vintasoft.Imaging.WsiCodec assembly.
    /// </summary>
    public class WsiCodecAssemblyLoader
    {

        /// <summary>
        /// Loads the Vintasoft.Imaging.WsiCodec assembly.
        /// </summary>
        public static void Load()
        {
            WsiCodecAssembly.Init();
        }

    }
}
