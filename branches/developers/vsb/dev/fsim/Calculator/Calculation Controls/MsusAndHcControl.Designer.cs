namespace Calculator.Calculation_Controls
{
    sealed partial class fsMsusAndHcControl
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
            this.ParameterColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.filterElementDiameterRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.massVolumeRadioButton = new System.Windows.Forms.RadioButton();
            this.denisitiesRadioButton = new System.Windows.Forms.RadioButton();
            this.cakeHeightRadioButton = new System.Windows.Forms.RadioButton();
            this.concentrationRadioButton = new System.Windows.Forms.RadioButton();
            this.areaRadioButton = new System.Windows.Forms.RadioButton();
            this.epsKappaRadioButton = new System.Windows.Forms.RadioButton();
            this.machineDiameterRadioButton = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.concaveAreaRadioButton = new System.Windows.Forms.RadioButton();
            this.convexAreaRadioButton = new System.Windows.Forms.RadioButton();
            this.planeAreaRadioButton = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
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
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dataGrid.HighLightCurrentRow = false;
            this.dataGrid.Location = new System.Drawing.Point(256, 0);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.RowTemplate.Height = 18;
            this.dataGrid.Size = new System.Drawing.Size(215, 293);
            this.dataGrid.TabIndex = 0;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 293);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.filterElementDiameterRadioButton);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.massVolumeRadioButton);
            this.panel2.Controls.Add(this.denisitiesRadioButton);
            this.panel2.Controls.Add(this.cakeHeightRadioButton);
            this.panel2.Controls.Add(this.concentrationRadioButton);
            this.panel2.Controls.Add(this.areaRadioButton);
            this.panel2.Controls.Add(this.epsKappaRadioButton);
            this.panel2.Controls.Add(this.machineDiameterRadioButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 96);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(256, 197);
            this.panel2.TabIndex = 8;
            // 
            // filterElementDiameterRadioButton
            // 
            this.filterElementDiameterRadioButton.AutoSize = true;
            this.filterElementDiameterRadioButton.Location = new System.Drawing.Point(24, 93);
            this.filterElementDiameterRadioButton.Name = "filterElementDiameterRadioButton";
            this.filterElementDiameterRadioButton.Size = new System.Drawing.Size(133, 17);
            this.filterElementDiameterRadioButton.TabIndex = 8;
            this.filterElementDiameterRadioButton.TabStop = true;
            this.filterElementDiameterRadioButton.Text = "Filter Element Diameter";
            this.filterElementDiameterRadioButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Calculate:";
            // 
            // massVolumeRadioButton
            // 
            this.massVolumeRadioButton.AutoSize = true;
            this.massVolumeRadioButton.Location = new System.Drawing.Point(24, 162);
            this.massVolumeRadioButton.Name = "massVolumeRadioButton";
            this.massVolumeRadioButton.Size = new System.Drawing.Size(96, 17);
            this.massVolumeRadioButton.TabIndex = 7;
            this.massVolumeRadioButton.TabStop = true;
            this.massVolumeRadioButton.Text = "Mass / Volume";
            this.massVolumeRadioButton.UseVisualStyleBackColor = true;
            // 
            // denisitiesRadioButton
            // 
            this.denisitiesRadioButton.AutoSize = true;
            this.denisitiesRadioButton.Location = new System.Drawing.Point(24, 24);
            this.denisitiesRadioButton.Name = "denisitiesRadioButton";
            this.denisitiesRadioButton.Size = new System.Drawing.Size(170, 17);
            this.denisitiesRadioButton.TabIndex = 1;
            this.denisitiesRadioButton.TabStop = true;
            this.denisitiesRadioButton.Text = "Solids and Suspension Density";
            this.denisitiesRadioButton.UseVisualStyleBackColor = true;
            // 
            // cakeHeightRadioButton
            // 
            this.cakeHeightRadioButton.AutoSize = true;
            this.cakeHeightRadioButton.Location = new System.Drawing.Point(24, 139);
            this.cakeHeightRadioButton.Name = "cakeHeightRadioButton";
            this.cakeHeightRadioButton.Size = new System.Drawing.Size(84, 17);
            this.cakeHeightRadioButton.TabIndex = 6;
            this.cakeHeightRadioButton.TabStop = true;
            this.cakeHeightRadioButton.Text = "Cake Height";
            this.cakeHeightRadioButton.UseVisualStyleBackColor = true;
            // 
            // concentrationRadioButton
            // 
            this.concentrationRadioButton.AutoSize = true;
            this.concentrationRadioButton.Location = new System.Drawing.Point(24, 47);
            this.concentrationRadioButton.Name = "concentrationRadioButton";
            this.concentrationRadioButton.Size = new System.Drawing.Size(96, 17);
            this.concentrationRadioButton.TabIndex = 2;
            this.concentrationRadioButton.TabStop = true;
            this.concentrationRadioButton.Text = "Concentrations";
            this.concentrationRadioButton.UseVisualStyleBackColor = true;
            // 
            // areaRadioButton
            // 
            this.areaRadioButton.AutoSize = true;
            this.areaRadioButton.Location = new System.Drawing.Point(24, 116);
            this.areaRadioButton.Name = "areaRadioButton";
            this.areaRadioButton.Size = new System.Drawing.Size(212, 17);
            this.areaRadioButton.TabIndex = 5;
            this.areaRadioButton.TabStop = true;
            this.areaRadioButton.Text = "Filter Area and other Machine Geometry";
            this.areaRadioButton.UseVisualStyleBackColor = true;
            // 
            // epsKappaRadioButton
            // 
            this.epsKappaRadioButton.AutoSize = true;
            this.epsKappaRadioButton.Location = new System.Drawing.Point(24, 70);
            this.epsKappaRadioButton.Name = "epsKappaRadioButton";
            this.epsKappaRadioButton.Size = new System.Drawing.Size(104, 17);
            this.epsKappaRadioButton.TabIndex = 3;
            this.epsKappaRadioButton.TabStop = true;
            this.epsKappaRadioButton.Text = "Porosity / Kappa";
            this.epsKappaRadioButton.UseVisualStyleBackColor = true;
            // 
            // machineDiameterRadioButton
            // 
            this.machineDiameterRadioButton.AutoSize = true;
            this.machineDiameterRadioButton.Location = new System.Drawing.Point(24, 93);
            this.machineDiameterRadioButton.Name = "machineDiameterRadioButton";
            this.machineDiameterRadioButton.Size = new System.Drawing.Size(111, 17);
            this.machineDiameterRadioButton.TabIndex = 4;
            this.machineDiameterRadioButton.TabStop = true;
            this.machineDiameterRadioButton.Text = "Machine Diameter";
            this.machineDiameterRadioButton.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.concaveAreaRadioButton);
            this.panel3.Controls.Add(this.convexAreaRadioButton);
            this.panel3.Controls.Add(this.planeAreaRadioButton);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(256, 96);
            this.panel3.TabIndex = 9;
            // 
            // concaveAreaRadioButton
            // 
            this.concaveAreaRadioButton.AutoSize = true;
            this.concaveAreaRadioButton.Location = new System.Drawing.Point(24, 70);
            this.concaveAreaRadioButton.Name = "concaveAreaRadioButton";
            this.concaveAreaRadioButton.Size = new System.Drawing.Size(155, 17);
            this.concaveAreaRadioButton.TabIndex = 3;
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
            this.convexAreaRadioButton.TabIndex = 2;
            this.convexAreaRadioButton.TabStop = true;
            this.convexAreaRadioButton.Text = "Convex Area (Candle Filters)";
            this.convexAreaRadioButton.UseVisualStyleBackColor = true;
            // 
            // planeAreaRadioButton
            // 
            this.planeAreaRadioButton.AutoSize = true;
            this.planeAreaRadioButton.Location = new System.Drawing.Point(24, 24);
            this.planeAreaRadioButton.Name = "planeAreaRadioButton";
            this.planeAreaRadioButton.Size = new System.Drawing.Size(77, 17);
            this.planeAreaRadioButton.TabIndex = 1;
            this.planeAreaRadioButton.TabStop = true;
            this.planeAreaRadioButton.Text = "Plane Area";
            this.planeAreaRadioButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Machine Type:";
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(471, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(140, 293);
            this.textBox1.TabIndex = 2;
            this.textBox1.Visible = false;
            // 
            // fsMsusAndHcControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.panel1);
            this.Name = "fsMsusAndHcControl";
            this.Size = new System.Drawing.Size(611, 293);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private fmDataGrid.fmDataGrid dataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn ValueColumn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton areaRadioButton;
        private System.Windows.Forms.RadioButton machineDiameterRadioButton;
        private System.Windows.Forms.RadioButton epsKappaRadioButton;
        private System.Windows.Forms.RadioButton concentrationRadioButton;
        private System.Windows.Forms.RadioButton denisitiesRadioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton massVolumeRadioButton;
        private System.Windows.Forms.RadioButton cakeHeightRadioButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton concaveAreaRadioButton;
        private System.Windows.Forms.RadioButton convexAreaRadioButton;
        private System.Windows.Forms.RadioButton planeAreaRadioButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton filterElementDiameterRadioButton;
    }
}
