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

        private IEquationParameter VolumeConcentration;
        private IEquationParameter FiltrateDensity;
        private IEquationParameter SolidsDensity;
        private IEquationParameter SuspensionDensity;

        #endregion

        public fsVolumeConcentrationEquation(
            IEquationParameter VolumeConcentration,
            IEquationParameter FiltrateDensity,
            IEquationParameter SolidsDensity,
            IEquationParameter SuspensionDensity)
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
