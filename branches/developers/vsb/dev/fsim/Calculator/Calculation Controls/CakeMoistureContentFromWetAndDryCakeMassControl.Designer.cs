namespace Calculator.Calculation_Controls
{
    sealed partial class CakeMoistureContentFromWetAndDryCakeMassControl
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
            this.saltContentComboBox = new System.Windows.Forms.ComboBox();
            this.concentrationComboBox = new System.Windows.Forms.ComboBox();
            this.concentrationLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGrid = new fmDataGrid.fmDataGrid();
            this.ParameterColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.saltContentComboBox);
            this.panel1.Controls.Add(this.concentrationComboBox);
            this.panel1.Controls.Add(this.concentrationLabel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 144);
            this.panel1.TabIndex = 0;
            // 
            // saltContentComboBox
            // 
            this.saltContentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.saltContentComboBox.FormattingEnabled = true;
            this.saltContentComboBox.Items.AddRange(new object[] {
            "Considered",
            "Neglected"});
            this.saltContentComboBox.Location = new System.Drawing.Point(132, 9);
            this.saltContentComboBox.Name = "saltContentComboBox";
            this.saltContentComboBox.Size = new System.Drawing.Size(136, 21);
            this.saltContentComboBox.TabIndex = 0;
            // 
            // concentrationComboBox
            // 
            this.concentrationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.concentrationComboBox.FormattingEnabled = true;
            this.concentrationComboBox.Location = new System.Drawing.Point(132, 36);
            this.concentrationComboBox.Name = "concentrationComboBox";
            this.concentrationComboBox.Size = new System.Drawing.Size(136, 21);
            this.concentrationComboBox.TabIndex = 3;
            // 
            // concentrationLabel
            // 
            this.concentrationLabel.AutoSize = true;
            this.concentrationLabel.Location = new System.Drawing.Point(15, 36);
            this.concentrationLabel.Name = "concentrationLabel";
            this.concentrationLabel.Size = new System.Drawing.Size(111, 13);
            this.concentrationLabel.TabIndex = 2;
            this.concentrationLabel.Text = "Solved salt measured:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Salt Content in dry cake:";
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
            this.ParameterColumn,
            this.ValueColumn});
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dataGrid.HighLightCurrentRow = false;
            this.dataGrid.Location = new System.Drawing.Point(274, 0);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.RowTemplate.Height = 18;
            this.dataGrid.Size = new System.Drawing.Size(212, 144);
            this.dataGrid.TabIndex = 1;
            // 
            // ParameterColumn
            // 
            this.ParameterColumn.HeaderText = "Parameter";
            this.ParameterColumn.Name = "ParameterColumn";
            this.ParameterColumn.ReadOnly = true;
            this.ParameterColumn.Width = 140;
            // 
            // ValueColumn
            // 
            this.ValueColumn.HeaderText = "Value";
            this.ValueColumn.Name = "ValueColumn";
            this.ValueColumn.Width = 60;
            // 
            // CakeMoistureContentFromWetAndDryCakeMassControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.panel1);
            this.Name = "CakeMoistureContentFromWetAndDryCakeMassControl";
            this.Size = new System.Drawing.Size(486, 144);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private fmDataGrid.fmDataGrid dataGrid;
        private System.Windows.Forms.ComboBox concentrationComboBox;
        private System.Windows.Forms.Label concentrationLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox saltContentComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn ValueColumn;
    }
}
