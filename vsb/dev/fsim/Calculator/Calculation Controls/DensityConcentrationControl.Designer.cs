namespace Calculator.Calculation_Controls
{
    sealed partial class fsDensityConcentrationControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.concentrationsRadioButton = new System.Windows.Forms.RadioButton();
            this.suspensionRadioButton = new System.Windows.Forms.RadioButton();
            this.solidsRadioButton = new System.Windows.Forms.RadioButton();
            this.filtrateRadioButton = new System.Windows.Forms.RadioButton();
            this.dataGrid = new fmDataGrid.fmDataGrid();
            this.ParameterColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.concentrationsRadioButton);
            this.panel1.Controls.Add(this.suspensionRadioButton);
            this.panel1.Controls.Add(this.solidsRadioButton);
            this.panel1.Controls.Add(this.filtrateRadioButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(149, 164);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Calculate:";
            // 
            // concentrationsRadioButton
            // 
            this.concentrationsRadioButton.AutoSize = true;
            this.concentrationsRadioButton.Location = new System.Drawing.Point(24, 93);
            this.concentrationsRadioButton.Name = "concentrationsRadioButton";
            this.concentrationsRadioButton.Size = new System.Drawing.Size(96, 17);
            this.concentrationsRadioButton.TabIndex = 3;
            this.concentrationsRadioButton.Text = "Concentrations";
            this.concentrationsRadioButton.UseVisualStyleBackColor = true;
            // 
            // suspensionRadioButton
            // 
            this.suspensionRadioButton.AutoSize = true;
            this.suspensionRadioButton.Checked = true;
            this.suspensionRadioButton.Location = new System.Drawing.Point(24, 70);
            this.suspensionRadioButton.Name = "suspensionRadioButton";
            this.suspensionRadioButton.Size = new System.Drawing.Size(118, 17);
            this.suspensionRadioButton.TabIndex = 2;
            this.suspensionRadioButton.TabStop = true;
            this.suspensionRadioButton.Text = "Suspension Density";
            this.suspensionRadioButton.UseVisualStyleBackColor = true;
            // 
            // solidsRadioButton
            // 
            this.solidsRadioButton.AutoSize = true;
            this.solidsRadioButton.Location = new System.Drawing.Point(24, 47);
            this.solidsRadioButton.Name = "solidsRadioButton";
            this.solidsRadioButton.Size = new System.Drawing.Size(91, 17);
            this.solidsRadioButton.TabIndex = 1;
            this.solidsRadioButton.Text = "Solids Density";
            this.solidsRadioButton.UseVisualStyleBackColor = true;
            // 
            // filtrateRadioButton
            // 
            this.filtrateRadioButton.AutoSize = true;
            this.filtrateRadioButton.Location = new System.Drawing.Point(24, 24);
            this.filtrateRadioButton.Name = "filtrateRadioButton";
            this.filtrateRadioButton.Size = new System.Drawing.Size(94, 17);
            this.filtrateRadioButton.TabIndex = 0;
            this.filtrateRadioButton.Text = "Filtrate Density";
            this.filtrateRadioButton.UseVisualStyleBackColor = true;
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AllowUserToResizeColumns = true;
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
            this.dataGrid.Location = new System.Drawing.Point(149, 0);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.RowTemplate.Height = 18;
            this.dataGrid.Size = new System.Drawing.Size(221, 164);
            this.dataGrid.TabIndex = 0;
            // 
            // ParameterColumn
            // 
            this.ParameterColumn.HeaderText = "Parameter";
            this.ParameterColumn.Name = "ParameterColumn";
            this.ParameterColumn.ReadOnly = true;
            this.ParameterColumn.Width = 160;
            // 
            // ValueColumn
            // 
            this.ValueColumn.HeaderText = "Value";
            this.ValueColumn.Name = "ValueColumn";
            this.ValueColumn.Width = 60;
            // 
            // fsDensityConcentrationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.panel1);
            this.Name = "fsDensityConcentrationControl";
            this.Size = new System.Drawing.Size(370, 164);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private fmDataGrid.fmDataGrid dataGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton concentrationsRadioButton;
        private System.Windows.Forms.RadioButton suspensionRadioButton;
        private System.Windows.Forms.RadioButton solidsRadioButton;
        private System.Windows.Forms.RadioButton filtrateRadioButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn ValueColumn;
    }
}
