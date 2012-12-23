﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CalculatorModules.User_Controls;
using CalculatorModules.User_Controls.Help_Dialogs;
using Parameters;
using ParametersIdentifiers;
using ParametersIdentifiers.Ranges;
using StepCalculators;
using Value;
using ZedGraph;

namespace CalculatorModules.Hydrocyclone.Feeds
{
    public partial class FeedCurvesControl : UserControl
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
        private fsParameterIdentifier m_iterationParameter;

        private readonly List<fsParameterIdentifier> m_yAxisParameters = new List<fsParameterIdentifier>();
        private readonly List<fsParameterIdentifier> m_y2AxisParameters = new List<fsParameterIdentifier>();

        private fsHydrocycloneNewControl hcControl;

        private AxisType xAxisType = AxisType.Linear;

        private bool isXAxisComboBoxFirstChanged;

        private bool isXgZero;
        private bool isSigmaGZero;
        private bool isSigmaSZero;
        private bool isXRedZero;
        private bool isThereZeroInfluencingParameter;

        //private bool isXAxisSet = false;

        private bool isEmptyPlot = true;

        #endregion

        #region Constructor

        public FeedCurvesControl()
        {
            InitializeComponent();

            isXAxisComboBoxFirstChanged = true;
            m_xAxisComboBox.SelectedIndex = 0;

            m_values = new Dictionary<fsParameterIdentifier, fsSimulationModuleParameter>();
        }

        #endregion

        //private void SetCurvesNames()
        //{
        //    foreach (var parameter in m_yAxisParameters)
        //    {
        //        var array = new fsDiagramWithTable.fsNamedArray { Name = parameter.Name + " [" + fsFeedFunctionsData.Values[parameter].Unit.Name + "]", Array = new fsValue[] { } }; 
        //        fsDiagramWithTable1.AddYAxis(array);                
        //    }
        //    foreach (var parameter in m_y2AxisParameters)
        //    {
        //        var array = new fsDiagramWithTable.fsNamedArray { Name = parameter.Name + " [" + fsFeedFunctionsData.Values[parameter].Unit.Name + "]", Array = new fsValue[] { } };
        //        fsDiagramWithTable1.AddY2Axis(array);                
        //    }
        //}

        public void SetHcControl(fsHydrocycloneNewControl hcc)
        {
            hcControl = hcc;
        }
        
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

        public void SetDiagram(
            fsParameterIdentifier iterationParameter,
            fsParameterIdentifier[] yAxisParameters,
            fsParameterIdentifier[] y2AxisParameters)
        {
            m_iterationParameter = iterationParameter;

            m_yAxisParameters.Clear();
            foreach (fsParameterIdentifier p in yAxisParameters)
            {
                m_yAxisParameters.Add(p);
            }

            m_y2AxisParameters.Clear();
            foreach (fsParameterIdentifier p in y2AxisParameters)
            {
                m_y2AxisParameters.Add(p);
            }

            // ---------------- for drag-and-drop in fsFeedCurvesSelectionDialog
            SetYAxisParameters();
            SetY2AxisParameters();
            SetNameToParameter();
            // ----------------
        }

        #region Reprocessing

        private bool m_inputRefreshing;

        public void RefreshAndRecalculateAll()
        {
            CheckZeroInfluencingParameters();
            RefreshInputAndReadIterationParameter();
            CalculateData();
            RefreshOutputAndReadYParameters();
            RedrawTableAndChart();
        }

        private void RefreshOutputAndReadYParameters()
        {
            RefreshYAxisList(m_yAxisParameters, m_yAxisList);
            RefreshYAxisList(m_y2AxisParameters, m_y2AxisList);
        }

        private void RefreshInputAndReadIterationParameter()
        {
            if (!m_inputRefreshing)
            {
                m_inputRefreshing = true;

                RefreshRangesBoxes();

                //if (detalizationBox.Text == "")
                //{
                //    detalizationBox.Text = @"50";
                //}

                RefreshInputsBox();

                m_inputRefreshing = false;
            }
        }

