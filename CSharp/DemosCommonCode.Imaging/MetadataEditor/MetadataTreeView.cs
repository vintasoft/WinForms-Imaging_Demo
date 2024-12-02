using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Vintasoft.Imaging.Metadata;


namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A control that allows to view the metadata tree.
    /// </summary>
    public partial class MetadataTreeView : TreeView
    {

        #region Fields

        /// <summary>
        /// The dictionary: metadata node => tree node.
        /// </summary>
        Dictionary<MetadataNode, TreeNode> _metadataNodeToTreeNode =
            new Dictionary<MetadataNode, TreeNode>();

        /// <summary>
        /// The dictionary: tree node => metadata node.
        /// </summary>
        Dictionary<TreeNode, MetadataNode> _treeNodeToMetadataNode =
            new Dictionary<TreeNode, MetadataNode>();

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MetadataTreeView"/> class.
        /// </summary>
        public MetadataTreeView()
        {
            InitializeComponent();
        }

        #endregion



        #region Properties

        MetadataNode _root;
        /// <summary>
        /// Gets or sets the root metadata node.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public MetadataNode RootMetadataNode
        {
            get
            {
                return _root;
            }
            set
            {
                _root = value;
                FillMetadataTree(_root);

                if (Nodes.Count > 0)
                    SelectedNode = Nodes[0];

                UpdateNodeStyle(SelectedNode, true, false);
            }
        }

        /// <summary>
        /// Gets or sets the selected metadata node.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public MetadataNode SelectedMetadataNode
        {
            get
            {
                if (SelectedNode == null)
                    return null;

                return _treeNodeToMetadataNode[SelectedNode];
            }
            set
            {
                TreeNode node = null;

                if (value != null)
                {
                    if (!_metadataNodeToTreeNode.TryGetValue(value, out node))
                        node = null;
                }

                if (SelectedNode != node)
                    SelectedNode = node;
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Updates the node.
        /// </summary>
        /// <param name="node">The node.</param>
        public void UpdateNode(MetadataNode node)
        {
            if (node == null)
                return;

            TreeNode treeNode = null;
            if (_metadataNodeToTreeNode.TryGetValue(node, out treeNode))
                UpdateNode(treeNode);
        }

        /// <summary>
        /// Updates the node.
        /// </summary>
        /// <param name="node">The node.</param>
        public void UpdateNode(TreeNode node)
        {
            if (node == null)
                return;

            // get metadata of selected node
            MetadataNode selectedNodeMetadata = null;
            // metadata of next node
            MetadataNode nextNodeMetadata = null;
            // metadata of previous node
            MetadataNode prevNodeMetadata = null;
            // get parent node
            TreeNode parent = null;

            // get expanded nodes
            MetadataNode[] expandedNodes = GetExpandedNodes();


            if (SelectedNode != null)
            {
                // get metadata of selected node
                selectedNodeMetadata = _treeNodeToMetadataNode[SelectedNode];

                // metadata of next node
                if (SelectedNode.NextNode != null)
                    nextNodeMetadata = _treeNodeToMetadataNode[SelectedNode.NextNode];

                // metadata of previous node
                if (SelectedNode.PrevNode != null)
                    prevNodeMetadata = _treeNodeToMetadataNode[SelectedNode.PrevNode];

                // get parent node
                parent = SelectedNode.Parent;
            }


            // begin update
            BeginUpdate();

            // remove specified node children
            Remove(node.Nodes);

            // update specified node style
            UpdateNodeStyle(node, true, false);

            // add children to specified node
            MetadataNode metadataNode = _treeNodeToMetadataNode[node];
            foreach (MetadataNode childNode in metadataNode)
                FillMetadataTree(node.Nodes, childNode);


            // restore selected node

            SelectedMetadataNode = selectedNodeMetadata;
            if (SelectedNode == null && nextNodeMetadata != null)
                SelectedMetadataNode = nextNodeMetadata;
            if (SelectedNode == null && prevNodeMetadata != null)
                SelectedMetadataNode = prevNodeMetadata;
            if (SelectedNode == null && parent != null)
                SelectedNode = parent;

            ExpandNodes(expandedNodes);

            // end update
            EndUpdate();
        }

        #endregion


        #region PROTECTED

        /// <summary>
        /// Returns the metadata node name.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>
        /// The metadata node name.
        /// </returns>
        protected virtual string GetMetadataNodeName(MetadataNode node)
        {
            return node.Name;
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// Fills the metadata tree.
        /// </summary>
        /// <param name="metadataTree">The node of metadata.</param>
        private void FillMetadataTree(MetadataNode metadataTree)
        {
            BeginUpdate();

            // clear tree view
            Nodes.Clear();
            // add nodes to tree view
            FillMetadataTree(Nodes, metadataTree);

            EndUpdate();
        }

        /// <summary>
        /// Updates the node style.
        /// </summary>
        /// <param name="treeNode">The tree node.</param>
        /// <param name="updateParent">A value indicating whether parent must be updated.</param>
        /// <param name="updateChildren">A value indicating whether children must be updated.</param>
        private void UpdateNodeStyle(TreeNode treeNode, bool updateParent, bool updateChildren)
        {
            if (treeNode == null)
                return;

            // get node of metadata
            MetadataNode metadataNode = _treeNodeToMetadataNode[treeNode];
            // node is not empty?
            bool hasValue = (metadataNode is PageMetadata) || !metadataNode.IsLeafNode || metadataNode.HasValue;
            // if node has not empty value
            if (hasValue)
            {
                // if node is changed
                if (metadataNode.IsChanged)
                {
                    if (treeNode.ForeColor != Color.DarkRed)
                        treeNode.ForeColor = Color.DarkRed;
                }
                // if node can be changed
                else if (!metadataNode.IsReadOnly && metadataNode.IsLeafNode && !(metadataNode is PageMetadata))
                {
                    if (treeNode.ForeColor != Color.Green)
                        treeNode.ForeColor = Color.Green;
                }
                else
                {
                    if (treeNode.ForeColor != Color.Black)
                        treeNode.ForeColor = Color.Black;
                }
            }
            else
            {
                if (treeNode.ForeColor != Color.Gray)
                    treeNode.ForeColor = Color.Gray;
            }

            string metadataNodeName = GetMetadataNodeName(metadataNode);
            // if text of tree node must be updated
            if (!string.Equals(treeNode.Text, metadataNodeName, StringComparison.InvariantCulture))
                // update text of thee node
                treeNode.Text = metadataNodeName;

            // if parent of tree node must be updated
            if (updateParent && treeNode.Parent != null)
                // update parent of tree node
                UpdateNodeStyle(treeNode.Parent, updateParent, updateChildren);

            // if children of tree node must be updated
            if (updateChildren)
            {
                // update children of tree node
                foreach (TreeNode node in treeNode.Nodes)
                    UpdateNodeStyle(node, updateParent, updateChildren);
            }
        }

        /// <summary>
        /// Fills the metadata tree.
        /// </summary>
        /// <param name="treeNodes">The parent node.</param>
        /// <param name="metadataNode">The node of metadata.</param>
        private void FillMetadataTree(TreeNodeCollection treeNodes, MetadataNode metadataNode)
        {
            if (metadataNode == null)
                return;

            string metadataNodeName = GetMetadataNodeName(metadataNode);

            TreeNode treeNode = treeNodes.Add(metadataNodeName);

            _metadataNodeToTreeNode.Add(metadataNode, treeNode);
            _treeNodeToMetadataNode.Add(treeNode, metadataNode);

            UpdateNodeStyle(treeNode, true, false);

            foreach (MetadataNode childNode in metadataNode)
                FillMetadataTree(treeNode.Nodes, childNode);
        }

        /// <summary>
        /// Removes the nodes of specified collection.
        /// </summary>
        /// <param name="nodes">The node collection.</param>
        private void Remove(TreeNodeCollection nodes)
        {
            for (int i = nodes.Count - 1; i >= 0; i--)
                Remove(nodes[i]);
        }

        /// <summary>
        /// Removes the specified node.
        /// </summary>
        /// <param name="node">The node for remove.</param>
        private void Remove(TreeNode node)
        {
            if (node == null)
                return;

            Remove(node.Nodes);

            MetadataNode metadataNode = _treeNodeToMetadataNode[node];
            _metadataNodeToTreeNode.Remove(metadataNode);
            _treeNodeToMetadataNode.Remove(node);

            node.Remove();
        }

        /// <summary>
        /// Returns the all expanded nodes of tree view.
        /// </summary>
        /// <returns>
        /// The expanded nodes array.
        /// </returns>
        private MetadataNode[] GetExpandedNodes()
        {
            List<MetadataNode> nodes = new List<MetadataNode>();

            foreach (TreeNode children in Nodes)
                AddExpandedNodes(children, nodes);

            return nodes.ToArray();
        }

        /// <summary>
        /// Adds the expanded nodes of the specified node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="expandedNodes">The expanded nodes.</param>
        private void AddExpandedNodes(TreeNode node, List<MetadataNode> expandedNodes)
        {
            // if specified node is expanded
            if (node.IsExpanded)
            {
                // add to list
                MetadataNode metadataNode = _treeNodeToMetadataNode[node];
                expandedNodes.Add(metadataNode);
            }

            // for each children in specified node
            foreach (TreeNode children in node.Nodes)
                AddExpandedNodes(children, expandedNodes);
        }

        /// <summary>
        /// Expands the specified nodes.
        /// </summary>
        /// <param name="nodes">The nodes.</param>
        private void ExpandNodes(params MetadataNode[] nodes)
        {
            TreeNode treeNode = null;
            foreach (MetadataNode node in nodes)
            {
                if (_metadataNodeToTreeNode.TryGetValue(node, out treeNode))
                    treeNode.Expand();
            }
        }

        #endregion

        #endregion

    }
}
