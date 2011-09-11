using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Parameters;
using Value;
using StepCalculators;
using System.Threading;
using UpdateHandler;

namespace WinFormsCakeFormationSample
{
    public partial class Form1 : Form
    {
        private Thread m_currentCalculation;

        private readonly Dictionary<fsParameterIdentifier, DataGridViewCell> m_parameterCell = new Dictionary<fsParameterIdentifier, DataGridViewCell>();
        private readonly Dictionary<DataGridViewCell, fsParameterIdentifier> m_cellParameter = new Dictionary<DataGridViewCell, fsParameterIdentifier>();
        private readonly Dictionary<fsParameterIdentifier, fsSimulationParameter> m_parameterValue = new Dictionary<fsParameterIdentifier, fsSimulationParameter>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var materialParameters = new[] {
                fsParameterIdentifier.FiltrateViscosity,
                fsParameterIdentifier.FiltrateDensity,
                fsParameterIdentifier.SolidsDensity,
                fsParameterIdentifier.SuspensionDensity,
                fsParameterIdentifier.MassConcentration,
                fsParameterIdentifier.VolumeConcentration,
                fsParameterIdentifier.Concentration,
                fsParameterIdentifier.Porosity0,
                fsParameterIdentifier.Kappa0,
                fsParameterIdentifier.Ne,
                fsParameterIdentifier.Pc0,
                fsParameterIdentifier.Rc0,
                fsParameterIdentifier.Alpha0,
                fsParameterIdentifier.Nc,
                fsParameterIdentifier.Hce0,
                fsParameterIdentifier.Rm0,
            };

            var cakeFormationParameters = new[] {
                fsParameterIdentifier.FilterArea,
                fsParameterIdentifier.Pressure,
                fsParameterIdentifier.CycleTime,
                fsParameterIdentifier.RotationalSpeed,
                fsParameterIdentifier.FormationRelativeTime,
                fsParameterIdentifier.FormationTime,
                fsParameterIdentifier.CakeHeight,
                fsParameterIdentifier.SuspensionMass,
                fsParameterIdentifier.SuspensionVolume,
                fsParameterIdentifier.SuspensionMassFlowrate
            };

            foreach (var p in materialParameters)
            {
                MaterialParametersDataGrid.Rows.Add(new object[] {p.Name + " (" + p.Units.CurrentName + ")"});
                var cell = MaterialParametersDataGrid.Rows[MaterialParametersDataGrid.Rows.Count - 1].Cells[1];
                m_parameterCell[p] = cell;
                m_cellParameter[cell] = p;
                m_parameterValue[p] = new fsSimulationParameter(p);
            }

            foreach (var p in cakeFormationParameters)
            {
                CakeFormationDataGrid.Rows.Add(new object[] { p.Name + " (" + p.Units.CurrentName + ")"});
                var cell = CakeFormationDataGrid.Rows[CakeFormationDataGrid.Rows.Count - 1].Cells[1];
                m_parameterCell[p] = cell;
                m_cellParameter[cell] = p;
                m_parameterValue[p] = new fsSimulationParameter(p);
            }

            m_parameterValue[fsParameterIdentifier.FiltrateDensity].IsInput = true;
            m_parameterValue[fsParameterIdentifier.SolidsDensity].IsInput = true;
            m_parameterValue[fsParameterIdentifier.SuspensionDensity].IsInput = true;
            m_parameterCell[fsParameterIdentifier.MassConcentration].ReadOnly = true;
            m_parameterCell[fsParameterIdentifier.VolumeConcentration].ReadOnly = true;
            m_parameterCell[fsParameterIdentifier.Concentration].ReadOnly = true;

            m_parameterValue[fsParameterIdentifier.FilterArea].IsInput = true;
            m_parameterValue[fsParameterIdentifier.Pressure].IsInput = true;
        }

        private void MaterialParametersDataGrid_CellValueChangedByUser(object sender, DataGridViewCellEventArgs e)
        {
            ProcessParameterChange(((DataGridView) sender)[e.ColumnIndex, e.RowIndex]);
        }

