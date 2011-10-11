using System.Collections.Generic;
using System.Windows.Forms;
using Parameters;
using System.Drawing;
using StepCalculators;

namespace Calculator.Calculation_Controls
{
    public class fsCalculationProcessor
    {
        public Dictionary<fsParameterIdentifier, fsNamedValueParameter> Values { get; private set; }
        public Dictionary<fsParameterIdentifier, DataGridViewCell> ParameterToCell { get; private set; }
        public Dictionary<DataGridViewCell, fsParameterIdentifier> CellToParameter { get; private set; }
        public List<fsCalculator> Calculators { get; private set; }

        public List<fsParametersGroup> Groups { get; private set; }
        public Dictionary<fsParameterIdentifier, fsParametersGroup> ParameterToGroup { get; private set; }

        public fsCalculationProcessor()
        {
            CellToParameter = new Dictionary<DataGridViewCell, fsParameterIdentifier>();
            ParameterToCell = new Dictionary<fsParameterIdentifier, DataGridViewCell>();
            Values = new Dictionary<fsParameterIdentifier, fsNamedValueParameter>();
            Groups = new List<fsParametersGroup>();
            ParameterToGroup = new Dictionary<fsParameterIdentifier, fsParametersGroup>();
            Calculators = new List<fsCalculator>();
        }


        public void SetGroupInputed(fsParametersGroup g, bool isInput)
        {
            g.IsInput = isInput;
            if (isInput)
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
    }
}
