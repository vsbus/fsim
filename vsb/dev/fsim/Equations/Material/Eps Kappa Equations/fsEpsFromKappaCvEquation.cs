using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;

namespace StepCalculators
{
    public class fsEpsFromKappaCvEquation : fsEpsKappaCvEquation
    {
        public fsEpsFromKappaCvEquation(
            fsCalculatorParameter Porosity,
            fsCalculatorParameter Kappa,
            fsCalculatorConstant VolumeConcentration)
            : base(Porosity, Kappa, VolumeConcentration)
        {
            Result = Porosity;
            Inputs.Add(Kappa);
        }

        public override void Calculate()
        {
            Porosity.Value = 1 - VolumeConcentration.Value * (Kappa.Value + 1) / Kappa.Value;
            base.Calculate();
        }
    }
}
