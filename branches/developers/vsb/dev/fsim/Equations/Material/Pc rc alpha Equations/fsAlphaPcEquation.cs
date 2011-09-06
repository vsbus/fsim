using System;
using System.Collections.Generic;
using System.Text;
using Parameters;

namespace Equations
{
    public class fsAlphaPcEquation : fsCalculatorEquation
    {
       #region Parameters

        protected fsIEquationParameter alpha;
        protected fsIEquationParameter Pc;
        protected fsIEquationParameter eps;
        protected fsIEquationParameter rho_s;

        #endregion

        public fsAlphaPcEquation(
            fsIEquationParameter alpha,
            fsIEquationParameter Pc,
            fsIEquationParameter eps,
            fsIEquationParameter rho_s)
            : base(
                alpha,
                Pc,
                eps,
                rho_s)
        {          
            this.alpha = alpha;
            this.Pc = Pc;
            this.eps = eps;
            this.rho_s = rho_s;
        }

        protected override void InitFormulas()
        {
            AddFormula(alpha, AlphaFormula);
            AddFormula(Pc, PcFormula);
        }

        #region Formulas

        private void AlphaFormula()
        {
            alpha.Value = 1 / (Pc.Value * (1 - eps.Value) * rho_s.Value);
        }

        private void PcFormula()
        {
            Pc.Value = 1 / (alpha.Value * (1 - eps.Value) * rho_s.Value);
        }

        #endregion
    }
}
