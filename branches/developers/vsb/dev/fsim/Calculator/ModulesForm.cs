using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Calculator.Calculation_Controls;

namespace Calculator
{
    public partial class ModulesForm : Form
    {
        private Dictionary<string, fsCalculatorControl> modules = new Dictionary<string, fsCalculatorControl>();
        public fsCalculatorControl SelectedModule { get; private set; }
        
        public ModulesForm()
        {
            InitializeComponent();
            SelectedModule = null;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            SelectedModule = modules[listBox1.SelectedItem.ToString()];
            SelectedModule.Dock = DockStyle.None;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ModulesForm_Load(object sender, EventArgs e)
        {
            modules["Density/Concentration"] = new DensityConcentrationControl();
            modules["Permeability"] = new PermeabilityControl();
            modules["Msus and Hc"] = new MsusAndHcControl();

            foreach (var s in modules.Keys)
            {
                listBox1.Items.Add(s);
            }
            listBox1.SelectedIndex = 0;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedModule != null)
            {
                SelectedModule.Parent = null;
            }
            SelectedModule = modules[listBox1.SelectedItem.ToString()];
            SelectedModule.Parent = panel1;
            SelectedModule.Dock = DockStyle.Fill;
        }
    }
}
