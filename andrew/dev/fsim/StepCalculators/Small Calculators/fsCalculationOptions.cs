﻿using System.ComponentModel;

namespace StepCalculators
{
    public class fsCalculationOptions
    {
        public enum fsDeliquoringModeOption
        {
            [Description("Analysis Mode")]
            AnalysisModeCalculations,
            [Description("Simulation Mode")]
            SimulationModeCalculations
        }

        public enum fsFormationModeOption
        {
            [Description("Analysis Mode")]
            AnalysisModeCalculations,
            [Description("Simulation Mode")]
            SimulationModeCalculations,
            [Description("Hidden")]
            HiddenModeCalculations
        }

        public enum fsGasModeOption
        {
            [Description("Analysis Mode")]
            AnalysisModeCalculations,
            [Description("Simulation Mode")]
            SimulationModeCalculations,
            [Description("Hidden")]
            HiddenModeCalculations
        }

        public enum fsFiltersKindOption
        {
            [Description("Batch Filters")]
            BatchFilterCalculations,
            [Description("Continuous Filters")]
            ContinuousFilterCalculations
        }

        public enum fsSimulationsOption
        {
            [Description("Default")]
            DefaultSimulationsCalculations,
            [Description("Medium Resistance considered")]
            MediumResistanceSimulationsCalculations,
            [Description("Medium Resistance and cake compressibility considered")]
            MediumResistanceAndCakeCompressibilitySimulationsCalculations,
            [Description("Show also ne")]
            ShowAlsoNeSimulationsCalculations
        }

        public enum fsSaltContentOption
        {
            [Description("Neglected")]
            Neglected,
            [Description("Considered")]
            Considered
        }

        public enum fsConcentrationOption
        {
            [Description("Mass fraction Cm_sol (%)")]
            SolidsMassFraction,
            [Description("Concentration C_sol (g/l)")]
            Concentration
        }

        public enum fsFromCalculationOption
        {
            [Description("Cake Wash Out Content X")]
            WashOutContent,
            [Description("pH")]
            Ph
        }

        public enum fsWashOutContentOption
        {
            [Description("Concentration Cw(g/l)")]
            AsConcentration,
            [Description("Mass Fraction Cwm(%)")]
            AsMassFraction
        }

        public enum fsCakeInputOption
        {
            [Description("Permeability Pc")]
            PermeabilityPc,
            [Description("Resistance rc")]
            ResistanceRc,
            [Description("Resistance alpha")]
            ResistanceAlpha
        }

        public enum fsEnterSolidsDensity
        {
            [Description("Density Dry Cake")]
            BulkDensityDrySolids,
            [Description("Solids Density and Cake Porosity")]
            SolidsDensityAndCakePorosity
        }
    }
}
