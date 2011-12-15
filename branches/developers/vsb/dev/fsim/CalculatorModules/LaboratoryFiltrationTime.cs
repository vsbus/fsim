using System.Drawing;
using Parameters;
using StepCalculators;

namespace CalculatorModules
{
    public sealed partial class fsLaboratoryFiltrationTime : fsOptionsOneTableAndCommentsCalculatorControl
    {
        public fsLaboratoryFiltrationTime()
        {
            InitializeComponent();

            Calculators.Add(new fsDensityConcentrationCalculator());
            Calculators.Add(new fsEps0Kappa0Calculator());
            Calculators.Add(new fsPc0Rc0Alpha0Calculator());
            Calculators.Add(new fsLaboratoryFiltrationCalculator());

            fsParametersGroup filtrateGroup = AddGroup(
                fsParameterIdentifier.FiltrateDensity);
            fsParametersGroup solidsGroup = AddGroup(
                fsParameterIdentifier.SolidsDensity,
                fsParameterIdentifier.SuspensionDensity);
            fsParametersGroup concentrationGroup = AddGroup(
                fsParameterIdentifier.SuspensionSolidsMassFraction,
                fsParameterIdentifier.SuspensionSolidsVolumeFraction,
                fsParameterIdentifier.SuspensionSolidsConcentration);
            fsParametersGroup epsKappaGroup = AddGroup(
                fsParameterIdentifier.CakePorosity0,
                fsParameterIdentifier.Kappa0);
            fsParametersGroup viscosityGroup = AddGroup(
                fsParameterIdentifier.FiltrateViscosity);
            fsParametersGroup pc0Rc0Alpha0Group = AddGroup(
                fsParameterIdentifier.CakePermeability0,
                fsParameterIdentifier.CakeResistance0,
                fsParameterIdentifier.CakeResistanceAlpha0);
            fsParametersGroup ncGroup = AddGroup(
                fsParameterIdentifier.CakeCompressibility);
            fsParametersGroup hceGroup = AddGroup(
                fsParameterIdentifier.Hce0);
            fsParametersGroup pressureGroup = AddGroup(
                fsParameterIdentifier.PressureDifference);
            fsParametersGroup areaGroup = AddGroup(
                fsParameterIdentifier.FilterArea);
            fsParametersGroup cakeFormationGroup = AddGroup(
                fsParameterIdentifier.CakeHeight,
                fsParameterIdentifier.FormationTime,
                fsParameterIdentifier.SuspensionMass);
            fsParametersGroup resultsGroup = AddGroup(
                fsParameterIdentifier.SolidsMass,
                fsParameterIdentifier.LiquidMass);


            var groups = new[]
                             {
                                 filtrateGroup,
                                 solidsGroup,
                                 concentrationGroup,
                                 epsKappaGroup,
                                 viscosityGroup,
                                 pc0Rc0Alpha0Group,
                                 ncGroup,
                                 hceGroup,
                                 pressureGroup,
                                 areaGroup,
                                 cakeFormationGroup,
                                 resultsGroup
                             };

            var colors = new[]
                             {
                                 Color.FromArgb(255, 255, 230),
                                 Color.FromArgb(255, 230, 255)
                             };

            for (int i = 0; i < groups.Length; ++i)
            {
                groups[i].IsInput = true;
                AddGroupToUI(dataGrid, groups[i], colors[i % colors.Length]);
            }
            resultsGroup.IsInput = false;
            ParameterToCell[fsParameterIdentifier.SolidsMass].ReadOnly = true;
            ParameterToCell[fsParameterIdentifier.LiquidMass].ReadOnly = true;

            UpdateGroupsInputInfoFromCalculationOptions();
            UpdateEquationsFromCalculationOptions();
            Recalculate();
            UpdateUIFromData();
            ConnectUIWithDataUpdating(dataGrid);
        }

        protected override void UpdateEquationsFromCalculationOptions()
        {
            // this control has only one equation
        }

        protected override void UpdateGroupsInputInfoFromCalculationOptions()
        {
            // this control hasn't calculation options
        }
    }
}