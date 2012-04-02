namespace CalculatorModules.Hydrocyclone
{
    partial class HydrocycloneControl
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
            this.comboBoxCalculationOption = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.panelRight.SuspendLayout();
            this.leftTopPanel.SuspendLayout();
            this.calculationOptionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Result3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Result2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Result1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.dataGridView_Result1);
            this.panelRight.Controls.Add(this.dataGridView_Result2);
            this.panelRight.Controls.Add(this.dataGridView_Result3);
            // 
            // leftTopPanel
            // 
            this.leftTopPanel.Size = new System.Drawing.Size(837, 59);
            // 
            // calculationOptionsPanel
            // 
            this.calculationOptionsPanel.Controls.Add(this.comboBoxCalculationOption);
            this.calculationOptionsPanel.Controls.Add(this.label1);
            // 
            // tablesPanel
            // 
            this.tablesPanel.Size = new System.Drawing.Size(837, 416);
            // 
            // comboBoxCalculationOption
            // 
            this.comboBoxCalculationOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCalculationOption.FormattingEnabled = true;
            this.comboBoxCalculationOption.Location = new System.Drawing.Point(112, 14);
            this.comboBoxCalculationOption.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxCalculationOption.Name = "comboBoxCalculationOption";
            this.comboBoxCalculationOption.Size = new System.Drawing.Size(193, 24);
            this.comboBoxCalculationOption.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Calculation:";
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
            this.dataGridView_Result3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView_Result3.Location = new System.Drawing.Point(0, 255);
            this.dataGridView_Result3.Name = "dataGridView_Result3";
            this.dataGridView_Result3.ReadOnly = true;
            this.dataGridView_Result3.RowTemplate.Height = 24;
            this.dataGridView_Result3.Size = new System.Drawing.Size(472, 161);
            this.dataGridView_Result3.TabIndex = 5;
            // 
            // ParameterColumn3
            // 
            this.ParameterColumn3.HeaderText = "Parameter";
            this.ParameterColumn3.Name = "ParameterColumn3";
            this.ParameterColumn3.ReadOnly = true;
            this.ParameterColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ParameterColumn3.Width = 50;
            // 
            // UnitsColumn3
            // 
            this.UnitsColumn3.HeaderText = "Units";
            this.UnitsColumn3.Name = "UnitsColumn3";
            this.UnitsColumn3.ReadOnly = true;
            this.UnitsColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UnitsColumn3.Width = 50;
            // 
            // FeedColumn
            // 
            this.FeedColumn.HeaderText = "Feed";
            this.FeedColumn.Name = "FeedColumn";
            this.FeedColumn.ReadOnly = true;
            this.FeedColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FeedColumn.Width = 50;
            // 
            // UnderflowColumn
            // 
            this.UnderflowColumn.HeaderText = "Underflow";
            this.UnderflowColumn.Name = "UnderflowColumn";
            this.UnderflowColumn.ReadOnly = true;
            this.UnderflowColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UnderflowColumn.Width = 50;
            // 
            // OverflowColumn
            // 
            this.OverflowColumn.HeaderText = "Overflow";
            this.OverflowColumn.Name = "OverflowColumn";
            this.OverflowColumn.ReadOnly = true;
            this.OverflowColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.OverflowColumn.Width = 50;
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
            this.dataGridView_Result2.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridView_Result2.Location = new System.Drawing.Point(259, 0);
            this.dataGridView_Result2.Name = "dataGridView_Result2";
            this.dataGridView_Result2.ReadOnly = true;
            this.dataGridView_Result2.RowTemplate.Height = 24;
            this.dataGridView_Result2.Size = new System.Drawing.Size(213, 255);
            this.dataGridView_Result2.TabIndex = 4;
            // 
            // ParameterColumn2
            // 
            this.ParameterColumn2.HeaderText = "Parameter";
            this.ParameterColumn2.Name = "ParameterColumn2";
            this.ParameterColumn2.ReadOnly = true;
            this.ParameterColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ParameterColumn2.Width = 50;
            // 
            // UnitsColumn2
            // 
            this.UnitsColumn2.HeaderText = "Units";
            this.UnitsColumn2.Name = "UnitsColumn2";
            this.UnitsColumn2.ReadOnly = true;
            this.UnitsColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UnitsColumn2.Width = 50;
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
            this.dataGridView_Result1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Result1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_Result1.MinimumSize = new System.Drawing.Size(100, 0);
            this.dataGridView_Result1.Name = "dataGridView_Result1";
            this.dataGridView_Result1.ReadOnly = true;
            this.dataGridView_Result1.RowTemplate.Height = 24;
            this.dataGridView_Result1.Size = new System.Drawing.Size(259, 255);
            this.dataGridView_Result1.TabIndex = 3;
            // 
            // ParameterColumn1
            // 
            this.ParameterColumn1.HeaderText = "Parameter";
            this.ParameterColumn1.Name = "ParameterColumn1";
            this.ParameterColumn1.ReadOnly = true;
            this.ParameterColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ParameterColumn1.Width = 50;
            // 
            // UnitsColumn1
            // 
            this.UnitsColumn1.HeaderText = "Units";
            this.UnitsColumn1.Name = "UnitsColumn1";
            this.UnitsColumn1.ReadOnly = true;
            this.UnitsColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UnitsColumn1.Width = 50;
            // 
            // ValueColumn1
            // 
            this.ValueColumn1.HeaderText = "Value";
            this.ValueColumn1.Name = "ValueColumn1";
            this.ValueColumn1.ReadOnly = true;
            this.ValueColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ValueColumn1.Width = 50;
            // 
            // HydrocycloneControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "HydrocycloneControl";
            this.panelRight.ResumeLayout(false);
            this.leftTopPanel.ResumeLayout(false);
            this.calculationOptionsPanel.ResumeLayout(false);
            this.calculationOptionsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Result3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Result2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Result1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCalculationOption;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView_Result3;
        private System.Windows.Forms.DataGridView dataGridView_Result2;
        private System.Windows.Forms.DataGridView dataGridView_Result1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitsColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitsColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitsColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn FeedColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnderflowColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn OverflowColumn;
    }
}
