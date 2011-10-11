namespace Calculator.Calculation_Controls
{
    sealed partial class CakePorossityControl
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
            this.machineTypePanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.concaveAreaRadioButton = new System.Windows.Forms.RadioButton();
            this.convexAreaRadioButton = new System.Windows.Forms.RadioButton();
            this.plainAreaRadioButton = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cakeSaturatedCaseRadioButton = new System.Windows.Forms.RadioButton();
            this.genaralCaseRadioButton = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.saltNotNeglectedRadioButton = new System.Windows.Forms.RadioButton();
            this.saltNeglectedRadioButton = new System.Windows.Forms.RadioButton();
            this.dataGrid = new fmDataGrid.fmDataGrid();
            this.ParameterColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.panel1.SuspendLayout();
            this.machineTypePanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.machineTypePanel);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(214, 321);
            this.panel1.TabIndex = 0;
            // 
            // machineTypePanel
            // 
            this.machineTypePanel.Controls.Add(this.label3);
            this.machineTypePanel.Controls.Add(this.concaveAreaRadioButton);
            this.machineTypePanel.Controls.Add(this.convexAreaRadioButton);
            this.machineTypePanel.Controls.Add(this.plainAreaRadioButton);
            this.machineTypePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.machineTypePanel.Location = new System.Drawing.Point(0, 81);
            this.machineTypePanel.Name = "machineTypePanel";
            this.machineTypePanel.Size = new System.Drawing.Size(214, 240);
            this.machineTypePanel.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Machine Type:";
            // 
            // concaveAreaRadioButton
            // 
            this.concaveAreaRadioButton.AutoSize = true;
            this.concaveAreaRadioButton.Location = new System.Drawing.Point(24, 70);
            this.concaveAreaRadioButton.Name = "concaveAreaRadioButton";
            this.concaveAreaRadioButton.Size = new System.Drawing.Size(155, 17);
            this.concaveAreaRadioButton.TabIndex = 2;
            this.concaveAreaRadioButton.TabStop = true;
            this.concaveAreaRadioButton.Text = "Concave Area (Centrifuges)";
            this.concaveAreaRadioButton.UseVisualStyleBackColor = true;
            // 
            // convexAreaRadioButton
            // 
            this.convexAreaRadioButton.AutoSize = true;
            this.convexAreaRadioButton.Location = new System.Drawing.Point(24, 47);
            this.convexAreaRadioButton.Name = "convexAreaRadioButton";
            this.convexAreaRadioButton.Size = new System.Drawing.Size(158, 17);
            this.convexAreaRadioButton.TabIndex = 1;
            this.convexAreaRadioButton.TabStop = true;
            this.convexAreaRadioButton.Text = "Convex Area (Candle Filters)";
            this.convexAreaRadioButton.UseVisualStyleBackColor = true;
            // 
            // plainAreaRadioButton
            // 
            this.plainAreaRadioButton.AutoSize = true;
            this.plainAreaRadioButton.Location = new System.Drawing.Point(24, 24);
            this.plainAreaRadioButton.Name = "plainAreaRadioButton";
            this.plainAreaRadioButton.Size = new System.Drawing.Size(73, 17);
            this.plainAreaRadioButton.TabIndex = 0;
            this.plainAreaRadioButton.TabStop = true;
            this.plainAreaRadioButton.Text = "Plain Area";
            this.plainAreaRadioButton.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.cakeSaturatedCaseRadioButton);
            this.panel3.Controls.Add(this.genaralCaseRadioButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(214, 81);
            this.panel3.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Saturation:";
            // 
            // cakeSaturatedCaseRadioButton
            // 
            this.cakeSaturatedCaseRadioButton.AutoSize = true;
            this.cakeSaturatedCaseRadioButton.Location = new System.Drawing.Point(24, 47);
            this.cakeSaturatedCaseRadioButton.Name = "cakeSaturatedCaseRadioButton";
            this.cakeSaturatedCaseRadioButton.Size = new System.Drawing.Size(99, 17);
            this.cakeSaturatedCaseRadioButton.TabIndex = 1;
            this.cakeSaturatedCaseRadioButton.TabStop = true;
            this.cakeSaturatedCaseRadioButton.Text = "Cake Saturated";
            this.cakeSaturatedCaseRadioButton.UseVisualStyleBackColor = true;
            // 
            // genaralCaseRadioButton
            // 
            this.genaralCaseRadioButton.AutoSize = true;
            this.genaralCaseRadioButton.Location = new System.Drawing.Point(24, 24);
            this.genaralCaseRadioButton.Name = "genaralCaseRadioButton";
            this.genaralCaseRadioButton.Size = new System.Drawing.Size(186, 17);
            this.genaralCaseRadioButton.TabIndex = 0;
            this.genaralCaseRadioButton.TabStop = true;
            this.genaralCaseRadioButton.Text = "General case (cake not saturated)";
            this.genaralCaseRadioButton.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.saltNotNeglectedRadioButton);
            this.panel2.Controls.Add(this.saltNeglectedRadioButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(214, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(207, 81);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Salt content:";
            // 
            // saltNotNeglectedRadioButton
            // 
            this.saltNotNeglectedRadioButton.AutoSize = true;
            this.saltNotNeglectedRadioButton.Location = new System.Drawing.Point(24, 47);
            this.saltNotNeglectedRadioButton.Name = "saltNotNeglectedRadioButton";
            this.saltNotNeglectedRadioButton.Size = new System.Drawing.Size(98, 17);
            this.saltNotNeglectedRadioButton.TabIndex = 1;
            this.saltNotNeglectedRadioButton.TabStop = true;
            this.saltNotNeglectedRadioButton.Text = "NOT neglected";
            this.saltNotNeglectedRadioButton.UseVisualStyleBackColor = true;
            // 
            // saltNeglectedRadioButton
            // 
            this.saltNeglectedRadioButton.AutoSize = true;
            this.saltNeglectedRadioButton.Location = new System.Drawing.Point(24, 24);
            this.saltNeglectedRadioButton.Name = "saltNeglectedRadioButton";
            this.saltNeglectedRadioButton.Size = new System.Drawing.Size(74, 17);
            this.saltNeglectedRadioButton.TabIndex = 0;
            this.saltNeglectedRadioButton.TabStop = true;
            this.saltNeglectedRadioButton.Text = "Neglected";
            this.saltNeglectedRadioButton.UseVisualStyleBackColor = true;
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
            this.dataGrid.Location = new System.Drawing.Point(214, 81);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.RowTemplate.Height = 18;
            this.dataGrid.Size = new System.Drawing.Size(207, 240);
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
            // CakePorossityControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "CakePorossityControl";
            this.Size = new System.Drawing.Size(421, 321);
            this.panel1.ResumeLayout(false);
            this.machineTypePanel.ResumeLayout(false);
            this.machineTypePanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel machineTypePanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private fmDataGrid.fmDataGrid dataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn ValueColumn;
        private System.Windows.Forms.RadioButton concaveAreaRadioButton;
        private System.Windows.Forms.RadioButton convexAreaRadioButton;
        private System.Windows.Forms.RadioButton plainAreaRadioButton;
        private System.Windows.Forms.RadioButton cakeSaturatedCaseRadioButton;
        private System.Windows.Forms.RadioButton genaralCaseRadioButton;
        private System.Windows.Forms.RadioButton saltNotNeglectedRadioButton;
        private System.Windows.Forms.RadioButton saltNeglectedRadioButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
