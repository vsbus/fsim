﻿namespace CalculatorModules
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
            this.panelRight = new System.Windows.Forms.Panel();
            this.ParameterColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.leftTopPanel.SuspendLayout();
            this.tablesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fmDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // tablesPanel
            // 
            this.tablesPanel.Controls.Add(this.panelRight);
            this.tablesPanel.Controls.Add(this.fmDataGrid);
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
            this.fmDataGrid.Dock = System.Windows.Forms.DockStyle.Left;
            this.fmDataGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.fmDataGrid.HighLightCurrentRow = false;
            this.fmDataGrid.Location = new System.Drawing.Point(0, 0);
            this.fmDataGrid.Margin = new System.Windows.Forms.Padding(4);
            this.fmDataGrid.Name = "fmDataGrid";
            this.fmDataGrid.RowHeadersVisible = false;
            this.fmDataGrid.RowTemplate.Height = 18;
            this.fmDataGrid.Size = new System.Drawing.Size(483, 310);
            this.fmDataGrid.TabIndex = 0;
            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(481, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(568, 310);
            this.panelRight.TabIndex = 1;
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
            // OptionsSingleTableWithPanelAndCommentsCalculatorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "OptionsSingleTableWithPanelAndCommentsCalculatorControl";
            this.leftTopPanel.ResumeLayout(false);
            this.tablesPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fmDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelRight;
        protected fmDataGrid.fmDataGrid fmDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn ValueColumn;
    }
}
