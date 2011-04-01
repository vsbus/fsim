using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;

namespace SimulationSteps.StepsEquations.CubeEquations
{
    public class fsScaleEquation : fsStepEquation
    {
        fsEquationParameter resultValue;
        fsEquationParameter value;
        fsEquationParameter scale;

        public fsScaleEquation(
            fsStepParameter resultValue,
            fsStepParameter value,
            fsStepParameter scale)
        {
            this.resultValue = InitOutputParameter(resultValue);
            this.value = InitInputParameter(value);
            this.scale = InitInputParameter(scale);
        }

        public override void Calculate()
        {
            resultValue.Value = value.Value * scale.Value;
        }
    }
}
