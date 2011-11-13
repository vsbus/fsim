using System.Collections.Generic;
using System.Windows.Forms;
using Calculator.Calculation_Controls;
using Units;

namespace Calculator
{
    public class fsModule
    {
        public string Name { get; private set; }
        private readonly fsCalculatorControl m_calculatorControl;
        public Form Form { get; private set; }

        public fsModule(string name, fsCalculatorControl calculatorControl)
        {
            Name = name;
            m_calculatorControl = calculatorControl;
            Form = new Form
                       {
                           Text = Name,
                           Width = m_calculatorControl.Width + 10,
                           Height = m_calculatorControl.Height + 10
                       };
            m_calculatorControl.Parent = Form;
            m_calculatorControl.Dock = DockStyle.Fill;
            Form.Show();
        }

        internal void SetUnits(Dictionary<fsCharacteristic, fsCharacteristic.fsUnit> dictionary)
        {
            m_calculatorControl.SetUnits(dictionary);
        }
    }
}
