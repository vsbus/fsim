using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;
using Value;

namespace StepCalculators
{
    public class fsDivisionInverseEquation : fsCalculatorEquation
    {
        private fsCalculatorParameter result;
        private fsCalculatorParameter denominator;

        public fsDivisionInverseEquation(
            fsCalculatorParameter result,
            fsCalculatorParameter denominator)
        {
            this.result = result;
            this.denominator = denominator;

            Result = result;
            Inputs.Add(denominator);
        }

        public override void Calculate()
        {
            result.Value = fsValue.One / denominator.Value;
            base.Calculate();
        }
    }
}
