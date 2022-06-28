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
    /// A control that allows to edit the DICOM frame metadata.
    /// </summary>
    public partial class DicomMetadataEditorControl : UserControl
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DicomMetadataEditorControl"/> class.
        /// </summary>
        public DicomMetadataEditorControl()
        {
            InitializeComponent();
        }

        #endregion



        #region Properties

        VintasoftImage _image;
        /// <summary>
        /// Gets or sets an image.
        /// </summary>
        public VintasoftImage Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;

                if (_image == null)
                    RootMetadataNode = null;
                else
                    RootMetadataNode = _image.Metadata.MetadataTree;
            }
        }

        /// <summary>
        /// Gets or sets the root metadata node.
        /// </summary>
        public MetadataNode RootMetadataNode
        {
            get
            {
                return metadataTreeView.RootMetadataNode;
            }
            set
            {
                metadataTreeView.RootMetadataNode = value;

                if (value == null)
                    ShowMetadataNodeProperties(null);

                UpdateUI();
            }
        }

        bool _canEdit = true;
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
                return _canEdit;
            }
            set
            {
                _canEdit = value;
            }
        }

        #endregion



        #region Methods

        #region PROTECTED

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            metadataTreeView.Select();
        }

        #endregion


        #region PRIVATE

        #region UI

        /// <summary>
        /// Handles the AfterSelect event of MetadataTreeView object.
        /// </summary>
        private void metadataTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // get metadata node
            MetadataNode metadataNode = metadataTreeView.SelectedMetadataNode;

            // show metadata node properties
            ShowMetadataNodeProperties(metadataNode);

            string selectedNodeDescription = string.Empty;
            string addButtonText = "Add DICOM Data Element...";

            // if metadata node is selected
            if (metadataNode != null)
            {
                // update metadata node description
                selectedNodeDescription = string.Format("{0} ({1})", metadataNode.Name, metadataNode.GetType().Name);

#if !REMOVE_DICOM_PLUGIN
                if (metadataNode is DicomDataElementMetadata &&
                           ((DicomDataElementMetadata)metadataNode).ValueRepresentation == DicomValueRepresentation.SQ)
                    addButtonText = "Add DICOM Sequence Item";
#endif
            }

            selectedNodeGroupBox.Text = selectedNodeDescription;
            addButton.Text = addButtonText;

            UpdateUI();
        }

        /// <summary>
        /// Handles the Click event of AddButton object.
        /// </summary>
        private void addButton_Click(object sender, EventArgs e)
        {
            // get selected metadata node
            MetadataNode metadataNode = metadataTreeView.SelectedMetadataNode;
            bool isMetadataNodeChanged = false;

#if !REMOVE_DICOM_PLUGIN
            if (metadataNode is DicomDataElementMetadata)
            {
                // get data element
                DicomDataElementMetadata node = (DicomDataElementMetadata)metadataNode;
                // add child
                node.AddChild();
                // specify that metadata node is changed
                isMetadataNodeChanged = true;
            }
            else
            {
                // create "Add data element" form
                using (AddDicomDataElementForm dialog = new AddDicomDataElementForm(metadataNode))
                {
                    dialog.StartPosition = FormStartPosition.CenterParent;
                    dialog.Owner = ParentForm;
                    // if data element is changed
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        isMetadataNodeChanged = true;
                    }
                }
            }
#endif

            // if metadata node is changed
            if (isMetadataNodeChanged)
            {
                // update node
                metadataTreeView.UpdateNode(metadataNode);
                metadataTreeView.Focus();

                treeViewSearchControl1.ResetSearchResult();
            }
        }

        /// <summary>
        /// Handles the Click event of RemoveButton object.
        /// </summary>
        private void removeButton_Click(object sender, EventArgs e)
        {
            // get the selected metadata node
            MetadataNode metadataNode = metadataTreeView.SelectedMetadataNode;
            // remove the selected metadata node
            metadataNode.Parent.RemoveChild(metadataNode);

            // update parent of selected node
            metadataTreeView.UpdateNode(metadataNode.Parent);

            metadataTreeView.Focus();
            treeViewSearchControl1.ResetSearchResult();
        }

        #endregion


        #region UI state

        /// <summary>
        /// Updates the user interface of this form.
        /// </summary>
        private void UpdateUI()
        {
            addButton.Visible = CanEdit;
            removeButton.Visible = CanEdit;

            MetadataNode metadataNode = metadataTreeView.SelectedMetadataNode;

            bool canAddSubNode = false;

            splitContainer1.Enabled = RootMetadataNode != null;

#if !REMOVE_DICOM_PLUGIN
            if (metadataNode is DicomFrameMetadata ||
                  metadataNode is DicomDataSetMetadata)
                canAddSubNode = true;

            if (metadataNode is DicomDataElementMetadata &&
                ((DicomDataElementMetadata)metadataNode).ValueRepresentation == DicomValueRepresentation.SQ)
                canAddSubNode = true;
#endif

            addButton.Enabled = CanEdit && canAddSubNode;
            if (metadataNode == null)
                removeButton.Enabled = false;
            else
                removeButton.Enabled = CanEdit && metadataNode.CanRemove;
        }

        #endregion


        /// <summary>
        /// Shows the specified metadata node properties in <see cref="PropertyGrid"/>.
        /// </summary>
        /// <param name="metadataNode">The metadata node.</param>
        private void ShowMetadataNodeProperties(MetadataNode metadataNode)
        {
            object selectedObject = metadataNode;

#if !REMOVE_DICOM_PLUGIN
            // if selected metadata tree node is DICOM metadata
            if (metadataNode is DicomDataElementMetadata)
            {
                DicomDataElementMetadataConverter metadataConverter =
                    new DicomDataElementMetadataConverter((DicomDataElementMetadata)metadataNode);
                metadataConverter.CanEdit = CanEdit;
                selectedObject = metadataConverter;
            }
#endif

            nodePropertyGrid.SelectedObject = selectedObject;
        }

        #endregion

        #endregion

    }
}
