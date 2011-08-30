using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;

namespace StepCalculators
{
    public class fsEpsKappaCvEquation : fsCalculatorEquation
    {
        protected fsCalculatorParameter Porosity;
        protected fsCalculatorParameter Kappa;
        protected fsCalculatorConstant VolumeConcentration;

        public fsEpsKappaCvEquation(
            fsCalculatorParameter Porosity,
            fsCalculatorParameter Kappa,
            fsCalculatorConstant VolumeConcentration)
        {
            this.Porosity = Porosity;
            this.Kappa = Kappa;
            this.VolumeConcentration = VolumeConcentration;
        }
    }
}
