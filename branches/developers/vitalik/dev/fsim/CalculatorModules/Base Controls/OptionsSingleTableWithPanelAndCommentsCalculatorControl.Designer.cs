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
            this.fmDataGrid = new fmDataGrid.fmDataGrid();
            this.ParameterColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.panelRight = new System.Windows.Forms.Panel();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.comboBoxCalculationOption = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.leftTopPanel.SuspendLayout();
            this.calculationOptionsPanel.SuspendLayout();
            this.tablesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fmDataGrid)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // calculationOptionsPanel
            // 
            this.calculationOptionsPanel.Controls.Add(this.comboBoxCalculationOption);
            this.calculationOptionsPanel.Controls.Add(this.label1);
            this.calculationOptionsPanel.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            // 
            // tablesPanel
            // 
            this.tablesPanel.Controls.Add(this.splitContainerMain);
            // 
            // fmDataGrid
            // 
            this.fmDataGrid.AllowUserToAddRows = false;
            this.fmDataGrid.AllowUserToDeleteRows = false;
            this.fmDataGrid.AllowUserToResizeRows = false;
            this.fmDataGrid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.fmDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fmDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fmDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ParameterColumn,
            this.ValueColumn});
            this.fmDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fmDataGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.fmDataGrid.HighLightCurrentRow = false;
            this.fmDataGrid.Location = new System.Drawing.Point(0, 0);
            this.fmDataGrid.Margin = new System.Windows.Forms.Padding(4);
            this.fmDataGrid.Name = "fmDataGrid";
            this.fmDataGrid.RowHeadersVisible = false;
            this.fmDataGrid.RowTemplate.Height = 18;
            this.fmDataGrid.Size = new System.Drawing.Size(526, 310);
            this.fmDataGrid.TabIndex = 0;
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
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(0, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(519, 310);
            this.panelRight.TabIndex = 1;
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.fmDataGrid);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.panelRight);
            this.splitContainerMain.Size = new System.Drawing.Size(1049, 310);
            this.splitContainerMain.SplitterDistance = 526;
            this.splitContainerMain.TabIndex = 2;
            // 
            // comboBoxCalculationOption
            // 
            this.comboBoxCalculationOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCalculationOption.FormattingEnabled = true;
            this.comboBoxCalculationOption.Location = new System.Drawing.Point(112, 14);
            this.comboBoxCalculationOption.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxCalculationOption.Name = "comboBoxCalculationOption";
            this.comboBoxCalculationOption.Size = new System.Drawing.Size(193, 24);
            this.comboBoxCalculationOption.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // OptionsSingleTableWithPanelAndCommentsCalculatorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "OptionsSingleTableWithPanelAndCommentsCalculatorControl";
            this.leftTopPanel.ResumeLayout(false);
            this.calculationOptionsPanel.ResumeLayout(false);
            this.calculationOptionsPanel.PerformLayout();
            this.tablesPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fmDataGrid)).EndInit();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            this.splitContainerMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelRight;
        protected fmDataGrid.fmDataGrid fmDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn ValueColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxCalculationOption;
        private System.Windows.Forms.SplitContainer splitContainerMain;
    }
}
