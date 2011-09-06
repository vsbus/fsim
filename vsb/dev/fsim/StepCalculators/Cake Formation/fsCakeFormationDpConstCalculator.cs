using System;
using System.Collections.Generic;

using System.Text;
using Parameters;
using Equations;

namespace StepCalculators
{
    public class fsCakeFormationDpConstCalculator : fsCalculator
    {
        fsCalculatorConstant SuspensionDensity;
        fsCalculatorConstant etaf;
        fsCalculatorConstant hce0;
        fsCalculatorConstant Porosity0;
        fsCalculatorConstant kappa0;
        fsCalculatorConstant Pc0;
        fsCalculatorConstant ne;
        fsCalculatorConstant nc;
        fsCalculatorConstant VolumeConcentration;

        fsCalculatorVariable FilterArea;

        fsCalculatorVariable Pressure;

        fsCalculatorVariable CycleTime;
        fsCalculatorVariable RotationalSpeed;

        fsCalculatorVariable FormationRelativeTime;
        fsCalculatorVariable FormationTime;
        fsCalculatorVariable CakeHeight;
        fsCalculatorVariable SuspensionMass;
        fsCalculatorVariable SuspensionVolume;

        fsCalculatorVariable Porosity;
        fsCalculatorVariable Pc;
        fsCalculatorVariable kappa;

        protected override void InitParameters()
        {
            SuspensionDensity = InitConstant(fsParameterIdentifier.SuspensionDensity);
            etaf = InitConstant(fsParameterIdentifier.FiltrateViscosity);
            hce0 = InitConstant(fsParameterIdentifier.hce0);
            Porosity0 = InitConstant(fsParameterIdentifier.Porosity0);
            kappa0 = InitConstant(fsParameterIdentifier.kappa0);
            Pc0 = InitConstant(fsParameterIdentifier.Pc0);
            ne = InitConstant(fsParameterIdentifier.ne);
            nc = InitConstant(fsParameterIdentifier.nc);
            VolumeConcentration = InitConstant(fsParameterIdentifier.VolumeConcentration);

            FilterArea = InitVariable(fsParameterIdentifier.FilterArea);

            Pressure = InitVariable(fsParameterIdentifier.Pressure);

            CycleTime = InitVariable(fsParameterIdentifier.CycleTime);
            RotationalSpeed = InitVariable(fsParameterIdentifier.RotationalSpeed);

            FormationRelativeTime = InitVariable(fsParameterIdentifier.FormationRelativeTime);
            FormationTime = InitVariable(fsParameterIdentifier.FormationTime);
            CakeHeight = InitVariable(fsParameterIdentifier.CakeHeight);
            SuspensionMass = InitVariable(fsParameterIdentifier.SuspensionMass);
            SuspensionVolume = InitVariable(fsParameterIdentifier.SuspensionVolume);

            Porosity = InitVariable(fsParameterIdentifier.Porosity);
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
            AddEquation(new fsFrom0AndDpEquation(Porosity, Porosity0, Pressure, ne));
            AddEquation(new fsFrom0AndDpEquation(Pc, Pc0, Pressure, nc));
            AddEquation(new fsEpsKappaCvEquation(Porosity, kappa, VolumeConcentration));
        }
    }
}
