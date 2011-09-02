using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;
using Value;

namespace Equations
{
    public class fsMassConcentrationEquation : fsCalculatorEquation
    {
        private fsIEquationParameter MassConcentration;
        private fsIEquationParameter FiltrateDensity;
        private fsIEquationParameter SolidsDensity;
        private fsIEquationParameter SuspensionDensity;

        public fsMassConcentrationEquation(
            fsIEquationParameter MassConcentration,
            fsIEquationParameter FiltrateDensity,
            fsIEquationParameter SolidsDensity,
            fsIEquationParameter SuspensionDensity) 
            : base(
                MassConcentration,
                FiltrateDensity, 
                SolidsDensity, 
                SuspensionDensity)
        {
            this.MassConcentration = MassConcentration;
            this.FiltrateDensity = FiltrateDensity;
            this.SolidsDensity = SolidsDensity;
            this.SuspensionDensity = SuspensionDensity;
        }

        protected override void InitFormulas()
        {
            AddFormula(MassConcentration, CalculateMassConcentration);
        }
        
        private void CalculateMassConcentration()
        {
            fsValue rho_s = SolidsDensity.Value;
            fsValue rho_f = FiltrateDensity.Value;
            fsValue rho_sus = SuspensionDensity.Value;
            MassConcentration.Value = rho_s * (rho_f - rho_sus) / rho_sus / (rho_f - rho_s);
        }
    }
}
