namespace Calculator.Calculation_Controls
{
    sealed partial class fsPkeFromPcRcControl
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
            this.enterSolidsDensityComboBox = new System.Windows.Forms.ComboBox();
            this.enterSolidsDensityLabel = new System.Windows.Forms.Label();
            this.inputCakeComboBox = new System.Windows.Forms.ComboBox();
            this.inputCake = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGrid = new fmDataGrid.fmDataGrid();
            this.ParameterColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.enterSolidsDensityComboBox);
            this.panel1.Controls.Add(this.enterSolidsDensityLabel);
            this.panel1.Controls.Add(this.inputCakeComboBox);
            this.panel1.Controls.Add(this.inputCake);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 61);
            this.panel1.TabIndex = 0;
            // 
            // enterSolidsDensityComboBox
            // 
            this.enterSolidsDensityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.enterSolidsDensityComboBox.FormattingEnabled = true;
            this.enterSolidsDensityComboBox.Location = new System.Drawing.Point(131, 30);
            this.enterSolidsDensityComboBox.Name = "enterSolidsDensityComboBox";
            this.enterSolidsDensityComboBox.Size = new System.Drawing.Size(146, 21);
            this.enterSolidsDensityComboBox.TabIndex = 3;
            // 
            // enterSolidsDensityLabel
            // 
            this.enterSolidsDensityLabel.AutoSize = true;
            this.enterSolidsDensityLabel.Location = new System.Drawing.Point(21, 33);
            this.enterSolidsDensityLabel.Name = "enterSolidsDensityLabel";
            this.enterSolidsDensityLabel.Size = new System.Drawing.Size(104, 13);
            this.enterSolidsDensityLabel.TabIndex = 2;
            this.enterSolidsDensityLabel.Text = "Enter Solids Density:";
            // 
            // inputCakeComboBox
            // 
            this.inputCakeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inputCakeComboBox.FormattingEnabled = true;
            this.inputCakeComboBox.Location = new System.Drawing.Point(131, 3);
            this.inputCakeComboBox.Name = "inputCakeComboBox";
            this.inputCakeComboBox.Size = new System.Drawing.Size(146, 21);
            this.inputCakeComboBox.TabIndex = 1;
            // 
            // inputCake
            // 
            this.inputCake.AutoSize = true;
            this.inputCake.Location = new System.Drawing.Point(63, 6);
            this.inputCake.Name = "inputCake";
            this.inputCake.Size = new System.Drawing.Size(62, 13);
            this.inputCake.TabIndex = 0;
            this.inputCake.Text = "Input Cake:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGrid);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 61);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(280, 189);
            this.panel2.TabIndex = 1;
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
            this.dataGrid.Size = new System.Drawing.Size(272, 189);
            this.dataGrid.TabIndex = 0;
            // 
            // ParameterColumn
            // 
            this.ParameterColumn.HeaderText = "Parameter";
            this.ParameterColumn.Name = "ParameterName";
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
            // fsPkeFromPcRcControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "fsPkeFromPcRcControl";
            this.Size = new System.Drawing.Size(330, 250);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox inputCakeComboBox;
        private System.Windows.Forms.Label inputCake;
        private fmDataGrid.fmDataGrid dataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn ValueColumn;
        private System.Windows.Forms.ComboBox enterSolidsDensityComboBox;
        private System.Windows.Forms.Label enterSolidsDensityLabel;
    }
}
