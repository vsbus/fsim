using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;
using Value;

namespace Equations
{
    public class fsConcentrationEquation : fsCalculatorEquation
    {
        #region Parameters

        private fsIEquationParameter Concentration;
        private fsIEquationParameter FiltrateDensity;
        private fsIEquationParameter SolidsDensity;
        private fsIEquationParameter SuspensionDensity;

        #endregion

        public fsConcentrationEquation(
            fsIEquationParameter Concentration,
            fsIEquationParameter FiltrateDensity,
            fsIEquationParameter SolidsDensity,
            fsIEquationParameter SuspensionDensity)
            : base(
                Concentration,
                FiltrateDensity,
                SolidsDensity,
                SuspensionDensity)
        {
            this.Concentration = Concentration;
            this.FiltrateDensity = FiltrateDensity;
            this.SolidsDensity = SolidsDensity;
            this.SuspensionDensity = SuspensionDensity;
        }

        protected override void InitFormulas()
        {
            AddFormula(Concentration, ConcentrationFormula);
        }

        #region Formulas

        private void ConcentrationFormula()
        {
            fsValue rho_s = SolidsDensity.Value;
            fsValue rho_f = FiltrateDensity.Value;
            fsValue rho_sus = SuspensionDensity.Value;
            Concentration.Value = rho_s * (rho_f - rho_sus) / (rho_f - rho_s); ;
        }

        #endregion
    }
}
