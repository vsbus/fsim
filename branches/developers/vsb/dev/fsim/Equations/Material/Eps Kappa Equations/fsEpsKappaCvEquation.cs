using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;

namespace Equations
{
    public class fsEpsKappaCvEquation : fsCalculatorEquation
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

        protected override void InitFormulas()
        {
            AddFormula(Porosity, CalculatePorosity);
            AddFormula(Kappa, CalculateKappa);
        }

        private void CalculateKappa()
        {
            Kappa.Value = VolumeConcentration.Value / (1 - Porosity.Value - VolumeConcentration.Value);
        }

        private void CalculatePorosity()
        {
            Porosity.Value = 1 - VolumeConcentration.Value * (Kappa.Value + 1) / Kappa.Value;
        }
    }
}
