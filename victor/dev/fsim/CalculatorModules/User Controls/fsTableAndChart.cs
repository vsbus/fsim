using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CalculatorModules.User_Controls.Help_Dialogs;
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

        private List<fsParameterIdentifier> m_yAxisParameters = new List<fsParameterIdentifier>();
        private List<fsParameterIdentifier> m_y2AxisParameters = new List<fsParameterIdentifier>();

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

        public void SetDefaultDiagram(
            fsParameterIdentifier xAxisParameter,
            fsParameterIdentifier yAxisParameter,
            fsParameterIdentifier y2AxisParameter)
        {
            m_xAxisParameter = xAxisParameter;
            m_yAxisParameters.Clear();
            m_yAxisParameters.Add(yAxisParameter);
            m_y2AxisParameters.Clear();
            m_y2AxisParameters.Add(y2AxisParameter);
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
            RefreshYAxisList(m_yAxisParameters, m_yAxisList);
            RefreshYAxisList(m_y2AxisParameters, m_y2AxisList);

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
                        + "\t" + m_values[parameter].GetValueInUnits();
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
            if (m_xAxisParameter != null && xAxisList.Items.Contains(m_xAxisParameter.Name))
            {
                xAxisList.SelectedIndex = xAxisList.Items.IndexOf(m_xAxisParameter.Name);
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

            var detalization = (int)fsValue.StringToValue(detalizationBox.Text).Value;
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
            BuildCurves(m_yCurves, m_yAxisList);
            BuildCurves(m_y2Curves, m_y2AxisList);
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

        private void RefreshYAxisList(IEnumerable<fsParameterIdentifier> parameters, ListView yAxisListView)
        {
            if (m_inputRefreshing)
                return;

            var inputList = new List<KeyValuePair<string, bool>>();
            var constResultsList = new List<KeyValuePair<string, bool>>();
            var variableResultsList = new List<KeyValuePair<string, bool>>();

            foreach (fsTablesAndChartsParametersSelectionDialog.fsYAxisParameter selectionParameter in GetSelectionParameters(parameters))
            {
                string parameterName = selectionParameter.Identifier.Name;
                bool isChecked = IsContains(yAxisListView.CheckedItems, parameterName)
                                 || !IsContains(yAxisListView.Items, parameterName);
                var pair = new KeyValuePair<string, bool>(parameterName, isChecked);
                if (selectionParameter.Kind == fsTablesAndChartsParametersSelectionDialog.fsYAxisParameter.fsYParameterKind.InputParameter)
                {
                    inputList.Add(pair);
                }
                if (selectionParameter.Kind == fsTablesAndChartsParametersSelectionDialog.fsYAxisParameter.fsYParameterKind.CalculatedConstantParameter)
                {
                    constResultsList.Add(pair);
                }
                if (selectionParameter.Kind == fsTablesAndChartsParametersSelectionDialog.fsYAxisParameter.fsYParameterKind.CalculatedVariableParameter)
                {
                    variableResultsList.Add(pair);
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

        private static bool IsContains(ListView.ListViewItemCollection checkedListViewItemCollection, string name)
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

        private void DetalizationBoxTextChanged(object sender, EventArgs e)
        {
            CalculateData();
            RefreshOutput();
        }

        private void YAxisConfigureClick(object sender, EventArgs e)
        {
            var selectionForm = new fsTablesAndChartsParametersSelectionDialog();
            selectionForm.AssignParameters(GetSelectionParametersWithCheking(m_yAxisList));
            selectionForm.ShowDialog();
            if (selectionForm.DialogResult == DialogResult.OK)
            {
                m_yAxisParameters.Clear();
                m_yAxisParameters.AddRange(selectionForm.GetCheckedParameters());
                Reprocess();
            }
        }

        private void Y2AxisConfigureClick(object sender, EventArgs e)
        {
            var selectionForm = new fsTablesAndChartsParametersSelectionDialog();
            selectionForm.AssignParameters(GetSelectionParametersWithCheking(m_y2AxisList));
            selectionForm.ShowDialog();
            if (selectionForm.DialogResult == DialogResult.OK)
            {
                m_y2AxisParameters.Clear();
                m_y2AxisParameters.AddRange(selectionForm.GetCheckedParameters());
                Reprocess();
            }
        }

        #region Selection Parameters Help

        private List<fsTablesAndChartsParametersSelectionDialog.fsYAxisParameterWithChecking> GetSelectionParametersWithCheking(ListView yAxisList)
        {
            var selectionParameters =
                   new List<fsTablesAndChartsParametersSelectionDialog.fsYAxisParameterWithChecking>();
            foreach (
                fsTablesAndChartsParametersSelectionDialog.fsYAxisParameter yParameter in
                    GetSelectionParameters(m_values.Keys))
            {
                selectionParameters.Add(
                    new fsTablesAndChartsParametersSelectionDialog.fsYAxisParameterWithChecking(
                        yParameter.Identifier,
                        yParameter.Kind,
                        IsContains(yAxisList.Items, yParameter.Identifier.Name)));
            }
            return selectionParameters;
        }

        private List<fsTablesAndChartsParametersSelectionDialog.fsYAxisParameter> GetSelectionParameters(IEnumerable<fsParameterIdentifier> parameters)
        {
            var selectionParameters = new List<fsTablesAndChartsParametersSelectionDialog.fsYAxisParameter>();
            foreach (fsParameterIdentifier parameter in parameters)
            {
                fsParametersGroup group = m_parameterToGroup[parameter];
                bool isChecked = IsContains(m_yAxisList.CheckedItems, parameter.Name);
                fsTablesAndChartsParametersSelectionDialog.fsYAxisParameter.fsYParameterKind kind;
                if (parameter == m_xAxisParameter)
                {
                    kind =
                        fsTablesAndChartsParametersSelectionDialog.fsYAxisParameter.fsYParameterKind.
                            CalculatedVariableParameter;
                }
                else if (group.IsInput && parameter == group.Representator)
                {
                    kind =
                        fsTablesAndChartsParametersSelectionDialog.fsYAxisParameter.fsYParameterKind.
                            InputParameter;
                }
                else
                {
                    if (IsConstantList(m_data[parameter]))
                    {
                        kind =
                        fsTablesAndChartsParametersSelectionDialog.fsYAxisParameter.fsYParameterKind.
                            CalculatedConstantParameter;
                    }
                    else
                    {
                        kind =
                        fsTablesAndChartsParametersSelectionDialog.fsYAxisParameter.fsYParameterKind.
                            CalculatedVariableParameter;
                    }
                }
                selectionParameters.Add(
                    new fsTablesAndChartsParametersSelectionDialog.fsYAxisParameter(parameter, kind));
            }
            return selectionParameters;
        }

        #endregion

        #endregion
    }
}
