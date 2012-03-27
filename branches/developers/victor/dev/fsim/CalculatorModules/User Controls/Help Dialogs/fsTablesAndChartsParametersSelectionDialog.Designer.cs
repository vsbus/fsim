namespace CalculatorModules.User_Controls.Help_Dialogs
{
    partial class fsTablesAndChartsParametersSelectionDialog
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.materialParametersListView = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.otherParametersListView = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.constantsCheckBox = new System.Windows.Forms.CheckBox();
            this.inputsCheckBox = new System.Windows.Forms.CheckBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.splitContainer1);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(550, 335);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameters";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 16);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.materialParametersListView);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.otherParametersListView);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(544, 255);
            this.splitContainer1.SplitterDistance = 269;
            this.splitContainer1.TabIndex = 0;
            // 
            // materialParametersListView
            // 
            this.materialParametersListView.CheckBoxes = true;
            this.materialParametersListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialParametersListView.Location = new System.Drawing.Point(0, 13);
            this.materialParametersListView.Name = "materialParametersListView";
            this.materialParametersListView.Size = new System.Drawing.Size(269, 242);
            this.materialParametersListView.TabIndex = 0;
            this.materialParametersListView.UseCompatibleStateImageBehavior = false;
            this.materialParametersListView.View = System.Windows.Forms.View.List;
            this.materialParametersListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ListView1ItemChecked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Material Parameters";
            // 
            // otherParametersListView
            // 
            this.otherParametersListView.CheckBoxes = true;
            this.otherParametersListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.otherParametersListView.Location = new System.Drawing.Point(0, 13);
            this.otherParametersListView.Name = "otherParametersListView";
            this.otherParametersListView.Size = new System.Drawing.Size(271, 242);
            this.otherParametersListView.TabIndex = 0;
            this.otherParametersListView.UseCompatibleStateImageBehavior = false;
            this.otherParametersListView.View = System.Windows.Forms.View.List;
            this.otherParametersListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ListView1ItemChecked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Machine Setting Parameters";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.constantsCheckBox);
            this.panel1.Controls.Add(this.inputsCheckBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 271);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(544, 61);
            this.panel1.TabIndex = 1;
            // 
            // constantsCheckBox
            // 
            this.constantsCheckBox.AutoSize = true;
            this.constantsCheckBox.Checked = true;
            this.constantsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.constantsCheckBox.Location = new System.Drawing.Point(3, 29);
            this.constantsCheckBox.Name = "constantsCheckBox";
            this.constantsCheckBox.Size = new System.Drawing.Size(207, 17);
            this.constantsCheckBox.TabIndex = 1;
            this.constantsCheckBox.Text = "Show Constant Calculated Parameters";
            this.constantsCheckBox.UseVisualStyleBackColor = true;
            this.constantsCheckBox.CheckedChanged += new System.EventHandler(this.CheckBox2CheckedChanged);
            // 
            // inputsCheckBox
            // 
            this.inputsCheckBox.AutoSize = true;
            this.inputsCheckBox.Checked = true;
            this.inputsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.inputsCheckBox.Location = new System.Drawing.Point(3, 6);
            this.inputsCheckBox.Name = "inputsCheckBox";
            this.inputsCheckBox.Size = new System.Drawing.Size(136, 17);
            this.inputsCheckBox.TabIndex = 0;
            this.inputsCheckBox.Text = "Show Input Parameters";
            this.inputsCheckBox.UseVisualStyleBackColor = true;
            this.inputsCheckBox.CheckedChanged += new System.EventHandler(this.CheckBox1CheckedChanged);
            // 
            // button1
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(484, 353);
            this.cancelButton.Name = "button1";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // button2
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(403, 353);
            this.okButton.Name = "button2";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButtonClick);
            // 
            // fsTablesAndChartsParametersSelectionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 384);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "fsTablesAndChartsParametersSelectionDialog";
            this.Text = "fsTablesAndChartsParametersSelectionDialog";
            this.Load += new System.EventHandler(this.TablesAndChartsParametersSelectionDialogLoad);
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView materialParametersListView;
        private System.Windows.Forms.ListView otherParametersListView;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.CheckBox constantsCheckBox;
        private System.Windows.Forms.CheckBox inputsCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}