        private void RefreshRangesBoxes()
        {
            fsRange range = m_values[m_iterationParameter].Range;
            double factor = m_values[m_iterationParameter].Unit.Coefficient;
            rangeFrom.Text = (range.From / factor).ToString();
            rangeTo.Text = (range.To / factor).ToString();
        }

        private void RefreshInputsBox()
        {
            inputsTextBox.ResetText();
            string line;
            foreach (var item in hcControl.ValuesForFeeds)
            {
                line = item.Key.Name + "\t" + item.Value.Unit.Name + "\t" + item.Value.GetValueInUnits();
                inputsTextBox.AppendText(line + "\r\n");
                bool condition = isXgZero && item.Key.Equals(fsParameterIdentifier.xg) ||
                                 isSigmaGZero && item.Key.Equals(fsParameterIdentifier.sigma_g) ||
                                 isSigmaSZero && item.Key.Equals(fsParameterIdentifier.sigma_s) ||
                                 isXRedZero && item.Key.Equals(fsParameterIdentifier.ReducedCutSize) ||
                                 !item.Value.Value.Defined;
                if (condition)
                {
                    int i = 0;
                    while (i <= inputsTextBox.Text.Length - line.Length)
                    {
                        i = inputsTextBox.Text.IndexOf(line, i);
                        if (i < 0) break;
                        inputsTextBox.SelectionStart = i;
                        inputsTextBox.SelectionLength = line.Length;
                        inputsTextBox.SelectionColor = Color.Red;
                        i += line.Length;
                    } 
                } 
            }
        }

        #region Calculations

        // ------ new --------
        private void CheckZeroInfluencingParameters()
        { 
            isXgZero = false;
            isSigmaGZero = false;
            isSigmaSZero = false;
            isXRedZero = false;
            if (hcControl.ValuesForFeeds[fsParameterIdentifier.xg].Value.Value == 0)
                isXgZero = true;
            if (hcControl.ValuesForFeeds[fsParameterIdentifier.sigma_g].Value.Value == 0)
                isSigmaGZero = true;
            if (hcControl.ValuesForFeeds[fsParameterIdentifier.sigma_s].Value.Value == 0)
                isSigmaSZero = true;
            if (hcControl.ValuesForFeeds[fsParameterIdentifier.ReducedCutSize].Value.Value == 0)
                isXRedZero = true;
            isThereZeroInfluencingParameter = isXgZero || isSigmaGZero || isSigmaSZero || isXRedZero;
        }
        // -------------------

