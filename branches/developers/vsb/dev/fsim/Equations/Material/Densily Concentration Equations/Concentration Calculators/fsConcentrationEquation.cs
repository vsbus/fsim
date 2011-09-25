using Parameters;
using Value;

namespace Equations
{
    public class fsConcentrationEquation : fsCalculatorEquation
    {
        #region Parameters

        readonly IEquationParameter m_solidsConcentration;
        readonly IEquationParameter m_filtrateDensity;
        readonly IEquationParameter m_solidsDensity;
        readonly IEquationParameter m_suspensionDensity;

        #endregion

        public fsConcentrationEquation(
            IEquationParameter solidsConcentration,
            IEquationParameter filtrateDensity,
            IEquationParameter solidsDensity,
            IEquationParameter suspensionDensity)
            : base(
                solidsConcentration,
                filtrateDensity,
                solidsDensity,
                suspensionDensity)
        {
            m_solidsConcentration = solidsConcentration;
            m_filtrateDensity = filtrateDensity;
            m_solidsDensity = solidsDensity;
            m_suspensionDensity = suspensionDensity;
        }

        protected override void InitFormulas()
        {
            AddFormula(m_solidsConcentration, ConcentrationFormula);
            AddFormula(m_filtrateDensity, FiltrateDensityFormula);
            AddFormula(m_solidsDensity, SolidsDensityFormula);
            AddFormula(m_suspensionDensity, SuspensionDensityFormula);
        }

        #region Formulas

        private void ConcentrationFormula()
        {
            fsValue rhoF = m_filtrateDensity.Value;
            fsValue rhoS = m_solidsDensity.Value;
            fsValue rhoSus = m_suspensionDensity.Value;
            m_solidsConcentration.Value = rhoS * (rhoF - rhoSus) / (rhoF - rhoS);
        }

        private void FiltrateDensityFormula()
        {
            fsValue C = m_solidsConcentration.Value;
            fsValue rhoS = m_solidsDensity.Value;
            fsValue rhoSus = m_suspensionDensity.Value;
            m_filtrateDensity.Value = rhoS * (C - rhoSus) / (C - rhoS);
        }

        private void SolidsDensityFormula()
        {
            fsValue C = m_solidsConcentration.Value;
            fsValue rhoF = m_filtrateDensity.Value;
            fsValue rhoSus = m_suspensionDensity.Value;
            m_solidsDensity.Value = C * rhoF / (C + rhoF - rhoSus);
        }

        private void SuspensionDensityFormula()
        {
            fsValue C = m_solidsConcentration.Value;
            fsValue rhoF = m_filtrateDensity.Value;
            fsValue rhoS = m_solidsDensity.Value;
            m_suspensionDensity.Value = (rhoS * rhoF + C * rhoS - C * rhoF) / rhoS;
        }

        #endregion
    }
}
