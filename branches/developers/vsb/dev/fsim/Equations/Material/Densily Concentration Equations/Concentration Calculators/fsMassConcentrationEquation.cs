using Parameters;
using Value;

namespace Equations
{
    public class fsMassConcentrationEquation : fsCalculatorEquation
    {
        #region Parameters

        readonly IEquationParameter m_massConcentration;
        readonly IEquationParameter m_filtrateDensity;
        readonly IEquationParameter m_solidsDensity;
        readonly IEquationParameter m_suspensionDensity;

        #endregion

        public fsMassConcentrationEquation(
            IEquationParameter massConcentration,
            IEquationParameter filtrateDensity,
            IEquationParameter solidsDensity,
            IEquationParameter suspensionDensity) 
            : base(
                massConcentration,
                filtrateDensity, 
                solidsDensity, 
                suspensionDensity)
        {
            m_massConcentration = massConcentration;
            m_filtrateDensity = filtrateDensity;
            m_solidsDensity = solidsDensity;
            m_suspensionDensity = suspensionDensity;
        }

        protected override void InitFormulas()
        {
            AddFormula(m_massConcentration, MassConcentrationFormula);
        }

        #region Formulas

        private void MassConcentrationFormula()
        {
            fsValue rhoS = m_solidsDensity.Value;
            fsValue rhoF = m_filtrateDensity.Value;
            fsValue rhoSus = m_suspensionDensity.Value;
            m_massConcentration.Value = rhoS * (rhoF - rhoSus) / rhoSus / (rhoF - rhoS);
        }

        #endregion
    }
}
