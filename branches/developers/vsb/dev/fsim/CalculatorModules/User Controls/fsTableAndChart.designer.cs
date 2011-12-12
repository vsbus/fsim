﻿namespace CalculatorModules.User_Controls
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label4 = new System.Windows.Forms.Label();
            this.yAxisList = new System.Windows.Forms.CheckedListBox();
            this.y2AxisList = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.xAxisList = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rangeFrom = new System.Windows.Forms.TextBox();
            this.detalizationBox = new System.Windows.Forms.TextBox();
            this.rangeTo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fsDiagramWithTable1 = new fsDiagramWithTable();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(128, 251);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 91);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.yAxisList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.y2AxisList);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Size = new System.Drawing.Size(128, 160);
            this.splitContainer1.SplitterDistance = 78;
            this.splitContainer1.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Y axis";
            // 
            // yAxisList
            // 
            this.yAxisList.CheckOnClick = true;
            this.yAxisList.Dock = System.Windows.Forms.DockStyle.Right;
            this.yAxisList.FormattingEnabled = true;
            this.yAxisList.Location = new System.Drawing.Point(48, 0);
            this.yAxisList.Name = "yAxisList";
            this.yAxisList.Size = new System.Drawing.Size(80, 64);
            this.yAxisList.TabIndex = 6;
            this.yAxisList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.YAxisListMouseUp);
            this.yAxisList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.yAxisList_KeyUp);
            // 
            // y2AxisList
            // 
            this.y2AxisList.CheckOnClick = true;
            this.y2AxisList.Dock = System.Windows.Forms.DockStyle.Right;
            this.y2AxisList.FormattingEnabled = true;
            this.y2AxisList.Location = new System.Drawing.Point(48, 0);
            this.y2AxisList.Name = "y2AxisList";
            this.y2AxisList.Size = new System.Drawing.Size(80, 64);
            this.y2AxisList.TabIndex = 1;
            this.y2AxisList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.y2AxisList_MouseUp);
            this.y2AxisList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.y2AxisList_KeyUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Y2 Axis";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.xAxisList);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.rangeFrom);
            this.panel2.Controls.Add(this.detalizationBox);
            this.panel2.Controls.Add(this.rangeTo);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(128, 91);
            this.panel2.TabIndex = 10;
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
            this.xAxisList.Size = new System.Drawing.Size(72, 21);
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
            // rangeFrom
            // 
            this.rangeFrom.Location = new System.Drawing.Point(48, 34);
            this.rangeFrom.Name = "rangeFrom";
            this.rangeFrom.Size = new System.Drawing.Size(32, 20);
            this.rangeFrom.TabIndex = 2;
            this.rangeFrom.TextChanged += new System.EventHandler(this.RangeFromTextChanged);
            // 
            // detalizationBox
            // 
            this.detalizationBox.Location = new System.Drawing.Point(88, 60);
            this.detalizationBox.Name = "detalizationBox";
            this.detalizationBox.Size = new System.Drawing.Size(32, 20);
            this.detalizationBox.TabIndex = 5;
            this.detalizationBox.TextChanged += new System.EventHandler(this.DetalizationBoxTextChanged);
            // 
            // rangeTo
            // 
            this.rangeTo.Location = new System.Drawing.Point(88, 34);
            this.rangeTo.Name = "rangeTo";
            this.rangeTo.Size = new System.Drawing.Size(32, 20);
            this.rangeTo.TabIndex = 3;
            this.rangeTo.TextChanged += new System.EventHandler(this.RangeToTextChanged);
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
            this.fsDiagramWithTable1.Location = new System.Drawing.Point(128, 0);
            this.fsDiagramWithTable1.Name = "fsDiagramWithTable1";
            this.fsDiagramWithTable1.Size = new System.Drawing.Size(327, 251);
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
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private fsDiagramWithTable fsDiagramWithTable1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckedListBox y2AxisList;
        private System.Windows.Forms.Label label5;
    }
}
