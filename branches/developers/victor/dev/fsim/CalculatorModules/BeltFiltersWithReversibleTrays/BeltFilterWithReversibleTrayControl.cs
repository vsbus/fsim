using System.ComponentModel;
using System.Drawing;
using CalculatorModules.Base_Controls;
using Parameters;
using StepCalculators;
using StepCalculators.Material_Calculators;
using StepCalculators.Simulation_Calculators;

namespace CalculatorModules.BeltFiltersWithReversibleTrays
{
    public sealed partial class fsBeltFilterWithReversibleTrayControl : fsOptionsDoubleTableAndCommentsCalculatorControl
    {
        #region Calculation Option

        private enum fsCalculationOption
        {
            [Description("Standard Calculation")]
            StandardCalculation,
            [Description("Filter Design")]
            FilterDesign
        }

        #endregion

        public fsBeltFilterWithReversibleTrayControl()
        {
            InitializeComponent();

            #region Calculators
            
            Calculators.Add(new fsDensityConcentrationCalculator());
            Calculators.Add(new fsEpsKappaNeDpCalculator());
            Calculators.Add(new fsPc0Rc0Alpha0Calculator());
            Calculators.Add(new fsRm0Hce0Calculator());
            Calculators.Add(new fsBeltFiltersWithReversibleTraysCalculator());

            #endregion

            fsMisc.FillList(calculationComboBox.Items, typeof(fsCalculationOption));
            EstablishCalculationOption(fsCalculationOption.StandardCalculation);
            AssignCalculationOptionAndControl(typeof(fsCalculationOption), calculationComboBox);

            UpdateGroupsInputInfoFromCalculationOptions();
            UpdateEquationsFromCalculationOptions();
            SetDefaultDiagram(fsParameterIdentifier.u, fsParameterIdentifier.FilterArea, fsParameterIdentifier.SpecificFiltrationTime);
            Recalculate();
            UpdateUIFromData();
            ConnectUIWithDataUpdating(materialParametersDataGrid, dataGrid, calculationComboBox);
        }

        #region Routine Methods

        private void CreateStandardGourps()
        {
            Groups.Clear();
            AddGroupsToUI(materialParametersDataGrid, MakeMaterialGroups());
            AddGroupsToUI(dataGrid, MakeMachiningStandardGroups());
        }

        private void CreateDesignGroups()
        {
            Groups.Clear();
            AddGroupsToUI(materialParametersDataGrid, MakeMaterialGroups());
            AddGroupsToUI(dataGrid, MakeMachiningDesignGroups());
        }

        private fsParametersGroup[] MakeMaterialGroups()
        {
            fsParametersGroup etafGroup = AddGroup(
                fsParameterIdentifier.MotherLiquidViscosity);

            fsParametersGroup rhofGroup = AddGroup(
                fsParameterIdentifier.MotherLiquidDensity);

            fsParametersGroup densitiesGroup = AddGroup(
                fsParameterIdentifier.SolidsDensity,
                fsParameterIdentifier.SuspensionDensity);

            fsParametersGroup cGroup = AddGroup(
                fsParameterIdentifier.SuspensionSolidsMassFraction,
                fsParameterIdentifier.SuspensionSolidsVolumeFraction,
                fsParameterIdentifier.SuspensionSolidsConcentration);

            fsParametersGroup neGroup = AddGroup(
                fsParameterIdentifier.Ne);

            fsParametersGroup epsGroup = AddGroup(
                fsParameterIdentifier.CakePorosity0,
                fsParameterIdentifier.Kappa0,
                fsParameterIdentifier.DryCakeDensity0,
                fsParameterIdentifier.CakeWetDensity0,
                fsParameterIdentifier.CakeWetMassSolidsFractionRs0,
                fsParameterIdentifier.CakeMoistureContentRf0,
                fsParameterIdentifier.CakePorosity,
                fsParameterIdentifier.Kappa,
                fsParameterIdentifier.DryCakeDensity,
                fsParameterIdentifier.CakeWetDensity,
                fsParameterIdentifier.CakeWetMassSolidsFractionRs,
                fsParameterIdentifier.CakeMoistureContentRf);

            fsParametersGroup pcrcGroup = AddGroup(
                fsParameterIdentifier.CakePermeability0,
                fsParameterIdentifier.CakeResistance0,
                fsParameterIdentifier.CakeResistanceAlpha0);

            fsParametersGroup ncGroup = AddGroup(
                fsParameterIdentifier.CakeCompressibility);

            fsParametersGroup hce0Group = AddGroup(
                fsParameterIdentifier.FilterMediumResistanceHce0,
                fsParameterIdentifier.FilterMediumResistanceRm0);

            return new[]
                       {
                           etafGroup,
                           rhofGroup,
                           densitiesGroup,
                           cGroup,
                           neGroup,
                           epsGroup,
                           pcrcGroup,
                           ncGroup,
                           hce0Group,
                       };
        }

