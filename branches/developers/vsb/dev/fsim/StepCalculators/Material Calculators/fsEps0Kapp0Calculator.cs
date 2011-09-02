using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;
using Equations;

namespace StepCalculators
{
    public class fsEps0Kappa0Calculator : fsCalculator
    {
        private fsCalculatorVariable Porosity0;
        private fsCalculatorVariable Kappa0;
        private fsCalculatorConstant VolumeConcentration;

        public fsEps0Kappa0Calculator()
            : base()
        {
        }

        public fsEps0Kappa0Calculator(fsCalculatorUpdateHandler updateHandler)
            : base(updateHandler)
        {
        }

        protected override void InitParametersAndConstants()
        {
            Porosity0 = InitVariable(fsParameterIdentifier.Porosity0);
            Kappa0 = InitVariable(fsParameterIdentifier.kappa0);
            VolumeConcentration = InitConstant(fsParameterIdentifier.VolumeConcentration);
        }

        protected override void InitEquations()
        {
            AddEquation(new fsEpsKappaCvEquation(Porosity0, Kappa0, VolumeConcentration));
        }
    }
}
