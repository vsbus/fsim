using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;
using Value;

namespace SimulationSteps.StepsEquations.BasicEquations
{
    abstract public class fsOneOperationEquation : fsStepEquation
    {
        fsJustValueParameter result;
        fsJustValueParameter leftValue;
        fsJustValueParameter rightValue;

        public fsOneOperationEquation(
            fsStepParameter result,
            fsStepParameter leftValue,
            fsStepParameter rightValue)
        {
            this.result = InitOutputParameter(result);
            this.leftValue = InitInputParameter(leftValue);
            this.rightValue = InitInputParameter(rightValue);
        }

        public override void Calculate()
        {
            result.Value = Operation(leftValue.Value, rightValue.Value);
        }

        abstract protected fsValue Operation(fsValue leftValue, fsValue rightValue);
    }
}
