namespace Calculator.Calculation_Controls
{
    sealed partial class fsCakeWashOutContentControl
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
            this.washOutContentComboBox = new System.Windows.Forms.ComboBox();
            this.fromComboBox = new System.Windows.Forms.ComboBox();
            this.washOutContentLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.panel1.Controls.Add(this.washOutContentComboBox);
            this.panel1.Controls.Add(this.fromComboBox);
            this.panel1.Controls.Add(this.washOutContentLabel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 72);
            this.panel1.TabIndex = 0;
            // 
            // washOutContentComboBox
            // 
            this.washOutContentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.washOutContentComboBox.FormattingEnabled = true;
            this.washOutContentComboBox.Location = new System.Drawing.Point(141, 35);
            this.washOutContentComboBox.Name = "washOutContentComboBox";
            this.washOutContentComboBox.Size = new System.Drawing.Size(136, 21);
            this.washOutContentComboBox.TabIndex = 3;
            // 
            // fromComboBox
            // 
            this.fromComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fromComboBox.FormattingEnabled = true;
            this.fromComboBox.Location = new System.Drawing.Point(141, 3);
            this.fromComboBox.Name = "fromComboBox";
            this.fromComboBox.Size = new System.Drawing.Size(136, 21);
            this.fromComboBox.TabIndex = 2;
            // 
            // washOutContentLabel
            // 
            this.washOutContentLabel.AutoSize = true;
            this.washOutContentLabel.Location = new System.Drawing.Point(37, 38);
            this.washOutContentLabel.Name = "washOutContentLabel";
            this.washOutContentLabel.Size = new System.Drawing.Size(98, 13);
            this.washOutContentLabel.TabIndex = 1;
            this.washOutContentLabel.Text = "Wash Out Content:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Measured Parameter:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGrid);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 72);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(280, 208);
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
            this.dataGrid.Size = new System.Drawing.Size(272, 208);
            this.dataGrid.TabIndex = 0;
            // 
            // ParameterColumn
            // 
            this.ParameterColumn.HeaderText = "Parameter";
            this.ParameterColumn.Name = "ParameterColumn";
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
            // CakeWashOutContentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "fsCakeWashOutContentControl";
            this.Size = new System.Drawing.Size(330, 280);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private fmDataGrid.fmDataGrid dataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn ValueColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox washOutContentComboBox;
        private System.Windows.Forms.ComboBox fromComboBox;
        private System.Windows.Forms.Label washOutContentLabel;
    }
}
