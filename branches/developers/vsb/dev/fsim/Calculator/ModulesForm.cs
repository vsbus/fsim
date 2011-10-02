using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Calculator.Calculation_Controls;

namespace Calculator
{
    public partial class fsModulesForm : Form
    {
        private readonly Dictionary<string, fsCalculatorControl> m_modules = new Dictionary<string, fsCalculatorControl>();
        public fsCalculatorControl SelectedModule { get; private set; }
        
        public fsModulesForm()
        {
            InitializeComponent();
            SelectedModule = null;
        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OkButtonClick(object sender, EventArgs e)
        {
            SelectedModule = m_modules[listBox1.SelectedItem.ToString()];
            SelectedModule.Dock = DockStyle.None;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ModulesFormLoad(object sender, EventArgs e)
        {
            m_modules["Density/Concentration"] = new fsDensityConcentrationControl();
            m_modules["Permeability"] = new fsPermeabilityControl();
            m_modules["Msus and Hc"] = new fsMsusAndHcControl();

            foreach (var s in m_modules.Keys)
            {
                listBox1.Items.Add(s);
            }
            listBox1.SelectedIndex = 0;
        }

        private void ListBox1SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedModule != null)
            {
                SelectedModule.Parent = null;
            }
            SelectedModule = m_modules[listBox1.SelectedItem.ToString()];
            SelectedModule.Parent = panel1;
            SelectedModule.Dock = DockStyle.Fill;
        }
    }
}
