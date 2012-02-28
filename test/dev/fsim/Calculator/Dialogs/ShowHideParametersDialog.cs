using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Parameters;

namespace Calculator.Dialogs
{
    public partial class fsShowHideParametersDialog : Form
    {
        public fsShowHideParametersDialog()
        {
            InitializeComponent();
        }

        private void ShowHideParametersDialogLoad(object sender, EventArgs e)
        {
            AddGroupToTree("eps0, kappa0 (Dp = 1)", treeView1.Nodes,
                new[]
                {
                    fsParameterIdentifier.Ne,
                    fsParameterIdentifier.CakePorosity0,
                    fsParameterIdentifier.Kappa0,
                    fsParameterIdentifier.DryCakeDensity0
                });
            AddGroupToTree("eps, kappa", treeView1.Nodes,
                new[]
                {
                    fsParameterIdentifier.CakePorosity,
                    fsParameterIdentifier.Kappa,
                    fsParameterIdentifier.DryCakeDensity
                });
        }

        private static void AddGroupToTree(
            string nodeName,
            TreeNodeCollection treeNodeCollection,
            IEnumerable<fsParameterIdentifier> parameters)
        {
            var node = new TreeNode(nodeName);
            foreach (var parameter in parameters)
            {
                node.Nodes.Add(parameter.ToString());
            }
            treeNodeCollection.Add(node);
        }


        private static void CheckSubtree(TreeNode treeNode, bool isChecked)
        {
            treeNode.Checked = isChecked;
            foreach(TreeNode node in treeNode.Nodes)
            {
                CheckSubtree(node, isChecked);
            }
        }

        private void TreeView1AfterCheck(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode node in e.Node.Nodes)
            {
                CheckSubtree(node, e.Node.Checked);
            }
        }
    }
}
