namespace Calculator.Calculation_Controls
{
    partial class fsOptionsOneTableAndCommentsCalculatorControl
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
            this.leftPanel = new System.Windows.Forms.Panel();
            this.tablesPanel = new System.Windows.Forms.Panel();
            this.dataGrid = new fmDataGrid.fmDataGrid();
            this.leftTopPanel = new System.Windows.Forms.Panel();
            this.calculationOptionsPanel = new System.Windows.Forms.Panel();
            this.showHideCommentsPanel = new System.Windows.Forms.Panel();
            this.showHideCommnetsButton = new System.Windows.Forms.Button();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ParameterColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.leftPanel.SuspendLayout();
            this.tablesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.leftTopPanel.SuspendLayout();
            this.showHideCommentsPanel.SuspendLayout();
            this.rightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // leftPanel
            // 
            this.leftPanel.Controls.Add(this.tablesPanel);
            this.leftPanel.Controls.Add(this.leftTopPanel);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(282, 300);
            this.leftPanel.TabIndex = 0;
            // 
            // tablesPanel
            // 
            this.tablesPanel.Controls.Add(this.dataGrid);
            this.tablesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablesPanel.Location = new System.Drawing.Point(0, 37);
            this.tablesPanel.Name = "tablesPanel";
            this.tablesPanel.Size = new System.Drawing.Size(282, 263);
            this.tablesPanel.TabIndex = 1;
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
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
            this.dataGrid.Location = new System.Drawing.Point(0, 0);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.RowTemplate.Height = 18;
            this.dataGrid.Size = new System.Drawing.Size(282, 263);
            this.dataGrid.TabIndex = 0;
            // 
            // leftTopPanel
            // 
            this.leftTopPanel.Controls.Add(this.calculationOptionsPanel);
            this.leftTopPanel.Controls.Add(this.showHideCommentsPanel);
            this.leftTopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.leftTopPanel.Location = new System.Drawing.Point(0, 0);
            this.leftTopPanel.Name = "leftTopPanel";
            this.leftTopPanel.Size = new System.Drawing.Size(282, 37);
            this.leftTopPanel.TabIndex = 0;
            // 
            // calculationOptionsPanel
            // 
            this.calculationOptionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calculationOptionsPanel.Location = new System.Drawing.Point(0, 0);
            this.calculationOptionsPanel.Name = "calculationOptionsPanel";
            this.calculationOptionsPanel.Size = new System.Drawing.Size(231, 37);
            this.calculationOptionsPanel.TabIndex = 0;
            // 
            // showHideCommentsPanel
            // 
            this.showHideCommentsPanel.Controls.Add(this.showHideCommnetsButton);
            this.showHideCommentsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.showHideCommentsPanel.Location = new System.Drawing.Point(231, 0);
            this.showHideCommentsPanel.Name = "showHideCommentsPanel";
            this.showHideCommentsPanel.Size = new System.Drawing.Size(51, 37);
            this.showHideCommentsPanel.TabIndex = 1;
            // 
            // showHideCommnetsButton
            // 
            this.showHideCommnetsButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.showHideCommnetsButton.Location = new System.Drawing.Point(6, 5);
            this.showHideCommnetsButton.Name = "showHideCommnetsButton";
            this.showHideCommnetsButton.Size = new System.Drawing.Size(39, 26);
            this.showHideCommnetsButton.TabIndex = 0;
            this.showHideCommnetsButton.Text = ">";
            this.showHideCommnetsButton.UseVisualStyleBackColor = true;
            this.showHideCommnetsButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // rightPanel
            // 
            this.rightPanel.Controls.Add(this.textBox1);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightPanel.Location = new System.Drawing.Point(282, 0);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(0, 300);
            this.rightPanel.TabIndex = 1;
            this.rightPanel.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(0, 300);
            this.textBox1.TabIndex = 0;
            // 
            // ParameterColumn
            // 
            this.ParameterColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ParameterColumn.FillWeight = 300F;
            this.ParameterColumn.HeaderText = "Parameter";
            this.ParameterColumn.Name = "ParameterColumn";
            this.ParameterColumn.ReadOnly = true;
            this.ParameterColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ValueColumn
            // 
            this.ValueColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ValueColumn.HeaderText = "Value";
            this.ValueColumn.Name = "ValueColumn";
            // 
            // fsOptionsOneTableAndCommentsCalculatorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.leftPanel);
            this.Controls.Add(this.rightPanel);
            this.Name = "fsOptionsOneTableAndCommentsCalculatorControl";
            this.Size = new System.Drawing.Size(282, 300);
            this.leftPanel.ResumeLayout(false);
            this.tablesPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.leftTopPanel.ResumeLayout(false);
            this.showHideCommentsPanel.ResumeLayout(false);
            this.rightPanel.ResumeLayout(false);
            this.rightPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Panel tablesPanel;
        protected System.Windows.Forms.Panel leftTopPanel;
        private System.Windows.Forms.Panel rightPanel;
        protected System.Windows.Forms.Panel calculationOptionsPanel;
        private System.Windows.Forms.Panel showHideCommentsPanel;
        private System.Windows.Forms.Button showHideCommnetsButton;
        private System.Windows.Forms.TextBox textBox1;
        protected fmDataGrid.fmDataGrid dataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn ValueColumn;
    }
}
