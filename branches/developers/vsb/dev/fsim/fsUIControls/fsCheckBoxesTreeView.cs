using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace fsUIControls
{
    public class fsCheckBoxesTreeView : TreeView
    {
        public fsCheckBoxesTreeView() : base()
        {
            CheckBoxes = true;
            AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewAfterCheck);
        }

        private static void CheckSubtree(TreeNode treeNode, bool isChecked)
        {
            treeNode.Checked = isChecked;
            foreach (TreeNode node in treeNode.Nodes)
            {
                CheckSubtree(node, isChecked);
            }
        }

        private void TreeViewAfterCheck(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode node in e.Node.Nodes)
            {
                CheckSubtree(node, e.Node.Checked);
            }
        }

    }
}
