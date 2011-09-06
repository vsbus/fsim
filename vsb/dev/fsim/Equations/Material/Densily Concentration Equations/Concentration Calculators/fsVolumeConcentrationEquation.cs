using System;
using System.Collections.Generic;
using System.Text;
using Parameters;
using Value;

namespace Equations
{
    public class fsVolumeConcentrationEquation : fsCalculatorEquation
    {
        #region Parameters

        private fsIEquationParameter VolumeConcentration;
        private fsIEquationParameter FiltrateDensity;
        private fsIEquationParameter SolidsDensity;
        private fsIEquationParameter SuspensionDensity;

        #endregion

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
            AddFormula(VolumeConcentration, VolumeConcentrationFormula);
        }

        #region Formulas

        private void VolumeConcentrationFormula()
        {
            fsValue rho_f = FiltrateDensity.Value;
            VolumeConcentration.Value = (rho_f - SuspensionDensity.Value) / (rho_f - SolidsDensity.Value);
        }

        #endregion
    }
}
