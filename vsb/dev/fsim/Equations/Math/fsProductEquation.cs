using Parameters;

namespace Equations
{
    public class fsProductEquation : fsCalculatorEquation
    {
        // product = firstFactor * secondFactor

        #region Parameters
        
        readonly IEquationParameter m_product;
        readonly IEquationParameter m_firstFactor;
        readonly IEquationParameter m_secondFactor;
        
        #endregion

        public fsProductEquation(
            IEquationParameter product,
            IEquationParameter firstFactor,
            IEquationParameter secondFactor)
            : base (product, firstFactor, secondFactor)
        {
            m_product = product;
            m_firstFactor = firstFactor;
            m_secondFactor = secondFactor;
        }

        protected override void InitFormulas()
        {
            AddFormula(m_product, ProductFormula);
            AddFormula(m_firstFactor, FirstFactorFormula);
            AddFormula(m_secondFactor, SecondFactorFormula);
        }

        #region Formulas

        private void SecondFactorFormula()
        {
            m_secondFactor.Value = m_product.Value / m_firstFactor.Value; 
        }

        private void FirstFactorFormula()
        {
            m_firstFactor.Value = m_product.Value / m_secondFactor.Value;
        }

        private void ProductFormula()
        {
            m_product.Value = m_firstFactor.Value * m_secondFactor.Value;
        }

        #endregion
    }
}
