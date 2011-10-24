using Parameters;
namespace Equations
{
    public class fsMoistureContentEquation : fsCalculatorEquation
    {
        #region Parameters

        readonly IEquationParameter m_moistureContent;
        readonly IEquationParameter m_dryMass;
        readonly IEquationParameter m_wetMass;
        readonly IEquationParameter m_concentration;

        #endregion

        public fsMoistureContentEquation(
            IEquationParameter moistureContent,
            IEquationParameter dryMass,
            IEquationParameter wetMass,
            IEquationParameter concentration)
            : base(moistureContent, dryMass, wetMass, concentration)
        {
            m_moistureContent = moistureContent;
            m_dryMass = dryMass;
            m_wetMass = wetMass;
            m_concentration = concentration;
        }

        protected override void InitFormulas()
        {
            AddFormula(m_moistureContent, MoistureContentFormula);
        }

        #region Formulas

        private void MoistureContentFormula()
        {
            m_moistureContent.Value = (1 - m_dryMass.Value / m_wetMass.Value) / (1 - m_concentration.Value);
        }

        #endregion
    }
}
