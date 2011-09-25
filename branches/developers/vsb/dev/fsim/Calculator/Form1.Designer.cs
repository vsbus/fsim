namespace Calculator
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.windowsDataGrid = new fmDataGrid.fmDataGrid();
            this.WindowNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.addModuleButton = new System.Windows.Forms.Button();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowTilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.windowsDataGrid)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(571, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.windowsDataGrid);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(120, 348);
            this.panel1.TabIndex = 3;
            // 
            // windowsDataGrid
            // 
            this.windowsDataGrid.AllowUserToAddRows = false;
            this.windowsDataGrid.AllowUserToDeleteRows = false;
            this.windowsDataGrid.AllowUserToResizeColumns = false;
            this.windowsDataGrid.AllowUserToResizeRows = false;
            this.windowsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.windowsDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WindowNameColumn});
            this.windowsDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windowsDataGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.windowsDataGrid.HighLightCurrentRow = false;
            this.windowsDataGrid.Location = new System.Drawing.Point(0, 31);
            this.windowsDataGrid.Name = "windowsDataGrid";
            this.windowsDataGrid.ReadOnly = true;
            this.windowsDataGrid.RowHeadersVisible = false;
            this.windowsDataGrid.RowTemplate.Height = 18;
            this.windowsDataGrid.Size = new System.Drawing.Size(120, 317);
            this.windowsDataGrid.TabIndex = 0;
            this.windowsDataGrid.CurrentCellChanged += new System.EventHandler(this.windowsDataGrid_CurrentCellChanged);
            // 
            // WindowNameColumn
            // 
            this.WindowNameColumn.HeaderText = "Window";
            this.WindowNameColumn.Name = "WindowNameColumn";
            this.WindowNameColumn.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.addModuleButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(120, 31);
            this.panel2.TabIndex = 1;
            // 
            // addModuleButton
            // 
            this.addModuleButton.Location = new System.Drawing.Point(3, 3);
            this.addModuleButton.Name = "addModuleButton";
            this.addModuleButton.Size = new System.Drawing.Size(75, 23);
            this.addModuleButton.TabIndex = 0;
            this.addModuleButton.Text = "Add Module";
            this.addModuleButton.UseVisualStyleBackColor = true;
            this.addModuleButton.Click += new System.EventHandler(this.addModuleButton_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.windowTilesToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // windowTilesToolStripMenuItem
            // 
            this.windowTilesToolStripMenuItem.Name = "windowTilesToolStripMenuItem";
            this.windowTilesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.windowTilesToolStripMenuItem.Text = "Window Tiles";
            this.windowTilesToolStripMenuItem.Click += new System.EventHandler(this.windowTilesToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 372);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.windowsDataGrid)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel1;
        private fmDataGrid.fmDataGrid windowsDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn WindowNameColumn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button addModuleButton;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowTilesToolStripMenuItem;

    }
}

