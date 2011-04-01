using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;
using SimulationSteps.StepsEquations.CubeEquations;

namespace SimulationSteps.CubeSteps
{
    public class fsCubeHeightFromWidthScalingStep : fsStep
    {
        public fsStepParameter width;
        public fsStepParameter length;
        private fsStepParameter height;
        private fsStepParameter volume;
        public fsStepParameter coefficient;

        protected override void DefineParameters()
        {
            height = InitParameter(fsParameterIdentifier.height, false);
            coefficient = InitParameter(fsParameterIdentifier.coefficient, false);
            volume = InitParameter(fsParameterIdentifier.volume, true);
            width = InitParameter(fsParameterIdentifier.width, true);
            length = InitParameter(fsParameterIdentifier.length, true);
        }

        protected override void DefineEquations()
        {
            Equations.Add(new fsScaleEquation(height, width, coefficient));
            Equations.Add(new fsVolumeEquation(volume, height, length, width));
        }
    }
}
