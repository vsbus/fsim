using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;

namespace StepCalculators
{
    public class fsProductEquation : fsCalculatorEquation
    {
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
        
            Result = product;
        }

        public override void Calculate()
        {
            product.Value = firstFactor.Value * secondFactor.Value;
            base.Calculate();
        }
    }
}
