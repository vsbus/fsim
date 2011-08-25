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
        fsCalculatorParameter Area;
        fsCalculatorParameter Pressure;
        fsCalculatorParameter CycleTime;
        fsCalculatorParameter CakeHeight;
        fsCalculatorParameter FormationTime;

        protected override void InitParameters()
        {
            Area = InitParameter(fsParameterIdentifier.FilterArea);
            Pressure = InitParameter(fsParameterIdentifier.Pressure);
            CycleTime = InitParameter(fsParameterIdentifier.CycleTime);
            CakeHeight = InitParameter(fsParameterIdentifier.CakeHeight);
            FormationTime = InitParameter(fsParameterIdentifier.FormationTime);
        }

        protected override void InitEquations()
        {
            Equations.Add(new fsFakeEquation(Area, Pressure, CycleTime, CakeHeight, FormationTime));
            Equations.Add(new fsFake2Equation(Area, Pressure));
        }
    }
}
