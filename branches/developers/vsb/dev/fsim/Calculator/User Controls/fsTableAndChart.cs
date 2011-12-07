using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ParametersIdentifiers.Interfaces;
using StepCalculators;
using Parameters;
using Calculator.Calculation_Controls;
using Units;
using Value;
using ZedGraph;

namespace Calculator.User_Controls
{
    public partial class fsTableAndChart : UserControl
    {
        private List<fsCalculator> m_calculators;
        private Dictionary<fsParameterIdentifier, fsMeasuredParameter> m_values;
        private List<fsParametersGroup> m_groups;
        private Dictionary<fsParameterIdentifier, fsParametersGroup> m_parameterToGroup;

        public fsTableAndChart()
        {
            InitializeComponent();

            m_values = new Dictionary<fsParameterIdentifier, fsMeasuredParameter>();
        }

        bool m_diagramUpdate = false;

        public void Reprocess()
        {
            if (!m_diagramUpdate)
            {
                m_diagramUpdate = true;

                RefreshXAxisList();
                RefreshYAxisList();
                rangeFrom.Text = "0";
                rangeTo.Text = "100";
                if (detalizationBox.Text == "")
                {
                    detalizationBox.Text = "50";
                }

                m_diagramUpdate = false;

                UpdateDiagram();

            }
        }

        private void UpdateDiagram()
        {
            if (!m_diagramUpdate)
            {
                m_diagramUpdate = true;

                BuildData();
                BuildFunctions();
                RefreshCurves();
                RefreshTable();

                m_diagramUpdate = false;
            }
        }

        private class Function
        {
            public fsParameterIdentifier ParameterIdentifier;
            public fsUnit Unit;
            public List<fsValue> Values;

            public Function(fsParameterIdentifier parameterIdentifier, fsUnit unit)
            {
                ParameterIdentifier = parameterIdentifier;
                Unit = unit;
                Values = new List<fsValue>();
            }
        }

        private List<Function> m_functions = new List<Function>();

        private void BuildFunctions()
        {
            m_functions.Clear();
            var fx = new Function(m_data[0][0].Identifier, m_data[0][0].Unit);
            for (int row = 0; row < m_data.Count; ++row)
            {
                fx.Values.Add(m_data[row][0].GetValueInUnits());
            }
            m_functions.Add(fx);
            for (int col = 1; col < m_data[0].Count; ++col)
            {
                var parameter = m_data[0][col].Identifier;
                if (yAxisList.CheckedItems.Contains(parameter.Name))
                {
                    var fy = new Function(parameter, m_data[0][col].Unit);
                    for (int row = 0; row < m_data.Count; ++row)
                    {
                        fy.Values.Add(m_data[row][col].GetValueInUnits());
                    }
                    m_functions.Add(fy);
                }
            }
        }

        private void RefreshCurves()
        {
            if (m_functions.Count > 1)
            {
                fmZedGraphControl1.GraphPane.CurveList.Clear();

                double[] xValues = new double[m_data.Count];
                for (int row = 0; row < m_data.Count; ++row)
                {
                    xValues[row] = m_functions[0].Values[row].Value;
                }
                for (int col = 1; col < m_functions.Count; ++col)
                {
                    string name = m_functions[col].ParameterIdentifier.Name;
                    string unitName = m_functions[col].Unit.Name;
                    double[] yValues = new double[m_functions[col].Values.Count];
                    for (int row = 0; row < m_data.Count; ++row)
                    {
                        yValues[row] = m_functions[col].Values[row].Value;
                    }
                    LineItem curve = fmZedGraphControl1.GraphPane.AddCurve(name + " (" + unitName + ")",
                        xValues,
                        yValues,
                        Color.Black,
                        SymbolType.None);
                    curve.Line.IsAntiAlias = true;
                }

                fmZedGraphControl1.GraphPane.AxisChange();
                fmZedGraphControl1.Refresh();
            }
        }

        private List<List<fsMeasuredParameter>> m_data;

