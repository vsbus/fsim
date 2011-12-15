using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CalculatorModules;

namespace SmallCalculator2
{
    public partial class SmallCalculatorMainWindow : Form
    {
        private readonly Dictionary<string, fsCalculatorControl> m_modules =
            new Dictionary<string, fsCalculatorControl>();

        public fsCalculatorControl SelectedCalculatorControl { get; private set; }

        public SmallCalculatorMainWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AddGroupToTree("Suspension", new[]
                                             {
                                                 new KeyValuePair<string, fsCalculatorControl>(
                                                     "Densities and Suspension Solids Content",
                                                     new fsDensityConcentrationControl()),
                                                 new KeyValuePair<string, fsCalculatorControl>(
                                                     "Suspension Solids Mass Fraction",
                                                     new SuspensionSolidsMassFractionControl())
                                             });
            AddGroupToTree("Filter Cake", new[]
                                              {
                                                  new KeyValuePair<string, fsCalculatorControl>(
                                                      "Suspension Amount and Cake Height", new fsMsusAndHcControl()),
                                                  new KeyValuePair<string, fsCalculatorControl>("Cake Porosity",
                                                                                                new fsCakePorossityControl
                                                                                                    ()),
                                                  new KeyValuePair<string, fsCalculatorControl>(
                                                      "Cake Permeability/Resistance and Cake Compressibility",
                                                      new fsPermeabilityControl())
                                              });
            AddGroupToTree("Cake Formation", new[]
                                                 {
                                                     new KeyValuePair<string, fsCalculatorControl>(
                                                         "Calculation Cake Formation", new fsLaboratoryFiltrationTime())
                                                 });
            AddGroupToTree("Cake Deliquoring", new[]
                                                   {
                                                       new KeyValuePair<string, fsCalculatorControl>(
                                                           "Cake Moisture Content from Wet and Dry Cake Mass",
                                                           new fsCakeMoistureContentFromWetAndDryCakeMassControl()),
                                                       new KeyValuePair<string, fsCalculatorControl>(
                                                           "Cake Moisture Content from Cake Saturation",
                                                           new fsCakeMoistureContentFromCakeSaturationControl()),
                                                       new KeyValuePair<string, fsCalculatorControl>(
                                                           "pke From Cake Permeability/Resistance",
                                                           new fsPkeFromPcRcControl())
                                                   });
            AddGroupToTree("Cake Washing", new[]
                                               {
                                                   new KeyValuePair<string, fsCalculatorControl>(
                                                       "Cake Wash Out Content X", new fsCakeWashOutContentControl())
                                               });

            treeView1.ExpandAll();
            treeView1.SelectedNode = treeView1.Nodes[0].Nodes[0];
        }

        private void AddGroupToTree(string nodeName,
                            IEnumerable<KeyValuePair<string, fsCalculatorControl>> calculationControls)
        {
            var node = new TreeNode(nodeName);
            foreach (var pair in calculationControls)
            {
                fsCalculatorControl calculatorControl = pair.Value;
                AddModuleToTree(node, pair.Key, calculatorControl);
                if (calculatorControl is fsOptionsOneTableAndCommentsCalculatorControl)
                {
                    (calculatorControl as fsOptionsOneTableAndCommentsCalculatorControl).AllowCommentsView = false;
                }
            }
            treeView1.Nodes.Add(node);
        }

        private void AddModuleToTree(TreeNode treeNode, string moduleName, fsCalculatorControl control)
        {
            if (m_modules.ContainsKey(moduleName))
                throw new Exception("Module with such name is already added.");
            m_modules[moduleName] = control;
            treeNode.Nodes.Add(moduleName).NodeFont = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!m_modules.ContainsKey(treeView1.SelectedNode.Text))
                return;

            string SelectedCalculatorControlName = treeView1.SelectedNode.Text;
            currentModuleTitleLabel.Text = SelectedCalculatorControlName;

            if (SelectedCalculatorControl != null)
            {
                SelectedCalculatorControl.Parent = null;
            }

            SelectedCalculatorControl = m_modules[SelectedCalculatorControlName];
            SelectedCalculatorControl.Parent = modulePanel;
            SelectedCalculatorControl.Dock = DockStyle.Fill;
        }

        private void unitsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}
