using System;
using System.Collections.Generic;

using System.Text;
using Equations;
using Parameters;

namespace StepCalculators
{
    public class fsRm0hce0Calculator : fsCalculator
    {
        private fsCalculatorVariable hce0;
        private fsCalculatorVariable Rm0;
        private fsCalculatorConstant Pc0;

        protected override void InitParameters()
        {
            hce0 = InitVariable(fsParameterIdentifier.hce0);
            Rm0 = InitVariable(fsParameterIdentifier.Rm0);
            Pc0 = InitConstant(fsParameterIdentifier.Pc0);
        }

        protected override void InitEquations()
        {
            AddEquation(new fsProductEquation(hce0, Pc0, Rm0));
        }
    }
}
