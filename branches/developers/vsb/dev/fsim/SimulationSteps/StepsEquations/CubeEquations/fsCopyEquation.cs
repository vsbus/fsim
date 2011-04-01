using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;

namespace SimulationSteps.StepsEquations.CubeEquations
{
    public class fsCopyEquation : fsStepEquation
    {
        fsEquationParameter destination;
        fsEquationParameter source;

        public fsCopyEquation(
            fsStepParameter destination,
            fsStepParameter source)
        {
            this.destination = InitOutputParameter(destination);
            this.source = InitInputParameter(source);
        }

        public override void Calculate()
        {
            destination.Value = source.Value;
        }
    }
}
