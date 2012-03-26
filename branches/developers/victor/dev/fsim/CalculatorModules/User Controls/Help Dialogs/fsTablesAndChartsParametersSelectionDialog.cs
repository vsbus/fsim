using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Parameters;

namespace CalculatorModules.User_Controls.Help_Dialogs
{
    public partial class fsTablesAndChartsParametersSelectionDialog : Form
    {
        public fsTablesAndChartsParametersSelectionDialog()
        {
            InitializeComponent();
        }

        public class fsYAxisParameter
        {
            public enum fsYParameterKind
            {
                InputParameter,
                CalculatedConstantParameter,
                CalculatedVariableParameter
            }

            public fsParameterIdentifier Identifier { get; private set; }
            public fsYParameterKind Kind { get; private set; }

            public fsYAxisParameter(fsParameterIdentifier identifier, fsYParameterKind kind)
            {
                Identifier = identifier;
                Kind = kind;
            }

            public fsYAxisParameter(fsYAxisParameter other)
            {
                Identifier = other.Identifier;
                Kind = other.Kind;
            }
        }

        public class fsYAxisParameterWithChecking : fsYAxisParameter
        {
            public bool IsChecked { get; set; }

            public fsYAxisParameterWithChecking(fsParameterIdentifier identifier, fsYParameterKind kind, bool isChecked)
                : base(identifier, kind)
            {
                IsChecked = isChecked;
            }

            public fsYAxisParameterWithChecking(fsYAxisParameterWithChecking other)
                : base(other)
            {
                IsChecked = other.IsChecked;
            }
        }

        private List<fsYAxisParameterWithChecking> m_parameters;
        private readonly Dictionary<fsYAxisParameter.fsYParameterKind, Color> m_kindToColor = new Dictionary<fsYAxisParameter.fsYParameterKind, Color>()
        {
            {fsYAxisParameter.fsYParameterKind.InputParameter, Color.Blue},
            {fsYAxisParameter.fsYParameterKind.CalculatedConstantParameter, Color.Gray},
            {fsYAxisParameter.fsYParameterKind.CalculatedVariableParameter, Color.Black}
        };

        private Dictionary<ListViewItem, fsYAxisParameterWithChecking> m_itemToParameter =
            new Dictionary<ListViewItem, fsYAxisParameterWithChecking>();

        public void AssignParameters(List<fsYAxisParameterWithChecking> parameters)
        {
            m_parameters = new List<fsYAxisParameterWithChecking>();
            foreach (var selectionParameter in parameters)
            {
                m_parameters.Add(new fsYAxisParameterWithChecking(selectionParameter));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void fsTablesAndChartsParametersSelectionDialog_Load(object sender, EventArgs e)
        {
            if (m_parameters != null)
            {
                foreach (fsYAxisParameterWithChecking selectionParameter in m_parameters)
                {
                    var newItem = new ListViewItem(selectionParameter.Identifier.Name)
                                      {
                                          Checked = selectionParameter.IsChecked,
                                          ForeColor = m_kindToColor[selectionParameter.Kind]
                                      };
                    listView1.Items.Add(newItem);
                    m_itemToParameter[newItem] = selectionParameter;
                }
            }
        }

        internal List<fsParameterIdentifier> GetCheckedParameters()
        {
            var result = new List<fsParameterIdentifier>();
            foreach (fsYAxisParameterWithChecking yParameter in m_parameters)
            {
                if (yParameter.IsChecked)
                {
                    result.Add(yParameter.Identifier);
                }
            }
            return result;
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (m_itemToParameter.ContainsKey(e.Item))
            {
                m_itemToParameter[e.Item].IsChecked = e.Item.Checked;
            }
        }
    }
}
