namespace Calculator
{
    partial class PermeabilityForm
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
            this.permeabilityControl1 = new Calculator.Calculation_Controls.PermeabilityControl();
            this.SuspendLayout();
            // 
            // permeabilityControl1
            // 
            this.permeabilityControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.permeabilityControl1.Location = new System.Drawing.Point(0, 0);
            this.permeabilityControl1.Name = "permeabilityControl1";
            this.permeabilityControl1.Size = new System.Drawing.Size(223, 215);
            this.permeabilityControl1.TabIndex = 0;
            // 
            // PermeabilityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 215);
            this.Controls.Add(this.permeabilityControl1);
            this.Name = "PermeabilityForm";
            this.Text = "PermeabilityForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Calculator.Calculation_Controls.PermeabilityControl permeabilityControl1;
    }
}