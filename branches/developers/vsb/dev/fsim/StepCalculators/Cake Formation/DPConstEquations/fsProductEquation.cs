using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;

namespace StepCalculators
{
    public class fsProductEquation : fsCalculatorEquation
    {
        private fsCalculatorParameter product;
        private fsCalculatorParameter firstFactor;
        private fsCalculatorParameter secondFactor;

        public fsProductEquation(
            fsCalculatorParameter product,
            fsCalculatorParameter firstFactor,
            fsCalculatorParameter secondFactor)
        {
            this.product = product;
            this.firstFactor = firstFactor;
            this.secondFactor = secondFactor;

            Result = product;
            Inputs.Add(firstFactor);
            Inputs.Add(secondFactor);
        }

        public override void Calculate()
        {
            product.Value = firstFactor.Value * secondFactor.Value;
            base.Calculate();
        }
    }
}
