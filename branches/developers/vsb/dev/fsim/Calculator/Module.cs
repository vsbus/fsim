using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Calculator.Calculation_Controls;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;

namespace Calculator
{
    public class Module
    {
        public string Name { get; private set; }
        private fsCalculatorControl m_calculatorControl;
        public Form Form { get; private set; }

        public Module(string name, fsCalculatorControl calculatorControl)
        {
            Name = name;
            m_calculatorControl = calculatorControl;
            Form = new Form();
            Form.Text = Name;
            Form.Width = m_calculatorControl.Width + 10;
            Form.Height = m_calculatorControl.Height + 10;
            m_calculatorControl.Parent = Form;
            m_calculatorControl.Dock = DockStyle.Fill;
            Form.Show();
        }
    }
}
