using System.Collections.Generic;
using System.Windows.Forms;

namespace Calculator
{
    public partial class fsMachineDialog : Form
    {
        public fsMachineDialog()
        {
            InitializeComponent();
        }

        internal void AssignModulesList(List<fsModule> modules)
        {
            var list = new List<string>();
            foreach (fsModule module in modules)
            {
                list.Add(module.Name);
            }
            fsCheckedList1.AssignList(list);
        }
    }
}
