using System;
using System.ComponentModel;
using System.Windows.Forms;
using Vintasoft.Imaging;
using Vintasoft.Imaging.Codecs.Decoders;

namespace CommonCode.Imaging
{
    /// <summary>
    /// Provides a base class for dialogs that allows to view and edit document layout settings.
    /// </summary>
    public class DocumentLayoutSettingsDialog : Form
    {

        #region Properties

        /// <summary>
        /// Gets the name of the codec.
        /// </summary>
        [Browsable(false)]
        public virtual string CodecName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        DocumentLayoutSettings _layoutSettings;
        /// <summary>
        /// Gets or sets the document layout settings.
        /// </summary>
        /// <value>
        /// Default value is <b>null</b>.
        /// </value>
        [Browsable(false)]
        [DefaultValue((DocumentLayoutSettings)null)]
        public virtual DocumentLayoutSettings LayoutSettings
        {
            get
            {
                return _layoutSettings;
            }
            set
            {
                _layoutSettings = value;
            }
        }

        ImageCollectionLayoutSettingsManager _layoutSettingsManager;
        /// <summary>
        /// Gets or sets the manager of document layout settings.
        /// </summary>
        /// <value>
        /// Default value is <b>null</b>.
        /// </value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ImageCollectionLayoutSettingsManager LayoutSettingsManager
        {
            get
            {
                return _layoutSettingsManager;
            }
            set
            {
                _layoutSettingsManager = value;
                if (value != null)
                    LayoutSettings = _layoutSettingsManager[CodecName];
            }
        }

        #endregion


        #region Methods

        /// <summary>
        /// Creates the default layout settings.
        /// </summary>
        protected virtual DocumentLayoutSettings CreateDefaultLayoutSettings()
        {
            return LayoutSettingsManager.GetDefaultSettings(CodecName);
        }

        #endregion

    }
}
