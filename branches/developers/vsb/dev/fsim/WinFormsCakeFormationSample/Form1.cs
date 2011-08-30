using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Parameters;
using Value;
using StepCalculators;

namespace WinFormsCakeFormationSample
{
    public partial class Form1 : Form
    {
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
                
                if (cell == parameterCell[fsParameterIdentifier.Porosity0])
                {
                    parameterValue[fsParameterIdentifier.Porosity0].isInput = true;
                    parameterValue[fsParameterIdentifier.kappa0].isInput = false;
                }
                if (cell == parameterCell[fsParameterIdentifier.kappa0])
                {
                    parameterValue[fsParameterIdentifier.Porosity0].isInput = false;
                    parameterValue[fsParameterIdentifier.kappa0].isInput = true;
                }

                Recalculate();
            }
        }

        private void Recalculate()
        {
            ApplyCalculator(new fsDensityConcentrationCalculator());
            ApplyCalculator(new fsEps0Kappa0Calculator());
            
            foreach (var p in parameterValue.Keys)
            {
                var value = parameterValue[p];
                if (value.isInput == false)
                {
                    parameterCell[p].Value = value.Value.ToString();
                }
            }
        }

        private void ApplyCalculator(fsStepCalculator calculator)
        {
            calculator.ReadDataFromStorage(parameterValue);
            calculator.Calculate();
            calculator.CopyValuesToStorage(parameterValue);
        }
        private void CakeFormationDataGrid_CellValueChangedByUser(object sender, DataGridViewCellEventArgs e)
        {
            ProcessParameterChange((sender as DataGridView)[e.ColumnIndex, e.RowIndex]);
        }
    }
}
