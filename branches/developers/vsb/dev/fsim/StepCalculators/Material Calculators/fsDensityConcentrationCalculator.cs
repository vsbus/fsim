using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;
using Equations;

namespace StepCalculators
{
    public class fsDensityConcentrationCalculator : fsCalculator
    {
        private fsCalculatorVariable FiltrateDensity;
        private fsCalculatorVariable SolidsDensity;
        private fsCalculatorVariable SuspensionDensity;
        private fsCalculatorVariable MassConcentration;
        private fsCalculatorVariable VolumeConcentration;
        private fsCalculatorVariable Concentration;

        public fsDensityConcentrationCalculator()
            : base()
        {
        }

        public fsDensityConcentrationCalculator(fsCalculatorUpdateHandler updateHandler)
            : base(updateHandler)
        {
        }

        protected override void InitParametersAndConstants()
        {
            FiltrateDensity = InitVariable(fsParameterIdentifier.FiltrateDensity);
            SolidsDensity = InitVariable(fsParameterIdentifier.SolidsDensity);
            SuspensionDensity = InitVariable(fsParameterIdentifier.SuspensionDensity);
            MassConcentration = InitVariable(fsParameterIdentifier.MassConcentration);
            VolumeConcentration = InitVariable(fsParameterIdentifier.VolumeConcentration);
            Concentration = InitVariable(fsParameterIdentifier.Concentration);
        }

        protected override void InitEquations()
        {
            AddEquation(new fsMassConcentrationEquation(MassConcentration, FiltrateDensity, SolidsDensity, SuspensionDensity));
            AddEquation(new fsVolumeConcentrationEquation(VolumeConcentration, FiltrateDensity, SolidsDensity, SuspensionDensity));
            AddEquation(new fsConcentrationEquation(Concentration, FiltrateDensity, SolidsDensity, SuspensionDensity));
        }
    }
}
