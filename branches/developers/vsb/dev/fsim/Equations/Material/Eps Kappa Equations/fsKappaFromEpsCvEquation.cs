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
            fsIEquationParameter Kappa,
            fsIEquationParameter Porosity,
            fsIEquationParameter VolumeConcentration)
            : base(
                Porosity, 
                Kappa, 
                VolumeConcentration)
        {
            Result = Kappa;
        }

        public override void Calculate()
        {
            Kappa.Value = VolumeConcentration.Value / (1 - Porosity.Value - VolumeConcentration.Value);
            base.Calculate();
        }
    }
}
