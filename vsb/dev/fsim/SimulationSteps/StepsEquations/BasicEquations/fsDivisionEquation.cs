using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Value;
using Parameters;

namespace SimulationSteps.StepsEquations.BasicEquations
{
    public class fsDivisionEquation : fsOneOperationEquation
    {
        public fsDivisionEquation(
            fsStepParameter result,
            fsStepParameter leftValue,
            fsStepParameter rightValue)
            : base(result, leftValue, rightValue) { }

        protected override fsValue Operation(fsValue leftValue, fsValue rightValue)
        {
            return leftValue / rightValue;
        }
    }
}
