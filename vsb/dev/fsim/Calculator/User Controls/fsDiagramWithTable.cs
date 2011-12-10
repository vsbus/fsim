using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Value;
using ZedGraph;

namespace Calculator.User_Controls
{
    public partial class fsDiagramWithTable : UserControl
    {
        public fsDiagramWithTable()
        {
            InitializeComponent();
        }

        public class fsNamedArray
        {
            public string Name { get; set; }
            public fsValue [] Array { get; set; }

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

        private fsNamedArray m_xAxis;
        private List<fsNamedArray> m_yAxis = new List<fsNamedArray>();
        private List<fsNamedArray> m_y2Axis = new List<fsNamedArray>();

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
        }

        private void AddArrayToTable(fsNamedArray curve)
        {
            table.ColumnCount++;
            table.RowCount = Math.Max(table.RowCount, curve.Array.Length);
            var column = table.Columns[table.ColumnCount - 1];
            column.HeaderCell.Value = curve.Name;
            for (int row = 0; row < curve.Array.Length; ++row)
            {
                table[table.ColumnCount - 1, row].Value = curve.Array[row].ToString();
            }
        }

        private void RefreshCurves()
        {
            fmZedGraphControl1.GraphPane.CurveList.Clear();
            foreach (fsNamedArray curve in m_yAxis)
            {
                string name = curve.Name;
                PointPairList pointList = new ZedGraph.PointPairList();
                for (int i = 0; i < curve.Array.Length; ++i)
                {
                    if (curve.Array[i].Defined)
                    {
                        pointList.Add(m_xAxis.Array[i].Value, curve.Array[i].Value);
                    }
                }
                LineItem zedCurve = fmZedGraphControl1.GraphPane.AddCurve(name, pointList, Color.Black, SymbolType.None);
                zedCurve.Line.IsAntiAlias = true;
            }

            fmZedGraphControl1.GraphPane.AxisChange();
            fmZedGraphControl1.Refresh();
        }

    }
}
