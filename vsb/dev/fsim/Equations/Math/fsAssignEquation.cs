using Parameters;

namespace Equations
{
    public class fsAssignEquation : fsCalculatorEquation
    {
        // x = y

        #region Parameters
        
        readonly IEquationParameter m_left;
        readonly IEquationParameter m_right;
        
        #endregion

        public fsAssignEquation(
            IEquationParameter left,
            IEquationParameter right)
            : base (left, right)
        {
            m_left = left;
            m_right = right;
        }

        protected override void InitFormulas()
        {
            AddFormula(m_left, LeftFormula);
            AddFormula(m_right, RightFormula);
        }

        #region Formulas

        private void LeftFormula()
        {
            m_left.Value = m_right.Value;
        }

        private void RightFormula()
        {
            m_right.Value = m_left.Value;
        }

        #endregion
    }
}
