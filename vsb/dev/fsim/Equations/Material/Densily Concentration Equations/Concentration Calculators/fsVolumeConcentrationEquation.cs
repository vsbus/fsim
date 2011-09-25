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

        private IEquationParameter SolidsVolumeFractionConcentration;
        private IEquationParameter FiltrateDensity;
        private IEquationParameter SolidsDensity;
        private IEquationParameter SuspensionDensity;

        #endregion

        public fsVolumeConcentrationEquation(
            IEquationParameter SolidsVolumeFractionConcentration,
            IEquationParameter FiltrateDensity,
            IEquationParameter SolidsDensity,
            IEquationParameter SuspensionDensity)
            : base(
                SolidsVolumeFractionConcentration,
                FiltrateDensity, 
                SolidsDensity, 
                SuspensionDensity)
        {
            this.SolidsVolumeFractionConcentration = SolidsVolumeFractionConcentration;
            this.FiltrateDensity = FiltrateDensity;
            this.SolidsDensity = SolidsDensity;
            this.SuspensionDensity = SuspensionDensity;
        }

        protected override void InitFormulas()
        {
            AddFormula(SolidsVolumeFractionConcentration, SolidsVolumeFractionFormula);
            AddFormula(FiltrateDensity, FiltrateDensityFormula);
            AddFormula(SolidsDensity, SolidsDensityFormula);
            AddFormula(SuspensionDensity, SuspensionDensityFormula);
        }

        #region Formulas

        private void SolidsVolumeFractionFormula()
        {
            fsValue rhoF = FiltrateDensity.Value;
            fsValue rhoS = SolidsDensity.Value;
            fsValue rhoSus = SuspensionDensity.Value;
            SolidsVolumeFractionConcentration.Value = (rhoF - rhoSus) / (rhoF - rhoS);
        }

        private void FiltrateDensityFormula()
        {
            fsValue Cv = SolidsVolumeFractionConcentration.Value;
            fsValue rhoS = SolidsDensity.Value;
            fsValue rhoSus = SuspensionDensity.Value;
            FiltrateDensity.Value = (rhoSus - Cv * rhoS) / (1 - Cv);
        }

        private void SolidsDensityFormula()
        {
            fsValue Cv = SolidsVolumeFractionConcentration.Value;
            fsValue rhoF = FiltrateDensity.Value;
            fsValue rhoSus = SuspensionDensity.Value;
            SolidsDensity.Value = (rhoSus - (1 - Cv) * rhoF) / Cv;
        }

        private void SuspensionDensityFormula()
        {
            fsValue Cv = SolidsVolumeFractionConcentration.Value;
            fsValue rhoF = FiltrateDensity.Value;
            fsValue rhoS = SolidsDensity.Value;
            SuspensionDensity.Value = rhoF * (1 - Cv) + Cv * rhoS;
        }

        #endregion
    }
}
