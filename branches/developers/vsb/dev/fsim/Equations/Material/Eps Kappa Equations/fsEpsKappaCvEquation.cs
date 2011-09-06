using System;
using System.Collections.Generic;
using System.Text;
using Parameters;

namespace Equations
{
    public class fsEpsKappaCvEquation : fsCalculatorEquation
    {
        #region Parameters

        protected fsIEquationParameter Porosity;
        protected fsIEquationParameter Kappa;
        protected fsIEquationParameter VolumeConcentration;

        #endregion

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
            AddFormula(Porosity, PorosityFormula);
            AddFormula(Kappa, KappaFormula);
        }

        #region Formulas

        private void KappaFormula()
        {
            Kappa.Value = VolumeConcentration.Value / (1 - Porosity.Value - VolumeConcentration.Value);
        }

        private void PorosityFormula()
        {
            Porosity.Value = 1 - VolumeConcentration.Value * (Kappa.Value + 1) / Kappa.Value;
        }

        #endregion
    }
}
