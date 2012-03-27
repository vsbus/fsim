using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
        private readonly Dictionary<fsYAxisParameter.fsYParameterKind, Color> m_kindToColor = new Dictionary<fsYAxisParameter.fsYParameterKind, Color>
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

        private void TablesAndChartsParametersSelectionDialogLoad(object sender, EventArgs e)
        {
            BuildLists();
        }

        private void BuildLists()
        {
            if (m_parameters != null)
            {
                m_itemToParameter = new Dictionary<ListViewItem, fsYAxisParameterWithChecking>();
                materialParametersListView.Items.Clear();
                otherParametersListView.Items.Clear();

                if (inputsCheckBox.Checked)
                {
                    AddParametersToLists(fsYAxisParameter.fsYParameterKind.InputParameter);
                }
                if (constantsCheckBox.Checked)
                {
                    AddParametersToLists(fsYAxisParameter.fsYParameterKind.CalculatedConstantParameter);
                }
                AddParametersToLists(fsYAxisParameter.fsYParameterKind.CalculatedVariableParameter);
            }
        }

        private void AddParametersToLists(fsYAxisParameter.fsYParameterKind kindToAdd)
        {
            var materialParameters = new[]
                                             {
                                                 fsParameterIdentifier.ViscosityFiltrate,
                                                 fsParameterIdentifier.FiltrateDensity,
                                                 fsParameterIdentifier.LiquidDensity,
                                                 fsParameterIdentifier.SolidsDensity,
                                                 fsParameterIdentifier.SuspensionDensity,
                                                 fsParameterIdentifier.SuspensionSolidsVolumeFraction,
                                                 fsParameterIdentifier.SuspensionSolidsMassFraction,
                                                 fsParameterIdentifier.SuspensionSolidsConcentration,
                                                 fsParameterIdentifier.CakePorosity0,
                                                 fsParameterIdentifier.CakePorosity,
                                                 fsParameterIdentifier.Kappa0,
                                                 fsParameterIdentifier.Kappa,
                                                 fsParameterIdentifier.Ne,
                                                 fsParameterIdentifier.CakePermeability0,
                                                 fsParameterIdentifier.CakePermeability,
                                                 fsParameterIdentifier.CakeResistance0,
                                                 fsParameterIdentifier.CakeResistance,
                                                 fsParameterIdentifier.CakeResistanceAlpha0,
                                                 fsParameterIdentifier.CakeResistanceAlpha,
                                                 fsParameterIdentifier.CakeCompressibility,
                                                 fsParameterIdentifier.FilterMediumResistanceHce0,
                                                 fsParameterIdentifier.DryCakeDensity0,
                                                 fsParameterIdentifier.DryCakeDensity,
                                                 fsParameterIdentifier.CakeWetDensity0,
                                                 fsParameterIdentifier.CakeWetDensity,
                                                 fsParameterIdentifier.CakeWetMassSolidsFractionRs0,
                                                 fsParameterIdentifier.CakeWetMassSolidsFractionRs,
                                                 fsParameterIdentifier.CakeMoistureContentRf0,
                                                 fsParameterIdentifier.CakeMoistureContentRf,

                                             };

            foreach (fsYAxisParameterWithChecking selectionParameter in m_parameters)
            {
                if (selectionParameter.Kind == kindToAdd)
                {
                    var newItem = new ListViewItem(selectionParameter.Identifier.Name)
                                      {
                                          Checked = selectionParameter.IsChecked,
                                          ForeColor = m_kindToColor[selectionParameter.Kind]
                                      };
                    if (materialParameters.Contains(selectionParameter.Identifier))
                    {
                        materialParametersListView.Items.Add(newItem);
                    }
                    else
                    {
                        otherParametersListView.Items.Add(newItem);
                    }
                    m_itemToParameter[newItem] = selectionParameter;
                }
            }
        }

        internal List<fsParameterIdentifier> GetCheckedParameters()
        {
            return (from yParameter in m_parameters where yParameter.IsChecked select yParameter.Identifier).ToList();
        }

        private void ListView1ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (m_itemToParameter.ContainsKey(e.Item))
            {
                m_itemToParameter[e.Item].IsChecked = e.Item.Checked;
            }
        }

        private void CheckBox1CheckedChanged(object sender, EventArgs e)
        {
            BuildLists();
        }

        private void CheckBox2CheckedChanged(object sender, EventArgs e)
        {
            BuildLists();
        }
    }
}
