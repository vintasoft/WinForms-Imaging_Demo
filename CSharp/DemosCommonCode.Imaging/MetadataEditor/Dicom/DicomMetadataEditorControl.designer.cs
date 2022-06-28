
namespace DemosCommonCode.Imaging
{
    partial class DicomMetadataEditorControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.metadataTreeView = new DemosCommonCode.Imaging.DicomMetadataTreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.treeViewSearchControl1 = new DemosCommonCode.CustomControls.TreeViewSearchControl();
            this.selectedNodeGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.removeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.nodePropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.selectedNodeGroupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.metadataTreeView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.selectedNodeGroupBox);
            this.splitContainer1.Size = new System.Drawing.Size(803, 516);
            this.splitContainer1.SplitterDistance = 384;
            this.splitContainer1.TabIndex = 3;
            // 
            // metadataTreeView
            // 
            this.metadataTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metadataTreeView.Location = new System.Drawing.Point(3, 3);
            this.metadataTreeView.Name = "metadataTreeView";
            this.metadataTreeView.RootMetadataNode = null;
            this.metadataTreeView.SelectedMetadataNode = null;
            this.metadataTreeView.Size = new System.Drawing.Size(378, 510);
            this.metadataTreeView.TabIndex = 0;
            this.metadataTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.metadataTreeView_AfterSelect);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.treeViewSearchControl1);
            this.groupBox1.Location = new System.Drawing.Point(0, 461);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 52);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Data Element";
            // 
            // treeViewSearchControl1
            // 
            this.treeViewSearchControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewSearchControl1.Location = new System.Drawing.Point(6, 16);
            this.treeViewSearchControl1.Margin = new System.Windows.Forms.Padding(0);
            this.treeViewSearchControl1.Name = "treeViewSearchControl1";
            this.treeViewSearchControl1.Size = new System.Drawing.Size(397, 25);
            this.treeViewSearchControl1.TabIndex = 0;
            this.treeViewSearchControl1.TreeView = this.metadataTreeView;
            // 
            // selectedNodeGroupBox
            // 
            this.selectedNodeGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectedNodeGroupBox.Controls.Add(this.tableLayoutPanel1);
            this.selectedNodeGroupBox.Controls.Add(this.nodePropertyGrid);
            this.selectedNodeGroupBox.Location = new System.Drawing.Point(0, 0);
            this.selectedNodeGroupBox.Name = "selectedNodeGroupBox";
            this.selectedNodeGroupBox.Size = new System.Drawing.Size(412, 455);
            this.selectedNodeGroupBox.TabIndex = 1;
            this.selectedNodeGroupBox.TabStop = false;
            this.selectedNodeGroupBox.Text = "<selected node>";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.removeButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.addButton, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(394, 30);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // removeButton
            // 
            this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.removeButton.Location = new System.Drawing.Point(200, 3);
            this.removeButton.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(194, 23);
            this.removeButton.TabIndex = 2;
            this.removeButton.Text = "Delete This Node";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton.Location = new System.Drawing.Point(0, 3);
            this.addButton.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(194, 23);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add DICOM Data Element...";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // nodePropertyGrid
            // 
            this.nodePropertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nodePropertyGrid.Location = new System.Drawing.Point(6, 55);
            this.nodePropertyGrid.Name = "nodePropertyGrid";
            this.nodePropertyGrid.Size = new System.Drawing.Size(397, 397);
            this.nodePropertyGrid.TabIndex = 0;
            // 
            // DicomMetadataEditorControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.splitContainer1);
            this.Name = "DicomMetadataEditorControl";
            this.Size = new System.Drawing.Size(803, 516);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.selectedNodeGroupBox.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DicomMetadataTreeView metadataTreeView;
        private System.Windows.Forms.GroupBox groupBox1;
        private CustomControls.TreeViewSearchControl treeViewSearchControl1;
        private System.Windows.Forms.GroupBox selectedNodeGroupBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.PropertyGrid nodePropertyGrid;
    }
}