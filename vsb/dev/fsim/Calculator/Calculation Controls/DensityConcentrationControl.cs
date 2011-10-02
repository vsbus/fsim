using System;
using System.Drawing;
using System.Windows.Forms;
using Parameters;
using StepCalculators;

namespace Calculator.Calculation_Controls
{
    public partial class DensityConcentrationControl : fsCalculatorControl
    {
        #region Calculation Data

        enum fsCalculationOption
        {
            CALC_FILTRATE_DENSITY,
            CALC_SOLIDS_DENSITY,
            CALC_SUSPENSION_DENSITY,
            CALC_CONCENTRATIONS
        }
       
        #endregion

        public DensityConcentrationControl()
        {
            InitializeComponent();

            Calculators.Add(new fsDensityConcentrationCalculator());

            var filtrateGroup = AddGroup(
                fsParameterIdentifier.FiltrateDensity);
            var solidsGroup = AddGroup(
                fsParameterIdentifier.SolidsDensity);
            var suspensionGroup = AddGroup(
                fsParameterIdentifier.SuspensionDensity);
            var concentrationGroup = AddGroup(
                fsParameterIdentifier.SolidsMassFraction,
                fsParameterIdentifier.SolidsVolumeFraction,
                fsParameterIdentifier.SolidsConcentration);

            AddGroupToUI(dataGrid, filtrateGroup, Color.FromArgb(230, 255, 255));
            AddGroupToUI(dataGrid, solidsGroup, Color.FromArgb(255, 230, 255));
            AddGroupToUI(dataGrid, suspensionGroup, Color.FromArgb(255, 255, 230));
            AddGroupToUI(dataGrid, concentrationGroup, Color.FromArgb(230, 230, 230));

            AssignCalculationOption(fsCalculationOption.CALC_FILTRATE_DENSITY, filtrateRadioButton, filtrateGroup);
            AssignCalculationOption(fsCalculationOption.CALC_SOLIDS_DENSITY, solidsRadioButton, solidsGroup);
            AssignCalculationOption(fsCalculationOption.CALC_SUSPENSION_DENSITY, suspensionRadioButton, suspensionGroup);
            AssignCalculationOption(fsCalculationOption.CALC_CONCENTRATIONS, concentrationsRadioButton, concentrationGroup);

            base.CalculationOption = fsCalculationOption.CALC_SUSPENSION_DENSITY;
            UpdateCalculationOptionAndInputGroups();

            ConnectUIWithDataUpdating(dataGrid);
            UpdateUIFromData();
        }
    }
}
