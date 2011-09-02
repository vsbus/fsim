using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;
using Value;

namespace Equations
{
    public class fsDivisionInverseEquation : fsCalculatorEquation
    {
        // first * second = 1

        private fsIEquationParameter first;
        private fsIEquationParameter second;

        public fsDivisionInverseEquation(
            fsIEquationParameter first,
            fsIEquationParameter second)
            : base(first, second)
        {
            this.first = first;
            this.second = second;
        }

        protected override void InitFormulas()
        {
            AddFormula(first, CalculateFirst);
            AddFormula(second, CalculateSecond);
        }

        private void CalculateFirst()
        {
            first.Value = 1 / second.Value;
        }

        private void CalculateSecond()
        {
            second.Value = 1 / first.Value;
        }
    }
}
