using System.Collections.Generic;
using System.Windows.Forms;
using Parameters;
using ParametersIdentifiers.Ranges;

namespace Calculator
{
    public partial class fsMachineDialog : Form
    {
        public Dictionary<fsParameterIdentifier, fsRange> Ranges
        {
            get { return fsMachineSettings1.Ranges; }
        }

        public fsMachineDialog()
        {
            InitializeComponent();
        }

        private Dictionary<string, fsModule> m_modules;

        internal void AssignModulesList(List<fsModule> modules)
        {
            var list = new List<string>();
            m_modules = new Dictionary<string, fsModule>();
            foreach (fsModule module in modules)
            {
                list.Add(module.Name);
                m_modules.Add(module.Name, module);
            }
            fsCheckedList1.AssignList(list);
        }

        private void cancelButton_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OKButton_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        internal IEnumerable<fsModule> GetModifiedModules()
        {
            List<fsModule> checkedModules = new List<fsModule>();
            foreach (ListViewItem item in fsCheckedList1.GetCheckedItems())
            {
                checkedModules.Add(m_modules[item.Text]);
            }
            return checkedModules;
        }
    }
}