﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Parameters;
using StepCalculators;
using Value;

namespace Calculator.Calculation_Controls
{
    public class fsCalculatorControl : UserControl
    {
        #region Calculation Data
        
        protected Dictionary<fsParameterIdentifier, fsNamedValueParameter> Values { get; private set; }
        protected object CalculationOption;
        
        #endregion

        #region UI data

        protected Dictionary<fsParameterIdentifier, DataGridViewCell> ParameterToCell { get; private set; }
        protected Dictionary<DataGridViewCell, fsParameterIdentifier> CellToParameter { get; private set; }
        protected Dictionary<object, RadioButton> CalculationOptionToRadioButton = new Dictionary<object, RadioButton>();
        protected Dictionary<object, fsParametersGroup> CalculationOptionToGroup = new Dictionary<object, fsParametersGroup>();

        #endregion

        public fsCalculatorControl()
        {
            Values = new Dictionary<fsParameterIdentifier, fsNamedValueParameter>();
            ParameterToCell = new Dictionary<fsParameterIdentifier,DataGridViewCell>();
            CellToParameter = new Dictionary<DataGridViewCell,fsParameterIdentifier>();
            Calculators = new List<fsCalculator>();
            Groups = new List<fsParametersGroup>();
            ParameterToGroup = new Dictionary<fsParameterIdentifier, fsParametersGroup>();
        }

        #region Routines

        virtual protected void UpdateUIFromData()
        {
            UpdateCellForeColors();
            WriteValuesToDataGrid();
            if (CalculationOption != null)
            {
                CalculationOptionToRadioButton[CalculationOption].Checked = true;
            }
        }

        virtual protected void RadioButtonCheckedChanged(object sender, EventArgs e)
        {
            UpdateCalculationOptionAndInputGroupsFromUI();
            Recalculate();
            UpdateUIFromData();
        }

        virtual protected void ConnectUIWithDataUpdating(fmDataGrid.fmDataGrid grid)
        {
            grid.CellValueChangedByUser += DataGridCellValueChangedByUser;
            foreach (var radioButton in CalculationOptionToRadioButton.Values)
            {
                radioButton.CheckedChanged += RadioButtonCheckedChanged;
            }
        }

        virtual protected void UpdateCalculationOptionAndInputGroupsFromUI()
        {
            foreach (var pair in CalculationOptionToRadioButton)
            {
                if (pair.Value.Checked)
                {
                    CalculationOption = pair.Key;
                    break;
                }
            }

            if (CalculationOption != null)
            {
                foreach (var group in Groups)
                {
                    SetGroupInput(group, CalculationOptionToGroup[CalculationOption] != group);
                }
            }
        }

        protected List<fsCalculator> Calculators { get; set; }
        protected List<fsParametersGroup> Groups { get; private set; }
        protected Dictionary<fsParameterIdentifier, fsParametersGroup> ParameterToGroup { get; private set; }

        protected void AssignCalculationOption(object calculationOption, RadioButton radioButton, fsParametersGroup group)
        {
            CalculationOptionToRadioButton[calculationOption] = radioButton;
            CalculationOptionToGroup[calculationOption] = group;
        }

        protected void SetGroupInput(fsParametersGroup group, bool value)
        {
            group.IsInput = value;
            foreach (var parameter in group.Parameters)
            {
                ParameterToCell[parameter].ReadOnly = !value;
            }
        }

        public fsParametersGroup AddGroup(params fsParameterIdentifier[] parameters)
        {
            var group = new fsParametersGroup();
            foreach (var parameter in parameters)
            {
                group.Parameters.Add(parameter);
                ParameterToGroup[parameter] = group;
            }
            group.Representator = group.Parameters[0];
            Groups.Add(group);
            return group;
        }

        protected void AddGroupToUI(DataGridView dataGrid, fsParametersGroup group, Color color)
        {
            foreach (var p in group.Parameters)
            {
                Values.Add(p, new fsSimulationParameter(p));
                AddRow(dataGrid, p, color);
            }
        }

        protected void DataGridCellValueChangedByUser(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView)
            {
                ProcessNewEntry(((DataGridView)sender).CurrentCell);
            }
            UpdateUIFromData();
        }

        protected void AddRow(DataGridView dataGrid, fsParameterIdentifier parameter, Color color)
        {
            int ind = dataGrid.Rows.Add(new[] { parameter + " [" + parameter.Units.CurrentName + "]", "" });
            SetRowColor(dataGrid, ind, color);
            AssignParameterAndCell(parameter, dataGrid.Rows[ind].Cells[1]);
        }

        protected void SetRowColor(DataGridView dataGrid, int ind, Color color)
        {
            foreach (DataGridViewCell cell in dataGrid.Rows[ind].Cells)
            {
                cell.Style.BackColor = color;
            }
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
            var localValues = new Dictionary<fsParameterIdentifier, fsSimulationParameter>();
            
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
            foreach (var pair in ParameterToCell)
            {
                var group = ParameterToGroup[pair.Key];
                if (group.IsInput)
                {
                    pair.Value.Style.ForeColor = group.Representator == pair.Key
                        ? Color.Blue
                        : Color.Black;    
                }
                else
                {
                    pair.Value.Style.ForeColor = Color.Black;
                }
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
