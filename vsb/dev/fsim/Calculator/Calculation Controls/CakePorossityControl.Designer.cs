namespace Calculator.Calculation_Controls
{
    sealed partial class fsCakePorossityControl
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
            this.machineTypePanel = new System.Windows.Forms.Panel();
            this.dataGrid = new fmDataGrid.fmDataGrid();
            this.panel3 = new System.Windows.Forms.Panel();
            this.saturationComboBox = new System.Windows.Forms.ComboBox();
            this.machineTypeComboBox = new System.Windows.Forms.ComboBox();
            this.saltContentComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ParameterColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.machineTypePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // machineTypePanel
            // 
            this.machineTypePanel.Controls.Add(this.dataGrid);
            this.machineTypePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.machineTypePanel.Location = new System.Drawing.Point(0, 101);
            this.machineTypePanel.Name = "machineTypePanel";
            this.machineTypePanel.Size = new System.Drawing.Size(280, 265);
            this.machineTypePanel.TabIndex = 2;
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AllowUserToResizeRows = false;
            this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ParameterColumn,
            this.ValueColumn});
            this.dataGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dataGrid.HighLightCurrentRow = false;
            this.dataGrid.Location = new System.Drawing.Point(8, 0);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.RowTemplate.Height = 18;
            this.dataGrid.Size = new System.Drawing.Size(272, 265);
            this.dataGrid.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.saturationComboBox);
            this.panel3.Controls.Add(this.machineTypeComboBox);
            this.panel3.Controls.Add(this.saltContentComboBox);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(280, 101);
            this.panel3.TabIndex = 1;
            // 
            // saturationComboBox
            // 
            this.saturationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.saturationComboBox.FormattingEnabled = true;
            this.saturationComboBox.Location = new System.Drawing.Point(115, 3);
            this.saturationComboBox.Name = "saturationComboBox";
            this.saturationComboBox.Size = new System.Drawing.Size(162, 21);
            this.saturationComboBox.TabIndex = 6;
            // 
            // machineTypeComboBox
            // 
            this.machineTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.machineTypeComboBox.FormattingEnabled = true;
            this.machineTypeComboBox.Location = new System.Drawing.Point(115, 35);
            this.machineTypeComboBox.Name = "machineTypeComboBox";
            this.machineTypeComboBox.Size = new System.Drawing.Size(162, 21);
            this.machineTypeComboBox.TabIndex = 5;
            // 
            // saltContentComboBox
            // 
            this.saltContentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.saltContentComboBox.FormattingEnabled = true;
            this.saltContentComboBox.Location = new System.Drawing.Point(115, 67);
            this.saltContentComboBox.Name = "saltContentComboBox";
            this.saltContentComboBox.Size = new System.Drawing.Size(162, 21);
            this.saltContentComboBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Salt content:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Machine Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Saturation:";
            // 
            // ParameterColumn
            // 
            this.ParameterColumn.HeaderText = "Parameter";
            this.ParameterColumn.Name = "ParameterColumn";
            this.ParameterColumn.ReadOnly = true;
            this.ParameterColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ParameterColumn.Width = 260;
            // 
            // ValueColumn
            // 
            this.ValueColumn.HeaderText = "Value";
            this.ValueColumn.Name = "ValueColumn";
            this.ValueColumn.Width = 50;
            // 
            // fsCakePorossityControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.machineTypePanel);
            this.Controls.Add(this.panel3);
            this.Name = "fsCakePorossityControl";
            this.Size = new System.Drawing.Size(330, 366);
            this.machineTypePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel machineTypePanel;
        private System.Windows.Forms.Panel panel3;
        private fmDataGrid.fmDataGrid dataGrid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox saturationComboBox;
        private System.Windows.Forms.ComboBox machineTypeComboBox;
        private System.Windows.Forms.ComboBox saltContentComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn ValueColumn;
    }
}