        private void CalculateData()
        {
            if (m_inputRefreshing)
                return;

            m_data = new Dictionary<fsParameterIdentifier, List<fsSimulationModuleParameter>>();
         
            // ----- new ------
            if (isThereZeroInfluencingParameter)
            {
                isEmptyPlot = true;
                return;
            }
            isEmptyPlot = false;
            // ----------------

            var detalization = (int)fsValue.StringToValue(detalizationBox.Text).Value;            

            if (detalization < 2)
            {
                detalization = 2;
            }
            double factor = m_values[m_iterationParameter].Unit.Coefficient;
            fsValue from = fsValue.StringToValue(rangeFrom.Text) * factor;
            fsValue to = fsValue.StringToValue(rangeTo.Text) * factor; 

            // ------ new --------
            if (!(from.Defined && to.Defined))
                return;
            if (from > to)
            {
                fsValue to2 = to;
                to = from;
                from = to2;
            }
            if (from == to)
                to += 0.01 * factor;
            if (from.Value <= 0.01 * factor)
            {
                from.Value = 0.01 * factor;
                if (to.Value <= 0.02 * factor)
                    to.Value = 0.02 * factor;                    
            }
            // -------------------
           
            fsValue coef = (xAxisType == AxisType.Linear) ? (to - from) / (double)detalization : fsValue.Pow(to / from, 1 / (double)detalization);
            for (int i = 0; i <= detalization; ++i)
            {
                Dictionary<fsParameterIdentifier, fsSimulationModuleParameter> currentValues = 
                    m_values.ToDictionary(pair => pair.Key, pair => new fsSimulationModuleParameter(pair.Value));

                fsParametersGroup xInitialgroup = m_parameterToGroup[m_iterationParameter];
                var xNewGroup = new fsParametersGroup(xInitialgroup) { Representator = m_iterationParameter };
                SubstituteGroup(m_parameterToGroup, xInitialgroup, xNewGroup);

                if (xAxisType == AxisType.Linear)
                    currentValues[m_iterationParameter].Value  = from + coef * i;
                else
                    currentValues[m_iterationParameter].Value  = from * fsValue.Pow(coef, i);
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

        private void RedrawTableAndChart()
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
            if (!isEmptyPlot)
            {
                curves.AddRange(from pair in m_data
                                select pair.Key
                                    into parameter
                                    where IsContains(yAxisListView.CheckedItems, parameter.Name)
                                    select GetArray(parameter));
            }
            else
            {
                List<fsParameterIdentifier> list = new List<fsParameterIdentifier>();
                list.AddRange(m_yAxisParameters);
                list.AddRange(m_y2AxisParameters);
                curves.AddRange(from parameter in list
                                where IsContains(yAxisListView.CheckedItems, parameter.Name)
                                select new fsDiagramWithTable.fsNamedArray
                                {
                                    Name = parameter.Name,
                                    Array = new fsValue[] { }
                                });
            }
        }

        private fsDiagramWithTable.fsNamedArray GetArray(fsParameterIdentifier yParameter)
        {
            List<fsSimulationModuleParameter> values = m_data[yParameter];
            var array = new fsDiagramWithTable.fsNamedArray { Name = yParameter.Name + " [" + m_data[yParameter][0].Unit.Name + "]", Array = new fsValue[values.Count] };
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

            var variableResultsList = new List<KeyValuePair<string, bool>>();

            foreach (fsYAxisParameter selectionParameter in GetSelectionParameters(parameters))
            {
                string parameterName = selectionParameter.Identifier.Name;
                bool isChecked = IsContains(yAxisListView.CheckedItems, parameterName)
                                 || !IsContains(yAxisListView.Items, parameterName);
                var pair = new KeyValuePair<string, bool>(parameterName, isChecked);
                variableResultsList.Add(pair);
            }

            var newList = new List<ListViewItem>();
            newList.AddRange(
                variableResultsList.Select(
                    keyValuePair =>
                    new ListViewItem(keyValuePair.Key) { Checked = keyValuePair.Value, ForeColor = Color.Black }));
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

        private void RefreshDiagramAndTable()
        {
            fsDiagramWithTable.fsNamedArray xArray = new fsDiagramWithTable.fsNamedArray();
            fsDiagramWithTable.fsNamedArray niceXArray = new fsDiagramWithTable.fsNamedArray();
            if (!isEmptyPlot)
            {
                xArray = GetArray(m_iterationParameter);
                niceXArray = (xAxisType == AxisType.Linear) ? MakeIncreasingNiceNodes(xArray) : xArray;

                fsDiagramWithTable1.SetXAxis(niceXArray);
            }
            else
            {
                fsDiagramWithTable1.SetXAxis(m_iterationParameter.Name + " [" + fsFeedFunctionsData.Values[m_iterationParameter].Unit.Name + "]");
            }

            fsDiagramWithTable1.ClearYAxis();
            foreach (fsDiagramWithTable.fsNamedArray curve in m_yCurves)
            {
                if (isEmptyPlot)
                    fsDiagramWithTable1.AddYAxis(curve);
                else
                    fsDiagramWithTable1.AddYAxis(CalculateWithLinearization(curve, xArray, niceXArray));
            }

            fsDiagramWithTable1.ClearY2Axis();
            foreach (fsDiagramWithTable.fsNamedArray curve in m_y2Curves)
            {
                if (isEmptyPlot)
                    fsDiagramWithTable1.AddY2Axis(curve);
                else
                    fsDiagramWithTable1.AddY2Axis(CalculateWithLinearization(curve, xArray, niceXArray));
            }

            fsDiagramWithTable1.Redraw();
        }

        private static fsDiagramWithTable.fsNamedArray MakeIncreasingNiceNodes(fsDiagramWithTable.fsNamedArray xArray)
        {
            //double[] x = xArray.GetDoublesArray();
            //if (x[0] > x[x.Length - 1])
            //{
            //    x = x.Reverse().ToArray();
            //}
            //double low = x[0];
            //double high = x[x.Length - 1];
            //if (high == low)
            //{
            //    var result = new fsDiagramWithTable.fsNamedArray
            //    {
            //        Name = xArray.Name,
            //        Array = new fsValue[xArray.Array.Length]
            //    };
            //    xArray.Array.CopyTo(result.Array, 0);
            //    return result;
            //}
            // ------ new ------
            double low = xArray.Array[0].Value;
            double high = xArray.Array[xArray.Array.Length - 1].Value;
            // -----------------
            double eps = (high - low) * 1e-9;
            var steps = new[]
                            {
                                1,
                                2,
                                2.5,
                                5
                            };
            for (var deg = (int)Math.Ceiling(Math.Log10((high - low) / steps[steps.Length - 1])); ; --deg)
            {
                for (int i = steps.Length - 1; i >= 0; --i)
                {
                    double step = steps[i] * Math.Pow(10.0, deg);
                    var nodesAmount = (int)(Math.Ceiling(high / step) - Math.Floor(low / step));
                    //if (nodesAmount >= x.Length)
                    if (nodesAmount >= xArray.Array.Length)
                    {
                        var nodes = new List<fsValue> { new fsValue(low) };
                        for (int j = 0; ; ++j)
                        {
                            double node = (Math.Ceiling(low / step + eps) + j) * step;
                            if (node >= high)
                            {
                                break;
                            }
                            nodes.Add(new fsValue(node));
                        }
                        nodes.Add(new fsValue(high));
                        var result = new fsDiagramWithTable.fsNamedArray { Name = xArray.Name, Array = nodes.ToArray() };
                        return result;
                    }
                }
            }
        }

        private static fsDiagramWithTable.fsNamedArray CalculateWithLinearization(
            fsDiagramWithTable.fsNamedArray yArray,
            fsDiagramWithTable.fsNamedArray xArray,
            fsDiagramWithTable.fsNamedArray niceXArray)
        {
            double[] x = xArray.GetDoublesArray();
            double[] y = yArray.GetDoublesArray();
            if (x[0] > x[x.Length - 1])
            {
                x = x.Reverse().ToArray();
                y = y.Reverse().ToArray();
            }

            var result = new fsDiagramWithTable.fsNamedArray
            {
                Name = yArray.Name,
                Array = new fsValue[niceXArray.Array.Length]
            };
            for (int i = 0, j = 0; i < niceXArray.Array.Length; ++i)
            {
                double currentX = niceXArray.Array[i].Value;
                while (x[j + 1] < currentX)
                {
                    ++j;
                }
                double xLow = x[j];
                double xHigh = x[j + 1];
                double yLow = y[j];
                double yHigh = y[j + 1];
                result.Array[i] = new fsValue(yLow + (currentX - xLow) / (xHigh - xLow) * (yHigh - yLow));
            }
            return result;
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

        private void XAxisComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            if (isXAxisComboBoxFirstChanged)
            {
                isXAxisComboBoxFirstChanged = false;
                return;
            }

            if (this.m_xAxisComboBox.SelectedIndex == 0)
                xAxisType = AxisType.Linear;
            else
                xAxisType = AxisType.Log;
            fsDiagramWithTable1.fmZedGraphControl1.GraphPane.XAxis.Type = xAxisType;
            CalculateData();
            RedrawTableAndChart();
        }

        private void YAxisListItemChecked(object sender, ItemCheckedEventArgs e)
        {
            RedrawTableAndChart();
        }

        private void RangeFromTextChanged(object sender, EventArgs e)
        {
            m_values[m_iterationParameter].Range.From = fsValue.StringToValue(rangeFrom.Text) *
                                                    m_values[m_iterationParameter].Unit.Coefficient;
            CalculateData();
            RedrawTableAndChart();
        }

        private void RangeToTextChanged(object sender, EventArgs e)
        {
            m_values[m_iterationParameter].Range.To = fsValue.StringToValue(rangeTo.Text) *
                                                  m_values[m_iterationParameter].Unit.Coefficient;
            CalculateData();
            RedrawTableAndChart();
        }

        private void DetalizationBoxTextChanged(object sender, EventArgs e)
        {
            CalculateData();
            RedrawTableAndChart();
        }

        // -------- new --------- for drag-and-drop
        //public List<fsYAxisParameterWithChecking> yAxisParameters = new List<fsYAxisParameterWithChecking>();
        public fsYAxisParameterWithChecking[] yAxisParameters;

        private void SetYAxisParameters()
        {
            var array = new fsParameterIdentifier[]
                            {
                                fsFeedFunctionsData.F_id,
                                fsFeedFunctionsData.Fo_id,
                                fsFeedFunctionsData.Fu_id,
                                fsFeedFunctionsData.G_id,
                                fsFeedFunctionsData.GRed_id
                            };
            var kind = fsYAxisParameter.fsYParameterKind.CalculatedVariableParameter;
            //foreach (var item in array)
            //{
            //    yAxisParameters.Add(
            //        new fsYAxisParameterWithChecking(item, kind, m_yAxisParameters.Contains(item))
            //        );
            //}
            yAxisParameters = new fsYAxisParameterWithChecking[array.Length];
            for (int i = 0; i < array.Length; i++)
			{
                yAxisParameters[i] = new fsYAxisParameterWithChecking(array[i], kind, m_yAxisParameters.Contains(array[i]));
			}
        }

        //public List<fsYAxisParameterWithChecking> y2AxisParameters = new List<fsYAxisParameterWithChecking>();
        public fsYAxisParameterWithChecking[] y2AxisParameters;

        private void SetY2AxisParameters()
        {
            var array = new fsParameterIdentifier[]
                            {
                                fsFeedFunctionsData.f_id,
                                fsFeedFunctionsData.fo_id,
                                fsFeedFunctionsData.fu_id
                            };
            var kind = fsYAxisParameter.fsYParameterKind.CalculatedVariableParameter;
            //foreach (var item in array)
            //{
            //    y2AxisParameters.Add(
            //        new fsYAxisParameterWithChecking(item, kind, m_y2AxisParameters.Contains(item))
            //        );
            //}
            y2AxisParameters = new fsYAxisParameterWithChecking[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                y2AxisParameters[i] = new fsYAxisParameterWithChecking(array[i], kind, m_y2AxisParameters.Contains(array[i]));
            }
        }

        public Dictionary<String, fsYAxisParameterWithChecking> nameToParameter;

        private void SetNameToParameter()
        {
            var list = new List<fsYAxisParameterWithChecking>();
            list.AddRange(yAxisParameters);
            list.AddRange(y2AxisParameters);
            nameToParameter = list.ToDictionary(parameter => parameter.Identifier.Name);
        }

        //private void RefreshAllYAxesParametersChecking(fsFeedCurvesSelectionDialog dialog)
        //{
        //    foreach (ListViewItem item in dialog.y1SelectionControl.otherVariablesListView.Items)
        //    {
        //        nameToParameter[item.Text].IsChecked = item.Checked;
        //    }
        //    foreach (ListViewItem item in dialog.y2SelectionControl.otherVariablesListView.Items)
        //    {
        //        nameToParameter[item.Text].IsChecked = item.Checked;
        //    }
        //    //foreach (var parameter in nameToParameter.Values)
        //    //{
        //    //    if (yAxisParameters.Contains(parameter))
        //    //        yAxisParameters[yAxisParameters.IndexOf(parameter)].IsChecked = parameter.IsChecked;
        //    //    else
        //    //        y2AxisParameters[y2AxisParameters.IndexOf(parameter)].IsChecked = parameter.IsChecked;
        //    //}
        //    foreach (var parameter in yAxisParameters)
        //    {
        //        parameter.IsChecked = nameToParameter[parameter.Identifier.Name].IsChecked;
        //    }
        //    foreach (var parameter in y2AxisParameters)
        //    {
        //        parameter.IsChecked = nameToParameter[parameter.Identifier.Name].IsChecked;
        //    }
        //}

        public void SetSelectedParameters(fsFeedCurvesSelectionDialog selectionForm)
        {
            m_yAxisParameters.Clear();
            m_yAxisParameters.AddRange(selectionForm.GetCheckedYAxisParameters());
            m_y2AxisParameters.Clear();
            m_y2AxisParameters.AddRange(selectionForm.GetCheckedY2AxisParameters());
            RefreshOutputAndReadYParameters();
            RedrawTableAndChart();
        }


        // ------------------------------------------

        private void YAxisConfigureClick(object sender, EventArgs e)
        {
            //var selectionForm = new fsFeedCurvesSelectionDialog();
            //selectionForm.AssignYAxisParameters(GetSelectionParametersWithCheking(m_yAxisList));
            //selectionForm.AssignY2AxisParameters(GetSelectionParametersWithCheking(m_y2AxisList));
            // ------ new ---------
            var selectionForm = new fsFeedCurvesSelectionDialog(this);
            selectionForm.AssignYAxisParametersByOrder(yAxisParameters);
            selectionForm.AssignY2AxisParametersByOrder(y2AxisParameters);
            selectionForm.MinimizeBox = false;
            selectionForm.MaximizeBox = false;
            selectionForm.Location = new Point(this.ParentForm.Location.X + this.ParentForm.Width, this.ParentForm.Location.Y); 
            selectionForm.StartPosition = FormStartPosition.Manual;
            // --------------------
            selectionForm.ShowDialog();
            //if (selectionForm.DialogResult == DialogResult.OK)
            //{
            //    m_yAxisParameters.Clear();
            //    m_yAxisParameters.AddRange(selectionForm.GetCheckedYAxisParameters());
            //    m_y2AxisParameters.Clear();
            //    m_y2AxisParameters.AddRange(selectionForm.GetCheckedY2AxisParameters());
            //    // ------- new ---------
            //    RefreshAllYAxesParametersChecking(selectionForm);
            //    // ---------------------
            //RefreshAndRecalculateAll();
            //}
        }

        //private void Y2AxisConfigureClick(object sender, EventArgs e)
        //{
        //    var selectionForm = new fsFeedCurvesSelectionDialog();
        //    selectionForm.AssignYAxisParameters(GetSelectionParametersWithCheking(m_y2AxisList));
        //    selectionForm.ShowDialog();
        //    if (selectionForm.DialogResult == DialogResult.OK)
        //    {
        //        m_y2AxisParameters.Clear();
        //        m_y2AxisParameters.AddRange(selectionForm.GetCheckedYAxisParameters());
        //        RefreshAndRecalculateAll();
        //    }
        //}

        #region Selection Parameters Help

        ////private List<fsYAxisParameterWithChecking> GetSelectionParametersWithCheking(ListView yAxisList)
        //// ------ new -----
        //private List<fsYAxisParameterWithChecking> GetSelectionParametersWithCheking(IEnumerable<fsParameterIdentifier> parameters, ListView yAxisList)
        //// ----------------
        //{
        //    var selectionParameters =
        //           new List<fsYAxisParameterWithChecking>();
        //    //foreach (fsYAxisParameter yParameter in GetSelectionParameters(m_values.Keys))
        //    // ------- new --------
        //    foreach (fsYAxisParameter yParameter in GetSelectionParameters(parameters))
        //    // --------------------
        //    {
        //        selectionParameters.Add(
        //            new fsYAxisParameterWithChecking(
        //                yParameter.Identifier,
        //                yParameter.Kind,
        //                IsContains(yAxisList.Items, yParameter.Identifier.Name)));
        //    }
        //    return selectionParameters;
        //}

        private IEnumerable<fsYAxisParameter> GetSelectionParameters(IEnumerable<fsParameterIdentifier> parameters)
        {
            var selectionParameters = new List<fsYAxisParameter>();
            fsYAxisParameter.fsYParameterKind kind;
            foreach (fsParameterIdentifier parameter in parameters)
            {
                if (parameter != m_iterationParameter)
                {
                    kind = fsYAxisParameter.fsYParameterKind.CalculatedVariableParameter;
                    selectionParameters.Add(new fsYAxisParameter(parameter, kind));
                }
            }
            return selectionParameters;
        }

        #endregion

        #endregion
    }
}