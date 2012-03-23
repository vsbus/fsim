using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Parameters;
using ParametersIdentifiers;
using ParametersIdentifiers.Ranges;
using StepCalculators;
using Value;

namespace CalculatorModules.User_Controls
{
    public partial class fsTableAndChart : UserControl
    {
        #region Private Data

        private readonly List<fsDiagramWithTable.fsNamedArray> m_y2Curves = new List<fsDiagramWithTable.fsNamedArray>();
        private readonly List<fsDiagramWithTable.fsNamedArray> m_yCurves = new List<fsDiagramWithTable.fsNamedArray>();
        private List<fsCalculator> m_calculators;

        private Dictionary<fsParameterIdentifier, List<fsSimulationModuleParameter>> m_data =
            new Dictionary<fsParameterIdentifier, List<fsSimulationModuleParameter>>();

        private List<fsParametersGroup> m_groups;
        private Dictionary<fsParameterIdentifier, fsParametersGroup> m_parameterToGroup;
        private Dictionary<fsParameterIdentifier, fsSimulationModuleParameter> m_values;
        private fsParameterIdentifier m_xAxisParameter;

        #endregion

        


        #region Constructor

        public fsTableAndChart()
        {
            InitializeComponent();

            m_values = new Dictionary<fsParameterIdentifier, fsSimulationModuleParameter>();
        }

        #endregion

        public void AssignCalculatorData(
            Dictionary<fsParameterIdentifier, fsSimulationModuleParameter> values,
            List<fsParametersGroup> groups,
            Dictionary<fsParameterIdentifier, fsParametersGroup> parameterToGroup,
            List<fsCalculator> calculators)
        {
            m_values = new Dictionary<fsParameterIdentifier, fsSimulationModuleParameter>(values);
            m_groups = new List<fsParametersGroup>(groups);
            m_parameterToGroup = new Dictionary<fsParameterIdentifier, fsParametersGroup>(parameterToGroup);
            m_calculators = new List<fsCalculator>(calculators);
        }

        #region Reprocessing

        private bool m_inputRefreshing;

        public void Reprocess()
        {
            RefreshInput();
            CalculateData();
            RefreshOutput();
        }

        private void RefreshOutput()
        {
            RefreshYAxisList(yAxisList);
            RefreshYAxisList(y2AxisList);

            UpdateDiagram();
        }

        private void RefreshInput()
        {
            if (!m_inputRefreshing)
            {
                m_inputRefreshing = true;

                RefreshXAxisList();

                m_xAxisParameter = m_values.Keys.FirstOrDefault(parameter => parameter.Name == xAxisList.Text);

                RefreshRangesBoxes();

                if (detalizationBox.Text == "")
                {
                    detalizationBox.Text = @"50";
                }

                RefreshInputsBox();

                m_inputRefreshing = false;
            }
        }

        private void RefreshRangesBoxes()
        {
            fsRange range = m_values[m_xAxisParameter].Range;
            double factor = m_values[m_xAxisParameter].Unit.Coefficient;
            rangeFrom.Text = (range.From / factor).ToString();
            rangeTo.Text = (range.To / factor).ToString();
        }

        #region RefreshInputs

