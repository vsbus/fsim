using Parameters;
using Equations;

namespace StepCalculators
{
    public class fsEps0Kappa0Calculator : fsCalculator
    {
        readonly fsCalculatorVariable m_porosity0;
        readonly fsCalculatorVariable m_kappa0;
        readonly fsCalculatorConstant m_volumeConcentration;

        public fsEps0Kappa0Calculator()
        {
            #region Parameters Initialization

            m_porosity0 = AddVariable(fsParameterIdentifier.Porosity0);
            m_kappa0 = AddVariable(fsParameterIdentifier.Kappa0);
            m_volumeConcentration = AddConstant(fsParameterIdentifier.VolumeConcentration);

            #endregion

            #region Equations Initialization

            AddEquation(new fsEpsKappaCvEquation(m_porosity0, m_kappa0, m_volumeConcentration));

            #endregion
        }
    }
}
