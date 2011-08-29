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
                fsParameterIdentifier.etaf,
                fsParameterIdentifier.SuspensionDensity,
                fsParameterIdentifier.hce0,
                fsParameterIdentifier.kappa,
                fsParameterIdentifier.Pc,
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
            }

            foreach (var p in CakeFormationParameters)
            {
                CakeFormationDataGrid.Rows.Add(new object[] { p.Name });
                var cell = CakeFormationDataGrid.Rows[CakeFormationDataGrid.Rows.Count - 1].Cells[1];
                parameterCell[p] = cell;
                cellParameter[cell] = p;
            }

            
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
                if (parameterValue.ContainsKey(id) == false)
                {
                    parameterValue[id] = new fsSimulationParameter(id);
                }
                var param = parameterValue[id];
                fsValue oldValue = param.Value;
                fsValue newValue = fsValue.ObjectToValue(cell.Value);
                param.Value = newValue;
                Text = param.Identifier.Name + " changed from " + oldValue.ToString() + " to " + newValue.ToString();
            }
        }

        private void CakeFormationDataGrid_CellValueChangedByUser(object sender, DataGridViewCellEventArgs e)
        {
            ProcessParameterChange((sender as DataGridView)[e.ColumnIndex, e.RowIndex]);
        }
    }
}
