using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;

namespace Equations
{
    public class fsVsusFromAreaAndCakeHeightEquation : fsCalculatorEquation
    {
        private fsIEquationParameter SuspensionVolume;
        private fsIEquationParameter Area;
        private fsIEquationParameter CakeHeight;
        private fsIEquationParameter kappa;

        public fsVsusFromAreaAndCakeHeightEquation(
            fsIEquationParameter SuspensionVolume,
            fsIEquationParameter Area,
            fsIEquationParameter CakeHeight,
            fsIEquationParameter kappa)
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
            AddFormula(SuspensionVolume, CalculateSuspensionVolume);
        }
        
        private void CalculateSuspensionVolume()
        {
            SuspensionVolume.Value = Area.Value * CakeHeight.Value * (1 + kappa.Value) / kappa.Value;
            base.Calculate();
        }
    }
}