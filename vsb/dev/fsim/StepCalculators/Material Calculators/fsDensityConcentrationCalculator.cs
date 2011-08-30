using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;

namespace StepCalculators
{
    public class fsDensityConcentrationCalculator : fsCalculator
    {
        private fsCalculatorParameter FiltrateDensity;
        private fsCalculatorParameter SolidsDensity;
        private fsCalculatorParameter SuspensionDensity;
        private fsCalculatorParameter MassConcentration;
        private fsCalculatorParameter VolumeConcentration;
        private fsCalculatorParameter Concentration;

        protected override void InitParametersAndConstants()
        {
            FiltrateDensity = InitParameter(fsParameterIdentifier.FiltrateDensity);
            SolidsDensity = InitParameter(fsParameterIdentifier.SolidsDensity);
            SuspensionDensity = InitParameter(fsParameterIdentifier.SuspensionDensity);
            MassConcentration = InitParameter(fsParameterIdentifier.MassConcentration);
            VolumeConcentration = InitParameter(fsParameterIdentifier.VolumeConcentration);
            Concentration = InitParameter(fsParameterIdentifier.Concentration);
        }

        protected override void InitEquations()
        {
            AddEquation(new fsMassConcentrationEquation(MassConcentration, FiltrateDensity, SolidsDensity, SuspensionDensity));
            AddEquation(new fsVolumeConcentrationEquation(VolumeConcentration, FiltrateDensity, SolidsDensity, SuspensionDensity));
            AddEquation(new fsConcentrationEquation(Concentration, FiltrateDensity, SolidsDensity, SuspensionDensity));
        }
    }
}
