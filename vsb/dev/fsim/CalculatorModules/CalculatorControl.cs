using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Parameters;
using ParametersIdentifiers.Interfaces;
using StepCalculators;
using Units;
using Value;

namespace CalculatorModules
{
    public abstract class fsCalculatorControl : UserControl
    {
        #region Calculation Data

        protected Dictionary<Type, Enum> CalculationOptions = new Dictionary<Type, Enum>();
        protected Dictionary<fsParameterIdentifier, fsMeasuredParameter> Values { get; private set; }

        #endregion

        #region UI data

        protected Dictionary<Type, Control> CalculationOptionToControl = new Dictionary<Type, Control>();

        protected Dictionary<object, fsParametersGroup> CalculationOptionToGroup =
            new Dictionary<object, fsParametersGroup>();

        protected Dictionary<Control, Type> ControlToCalculationOption = new Dictionary<Control, Type>();
        protected Dictionary<fsParameterIdentifier, DataGridViewCell> ParameterToCell { get; private set; }
        protected Dictionary<DataGridViewCell, fsParameterIdentifier> CellToParameter { get; private set; }

        #endregion

        public fsCalculatorControl()
        {
            Values = new Dictionary<fsParameterIdentifier, fsMeasuredParameter>();
            ParameterToCell = new Dictionary<fsParameterIdentifier, DataGridViewCell>();
            CellToParameter = new Dictionary<DataGridViewCell, fsParameterIdentifier>();
            Calculators = new List<fsCalculator>();
            Groups = new List<fsParametersGroup>();
            ParameterToGroup = new Dictionary<fsParameterIdentifier, fsParametersGroup>();
        }

        #region Routines

        protected List<fsCalculator> Calculators { get; set; }
        protected List<fsParametersGroup> Groups { get; private set; }
        protected Dictionary<fsParameterIdentifier, fsParametersGroup> ParameterToGroup { get; private set; }

        protected void EstablishCalculationOption(Enum option)
        {
            CalculationOptions[option.GetType()] = option;
        }

        protected void AssignCalculationOptionAndControl(Type type, ComboBox comboBox)
        {
            CalculationOptionToControl[type] = comboBox;
            ControlToCalculationOption[comboBox] = type;
        }

        protected virtual void UpdateUIFromData()
        {
            UpdateCellForeColors();
            WriteValuesToDataGrid();
            WriteCalculationOptionsToUI();
        }

        private void WriteCalculationOptionsToUI()
        {
            foreach (var keyValuePair in ControlToCalculationOption)
            {
                keyValuePair.Key.Text = fsMisc.GetEnumDescription(CalculationOptions[keyValuePair.Value]);
            }
        }

        protected virtual void CalculationOptionChanged(object sender, EventArgs e)
        {
            UpdateCalculationOptionFromUI();
            UpdateGroupsInputInfoFromCalculationOptions();
            UpdateEquationsFromCalculationOptions();
            Recalculate();
            UpdateUIFromData();
        }

        protected void ConnectUIWithDataUpdating(params Control[] controls)
        {
            foreach (Control control in controls)
            {
                if (control is DataGridView)
                {
                    var grid = control as fmDataGrid.fmDataGrid;
                    grid.CellValueChangedByUser += DataGridCellValueChangedByUser;
                }
                else if (control is RadioButton)
                {
                    throw new Exception("radio buttons doesn't supported");
                    //var radioButton = control as RadioButton;
                    //radioButton.CheckedChanged += CalculationOptionChanged;
                }
                else if (control is ComboBox)
                {
                    var comboBox = control as ComboBox;
                    comboBox.SelectedIndexChanged += CalculationOptionChanged;
                }
            }
        }

        protected virtual void UpdateGroupsInputInfoFromCalculationOptions()
        {
            throw new Exception("You should set up groups input info in this method. Override this methodin your class.");
        }

        protected virtual void UpdateEquationsFromCalculationOptions()
        {
            throw new Exception("it should set up equations here. Override this method.");
        }

        protected void UpdateCalculationOptionFromUI()
        {
            foreach (var pair in ControlToCalculationOption)
            {
                CalculationOptions[pair.Value] = fsMisc.GetEnum(pair.Value, pair.Key.Text);
            }
        }

        protected void SetGroupInput(fsParametersGroup group, bool value)
        {
            group.IsInput = value;
            foreach (fsParameterIdentifier parameter in group.Parameters)
            {
                ParameterToCell[parameter].ReadOnly = !value;
            }
        }

        public fsParametersGroup AddGroup(params fsParameterIdentifier[] parameters)
        {
            var group = new fsParametersGroup();
            foreach (fsParameterIdentifier parameter in parameters)
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
            foreach (fsParameterIdentifier p in group.Parameters)
            {
                var parameter = new fsMeasuredParameter(p);
                Values.Add(p, parameter);
                AddRow(dataGrid, parameter, color);
            }
        }

        protected void DataGridCellValueChangedByUser(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = ((DataGridView) sender).CurrentCell;
            if (cell == null || !CellToParameter.ContainsKey(cell))
                return;

            fsParameterIdentifier parameter = CellToParameter[cell];
            UpdateInputInGroup(parameter);
            ReadEnteredValue(cell, parameter);
            Recalculate();
            UpdateCellForeColors();
            WriteValuesToDataGrid();
        }

        protected void AddRow(DataGridView dataGrid, fsMeasuredParameter parameter, Color color)
        {
            int ind = dataGrid.Rows.Add(new[] {parameter.ToString(), ""});
            SetRowColor(dataGrid, ind, color);
            AssignParameterAndCell(parameter.Identifier, dataGrid.Rows[ind].Cells[1]);
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

        protected virtual void Recalculate()
        {
            fsCalculationProcessor.ProcessCalculatorParameters(Values, ParameterToGroup, Calculators);
        }

        protected void WriteValuesToDataGrid()
        {
            foreach (fsParameterIdentifier p in Values.Keys)
            {
                ParameterToCell[p].Value = Values[p].GetValueInUnits();
            }
        }

        protected void UpdateCellForeColors()
        {
            foreach (var pair in ParameterToCell)
            {
                fsParametersGroup group = ParameterToGroup[pair.Key];
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
            fsParametersGroup g = ParameterToGroup[parameter];
            g.Representator = parameter;
            foreach (fsParameterIdentifier p in g.Parameters)
            {
                ParameterToCell[p].Style.ForeColor = p == parameter ? Color.Blue : Color.Black;
            }
        }

        protected void ReadEnteredValue(DataGridViewCell cell, fsParameterIdentifier parameter)
        {
            fsMeasuredParameter value = Values[parameter];
            value.SetValueInUnits(fsValue.ObjectToValue(cell.Value));
        }

        #endregion

        public void SetUnits(Dictionary<fsCharacteristic, fsUnit> dictionary)
        {
            StopGridsEdit();

            foreach (fsParameterIdentifier identifier in Values.Keys)
            {
                fsMeasuredParameter parameter = Values[identifier];
                if (dictionary.ContainsKey(identifier.MeasurementCharacteristic))
                {
                    parameter.Unit = dictionary[identifier.MeasurementCharacteristic];
                    DataGridViewCell valueCell = ParameterToCell[identifier];
                    DataGridViewCell parameterNameCell =
                        valueCell.DataGridView[valueCell.ColumnIndex - 1, valueCell.RowIndex];
                    parameterNameCell.Value = parameter.ToString();
                    valueCell.Value = parameter.GetValueInUnits();
                }
            }
            Recalculate();
        }

        protected abstract void StopGridsEdit();
    }
}