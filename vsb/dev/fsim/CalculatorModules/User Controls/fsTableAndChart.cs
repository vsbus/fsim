﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Parameters;
using ParametersIdentifiers.Interfaces;
using StepCalculators;
using System.Threading;
using Units;
using Value;

namespace CalculatorModules.User_Controls
{
    public partial class fsTableAndChart : UserControl
    {
        #region Private Data

        private readonly List<fsFunction> m_functions = new List<fsFunction>();
        private readonly List<fsFunction> m_functions2 = new List<fsFunction>();
        private List<fsCalculator> m_calculators;
        private List<List<fsMeasuredParameter>> m_data;
        private List<fsParametersGroup> m_groups;
        private Dictionary<fsParameterIdentifier, fsParametersGroup> m_parameterToGroup;
        private Dictionary<fsParameterIdentifier, fsMeasuredParameter> m_values;
        private bool m_reprocessWorks;
        private delegate void fsVoidMethod();
        private Thread m_recalculateAndUpdateDiagramThread;

        #endregion

        #region Constructor

        public fsTableAndChart()
        {
            InitializeComponent();

            m_values = new Dictionary<fsParameterIdentifier, fsMeasuredParameter>();
        }

        #endregion

        #region Reprocessing

        public void Reprocess()
        {
            if (!m_reprocessWorks)
            {
                m_reprocessWorks = true;

                RefreshXAxisList();
                RefreshInputsBox();
                rangeFrom.Text = @"0";
                rangeTo.Text = @"100";
                if (detalizationBox.Text == "")
                {
                    detalizationBox.Text = @"50";
                }

                m_reprocessWorks = false;

                RecalculateAndUpdateDiagram();
                RefreshYAxisList(yAxisList);
                RefreshYAxisList(y2AxisList);
            }
        }

        private void RefreshInputsBox()
        {
            var inputData = new List<string>();
            foreach (fsParametersGroup group in m_groups)
            {
                if (group.IsInput)
                {
                    fsParameterIdentifier parameter = group.Representator;
                    inputData.Add(parameter.Name + ":\t" + m_values[parameter].GetValueInUnits() + " " + m_values[parameter].Unit.Name);
                }
            }

            textBox1.Lines = inputData.ToArray();
        }

        private void RecalculateAndUpdateDiagram()
        {
            if (!m_reprocessWorks)
            {
                if (m_recalculateAndUpdateDiagramThread != null)
                {
                    m_recalculateAndUpdateDiagramThread.Abort();
                    m_recalculateAndUpdateDiagramThread = null;
                }
                fsParameterIdentifier xAxisParameter = m_values.Keys.FirstOrDefault(parameter => parameter.Name == xAxisList.Text);
                m_recalculateAndUpdateDiagramThread = new Thread(BuildDataAndRefreshPlot);
                m_recalculateAndUpdateDiagramThread.Start(xAxisParameter);
            }
        }

        private void BuildDataAndRefreshPlot(object xAxisParameter)
        {
            BuildData((fsParameterIdentifier) xAxisParameter);
            BuildFunctions(m_functions, yAxisList);
            BuildFunctions(m_functions2, y2AxisList);

            if (Visible)
            {
                Invoke(new fsVoidMethod(RefreshDiagramAndTable));
            }
        }

        private void BuildFunctions(List<fsFunction> functions, ListView yAxisListView)
        {
            functions.Clear();
            var fx = new fsFunction(m_data[0][0].Identifier, m_data[0][0].Unit);
            foreach (var t in m_data)
            {
                fx.Values.Add(t[0].GetValueInUnits());
            }
            functions.Add(fx);
            for (int col = 1; col < m_data[0].Count; ++col)
            {
                fsParameterIdentifier parameter = m_data[0][col].Identifier;
                if (IsContains(yAxisListView.CheckedItems, parameter.Name))
                {
                    var fy = new fsFunction(parameter, m_data[0][col].Unit);
                    foreach (var t in m_data)
                    {
                        fy.Values.Add(t[col].GetValueInUnits());
                    }
                    functions.Add(fy);
                }
            }
        }

        private static bool IsContains(ListView.CheckedListViewItemCollection checkedListViewItemCollection, string name)
        {
            return checkedListViewItemCollection.Cast<ListViewItem>().Any(item => item.Text == name);
        }

        private void RefreshDiagramAndTable()
        {
            var xAxis = new fsDiagramWithTable.fsNamedArray
                            {
                                Name = m_functions[0].ParameterIdentifier.Name + "(" + m_functions[0].Unit.Name + ")",
                                Array = m_functions[0].Values.ToArray()
                            };
            fsDiagramWithTable1.SetXAxis(xAxis);

            fsDiagramWithTable1.ClearYAxis();
            for (int i = 1; i < m_functions.Count; ++i)
            {
                var yAxis = new fsDiagramWithTable.fsNamedArray
                                {
                                    Name =
                                        m_functions[i].ParameterIdentifier.Name + "(" + m_functions[i].Unit.Name + ")",
                                    Array = m_functions[i].Values.ToArray()
                                };
                fsDiagramWithTable1.AddYAxis(yAxis);
            }

            fsDiagramWithTable1.ClearY2Axis();
            for (int i = 1; i < m_functions2.Count; ++i)
            {
                var yAxis = new fsDiagramWithTable.fsNamedArray
                                {
                                    Name =
                                        m_functions2[i].ParameterIdentifier.Name + "(" + m_functions2[i].Unit.Name + ")",
                                    Array = m_functions2[i].Values.ToArray()
                                };
                fsDiagramWithTable1.AddY2Axis(yAxis);
            }

            fsDiagramWithTable1.Redraw();
        }

