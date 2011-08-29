using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;
using Value;

namespace StepCalculators
{
    public class fsMassConcentrationEquation : fsBaseConcentrationEquation
    {
        private fsCalculatorParameter MassConcentration;

        public fsMassConcentrationEquation(
            fsCalculatorParameter MassConcentration,
            fsCalculatorParameter FiltrateDensity,
            fsCalculatorParameter SolidsDensity,
            fsCalculatorParameter SuspensionDensity) 
            : base(
                FiltrateDensity, 
                SolidsDensity, 
                SuspensionDensity)
        {
            this.MassConcentration = MassConcentration;

            Result = MassConcentration;
        }

        public override void Calculate()
        {
            fsValue rho_s = SolidsDensity.Value;
            fsValue rho_f = FiltrateDensity.Value;
            fsValue rho_sus = SuspensionDensity.Value;
            MassConcentration.Value = rho_s * (rho_f - rho_sus) / rho_sus / (rho_f - rho_s);
            base.Calculate();
        }
    }
}
