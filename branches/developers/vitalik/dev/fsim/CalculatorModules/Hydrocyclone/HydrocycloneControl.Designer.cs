namespace CalculatorModules.Hydrocyclone
{
    partial class HydrocycloneControl
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxCalculationOption = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.leftTopPanel.SuspendLayout();
            this.calculationOptionsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // calculationOptionsPanel
            // 
            this.calculationOptionsPanel.Controls.Add(this.comboBoxCalculationOption);
            this.calculationOptionsPanel.Controls.Add(this.label1);
            // 
            // comboBoxCalculationOption
            // 
            this.comboBoxCalculationOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCalculationOption.FormattingEnabled = true;
            this.comboBoxCalculationOption.Location = new System.Drawing.Point(112, 14);
            this.comboBoxCalculationOption.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxCalculationOption.Name = "comboBoxCalculationOption";
            this.comboBoxCalculationOption.Size = new System.Drawing.Size(193, 24);
            this.comboBoxCalculationOption.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Calculation:";
            // 
            // HydrocycloneControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "HydrocycloneControl";
            this.leftTopPanel.ResumeLayout(false);
            this.calculationOptionsPanel.ResumeLayout(false);
            this.calculationOptionsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCalculationOption;
        private System.Windows.Forms.Label label1;
    }
}
