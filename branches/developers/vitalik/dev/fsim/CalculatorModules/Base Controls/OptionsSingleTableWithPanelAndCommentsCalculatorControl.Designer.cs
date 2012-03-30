namespace CalculatorModules
{
    partial class OptionsSingleTableWithPanelAndCommentsCalculatorControl
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelRight = new System.Windows.Forms.Panel();
            this.dataGridView_Result3 = new System.Windows.Forms.DataGridView();
            this.ParameterColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitsColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FeedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnderflowColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OverflowColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView_Result2 = new System.Windows.Forms.DataGridView();
            this.ParameterColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitsColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView_Result1 = new System.Windows.Forms.DataGridView();
            this.ParameterColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitsColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.dataGrid = new fsUIControls.fsParametersWithValuesTable();
            this.leftTopPanel.SuspendLayout();
            this.tablesPanel.SuspendLayout();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Result3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Result2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Result1)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // calculationOptionsPanel
            // 
            this.calculationOptionsPanel.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            // 
            // tablesPanel
            // 
            this.tablesPanel.Controls.Add(this.splitContainerMain);
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.dataGridView_Result3);
            this.panelRight.Controls.Add(this.dataGridView_Result2);
            this.panelRight.Controls.Add(this.dataGridView_Result1);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(0, 0);
            this.panelRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(520, 310);
            this.panelRight.TabIndex = 1;
            // 
            // dataGridView_Result3
            // 
            this.dataGridView_Result3.AllowUserToAddRows = false;
            this.dataGridView_Result3.AllowUserToDeleteRows = false;
            this.dataGridView_Result3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Result3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ParameterColumn3,
            this.UnitsColumn3,
            this.FeedColumn,
            this.UnderflowColumn,
            this.OverflowColumn});
            this.dataGridView_Result3.Location = new System.Drawing.Point(19, 161);
            this.dataGridView_Result3.Name = "dataGridView_Result3";
            this.dataGridView_Result3.ReadOnly = true;
            this.dataGridView_Result3.RowTemplate.Height = 24;
            this.dataGridView_Result3.Size = new System.Drawing.Size(433, 124);
            this.dataGridView_Result3.TabIndex = 2;
            // 
            // ParameterColumn3
            // 
            this.ParameterColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ParameterColumn3.HeaderText = "Parameter";
            this.ParameterColumn3.Name = "ParameterColumn3";
            this.ParameterColumn3.ReadOnly = true;
            this.ParameterColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ParameterColumn3.Width = 5;
            // 
            // UnitsColumn3
            // 
            this.UnitsColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.UnitsColumn3.HeaderText = "Units";
            this.UnitsColumn3.Name = "UnitsColumn3";
            this.UnitsColumn3.ReadOnly = true;
            this.UnitsColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UnitsColumn3.Width = 5;
            // 
            // FeedColumn
            // 
            this.FeedColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.FeedColumn.HeaderText = "Feed";
            this.FeedColumn.Name = "FeedColumn";
            this.FeedColumn.ReadOnly = true;
            this.FeedColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FeedColumn.Width = 5;
            // 
            // UnderflowColumn
            // 
            this.UnderflowColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.UnderflowColumn.HeaderText = "Underflow";
            this.UnderflowColumn.Name = "UnderflowColumn";
            this.UnderflowColumn.ReadOnly = true;
            this.UnderflowColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UnderflowColumn.Width = 5;
            // 
            // OverflowColumn
            // 
            this.OverflowColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.OverflowColumn.HeaderText = "Overflow";
            this.OverflowColumn.Name = "OverflowColumn";
            this.OverflowColumn.ReadOnly = true;
            this.OverflowColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.OverflowColumn.Width = 5;
            // 
            // dataGridView_Result2
            // 
            this.dataGridView_Result2.AllowUserToAddRows = false;
            this.dataGridView_Result2.AllowUserToDeleteRows = false;
            this.dataGridView_Result2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Result2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ParameterColumn2,
            this.UnitsColumn2,
            this.ValueColumn2});
            this.dataGridView_Result2.Location = new System.Drawing.Point(241, 21);
            this.dataGridView_Result2.Name = "dataGridView_Result2";
            this.dataGridView_Result2.ReadOnly = true;
            this.dataGridView_Result2.RowTemplate.Height = 24;
            this.dataGridView_Result2.Size = new System.Drawing.Size(211, 124);
            this.dataGridView_Result2.TabIndex = 1;
            // 
            // ParameterColumn2
            // 
            this.ParameterColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ParameterColumn2.HeaderText = "Parameter";
            this.ParameterColumn2.Name = "ParameterColumn2";
            this.ParameterColumn2.ReadOnly = true;
            this.ParameterColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ParameterColumn2.Width = 5;
            // 
            // UnitsColumn2
            // 
            this.UnitsColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.UnitsColumn2.HeaderText = "Units";
            this.UnitsColumn2.Name = "UnitsColumn2";
            this.UnitsColumn2.ReadOnly = true;
            this.UnitsColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UnitsColumn2.Width = 5;
            // 
            // ValueColumn2
            // 
            this.ValueColumn2.HeaderText = "Value";
            this.ValueColumn2.Name = "ValueColumn2";
            this.ValueColumn2.ReadOnly = true;
            this.ValueColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ValueColumn2.Width = 50;
            // 
            // dataGridView_Result1
            // 
            this.dataGridView_Result1.AllowUserToAddRows = false;
            this.dataGridView_Result1.AllowUserToDeleteRows = false;
            this.dataGridView_Result1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Result1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ParameterColumn1,
            this.UnitsColumn1,
            this.ValueColumn1});
            this.dataGridView_Result1.Location = new System.Drawing.Point(19, 21);
            this.dataGridView_Result1.Name = "dataGridView_Result1";
            this.dataGridView_Result1.ReadOnly = true;
            this.dataGridView_Result1.RowTemplate.Height = 24;
            this.dataGridView_Result1.Size = new System.Drawing.Size(216, 124);
            this.dataGridView_Result1.TabIndex = 0;
            // 
            // ParameterColumn1
            // 
            this.ParameterColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ParameterColumn1.HeaderText = "Parameter";
            this.ParameterColumn1.Name = "ParameterColumn1";
            this.ParameterColumn1.ReadOnly = true;
            this.ParameterColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ParameterColumn1.Width = 5;
            // 
            // UnitsColumn1
            // 
            this.UnitsColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.UnitsColumn1.HeaderText = "Units";
            this.UnitsColumn1.Name = "UnitsColumn1";
            this.UnitsColumn1.ReadOnly = true;
            this.UnitsColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UnitsColumn1.Width = 5;
            // 
            // ValueColumn1
            // 
            this.ValueColumn1.HeaderText = "Value";
            this.ValueColumn1.Name = "ValueColumn1";
            this.ValueColumn1.ReadOnly = true;
            this.ValueColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ValueColumn1.Width = 50;
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.dataGrid);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.panelRight);
            this.splitContainerMain.Size = new System.Drawing.Size(1049, 310);
            this.splitContainerMain.SplitterDistance = 525;
            this.splitContainerMain.TabIndex = 2;
            // 
            // dataGrid
            // 
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dataGrid.Location = new System.Drawing.Point(0, 0);
            this.dataGrid.Margin = new System.Windows.Forms.Padding(4);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(525, 310);
            this.dataGrid.TabIndex = 0;
            // 
            // OptionsSingleTableWithPanelAndCommentsCalculatorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "OptionsSingleTableWithPanelAndCommentsCalculatorControl";
            this.leftTopPanel.ResumeLayout(false);
            this.tablesPanel.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Result3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Result2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Result1)).EndInit();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            this.splitContainerMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        protected fsUIControls.fsParametersWithValuesTable dataGrid;
        private System.Windows.Forms.DataGridView dataGridView_Result1;
        private System.Windows.Forms.DataGridView dataGridView_Result3;
        private System.Windows.Forms.DataGridView dataGridView_Result2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitsColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitsColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn FeedColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnderflowColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn OverflowColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitsColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueColumn1;
    }
}
