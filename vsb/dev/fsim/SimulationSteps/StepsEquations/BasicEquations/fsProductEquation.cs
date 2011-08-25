using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;

namespace SimulationSteps.StepsEquations.BasicEquations
{
    public class fsProductEquation : fsOneOperationEquation
    {
        public fsProductEquation(
            fsStepParameter result,
            fsStepParameter leftValue,
            fsStepParameter rightValue)
            : base(result, leftValue, rightValue) { }

        protected override Value.fsValue Operation(Value.fsValue leftValue, Value.fsValue rightValue)
        {
            double s = 0;
            for (int i = 0; i < 1000000; ++i)
            {
                s += Math.Pow(i, 0.5);
            }
            return leftValue * rightValue;
        }
    }
}
