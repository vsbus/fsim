using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Equations;
using Parameters;

namespace StepCalculators.Material_Calculators
{
    public class fsEpsKappaNeDpCalculator : fsCalculator
    {
        public fsEpsKappaNeDpCalculator()
        {
            #region Parameters Initialization

            fsCalculatorConstant ne = AddConstant(fsParameterIdentifier.Ne);
            fsCalculatorConstant pressureDifference = AddConstant(fsParameterIdentifier.PressureDifference);
            fsCalculatorConstant volumeConcentration = AddConstant(fsParameterIdentifier.SuspensionSolidsVolumeFraction);
            fsCalculatorConstant solidsDensity = AddConstant(fsParameterIdentifier.SolidsDensity);

            fsCalculatorVariable porosity0 = AddVariable(fsParameterIdentifier.CakePorosity0);
            fsCalculatorVariable kappa0 = AddVariable(fsParameterIdentifier.Kappa0);
            fsCalculatorVariable cakeDrySolidsDensity0 = AddVariable(fsParameterIdentifier.DryCakeDensity0);

            fsCalculatorVariable porosity = AddVariable(fsParameterIdentifier.CakePorosity);
            fsCalculatorVariable kappa = AddVariable(fsParameterIdentifier.Kappa);
            fsCalculatorVariable cakeDrySolidsDensity = AddVariable(fsParameterIdentifier.DryCakeDensity);

            #endregion

            #region Equations Initialization

            AddEquation(new fsEpsKappaCvEquation(porosity0, kappa0, volumeConcentration));
            AddEquation(new fsCakeDrySolidsDensityEquation(cakeDrySolidsDensity0, porosity0, solidsDensity));
            AddEquation(new fsEpsKappaCvEquation(porosity, kappa, volumeConcentration));
            AddEquation(new fsCakeDrySolidsDensityEquation(cakeDrySolidsDensity, porosity, solidsDensity));
            AddEquation(new fsFrom0AndDpEquation(porosity, porosity0, pressureDifference, ne));

            #endregion
        }
    }

}