        private void ProcessParameterChange(DataGridViewCell cell)
        {
            if (m_cellParameter.ContainsKey(cell))
            {
                var id = m_cellParameter[cell];
                var param = m_parameterValue[id];
                
                fsValue oldValue = param.Value;
                fsValue newValue = fsValue.ObjectToValue(cell.Value) * param.Identifier.Units.CurrentCoefficient;
                Text = param.Identifier.Name + @" changed from " + oldValue.ToString() + @" to " + newValue.ToString();
                param.Value = newValue;

                UpdateInputs(cell);

                Recalculate();
            }
        }

        private void UpdateInputs(DataGridViewCell cell, params fsParameterIdentifier [] parameters)
        {
            var parameter = m_cellParameter.ContainsKey(cell)
                ? m_cellParameter[cell]
                : null;
            if (parameters.Contains(parameter))
                foreach (var p in parameters)
                {
                    var pcell = m_parameterCell[p];
                    bool isInput = cell == pcell;
                    m_parameterValue[p].IsInput = isInput;
                    pcell.Style.ForeColor = isInput ? Color.Blue : Color.Black;
                }
        }

        private void UpdateInputs(DataGridViewCell cell)
        {
            UpdateInputs(cell, 
                fsParameterIdentifier.Porosity0,
                fsParameterIdentifier.Kappa0);

            UpdateInputs(cell,
                fsParameterIdentifier.Pc0,
                fsParameterIdentifier.Rc0,
                fsParameterIdentifier.Alpha0);

            UpdateInputs(cell,
                fsParameterIdentifier.Rm0,
                fsParameterIdentifier.Hce0);

            UpdateInputs(cell,
                fsParameterIdentifier.CycleTime,
                fsParameterIdentifier.RotationalSpeed);

            UpdateInputs(cell,
                fsParameterIdentifier.FormationTime,
                fsParameterIdentifier.FormationRelativeTime,
                fsParameterIdentifier.CakeHeight,
                fsParameterIdentifier.SuspensionMass,
                fsParameterIdentifier.SuspensionVolume);
        }

        private void Recalculate()
        {
            if (useMultiThreadingFlag.Checked)
            {
                if (m_currentCalculation != null)
                {
                    m_currentCalculation.Abort();
                    m_currentCalculation = null;
                }
                m_currentCalculation = new Thread(CalculateInThread);
                m_currentCalculation.Start();
            }
            else
            {
                CalculateInThread();
            }
        }

        private void CalculateInThread()
        {
            var uh = new fsCalculatorUpdateHandler(fsLabeledProgressBar1);
            errorMessageTextBox.Text = "";

            var calcsList = new fsCalculator [] {
                new fsDensityConcentrationCalculator(),
                new fsEps0Kappa0Calculator(),
                new fsPc0rc0alpha0Calculator(),
                new fsRm0hce0Calculator(),
                new fsCakeFormationDpConstCalculator(),
            };
            
            var progressSplitters = new double[calcsList.Length + 1];
            int totalAmount = calcsList.Sum(t => t.GetToCalculateAmount());
            int currentAmount = 0;
            for (int i = 0; i < calcsList.Length; ++i)
            {
                progressSplitters[i] = (double)currentAmount / totalAmount;
                currentAmount += calcsList[i].GetToCalculateAmount();
            }
            progressSplitters[calcsList.Length] = 1;

            for (int i = 0; i < calcsList.Length; ++i)
            {
                var calc = calcsList[i];
                calc.SetUpdateHandler(uh.CreateSubHandler(
                    progressSplitters[i],
                    progressSplitters[i + 1]));
                ApplyCalculator(calc);
            }

            foreach (var p in m_parameterValue.Keys)
            {
                var value = m_parameterValue[p];
                if (value.IsInput == false)
                {
                    m_parameterCell[p].Value = value.ValueToStringWithCurrentUnits();
                }
            }
        }
        private void ApplyCalculator(fsCalculator calculator)
        {
            calculator.ReadDataFromStorage(m_parameterValue);
            calculator.Calculate();
            errorMessageTextBox.Text += calculator.GetStatusMessage();
            calculator.CopyValuesToStorage(m_parameterValue);
        }
        private void CakeFormationDataGrid_CellValueChangedByUser(object sender, DataGridViewCellEventArgs e)
        {
            ProcessParameterChange(((DataGridView) sender)[e.ColumnIndex, e.RowIndex]);
        }
    }
}
