using System;
using System.ComponentModel;
using System.Windows.Forms;

using Vintasoft.Imaging.Codecs.Decoders;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// Provides a base class for dialogs that allows to view and edit document layout settings.
    /// </summary>
    public class DocumentLayoutSettingsDialog : Form
    {

        #region Properties

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

        #endregion



        #region Methods

        /// <summary>
        /// Returns default document layout settings.
        /// </summary>
        /// <returns>
        /// Default document layout settings.
        /// </returns>
        /// <exception cref="NotImplementedException">Thrown if method is not implemented.</exception>
        protected virtual DocumentLayoutSettings CreateDefaultLayoutSettings()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
