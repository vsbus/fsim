using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;

namespace StepCalculators
{
    public class fsBaseConcentrationEquation : fsCalculatorEquation
    {
        protected fsCalculatorParameter FiltrateDensity;
        protected fsCalculatorParameter SolidsDensity;
        protected fsCalculatorParameter SuspensionDensity;

        public fsBaseConcentrationEquation(
            fsCalculatorParameter FiltrateDensity,
            fsCalculatorParameter SolidsDensity,
            fsCalculatorParameter SuspensionDensity)
        {
            this.FiltrateDensity = FiltrateDensity;
            this.SolidsDensity = SolidsDensity;
            this.SuspensionDensity = SuspensionDensity;

            Inputs.Add(FiltrateDensity);
            Inputs.Add(SolidsDensity);
            Inputs.Add(SuspensionDensity);
        }
    }
}
