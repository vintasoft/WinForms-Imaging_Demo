using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DemosCommonCode.CustomControls
{
    /// <summary>
    /// A control that allows to search <see cref="System.Windows.Forms.TreeNode"/> in the <see cref="System.Windows.Forms.TreeView"/>.
    /// </summary>
    public partial class TreeViewSearchControl : UserControl
    {

        #region Fields

        /// <summary>
        /// The found tree nodes.
        /// </summary>
        List<TreeNode> _foundTreeNodes = null;

        /// <summary>
        /// The current tree node index of searched tree nodes.
        /// </summary>
        int _currentSelectedNodeIndex = -1;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeViewSearchControl"/> class.
        /// </summary>
        public TreeViewSearchControl()
        {
            InitializeComponent();

            ResetSearchResult();
        }

        #endregion



        #region Properties

        TreeView _treeView = null;
        /// <summary> 
        /// Gets or sets the <see cref="System.Windows.Forms.TreeView"/> for search in <see cref="System.Windows.Forms.TreeNode"/>.
        /// </summary>
        /// <value>
        /// Default value is <b>null</b>.
        /// </value>
        public TreeView TreeView
        {
            get
            {
                return _treeView;
            }
            set
            {
                if (_treeView != value)
                {
                    _treeView = value;

                    ResetSearchResult();
                }
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Resets the searched result. 
        /// </summary>
        public void ResetSearchResult()
        {
            _foundTreeNodes = null;
            _currentSelectedNodeIndex = -1;
        }

        #endregion


        #region PRIVATE

        #region UI

        /// <summary>
        /// Handles the Click event of FindButton object.
        /// </summary>
        private void findButton_Click(object sender, EventArgs e)
        {
            // search nodes
            SearchNodes();
            // select first searched node
            SelectNextSearchedNode();
        }

        /// <summary>
        /// Handles the TextChanged event of FindPatternTextBox object.
        /// </summary>
        private void findPatternTextBox_TextChanged(object sender, EventArgs e)
        {
            // remove search result
            ResetSearchResult();
        }

        /// <summary>
        /// Handles the KeyUp event of FindPatternTextBox object.
        /// </summary>
        private void findPatternTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            // if search nodes must be started
            if (e.Modifiers == Keys.None && e.KeyCode == Keys.Enter)
            {
                // search nodes
                SearchNodes();
                // select first searched node
                SelectNextSearchedNode();
            }
        }

        #endregion


        /// <summary>
        /// Selects the next searched node.
        /// </summary>
        private void SelectNextSearchedNode()
        {
            if (TreeView == null)
                return;

            // if nodes are not found
            if (_foundTreeNodes == null || _foundTreeNodes.Count == 0)
                return;

            // change currently selected node index
            _currentSelectedNodeIndex++;

            bool isAllNodesSelected = false;
            // if index of currently selected node is greater than count of found nodes
            if (_currentSelectedNodeIndex >= _foundTreeNodes.Count)
            {
                _currentSelectedNodeIndex = 0;
                isAllNodesSelected = true;
            }

            // update selected node
            TreeView.SelectedNode = _foundTreeNodes[_currentSelectedNodeIndex];
            // move focus to the tree view
            TreeView.Focus();

            // if all nodes are selected
            if (isAllNodesSelected)
            {
                MessageBox.Show(
                    "Find reached the starting point of the search.",
                    "Tree View Search Control",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Searches the tree nodes.
        /// </summary>
        private void SearchNodes()
        {
            if (TreeView == null)
                return;

            // if nodes are not found
            if (_foundTreeNodes == null)
            {
                // get search pattern
                string searchPattern = findPatternTextBox.Text;

                // if pattern is empty
                if (string.IsNullOrEmpty(searchPattern))
                    return;

                // create new search result list
                _foundTreeNodes = new List<TreeNode>();

                // search nodes
                SearchNodes(TreeView.Nodes, searchPattern.ToLowerInvariant(), _foundTreeNodes);

                // if nodes are not found
                if (_foundTreeNodes.Count == 0)
                {
                    MessageBox.Show(
                        string.Format("The specified text was not found:\r\n{0}", searchPattern),
                        "Tree View Search Control",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// Search the tree node in the specified tree node collection.
        /// </summary>
        /// <param name="nodes">The collection to search.</param>
        /// <param name="searchPattern">The search pattern.</param>
        /// <param name="searchedNodes">The searched nodes list.</param>
        private void SearchNodes(
            TreeNodeCollection nodes,
            string searchPattern,
            List<TreeNode> searchedNodes)
        {
            foreach (TreeNode node in nodes)
            {
                string nodeName = node.Text.ToLowerInvariant();
                if (nodeName.Contains(searchPattern))
                    searchedNodes.Add(node);

                SearchNodes(node.Nodes, searchPattern, searchedNodes);
            }
        }

        #endregion

        #endregion

    }
}
