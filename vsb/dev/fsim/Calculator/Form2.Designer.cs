namespace Calculator
{
    partial class Form2
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
            this.densityConcentrationControl1 = new Calculator.Calculation_Controls.DensityConcentrationControl();
            this.SuspendLayout();
            // 
            // densityConcentrationControl1
            // 
            this.densityConcentrationControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.densityConcentrationControl1.Location = new System.Drawing.Point(0, 0);
            this.densityConcentrationControl1.Name = "densityConcentrationControl1";
            this.densityConcentrationControl1.Size = new System.Drawing.Size(368, 136);
            this.densityConcentrationControl1.TabIndex = 0;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 136);
            this.Controls.Add(this.densityConcentrationControl1);
            this.Name = "Form2";
            this.Text = "Densities and Concentration";
            this.ResumeLayout(false);

        }

        #endregion

        private Calculator.Calculation_Controls.DensityConcentrationControl densityConcentrationControl1;






    }
}