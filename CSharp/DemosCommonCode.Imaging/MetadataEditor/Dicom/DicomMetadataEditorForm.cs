﻿using System;
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

                UpdateUI();
            }
        }

        #endregion



        #region Methods

        #region PROTECTED

        /// <summary>
        /// Form is shown.
        /// </summary>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            metadataTreeView.Select();
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// Updates the user interface of this form.
        /// </summary>
        private void UpdateUI()
        {
            MetadataNode metadataNode = metadataTreeView.SelectedMetadataNode;

            bool canAddSubNode = false;

#if !REMOVE_DICOM_PLUGIN
            if (metadataNode is DicomFrameMetadata ||
                  metadataNode is DicomDataSetMetadata)
                canAddSubNode = true;

            if (metadataNode is DicomDataElementMetadata &&
                ((DicomDataElementMetadata)metadataNode).ValueRepresentation == DicomValueRepresentation.SQ)
                canAddSubNode = true; 
#endif

            addButton.Enabled = canAddSubNode;
            if (metadataNode == null)
                removeButton.Enabled = false;
            else
                removeButton.Enabled = metadataNode.CanRemove;
        }

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
                selectedObject = new DicomDataElementMetadataConverter((DicomDataElementMetadata)metadataNode);
            } 
#endif

            nodePropertyGrid.SelectedObject = selectedObject;
        }

        /// <summary>
        /// Node of tree view is selected.
        /// </summary>
        private void metadataTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            MetadataNode metadataNode = metadataTreeView.SelectedMetadataNode;

            ShowMetadataNodeProperties(metadataNode);

            string selectedNodeDescription = string.Empty;
            string addButtonText = "Add DICOM Data Element...";

            if (metadataNode != null)
            {
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
        /// Adds new metadata node to the selected metadata node.
        /// </summary>
        private void addButton_Click(object sender, EventArgs e)
        {
            MetadataNode metadataNode = metadataTreeView.SelectedMetadataNode;
            bool isMetadataNodeChanged = false;

#if !REMOVE_DICOM_PLUGIN
            if (metadataNode is DicomDataElementMetadata)
            {
                DicomDataElementMetadata node = (DicomDataElementMetadata)metadataNode;

                node.AddChild();
                isMetadataNodeChanged = true;
            }
            else
            {
                MetadataNode node = (MetadataNode)metadataNode;

                using (AddDicomDataElementForm dialog = new AddDicomDataElementForm(node))
                {
                    dialog.StartPosition = FormStartPosition.CenterParent;
                    dialog.Owner = this;
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        isMetadataNodeChanged = true;
                    }
                }
            } 
#endif

            if (isMetadataNodeChanged)
            {
                metadataTreeView.UpdateNode(metadataNode);
                metadataTreeView.Focus();

                treeViewSearchControl1.ResetSearchResult();
            }
        }

        /// <summary>
        /// Removes the selected metadata node.
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

        #endregion

    }
}
