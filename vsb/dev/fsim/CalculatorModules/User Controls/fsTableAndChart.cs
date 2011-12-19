using System;
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

        private readonly List<fsDiagramWithTable.fsNamedArray> m_yCurves = new List<fsDiagramWithTable.fsNamedArray>();
        private readonly List<fsDiagramWithTable.fsNamedArray> m_y2Curves = new List<fsDiagramWithTable.fsNamedArray>();
        private List<fsCalculator> m_calculators;
        private Dictionary<fsParameterIdentifier, List<fsMeasuredParameter>> m_data = new Dictionary<fsParameterIdentifier, List<fsMeasuredParameter>>();
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

        public void AssignCalculatorData(
            Dictionary<fsParameterIdentifier, fsMeasuredParameter> values,
            List<fsParametersGroup> groups,
            Dictionary<fsParameterIdentifier, fsParametersGroup> parameterToGroup,
            List<fsCalculator> calculators)
        {
            m_values = new Dictionary<fsParameterIdentifier, fsMeasuredParameter>(values);
            m_groups = new List<fsParametersGroup>(groups);
            m_parameterToGroup = new Dictionary<fsParameterIdentifier, fsParametersGroup>(parameterToGroup);
            m_calculators = new List<fsCalculator>(calculators);
        }

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

                RecalculateAndUpdateYAxisAndDiagram();
            }
        }

        #region RefreshInputs

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

        #region Calculations

        private void CalculateData(fsParameterIdentifier xParameter)
        {
            int detalization = Convert.ToInt32(detalizationBox.Text);
            fsValue from = fsValue.StringToValue(rangeFrom.Text);
            fsValue to = fsValue.StringToValue(rangeTo.Text);

            m_data = new Dictionary<fsParameterIdentifier, List<fsMeasuredParameter>>();
            for (int i = 0; i < detalization; ++i)
            {
                Dictionary<fsParameterIdentifier, fsMeasuredParameter> currentValues =
                    m_values.ToDictionary(pair => pair.Key, pair => new fsMeasuredParameter(pair.Value));

                fsParametersGroup xInitialgroup = m_parameterToGroup[xParameter];
                var xNewGroup = new fsParametersGroup(xInitialgroup) { Representator = xParameter };
                SubstituteGroup(m_parameterToGroup, xInitialgroup, xNewGroup);

                currentValues[xParameter].SetValueInUnits(from + (to - from) * i / detalization);
                fsCalculationProcessor.ProcessCalculatorParameters(currentValues, m_parameterToGroup, m_calculators);

                SubstituteGroup(m_parameterToGroup, xNewGroup, xInitialgroup);

                var calculations = new List<fsMeasuredParameter>();
                foreach (var pair in currentValues)
                {
                    if (m_data.ContainsKey(pair.Key) == false)
                    {
                        m_data.Add(pair.Key, new List<fsMeasuredParameter>());
                    }
                    m_data[pair.Key].Add(pair.Value);
                }
            }
        }

        private void RecalculateAndUpdateYAxisAndDiagram()
        {
            RecalculateAndUpdateYaxis();
            UpdateDiagram();
        }

        private void UpdateDiagram()
        {
            BuildCurves();
            BuildTable();
            RefreshDiagramAndTable();
        }

        private void RecalculateAndUpdateYaxis()
        {
            if (!m_reprocessWorks)
            {
                if (m_recalculateAndUpdateDiagramThread != null)
                {
                    m_recalculateAndUpdateDiagramThread.Abort();
                    m_recalculateAndUpdateDiagramThread = null;
                }
                fsParameterIdentifier xAxisParameter = m_values.Keys.FirstOrDefault(parameter => parameter.Name == xAxisList.Text);
                CalculateData((fsParameterIdentifier)xAxisParameter);

                RefreshYAxisList(yAxisList);
                RefreshYAxisList(y2AxisList);
            }
        }
        private void BuildTable()
        {
        }

        private void BuildCurves()
        {
            BuildCurves(m_yCurves, yAxisList);
            BuildCurves(m_y2Curves, y2AxisList);
        }

        private void BuildCurves(List<fsDiagramWithTable.fsNamedArray> curves, ListView yAxisList)
        {
            if (m_data == null)
                return;
            
            curves.Clear();
            foreach (var pair in m_data)
            {
                fsParameterIdentifier parameter = pair.Key;
                if (IsContains(yAxisList.CheckedItems, parameter.Name))
                {
                    curves.Add(GetArray(parameter));
                }
            }
        }

        private fsDiagramWithTable.fsNamedArray GetArray(fsParameterIdentifier parameter)
        {
            var values = m_data[parameter];
            var array = new fsDiagramWithTable.fsNamedArray
                            {Name = parameter.Name, Array = new fsValue[values.Count]};
            for (int i = 0; i < values.Count; ++i)
            {
                array.Array[i] = values[i].GetValueInUnits();
            }
            return array;
        }

        #endregion

        #region Refresh Output

        private void RefreshYAxisList(ListView yAxisListView)
        {
            var inputList = new List<KeyValuePair<string, bool>>();
            var constResultsList = new List<KeyValuePair<string, bool>>();
            var variableResultsList = new List<KeyValuePair<string, bool>>();
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
                        if (IsConstantList(m_data[parameter]))
                        {
                            constResultsList.Add(element);
                        }
                        else
                        {
                            variableResultsList.Add(element);
                        }
                    }
                }
            }
            List<ListViewItem> newList = new List<ListViewItem>();
            foreach (var keyValuePair in variableResultsList)
            {
                var item = new ListViewItem(keyValuePair.Key) { Checked = keyValuePair.Value, ForeColor = Color.Black };
                newList.Add(item);
            }
            foreach (var keyValuePair in constResultsList)
            {
                var item = new ListViewItem(keyValuePair.Key) { Checked = keyValuePair.Value, ForeColor = Color.LightGray };
                newList.Add(item);
            }
            foreach (var keyValuePair in inputList)
            {
                var item = new ListViewItem(keyValuePair.Key) { Checked = keyValuePair.Value, ForeColor = Color.Blue };
                newList.Add(item);
            }
            bool different = false;
            if (yAxisListView.Items.Count != newList.Count)
            {
                different = true;
            }
            else
            {
                for (int i = 0; i < newList.Count; ++i)
                {
                    if (newList[i].Text != yAxisListView.Items[i].Text
                        || newList[i].Checked != yAxisListView.Items[i].Checked
                        || newList[i].ForeColor != yAxisListView.Items[i].ForeColor)
                    {
                        different = true;
                        break;
                    }
                }
            }
            if (different)
            {
                var array = newList.ToArray();
                yAxisListView.Items.Clear();
                yAxisListView.Items.AddRange(array);
            }
        }

        private bool IsConstantList(List<fsMeasuredParameter> list)
        {
            if (list.Count <= 1)
            {
                return true;
            }
            fsValue minValue = list[0].GetValueInUnits();
            fsValue maxValue = list[0].GetValueInUnits();
            for (int i = 1; i < list.Count; ++i)
            {
                fsValue currentValue = list[i].GetValueInUnits();
                if (!minValue.Defined
                    || currentValue.Defined && minValue.Value > currentValue.Value)
                {
                    minValue = currentValue;
                }
                if (!maxValue.Defined
                    || currentValue.Defined && maxValue.Value < currentValue.Value)
                {
                    maxValue = currentValue;
                }
            }
            fsValue delta = maxValue - minValue;
            fsValue deviation = delta / fsValue.Max(fsValue.Abs(minValue), fsValue.Abs(maxValue));
            return deviation <= new fsValue(1e-9);
        }

        private void RefreshDiagramAndTable()
        {
            if (m_data.Count == 0)
                return;

            fsParameterIdentifier xAxisParameter = m_values.Keys.FirstOrDefault(parameter => parameter.Name == xAxisList.Text);
            fsDiagramWithTable1.SetXAxis(GetArray(xAxisParameter));

            fsDiagramWithTable1.ClearYAxis();
            foreach (fsDiagramWithTable.fsNamedArray curve in m_yCurves)
            {
                fsDiagramWithTable1.AddYAxis(curve);
            }

            fsDiagramWithTable1.ClearY2Axis();
            foreach (fsDiagramWithTable.fsNamedArray curve in m_y2Curves)
            {
                fsDiagramWithTable1.AddY2Axis(curve);
            }

            fsDiagramWithTable1.Redraw();
        }

        #endregion

        #endregion

        #region Misc

        private static bool IsContains(ListView.CheckedListViewItemCollection checkedListViewItemCollection, string name)
        {
            return checkedListViewItemCollection.Cast<ListViewItem>().Any(item => item.Text == name);
        }

        private static void SubstituteGroup(Dictionary<fsParameterIdentifier, fsParametersGroup> parameterToGroup, fsParametersGroup initialGroup, fsParametersGroup newGroup)
        {
            foreach (fsParameterIdentifier parameter in initialGroup.Parameters)
            {
                parameterToGroup[parameter] = newGroup;
            }
        }

        #endregion

        #region UI Event

        private void XAxisListSelectedIndexChanged(object sender, EventArgs e)
        {
            RecalculateAndUpdateYAxisAndDiagram();
        }

        private void RangeFromTextChanged(object sender, EventArgs e)
        {
            RecalculateAndUpdateYAxisAndDiagram();
        }

        private void RangeToTextChanged(object sender, EventArgs e)
        {
            RecalculateAndUpdateYAxisAndDiagram();
        }

        private void DetalizationBoxTextChanged(object sender, EventArgs e)
        {
            RecalculateAndUpdateYAxisAndDiagram();
        }

        private void YAxisListItemChecked(object sender, ItemCheckedEventArgs e)
        {
            UpdateDiagram();
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