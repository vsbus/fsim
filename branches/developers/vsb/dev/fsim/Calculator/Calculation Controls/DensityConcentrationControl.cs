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
    public partial class DensityConcentrationControl : CalculatorControl
    {
        public DensityConcentrationControl()
        {
            InitializeComponent();

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

            AddGroup(dataGrid, filtrateGroup, Color.FromArgb(230, 255, 255));
            AddGroup(dataGrid, solidsGroup, Color.FromArgb(255, 230, 255));
            AddGroup(dataGrid, suspensionGroup, Color.FromArgb(255, 255, 230));
            AddGroup(dataGrid, concentrationGroup, Color.FromArgb(230, 230, 230));

            ChangeCalculationOption();
        }

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

            ParametersGroup newCalculatedGroup = m_calculationProcessor.ParameterToGroup[driveParameter];
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

        #region Radio Buttons Events

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
    }
}
