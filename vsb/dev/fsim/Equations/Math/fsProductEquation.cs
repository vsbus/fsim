using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;

namespace Equations
{
    public class fsProductEquation : fsCalculatorEquation
    {
        // product = firstFactor * secondFactor

        private fsIEquationParameter product;
        private fsIEquationParameter firstFactor;
        private fsIEquationParameter secondFactor;

        public fsProductEquation(
            fsIEquationParameter product,
            fsIEquationParameter firstFactor,
            fsIEquationParameter secondFactor)
            : base (product, firstFactor, secondFactor)
        {
            this.product = product;
            this.firstFactor = firstFactor;
            this.secondFactor = secondFactor;
        }

        protected override void InitFormulas()
        {
            AddFormula(product, CalculateProduct);
            AddFormula(firstFactor, CalculateFirstFactor);
            AddFormula(secondFactor, CalculateSecondFactor);
        }
       
        private void CalculateSecondFactor()
        {
            firstFactor.Value = product.Value / secondFactor.Value;
        }

        private void CalculateFirstFactor()
        {
            secondFactor.Value = product.Value / firstFactor.Value;
        }

        private void CalculateProduct()
        {
            product.Value = firstFactor.Value * secondFactor.Value;
        }
    }
}
