namespace Calculator.Calculation_Controls
{
    sealed partial class fsPermeabilityControl
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
            this.parameterNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pcrcalphaRadioButton = new System.Windows.Forms.RadioButton();
            this.ncRadioButton = new System.Windows.Forms.RadioButton();
            this.pressureRadioButton = new System.Windows.Forms.RadioButton();
            this.pc0rc0alpha0RadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AllowUserToResizeColumns = false;
            this.dataGrid.AllowUserToResizeRows = false;
            this.dataGrid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.parameterNameColumn,
            this.valueColumn});
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dataGrid.HighLightCurrentRow = false;
            this.dataGrid.Location = new System.Drawing.Point(153, 0);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.RowTemplate.Height = 18;
            this.dataGrid.Size = new System.Drawing.Size(217, 237);
            this.dataGrid.TabIndex = 0;
            // 
            // parameterNameColumn
            // 
            this.parameterNameColumn.HeaderText = "Parameter";
            this.parameterNameColumn.Name = "parameterNameColumn";
            this.parameterNameColumn.ReadOnly = true;
            this.parameterNameColumn.Width = 140;
            // 
            // valueColumn
            // 
            this.valueColumn.HeaderText = "Value";
            this.valueColumn.Name = "valueColumn";
            this.valueColumn.Width = 60;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pcrcalphaRadioButton);
            this.panel1.Controls.Add(this.ncRadioButton);
            this.panel1.Controls.Add(this.pressureRadioButton);
            this.panel1.Controls.Add(this.pc0rc0alpha0RadioButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(153, 237);
            this.panel1.TabIndex = 1;
            // 
            // pcrcalphaRadioButton
            // 
            this.pcrcalphaRadioButton.AutoSize = true;
            this.pcrcalphaRadioButton.Checked = true;
            this.pcrcalphaRadioButton.Location = new System.Drawing.Point(31, 95);
            this.pcrcalphaRadioButton.Name = "pcrcalphaRadioButton";
            this.pcrcalphaRadioButton.Size = new System.Drawing.Size(79, 17);
            this.pcrcalphaRadioButton.TabIndex = 4;
            this.pcrcalphaRadioButton.TabStop = true;
            this.pcrcalphaRadioButton.Text = "Pc rc alpha";
            this.pcrcalphaRadioButton.UseVisualStyleBackColor = true;
            // 
            // ncRadioButton
            // 
            this.ncRadioButton.AutoSize = true;
            this.ncRadioButton.Location = new System.Drawing.Point(31, 49);
            this.ncRadioButton.Name = "ncRadioButton";
            this.ncRadioButton.Size = new System.Drawing.Size(37, 17);
            this.ncRadioButton.TabIndex = 3;
            this.ncRadioButton.TabStop = true;
            this.ncRadioButton.Text = "nc";
            this.ncRadioButton.UseVisualStyleBackColor = true;
            // 
            // pressureRadioButton
            // 
            this.pressureRadioButton.AutoSize = true;
            this.pressureRadioButton.Location = new System.Drawing.Point(31, 72);
            this.pressureRadioButton.Name = "pressureRadioButton";
            this.pressureRadioButton.Size = new System.Drawing.Size(89, 17);
            this.pressureRadioButton.TabIndex = 2;
            this.pressureRadioButton.TabStop = true;
            this.pressureRadioButton.Text = "Pressure (Dp)";
            this.pressureRadioButton.UseVisualStyleBackColor = true;
            // 
            // pc0rc0alpha0RadioButton
            // 
            this.pc0rc0alpha0RadioButton.AutoSize = true;
            this.pc0rc0alpha0RadioButton.Location = new System.Drawing.Point(31, 26);
            this.pc0rc0alpha0RadioButton.Name = "pc0rc0alpha0RadioButton";
            this.pc0rc0alpha0RadioButton.Size = new System.Drawing.Size(97, 17);
            this.pc0rc0alpha0RadioButton.TabIndex = 1;
            this.pc0rc0alpha0RadioButton.TabStop = true;
            this.pc0rc0alpha0RadioButton.Text = "Pc0 rc0 alpha0";
            this.pc0rc0alpha0RadioButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Calculate:";
            // 
            // PermeabilityControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.panel1);
            this.Name = "fsPermeabilityControl";
            this.Size = new System.Drawing.Size(370, 237);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private fmDataGrid.fmDataGrid dataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn parameterNameColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn valueColumn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton pcrcalphaRadioButton;
        private System.Windows.Forms.RadioButton ncRadioButton;
        private System.Windows.Forms.RadioButton pressureRadioButton;
        private System.Windows.Forms.RadioButton pc0rc0alpha0RadioButton;
        private System.Windows.Forms.Label label1;
    }
}
