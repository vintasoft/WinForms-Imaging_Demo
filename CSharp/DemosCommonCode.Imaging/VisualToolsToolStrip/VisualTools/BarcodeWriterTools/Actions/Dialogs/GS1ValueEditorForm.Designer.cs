namespace DemosCommonCode.Barcode
{
    partial class GS1ValueEditorForm
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
            this.ApplicationIdentifierLabel = new System.Windows.Forms.Label();
            this.aiNumberComboBox = new System.Windows.Forms.ComboBox();
            this.dataContentLabel = new System.Windows.Forms.Label();
            this.aiValueTextBox = new System.Windows.Forms.TextBox();
            this.dataValueLabel = new System.Windows.Forms.Label();
            this.aiDataContentLabel = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.aiListDataGridView = new System.Windows.Forms.DataGridView();
            this.aiNumberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aiTitleColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aiValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.okButton = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.dataFormatLabel = new System.Windows.Forms.Label();
            this.aiDataFormatLabel = new System.Windows.Forms.Label();
            this.formatStructureLabel = new System.Windows.Forms.Label();
            this.formatStructureValueLabel = new System.Windows.Forms.Label();
            this.barcodePrintableValueLabel = new System.Windows.Forms.Label();
            this.gs1BarcodePrintableValueLabel = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.aiListDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ApplicationIdentifierLabel
            // 
            this.ApplicationIdentifierLabel.AutoSize = true;
            this.ApplicationIdentifierLabel.Location = new System.Drawing.Point(9, 40);
            this.ApplicationIdentifierLabel.Name = "ApplicationIdentifierLabel";
            this.ApplicationIdentifierLabel.Size = new System.Drawing.Size(102, 13);
            this.ApplicationIdentifierLabel.TabIndex = 0;
            this.ApplicationIdentifierLabel.Text = "Application Identifier";
            // 
            // aiNumberComboBox
            // 
            this.aiNumberComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.aiNumberComboBox.FormattingEnabled = true;
            this.aiNumberComboBox.Location = new System.Drawing.Point(134, 37);
            this.aiNumberComboBox.Name = "aiNumberComboBox";
            this.aiNumberComboBox.Size = new System.Drawing.Size(300, 21);
            this.aiNumberComboBox.TabIndex = 1;
            this.aiNumberComboBox.SelectedIndexChanged += new System.EventHandler(this.aiNumberComboBox_SelectedIndexChanged);
            // 
            // dataContentLabel
            // 
            this.dataContentLabel.AutoSize = true;
            this.dataContentLabel.Location = new System.Drawing.Point(9, 61);
            this.dataContentLabel.Name = "dataContentLabel";
            this.dataContentLabel.Size = new System.Drawing.Size(70, 13);
            this.dataContentLabel.TabIndex = 2;
            this.dataContentLabel.Text = "Data Content";
            // 
            // aiValueTextBox
            // 
            this.aiValueTextBox.Location = new System.Drawing.Point(134, 101);
            this.aiValueTextBox.Name = "aiValueTextBox";
            this.aiValueTextBox.Size = new System.Drawing.Size(300, 20);
            this.aiValueTextBox.TabIndex = 3;
            // 
            // dataValueLabel
            // 
            this.dataValueLabel.AutoSize = true;
            this.dataValueLabel.Location = new System.Drawing.Point(9, 101);
            this.dataValueLabel.Name = "dataValueLabel";
            this.dataValueLabel.Size = new System.Drawing.Size(60, 13);
            this.dataValueLabel.TabIndex = 4;
            this.dataValueLabel.Text = "Data Value";
            // 
            // aiDataContentLabel
            // 
            this.aiDataContentLabel.Location = new System.Drawing.Point(131, 61);
            this.aiDataContentLabel.Name = "aiDataContentLabel";
            this.aiDataContentLabel.Size = new System.Drawing.Size(427, 37);
            this.aiDataContentLabel.TabIndex = 5;
            this.aiDataContentLabel.Text = "[Data Content]";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(440, 140);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(118, 23);
            this.addButton.TabIndex = 6;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(440, 170);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(118, 23);
            this.deleteButton.TabIndex = 7;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // aiListDataGridView
            // 
            this.aiListDataGridView.AllowUserToAddRows = false;
            this.aiListDataGridView.AllowUserToDeleteRows = false;
            this.aiListDataGridView.AllowUserToResizeColumns = false;
            this.aiListDataGridView.AllowUserToResizeRows = false;
            this.aiListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.aiListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.aiNumberColumn,
            this.aiTitleColumn,
            this.aiValueColumn});
            this.aiListDataGridView.Location = new System.Drawing.Point(12, 199);
            this.aiListDataGridView.MultiSelect = false;
            this.aiListDataGridView.Name = "aiListDataGridView";
            this.aiListDataGridView.ReadOnly = true;
            this.aiListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.aiListDataGridView.Size = new System.Drawing.Size(546, 130);
            this.aiListDataGridView.TabIndex = 8;
            this.aiListDataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.aiListDataGridView_RowEnter);
            // 
            // aiNumberColumn
            // 
            this.aiNumberColumn.HeaderText = "AI";
            this.aiNumberColumn.Name = "aiNumberColumn";
            this.aiNumberColumn.ReadOnly = true;
            this.aiNumberColumn.Width = 70;
            // 
            // aiTitleColumn
            // 
            this.aiTitleColumn.HeaderText = "Data Title";
            this.aiTitleColumn.Name = "aiTitleColumn";
            this.aiTitleColumn.ReadOnly = true;
            this.aiTitleColumn.Width = 200;
            // 
            // aiValueColumn
            // 
            this.aiValueColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.aiValueColumn.HeaderText = "Value";
            this.aiValueColumn.Name = "aiValueColumn";
            this.aiValueColumn.ReadOnly = true;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(402, 335);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 9;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(483, 335);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // dataFormatLabel
            // 
            this.dataFormatLabel.AutoSize = true;
            this.dataFormatLabel.Location = new System.Drawing.Point(9, 133);
            this.dataFormatLabel.Name = "dataFormatLabel";
            this.dataFormatLabel.Size = new System.Drawing.Size(65, 13);
            this.dataFormatLabel.TabIndex = 11;
            this.dataFormatLabel.Text = "Data Format";
            // 
            // aiDataFormatLabel
            // 
            this.aiDataFormatLabel.AutoSize = true;
            this.aiDataFormatLabel.Location = new System.Drawing.Point(131, 133);
            this.aiDataFormatLabel.Name = "aiDataFormatLabel";
            this.aiDataFormatLabel.Size = new System.Drawing.Size(71, 13);
            this.aiDataFormatLabel.TabIndex = 12;
            this.aiDataFormatLabel.Text = "[Data Format]";
            // 
            // formatStructureLabel
            // 
            this.formatStructureLabel.AutoSize = true;
            this.formatStructureLabel.Location = new System.Drawing.Point(9, 155);
            this.formatStructureLabel.Name = "formatStructureLabel";
            this.formatStructureLabel.Size = new System.Drawing.Size(85, 13);
            this.formatStructureLabel.TabIndex = 13;
            this.formatStructureLabel.Text = "Format Structure";
            // 
            // formatStructureValueLabel
            // 
            this.formatStructureValueLabel.Location = new System.Drawing.Point(131, 155);
            this.formatStructureValueLabel.Name = "formatStructureValueLabel";
            this.formatStructureValueLabel.Size = new System.Drawing.Size(303, 41);
            this.formatStructureValueLabel.TabIndex = 14;
            this.formatStructureValueLabel.Text = "\'Nk\' - k numeric digits, fixed length\r\n\'N..k\' - up to k numeric digits\r\n\'X..k\' - " +
                "up to k characters ISO646";
            // 
            // barcodePrintableValueLabel
            // 
            this.barcodePrintableValueLabel.AutoSize = true;
            this.barcodePrintableValueLabel.Location = new System.Drawing.Point(9, 9);
            this.barcodePrintableValueLabel.Name = "barcodePrintableValueLabel";
            this.barcodePrintableValueLabel.Size = new System.Drawing.Size(119, 13);
            this.barcodePrintableValueLabel.TabIndex = 15;
            this.barcodePrintableValueLabel.Text = "Barcode printable value";
            // 
            // gs1BarcodePrintableValueLabel
            // 
            this.gs1BarcodePrintableValueLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.gs1BarcodePrintableValueLabel.Location = new System.Drawing.Point(134, 6);
            this.gs1BarcodePrintableValueLabel.Name = "gs1BarcodePrintableValueLabel";
            this.gs1BarcodePrintableValueLabel.ReadOnly = true;
            this.gs1BarcodePrintableValueLabel.Size = new System.Drawing.Size(300, 20);
            this.gs1BarcodePrintableValueLabel.TabIndex = 16;
            // 
            // GS1ValueEditorForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(570, 366);
            this.Controls.Add(this.gs1BarcodePrintableValueLabel);
            this.Controls.Add(this.barcodePrintableValueLabel);
            this.Controls.Add(this.formatStructureValueLabel);
            this.Controls.Add(this.formatStructureLabel);
            this.Controls.Add(this.aiDataFormatLabel);
            this.Controls.Add(this.dataFormatLabel);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.aiListDataGridView);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.aiDataContentLabel);
            this.Controls.Add(this.dataValueLabel);
            this.Controls.Add(this.aiValueTextBox);
            this.Controls.Add(this.dataContentLabel);
            this.Controls.Add(this.aiNumberComboBox);
            this.Controls.Add(this.ApplicationIdentifierLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GS1ValueEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormGS1ValueEditor";
            ((System.ComponentModel.ISupportInitialize)(this.aiListDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ApplicationIdentifierLabel;
        private System.Windows.Forms.ComboBox aiNumberComboBox;
        private System.Windows.Forms.Label dataContentLabel;
        private System.Windows.Forms.TextBox aiValueTextBox;
        private System.Windows.Forms.Label dataValueLabel;
        private System.Windows.Forms.Label aiDataContentLabel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.DataGridView aiListDataGridView;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label dataFormatLabel;
        private System.Windows.Forms.Label aiDataFormatLabel;
        private System.Windows.Forms.Label formatStructureLabel;
        private System.Windows.Forms.Label formatStructureValueLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn aiNumberColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aiTitleColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aiValueColumn;
        private System.Windows.Forms.Label barcodePrintableValueLabel;
        private System.Windows.Forms.TextBox gs1BarcodePrintableValueLabel;
    }
}