        private void RefreshTable()
        {
            table.Rows.Clear();
            table.Columns.Clear();
            if (m_functions.Count > 0)
            {
                table.ColumnCount = m_functions.Count;
                if (m_functions[0].Values.Count > 0)
                {
                    table.RowCount = m_functions[0].Values.Count;
                    for (int col = 0; col < table.ColumnCount; ++col)
                    {
                        table.Columns[col].HeaderCell.Value = m_functions[col].ParameterIdentifier.Name;
                        for (int row = 0; row < table.RowCount; ++row)
                        {
                            table[col, row].Value = m_functions[col].Values[row];
                        }
                    }
                }
            }
        }

        private void BuildData()
        {
            fsParameterIdentifier xParameter = null;
            foreach (var parameter in m_values.Keys)
            {
                if (parameter.Name == xAxisList.Text)
                {
                    xParameter = parameter;
                    break;
                }
            }

            int detalization = Convert.ToInt32(detalizationBox.Text);
            m_data = new List<List<fsMeasuredParameter>>();
            for (int i = 0; i < detalization; ++i)
            {
                Dictionary<fsParameterIdentifier, fsMeasuredParameter> currentValues = new Dictionary<fsParameterIdentifier, fsMeasuredParameter>();
                foreach (var pair in m_values)
                {
                    currentValues.Add(pair.Key, new fsMeasuredParameter(pair.Value));
                }

                fsValue from = fsValue.StringToValue(rangeFrom.Text);
                fsValue to = fsValue.StringToValue(rangeTo.Text);
                currentValues[xParameter].SetValueInUnits(from + (to - from) * i / detalization);

                fsCalculationProcessor.ProcessCalculatorParameters(currentValues, m_parameterToGroup, m_calculators);

                var calculations = new List<fsMeasuredParameter>();
                foreach (var pair in currentValues)
                {
                    if (pair.Key == xParameter)
                    {
                        calculations.Insert(0, pair.Value);
                    }
                    else
                    {
                        calculations.Add(pair.Value);
                    }
                }
                m_data.Add(calculations);
            }
        }

        private void RefreshYAxisList()
        {
            var newList = new List<KeyValuePair<string, bool>>();
            foreach (var group in m_groups)
            {
                foreach (var parameter in group.Parameters)
                {
                    newList.Add(new KeyValuePair<string, bool>(parameter.Name,
                                                               yAxisList.CheckedItems.Contains(parameter.Name)));
                }
            }
            yAxisList.Items.Clear();
            foreach (var keyValuePair in newList)
            {
                yAxisList.Items.Add(keyValuePair.Key, keyValuePair.Value);
            }
        }

        private void RefreshXAxisList()
        {
            string currentText = xAxisList.Text;
            xAxisList.Items.Clear();
            foreach (var group in m_groups)
            {
                if (group.IsInput)
                {
                    xAxisList.Items.Add(group.Representator.Name);
                }
            }
            if (xAxisList.Items.Contains(currentText))
            {
                xAxisList.SelectedIndex = xAxisList.Items.IndexOf(currentText);
            }
            else
            {
                xAxisList.SelectedItem = xAxisList.Items[0];
            }
        }

        public void AssignCalculatorData(
            Dictionary<fsParameterIdentifier, fsMeasuredParameter> values,
            List<fsParametersGroup> groups,
            Dictionary<fsParameterIdentifier, fsParametersGroup> parameterToGroup,
            List<fsCalculator> calculators)
        {
            m_values = values;
            m_groups = groups;
            m_parameterToGroup = parameterToGroup;
            m_calculators = calculators;
        }

        private void xAxisList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDiagram();
        }

        private void yAxisList_MouseUp(object sender, MouseEventArgs e)
        {
            UpdateDiagram();
        }

        private void rangeFrom_TextChanged(object sender, EventArgs e)
        {
            UpdateDiagram();
        }

        private void rangeTo_TextChanged(object sender, EventArgs e)
        {
            UpdateDiagram();
        }

        private void detalizationBox_TextChanged(object sender, EventArgs e)
        {
            UpdateDiagram();
        }
    }
}
