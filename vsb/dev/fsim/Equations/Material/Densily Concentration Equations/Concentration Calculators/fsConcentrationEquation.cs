using Parameters;
using Value;

namespace Equations
{
    public class fsConcentrationEquation : fsCalculatorEquation
    {
        #region Parameters

        readonly IEquationParameter m_concentration;
        readonly IEquationParameter m_filtrateDensity;
        readonly IEquationParameter m_solidsDensity;
        readonly IEquationParameter m_suspensionDensity;

        #endregion

        public fsConcentrationEquation(
            IEquationParameter concentration,
            IEquationParameter filtrateDensity,
            IEquationParameter solidsDensity,
            IEquationParameter suspensionDensity)
            : base(
                concentration,
                filtrateDensity,
                solidsDensity,
                suspensionDensity)
        {
            m_concentration = concentration;
            m_filtrateDensity = filtrateDensity;
            m_solidsDensity = solidsDensity;
            m_suspensionDensity = suspensionDensity;
        }

        protected override void InitFormulas()
        {
            AddFormula(m_concentration, ConcentrationFormula);
        }

        #region Formulas

        private void ConcentrationFormula()
        {
            fsValue rhoS = m_solidsDensity.Value;
            fsValue rhoF = m_filtrateDensity.Value;
            fsValue rhoSus = m_suspensionDensity.Value;
            m_concentration.Value = rhoS * (rhoF - rhoSus) / (rhoF - rhoS);
        }

        #endregion
    }
}
