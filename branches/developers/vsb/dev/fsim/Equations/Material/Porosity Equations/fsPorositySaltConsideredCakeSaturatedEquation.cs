using Parameters;
using Value;

namespace Equations
{
    public class fsPorositySaltConsideredCakeSaturatedEquation : fsCalculatorEquation
    {
        #region Parameters

        readonly IEquationParameter m_porosity;
        readonly IEquationParameter m_dryMass;
        readonly IEquationParameter m_wetMass;
        readonly IEquationParameter m_solidsConcentration;
        readonly IEquationParameter m_solidsDensity;
        readonly IEquationParameter m_liquidDensity;

        #endregion

        public fsPorositySaltConsideredCakeSaturatedEquation(
            IEquationParameter porosity,
            IEquationParameter dryMass,
            IEquationParameter wetMass,
            IEquationParameter solidsConcentration,
            IEquationParameter solidsDensity,
            IEquationParameter liquidDensity)
            : base(porosity, dryMass, wetMass, solidsConcentration, solidsDensity, liquidDensity)
        {
            m_porosity = porosity;
            m_dryMass = dryMass;
            m_wetMass = wetMass;
            m_solidsConcentration = solidsConcentration;
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
            fsValue const0 = m_dryMass.Value - (m_wetMass.Value - m_dryMass.Value) * m_solidsConcentration.Value / m_liquidDensity.Value;
            fsValue nom = const0;
            fsValue const1 = m_solidsDensity.Value / m_liquidDensity.Value * (m_wetMass.Value - m_dryMass.Value);
            fsValue den = const1 + const0;
            m_porosity.Value = 1 - nom / den;
        }

        #endregion
    }
}
