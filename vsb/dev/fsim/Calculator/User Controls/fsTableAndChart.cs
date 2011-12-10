using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Calculator.Calculation_Controls;
using Parameters;
using ParametersIdentifiers.Interfaces;
using StepCalculators;
using Units;
using Value;
using ZedGraph;
using System.Threading;

namespace Calculator.User_Controls
{
    public partial class fsTableAndChart : UserControl
    {
        private readonly List<fsFunction> m_functions = new List<fsFunction>();
        private List<fsCalculator> m_calculators;
        private List<List<fsMeasuredParameter>> m_data;
        private List<fsParametersGroup> m_groups;
        private Dictionary<fsParameterIdentifier, fsParametersGroup> m_parameterToGroup;
        private Dictionary<fsParameterIdentifier, fsMeasuredParameter> m_values;

        public fsTableAndChart()
        {
            InitializeComponent();

            m_values = new Dictionary<fsParameterIdentifier, fsMeasuredParameter>();
        }

        private bool m_reprocessWorks;

        public void Reprocess()
        {
            if (!m_reprocessWorks)
            {
                m_reprocessWorks = true;

                RefreshXAxisList();
                RefreshYAxisList();
                rangeFrom.Text = @"0";
                rangeTo.Text = @"100";
                if (detalizationBox.Text == "")
                {
                    detalizationBox.Text = @"50";
                }

                m_reprocessWorks = false;

                RecalculateAndUpdateDiagram();
            }
        }

        private delegate void VoidMethod();

        private Thread m_recalculateAndUpdateDiagramThread;

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
            BuildFunctions();

            if (Visible)
            {
                Invoke(new VoidMethod(RefreshDiagramAndTable));
            }
        }

        private void BuildFunctions()
        {
            m_functions.Clear();
            var fx = new fsFunction(m_data[0][0].Identifier, m_data[0][0].Unit);
            foreach (var t in m_data)
            {
                fx.Values.Add(t[0].GetValueInUnits());
            }
            m_functions.Add(fx);
            for (int col = 1; col < m_data[0].Count; ++col)
            {
                fsParameterIdentifier parameter = m_data[0][col].Identifier;
                if (yAxisList.CheckedItems.Contains(parameter.Name))
                {
                    var fy = new fsFunction(parameter, m_data[0][col].Unit);
                    foreach (var t in m_data)
                    {
                        fy.Values.Add(t[col].GetValueInUnits());
                    }
                    m_functions.Add(fy);
                }
            }
        }

        private void RefreshDiagramAndTable()
        {
            var xAxis = new fsDiagramWithTable.fsNamedArray();
            xAxis.Name = m_functions[0].ParameterIdentifier.Name + "(" + m_functions[0].Unit.Name + ")";
            xAxis.Array = m_functions[0].Values.ToArray();
            fsDiagramWithTable1.SetXAxis(xAxis);

            fsDiagramWithTable1.ClearYAxis();
            for (int i = 1; i < m_functions.Count; ++i)
            {
                var yAxis = new fsDiagramWithTable.fsNamedArray();
                yAxis.Name = m_functions[i].ParameterIdentifier.Name + "(" + m_functions[i].Unit.Name + ")";
                yAxis.Array = m_functions[i].Values.ToArray();
                fsDiagramWithTable1.AddYAxis(yAxis);
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
            foreach (fsParametersGroup group in m_groups)
            {
                newList.AddRange(
                    group.Parameters.Select(
                        parameter =>
                        new KeyValuePair<string, bool>(parameter.Name, yAxisList.CheckedItems.Contains(parameter.Name))));
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
            foreach (fsParametersGroup group in m_groups)
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

        private void XAxisListSelectedIndexChanged(object sender, EventArgs e)
        {
            RecalculateAndUpdateDiagram();
        }

        private void YAxisListMouseUp(object sender, MouseEventArgs e)
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