        private void BuildData(fsParameterIdentifier xParameter)
        {
            int detalization = Convert.ToInt32(detalizationBox.Text);
            m_data = new List<List<fsMeasuredParameter>>();
            for (int i = 0; i < detalization; ++i)
            {
                Dictionary<fsParameterIdentifier, fsMeasuredParameter> currentValues =
                    m_values.ToDictionary(pair => pair.Key, pair => new fsMeasuredParameter(pair.Value));

                fsValue from = fsValue.StringToValue(rangeFrom.Text);
                fsValue to = fsValue.StringToValue(rangeTo.Text);

                fsParametersGroup xInitialgroup = m_parameterToGroup[xParameter];
                var xNewGroup = new fsParametersGroup(xInitialgroup) {Representator = xParameter};
                SubstituteGroup(m_parameterToGroup, xInitialgroup, xNewGroup);

                currentValues[xParameter].SetValueInUnits(from + (to - from) * i / detalization);
                fsCalculationProcessor.ProcessCalculatorParameters(currentValues, m_parameterToGroup, m_calculators);

                SubstituteGroup(m_parameterToGroup, xNewGroup, xInitialgroup); 
                
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

        private static void SubstituteGroup(Dictionary<fsParameterIdentifier, fsParametersGroup> parameterToGroup, fsParametersGroup initialGroup, fsParametersGroup newGroup)
        {
            foreach (fsParameterIdentifier parameter in initialGroup.Parameters)
            {
                parameterToGroup[parameter] = newGroup;
            }
        }

        private void RefreshYAxisList(ListView yAxisListView)
        {
            var calculatedList = new List<KeyValuePair<string, bool>>();
            var inputList = new List<KeyValuePair<string, bool>>();
            foreach (fsParametersGroup group in m_groups)
            {
                foreach (fsParameterIdentifier parameter in group.Parameters)
                {
                    var element = new KeyValuePair<string, bool>(parameter.Name,
                                                                 IsContains(yAxisListView.CheckedItems, parameter.Name));
                    if (group.IsInput && parameter == group.Representator)
                    {
                        inputList.Add(element);
                    }
                    else
                    {
                        calculatedList.Add(element);
                    }
                }
            }
            yAxisListView.Items.Clear();
            foreach (var keyValuePair in calculatedList)
            {
                var item = new ListViewItem(keyValuePair.Key) {Checked = keyValuePair.Value, ForeColor = Color.Black};
                yAxisListView.Items.Add(item);
            }
            foreach (var keyValuePair in inputList)
            {
                var item = new ListViewItem(keyValuePair.Key) {Checked = keyValuePair.Value, ForeColor = Color.Blue};
                yAxisListView.Items.Add(item);
            }
        }

        private void RefreshXAxisList()
        {
            string currentText = xAxisList.Text;
            xAxisList.Items.Clear();
            foreach (fsParametersGroup group in m_groups)
            {
                if (group.IsInput)
                {
                    foreach (fsParameterIdentifier parameter in group.Parameters)
                    {
                        xAxisList.Items.Add(parameter.Name);
                    }
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

        #endregion

        public void AssignCalculatorData(
            Dictionary<fsParameterIdentifier, fsMeasuredParameter> values,
            List<fsParametersGroup> groups,
            Dictionary<fsParameterIdentifier, fsParametersGroup> parameterToGroup,
            List<fsCalculator> calculators)
        {
            m_values = new Dictionary<fsParameterIdentifier,fsMeasuredParameter>(values);
            m_groups = new List<fsParametersGroup> (groups);
            m_parameterToGroup = new Dictionary<fsParameterIdentifier,fsParametersGroup>(parameterToGroup);
            m_calculators = new List<fsCalculator>(calculators);
        }

        #region UI Event

        private void XAxisListSelectedIndexChanged(object sender, EventArgs e)
        {
            RecalculateAndUpdateDiagram();
        }

        private void RangeFromTextChanged(object sender, EventArgs e)
        {
            RecalculateAndUpdateDiagram();
        }

        private void RangeToTextChanged(object sender, EventArgs e)
        {
            RecalculateAndUpdateDiagram();
        }

        private void DetalizationBoxTextChanged(object sender, EventArgs e)
        {
            RecalculateAndUpdateDiagram();
        }

        private void YAxisListItemChecked(object sender, ItemCheckedEventArgs e)
        {
            RecalculateAndUpdateDiagram();
        }

        #endregion

        #region Nested type: fsFunction

        private class fsFunction
        {
            public readonly fsParameterIdentifier ParameterIdentifier;
            public readonly List<fsValue> Values;
            public fsUnit Unit;

            public fsFunction(fsParameterIdentifier parameterIdentifier, fsUnit unit)
            {
                ParameterIdentifier = parameterIdentifier;
                Unit = unit;
                Values = new List<fsValue>();
            }
        }

        #endregion

    }
}