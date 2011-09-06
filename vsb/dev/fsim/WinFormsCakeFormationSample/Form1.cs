using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
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
        private Thread m_currentCalculation = null;

        private Dictionary<fsParameterIdentifier, DataGridViewCell> parameterCell = new Dictionary<fsParameterIdentifier, DataGridViewCell>();
        private Dictionary<DataGridViewCell, fsParameterIdentifier> cellParameter = new Dictionary<DataGridViewCell, fsParameterIdentifier>();
        private Dictionary<fsParameterIdentifier, fsSimulationParameter> parameterValue = new Dictionary<fsParameterIdentifier, fsSimulationParameter>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fsParameterIdentifier[] MaterialParameters = new fsParameterIdentifier[] {
                fsParameterIdentifier.FiltrateViscosity,
                fsParameterIdentifier.FiltrateDensity,
                fsParameterIdentifier.SolidsDensity,
                fsParameterIdentifier.SuspensionDensity,
                fsParameterIdentifier.MassConcentration,
                fsParameterIdentifier.VolumeConcentration,
                fsParameterIdentifier.Concentration,
                fsParameterIdentifier.Porosity0,
                fsParameterIdentifier.kappa0,
                fsParameterIdentifier.ne,
                fsParameterIdentifier.Pc0,
                fsParameterIdentifier.rc0,
                fsParameterIdentifier.alpha0,
                fsParameterIdentifier.nc,
                fsParameterIdentifier.hce0,
                fsParameterIdentifier.Rm0,
            };

            fsParameterIdentifier[] CakeFormationParameters = new fsParameterIdentifier[] {
                fsParameterIdentifier.FilterArea,
                fsParameterIdentifier.Pressure,
                fsParameterIdentifier.CycleTime,
                fsParameterIdentifier.RotationalSpeed,
                fsParameterIdentifier.FormationRelativeTime,
                fsParameterIdentifier.FormationTime,
                fsParameterIdentifier.CakeHeight
            };

            foreach (var p in MaterialParameters)
            {
                MaterialParametersDataGrid.Rows.Add(new object[] {p.Name + " (" + p.Units.CurrentName + ")"});
                var cell = MaterialParametersDataGrid.Rows[MaterialParametersDataGrid.Rows.Count - 1].Cells[1];
                parameterCell[p] = cell;
                cellParameter[cell] = p;
                parameterValue[p] = new fsSimulationParameter(p);
            }

            foreach (var p in CakeFormationParameters)
            {
                CakeFormationDataGrid.Rows.Add(new object[] { p.Name + " (" + p.Units.CurrentName + ")"});
                var cell = CakeFormationDataGrid.Rows[CakeFormationDataGrid.Rows.Count - 1].Cells[1];
                parameterCell[p] = cell;
                cellParameter[cell] = p;
                parameterValue[p] = new fsSimulationParameter(p);
            }

            parameterValue[fsParameterIdentifier.FiltrateDensity].isInput = true;
            parameterValue[fsParameterIdentifier.SolidsDensity].isInput = true;
            parameterValue[fsParameterIdentifier.SuspensionDensity].isInput = true;
            parameterCell[fsParameterIdentifier.MassConcentration].ReadOnly = true;
            parameterCell[fsParameterIdentifier.VolumeConcentration].ReadOnly = true;
            parameterCell[fsParameterIdentifier.Concentration].ReadOnly = true;

            parameterValue[fsParameterIdentifier.FilterArea].isInput = true;
            parameterValue[fsParameterIdentifier.Pressure].isInput = true;
        }

        private void MaterialParametersDataGrid_CellValueChangedByUser(object sender, DataGridViewCellEventArgs e)
        {
            ProcessParameterChange((sender as DataGridView)[e.ColumnIndex, e.RowIndex]);
        }

        private void ProcessParameterChange(DataGridViewCell cell)
        {
            if (cellParameter.ContainsKey(cell))
            {
                var id = cellParameter[cell];
                var param = parameterValue[id];
                
                fsValue oldValue = param.Value;
                fsValue newValue = fsValue.ObjectToValue(cell.Value) * param.Identifier.Units.CurrentCoefficient;
                Text = param.Identifier.Name + " changed from " + oldValue.ToString() + " to " + newValue.ToString();
                param.Value = newValue;

                UpdateInputs(cell);

                Recalculate();
            }
        }

        private void UpdateInputs(DataGridViewCell cell, params fsParameterIdentifier [] parameters)
        {
            var parameter = cellParameter.ContainsKey(cell)
                ? cellParameter[cell]
                : null;
            if (parameters.Contains(parameter))
                foreach (var p in parameters)
                {
                    var pcell = parameterCell[p];
                    bool isInput = cell == pcell;
                    parameterValue[p].isInput = isInput;
                    pcell.Style.ForeColor = isInput ? Color.Blue : Color.Black;
                }
        }

        private void UpdateInputs(DataGridViewCell cell)
        {
            UpdateInputs(cell, 
                fsParameterIdentifier.Porosity0,
                fsParameterIdentifier.kappa0);

            UpdateInputs(cell,
                fsParameterIdentifier.Pc0,
                fsParameterIdentifier.rc0,
                fsParameterIdentifier.alpha0);

            UpdateInputs(cell,
                fsParameterIdentifier.Rm0,
                fsParameterIdentifier.hce0);

            UpdateInputs(cell,
                fsParameterIdentifier.CycleTime,
                fsParameterIdentifier.RotationalSpeed);

            UpdateInputs(cell,
                fsParameterIdentifier.FormationTime,
                fsParameterIdentifier.FormationRelativeTime,
                fsParameterIdentifier.CakeHeight);
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
                m_currentCalculation = new Thread(new ThreadStart(CalculateInThread));
                m_currentCalculation.Start();
            }
            else
            {
                CalculateInThread();
            }
        }

        private void CalculateInThread()
        {
            fsCalculatorUpdateHandler uh = new fsCalculatorUpdateHandler(fsLabeledProgressBar1);
            errorMessageTextBox.Text = "";

            var calcsList = new fsCalculator [] {
                new fsDensityConcentrationCalculator(),
                new fsEps0Kappa0Calculator(),
                new fsPc0rc0alpha0Calculator(),
                new fsRm0hce0Calculator(),
                new fsCakeFormationDpConstCalculator(),
            };
            
            var progressSplitters = new double[calcsList.Length + 1];
            int totalAmount = 0;
            for (int i = 0; i < calcsList.Length; ++i)
            {
                totalAmount += calcsList[i].GetToCalculateAmount();
            }
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

            foreach (var p in parameterValue.Keys)
            {
                var value = parameterValue[p];
                if (value.isInput == false)
                {
                    parameterCell[p].Value = value.ValueToStringWithCurrentUnits();
                }
            }
        }
        private void ApplyCalculator(fsCalculator calculator)
        {
            calculator.ReadDataFromStorage(parameterValue);
            calculator.Calculate();
            errorMessageTextBox.Text += calculator.GetStatusMessage();
            calculator.CopyValuesToStorage(parameterValue);
        }
        private void CakeFormationDataGrid_CellValueChangedByUser(object sender, DataGridViewCellEventArgs e)
        {
            ProcessParameterChange((sender as DataGridView)[e.ColumnIndex, e.RowIndex]);
        }
    }
}
