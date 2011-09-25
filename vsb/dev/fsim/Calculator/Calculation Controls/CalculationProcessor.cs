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

        public class Group
        {
            public List<fsParameterIdentifier> Parameters { get; private set; }
            public fsParameterIdentifier Representator { get; set; }
            public bool IsInput { get; set; }

            public Group()
            {
                Parameters = new List<fsParameterIdentifier>();
                Representator = null;
                IsInput = false;
            }
        }

        public List<Group> Groups { get; private set; }
        public Dictionary<fsParameterIdentifier, Group> ParameterToGroup { get; private set; }

        public void SetGroupInputed(Group g, bool isInput)
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

        public CalculationProcessor()
        {
            CellToParameter = new Dictionary<DataGridViewCell, fsParameterIdentifier>();
            ParameterToCell = new Dictionary<fsParameterIdentifier, DataGridViewCell>();
            Values = new Dictionary<fsParameterIdentifier, fsNamedValueParameter>();
            Groups = new List<Group>();
            ParameterToGroup = new Dictionary<fsParameterIdentifier, Group>();
            Calculators = new List<fsCalculator>();
        }

        internal void AssignParameterAndCell(fsParameterIdentifier parameter, DataGridViewCell dataGridViewCell)
        {
            Values.Add(parameter, new fsSimulationParameter(parameter));
            ParameterToCell.Add(parameter, dataGridViewCell);
            CellToParameter.Add(dataGridViewCell, parameter);
        }

        internal void CellValueChanged(DataGridViewCell cell)
        {
            if (CellToParameter.ContainsKey(cell))
            {
                var parameter = CellToParameter[cell];
                UpdateInputInGroup(parameter);
                ReadEnteredValue(cell, parameter);
                Recalculate();
                WriteValuesToDataGrid();
            }
        }

        private void WriteValuesToDataGrid()
        {
            foreach (var p in Values.Keys)
            {
                ParameterToCell[p].Value = Values[p].Value / p.Units.CurrentCoefficient;
            }
        }

        private void Recalculate()
        {
            Dictionary<fsParameterIdentifier, fsSimulationParameter> localValues = new Dictionary<fsParameterIdentifier, fsSimulationParameter>();
            foreach (var p in Values.Keys)
            {
                if (ParameterToGroup[p].IsInput && p == ParameterToGroup[p].Representator)
                {
                    localValues[p] = new fsSimulationParameter(
                        p,
                        true,
                        Values[p].Value);
                }
                else
                {
                    localValues[p] = new fsSimulationParameter(p);
                }
            }
            foreach (var calc in Calculators)
            {
                calc.ReadDataFromStorage(localValues);
                calc.Calculate();
                calc.CopyValuesToStorage(localValues);
            }
            foreach (var p in Values.Keys)
            {
                Values[p].Value = localValues[p].Value;
            }
        }

        private void ReadEnteredValue(DataGridViewCell cell, fsParameterIdentifier parameter)
        {
            var value = Values[parameter];
            value.Value = fsValue.ObjectToValue(cell.Value) * parameter.Units.CurrentCoefficient;
        }

        private void UpdateInputInGroup(fsParameterIdentifier parameter)
        {
            var g = ParameterToGroup[parameter];
            g.Representator = parameter;
            foreach (var p in g.Parameters)
            {
                ParameterToCell[p].Style.ForeColor = p == parameter ? Color.Blue : Color.Black;
            }
        }

        public Group AddGroup(params fsParameterIdentifier [] parameters)
        {
            Group group = new Group();
            foreach (var p in parameters)
            {
                group.Parameters.Add(p);
                ParameterToGroup[p] = group;
            }
            group.Representator = group.Parameters[0];
            Groups.Add(group);
            return group;
        }
    }
}
