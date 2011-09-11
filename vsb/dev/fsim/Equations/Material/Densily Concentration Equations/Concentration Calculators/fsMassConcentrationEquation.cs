using System;
using System.Collections.Generic;
using System.Text;
using Parameters;
using Value;

namespace Equations
{
    public class fsMassConcentrationEquation : fsCalculatorEquation
    {
        #region Parameters

        private IEquationParameter MassConcentration;
        private IEquationParameter FiltrateDensity;
        private IEquationParameter SolidsDensity;
        private IEquationParameter SuspensionDensity;

        #endregion

        public fsMassConcentrationEquation(
            IEquationParameter MassConcentration,
            IEquationParameter FiltrateDensity,
            IEquationParameter SolidsDensity,
            IEquationParameter SuspensionDensity) 
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
            AddFormula(MassConcentration, MassConcentrationFormula);
        }

        #region Formulas

        private void MassConcentrationFormula()
        {
            fsValue rho_s = SolidsDensity.Value;
            fsValue rho_f = FiltrateDensity.Value;
            fsValue rho_sus = SuspensionDensity.Value;
            MassConcentration.Value = rho_s * (rho_f - rho_sus) / rho_sus / (rho_f - rho_s);
        }

        #endregion
    }
}
