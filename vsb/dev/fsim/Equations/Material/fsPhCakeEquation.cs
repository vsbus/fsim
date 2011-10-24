using System;
using Parameters;
using Value;

namespace Equations
{
    public class fsPhCakeEquation : fsCalculatorEquation
    {
        #region Parameters

        readonly IEquationParameter m_pHCake;
        readonly IEquationParameter m_pH;
        readonly IEquationParameter m_wetMass;
        readonly IEquationParameter m_dryMass;
        readonly IEquationParameter m_liquidMass;

        #endregion

        public fsPhCakeEquation(
            IEquationParameter pHCake,
            IEquationParameter pH,
            IEquationParameter wetMass,
            IEquationParameter dryMass,
            IEquationParameter liquidMass)
            : base(pHCake, pH, wetMass, dryMass, liquidMass)
        {
            m_pHCake = pHCake;
            m_pH = pH;
            m_wetMass = wetMass;
            m_dryMass = dryMass;
            m_liquidMass = liquidMass;
        }

        protected override void InitFormulas()
        {
            AddFormula(m_pHCake, PhCakeFormula);
        }

        #region Formulas

        private void PhCakeFormula()
        {
            m_pHCake.Value = m_pH.Value -
                             fsValue.Log(1 + m_liquidMass.Value / (m_wetMass.Value - m_dryMass.Value)) / Math.Log(10);
        }

        #endregion
    }
}
