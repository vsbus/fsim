using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;
using SimulationSteps.StepsEquations.CubeEquations;

namespace SimulationSteps.CubeSteps
{
    public class fsCubeFormationStep : fsStep
    {
        private fsStepParameter side;
        private fsStepParameter volume;
        private fsStepParameter height;
        private fsStepParameter length;
        private fsStepParameter width;

        protected override void DefineParameters()
        {
            side = InitParameter(fsParameterIdentifier.side, false);
            volume = InitParameter(fsParameterIdentifier.volume, false);
            height = InitParameter(fsParameterIdentifier.height, false);
            length = InitParameter(fsParameterIdentifier.length, false);
            width = InitParameter(fsParameterIdentifier.width, false);
        }

        protected override void DefineEquations()
        {
            Equations.Add(new fsSideFromVolumeEquation(side, volume));
            Equations.Add(new fsCopyEquation(height, side));
            Equations.Add(new fsCopyEquation(length, side));
            Equations.Add(new fsCopyEquation(width, side));
        }
    }
}
