using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Parameters;
using Value;
using System.Drawing;
using StepCalculators;

namespace Calculator.Calculation_Controls
{
    public class CalculationProcessor
    {
        public Dictionary<fsParameterIdentifier, fsNamedValueParameter> Values { get; private set; }
        public Dictionary<fsParameterIdentifier, DataGridViewCell> ParameterToCell { get; private set; }
        public Dictionary<DataGridViewCell, fsParameterIdentifier> CellToParameter { get; private set; }
        public List<fsCalculator> Calculators { get; private set; }

        public List<ParametersGroup> Groups { get; private set; }
        public Dictionary<fsParameterIdentifier, ParametersGroup> ParameterToGroup { get; private set; }

        public CalculationProcessor()
        {
            CellToParameter = new Dictionary<DataGridViewCell, fsParameterIdentifier>();
            ParameterToCell = new Dictionary<fsParameterIdentifier, DataGridViewCell>();
            Values = new Dictionary<fsParameterIdentifier, fsNamedValueParameter>();
            Groups = new List<ParametersGroup>();
            ParameterToGroup = new Dictionary<fsParameterIdentifier, ParametersGroup>();
            Calculators = new List<fsCalculator>();
        }


        public void SetGroupInputed(ParametersGroup g, bool isInput)
        {
            g.IsInput = isInput;
            if (isInput == true)
            {
                foreach (var p in g.Parameters)
                {
                    ParameterToCell[p].ReadOnly = false;
                    ParameterToCell[p].Style.ForeColor = p == g.Representator ? Color.Blue : Color.Black;
                }
            }
            else
            {
                foreach (var p in g.Parameters)
                {
                    ParameterToCell[p].ReadOnly = true;
                    ParameterToCell[p].Style.ForeColor = Color.Black;
                }
            }
        }

//         internal void CellValueChanged(DataGridViewCell cell)
//         {
//             if (CellToParameter.ContainsKey(cell))
//             {
//                 var parameter = CellToParameter[cell];
//                 UpdateInputInGroup(parameter);
//                 ReadEnteredValue(cell, parameter);
//             }
//             RecalculateAndOutput();
//         }


        private void WriteValuesToDataGrid()
        {
            foreach (var p in Values.Keys)
            {
                ParameterToCell[p].Value = Values[p].Value / p.Units.CurrentCoefficient;
            }
        }

    }
}
