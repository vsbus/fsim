using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;

namespace StepCalculators
{
    public class fsKappaFromEpsCvEquation : fsEpsKappaCvEquation
    {
        public fsKappaFromEpsCvEquation(
            fsCalculatorParameter Kappa,
            fsCalculatorParameter Porosity,
            fsCalculatorConstant VolumeConcentration)
            : base(Porosity, Kappa, VolumeConcentration)
        {
            Result = Kappa;
            Inputs.Add(Porosity);
        }

        public override void Calculate()
        {
            Kappa.Value = VolumeConcentration.Value / (1 - Porosity.Value - VolumeConcentration.Value);
            base.Calculate();
        }
    }
}
