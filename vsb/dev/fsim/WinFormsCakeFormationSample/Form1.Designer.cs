namespace WinFormsCakeFormationSample
{
    partial class Form1
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
            this.materialDataGroupBox = new System.Windows.Forms.GroupBox();
            this.MaterialParametersDataGrid = new fmDataGrid.fmDataGrid();
            this.MaterialParameterNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialParameterValue = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.cakeFormationGroupBox = new System.Windows.Forms.GroupBox();
            this.CakeFormationDataGrid = new fmDataGrid.fmDataGrid();
            this.CakeFormationParameterNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CakeFormationParameterValueColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.calculationIndicatorButton = new System.Windows.Forms.Button();
            this.useMultiThreadingFlag = new System.Windows.Forms.CheckBox();
            this.materialDataGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaterialParametersDataGrid)).BeginInit();
            this.cakeFormationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CakeFormationDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // materialDataGroupBox
            // 
            this.materialDataGroupBox.Controls.Add(this.MaterialParametersDataGrid);
            this.materialDataGroupBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.materialDataGroupBox.Location = new System.Drawing.Point(0, 0);
            this.materialDataGroupBox.Name = "materialDataGroupBox";
            this.materialDataGroupBox.Size = new System.Drawing.Size(273, 559);
            this.materialDataGroupBox.TabIndex = 0;
            this.materialDataGroupBox.TabStop = false;
            this.materialDataGroupBox.Text = "Material Data";
            // 
            // MaterialParametersDataGrid
            // 
            this.MaterialParametersDataGrid.AllowUserToAddRows = false;
            this.MaterialParametersDataGrid.AllowUserToResizeRows = false;
            this.MaterialParametersDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MaterialParametersDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaterialParameterNameColumn,
            this.MaterialParameterValue});
            this.MaterialParametersDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MaterialParametersDataGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.MaterialParametersDataGrid.HighLightCurrentRow = false;
            this.MaterialParametersDataGrid.Location = new System.Drawing.Point(3, 16);
            this.MaterialParametersDataGrid.Name = "MaterialParametersDataGrid";
            this.MaterialParametersDataGrid.RowHeadersVisible = false;
            this.MaterialParametersDataGrid.RowTemplate.Height = 18;
            this.MaterialParametersDataGrid.Size = new System.Drawing.Size(267, 540);
            this.MaterialParametersDataGrid.TabIndex = 0;
            this.MaterialParametersDataGrid.CellValueChangedByUser += new System.Windows.Forms.DataGridViewCellEventHandler(this.MaterialParametersDataGrid_CellValueChangedByUser);
            // 
            // MaterialParameterNameColumn
            // 
            this.MaterialParameterNameColumn.HeaderText = "Parameter";
            this.MaterialParameterNameColumn.Name = "MaterialParameterNameColumn";
            this.MaterialParameterNameColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // MaterialParameterValue
            // 
            this.MaterialParameterValue.HeaderText = "Value";
            this.MaterialParameterValue.Name = "MaterialParameterValue";
            this.MaterialParameterValue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MaterialParameterValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // cakeFormationGroupBox
            // 
            this.cakeFormationGroupBox.Controls.Add(this.CakeFormationDataGrid);
            this.cakeFormationGroupBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.cakeFormationGroupBox.Location = new System.Drawing.Point(273, 0);
            this.cakeFormationGroupBox.Name = "cakeFormationGroupBox";
            this.cakeFormationGroupBox.Size = new System.Drawing.Size(289, 559);
            this.cakeFormationGroupBox.TabIndex = 1;
            this.cakeFormationGroupBox.TabStop = false;
            this.cakeFormationGroupBox.Text = "Cake Formation";
            // 
            // CakeFormationDataGrid
            // 
            this.CakeFormationDataGrid.AllowUserToAddRows = false;
            this.CakeFormationDataGrid.AllowUserToResizeRows = false;
            this.CakeFormationDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CakeFormationDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CakeFormationParameterNameColumn,
            this.CakeFormationParameterValueColumn});
            this.CakeFormationDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CakeFormationDataGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CakeFormationDataGrid.HighLightCurrentRow = false;
            this.CakeFormationDataGrid.Location = new System.Drawing.Point(3, 16);
            this.CakeFormationDataGrid.Name = "CakeFormationDataGrid";
            this.CakeFormationDataGrid.RowHeadersVisible = false;
            this.CakeFormationDataGrid.RowTemplate.Height = 18;
            this.CakeFormationDataGrid.Size = new System.Drawing.Size(283, 540);
            this.CakeFormationDataGrid.TabIndex = 0;
            this.CakeFormationDataGrid.CellValueChangedByUser += new System.Windows.Forms.DataGridViewCellEventHandler(this.CakeFormationDataGrid_CellValueChangedByUser);
            // 
            // CakeFormationParameterNameColumn
            // 
            this.CakeFormationParameterNameColumn.HeaderText = "Parameter";
            this.CakeFormationParameterNameColumn.Name = "CakeFormationParameterNameColumn";
            // 
            // CakeFormationParameterValueColumn
            // 
            this.CakeFormationParameterValueColumn.HeaderText = "Value";
            this.CakeFormationParameterValueColumn.Name = "CakeFormationParameterValueColumn";
            // 
            // calculationIndicatorButton
            // 
            this.calculationIndicatorButton.Location = new System.Drawing.Point(568, 52);
            this.calculationIndicatorButton.Name = "calculationIndicatorButton";
            this.calculationIndicatorButton.Size = new System.Drawing.Size(76, 23);
            this.calculationIndicatorButton.TabIndex = 2;
            this.calculationIndicatorButton.UseVisualStyleBackColor = true;
            // 
            // useMultiThreadingFlag
            // 
            this.useMultiThreadingFlag.AutoSize = true;
            this.useMultiThreadingFlag.Location = new System.Drawing.Point(568, 29);
            this.useMultiThreadingFlag.Name = "useMultiThreadingFlag";
            this.useMultiThreadingFlag.Size = new System.Drawing.Size(118, 17);
            this.useMultiThreadingFlag.TabIndex = 3;
            this.useMultiThreadingFlag.Text = "Use MultiThreading";
            this.useMultiThreadingFlag.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 559);
            this.Controls.Add(this.useMultiThreadingFlag);
            this.Controls.Add(this.calculationIndicatorButton);
            this.Controls.Add(this.cakeFormationGroupBox);
            this.Controls.Add(this.materialDataGroupBox);
            this.Name = "Form1";
            this.Text = "Cake Fromation Sample";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.materialDataGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MaterialParametersDataGrid)).EndInit();
            this.cakeFormationGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CakeFormationDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox materialDataGroupBox;
        private System.Windows.Forms.GroupBox cakeFormationGroupBox;
        private fmDataGrid.fmDataGrid MaterialParametersDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialParameterNameColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn MaterialParameterValue;
        private fmDataGrid.fmDataGrid CakeFormationDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn CakeFormationParameterNameColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn CakeFormationParameterValueColumn;
        private System.Windows.Forms.Button calculationIndicatorButton;
        private System.Windows.Forms.CheckBox useMultiThreadingFlag;
    }
}

