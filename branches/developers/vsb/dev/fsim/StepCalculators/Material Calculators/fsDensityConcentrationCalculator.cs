using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;

namespace StepCalculators
{
    public class fsDensityConcentrationCalculator : fsStepCalculator
    {
        private fsCalculatorParameter FiltrateDensity;
        private fsCalculatorParameter SolidsDensity;
        private fsCalculatorParameter SuspensionDensity;
        private fsCalculatorParameter MassConcentration;
        private fsCalculatorParameter VolumeConcentration;
        private fsCalculatorParameter Concentration;

        protected override void InitParameters()
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
            Equations.Add(new fsMassConcentrationEquation(MassConcentration, FiltrateDensity, SolidsDensity, SuspensionDensity));
            Equations.Add(new fsVolumeConcentrationEquation(MassConcentration, FiltrateDensity, SolidsDensity, SuspensionDensity));
            Equations.Add(new fsConcentrationEquation(MassConcentration, FiltrateDensity, SolidsDensity, SuspensionDensity));
        }
    }
}
