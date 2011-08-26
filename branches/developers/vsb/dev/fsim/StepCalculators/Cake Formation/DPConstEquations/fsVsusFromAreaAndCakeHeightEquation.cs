using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;

namespace StepCalculators
{
    public class fsVsusFromAreaAndCakeHeightEquation : fsCalculatorEquation
    {
        private fsCalculatorParameter SuspensionVolume;
        private fsCalculatorParameter Area;
        private fsCalculatorParameter CakeHeight;
        private fsCalculatorParameter kappa;

        public fsVsusFromAreaAndCakeHeightEquation(
            fsCalculatorParameter Vsus,
            fsCalculatorParameter Area,
            fsCalculatorParameter CakeHeight,
            fsCalculatorParameter kappa)
        {
            this.SuspensionVolume = Vsus;
            this.Area = Area;
            this.CakeHeight = CakeHeight;
            this.kappa = kappa;

            Result = Vsus;
            Inputs.Add(Area);
            Inputs.Add(CakeHeight);
            Inputs.Add(kappa);
        }

        public override void Calculate()
        {
            SuspensionVolume.Value = Area.Value * CakeHeight.Value * (1 + kappa.Value) / kappa.Value;
            base.Calculate();
        }
    }
}