using Parameters;
using Equations;

namespace StepCalculators
{
    public class fsEps0Kappa0Calculator : fsCalculator
    {
        public fsEps0Kappa0Calculator()
        {
            #region Parameters Initialization

            fsCalculatorVariable porosity0 = AddVariable(fsParameterIdentifier.CakePorosity0);
            fsCalculatorVariable kappa0 = AddVariable(fsParameterIdentifier.Kappa0);
            fsCalculatorVariable cakeDrySolidsDensity0 = AddVariable(fsParameterIdentifier.DryCakeDensity0);

            fsCalculatorConstant volumeConcentration = AddConstant(fsParameterIdentifier.SuspensionSolidsVolumeFraction);
            fsCalculatorConstant solidsDensity = AddConstant(fsParameterIdentifier.SolidsDensity);

            #endregion

            #region Equations Initialization

            AddEquation(new fsEpsKappaCvEquation(porosity0, kappa0, volumeConcentration));
            AddEquation(new fsCakeDrySolidsDensityEquation(cakeDrySolidsDensity0, porosity0, solidsDensity));

            #endregion
        }
    }
}
