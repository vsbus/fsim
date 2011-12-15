﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace StepCalculators
{
    public class fsCalculationOptions
    {
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
            [Description("Wash Out Content")]
            WashOutContent,
            [Description("pH")]
            Ph
        }

        public enum fsWashOutContentOption
        {
            [Description("As Concentration Cw(g/l)")]
            AsConcentration,
            [Description("As Mass Fraction Cwm(%)")]
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
