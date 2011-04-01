using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;
using Value;

namespace SimulationSteps.StepsEquations.CubeEquations
{
    public class fsSideFromVolumeEquation : fsStepEquation
    {
        fsEquationParameter side;
        fsEquationParameter volume;

        public fsSideFromVolumeEquation(
            fsStepParameter side,
            fsStepParameter volume)
        {
            this.side = InitOutputParameter(side);
            this.volume = InitInputParameter(volume);
        }

        public override void Calculate()
        {
            side.Value = fsValue.Pow(volume.Value, 1.0 / 3);
        }
    }
}
