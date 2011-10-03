using Parameters;
using Value;

namespace Equations
{
    public class fsPorosityEquation : fsCalculatorEquation
    {
        #region Parameters

        private bool m_isSaltContentNeglected;
        private bool m_isSaturated;
        readonly IEquationParameter m_porosity;
        readonly IEquationParameter m_dryMass;
        readonly IEquationParameter m_wetMass;
        readonly IEquationParameter m_solidsDensity;
        readonly IEquationParameter m_liquidDensity;
        readonly IEquationParameter m_area;
        readonly IEquationParameter m_solidsConcentration;
        readonly IEquationParameter m_cakeHeight;

        #endregion

        public fsPorosityEquation(
            bool isSaltContentNeglected,
            bool isSaturated,
            IEquationParameter porosity,
            IEquationParameter dryMass,
            IEquationParameter wetMass,
            IEquationParameter solidsDensity,
            IEquationParameter liquidDensity,
            IEquationParameter area,
            IEquationParameter solidsConcentration,
            IEquationParameter cakeHeight)
            : base(porosity)
        {
            m_isSaltContentNeglected = isSaltContentNeglected;
            m_isSaturated = isSaturated;
            m_porosity = porosity;
            m_dryMass = dryMass;
            m_wetMass = wetMass;
            m_solidsDensity = solidsDensity;
            m_liquidDensity = liquidDensity;
            m_area = area;
            m_solidsConcentration = solidsConcentration;
            m_cakeHeight = cakeHeight;
        }

        protected override void InitFormulas()
        {
            if (m_isSaltContentNeglected)
            {
                if (!m_isSaturated)
                {
                    AddFormula(m_porosity, Formula1);
                }
                else
                {
                    AddFormula(m_porosity, Formula2);
                }
            }
            else
            {
                if (!m_isSaturated)
                {
                    AddFormula(m_porosity, Formula3);
                }
                else
                {
                    AddFormula(m_porosity, Formula4);
                }
            }
        }

        #region Formulas

        private void Formula1()
        {
            m_porosity.Value = 1 - m_dryMass.Value / (m_solidsDensity.Value * m_area.Value * m_cakeHeight.Value);
        }

        private void Formula2()
        {
            m_porosity.Value = 1 - 1 / (m_solidsDensity.Value / m_liquidDensity.Value * (m_wetMass.Value / m_dryMass.Value - 1) + 1);
        }

        private void Formula3()
        {
            fsValue nom = m_dryMass.Value - (m_wetMass.Value - m_dryMass.Value) * m_solidsConcentration.Value / m_liquidDensity.Value;
            fsValue den = m_solidsDensity.Value * m_area.Value * m_cakeHeight.Value;
            m_porosity.Value = 1 - nom / den;
        }

        private void Formula4()
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
