using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Parameters;
using StepCalculators;

namespace Calculator.Calculation_Controls
{
    public partial class PermeabilityControl : CalculatorControl
    {
        public PermeabilityControl()
        {
            InitializeComponent();

            m_calculationProcessor.Calculators.Add(new fsPermeabilityCalculator());

            var solidsGroup = m_calculationProcessor.AddGroup(
                fsParameterIdentifier.SolidsDensity);
            var porosityGroup = m_calculationProcessor.AddGroup(
                fsParameterIdentifier.Porosity);
            var pc0rc0a0Group = m_calculationProcessor.AddGroup(
                fsParameterIdentifier.Pc0,
                fsParameterIdentifier.Rc0,
                fsParameterIdentifier.Alpha0);
            var ncGroup = m_calculationProcessor.AddGroup(
                fsParameterIdentifier.Nc);
            var pressureGroup = m_calculationProcessor.AddGroup(
                fsParameterIdentifier.Pressure);
            var pcrcaGroup = m_calculationProcessor.AddGroup(
                fsParameterIdentifier.Pc,
                fsParameterIdentifier.Rc,
                fsParameterIdentifier.Alpha);

            AddGroup(dataGrid, solidsGroup, Color.FromArgb(230, 230, 255));
            AddGroup(dataGrid, porosityGroup, Color.FromArgb(255, 255, 230));
            AddGroup(dataGrid, pc0rc0a0Group, Color.FromArgb(230, 230, 255));
            AddGroup(dataGrid, ncGroup, Color.FromArgb(255, 255, 230));
            AddGroup(dataGrid, pressureGroup, Color.FromArgb(230, 230, 255));
            AddGroup(dataGrid, pcrcaGroup, Color.FromArgb(255, 230, 230));

            m_calculationProcessor.SetGroupInputed(solidsGroup, true);
            m_calculationProcessor.SetGroupInputed(porosityGroup, true);
            m_calculationProcessor.SetGroupInputed(pc0rc0a0Group, true);
            m_calculationProcessor.SetGroupInputed(ncGroup, true);
            m_calculationProcessor.SetGroupInputed(pressureGroup, true);
            m_calculationProcessor.SetGroupInputed(pcrcaGroup, false);
        }

        private void dataGrid_CellValueChangedByUser(object sender, DataGridViewCellEventArgs e)
        {
            m_calculationProcessor.CellValueChanged(dataGrid[e.ColumnIndex, e.RowIndex]);
        }
    }
}
