using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Parameters;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using StepCalculators;
using Value;

namespace Calculator.Calculation_Controls
{
    public class CalculatorControl : UserControl
    {
        #region Calculation Data
        
        protected Dictionary<fsParameterIdentifier, fsNamedValueParameter> Values { get; private set; }
        
        #endregion

        virtual protected void UpdateUIFromData()
        {
            throw new NotImplementedException();
        }
        virtual protected void ConnectUIWithDataUpdating()
        {
            throw new NotImplementedException();
        }
        virtual protected void UpdateCalculationOptionAndInputGroups()
        {
            throw new NotImplementedException();
        }

        #region UI data

        protected Dictionary<fsParameterIdentifier, DataGridViewCell> ParameterToCell { get; private set; }
        protected Dictionary<DataGridViewCell, fsParameterIdentifier> CellToParameter { get; private set; }

        #endregion

        public CalculatorControl()
        {
            Values = new Dictionary<fsParameterIdentifier, fsNamedValueParameter>();
            ParameterToCell = new Dictionary<fsParameterIdentifier,DataGridViewCell>();
            CellToParameter = new Dictionary<DataGridViewCell,fsParameterIdentifier>();
            Calculators = new List<fsCalculator>();
            Groups = new List<ParametersGroup>();
            ParameterToGroup = new Dictionary<fsParameterIdentifier, ParametersGroup>();
        }

        #region Routines

        protected List<fsCalculator> Calculators { get; private set; }
        protected List<ParametersGroup> Groups { get; private set; }
        protected Dictionary<fsParameterIdentifier, ParametersGroup> ParameterToGroup { get; private set; }

        public ParametersGroup AddGroup(params fsParameterIdentifier[] parameters)
        {
            ParametersGroup group = new ParametersGroup();
            foreach (var parameter in parameters)
            {
                group.Parameters.Add(parameter);
                ParameterToGroup[parameter] = group;
            }
            group.Representator = group.Parameters[0];
            Groups.Add(group);
            return group;
        }


        protected void AddGroupToUI(DataGridView dataGrid, ParametersGroup group, Color color)
        {
            foreach (var p in group.Parameters)
            {
                Values.Add(p, new fsSimulationParameter(p));
                AddRow(dataGrid, p, color);
            }
        }

        protected void AddRow(DataGridView dataGrid, fsParameterIdentifier parameter, Color color)
        {
            int ind = dataGrid.Rows.Add(new[] { parameter.ToString() + " [" + parameter.Units.CurrentName + "]", "" });
            foreach (DataGridViewCell cell in dataGrid.Rows[ind].Cells)
            {
                cell.Style.BackColor = color;
            }
            AssignParameterAndCell(parameter, dataGrid.Rows[ind].Cells[1]);
        }

        protected void AssignParameterAndCell(fsParameterIdentifier parameter, DataGridViewCell dataGridViewCell)
        {
            ParameterToCell.Add(parameter, dataGridViewCell);
            CellToParameter.Add(dataGridViewCell, parameter);
        }

        protected void ProcessNewEntry(DataGridViewCell cell)
        {
            if (cell != null && CellToParameter.ContainsKey(cell))
            {
                var parameter = CellToParameter[cell];
                UpdateInputInGroup(parameter);
                ReadEnteredValue(cell, parameter);
                Recalculate();
                WriteValuesToDataGrid();
            }
        }

        protected void Recalculate()
        {
            Dictionary<fsParameterIdentifier, fsSimulationParameter> localValues = new Dictionary<fsParameterIdentifier, fsSimulationParameter>();
            
            foreach (var parameter in Values.Keys)
            {
                localValues[parameter] = ParameterToGroup[parameter].IsInput && parameter == ParameterToGroup[parameter].Representator
                    ? new fsSimulationParameter(parameter, true, Values[parameter].Value)
                    : localValues[parameter] = new fsSimulationParameter(parameter);
            }
            
            foreach (var calc in Calculators)
            {
                calc.ReadDataFromStorage(localValues);
                calc.Calculate();
                calc.CopyValuesToStorage(localValues);
            }
            
            foreach (var parameter in Values.Keys)
            {
                Values[parameter].Value = localValues[parameter].Value;
            }
        }


        protected void WriteValuesToDataGrid()
        {
            foreach (var p in Values.Keys)
            {
                ParameterToCell[p].Value = Values[p].Value / p.Units.CurrentCoefficient;
            }
        }

        protected void UpdateCellForeColors()
        {
            foreach (var p in ParameterToCell)
            {
                var group = ParameterToGroup[p.Key];
                p.Value.Style.ForeColor = group.IsInput && group.Representator == p.Key ? Color.Blue : Color.Black;
            }
        }

        protected void UpdateInputInGroup(fsParameterIdentifier parameter)
        {
            var g = ParameterToGroup[parameter];
            g.Representator = parameter;
            foreach (var p in g.Parameters)
            {
                ParameterToCell[p].Style.ForeColor = p == parameter ? Color.Blue : Color.Black;
            }
        }

        protected void ReadEnteredValue(DataGridViewCell cell, fsParameterIdentifier parameter)
        {
            var value = Values[parameter];
            value.Value = fsValue.ObjectToValue(cell.Value) * parameter.Units.CurrentCoefficient;
        }


        #endregion
    }
}
