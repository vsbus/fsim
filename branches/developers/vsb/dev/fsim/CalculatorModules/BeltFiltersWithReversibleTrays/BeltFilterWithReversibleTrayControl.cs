using System.ComponentModel;
using System.Drawing;
using Parameters;
using StepCalculators;
using StepCalculators.Simulation_Calculators;
using StepCalculators.Simulation_Calculators.Simulation_Help_Calculators;

namespace CalculatorModules.BeltFiltersWithReversibleTrays
{
    public sealed partial class fsBeltFilterWithReversibleTrayControl : fsOptionsOneTableAndCommentsCalculatorControl
    {
        #region Calculation Option

        private enum fsCalculationOption
        {
            [Description("Standard")]
            Standard,
            [Description("Design")]
            Design
        }

        #endregion

        public fsBeltFilterWithReversibleTrayControl()
        {
            InitializeComponent();

            Calculators.Add(new fsDensityConcentrationCalculator());
            Calculators.Add(new fsEps0Kappa0Calculator());
            Calculators.Add(new fsRf0Rs0RhoCw0FromDensitiesAndCakePorosity0Calculator());
            Calculators.Add(new fsPc0Rc0Alpha0Calculator());
            Calculators.Add(new fsRm0Hce0Calculator());
            Calculators.Add(new fsBeltFiltersWithReversibleTraysCalculator());

            fsParametersGroup etafGroup = AddGroup(
                fsParameterIdentifier.ViscosityFiltrate);

            fsParametersGroup rhofGroup = AddGroup(
                fsParameterIdentifier.FiltrateDensity);

            fsParametersGroup densitiesGroup = AddGroup(
                fsParameterIdentifier.SolidsDensity,
                fsParameterIdentifier.SuspensionDensity);

            fsParametersGroup cGroup = AddGroup(
                fsParameterIdentifier.SuspensionSolidsMassFraction,
                fsParameterIdentifier.SuspensionSolidsVolumeFraction,
                fsParameterIdentifier.SuspensionSolidsConcentration);

            fsParametersGroup epsGroup = AddGroup(
                fsParameterIdentifier.CakePorosity0,
                fsParameterIdentifier.Kappa0,
                fsParameterIdentifier.DryCakeDensity0);

            fsParametersGroup rGroup = AddGroup(
                fsParameterIdentifier.CakeWetDensity0,
                fsParameterIdentifier.CakeWetMassSolidsFractionRs0,
                fsParameterIdentifier.CakeMoistureContentRf0);

            fsParametersGroup neGroup = AddGroup(
                fsParameterIdentifier.Ne);

            fsParametersGroup pcrcGroup = AddGroup(
                fsParameterIdentifier.CakePermeability0,
                fsParameterIdentifier.CakeResistance0,
                fsParameterIdentifier.CakeResistanceAlpha0);

            fsParametersGroup ncGroup = AddGroup(
                fsParameterIdentifier.CakeCompressibility);

            fsParametersGroup hce0Group = AddGroup(
                fsParameterIdentifier.FilterMediumResistanceHce0,
                fsParameterIdentifier.FilterMediumResistanceRm0);
            
            fsParametersGroup qsusGroup = AddGroup(
                fsParameterIdentifier.Qms,
                fsParameterIdentifier.Qsus,
                fsParameterIdentifier.SuspensionMassFlowrate);
            
            fsParametersGroup nsGroup = AddGroup(
                fsParameterIdentifier.ns);

            fsParametersGroup geometryGroup = AddGroup(
                fsParameterIdentifier.ls_over_b,
                fsParameterIdentifier.l_over_b,
                fsParameterIdentifier.ls);
            
            fsParametersGroup timeGroup = AddGroup(
                fsParameterIdentifier.ttech0);
            
            fsParametersGroup dpGroup = AddGroup(
                fsParameterIdentifier.PressureDifference);
            
            fsParametersGroup cycleGroup = AddGroup(
                fsParameterIdentifier.u,
                fsParameterIdentifier.RotationalSpeed,
                fsParameterIdentifier.CycleTime,
                fsParameterIdentifier.nsf,
                fsParameterIdentifier.nsr,
                fsParameterIdentifier.SpecificFiltrationTime,
                fsParameterIdentifier.SpecificResidualTime,
                fsParameterIdentifier.ResidualTime);
            
            fsParametersGroup filtrationGroup = AddGroup(
                fsParameterIdentifier.CakeHeight,
                fsParameterIdentifier.FiltrationTime,
                fsParameterIdentifier.qft,
                fsParameterIdentifier.qmft);
            
            fsParametersGroup lambdaGroup = AddGroup(
                fsParameterIdentifier.lambda);
            
            fsParametersGroup resultsGroup = AddGroup(
                fsParameterIdentifier.FilterArea,
                fsParameterIdentifier.As,
                fsParameterIdentifier.MachineWidth,
                fsParameterIdentifier.FilterLength,
                fsParameterIdentifier.CakePorosity,
                fsParameterIdentifier.Kappa,
                fsParameterIdentifier.DryCakeDensity,
                fsParameterIdentifier.TechnicalTime);

            var groups = new[]
                             {
                                etafGroup,
                                rhofGroup,
                                densitiesGroup,
                                cGroup,
                                epsGroup,
                                rGroup,
                                neGroup,
                                pcrcGroup,
                                ncGroup,
                                hce0Group, 
                                qsusGroup,
                                nsGroup,
                                geometryGroup,
                                timeGroup,
                                dpGroup,
                                cycleGroup,
                                filtrationGroup,
                                lambdaGroup,
                                resultsGroup
                             };

            var colors = new[]
                             {
                                 Color.FromArgb(255, 255, 230),
                                 Color.FromArgb(255, 230, 255)
                             };

            for (int i = 0; i < groups.Length; ++i)
            {
                AddGroupToUI(dataGrid, groups[i], colors[i % colors.Length]);
                SetGroupInput(groups[i], true);
            }
            SetGroupInput(rGroup, false);
            SetGroupInput(resultsGroup, false);

            fsMisc.FillList(calculationComboBox.Items, typeof(fsCalculationOption));
            EstablishCalculationOption(fsCalculationOption.Design);
            AssignCalculationOptionAndControl(typeof(fsCalculationOption), calculationComboBox);

            UpdateGroupsInputInfoFromCalculationOptions();
            UpdateEquationsFromCalculationOptions();
            Recalculate();
            UpdateUIFromData();
            ConnectUIWithDataUpdating(dataGrid, calculationComboBox);
        }

