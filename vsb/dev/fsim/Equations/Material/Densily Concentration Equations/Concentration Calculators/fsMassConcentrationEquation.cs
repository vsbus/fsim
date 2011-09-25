using Parameters;
using Value;

namespace Equations
{
    public class fsMassConcentrationEquation : fsCalculatorEquation
    {
        #region Parameters

        readonly IEquationParameter m_solidsMassFraction;
        readonly IEquationParameter m_filtrateDensity;
        readonly IEquationParameter m_solidsDensity;
        readonly IEquationParameter m_suspensionDensity;

        #endregion

        public fsMassConcentrationEquation(
            IEquationParameter solidsMassFraction,
            IEquationParameter filtrateDensity,
            IEquationParameter solidsDensity,
            IEquationParameter suspensionDensity) 
            : base(
                solidsMassFraction,
                filtrateDensity, 
                solidsDensity, 
                suspensionDensity)
        {
            m_solidsMassFraction = solidsMassFraction;
            m_filtrateDensity = filtrateDensity;
            m_solidsDensity = solidsDensity;
            m_suspensionDensity = suspensionDensity;
        }

        protected override void InitFormulas()
        {
            AddFormula(m_solidsMassFraction, MassConcentrationFormula);
            AddFormula(m_filtrateDensity, filtrateDensityFormula);
            AddFormula(m_solidsDensity, solidsDensityFormula);
            AddFormula(m_suspensionDensity, suspensionDensityFormula);
        }

        #region Formulas

        private void MassConcentrationFormula()
        {
            fsValue rhoF = m_filtrateDensity.Value;
            fsValue rhoS = m_solidsDensity.Value;
            fsValue rhoSus = m_suspensionDensity.Value;
            m_solidsMassFraction.Value = rhoS * (rhoF - rhoSus) / rhoSus / (rhoF - rhoS);
        }

        private void filtrateDensityFormula()
        {
            fsValue Cm = m_solidsMassFraction.Value;
            fsValue rhoS = m_solidsDensity.Value;
            fsValue rhoSus = m_suspensionDensity.Value;
            m_filtrateDensity.Value = rhoS * rhoSus * (1 - Cm) / (rhoS - Cm * rhoSus);
        }

        private void solidsDensityFormula()
        {
            fsValue Cm = m_solidsMassFraction.Value;
            fsValue rhoF = m_filtrateDensity.Value;
            fsValue rhoSus = m_suspensionDensity.Value;
            m_solidsDensity.Value = Cm * rhoF * rhoSus / (rhoF - rhoSus * (1 - Cm));
        }

        private void suspensionDensityFormula()
        {
            fsValue Cm = m_solidsMassFraction.Value;
            fsValue rhoF = m_filtrateDensity.Value;
            fsValue rhoS = m_solidsDensity.Value;
            m_suspensionDensity.Value = rhoS * rhoF / (rhoS * (1 - Cm) + Cm * rhoF);
        }

        #endregion
    }
}
