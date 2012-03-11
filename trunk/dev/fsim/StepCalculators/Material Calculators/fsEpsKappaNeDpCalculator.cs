using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Equations;
using Parameters;
using Equations.Material.Cake_Moisture_Content_Rf_Equations;
using Equations.Material.Eps_Kappa_Equations;
using Value;

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
            fsCalculatorConstant suspensionSolidsMassFraction = AddConstant(fsParameterIdentifier.SuspensionSolidsMassFraction);
            fsCalculatorConstant solidsDensity = AddConstant(fsParameterIdentifier.SolidsDensity);
            fsCalculatorConstant filtrateDensity = AddConstant(fsParameterIdentifier.FiltrateDensity);

            fsCalculatorVariable porosity0 = AddVariable(fsParameterIdentifier.CakePorosity0);
            fsCalculatorVariable kappa0 = AddVariable(fsParameterIdentifier.Kappa0);
            fsCalculatorVariable cakeDrySolidsDensity0 = AddVariable(fsParameterIdentifier.DryCakeDensity0);

            fsCalculatorVariable porosity = AddVariable(fsParameterIdentifier.CakePorosity);
            fsCalculatorVariable kappa = AddVariable(fsParameterIdentifier.Kappa);
            fsCalculatorVariable cakeDrySolidsDensity = AddVariable(fsParameterIdentifier.DryCakeDensity);

            fsCalculatorVariable cakeWetDensity0 = AddVariable(fsParameterIdentifier.CakeWetDensity0);
            fsCalculatorVariable cakeMoistureContentRf0 = AddVariable(fsParameterIdentifier.CakeMoistureContentRf0);
            fsCalculatorVariable cakeWetMassSolidsFractionRs0 = AddVariable(fsParameterIdentifier.CakeWetMassSolidsFractionRs0);

            #endregion

            #region Equations Initialization

            AddEquation(new fsEpsKappaCvEquation(porosity0, kappa0, volumeConcentration));
            AddEquation(new fsCakeDrySolidsDensityEquation(cakeDrySolidsDensity0, porosity0, solidsDensity));
            AddEquation(new fsEpsKappaCvEquation(porosity, kappa, volumeConcentration));
            AddEquation(new fsCakeDrySolidsDensityEquation(cakeDrySolidsDensity, porosity, solidsDensity));
            AddEquation(new fsFrom0AndDpEquation(porosity, porosity0, pressureDifference, ne));
            AddEquation(new fsMoistureContentFromDensitiesAndPorosityEquation(
                cakeMoistureContentRf0,
                porosity0,
                filtrateDensity,
                solidsDensity));
            var one = new fsCalculatorConstant(new fsParameterIdentifier("one")) { Value = fsValue.One };
            AddEquation(new fsSumEquation(one, cakeMoistureContentRf0, cakeWetMassSolidsFractionRs0));
            AddEquation(new fsCakeWetDensityFromRhofRhosPorosityEquation(
                cakeWetDensity0,
                filtrateDensity,
                solidsDensity,
                porosity0));

            #endregion
        }
    }

}