        private fsParametersGroup[] MakeMachiningStandardGroups()
        {
            fsParametersGroup AbGroup = AddGroup(
               fsParameterIdentifier.FilterArea,
               fsParameterIdentifier.MachineWidth);

            fsParametersGroup nsGroup = AddGroup(
                fsParameterIdentifier.ns);

            fsParametersGroup geometryGroup = AddGroup(
                fsParameterIdentifier.ls,
                fsParameterIdentifier.ls_over_b,
                fsParameterIdentifier.FilterLength,
                fsParameterIdentifier.l_over_b,
                fsParameterIdentifier.As);

            fsParametersGroup timeGroup = AddGroup(
                fsParameterIdentifier.StandardTechnicalTime,
                fsParameterIdentifier.TechnicalTime);

            fsParametersGroup dpGroup = AddGroup(
                fsParameterIdentifier.PressureDifference);

            fsParametersGroup specificTimeGroup = AddGroup(
                fsParameterIdentifier.nsf,
                fsParameterIdentifier.SpecificFiltrationTime,
                fsParameterIdentifier.nsr,
                fsParameterIdentifier.SpecificResidualTime,
                fsParameterIdentifier.ResidualTime);

            fsParametersGroup timeQGroup = AddGroup(
                fsParameterIdentifier.u,
                fsParameterIdentifier.RotationalSpeed,
                fsParameterIdentifier.CycleTime,
                fsParameterIdentifier.CakeHeight,
                fsParameterIdentifier.FiltrationTime,
                fsParameterIdentifier.qft,
                fsParameterIdentifier.qmft,
                fsParameterIdentifier.Qms,
                fsParameterIdentifier.Qsus,
                fsParameterIdentifier.SuspensionMassFlowrate);

            fsParametersGroup lambdaGroup = AddGroup(
                fsParameterIdentifier.lambda);

            fsParametersGroup resultsGroup = AddOnlyCalculatedGroup(
                fsParameterIdentifier.MeanHeightRate,
                fsParameterIdentifier.HcOverTc,
                fsParameterIdentifier.DiffHeightRate,
                fsParameterIdentifier.SolidsMass,
                fsParameterIdentifier.SuspensionMass,
                fsParameterIdentifier.SolidsVolume,
                fsParameterIdentifier.SuspensionVolume,
                fsParameterIdentifier.SpecificSuspensionMass,
                fsParameterIdentifier.SpecificSuspensionVolume,
                fsParameterIdentifier.Qmsust,
                fsParameterIdentifier.Qmsusd,
                fsParameterIdentifier.Qsust,
                fsParameterIdentifier.Qsusd,
                fsParameterIdentifier.qmsust,
                fsParameterIdentifier.qmsusd,
                fsParameterIdentifier.qsust,
                fsParameterIdentifier.qsusd);

            return new[]
                       {
                           AbGroup,
                           nsGroup,
                           geometryGroup,
                           timeGroup,
                           dpGroup,
                           specificTimeGroup,
                           timeQGroup,
                           lambdaGroup,
                           resultsGroup
                       };
        }

        private fsParametersGroup[] MakeMachiningDesignGroups()
        {
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
                fsParameterIdentifier.StandardTechnicalTime,
                fsParameterIdentifier.TechnicalTime);

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

            fsParametersGroup resultsGroup = AddOnlyCalculatedGroup(
                fsParameterIdentifier.FilterArea,
                fsParameterIdentifier.As,
                fsParameterIdentifier.MachineWidth,
                fsParameterIdentifier.FilterLength,
                fsParameterIdentifier.MeanHeightRate,
                fsParameterIdentifier.HcOverTc,
                fsParameterIdentifier.DiffHeightRate,
                fsParameterIdentifier.SolidsMass,
                fsParameterIdentifier.SuspensionMass,
                fsParameterIdentifier.SolidsVolume,
                fsParameterIdentifier.SuspensionVolume,
                fsParameterIdentifier.SpecificSuspensionMass,
                fsParameterIdentifier.SpecificSuspensionVolume,
                fsParameterIdentifier.Qmsust,
                fsParameterIdentifier.Qmsusd,
                fsParameterIdentifier.Qsust,
                fsParameterIdentifier.Qsusd,
                fsParameterIdentifier.qmsust,
                fsParameterIdentifier.qmsusd,
                fsParameterIdentifier.qsust,
                fsParameterIdentifier.qsusd);

            return new[]
                       {
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
        }

        protected override void UpdateGroupsInputInfoFromCalculationOptions()
        {
            var calculationOption = (fsCalculationOption)CalculationOptions[typeof(fsCalculationOption)]; 
            if (calculationOption == fsCalculationOption.FilterDesign)
            {
                CreateDesignGroups();
            }
            else
            {
                CreateStandardGourps();
            }
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

        private void MaterialParametersDisplayCheckBoxCheckedChanged(object sender, System.EventArgs e)
        {
            tablesSplitContainer.Panel1Collapsed = !materialParametersDisplayCheckBox.Checked;
        }
    }
}

