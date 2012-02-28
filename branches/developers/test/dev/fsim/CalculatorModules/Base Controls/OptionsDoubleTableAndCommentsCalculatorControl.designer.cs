namespace CalculatorModules.Base_Controls
{
    partial class fsOptionsDoubleTableAndCommentsCalculatorControl
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
            this.dataGrid = new fmDataGrid.fmDataGrid();
            this.ParameterColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.tablesSplitContainer = new System.Windows.Forms.SplitContainer();
            this.materialParametersDataGrid = new fmDataGrid.fmDataGrid();
            this.MatrialParameterColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialValueColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.leftTopPanel.SuspendLayout();
            this.tablesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.tablesSplitContainer.Panel1.SuspendLayout();
            this.tablesSplitContainer.Panel2.SuspendLayout();
            this.tablesSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.materialParametersDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // leftTopPanel
            // 
            this.leftTopPanel.Size = new System.Drawing.Size(464, 48);
            // 
            // calculationOptionsPanel
            // 
            this.calculationOptionsPanel.Size = new System.Drawing.Size(413, 48);
            // 
            // tablesPanel
            // 
            this.tablesPanel.Controls.Add(this.tablesSplitContainer);
            this.tablesPanel.Size = new System.Drawing.Size(464, 357);
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AllowUserToResizeRows = false;
            this.dataGrid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ParameterColumn,
            this.ValueColumn});
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dataGrid.HighLightCurrentRow = false;
            this.dataGrid.Location = new System.Drawing.Point(0, 0);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.RowTemplate.Height = 18;
            this.dataGrid.Size = new System.Drawing.Size(233, 357);
            this.dataGrid.TabIndex = 0;
            // 
            // ParameterColumn
            // 
            this.ParameterColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ParameterColumn.HeaderText = "Parameter";
            this.ParameterColumn.Name = "ParameterColumn";
            this.ParameterColumn.ReadOnly = true;
            // 
            // ValueColumn
            // 
            this.ValueColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ValueColumn.FillWeight = 50F;
            this.ValueColumn.HeaderText = "Value";
            this.ValueColumn.Name = "ValueColumn";
            // 
            // tablesSplitContainer
            // 
            this.tablesSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablesSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.tablesSplitContainer.Name = "tablesSplitContainer";
            // 
            // tablesSplitContainer.Panel1
            // 
            this.tablesSplitContainer.Panel1.Controls.Add(this.materialParametersDataGrid);
            // 
            // tablesSplitContainer.Panel2
            // 
            this.tablesSplitContainer.Panel2.Controls.Add(this.dataGrid);
            this.tablesSplitContainer.Size = new System.Drawing.Size(464, 357);
            this.tablesSplitContainer.SplitterDistance = 227;
            this.tablesSplitContainer.TabIndex = 1;
            // 
            // materialParametersDataGrid
            // 
            this.materialParametersDataGrid.AllowUserToAddRows = false;
            this.materialParametersDataGrid.AllowUserToDeleteRows = false;
            this.materialParametersDataGrid.AllowUserToResizeRows = false;
            this.materialParametersDataGrid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.materialParametersDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.materialParametersDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.materialParametersDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MatrialParameterColumn,
            this.MaterialValueColumn});
            this.materialParametersDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialParametersDataGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.materialParametersDataGrid.HighLightCurrentRow = false;
            this.materialParametersDataGrid.Location = new System.Drawing.Point(0, 0);
            this.materialParametersDataGrid.Name = "materialParametersDataGrid";
            this.materialParametersDataGrid.RowHeadersVisible = false;
            this.materialParametersDataGrid.RowTemplate.Height = 18;
            this.materialParametersDataGrid.Size = new System.Drawing.Size(227, 357);
            this.materialParametersDataGrid.TabIndex = 0;
            // 
            // MatrialParameterColumn
            // 
            this.MatrialParameterColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MatrialParameterColumn.HeaderText = "Parameter";
            this.MatrialParameterColumn.Name = "MatrialParameterColumn";
            this.MatrialParameterColumn.ReadOnly = true;
            // 
            // MaterialValueColumn
            // 
            this.MaterialValueColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MaterialValueColumn.FillWeight = 50F;
            this.MaterialValueColumn.HeaderText = "Value";
            this.MaterialValueColumn.Name = "MaterialValueColumn";
            // 
            // fsOptionsDoubleTableAndCommentsCalculatorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "fsOptionsDoubleTableAndCommentsCalculatorControl";
            this.Size = new System.Drawing.Size(464, 405);
            this.leftTopPanel.ResumeLayout(false);
            this.tablesPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.tablesSplitContainer.Panel1.ResumeLayout(false);
            this.tablesSplitContainer.Panel2.ResumeLayout(false);
            this.tablesSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.materialParametersDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn ValueColumn;
        protected fmDataGrid.fmDataGrid dataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatrialParameterColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn MaterialValueColumn;
        protected fmDataGrid.fmDataGrid materialParametersDataGrid;
        protected System.Windows.Forms.SplitContainer tablesSplitContainer;


    }
}
