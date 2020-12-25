namespace DemosCommonCode.Imaging
{
    partial class MetadataEditorForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.metadataTreeView = new DemosCommonCode.Imaging.MetadataTreeView();
            this.metadataNodeProperties = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.nodePropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.panel5 = new System.Windows.Forms.Panel();
            this.addNodeButton = new System.Windows.Forms.Button();
            this.loadBinaryValueFromFileButton = new System.Windows.Forms.Button();
            this.saveBinaryValueToFileButton = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.methodsComboBox = new System.Windows.Forms.ComboBox();
            this.executeButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonOk = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.metadataNodeProperties.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 562);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.splitContainer1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(784, 522);
            this.panel3.TabIndex = 1;
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
            this.splitContainer1.Panel2.Controls.Add(this.metadataNodeProperties);
            this.splitContainer1.Size = new System.Drawing.Size(784, 522);
            this.splitContainer1.SplitterDistance = 377;
            this.splitContainer1.TabIndex = 1;
            // 
            // metadataTreeView
            // 
            this.metadataTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metadataTreeView.Location = new System.Drawing.Point(0, 0);
            this.metadataTreeView.Name = "metadataTreeView";
            this.metadataTreeView.RootMetadataNode = null;
            this.metadataTreeView.SelectedMetadataNode = null;
            this.metadataTreeView.Size = new System.Drawing.Size(377, 522);
            this.metadataTreeView.TabIndex = 0;
            this.metadataTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.metadataTreeView_AfterSelect);
            // 
            // metadataNodeProperties
            // 
            this.metadataNodeProperties.Controls.Add(this.panel4);
            this.metadataNodeProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metadataNodeProperties.Location = new System.Drawing.Point(0, 0);
            this.metadataNodeProperties.Name = "metadataNodeProperties";
            this.metadataNodeProperties.Size = new System.Drawing.Size(403, 522);
            this.metadataNodeProperties.TabIndex = 0;
            this.metadataNodeProperties.TabStop = false;
            this.metadataNodeProperties.Text = "groupBox1";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 16);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(397, 503);
            this.panel4.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.nodePropertyGrid);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 124);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(3);
            this.panel6.Size = new System.Drawing.Size(397, 379);
            this.panel6.TabIndex = 1;
            // 
            // nodePropertyGrid
            // 
            this.nodePropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nodePropertyGrid.Location = new System.Drawing.Point(3, 3);
            this.nodePropertyGrid.Name = "nodePropertyGrid";
            this.nodePropertyGrid.Size = new System.Drawing.Size(391, 373);
            this.nodePropertyGrid.TabIndex = 0;
            this.nodePropertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.nodePropertyGrid_PropertyValueChanged);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.addNodeButton);
            this.panel5.Controls.Add(this.loadBinaryValueFromFileButton);
            this.panel5.Controls.Add(this.saveBinaryValueToFileButton);
            this.panel5.Controls.Add(this.buttonDelete);
            this.panel5.Controls.Add(this.methodsComboBox);
            this.panel5.Controls.Add(this.executeButton);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(397, 124);
            this.panel5.TabIndex = 0;
            // 
            // addNodeButton
            // 
            this.addNodeButton.Location = new System.Drawing.Point(10, 63);
            this.addNodeButton.Name = "addNodeButton";
            this.addNodeButton.Size = new System.Drawing.Size(115, 23);
            this.addNodeButton.TabIndex = 9;
            this.addNodeButton.Text = "Add Node...";
            this.addNodeButton.UseVisualStyleBackColor = true;
            this.addNodeButton.Visible = false;
            this.addNodeButton.Click += new System.EventHandler(this.addNewNodeToSelectedNodeButton_Click);
            // 
            // loadBinaryValueFromFileButton
            // 
            this.loadBinaryValueFromFileButton.Location = new System.Drawing.Point(132, 91);
            this.loadBinaryValueFromFileButton.Name = "loadBinaryValueFromFileButton";
            this.loadBinaryValueFromFileButton.Size = new System.Drawing.Size(129, 23);
            this.loadBinaryValueFromFileButton.TabIndex = 5;
            this.loadBinaryValueFromFileButton.Text = "Load value from file...";
            this.loadBinaryValueFromFileButton.UseVisualStyleBackColor = true;
            this.loadBinaryValueFromFileButton.Click += new System.EventHandler(this.loadBinaryValueFromFileButton_Click);
            // 
            // saveBinaryValueToFileButton
            // 
            this.saveBinaryValueToFileButton.Location = new System.Drawing.Point(10, 91);
            this.saveBinaryValueToFileButton.Name = "saveBinaryValueToFileButton";
            this.saveBinaryValueToFileButton.Size = new System.Drawing.Size(115, 23);
            this.saveBinaryValueToFileButton.TabIndex = 4;
            this.saveBinaryValueToFileButton.Text = "Save value to file...";
            this.saveBinaryValueToFileButton.UseVisualStyleBackColor = true;
            this.saveBinaryValueToFileButton.Click += new System.EventHandler(this.saveBinaryValueToFileButton_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(10, 6);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(115, 23);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "Delete This Node";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // methodsComboBox
            // 
            this.methodsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.methodsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.methodsComboBox.FormattingEnabled = true;
            this.methodsComboBox.Location = new System.Drawing.Point(132, 35);
            this.methodsComboBox.Name = "methodsComboBox";
            this.methodsComboBox.Size = new System.Drawing.Size(255, 21);
            this.methodsComboBox.TabIndex = 1;
            // 
            // executeButton
            // 
            this.executeButton.Location = new System.Drawing.Point(10, 34);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(115, 23);
            this.executeButton.TabIndex = 0;
            this.executeButton.Text = "Execute";
            this.executeButton.UseVisualStyleBackColor = true;
            this.executeButton.Click += new System.EventHandler(this.executeButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonOk);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 522);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 40);
            this.panel2.TabIndex = 0;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(699, 9);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "All files|*.*";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "All files|*.*";
            // 
            // MetadataEditorForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.panel1);
            this.MinimizeBox = false;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "MetadataEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MetadataEditorForm";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.metadataNodeProperties.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.GroupBox metadataNodeProperties;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox methodsComboBox;
        private System.Windows.Forms.Button executeButton;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button loadBinaryValueFromFileButton;
        private System.Windows.Forms.Button saveBinaryValueToFileButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button addNodeButton;
        protected System.Windows.Forms.PropertyGrid nodePropertyGrid;
        private MetadataTreeView metadataTreeView;
    }
}
