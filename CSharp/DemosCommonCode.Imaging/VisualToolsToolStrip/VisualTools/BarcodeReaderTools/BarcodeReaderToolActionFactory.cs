using System;
using System.Drawing;

using DemosCommonCode.Imaging;


namespace DemosCommonCode.Barcode
{
    /// <summary>
    /// Creates visual tool action, which allows to enable/disable visual tool <see cref="BarcodeReaderTool"/> in image viewer, and adds action to the toolstrip.
    /// </summary>    
    public class BarcodeReaderToolActionFactory
    {

        #region Methods

        #region PUBLIC

        /// <summary>
        /// Creates visual tool action, which allows to enable/disable visual tool <see cref="BarcodeReaderTool"/> in image viewer, and adds action to the toolstrip.
        /// </summary>
        /// <param name="toolStrip">The toolstrip, where actions must be added.</param>
        public static void CreateActions(VisualToolsToolStrip toolStrip)
        {
            // create action, which allows to enable the barcode reader tool in image viewer
            BarcodeReaderToolAction barcodeReaderToolAction = new BarcodeReaderToolAction(
                new BarcodeReaderTool(),
                "Barcode Reader",
                "Barcode Reader",
                GetIcon("BarcodeReaderTool.png"));
            // add the action to the toolstrip
            toolStrip.AddAction(barcodeReaderToolAction);
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// Returns the visual tool icon of specified name.
        /// </summary>
        /// <param name="iconName">The visual tool icon name.</param>
        /// <returns>
        /// The visual tool icon.
        /// </returns>
        private static Image GetIcon(string iconName)
        {
            string iconPath =
                string.Format("DemosCommonCode.Imaging.VisualToolsToolStrip.VisualTools.BarcodeReaderTools.Resources.{0}", iconName);

            return DemosResourcesManager.GetResourceAsBitmap(iconPath);
        }

        #endregion

        #endregion

    }
}
