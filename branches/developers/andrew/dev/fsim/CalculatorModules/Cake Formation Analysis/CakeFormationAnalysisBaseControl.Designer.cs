﻿namespace CalculatorModules.Cake_Formation_Analysis
{
    partial class CakeFormationAnalysisBaseControl
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.simulationBox = new System.Windows.Forms.ComboBox();
            this.leftTopPanel.SuspendLayout();
            this.calculationOptionsPanel.SuspendLayout();
            this.tablesPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGrid
            // 
            this.dataGrid.Size = new System.Drawing.Size(329, 656);
            // 
            // leftTopPanel
            // 
            this.leftTopPanel.Size = new System.Drawing.Size(329, 72);
            // 
            // calculationOptionsPanel
            // 
            this.calculationOptionsPanel.Controls.Add(this.label2);
            this.calculationOptionsPanel.Controls.Add(this.label1);
            this.calculationOptionsPanel.Controls.Add(this.simulationBox);
            this.calculationOptionsPanel.Size = new System.Drawing.Size(278, 72);
            // 
            // tablesPanel
            // 
            this.tablesPanel.Location = new System.Drawing.Point(0, 72);
            this.tablesPanel.Size = new System.Drawing.Size(329, 656);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Calculation Option:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Filter Type:";
            // 
            // simulationBox
            // 
            this.simulationBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simulationBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.simulationBox.FormattingEnabled = true;
            this.simulationBox.Location = new System.Drawing.Point(111, 40);
            this.simulationBox.Name = "simulationBox";
            this.simulationBox.Size = new System.Drawing.Size(160, 21);
            this.simulationBox.TabIndex = 4;
            this.simulationBox.TabStop = false;
            this.simulationBox.DropDown += new System.EventHandler(this.simulationBox_DropDown);
            // 
            // CakeFormationAnalysisBaseControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "CakeFormationAnalysisBaseControl";
            this.Size = new System.Drawing.Size(329, 728);
            this.leftTopPanel.ResumeLayout(false);
            this.calculationOptionsPanel.ResumeLayout(false);
            this.calculationOptionsPanel.PerformLayout();
            this.tablesPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.ComboBox simulationBox;
    }
}
