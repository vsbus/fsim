using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Parameters;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;

namespace Calculator.Calculation_Controls
{
    public class CalculatorControl : UserControl
    {
        protected CalculationProcessor m_calculationProcessor = new CalculationProcessor();

        protected void AddGroup(DataGridView dataGrid, ParametersGroup group, Color color)
        {
            foreach (var p in group.Parameters)
            {
                AddRow(dataGrid, p, color);
            }
        }

        protected void AddRow(DataGridView dataGrid, fsParameterIdentifier parameter, Color color)
        {
            int ind = dataGrid.Rows.Add(new[] { parameter.ToString() + " [" + parameter.Units.CurrentName + "]", "" });
            foreach (DataGridViewCell cell in dataGrid.Rows[ind].Cells)
            {
                cell.Style.BackColor = color;
            }
            m_calculationProcessor.AssignParameterAndCell(parameter, dataGrid.Rows[ind].Cells[1]);
        }
    }
}
