using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;
using StepCalculators.Cake_Formation.DPConstEquations;

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
        
        protected override void InitParameters()
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
            etaf = InitParameter(fsParameterIdentifier.etaf);
            hce0 = InitParameter(fsParameterIdentifier.hce0);
            Pc = InitParameter(fsParameterIdentifier.Pc);
            kappa = InitParameter(fsParameterIdentifier.kappa);
        }

        protected override void InitEquations()
        {
            Equations.Add(new fsDivisionInverseEquation(CycleTime, RotationalSpeed));
            Equations.Add(new fsDivisionInverseEquation(RotationalSpeed, CycleTime));
            Equations.Add(new fsProductEquation(FormationTime, FormationRelativeTime, CycleTime));
            Equations.Add(new fsCakeHeightFrom_Dp_tf(CakeHeight, hce0, Pc, kappa, Pressure, FormationTime, etaf));
            Equations.Add(new fsVsusFromAreaAndCakeHeightEquation(SuspensionVolume, FilterArea, CakeHeight, kappa));
            Equations.Add(new fsProductEquation(SuspensionMass, SuspensionDensity, SuspensionVolume));
        }
    }
}
