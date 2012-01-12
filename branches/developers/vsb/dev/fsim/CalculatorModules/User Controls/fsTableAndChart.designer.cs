namespace CalculatorModules.User_Controls
{
    partial class fsTableAndChart
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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.yAxisSplitContainer = new System.Windows.Forms.SplitContainer();
            this.yAxisList = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.y2AxisList = new System.Windows.Forms.ListView();
            this.label5 = new System.Windows.Forms.Label();
            this.inputsTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.detalizationBox = new fmDataGrid.fmNumericalTextBox();
            this.rangeTo = new fmDataGrid.fmNumericalTextBox();
            this.rangeFrom = new fmDataGrid.fmNumericalTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.xAxisList = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fsDiagramWithTable1 = new CalculatorModules.User_Controls.fsDiagramWithTable();
            this.panel1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.yAxisSplitContainer.Panel1.SuspendLayout();
            this.yAxisSplitContainer.Panel2.SuspendLayout();
            this.yAxisSplitContainer.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.Controls.Add(this.splitContainer2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(151, 251);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 91);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.yAxisSplitContainer);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.inputsTextBox);
            this.splitContainer2.Panel2.Controls.Add(this.label6);
            this.splitContainer2.Size = new System.Drawing.Size(151, 160);
            this.splitContainer2.SplitterDistance = 98;
            this.splitContainer2.TabIndex = 11;
            // 
            // yAxisSplitContainer
            // 
            this.yAxisSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yAxisSplitContainer.IsSplitterFixed = true;
            this.yAxisSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.yAxisSplitContainer.Name = "yAxisSplitContainer";
            this.yAxisSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // yAxisSplitContainer.Panel1
            // 
            this.yAxisSplitContainer.Panel1.Controls.Add(this.yAxisList);
            this.yAxisSplitContainer.Panel1.Controls.Add(this.label4);
            // 
            // yAxisSplitContainer.Panel2
            // 
            this.yAxisSplitContainer.Panel2.Controls.Add(this.y2AxisList);
            this.yAxisSplitContainer.Panel2.Controls.Add(this.label5);
            this.yAxisSplitContainer.Size = new System.Drawing.Size(151, 98);
            this.yAxisSplitContainer.SplitterDistance = 47;
            this.yAxisSplitContainer.TabIndex = 9;
            // 
            // yAxisList
            // 
            this.yAxisList.CheckBoxes = true;
            this.yAxisList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yAxisList.Location = new System.Drawing.Point(0, 13);
            this.yAxisList.Name = "yAxisList";
            this.yAxisList.Size = new System.Drawing.Size(151, 34);
            this.yAxisList.TabIndex = 9;
            this.yAxisList.UseCompatibleStateImageBehavior = false;
            this.yAxisList.View = System.Windows.Forms.View.List;
            this.yAxisList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.YAxisListItemChecked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Y axis";
            // 
            // y2AxisList
            // 
            this.y2AxisList.CheckBoxes = true;
            this.y2AxisList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.y2AxisList.Location = new System.Drawing.Point(0, 13);
            this.y2AxisList.Name = "y2AxisList";
            this.y2AxisList.Size = new System.Drawing.Size(151, 34);
            this.y2AxisList.TabIndex = 2;
            this.y2AxisList.UseCompatibleStateImageBehavior = false;
            this.y2AxisList.View = System.Windows.Forms.View.List;
            this.y2AxisList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.YAxisListItemChecked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Y2 Axis";
            // 
            // inputsTextBox
            // 
            this.inputsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputsTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.inputsTextBox.Location = new System.Drawing.Point(0, 13);
            this.inputsTextBox.Multiline = true;
            this.inputsTextBox.Name = "inputsTextBox";
            this.inputsTextBox.ReadOnly = true;
            this.inputsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.inputsTextBox.Size = new System.Drawing.Size(151, 45);
            this.inputsTextBox.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Inputs:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.detalizationBox);
            this.panel2.Controls.Add(this.rangeTo);
            this.panel2.Controls.Add(this.rangeFrom);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.xAxisList);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(151, 91);
            this.panel2.TabIndex = 10;
            // 
            // detalizationBox
            // 
            this.detalizationBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.detalizationBox.ForeColor = System.Drawing.Color.Red;
            this.detalizationBox.Location = new System.Drawing.Point(71, 60);
            this.detalizationBox.Name = "detalizationBox";
            this.detalizationBox.Size = new System.Drawing.Size(74, 20);
            this.detalizationBox.TabIndex = 10;
            // 
            // rangeTo
            // 
            this.rangeTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.rangeTo.ForeColor = System.Drawing.Color.Red;
            this.rangeTo.Location = new System.Drawing.Point(101, 34);
            this.rangeTo.Name = "rangeTo";
            this.rangeTo.Size = new System.Drawing.Size(44, 20);
            this.rangeTo.TabIndex = 9;
            this.rangeTo.TextChanged += new System.EventHandler(this.RangeToTextChanged);
            // 
            // rangeFrom
            // 
            this.rangeFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.rangeFrom.ForeColor = System.Drawing.Color.Red;
            this.rangeFrom.Location = new System.Drawing.Point(48, 34);
            this.rangeFrom.Name = "rangeFrom";
            this.rangeFrom.Size = new System.Drawing.Size(44, 20);
            this.rangeFrom.TabIndex = 8;
            this.rangeFrom.TextChanged += new System.EventHandler(this.RangeFromTextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "X axis";
            // 
            // xAxisList
            // 
            this.xAxisList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.xAxisList.FormattingEnabled = true;
            this.xAxisList.Location = new System.Drawing.Point(48, 7);
            this.xAxisList.Name = "xAxisList";
            this.xAxisList.Size = new System.Drawing.Size(97, 21);
            this.xAxisList.TabIndex = 0;
            this.xAxisList.SelectedIndexChanged += new System.EventHandler(this.XAxisListSelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Detalization";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Range";
            // 
            // fsDiagramWithTable1
            // 
            this.fsDiagramWithTable1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fsDiagramWithTable1.Location = new System.Drawing.Point(151, 0);
            this.fsDiagramWithTable1.Name = "fsDiagramWithTable1";
            this.fsDiagramWithTable1.Size = new System.Drawing.Size(304, 251);
            this.fsDiagramWithTable1.TabIndex = 1;
            // 
            // fsTableAndChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fsDiagramWithTable1);
            this.Controls.Add(this.panel1);
            this.Name = "fsTableAndChart";
            this.Size = new System.Drawing.Size(455, 251);
            this.panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            this.yAxisSplitContainer.Panel1.ResumeLayout(false);
            this.yAxisSplitContainer.Panel1.PerformLayout();
            this.yAxisSplitContainer.Panel2.ResumeLayout(false);
            this.yAxisSplitContainer.Panel2.PerformLayout();
            this.yAxisSplitContainer.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox xAxisList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private fsDiagramWithTable fsDiagramWithTable1;
        private System.Windows.Forms.SplitContainer yAxisSplitContainer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox inputsTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView y2AxisList;
        private System.Windows.Forms.ListView yAxisList;
        private fmDataGrid.fmNumericalTextBox detalizationBox;
        private fmDataGrid.fmNumericalTextBox rangeTo;
        private fmDataGrid.fmNumericalTextBox rangeFrom;
    }
}
