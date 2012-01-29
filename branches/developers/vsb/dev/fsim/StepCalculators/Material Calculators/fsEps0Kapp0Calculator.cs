using Parameters;
using Equations;

namespace StepCalculators
{
    public class fsEps0Kappa0Calculator : fsCalculator
    {
        readonly fsCalculatorVariable m_porosity0;
        readonly fsCalculatorVariable m_kappa0;
        readonly fsCalculatorVariable m_cakeDrySolidsDensity0;
        
        readonly fsCalculatorConstant m_volumeConcentration;
        readonly fsCalculatorConstant m_solidsDensity;

        readonly fsCalculatorVariable m_oneMinusPorosity;

        public fsEps0Kappa0Calculator()
        {
            #region Parameters Initialization

            m_porosity0 = AddVariable(fsParameterIdentifier.CakePorosity0);
            m_kappa0 = AddVariable(fsParameterIdentifier.Kappa0);
            m_cakeDrySolidsDensity0 = AddVariable(fsParameterIdentifier.CakeDrySolidsDensity0);
            m_volumeConcentration = AddConstant(fsParameterIdentifier.SuspensionSolidsVolumeFraction);
            m_solidsDensity = AddConstant(fsParameterIdentifier.SolidsDensity);
            m_oneMinusPorosity = AddVariable(new fsParameterIdentifier("1-eps"));

            #endregion

            #region Equations Initialization

            AddEquation(new fsEpsKappaCvEquation(m_porosity0, m_kappa0, m_volumeConcentration));
            AddEquation(new fsCakeDrySolidsDensityEquation(m_cakeDrySolidsDensity0, m_porosity0, m_solidsDensity));

            #endregion
        }
    }
}
