using System;
using System.Collections.Generic;

using System.Text;
using Parameters;
using Equations;

namespace StepCalculators
{
    public class fsPc0rc0alpha0Calculator : fsCalculator
    {
        private fsCalculatorVariable Pc0;
        private fsCalculatorVariable rc0;
        private fsCalculatorVariable alpha0;
        private fsCalculatorConstant eps0;
        private fsCalculatorConstant rho_s;

        protected override void InitParameters()
        {
            Pc0 = InitVariable(fsParameterIdentifier.Pc0);
            rc0 = InitVariable(fsParameterIdentifier.rc0);
            alpha0 = InitVariable(fsParameterIdentifier.alpha0);
            eps0 = InitConstant(fsParameterIdentifier.Porosity0);
            rho_s = InitConstant(fsParameterIdentifier.SolidsDensity);
        }

        protected override void InitEquations()
        {
            AddEquation(new fsPcrcEquation(Pc0, rc0));
            AddEquation(new fsAlphaPcEquation(alpha0, Pc0, eps0, rho_s));
        }
    }
}
