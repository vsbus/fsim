using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;

namespace StepCalculators
{
    public class fsEps0Kappa0Calculator : fsCalculator
    {
        private fsCalculatorVariable Porosity0;
        private fsCalculatorVariable Kappa0;
        private fsCalculatorConstant VolumeConcentration;

        protected override void InitParametersAndConstants()
        {
            Porosity0 = InitVariable(fsParameterIdentifier.Porosity0);
            Kappa0 = InitVariable(fsParameterIdentifier.kappa0);
            VolumeConcentration = InitConstant(fsParameterIdentifier.VolumeConcentration);
        }

        protected override void InitEquations()
        {
            AddEquation(new fsKappaFromEpsCvEquation(Kappa0, Porosity0, VolumeConcentration));
            AddEquation(new fsEpsFromKappaCvEquation(Porosity0, Kappa0, VolumeConcentration));
        }
    }
}
