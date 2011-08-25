using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;
using SimulationSteps.StepsEquations.BasicEquations;

namespace SimulationSteps.GeometryProgressionSteps
{
    public class fsGProgressionInitStep : fsStep
    {
        private fsStepParameter q;
        private fsStepParameter a1;
        private fsStepParameter a2;
        private fsStepParameter a3;
        private fsStepParameter a4;
        private fsStepParameter a5;

        protected override void DefineParameters()
        {
            q = InitParameter(fsParameterIdentifier.q, false);
            a1 = InitParameter(fsParameterIdentifier.a1, false);
            a2 = InitParameter(fsParameterIdentifier.a2, false);
            a3 = InitParameter(fsParameterIdentifier.a3, false);
            a4 = InitParameter(fsParameterIdentifier.a4, false);
            a5 = InitParameter(fsParameterIdentifier.a5, false);
        }

        protected override void DefineEquations()
        {
            Equations.Add(new fsProductEquation(a2, q, a1));
            Equations.Add(new fsProductEquation(a3, q, a2));
            Equations.Add(new fsProductEquation(a4, q, a3));
            Equations.Add(new fsProductEquation(a5, q, a4));

            Equations.Add(new fsDivisionEquation(q, a2, a1));
            Equations.Add(new fsDivisionEquation(q, a3, a2));
            Equations.Add(new fsDivisionEquation(q, a4, a3));
            Equations.Add(new fsDivisionEquation(q, a5, a4));

            Equations.Add(new fsDivisionEquation(a1, a2, q));
            Equations.Add(new fsDivisionEquation(a2, a3, q));
            Equations.Add(new fsDivisionEquation(a3, a4, q));
            Equations.Add(new fsDivisionEquation(a4, a5, q));
        }
    }
}
