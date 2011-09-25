using Parameters;
using Equations;

namespace StepCalculators
{
    public class fsDensityConcentrationCalculator : fsCalculator
    {
        readonly fsCalculatorVariable m_filtrateDensity;
        readonly fsCalculatorVariable m_solidsDensity;
        readonly fsCalculatorVariable m_suspensionDensity;
        readonly fsCalculatorVariable m_massConcentration;
        readonly fsCalculatorVariable m_volumeConcentration;
        readonly fsCalculatorVariable m_concentration;

        public fsDensityConcentrationCalculator() : base()
        {
            #region Parameters Initialization

            m_filtrateDensity = AddVariable(fsParameterIdentifier.FiltrateDensity);
            m_solidsDensity = AddVariable(fsParameterIdentifier.SolidsDensity);
            m_suspensionDensity = AddVariable(fsParameterIdentifier.SuspensionDensity);
            m_massConcentration = AddVariable(fsParameterIdentifier.SolidsMassFraction);
            m_volumeConcentration = AddVariable(fsParameterIdentifier.SolidsVolumeFraction);
            m_concentration = AddVariable(fsParameterIdentifier.SolidsConcentration);

            #endregion

            #region Equations Initialization

            AddEquation(new fsMassConcentrationEquation(m_massConcentration, m_filtrateDensity, m_solidsDensity, m_suspensionDensity));
            AddEquation(new fsVolumeConcentrationEquation(m_volumeConcentration, m_filtrateDensity, m_solidsDensity, m_suspensionDensity));
            AddEquation(new fsConcentrationEquation(m_concentration, m_filtrateDensity, m_solidsDensity, m_suspensionDensity));

            #endregion
        }
    }
}
