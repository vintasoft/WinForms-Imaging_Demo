using System;
using System.Windows.Forms;

using Vintasoft.Imaging;
#if !REMOVE_DICOM_PLUGIN
using Vintasoft.Imaging.Codecs.ImageFiles.Dicom; 
#endif
using Vintasoft.Imaging.Metadata;


namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A form that allows to edit the DICOM frame metadata.
    /// </summary>
    public partial class DicomMetadataEditorForm : Form
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DicomMetadataEditorForm"/> class.
        /// </summary>
        public DicomMetadataEditorForm()
        {
            InitializeComponent();
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets or sets an image.
        /// </summary>
        public VintasoftImage Image
        {
            get
            {
                return dicomMetadataEditorControl1.Image;
            }
            set
            {
                dicomMetadataEditorControl1.Image = value;
            }
        }

        /// <summary>
        /// Gets or sets the root metadata node.
        /// </summary>
        public MetadataNode RootMetadataNode
        {
            get
            {
                return dicomMetadataEditorControl1.RootMetadataNode;
            }
            set
            {
                dicomMetadataEditorControl1.RootMetadataNode = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether DICOM metadata can be edited.
        /// </summary>
        /// <value>
        /// <b>True</b> if DICOM metadata can be edited; otherwise, <b>false</b>.
        /// </value>
        public bool CanEdit
        {
            get
            { 
                return dicomMetadataEditorControl1.CanEdit;
            }
            set 
            {
                dicomMetadataEditorControl1.CanEdit = value;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Form is shown.
        /// </summary>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            dicomMetadataEditorControl1.Select();

            if (CanEdit)
            {
                this.Text = "DICOM Metadata Editor";
            }
            else
            {
                this.Text = "DICOM Metadata Viewer";
            }
        }

        #endregion

    }
}
