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
                fsParameterIdentifier.hce0,
                fsParameterIdentifier.Rm0,
            };

            fsParameterIdentifier[] CakeFormationParameters = new fsParameterIdentifier[] {
                fsParameterIdentifier.FilterArea,
                fsParameterIdentifier.Pressure,
                fsParameterIdentifier.CakeHeight,
                fsParameterIdentifier.CycleTime,
                fsParameterIdentifier.FormationRelativeTime,
                fsParameterIdentifier.FormationTime
            };

            foreach (var p in MaterialParameters)
            {
                MaterialParametersDataGrid.Rows.Add(new object[] {p.Name});
                var cell = MaterialParametersDataGrid.Rows[MaterialParametersDataGrid.Rows.Count - 1].Cells[1];
                parameterCell[p] = cell;
                cellParameter[cell] = p;
                parameterValue[p] = new fsSimulationParameter(p);
            }

            foreach (var p in CakeFormationParameters)
            {
                CakeFormationDataGrid.Rows.Add(new object[] { p.Name });
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
                fsValue newValue = fsValue.ObjectToValue(cell.Value);
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
                    parameterValue[p].isInput = cell == parameterCell[p];
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
                new fsRm0hce0Calculator()
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
                    parameterCell[p].Value = value.Value.ToString();
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
