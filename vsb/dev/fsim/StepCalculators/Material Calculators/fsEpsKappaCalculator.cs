using Parameters;
using Equations;

namespace StepCalculators
{
    public class fsEpsKappaCalculator : fsCalculator
    {
        readonly fsCalculatorVariable m_porosity;
        readonly fsCalculatorVariable m_kappa;
        readonly fsCalculatorConstant m_volumeConcentration;

        public fsEpsKappaCalculator()
        {
            #region Parameters Initialization

            m_porosity = AddVariable(fsParameterIdentifier.CakePorosity);
            m_kappa = AddVariable(fsParameterIdentifier.Kappa);
            m_volumeConcentration = AddConstant(fsParameterIdentifier.SolidsVolumeFraction);

            #endregion

            #region Equations Initialization

            AddEquation(new fsEpsKappaCvEquation(m_porosity, m_kappa, m_volumeConcentration));

            #endregion
        }
    }
}
