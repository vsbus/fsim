using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Calculator.Calculation_Controls;

namespace Calculator
{
    public partial class fsModulesForm : Form
    {
        private readonly Dictionary<string, fsCalculatorControl> m_modules = new Dictionary<string, fsCalculatorControl>();
        public fsCalculatorControl SelectedModule { get; private set; }
        public string SelectedModuleName { get; private set; }
        
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
            SelectedModule.Dock = DockStyle.None;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ModulesFormLoad(object sender, EventArgs e)
        {
            //var boldFont = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold);
            {
                var suspensionNode = new TreeNode("Suspension");
                AddModuleToTree(suspensionNode, "Densities and Suspension Solids Content", new fsDensityConcentrationControl());
                AddModuleToTree(suspensionNode, "Suspension Solids Mass Fraction", new SuspensionSolidsMassFractionControl());
                treeView1.Nodes.Add(suspensionNode);
            }
            {
                var filterCakeNode = new TreeNode("Filter Cake");
                AddModuleToTree(filterCakeNode, "Suspension Amount and Cake Height", new fsMsusAndHcControl());
                AddModuleToTree(filterCakeNode, "Cake Porosity", new fsCakePorossityControl());
                AddModuleToTree(filterCakeNode, "Cake Permeability/resistance and Cake Compressibility", new fsPermeabilityControl());
                treeView1.Nodes.Add(filterCakeNode);
            }
            {
                var cakeFormationNode = new TreeNode("Cake Formation");
                AddModuleToTree(cakeFormationNode, "Calculation Cake Formation", new fsLaboratoryFiltrationTime());
                treeView1.Nodes.Add(cakeFormationNode);
            }
            {
                var cakeDeliquoringNode = new TreeNode("Cake Deliquoring");
                AddModuleToTree(cakeDeliquoringNode, "Cake Moisture Content from Wet and Dry Cake Mass", new fsCakeMoistureContentFromWetAndDryCakeMassControl());
                AddModuleToTree(cakeDeliquoringNode, "Cake Moisture Content from Cake Saturation", new fsCakeMoistureContentFromCakeSaturationControl());
                treeView1.Nodes.Add(cakeDeliquoringNode);
            }
            {
                var cakeWashingNode = new TreeNode("Cake Washing");
                AddModuleToTree(cakeWashingNode, "Cake Wash Out Content X", new fsCakeWashOutContentControl());
                treeView1.Nodes.Add(cakeWashingNode);
            }

            treeView1.ExpandAll();
            treeView1.SelectedNode = treeView1.Nodes[0].Nodes[0];
        }

        private void AddModuleToTree(TreeNode suspensionNode, string moduleName, fsCalculatorControl control)
        {
            if (m_modules.ContainsKey(moduleName))
                throw new Exception("Module with such name is already added.");
            m_modules[moduleName] = control;
            suspensionNode.Nodes.Add(moduleName).NodeFont = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular);
        }

        private void TreeView1AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectedModuleName = treeView1.SelectedNode.Text;
            if (!m_modules.ContainsKey(SelectedModuleName))
                return;

            currentModuleTitleLabel.Text = SelectedModuleName;

            if (SelectedModule != null)
            {
                SelectedModule.Parent = null;
            }
            
            SelectedModule = m_modules[SelectedModuleName];
            SelectedModule.Parent = panel1;
            SelectedModule.Dock = DockStyle.Fill;
        }
    }
}
