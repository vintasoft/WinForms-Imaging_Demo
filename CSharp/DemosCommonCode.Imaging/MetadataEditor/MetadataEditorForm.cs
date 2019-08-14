using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Codecs.ImageFiles.Tiff;
using Vintasoft.Imaging.Metadata;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A form that allows to edit an image metadata.
    /// </summary>
    public partial class MetadataEditorForm : Form
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MetadataEditorForm"/> class.
        /// </summary>
        public MetadataEditorForm()
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
        /// Adds new metadata node to the selected metadata node.
        /// </summary>
        /// <returns>
        /// <b>True</b> if new metadata node is added to the selected metadata node successfully; otherwise, <b>false</b>.
        /// </returns>
        private bool AddMetadataNode()
        {
            TiffIfdMetadata node = (TiffIfdMetadata)metadataTreeView.SelectedMetadataNode;
            int tagId;
            object tagValue = null;
            if (GetTiffTagInfo(out tagId, out tagValue))
            {
                node.SetTiffTagMetadata(tagId, tagValue);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Determines whether this form can add new metadata nodes to the specified metadata node.
        /// </summary>
        /// <param name="metadataNode">The metadata node.</param>
        /// <returns>
        /// <b>True</b> if this form can add new metadata nodes to the specified metadata node; otherwise, <b>false</b>.
        /// </returns>
        private bool CanAddMetadataNode(MetadataNode metadataNode)
        {
            if (metadataNode != null)
            {
                if (metadataNode is TiffIfdMetadata)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Determines whether the specified metadata node can be removed.
        /// </summary>
        /// <param name="metadataNode">The metadata node.</param>
        /// <returns>
        /// <b>True</b> - the metadata node can be removed; otherwise, <b>false</b>.
        /// </returns>
        private bool CanRemoveMetadataNode(MetadataNode metadataNode)
        {
            if (metadataNode != null)
            {
                return metadataNode.CanRemove;
            }

            return false;
        }

        /// <summary>
        /// Shows the specified metadata node properties in <see cref="PropertyGrid"/>.
        /// </summary>
        /// <param name="metadataNode">The metadata node.</param>
        private void ShowMetadataNodeProperties(MetadataNode metadataNode)
        {
            // if selected metadata tree node is TIFF metadata
            if (metadataNode is TiffTagMetadata)
                nodePropertyGrid.SelectedObject = new TiffTagMetadataConverter((TiffTagMetadata)metadataNode);
            else
                nodePropertyGrid.SelectedObject = metadataNode;
        }

        /// <summary>
        /// Returns the methods of specified metadata node.
        /// </summary>
        /// <param name="metadataNode">The metadata node.</param>
        private MethodExecutor[] GetExecuteMethods(MetadataNode metadataNode)
        {
            List<MethodExecutor> executeMethods = new List<MethodExecutor>();

            // get methods of node
            MethodInfo[] methods = metadataNode.GetType().GetMethods();
            for (int i = 0; i < methods.Length; i++)
            {
                // if method can change the node
                if (methods[i].Name.StartsWith("Create") ||
                    methods[i].Name.StartsWith("Add") ||
                    methods[i].Name.StartsWith("Remove"))
                {
                    // if method does not have parameters
                    if (methods[i].GetParameters().Length == 0)
                        executeMethods.Add(new MethodExecutor(metadataNode, methods[i]));
                }
            }

            return executeMethods.ToArray();
        }

        /// <summary>
        /// Updates the user interface of this form.
        /// </summary>
        private void UpdateUI()
        {
            string title = "Metadata Editor";
            if (_image != null && _image.SourceInfo.Stream is FileStream)
            {
                title = string.Concat(title, string.Format(": {0}, page {1}",
                       Path.GetFileName(((FileStream)_image.SourceInfo.Stream).Name),
                       _image.SourceInfo.PageIndex + 1));
            }
            if (Text != title)
                Text = title;

            MetadataNode selectedMetadataNode = metadataTreeView.SelectedMetadataNode;
            if (selectedMetadataNode != null)
            {
                bool isBinaryArrayData = selectedMetadataNode.Value is byte[] ||
                    selectedMetadataNode is AnnotationsMetadata;

                if (isBinaryArrayData && selectedMetadataNode.Value != null)
                    saveBinaryValueToFileButton.Enabled = true;
                else
                    saveBinaryValueToFileButton.Enabled = false;
                loadBinaryValueFromFileButton.Enabled = isBinaryArrayData;
            }

            string metadataNodePropertiesText = string.Empty;

            if (selectedMetadataNode != null)
            {
                metadataNodePropertiesText = string.Format("{0} ({1})", selectedMetadataNode.Name,
                    selectedMetadataNode.GetType().Name);
            }

            buttonDelete.Enabled = CanRemoveMetadataNode(selectedMetadataNode);
            addNodeButton.Visible = CanAddMetadataNode(selectedMetadataNode);
            metadataNodeProperties.Text = metadataNodePropertiesText;

            if (selectedMetadataNode != null)
            {
                UpdateMetadataNodeMethods(selectedMetadataNode);
            }

            bool hasMethods = methodsComboBox.Items.Count > 0;
            methodsComboBox.Enabled = hasMethods;
            executeButton.Enabled = hasMethods;
        }

        /// <summary>
        /// "OK" button is clicked.
        /// </summary>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Node of tree view is selected.
        /// </summary>
        private void metadataTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ShowMetadataNodeProperties(metadataTreeView.SelectedMetadataNode);

            UpdateUI();
        }

        /// <summary>
        /// Property of node is changed.
        /// </summary>
        private void nodePropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            UpdateUI();
        }

        /// <summary>
        /// "Execute method" button is clicked.
        /// </summary>
        private void executeButton_Click(object sender, EventArgs e)
        {
            if (methodsComboBox.SelectedItem != null)
            {
                // execute method
                ((MethodExecutor)methodsComboBox.SelectedItem).Execute();

                if (metadataTreeView.SelectedNode != null)
                {
                    if (metadataTreeView.SelectedNode.Parent == null)
                        metadataTreeView.UpdateNode(metadataTreeView.SelectedNode);
                    else
                        metadataTreeView.UpdateNode(metadataTreeView.SelectedNode.Parent);
                }
            }
        }

        /// <summary>
        /// Remove selected node.
        /// </summary>
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // get selected node
            MetadataNode metadataNode = metadataTreeView.SelectedMetadataNode;
            // remove selected node
            metadataNode.Parent.RemoveChild(metadataNode);

            metadataTreeView.UpdateNode(metadataNode.Parent);

            metadataTreeView.Focus();
        }

        /// <summary>
        /// Updates methods of the metadata node.
        /// </summary>
        /// <param name="metadataNode">The metadata node.</param>
        private void UpdateMetadataNodeMethods(MetadataNode metadataNode)
        {
            // clear combobox
            methodsComboBox.Items.Clear();

            // get methods to execute
            MethodExecutor[] executeMethods = GetExecuteMethods(metadataNode);

            if (executeMethods != null && executeMethods.Length != 0)
            {
                // add execute methods
                foreach (MethodExecutor executeMethod in executeMethods)
                    methodsComboBox.Items.Add(executeMethod);

                // select the first item
                methodsComboBox.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Returns the TIFF tag information.
        /// </summary>
        /// <param name="tagId">The tag identifier.</param>
        /// <param name="tagValue">The tag value.</param>
        private bool GetTiffTagInfo(out int tagId, out object tagValue)
        {
            tagId = 0;
            tagValue = (int)0;

            using (AddTiffTagForm dlg = new AddTiffTagForm())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    tagId = dlg.TagId;

                    //
                    switch (dlg.TagDataType)
                    {
                        case TiffTagDataType.Ascii:
                            tagValue = dlg.StringValue;
                            break;

                        case TiffTagDataType.Short:
                            tagValue = (ushort)dlg.IntegerValue;
                            break;
                        case TiffTagDataType.SShort:
                            tagValue = (short)dlg.IntegerValue;
                            break;

                        case TiffTagDataType.Long:
                            tagValue = (uint)dlg.IntegerValue;
                            break;
                        case TiffTagDataType.SLong:
                            tagValue = (int)dlg.IntegerValue;
                            break;

                        case TiffTagDataType.Float:
                            tagValue = (float)dlg.DoubleValue;
                            break;
                        case TiffTagDataType.Double:
                            tagValue = dlg.DoubleValue;
                            break;

                        case TiffTagDataType.Rational:
                            tagValue = new TiffRational((uint)dlg.NumeratorValue, (uint)dlg.DenominatorValue);
                            break;
                        case TiffTagDataType.SRational:
                            tagValue = new TiffSRational((int)dlg.NumeratorValue, (uint)dlg.DenominatorValue);
                            break;
                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Saves binary value to a file.
        /// </summary>
        private void saveBinaryValueToFileButton_Click(object sender, EventArgs e)
        {
            MetadataNode selectedMetadataNode = metadataTreeView.SelectedMetadataNode;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                byte[] byteArray = selectedMetadataNode.Value as byte[];
                string filePath = Path.GetFullPath(saveFileDialog.FileName);
                File.WriteAllBytes(filePath, byteArray);
            }
        }

        /// <summary>
        /// Loads binary value from a file.
        /// </summary>
        private void loadBinaryValueFromFileButton_Click(object sender, EventArgs e)
        {
            MetadataNode selectedMetadataNode = metadataTreeView.SelectedMetadataNode;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = Path.GetFullPath(openFileDialog.FileName);
                byte[] byteArray = File.ReadAllBytes(filePath);
                selectedMetadataNode.Value = byteArray;

                UpdateUI();
            }
        }

        /// <summary>
        /// Adds new node to the selected node.
        /// </summary>
        private void addNewNodeToSelectedNodeButton_Click(object sender, EventArgs e)
        {
            if (AddMetadataNode())
            {
                if (metadataTreeView.SelectedNode != null)
                    metadataTreeView.UpdateNode(metadataTreeView.SelectedNode.Parent);

                UpdateUI();
            }
        }

        #endregion

        #endregion

    }
}
