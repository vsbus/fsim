namespace Calculator
{
    partial class fsMachineDialog
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.fsCheckedList1 = new fsUIControls.fsCheckedList();
            this.fsMachineSettings1 = new fsUIControls.fsMachineSettings();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.fsCheckedList1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.fsMachineSettings1);
            this.splitContainer1.Size = new System.Drawing.Size(681, 397);
            this.splitContainer1.SplitterDistance = 304;
            this.splitContainer1.TabIndex = 0;
            // 
            // fsCheckedList1
            // 
            this.fsCheckedList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fsCheckedList1.Location = new System.Drawing.Point(0, 0);
            this.fsCheckedList1.Name = "fsCheckedList1";
            this.fsCheckedList1.Size = new System.Drawing.Size(304, 397);
            this.fsCheckedList1.TabIndex = 0;
            // 
            // fsMachineSettings1
            // 
            this.fsMachineSettings1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fsMachineSettings1.Location = new System.Drawing.Point(0, 0);
            this.fsMachineSettings1.Name = "fsMachineSettings1";
            this.fsMachineSettings1.Size = new System.Drawing.Size(373, 397);
            this.fsMachineSettings1.TabIndex = 0;
            // 
            // fsMachineDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 397);
            this.Controls.Add(this.splitContainer1);
            this.Name = "fsMachineDialog";
            this.Text = "MachineDialog";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private fsUIControls.fsCheckedList fsCheckedList1;
        private fsUIControls.fsMachineSettings fsMachineSettings1;
    }
}