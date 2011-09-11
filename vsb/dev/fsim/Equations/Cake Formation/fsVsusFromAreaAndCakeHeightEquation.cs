using System;
using System.Collections.Generic;
using System.Text;
using Parameters;

namespace Equations
{
    public class fsVsusFromAreaAndCakeHeightEquation : fsCalculatorEquation
    {
        #region Parameters

        private IEquationParameter SuspensionVolume;
        private IEquationParameter Area;
        private IEquationParameter CakeHeight;
        private IEquationParameter kappa;

        #endregion

        public fsVsusFromAreaAndCakeHeightEquation(
            IEquationParameter SuspensionVolume,
            IEquationParameter Area,
            IEquationParameter CakeHeight,
            IEquationParameter kappa)
            : base(
                SuspensionVolume, 
                Area, 
                CakeHeight, 
                kappa)
        {
            this.SuspensionVolume = SuspensionVolume;
            this.Area = Area;
            this.CakeHeight = CakeHeight;
            this.kappa = kappa;
        }

        protected override void InitFormulas()
        {
            AddFormula(SuspensionVolume, SuspensionVolumeFormula);
        }

        #region Formulas

        private void SuspensionVolumeFormula()
        {
            SuspensionVolume.Value = Area.Value * CakeHeight.Value * (1 + kappa.Value) / kappa.Value;
        }

        #endregion
    }
}