using System;
using System.Collections.Generic;
using System.Text;
using Parameters;
using Value;

namespace Equations
{
    public class fsDivisionInverseEquation : fsCalculatorEquation
    {
        // first * second = 1

        #region Parameters

        private IEquationParameter first;
        private IEquationParameter second;

        #endregion

        public fsDivisionInverseEquation(
            IEquationParameter first,
            IEquationParameter second)
            : base(first, second)
        {
            this.first = first;
            this.second = second;
        }

        protected override void InitFormulas()
        {
            AddFormula(first, FirstFormula);
            AddFormula(second, SecondFormula);
        }

        #region Formulas

        private void FirstFormula()
        {
            first.Value = 1 / second.Value;
        }

        private void SecondFormula()
        {
            second.Value = 1 / first.Value;
        }

        #endregion
    }
}
