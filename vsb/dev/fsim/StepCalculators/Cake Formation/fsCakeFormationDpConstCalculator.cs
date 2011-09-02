using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;

namespace StepCalculators
{
    public class fsCakeFormationDpConstCalculator : fsCalculator
    {
        fsCalculatorConstant SuspensionDensity;
        fsCalculatorConstant etaf;
        fsCalculatorConstant hce0;

        fsCalculatorVariable FilterArea;

        fsCalculatorVariable Pressure;

        fsCalculatorVariable CycleTime;
        fsCalculatorVariable RotationalSpeed;

        fsCalculatorVariable FormationRelativeTime;
        fsCalculatorVariable FormationTime;
        fsCalculatorVariable CakeHeight;
        fsCalculatorVariable SuspensionMass;
        fsCalculatorVariable SuspensionVolume;

        fsCalculatorVariable Pc;
        fsCalculatorVariable kappa;

        protected override void InitParametersAndConstants()
        {
            SuspensionDensity = InitConstant(fsParameterIdentifier.SuspensionDensity);
            etaf = InitConstant(fsParameterIdentifier.FiltrateViscosity);
            hce0 = InitConstant(fsParameterIdentifier.hce0);

            FilterArea = InitVariable(fsParameterIdentifier.FilterArea);

            Pressure = InitVariable(fsParameterIdentifier.Pressure);

            CycleTime = InitVariable(fsParameterIdentifier.CycleTime);
            RotationalSpeed = InitVariable(fsParameterIdentifier.RotationalSpeed);

            FormationRelativeTime = InitVariable(fsParameterIdentifier.FormationRelativeTime);
            FormationTime = InitVariable(fsParameterIdentifier.FormationTime);
            CakeHeight = InitVariable(fsParameterIdentifier.CakeHeight);
            SuspensionMass = InitVariable(fsParameterIdentifier.SuspensionMass);
            SuspensionVolume = InitVariable(fsParameterIdentifier.SuspensionVolume);

            Pc = InitVariable(fsParameterIdentifier.Pc);
            kappa = InitVariable(fsParameterIdentifier.kappa);
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
