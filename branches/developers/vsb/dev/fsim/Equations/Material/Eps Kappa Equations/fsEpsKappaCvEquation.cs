using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;

namespace StepCalculators
{
    public abstract class fsEpsKappaCvEquation : fsCalculatorEquation
    {
        protected fsIEquationParameter Porosity;
        protected fsIEquationParameter Kappa;
        protected fsIEquationParameter VolumeConcentration;

        public fsEpsKappaCvEquation(
            fsIEquationParameter Porosity,
            fsIEquationParameter Kappa,
            fsIEquationParameter VolumeConcentration)
            : base(
                Porosity, 
                Kappa, 
                VolumeConcentration)
        {
            this.Porosity = Porosity;
            this.Kappa = Kappa;
            this.VolumeConcentration = VolumeConcentration;
        }
    }
}
