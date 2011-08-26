namespace WinFormsCakeFormationSample
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
            this.materialDataGroupBox = new System.Windows.Forms.GroupBox();
            this.cakeFormationGroupBox = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // materialDataGroupBox
            // 
            this.materialDataGroupBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.materialDataGroupBox.Location = new System.Drawing.Point(0, 0);
            this.materialDataGroupBox.Name = "materialDataGroupBox";
            this.materialDataGroupBox.Size = new System.Drawing.Size(273, 294);
            this.materialDataGroupBox.TabIndex = 0;
            this.materialDataGroupBox.TabStop = false;
            this.materialDataGroupBox.Text = "Material Data";
            // 
            // cakeFormationGroupBox
            // 
            this.cakeFormationGroupBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.cakeFormationGroupBox.Location = new System.Drawing.Point(273, 0);
            this.cakeFormationGroupBox.Name = "cakeFormationGroupBox";
            this.cakeFormationGroupBox.Size = new System.Drawing.Size(289, 294);
            this.cakeFormationGroupBox.TabIndex = 1;
            this.cakeFormationGroupBox.TabStop = false;
            this.cakeFormationGroupBox.Text = "Cake Formation";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 294);
            this.Controls.Add(this.cakeFormationGroupBox);
            this.Controls.Add(this.materialDataGroupBox);
            this.Name = "Form1";
            this.Text = "Cake Fromation Sample";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox materialDataGroupBox;
        private System.Windows.Forms.GroupBox cakeFormationGroupBox;
    }
}

