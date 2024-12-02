using System;
using System.ComponentModel;
using System.Windows.Forms;

using Vintasoft.Imaging.Codecs.Decoders;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A control that allows to edit document layout settings.
    /// </summary>
    public partial class DocumentLayoutSettingsEditorControl : UserControl
    {

        #region Constructors

        /// <summary>
        /// Inititalizes new instance of <see cref="DocumentLayoutSettingsEditorControl"/>.
        /// </summary>
        public DocumentLayoutSettingsEditorControl()
        {
            InitializeComponent();
        }

        #endregion



        #region Properties

        DocumentLayoutSettings _layoutSettings;
        /// <summary>
        /// Gets or sets document layout settings.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown if <b>value</b> is null.</exception>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DocumentLayoutSettings LayoutSettings
        {
            get
            {
                _layoutSettings.PageLayoutSettings = allPagesLayoutSettingsControl.PageLayoutSettings;
                _layoutSettings.EvenPageLayoutSettings = evenPagesLayoutSettingsControl.PageLayoutSettings;
                _layoutSettings.OddPageLayoutSettings = oddPagesLayoutSettingsControl.PageLayoutSettings;

                return _layoutSettings;
            }
            set
            {
                if (DesignMode)
                    return;

                if (value == null)
                    throw new ArgumentNullException("", "Value can not be null.");

                allPagesLayoutSettingsControl.PageLayoutSettings = value.PageLayoutSettings;
                evenPagesLayoutSettingsControl.PageLayoutSettings = value.EvenPageLayoutSettings;
                oddPagesLayoutSettingsControl.PageLayoutSettings = value.OddPageLayoutSettings;

                _layoutSettings = value;
            }
        }

        #endregion

    }
}
