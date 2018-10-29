using System.IO;
using System.Reflection;

namespace ImagingDemo
{
    internal class ImagingDemoResources
    {

        #region Methods

        internal static Vintasoft.Imaging.VintasoftImage GetResourceAsImage(string filename)
        {
            return new Vintasoft.Imaging.VintasoftImage(GetResourceAsStream(filename));
        }

        internal static Stream GetResourceAsStream(string filename)
        {
            Assembly assembly = typeof(ImagingDemoResources).Module.Assembly;
            Stream resourceStream = assembly.GetManifestResourceStream("ImagingDemo.Resources." + filename);
            if (resourceStream == null)
                resourceStream = assembly.GetManifestResourceStream("ImagingDemo." + filename);
            return resourceStream;
        }

        #endregion

    }
}
