using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;

namespace SimulationSteps.StepsEquations.CubeEquations
{
    public class fsVolumeEquation : fsStepEquation
    {
        fsJustValueParameter volume;
        fsJustValueParameter height;
        fsJustValueParameter width;
        fsJustValueParameter length;

        public fsVolumeEquation(
            fsStepParameter volume,
            fsStepParameter height,
            fsStepParameter length,
            fsStepParameter width)
        {
            this.volume = InitOutputParameter(volume);

            this.height = InitInputParameter(height);
            this.width = InitInputParameter(width);
            this.length = InitInputParameter(length);
        }

        public override void Calculate()
        {
            volume.Value = height.Value * width.Value * length.Value;
        }

    }
}
