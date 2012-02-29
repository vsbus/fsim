using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Parameters;

namespace fsUIControls
{
    public partial class fsParametersCheckBoxesTree : UserControl
    {
        private Dictionary<TreeNode, fsParameterIdentifier> m_nodesToParameters = new Dictionary<TreeNode, fsParameterIdentifier>();
        private Dictionary<fsParameterIdentifier, bool> m_involvedParametersWithCheckStatus = new Dictionary<fsParameterIdentifier, bool>();

        public fsParametersCheckBoxesTree()
        {
            InitializeComponent();

        }

        #region Tree Initialization

        public void InitializeTree(Dictionary<fsParameterIdentifier, bool> involvedParametersWithCheckStatus)
        {
            m_involvedParametersWithCheckStatus = involvedParametersWithCheckStatus;

            treeView1.Nodes.Clear();

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
                if (m_involvedParametersWithCheckStatus.ContainsKey(parameter))
                {
                    TreeNode leaf = node.Nodes.Add(parameter.ToString());
                    leaf.Checked = m_involvedParametersWithCheckStatus[parameter];
                    m_nodesToParameters.Add(leaf, parameter);
                }
            }
            if (node.Nodes.Count > 0)
            {
                treeNodeCollection.Add(node);
            }
        }

        #endregion

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


    }
}
