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
        #region Calculation Data

        enum CalculationOption
        {
            CALC_FILTRATE_DENSITY,
            CALC_SOLIDS_DENSITY,
            CALC_SUSPENSION_DENSITY,
            CALC_CONCENTRATIONS
        }
        private CalculationOption calculationOption;
       
        #endregion

        #region Routine Data

        ParametersGroup filtrateGroup;
        ParametersGroup solidsGroup;
        ParametersGroup suspensionGroup;
        ParametersGroup concentrationGroup;

        #endregion

        public DensityConcentrationControl()
        {
            InitializeComponent();

            Calculators.Add(new fsDensityConcentrationCalculator());

            filtrateGroup = AddGroup(
                fsParameterIdentifier.FiltrateDensity);
            solidsGroup = AddGroup(
                fsParameterIdentifier.SolidsDensity);
            suspensionGroup = AddGroup(
                fsParameterIdentifier.SuspensionDensity);
            concentrationGroup = AddGroup(
                fsParameterIdentifier.SolidsMassFraction,
                fsParameterIdentifier.SolidsVolumeFraction,
                fsParameterIdentifier.SolidsConcentration);

            AddGroupToUI(dataGrid, filtrateGroup, Color.FromArgb(230, 255, 255));
            AddGroupToUI(dataGrid, solidsGroup, Color.FromArgb(255, 230, 255));
            AddGroupToUI(dataGrid, suspensionGroup, Color.FromArgb(255, 255, 230));
            AddGroupToUI(dataGrid, concentrationGroup, Color.FromArgb(230, 230, 230));

            AssignCalculationOption(CalculationOption.CALC_FILTRATE_DENSITY, filtrateRadioButton, filtrateGroup);
            AssignCalculationOption(CalculationOption.CALC_SOLIDS_DENSITY, solidsRadioButton, solidsGroup);
            AssignCalculationOption(CalculationOption.CALC_SUSPENSION_DENSITY, suspensionRadioButton, suspensionGroup);
            AssignCalculationOption(CalculationOption.CALC_CONCENTRATIONS, concentrationsRadioButton, concentrationGroup);

            calculationOption = CalculationOption.CALC_SUSPENSION_DENSITY;
            UpdateCalculationOptionAndInputGroups();

            ConnectUIWithDataUpdating();
            UpdateUIFromData();
        }

        #region Routine Methods

        protected override void UpdateUIFromData()
        {
            UpdateCellForeColors();

            WriteValuesToDataGrid();

            calculationOptionToRadioButton[calculationOption].Checked = true;
        }

        protected override void UpdateCalculationOptionAndInputGroups()
        {
            foreach (var pair in calculationOptionToRadioButton)
            {
                if (pair.Value.Checked)
                {
                    calculationOption = (CalculationOption)pair.Key;
                    break;
                }
            }

            foreach (var group in Groups)
            {
                SetGroupInput(group, calculationOptionToGroup[calculationOption] != group);
            }
        }

        protected override void ConnectUIWithDataUpdating()
        {
            dataGrid.CellValueChangedByUser += new DataGridViewCellEventHandler(dataGridCellValueChangedByUser);
            foreach (var radioButton in calculationOptionToRadioButton.Values)
            {
                radioButton.CheckedChanged += new EventHandler(radioButtonCheckedChanged);
            }
        }

        void radioButtonCheckedChanged(object sender, EventArgs e)
        {
            UpdateCalculationOptionAndInputGroups();
            UpdateUIFromData();
        }

        void dataGridCellValueChangedByUser(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView)
            {
                ProcessNewEntry(((DataGridView)sender).CurrentCell);
            }
            UpdateUIFromData();
        }

        #endregion
    }
}
