using Parameters;

namespace Equations
{
    public class fsPorositySaltNeglectedCakeSaturatedEquation : fsCalculatorEquation
    {
        #region Parameters

        readonly IEquationParameter m_porosity;
        readonly IEquationParameter m_dryMass;
        readonly IEquationParameter m_wetMass;
        readonly IEquationParameter m_solidsDensity;
        readonly IEquationParameter m_liquidDensity;

        #endregion

        public fsPorositySaltNeglectedCakeSaturatedEquation(
            IEquationParameter porosity,
            IEquationParameter dryMass,
            IEquationParameter wetMass,
            IEquationParameter solidsDensity,
            IEquationParameter liquidDensity)
            : base(porosity, dryMass, wetMass, solidsDensity, liquidDensity)
        {
            m_porosity = porosity;
            m_dryMass = dryMass;
            m_wetMass = wetMass;
            m_solidsDensity = solidsDensity;
            m_liquidDensity = liquidDensity;
        }

        protected override void InitFormulas()
        {
            AddFormula(m_porosity, PorosityFormula);
        }

        #region Formulas

        private void PorosityFormula()
        {
            m_porosity.Value = 1 - 1 / (m_solidsDensity.Value / m_liquidDensity.Value * (m_wetMass.Value / m_dryMass.Value - 1) + 1);
        }

        #endregion
    }
}