        #region Routine Methods

        protected override void UpdateGroupsInputInfoFromCalculationOptions()
        {
            // for now we work only with design option so do nothing here
        }

        protected override void UpdateEquationsFromCalculationOptions()
        {
            //m_calculator.FromCalculationOption =
            //    (fsCalculationOptions.fsFromCalculationOption)
            //    CalculationOptions[typeof(fsCalculationOptions.fsFromCalculationOption)];
            //m_calculator.WashOutContentOption =
            //    (fsCalculationOptions.fsWashOutContentOption)
            //    CalculationOptions[typeof(fsCalculationOptions.fsWashOutContentOption)];
            //m_calculator.RebuildEquationsList();
        }

        protected override void UpdateUIFromData()
        {
            //var fromContentOption =
            //    (fsCalculationOptions.fsFromCalculationOption)
            //    CalculationOptions[typeof(fsCalculationOptions.fsFromCalculationOption)];
            //bool isFromWashOutConcentration = fromContentOption ==
            //                                  fsCalculationOptions.fsFromCalculationOption.WashOutContent;

            //washOutContentLabel.Visible = isFromWashOutConcentration;
            //washOutContentComboBox.Visible = isFromWashOutConcentration;

            //var washOutContentOption =
            //    (fsCalculationOptions.fsWashOutContentOption)
            //    CalculationOptions[typeof(fsCalculationOptions.fsWashOutContentOption)];
            //bool isCmInput = washOutContentOption ==
            //                 fsCalculationOptions.fsWashOutContentOption.AsMassFraction;

            //ParameterToCell[fsParameterIdentifier.LiquidWashOutMassFraction].OwningRow.Visible =
            //    isFromWashOutConcentration &&
            //    isCmInput;
            //ParameterToCell[fsParameterIdentifier.LiquidWashOutConcentration].OwningRow.Visible =
            //    isFromWashOutConcentration && !isCmInput;
            //ParameterToCell[fsParameterIdentifier.LiquidDensity].OwningRow.Visible = !isFromWashOutConcentration ||
            //                                                                         !isCmInput;
            //ParameterToCell[fsParameterIdentifier.Ph].OwningRow.Visible = !isFromWashOutConcentration;
            //ParameterToCell[fsParameterIdentifier.PHcake].OwningRow.Visible = !isFromWashOutConcentration;

            base.UpdateUIFromData();
        }

        #endregion
    }
}

