using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;
using Value;

namespace Equations
{
    public class fsVolumeConcentrationEquation : fsCalculatorEquation
    {
        private fsIEquationParameter VolumeConcentration;
        private fsIEquationParameter FiltrateDensity;
        private fsIEquationParameter SolidsDensity;
        private fsIEquationParameter SuspensionDensity;

        public fsVolumeConcentrationEquation(
            fsIEquationParameter VolumeConcentration,
            fsIEquationParameter FiltrateDensity,
            fsIEquationParameter SolidsDensity,
            fsIEquationParameter SuspensionDensity)
            : base(
                VolumeConcentration,
                FiltrateDensity, 
                SolidsDensity, 
                SuspensionDensity)
        {
            this.VolumeConcentration = VolumeConcentration;
            this.FiltrateDensity = FiltrateDensity;
            this.SolidsDensity = SolidsDensity;
            this.SuspensionDensity = SuspensionDensity;
        }

        protected override void InitFormulas()
        {
            AddFormula(VolumeConcentration, CalculateVolumeConcentration);
        }

        private void CalculateVolumeConcentration()
        {
            fsValue rho_f = FiltrateDensity.Value;
            VolumeConcentration.Value = (rho_f - SuspensionDensity.Value) / (rho_f - SolidsDensity.Value);
        }
    }
}