        private void RefreshInputsBox()
        {
            var materialInputData = new List<string>();
            var machiningSettingsInputData = new List<string>();
            foreach (fsParametersGroup group in m_groups)
            {
                if (group.Parameters.Contains(m_xAxisParameter))
                    continue;

                if (group.IsInput)
                {
                    fsParameterIdentifier parameter = group.Representator;
                    string line = parameter.Name
                        + "\t" + m_values[parameter].Unit.Name
                        + "\t" + m_values[parameter].GetValueInUnits().ToString();
                    if (group.Kind == fsParametersGroup.ParametersGroupKind.MaterialParameters)
                    {
                        materialInputData.Add(line);
                    }
                    else
                    {
                        machiningSettingsInputData.Add(line);
                    }
                }
            }

            var lines = new List<string>();
            lines.AddRange(materialInputData);
            lines.Add("------------------------------------");
            lines.AddRange(machiningSettingsInputData);
            
            inputsTextBox.ForeColor = Color.Blue;
            inputsTextBox.Lines = lines.ToArray();
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

        private void CalculateData()
        {
            if (m_inputRefreshing)
                return;

            int detalization = (int)fsValue.StringToValue(detalizationBox.Text).Value;
            if (detalization < 2)
            {
                detalization = 2;
            }
            double factor = m_values[m_xAxisParameter].Unit.Coefficient;
            fsValue from = fsValue.StringToValue(rangeFrom.Text) * factor;
            fsValue to = fsValue.StringToValue(rangeTo.Text) * factor;

            m_data = new Dictionary<fsParameterIdentifier, List<fsSimulationModuleParameter>>();
            for (int i = 0; i < detalization; ++i)
            {
                Dictionary<fsParameterIdentifier, fsSimulationModuleParameter> currentValues =
                    m_values.ToDictionary(pair => pair.Key, pair => new fsSimulationModuleParameter(pair.Value));

                fsParametersGroup xInitialgroup = m_parameterToGroup[m_xAxisParameter];
                var xNewGroup = new fsParametersGroup(xInitialgroup) {Representator = m_xAxisParameter};
                SubstituteGroup(m_parameterToGroup, xInitialgroup, xNewGroup);

                currentValues[m_xAxisParameter].Value = from + (to - from) * i / detalization;
                fsCalculationProcessor.ProcessCalculatorParameters(currentValues, m_parameterToGroup, m_calculators);

                SubstituteGroup(m_parameterToGroup, xNewGroup, xInitialgroup);

                foreach (var pair in currentValues)
                {
                    if (m_data.ContainsKey(pair.Key) == false)
                    {
                        m_data.Add(pair.Key, new List<fsSimulationModuleParameter>());
                    }
                    m_data[pair.Key].Add(pair.Value);
                }
            }
        }

        private void UpdateDiagram()
        {
            if (m_inputRefreshing)
                return;

            BuildCurves();
            RefreshDiagramAndTable();
        }

        private void BuildCurves()
        {
            BuildCurves(m_yCurves, yAxisList);
            BuildCurves(m_y2Curves, y2AxisList);
        }

        private void BuildCurves(List<fsDiagramWithTable.fsNamedArray> curves, ListView yAxisListView)
        {
            if (m_data == null)
                return;

            curves.Clear();
            curves.AddRange(from pair in m_data
                            select pair.Key
                            into parameter where IsContains(yAxisListView.CheckedItems, parameter.Name)
                            select GetArray(parameter));
        }

        private fsDiagramWithTable.fsNamedArray GetArray(fsParameterIdentifier parameter)
        {
            List<fsSimulationModuleParameter> values = m_data[parameter];
            var array = new fsDiagramWithTable.fsNamedArray
                            {Name = parameter.Name + " [" + m_data[parameter][0].Unit.Name + "]", Array = new fsValue[values.Count]};
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
            if (m_inputRefreshing)
                return;

            var inputList = new List<KeyValuePair<string, bool>>();
            var constResultsList = new List<KeyValuePair<string, bool>>();
            var variableResultsList = new List<KeyValuePair<string, bool>>();
            foreach (fsParametersGroup group in m_groups)
            {
                foreach (fsParameterIdentifier parameter in group.Parameters)
                {
                    var element = new KeyValuePair<string, bool>(parameter.Name,
                                                                 IsContains(yAxisListView.CheckedItems, parameter.Name));
                    if (parameter == m_xAxisParameter)
                    {
                        variableResultsList.Add(element);
                    }
                    else if (group.IsInput && parameter == group.Representator)
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
            var newList = new List<ListViewItem>();
            newList.AddRange(
                variableResultsList.Select(
                    keyValuePair =>
                    new ListViewItem(keyValuePair.Key) {Checked = keyValuePair.Value, ForeColor = Color.Black}));
            newList.AddRange(
                constResultsList.Select(
                    keyValuePair =>
                    new ListViewItem(keyValuePair.Key) {Checked = keyValuePair.Value, ForeColor = Color.LightGray}));
            newList.AddRange(
                inputList.Select(
                    keyValuePair =>
                    new ListViewItem(keyValuePair.Key) {Checked = keyValuePair.Value, ForeColor = Color.Blue}));
            if (yAxisListView.Items.Count != newList.Count)
            {
                ListViewItem[] array = newList.ToArray();
                yAxisListView.Items.Clear();
                yAxisListView.Items.AddRange(array);
            }
            else
            {
                bool different = false;
                if (
                    newList.Where(
                        (t, i) =>
                        t.Text != yAxisListView.Items[i].Text || t.Checked != yAxisListView.Items[i].Checked ||
                        t.ForeColor != yAxisListView.Items[i].ForeColor).Any())
                {
                    different = true;
                }
                if (different)
                {
                    for (int i = 0; i < newList.Count; ++i)
                    {
                        yAxisListView.Items[i].Text = newList[i].Text;
                        yAxisListView.Items[i].Checked = newList[i].Checked;
                        yAxisListView.Items[i].ForeColor = newList[i].ForeColor;
                    }
                }
            }
        }

        private static bool IsConstantList(List<fsSimulationModuleParameter> list)
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

            fsDiagramWithTable1.SetXAxis(GetArray(m_xAxisParameter));

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

        private static void SubstituteGroup(Dictionary<fsParameterIdentifier, fsParametersGroup> parameterToGroup,
                                            fsParametersGroup initialGroup, fsParametersGroup newGroup)
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
            m_xAxisParameter = m_values.Keys.FirstOrDefault(parameter => parameter.Name == xAxisList.Text);
            RefreshRangesBoxes();
            RefreshInputsBox();
            CalculateData();
            RefreshOutput();
        }

        private void YAxisListItemChecked(object sender, ItemCheckedEventArgs e)
        {
            UpdateDiagram();
        }

        private void RangeFromTextChanged(object sender, EventArgs e)
        {
            m_values[m_xAxisParameter].Range.From = fsValue.StringToValue(rangeFrom.Text) *
                                                    m_values[m_xAxisParameter].Unit.Coefficient;
            CalculateData();
            RefreshOutput();
        }

        private void RangeToTextChanged(object sender, EventArgs e)
        {
            m_values[m_xAxisParameter].Range.To = fsValue.StringToValue(rangeTo.Text) *
                                                  m_values[m_xAxisParameter].Unit.Coefficient;
            CalculateData();
            RefreshOutput();
        }

        private void detalizationBox_TextChanged(object sender, EventArgs e)
        {
            CalculateData();
            RefreshOutput();
        }

        #endregion

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
