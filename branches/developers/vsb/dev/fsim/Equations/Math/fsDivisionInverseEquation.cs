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
        private fsIEquationParameter result;
        private fsIEquationParameter denominator;

        public fsDivisionInverseEquation(
            fsIEquationParameter result,
            fsIEquationParameter denominator)
            : base(result, denominator)
        {
            this.result = result;
            this.denominator = denominator;
        
            Result = result;
        }

        public override void Calculate()
        {
            result.Value = fsValue.One / denominator.Value;
            base.Calculate();
        }
    }
}
