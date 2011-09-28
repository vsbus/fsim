using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calculator
{
    public partial class ModulesForm : Form
    {
        private Dictionary<string, Form> moduleTypes = new Dictionary<string, Form>();
        public Form SelectedModule { get; private set; }
        
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
            SelectedModule = moduleTypes[listBox1.SelectedItem.ToString()];
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ModulesForm_Load(object sender, EventArgs e)
        {
            moduleTypes["Density/Concentration"] = new Form2();
            moduleTypes["Permeability"] = new PermeabilityForm();

            foreach (var s in moduleTypes.Keys)
            {
                listBox1.Items.Add(s);
            }
            listBox1.SelectedIndex = 0;
        }
    }
}
