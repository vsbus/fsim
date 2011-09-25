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
    public partial class DensityConcentrationControl : UserControl
    {
        private CalculationProcessor m_calculationProcessor = new CalculationProcessor();
        
        public DensityConcentrationControl()
        {
            InitializeComponent();
        }

        private void DensityConcentrationControl_Load(object sender, EventArgs e)
        {
            m_calculationProcessor.Calculators.Add(new fsDensityConcentrationCalculator());

            var filtrateGroup = m_calculationProcessor.AddGroup(
                fsParameterIdentifier.FiltrateDensity);
            var solidsGroup = m_calculationProcessor.AddGroup(
                fsParameterIdentifier.SolidsDensity);
            var suspensionGroup = m_calculationProcessor.AddGroup(
                fsParameterIdentifier.SuspensionDensity);
            var concentrationGroup = m_calculationProcessor.AddGroup(
                fsParameterIdentifier.SolidsMassFraction,
                fsParameterIdentifier.SolidsVolumeFraction,
                fsParameterIdentifier.SolidsConcentration);

            AddGroup(filtrateGroup, Color.FromArgb(230, 255, 255));
            AddGroup(solidsGroup, Color.FromArgb(255, 230, 255));
            AddGroup(suspensionGroup, Color.FromArgb(255, 255, 230));
            AddGroup(concentrationGroup, Color.FromArgb(230, 230, 230));
            
            ChangeCalculationOption();
        }

        private void AddGroup(CalculationProcessor.Group group, Color color)
        {
            foreach (var p in group.Parameters)
            {
                AddRow(p, color);
            }
        }

        private void AddRow(fsParameterIdentifier parameter, Color color)
        {
            int ind = dataGrid.Rows.Add(new[] {parameter.ToString(), ""});
            foreach (DataGridViewCell cell in dataGrid.Rows[ind].Cells)
            {
                cell.Style.BackColor = color;
            }
            m_calculationProcessor.AssignParameterAndCell(parameter, dataGrid.Rows[ind].Cells[1]);
        }

        #region radio buttons events
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ChangeCalculationOption();
        }

        private void solidsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ChangeCalculationOption();
        }

        private void suspensionRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ChangeCalculationOption();
        }

        private void concentrationsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ChangeCalculationOption();
        }

        #endregion
        private void ChangeCalculationOption()
        {
            fsParameterIdentifier driveParameter = null;
            if (filtrateRadioButton.Checked)
            {
                driveParameter = fsParameterIdentifier.FiltrateDensity;
            }
            if (solidsRadioButton.Checked)
            {
                driveParameter = fsParameterIdentifier.SolidsDensity;
            }
            if (suspensionRadioButton.Checked)
            {
                driveParameter = fsParameterIdentifier.SuspensionDensity;
            }
            if (concentrationsRadioButton.Checked)
            {
                driveParameter = fsParameterIdentifier.SolidsMassFraction;
            }

            CalculationProcessor.Group newCalculatedGroup = m_calculationProcessor.ParameterToGroup[driveParameter];
            foreach (var g in m_calculationProcessor.Groups)
            {
                m_calculationProcessor.SetGroupInputed(g, g != newCalculatedGroup);
            }

            m_calculationProcessor.RecalculateAndOutput();
        }

        private void dataGrid_CellValueChangedByUser(object sender, DataGridViewCellEventArgs e)
        {
            m_calculationProcessor.CellValueChanged(dataGrid[e.ColumnIndex, e.RowIndex]);
        }
    }
}
