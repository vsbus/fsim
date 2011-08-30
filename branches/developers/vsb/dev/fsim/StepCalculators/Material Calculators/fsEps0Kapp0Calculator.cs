using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;

namespace StepCalculators
{
    public class fsEps0Kappa0Calculator : fsStepCalculator
    {
        private fsCalculatorParameter Porosity0;
        private fsCalculatorParameter Kappa0;
        private fsCalculatorConstant VolumeConcentration;

        protected override void InitParametersAndConstants()
        {
            Porosity0 = InitParameter(fsParameterIdentifier.Porosity0);
            Kappa0 = InitParameter(fsParameterIdentifier.kappa0);
            VolumeConcentration = InitConstant(fsParameterIdentifier.VolumeConcentration);
        }

        protected override void InitEquations()
        {
            AddEquation(new fsKappaFromEpsCvEquation(Kappa0, Porosity0, VolumeConcentration));
            AddEquation(new fsEpsFromKappaCvEquation(Porosity0, Kappa0, VolumeConcentration));
        }
    }
}
