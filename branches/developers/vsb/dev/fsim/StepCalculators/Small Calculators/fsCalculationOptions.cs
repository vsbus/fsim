using System;
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
            [Description("Mass fraction Cm (%)")]
            SolidsMassFraction,
            [Description("Concentration C (g/l)")]
            Concentration
        }
    }
}
