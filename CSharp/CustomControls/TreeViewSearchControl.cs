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
        /// The searched tree nodes.
        /// </summary>
        List<TreeNode> _searchedTreeNodes = null;

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
            _searchedTreeNodes = null;
            _currentSelectedNodeIndex = -1;
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// The "Find" button is clicked.
        /// </summary>
        private void findButton_Click(object sender, EventArgs e)
        {
            SearchNodes();

            SelectNextSearchedNode();
        }

        /// <summary>
        /// The search pattern text is changed.
        /// </summary>
        private void findPatternTextBox_TextChanged(object sender, EventArgs e)
        {
            ResetSearchResult();
        }

        /// <summary>
        /// The key is pressed in the "Find pattern" text box.
        /// </summary>
        private void findPatternTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.None && e.KeyCode == Keys.Enter)
            {
                SearchNodes();

                SelectNextSearchedNode();
            }
        }

        /// <summary>
        /// Selects the next searched node.
        /// </summary>
        private void SelectNextSearchedNode()
        {
            if (TreeView == null)
                return;

            if (_searchedTreeNodes == null ||
                _searchedTreeNodes.Count == 0)
                return;

            _currentSelectedNodeIndex++;

            bool isAllNodesSelected = false;

            if (_currentSelectedNodeIndex >= _searchedTreeNodes.Count)
            {
                _currentSelectedNodeIndex = 0;
                isAllNodesSelected = true;
            }

            TreeView.SelectedNode = _searchedTreeNodes[_currentSelectedNodeIndex];

            TreeView.Focus();

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
        /// Search the tree nodes.
        /// </summary>
        private void SearchNodes()
        {
            if (TreeView == null)
                return;

            if (_searchedTreeNodes == null)
            {
                string searchPattern = findPatternTextBox.Text;

                if (string.IsNullOrEmpty(searchPattern))
                    return;

                _searchedTreeNodes = new List<TreeNode>();

                SearchNodes(TreeView.Nodes, searchPattern.ToLowerInvariant(), _searchedTreeNodes);

                if (_searchedTreeNodes.Count == 0)
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
        /// <param name="nodes">The collection for search.</param>
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
