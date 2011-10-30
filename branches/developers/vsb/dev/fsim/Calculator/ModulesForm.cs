﻿using System;
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
            AddGroupToTree("Suspension", new KeyValuePair<string, fsCalculatorControl>[] {
                new KeyValuePair<string, fsCalculatorControl>("Densities and Suspension Solids Content", new fsDensityConcentrationControl()),
                new KeyValuePair<string, fsCalculatorControl>("Suspension Solids Mass Fraction", new SuspensionSolidsMassFractionControl())
            });
            AddGroupToTree("Filter Cake", new KeyValuePair<string, fsCalculatorControl>[] {
                new KeyValuePair<string, fsCalculatorControl>("Suspension Amount and Cake Height", new fsMsusAndHcControl()),
                new KeyValuePair<string, fsCalculatorControl>("Cake Porosity", new fsCakePorossityControl()),
                new KeyValuePair<string, fsCalculatorControl>("Cake Permeability/Resistance and Cake Compressibility", new fsPermeabilityControl())
            });
            AddGroupToTree("Cake Formation", new KeyValuePair<string, fsCalculatorControl>[] {
                new KeyValuePair<string, fsCalculatorControl>("Calculation Cake Formation", new fsLaboratoryFiltrationTime())
            });
            AddGroupToTree("Cake Deliquoring", new KeyValuePair<string, fsCalculatorControl>[] {
                new KeyValuePair<string, fsCalculatorControl>("Cake Moisture Content from Wet and Dry Cake Mass", new fsCakeMoistureContentFromWetAndDryCakeMassControl()),
                new KeyValuePair<string, fsCalculatorControl>("Cake Moisture Content from Cake Saturation", new fsCakeMoistureContentFromCakeSaturationControl()),
                new KeyValuePair<string, fsCalculatorControl>("pke From Cake Permeability/Resistance", new fsPkeFromPcRcControl())
            });
            AddGroupToTree("Cake Washing", new KeyValuePair<string, fsCalculatorControl>[] {
                new KeyValuePair<string, fsCalculatorControl>("Cake Wash Out Content X", new fsCakeWashOutContentControl())
            });

            treeView1.ExpandAll();
            treeView1.SelectedNode = treeView1.Nodes[0].Nodes[0];
        }

        private void AddGroupToTree(string nodeName, IEnumerable<KeyValuePair<string, fsCalculatorControl>> calculationControls)
        {
            var node = new TreeNode(nodeName);
            foreach (var pair in calculationControls)
            {
                AddModuleToTree(node, pair.Key, pair.Value);
            }
            treeView1.Nodes.Add(node);
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

