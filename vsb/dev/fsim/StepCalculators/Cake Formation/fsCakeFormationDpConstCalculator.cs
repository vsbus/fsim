using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;

namespace StepCalculators
{
    public class fsCakeFormationDpConstCalculator : fsStepCalculator
    {
        fsCalculatorParameter FilterArea;

        fsCalculatorParameter Pressure;

        fsCalculatorParameter CycleTime;
        fsCalculatorParameter RotationalSpeed;

        fsCalculatorParameter FormationRelativeTime;
        fsCalculatorParameter FormationTime;
        fsCalculatorParameter CakeHeight;
        fsCalculatorParameter SuspensionMass;
        fsCalculatorParameter SuspensionVolume;

        fsCalculatorParameter SuspensionDensity;
        fsCalculatorParameter etaf;
        fsCalculatorParameter hce0;
        fsCalculatorParameter Pc;
        fsCalculatorParameter kappa;

        protected override void InitParametersAndConstants()
        {
            FilterArea = InitParameter(fsParameterIdentifier.FilterArea);

            Pressure = InitParameter(fsParameterIdentifier.Pressure);

            CycleTime = InitParameter(fsParameterIdentifier.CycleTime);
            RotationalSpeed = InitParameter(fsParameterIdentifier.RotationalSpeed);

            FormationRelativeTime = InitParameter(fsParameterIdentifier.FormationRelativeTime);
            FormationTime = InitParameter(fsParameterIdentifier.FormationTime);
            CakeHeight = InitParameter(fsParameterIdentifier.CakeHeight);
            SuspensionMass = InitParameter(fsParameterIdentifier.SuspensionMass);
            SuspensionVolume = InitParameter(fsParameterIdentifier.SuspensionVolume);

            SuspensionDensity = InitParameter(fsParameterIdentifier.SuspensionDensity);
            etaf = InitParameter(fsParameterIdentifier.FiltrateViscosity);
            hce0 = InitParameter(fsParameterIdentifier.hce0);
            Pc = InitParameter(fsParameterIdentifier.Pc);
            kappa = InitParameter(fsParameterIdentifier.kappa);
        }

        protected override void InitEquations()
        {
            AddEquation(new fsDivisionInverseEquation(CycleTime, RotationalSpeed));
            AddEquation(new fsDivisionInverseEquation(RotationalSpeed, CycleTime));
            AddEquation(new fsProductEquation(FormationTime, FormationRelativeTime, CycleTime));
            AddEquation(new fsCakeHeightFrom_Dp_tf(CakeHeight, hce0, Pc, kappa, Pressure, FormationTime, etaf));
            AddEquation(new fsVsusFromAreaAndCakeHeightEquation(SuspensionVolume, FilterArea, CakeHeight, kappa));
            AddEquation(new fsProductEquation(SuspensionMass, SuspensionDensity, SuspensionVolume));
        }
    }
}
