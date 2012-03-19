namespace Calculator.Dialogs
{
    partial class TablesAndChartsParametersDialog
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.xAxisListView = new System.Windows.Forms.ListView();
            this.ParameterColumn = new System.Windows.Forms.ColumnHeader();
            this.yAxisListView = new System.Windows.Forms.ListView();
            this.y2AxisListView = new System.Windows.Forms.ListView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.yColums = new System.Windows.Forms.ColumnHeader();
            this.y2Column = new System.Windows.Forms.ColumnHeader();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.OKButton);
            this.panel1.Controls.Add(this.CancelButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 303);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(348, 51);
            this.panel1.TabIndex = 0;
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.Location = new System.Drawing.Point(180, 16);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 1;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Location = new System.Drawing.Point(261, 16);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 0;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // xAxisListView
            // 
            this.xAxisListView.CheckBoxes = true;
            this.xAxisListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ParameterColumn});
            this.xAxisListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xAxisListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.xAxisListView.Location = new System.Drawing.Point(0, 0);
            this.xAxisListView.Name = "xAxisListView";
            this.xAxisListView.Size = new System.Drawing.Size(172, 303);
            this.xAxisListView.TabIndex = 1;
            this.xAxisListView.UseCompatibleStateImageBehavior = false;
            this.xAxisListView.View = System.Windows.Forms.View.Details;
            // 
            // ParameterColumn
            // 
            this.ParameterColumn.Text = "X Axis Parameters";
            this.ParameterColumn.Width = 150;
            // 
            // yAxisListView
            // 
            this.yAxisListView.CheckBoxes = true;
            this.yAxisListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.yColums});
            this.yAxisListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yAxisListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.yAxisListView.Location = new System.Drawing.Point(0, 0);
            this.yAxisListView.Name = "yAxisListView";
            this.yAxisListView.Size = new System.Drawing.Size(172, 143);
            this.yAxisListView.TabIndex = 2;
            this.yAxisListView.UseCompatibleStateImageBehavior = false;
            this.yAxisListView.View = System.Windows.Forms.View.Details;
            // 
            // y2AxisListView
            // 
            this.y2AxisListView.CheckBoxes = true;
            this.y2AxisListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.y2Column});
            this.y2AxisListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.y2AxisListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.y2AxisListView.Location = new System.Drawing.Point(0, 0);
            this.y2AxisListView.Name = "y2AxisListView";
            this.y2AxisListView.Size = new System.Drawing.Size(172, 156);
            this.y2AxisListView.TabIndex = 3;
            this.y2AxisListView.UseCompatibleStateImageBehavior = false;
            this.y2AxisListView.View = System.Windows.Forms.View.Details;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.xAxisListView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(348, 303);
            this.splitContainer1.SplitterDistance = 172;
            this.splitContainer1.TabIndex = 4;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.yAxisListView);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.y2AxisListView);
            this.splitContainer2.Size = new System.Drawing.Size(172, 303);
            this.splitContainer2.SplitterDistance = 143;
            this.splitContainer2.TabIndex = 0;
            // 
            // yColums
            // 
            this.yColums.Text = "Y Axis Parameters";
            this.yColums.Width = 150;
            // 
            // y2Column
            // 
            this.y2Column.Text = "Y2 Axis Parameters";
            this.y2Column.Width = 150;
            // 
            // TablesAndChartsParametersDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 354);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "TablesAndChartsParametersDialog";
            this.Text = "TablesAndChartsParametersDialog";
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.ListView xAxisListView;
        private System.Windows.Forms.ListView yAxisListView;
        private System.Windows.Forms.ListView y2AxisListView;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ColumnHeader ParameterColumn;
        private System.Windows.Forms.ColumnHeader yColums;
        private System.Windows.Forms.ColumnHeader y2Column;
    }
}