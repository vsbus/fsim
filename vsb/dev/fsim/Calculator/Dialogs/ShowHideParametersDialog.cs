using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Parameters;

namespace Calculator.Dialogs
{
    public partial class fsShowHideParametersDialog : Form
    {
        private Dictionary<TreeNode, fsParameterIdentifier> m_nodesToParameters = new Dictionary<TreeNode, fsParameterIdentifier>();
        private List<fsParameterIdentifier> m_initiallyCheckedParameters = new List<fsParameterIdentifier>();

        public fsShowHideParametersDialog()
        {
            InitializeComponent();
        }

        public Dictionary<fsParameterIdentifier, bool> GetParametersToShowAndHide()
        {
            var parametersToShowAndHide = new Dictionary<fsParameterIdentifier, bool>();
            foreach (TreeNode node in treeView1.Nodes)
            {
                AddCheckedParametersToList(node, parametersToShowAndHide);
            }
            return parametersToShowAndHide;
        }

        private void AddCheckedParametersToList(TreeNode node, Dictionary<fsParameterIdentifier, bool> checkedParameters)
        {
            if (node.Nodes.Count == 0)
            {
                checkedParameters.Add(m_nodesToParameters[node], node.Checked);
            }
            else
            {
                foreach (TreeNode subNode in node.Nodes)
                {
                    AddCheckedParametersToList(subNode, checkedParameters);
                }
            }
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
            treeView1.ExpandAll();
        }

        private void AddGroupToTree(
            string nodeName,
            TreeNodeCollection treeNodeCollection,
            IEnumerable<fsParameterIdentifier> parameters)
        {
            var node = new TreeNode(nodeName);
            foreach (var parameter in parameters)
            {
                TreeNode leaf = node.Nodes.Add(parameter.ToString());
                leaf.Checked = m_initiallyCheckedParameters.Contains(parameter);
                m_nodesToParameters.Add(leaf, parameter);
            }
            treeNodeCollection.Add(node);
        }


        #region UI Events

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

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        #endregion

        internal void CheckParameters(List<fsParameterIdentifier> list)
        {
            foreach (fsParameterIdentifier parameterIdentifier in list)
            {
                m_initiallyCheckedParameters.Add(parameterIdentifier);
            }
        }
    }
}
