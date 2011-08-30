using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;
using Value;

namespace StepCalculators
{
    public class fsVolumeConcentrationEquation : fsBaseConcentrationEquation
    {
        private fsCalculatorParameter VolumeConcentration;

        public fsVolumeConcentrationEquation(
            fsCalculatorParameter VolumeConcentration,
            fsCalculatorParameter FiltrateDensity,
            fsCalculatorParameter SolidsDensity,
            fsCalculatorParameter SuspensionDensity)
            : base(
                FiltrateDensity,
                SolidsDensity,
                SuspensionDensity)
        {
            this.VolumeConcentration = VolumeConcentration;

            Result = VolumeConcentration;
        }

        public override void Calculate()
        {
            fsValue rho_f = FiltrateDensity.Value;
            VolumeConcentration.Value = (rho_f - SuspensionDensity.Value) / (rho_f - SolidsDensity.Value);
            base.Calculate();
        }
    }
}
