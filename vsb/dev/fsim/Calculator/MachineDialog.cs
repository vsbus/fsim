using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Parameters;
using ParametersIdentifiers.Ranges;

namespace Calculator
{
    public partial class fsMachineDialog : Form
    {
        private Dictionary<string, fsModule> m_modules;

        public fsMachineDialog()
        {
            InitializeComponent();
        }

        public Dictionary<fsParameterIdentifier, fsRange> Ranges
        {
            get
            {
                return
                    fsMachineSettings1.ParameterRanges.Values.ToDictionary(parameterRange => parameterRange.Identifier,
                                                                           parameterRange => parameterRange.Range);
            }
        }

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

        internal IEnumerable<fsModule> GetModifiedModules()
        {
            return (from ListViewItem item in fsCheckedList1.GetCheckedItems() select m_modules[item.Text]).ToList();
        }

        #region Buttons Events

        private void CancelButtonClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OkButtonClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        #endregion
    }
}