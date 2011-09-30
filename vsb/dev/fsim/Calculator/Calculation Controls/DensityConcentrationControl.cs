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
        #region 

        enum CalculationOption
        {
            CALC_FILTRATE_DENSITY,
            CALC_SOLIDS_DENSITY,
            CALC_SUSPENSION_DENSITY,
            CALC_CONCENTRATIONS
        }
        private CalculationOption calculationOption;
       
        #endregion

        ParametersGroup filtrateGroup;
        ParametersGroup solidsGroup;
        ParametersGroup suspensionGroup;
        ParametersGroup concentrationGroup;

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

            calculationOption = CalculationOption.CALC_SUSPENSION_DENSITY;
            UpdateCalculationOptionAndInputGroups();

            ConnectUIWithDataUpdating();
            UpdateUIFromData();
        }

        protected override void UpdateUIFromData()
        {
            UpdateCellForeColors();

            WriteValuesToDataGrid();

            switch (calculationOption)
            {
                case CalculationOption.CALC_FILTRATE_DENSITY:
                    filtrateRadioButton.Checked = true;
                    break;
                case CalculationOption.CALC_SOLIDS_DENSITY:
                    solidsRadioButton.Checked = true;
                    break;
                case CalculationOption.CALC_SUSPENSION_DENSITY:
                    suspensionRadioButton.Checked = true;
                    break;
                case CalculationOption.CALC_CONCENTRATIONS:
                    concentrationsRadioButton.Checked = true;
                    break;
            }
        }

        protected override void UpdateCalculationOptionAndInputGroups()
        {
            if (filtrateRadioButton.Checked)
            {
                calculationOption = CalculationOption.CALC_FILTRATE_DENSITY;
            }
            if (solidsRadioButton.Checked)
            {
                calculationOption = CalculationOption.CALC_SOLIDS_DENSITY;
            }
            if (suspensionRadioButton.Checked)
            {
                calculationOption = CalculationOption.CALC_SUSPENSION_DENSITY;
            }
            if (concentrationsRadioButton.Checked)
            {
                calculationOption = CalculationOption.CALC_CONCENTRATIONS;
            }

            SetGroupInput(filtrateGroup, calculationOption != CalculationOption.CALC_FILTRATE_DENSITY);
            SetGroupInput(solidsGroup, calculationOption != CalculationOption.CALC_SOLIDS_DENSITY);
            SetGroupInput(suspensionGroup, calculationOption != CalculationOption.CALC_SUSPENSION_DENSITY);
            SetGroupInput(concentrationGroup, calculationOption != CalculationOption.CALC_CONCENTRATIONS);
        }
        private void SetGroupInput(ParametersGroup group, bool value)
        {
            group.IsInput = value;
            foreach (var parameter in group.Parameters)
            {
                ParameterToCell[parameter].ReadOnly = !value;
            }
        }

        protected override void ConnectUIWithDataUpdating()
        {
            dataGrid.CellValueChangedByUser += new DataGridViewCellEventHandler(dataGridCellValueChangedByUser);
            filtrateRadioButton.CheckedChanged += new EventHandler(radioButtonCheckedChanged);
            solidsRadioButton.CheckedChanged += new EventHandler(radioButtonCheckedChanged);
            suspensionRadioButton.CheckedChanged += new EventHandler(radioButtonCheckedChanged);
            concentrationsRadioButton.CheckedChanged += new EventHandler(radioButtonCheckedChanged);
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
    }
}
