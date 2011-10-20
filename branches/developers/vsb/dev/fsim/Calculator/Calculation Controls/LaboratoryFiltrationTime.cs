using System.Drawing;
using Parameters;
using StepCalculators;

namespace Calculator.Calculation_Controls
{
    public sealed partial class fsLaboratoryFiltrationTime : fsCalculatorControl
    {
        public fsLaboratoryFiltrationTime()
        {
            InitializeComponent();

            Calculators.Add(new fsDensityConcentrationCalculator());
            Calculators.Add(new fsEps0Kappa0Calculator());
            Calculators.Add(new fsPc0Rc0Alpha0Calculator());
            Calculators.Add(new fsLaboratoryFiltrationCalculator());

            var filtrateGroup = AddGroup(
                fsParameterIdentifier.FiltrateDensity);
            var solidsGroup = AddGroup(
                fsParameterIdentifier.SolidsDensity,
                fsParameterIdentifier.SuspensionDensity);
            var concentrationGroup = AddGroup(
                fsParameterIdentifier.SolidsMassFraction,
                fsParameterIdentifier.SolidsVolumeFraction,
                fsParameterIdentifier.SolidsConcentration);
            var epsKappaGroup = AddGroup(
                fsParameterIdentifier.Porosity0,
                fsParameterIdentifier.Kappa0);
            var viscosityGroup = AddGroup(
                fsParameterIdentifier.FiltrateViscosity);
            var pc0Rc0Alpha0Group = AddGroup(
                fsParameterIdentifier.Pc0,
                fsParameterIdentifier.Rc0,
                fsParameterIdentifier.Alpha0);
            var ncGroup = AddGroup(
                fsParameterIdentifier.CakeCompressibility);
            var hceGroup = AddGroup(
                fsParameterIdentifier.Hce0);
            var pressureGroup = AddGroup(
                fsParameterIdentifier.Pressure);
            var areaGroup = AddGroup(
                fsParameterIdentifier.FilterArea);
            var cakeFormationGroup = AddGroup(
                fsParameterIdentifier.CakeHeight,
                fsParameterIdentifier.FormationTime,
                fsParameterIdentifier.SuspensionMass);
            var resultsGroup = AddGroup(
                fsParameterIdentifier.SolidsMass,
                fsParameterIdentifier.LiquidMass);


            var groups = new[] {
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

            var colors = new[] {
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

