namespace Calculator.User_Controls
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.yAxisList = new System.Windows.Forms.CheckedListBox();
            this.detalizationBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rangeTo = new System.Windows.Forms.TextBox();
            this.rangeFrom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.xAxisList = new System.Windows.Forms.ComboBox();
            this.fmZedGraphControl1 = new fmZedGraph.fmZedGraphControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.table = new fmDataGrid.fmDataGrid();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.yAxisList);
            this.panel1.Controls.Add(this.detalizationBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.rangeTo);
            this.panel1.Controls.Add(this.rangeFrom);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.xAxisList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(128, 251);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Y axis";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Detalization";
            // 
            // yAxisList
            // 
            this.yAxisList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.yAxisList.CheckOnClick = true;
            this.yAxisList.FormattingEnabled = true;
            this.yAxisList.Location = new System.Drawing.Point(48, 97);
            this.yAxisList.Name = "yAxisList";
            this.yAxisList.Size = new System.Drawing.Size(72, 139);
            this.yAxisList.TabIndex = 6;
            this.yAxisList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.yAxisList_MouseUp);
            // 
            // detalizationBox
            // 
            this.detalizationBox.Location = new System.Drawing.Point(88, 56);
            this.detalizationBox.Name = "detalizationBox";
            this.detalizationBox.Size = new System.Drawing.Size(32, 20);
            this.detalizationBox.TabIndex = 5;
            this.detalizationBox.TextChanged += new System.EventHandler(this.detalizationBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Range";
            // 
            // rangeTo
            // 
            this.rangeTo.Location = new System.Drawing.Point(88, 30);
            this.rangeTo.Name = "rangeTo";
            this.rangeTo.Size = new System.Drawing.Size(32, 20);
            this.rangeTo.TabIndex = 3;
            this.rangeTo.TextChanged += new System.EventHandler(this.rangeTo_TextChanged);
            // 
            // rangeFrom
            // 
            this.rangeFrom.Location = new System.Drawing.Point(48, 30);
            this.rangeFrom.Name = "rangeFrom";
            this.rangeFrom.Size = new System.Drawing.Size(32, 20);
            this.rangeFrom.TabIndex = 2;
            this.rangeFrom.TextChanged += new System.EventHandler(this.rangeFrom_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "X axis";
            // 
            // xAxisList
            // 
            this.xAxisList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.xAxisList.FormattingEnabled = true;
            this.xAxisList.Location = new System.Drawing.Point(48, 3);
            this.xAxisList.Name = "xAxisList";
            this.xAxisList.Size = new System.Drawing.Size(72, 21);
            this.xAxisList.TabIndex = 0;
            this.xAxisList.SelectedIndexChanged += new System.EventHandler(this.xAxisList_SelectedIndexChanged);
            // 
            // fmZedGraphControl1
            // 
            this.fmZedGraphControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fmZedGraphControl1.IsAntiAlias = true;
            this.fmZedGraphControl1.Location = new System.Drawing.Point(0, 0);
            this.fmZedGraphControl1.Name = "fmZedGraphControl1";
            this.fmZedGraphControl1.ScrollGrace = 0;
            this.fmZedGraphControl1.ScrollMaxX = 0;
            this.fmZedGraphControl1.ScrollMaxY = 0;
            this.fmZedGraphControl1.ScrollMaxY2 = 0;
            this.fmZedGraphControl1.ScrollMinX = 0;
            this.fmZedGraphControl1.ScrollMinY = 0;
            this.fmZedGraphControl1.ScrollMinY2 = 0;
            this.fmZedGraphControl1.Size = new System.Drawing.Size(327, 171);
            this.fmZedGraphControl1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(128, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.fmZedGraphControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.table);
            this.splitContainer1.Size = new System.Drawing.Size(327, 251);
            this.splitContainer1.SplitterDistance = 171;
            this.splitContainer1.TabIndex = 3;
            // 
            // table
            // 
            this.table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.table.HighLightCurrentRow = false;
            this.table.Location = new System.Drawing.Point(0, 0);
            this.table.Name = "table";
            this.table.RowTemplate.Height = 18;
            this.table.Size = new System.Drawing.Size(327, 76);
            this.table.TabIndex = 0;
            // 
            // fsTableAndChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "fsTableAndChart";
            this.Size = new System.Drawing.Size(455, 251);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox xAxisList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox yAxisList;
        private System.Windows.Forms.TextBox detalizationBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox rangeTo;
        private System.Windows.Forms.TextBox rangeFrom;
        private System.Windows.Forms.Label label1;
        private fmDataGrid.fmDataGrid table;
        private fmZedGraph.fmZedGraphControl fmZedGraphControl1;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
