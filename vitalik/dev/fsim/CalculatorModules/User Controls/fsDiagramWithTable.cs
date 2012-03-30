using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Value;
using ZedGraph;

namespace CalculatorModules.User_Controls
{
    public partial class fsDiagramWithTable : UserControl
    {
        private readonly List<fsNamedArray> m_yAxis = new List<fsNamedArray>();
        private readonly List<fsNamedArray> m_y2Axis = new List<fsNamedArray>();
        private fsNamedArray m_xAxis;

        public fsDiagramWithTable()
        {
            InitializeComponent();
        }

        public void SetXAxis(fsNamedArray xAxis)
        {
            m_xAxis = xAxis;
        }

        public void ClearYAxis()
        {
            m_yAxis.Clear();
        }

        public void AddYAxis(fsNamedArray yAxis)
        {
            m_yAxis.Add(yAxis);
        }

        public void ClearY2Axis()
        {
            m_y2Axis.Clear();
        }

        public void AddY2Axis(fsNamedArray yAxis)
        {
            m_y2Axis.Add(yAxis);
        }

        public void Redraw()
        {
            RefreshCurves();
            RefreshTable();
        }

        private void RefreshTable()
        {
            table.ColumnCount = 0;
            AddArrayToTable(m_xAxis);
            foreach (fsNamedArray curve in m_yAxis)
            {
                AddArrayToTable(curve);
            }
            foreach (fsNamedArray curve in m_y2Axis)
            {
                AddArrayToTable(curve);
            }
        }

        private void AddArrayToTable(fsNamedArray curve)
        {
            table.ColumnCount++;
            table.RowCount = Math.Max(table.RowCount, curve.Array.Length);
            DataGridViewColumn column = table.Columns[table.ColumnCount - 1];
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.HeaderCell.Value = curve.Name;
            for (int row = 0; row < curve.Array.Length; ++row)
            {
                table[table.ColumnCount - 1, row].Value = curve.Array[row].ToString();
            }
        }

        private void RefreshCurves()
        {
            fmZedGraphControl1.GraphPane.CurveList.Clear();
            fmZedGraphControl1.GraphPane.XAxis.Title.Text = m_xAxis.Name;
            fmZedGraphControl1.GraphPane.YAxis.IsVisible = false;
            fmZedGraphControl1.GraphPane.Y2Axis.IsVisible = false;

            RefreshYAxis(m_yAxis, false);
            RefreshYAxis(m_y2Axis, true);

            fmZedGraphControl1.GraphPane.AxisChange();
            fmZedGraphControl1.Refresh();
        }

        private void RefreshYAxis(List<fsNamedArray> yAxis, bool isY2Axis)
        {
            if (yAxis.Count > 0)
            {
                Color color;
                Axis graphYAxis;
                if (isY2Axis)
                {
                    color = Color.Green;
                    graphYAxis = fmZedGraphControl1.GraphPane.Y2Axis;
                }
                else
                {
                    color = Color.Blue;
                    graphYAxis = fmZedGraphControl1.GraphPane.YAxis;
                }
                graphYAxis.IsVisible = true;
                graphYAxis.Color = color;
                graphYAxis.Title.Text = "";

                foreach (fsNamedArray curve in yAxis)
                {
                    string name = curve.Name;
                    var pointList = new PointPairList();
                    for (int i = 0; i < curve.Array.Length; ++i)
                    {
                        if (curve.Array[i].Defined)
                        {
                            pointList.Add(m_xAxis.Array[i].Value, curve.Array[i].Value);
                        }
                    }
                    LineItem zedCurve = fmZedGraphControl1.GraphPane.AddCurve(name, pointList, color, SymbolType.None);
                    zedCurve.IsY2Axis = isY2Axis;
                    zedCurve.Line.IsAntiAlias = true;
                }
            }
        }

        #region Nested type: fsNamedArray

        public class fsNamedArray
        {
            public string Name { get; set; }
            public fsValue[] Array { get; set; }

            public double[] GetDoublesArray()
            {
                var result = new double[Array.Length];
                for (int i = 0; i < result.Length; ++i)
                {
                    result[i] = Array[i].Value;
                }
                return result;
            }
        }

        #endregion
    }
}